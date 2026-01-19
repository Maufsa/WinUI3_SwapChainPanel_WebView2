using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

using System.Runtime.InteropServices;
using WinRT;
using GlobalStructures;
using static GlobalStructures.GlobalTools;
using Windows.Graphics.Capture;
using DXGI;
using Direct2D;
using static DXGI.DXGITools;
using WebView2;
using static WebView2.WebView2Tools;
using D3D11;
using System.Text;
using System.Text.Json;
using System.ComponentModel;
using WIC;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3_SwapChainPanel_WebView2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        [DllImport("CoreMessaging.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CreateDispatcherQueueController(DispatcherQueueOptions options, /*PDISPATCHERQUEUECONTROLLER**/ [MarshalAs(UnmanagedType.IUnknown)] out object dispatcherQueueController);

        public enum DISPATCHERQUEUE_THREAD_TYPE
        {
            DQTYPE_THREAD_DEDICATED = 1,
            DQTYPE_THREAD_CURRENT = 2,
        };

        public enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        {
            DQTAT_COM_NONE = 0,
            DQTAT_COM_ASTA = 1,
            DQTAT_COM_STA = 2
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct DispatcherQueueOptions
        {
            public uint dwSize;
            public DISPATCHERQUEUE_THREAD_TYPE threadType;
            public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        }

        [DllImport("d3d11.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CreateDirect3D11DeviceFromDXGIDevice(IntPtr dxgiDevice, out IntPtr graphicsDevice);

        [ComImport]
        [Guid("A9B3D012-3DF2-4EE3-B8D1-8695F457D3C1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IDirect3DDxgiInterfaceAccess
        {
            HRESULT GetInterface([MarshalAs(UnmanagedType.LPStruct)] Guid iid, out IntPtr ppv);
        }

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        private static Windows.UI.Composition.Compositor? m_WindowsCompositor;
        //private static Windows.UI.Composition.ContainerVisual? m_RootVisual;
        private static Windows.UI.Composition.ContainerVisual? m_WebView2Visual;
        private static Windows.System.DispatcherQueue? m_DispatcherQueue;

        ID2D1Factory m_pD2DFactory = null;
        ID2D1Factory1 m_pD2DFactory1 = null;
        IWICImagingFactory m_pWICImagingFactory = null;
        IWICImagingFactory2 m_pWICImagingFactory2 = null;

        Windows.Graphics.DirectX.Direct3D11.IDirect3DDevice m_pDirect3DDevice = null;
        ID3D11Device m_pD3D11Device= null;
        IntPtr m_pD3D11DevicePtr = IntPtr.Zero;
        D3D11.ID3D11DeviceContext m_pD3D11DeviceContext = null; 
        IntPtr m_pD3D11DeviceContextPtr = IntPtr.Zero;
        IDXGIDevice1 m_pDXGIDevice = null;

        ID2D1Device m_pD2DDevice = null; // Released in CreateDeviceContextAndDirect3DDevice
        ID2D1DeviceContext m_pD2DDeviceContext = null;

        IDXGISwapChain1 m_pDXGISwapChain1 = null;
        ID2D1Bitmap1 m_pD2DTargetBitmap = null;
        ID2D1Bitmap m_pD2DBitmap1 = null;

        Direct3D11CaptureFramePool m_captureFramePool = null;  
        GraphicsCaptureSession m_captureSession = null;

        private IntPtr hWndMain = IntPtr.Zero;
        int m_nWebView2Width = 900, m_nWebView2Height = 900;

        public MainWindow()
        {
            this.InitializeComponent();
            hWndMain = WinRT.Interop.WindowNative.GetWindowHandle(this);

            InitializeWindowsComposition(hWndMain);

            this.Title = "WinUI 3 : Composited WebView2 rendered with SwapChainPanel";
            Application.Current.Resources["ButtonBackgroundPointerOver"] = new SolidColorBrush(Microsoft.UI.Colors.SteelBlue);
            Application.Current.Resources["ButtonBackgroundPressed"] = new SolidColorBrush(Microsoft.UI.Colors.LightSteelBlue);

            m_pWICImagingFactory = (IWICImagingFactory)Activator.CreateInstance(Type.GetTypeFromCLSID(WICTools.CLSID_WICImagingFactory));
            m_pWICImagingFactory2 = (IWICImagingFactory2)m_pWICImagingFactory;
            HRESULT hr = CreateD2D1Factory();
            if (SUCCEEDED(hr))
            {
                CreateDeviceContextAndDirect3DDevice();
                hr = CreateSwapChain(IntPtr.Zero);
                if (SUCCEEDED(hr))
                {
                    hr = ConfigureSwapChain(hWndMain);
                    ISwapChainPanelNative panelNative = WinRT.CastExtensions.As<ISwapChainPanelNative>(scp1);
                    hr = panelNative.SetSwapChain(m_pDXGISwapChain1);
                    scp1.SizeChanged += Scp1_SizeChanged;
                    scp1.Loaded += Scp1_Loaded;                    
                }

                // Too slow for Direct3D, at least on my old PC :
                // Intel Pentium G3260 3300 MHz
                // Intel® HD Graphics : Intel Xeon E3-1200 v3/4th Gen Core Processor Integrated Graphics Controller
                // Monitor Philips 247ELH PHLC085, 60-75 Hz

                // CompositionTarget.Rendering += CompositionTarget_Rendering;
            }

            // Define JSON file path in LocalAppData
            string sFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebView2");
            Directory.CreateDirectory(sFolder);
            // C:\Users\Christian\AppData\Local\WebView2\url_history.json
            m_sHistoryFile = Path.Combine(sFolder, "url_history.json");
            LoadHistory();

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal;

            this.Closed += MainWindow_Closed;
        }
        
        private async void Scp1_Loaded(object sender, RoutedEventArgs e)
        {
            HRESULT hr = HRESULT.S_OK;
            var options = new CoreWebView2EnvironmentOptionsClass
            {
                AdditionalArgs = "--enable-features=OverlayScrollbar,OverlayScrollbarWinStyle,OverlayScrollbarWinStyleAnimation", // default ?               
                Language = "en-US", // MSDN : It applies to browser UIs such as context menu and dialogs. It also applies to the accept-languages HTTP header that WebView sends to websites
                //TargetVersion = "123.0.0.0",
                //TargetVersion = "142.0.3595.90",
                TargetVersion = "144.0.3712.0",
                AllowSSO = true
            };

            // To get first Canary Runtime
            //options.ChannelSearchKind = COREWEBVIEW2_CHANNEL_SEARCH_KIND.COREWEBVIEW2_CHANNEL_SEARCH_KIND_LEAST_STABLE;

            IntPtr pOptions = Marshal.GetIUnknownForObject(options);
            hr = CreateCoreWebView2EnvironmentWithOptions(null, null, pOptions, new EnvironmentCompletedHandler(this, hWndMain));
            if (!SUCCEEDED(hr))
            {
                string sError = "Could not create CoreWebView2" + "\r\n" + "HRESULT = 0x" + string.Format("{0:X}", hr) + "\r\n" + Marshal.GetExceptionForHR((int)hr)?.Message;
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWndMain);
                _ = await md.ShowAsync();
            }
            Marshal.Release(pOptions);
        }

        private class EnvironmentCompletedHandler : ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler
        {
            private readonly MainWindow _owner;
            private readonly IntPtr _hWnd;

            public EnvironmentCompletedHandler(MainWindow owner, IntPtr hWnd)
            {
                _owner = owner;
                _hWnd = hWnd;
            }

            public HRESULT Invoke(HRESULT result, ICoreWebView2Environment environment)
            {
                HRESULT hr = HRESULT.S_OK;

                System.Diagnostics.Debug.WriteLine("WebView2 environment created");

                var env3 = environment as ICoreWebView2Environment3;
                if (env3 != null)
                {
                    var env10 = (ICoreWebView2Environment10)env3;

                    // C:\Program Files (x86)\Microsoft\EdgeWebView\Application
                    // 145.0.3770.0 canary
                    hr = env3.get_BrowserVersionString(out string sVersion);

                    hr = env10.CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions options);
                    var options4 = (ICoreWebView2ControllerOptions4)options;
                    hr = options4.get_AllowHostInputProcessing(out bool bHIP); // false
                    //hr = options4.put_AllowHostInputProcessing(true);                  

                    hr = options4.get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR color);
                    // DimGray
                    //color.R = 0x69;
                    //color.G = 0x69;
                    //color.B = 0x69;
                    // MidnightBlue
                    color.R = 0x19;
                    color.G = 0x19;
                    color.B = 0x70;
                    //color.A = 255;
                    color.A = 0; // Transparent
                    hr = options4.put_DefaultBackgroundColor(color);
                    
                    hr = env10.CreateCoreWebView2CompositionControllerWithOptions(_hWnd, options4, new CompositionControllerCompletedHandler(_owner, _hWnd));
                    SafeRelease(ref env10);
                    SafeRelease(ref options4);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Environment does not support composition controller");
                }
                return hr;
            }
        }

        private static void AttachWebViewToVisualTree(Windows.UI.Composition.ContainerVisual? containerVisual)
        {
            if (containerVisual != null && m_pCompositionController != null)
            {
                IntPtr pUnknown = Marshal.GetIUnknownForObject(containerVisual);
                m_pCompositionController.put_RootVisualTarget(pUnknown);
                Marshal.Release(pUnknown);
            }
        }

        private static ICoreWebView2CompositionController? m_pCompositionController = null;
        private static ICoreWebView2Controller2? m_pController2 = null;
        private static ICoreWebView2? m_pCoreWebView2 = null;

        private class CompositionControllerCompletedHandler : ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler
        {
            private readonly MainWindow _owner;
            private readonly IntPtr _hWnd;

            public CompositionControllerCompletedHandler(MainWindow owner, IntPtr hWnd)
            {
                _owner = owner;
                _hWnd = hWnd;
            }

            public HRESULT Invoke(HRESULT result, ICoreWebView2CompositionController compositionController)
            {
                HRESULT hr = HRESULT.S_OK;
                if (compositionController != null)
                {
                    System.Diagnostics.Debug.WriteLine("Composition controller created");

                    m_pCompositionController = compositionController;

                    ICoreWebView2Controller controller = (ICoreWebView2Controller)compositionController;
                    m_pController2 = (ICoreWebView2Controller2)controller;

                    hr = m_pController2.put_IsVisible(true);
                    hr = m_pController2.get_CoreWebView2(out m_pCoreWebView2);

                    // If no history, pre-load a url/video (actually "Guru Josh Project - Infinity 2008")
                    if (_owner.m_History.Count == 0)
                    {
                        //_owner.tbURL.Text = "http://www.google.com";
                        //_owner.tbURL.Text = "https://www.yout-ube.com/watch?v=DvyCbevQbtI&list=RDDvyCbevQbtI&iv_load_policy=3&loop=1&start=";
                        _owner.tbURL.Text = "https://www.yout-ube.com/watch?v=jzy2dgEUOhY&autoplay=1&iv_load_policy=3&loop=1&start=";
                        //string sURL = _owner.NormalizeUrl(_owner.tbURL.Text);
                        //hr = m_pCoreWebView2.Navigate(sURL);
                    }

                    AttachWebViewToVisualTree(m_WebView2Visual);

                    var c4 = (ICoreWebView2Controller4)m_pController2;
                    hr = c4.get_AllowExternalDrop(out bool bDrop); // true

                    hr = c4.get_BoundsMode(out COREWEBVIEW2_BOUNDS_MODE nBounsMode);
                    //hr = c4.put_BoundsMode(COREWEBVIEW2_BOUNDS_MODE.COREWEBVIEW2_BOUNDS_MODE_USE_RASTERIZATION_SCALE);

                    hr = m_pController2.get_Bounds(out RECT rcBounds);
                    if (SUCCEEDED(hr))
                    {
                        if (_owner.tsRender3D.IsOn)
                        {
                            if (m_WebView2Visual != null)
                            {
                                rcBounds.left = (int)m_WebView2Visual.Offset.X;
                                rcBounds.top = (int)m_WebView2Visual.Offset.Y;
                                rcBounds.right = (int)(m_WebView2Visual.Offset.X + m_WebView2Visual.Size.X);
                                rcBounds.bottom = (int)(m_WebView2Visual.Offset.Y + m_WebView2Visual.Size.Y);
                                hr = m_pController2.put_Bounds(rcBounds);
                            }
                        }
                        else
                        {
                            if (m_WebView2Visual != null)
                            {
                                m_WebView2Visual.Size = new System.Numerics.Vector2((float)_owner.scp1.ActualWidth, (float)_owner.scp1.ActualHeight);
                                rcBounds.left = (int)m_WebView2Visual.Offset.X;
                                rcBounds.top = (int)m_WebView2Visual.Offset.Y;
                                rcBounds.right = (int)(m_WebView2Visual.Offset.X + m_WebView2Visual.Size.X);
                                rcBounds.bottom = (int)(m_WebView2Visual.Offset.Y + m_WebView2Visual.Size.Y);
                                hr = m_pController2.put_Bounds(rcBounds);
                            }
                        }
                    }

                    //var cursorHandler = new CoreWebView2CursorChangedEventHandler(_hWnd);
                    //hr = m_pCompositionController.add_CursorChanged(cursorHandler, out EventRegistrationToken _);

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Failed to create Composition controller");
                }
                return hr;
            }
        }

        // Vertex structure
        [StructLayout(LayoutKind.Sequential)]
        struct Vertex
        {
            public System.Numerics.Vector3 Position;
            public System.Numerics.Vector2 TexCoord;
        }

        // Cube vertex buffer
        Vertex[] cubeVertices = new Vertex[]
        {
            // Front face
            new() { Position = new(-1, -1, -1), TexCoord = new(0,1) },
            new() { Position = new(-1,  1, -1), TexCoord = new(0,0) },
            new() { Position = new( 1,  1, -1), TexCoord = new(1,0) },
            new() { Position = new( 1, -1, -1), TexCoord = new(1,1) },

            // Back face
            new() { Position = new( 1, -1,  1), TexCoord = new(0,1) },
            new() { Position = new( 1,  1,  1), TexCoord = new(0,0) },
            new() { Position = new(-1,  1,  1), TexCoord = new(1,0) },
            new() { Position = new(-1, -1,  1), TexCoord = new(1,1) },

            // Left face
            new() { Position = new(-1, -1,  1), TexCoord = new(0,1) },
            new() { Position = new(-1,  1,  1), TexCoord = new(0,0) },
            new() { Position = new(-1,  1, -1), TexCoord = new(1,0) },
            new() { Position = new(-1, -1, -1), TexCoord = new(1,1) },

            // Right face
            new() { Position = new( 1, -1, -1), TexCoord = new(0,1) },
            new() { Position = new( 1,  1, -1), TexCoord = new(0,0) },
            new() { Position = new( 1,  1,  1), TexCoord = new(1,0) },
            new() { Position = new( 1, -1,  1), TexCoord = new(1,1) },

            // Top face
            new() { Position = new(-1,  1, -1), TexCoord = new(0,1) },
            new() { Position = new(-1,  1,  1), TexCoord = new(0,0) },
            new() { Position = new( 1,  1,  1), TexCoord = new(1,0) },
            new() { Position = new( 1,  1, -1), TexCoord = new(1,1) },

            // Bottom face
            new() { Position = new(-1, -1,  1), TexCoord = new(0,1) },
            new() { Position = new(-1, -1, -1), TexCoord = new(0,0) },
            new() { Position = new( 1, -1, -1), TexCoord = new(1,0) },
            new() { Position = new( 1, -1,  1), TexCoord = new(1,1) },
        };

        // Cube indices
        ushort[] cubeIndices = new ushort[]
        {
            0,1,2, 0,2,3,
            4,5,6, 4,6,7,
            8,9,10, 8,10,11,
            12,13,14, 12,14,15,
            16,17,18, 16,18,19,
            20,21,22, 20,22,23
        };

        D3D11.ID3D11Buffer? m_cubeVertexBuffer;
        D3D11.ID3D11Buffer? m_cubeIndexBuffer;
        D3D11.ID3D11Buffer? m_constantBuffer;

        D3D11.ID3D11RasterizerState? m_rs;

        // To draw cube edges (not visible if uniform background)
        D3D11.ID3D11Buffer? m_edgeVertexBuffer;
        D3D11.ID3D11Buffer? m_edgeIndexBuffer;
        D3D11.ID3D11PixelShader? m_psEdge;
        D3D11.ID3D11DepthStencilState? m_dsEdges;
        // Edge vertex layout must match Vertex struct (Position, TexCoord).
        // TexCoord are unused for edges — set to zero.
        Vertex[] edgeVertices = new Vertex[]
        {
            new() { Position = new(-1f, -1f, -1f), TexCoord = new(0,0) }, // 0
            new() { Position = new( 1f, -1f, -1f), TexCoord = new(0,0) }, // 1
            new() { Position = new( 1f,  1f, -1f), TexCoord = new(0,0) }, // 2
            new() { Position = new(-1f,  1f, -1f), TexCoord = new(0,0) }, // 3
            new() { Position = new(-1f, -1f,  1f), TexCoord = new(0,0) }, // 4
            new() { Position = new( 1f, -1f,  1f), TexCoord = new(0,0) }, // 5
            new() { Position = new( 1f,  1f,  1f), TexCoord = new(0,0) }, // 6
            new() { Position = new(-1f,  1f,  1f), TexCoord = new(0,0) }  // 7
        };

        // 12 edges, each as a pair of vertex indices
        ushort[] edgeIndices = new ushort[]
        {
            0,1, 1,2, 2,3, 3,0, // front rectangle (-z)
            4,5, 5,6, 6,7, 7,4, // back rectangle (+z)
            0,4, 1,5, 2,6, 3,7  // vertical edges
        };

        // Render targets
        D3D11.ID3D11RenderTargetView? m_rtv;
        D3D11.ID3D11DepthStencilView? m_dsv;

        // Pipeline
        D3D11.ID3D11VertexShader? m_cubeVS;
        D3D11.ID3D11PixelShader? m_cubePS;
        D3D11.ID3D11InputLayout? m_inputLayout;
        D3D11.ID3D11SamplerState? m_sampler;

        [StructLayout(LayoutKind.Sequential)]
        public struct CBMVP
        {
            public float m11, m12, m13, m14;
            public float m21, m22, m23, m24;
            public float m31, m32, m33, m34;
            public float m41, m42, m43, m44;
        }

        // Swirl

        D3D11.ID3D11VertexShader? m_swirlVS;
        D3D11.ID3D11PixelShader? m_swirlPS;
        D3D11.ID3D11Buffer? m_cbTime;

        // Paper

        [StructLayout(LayoutKind.Sequential)]
        struct PaperCB
        {
            public System.Numerics.Matrix4x4 WorldViewProj;
            public float Theta;
            public System.Numerics.Vector3 Padding; // 16-byte alignment
        }

        D3D11.ID3D11Buffer? m_paperVertexBuffer;
        D3D11.ID3D11Buffer? m_paperIndexBuffer;
        D3D11.ID3D11Buffer? m_paperConstantBuffer;
        D3D11.ID3D11VertexShader? m_paperVS;
        D3D11.ID3D11PixelShader? m_paperPS;

        uint m_paperIndexCount; 

        // Tunnel

        [StructLayout(LayoutKind.Sequential)]
        struct TunnelVertex
        {
            public System.Numerics.Vector3 Position;
            public System.Numerics.Vector3 Normal;
            public System.Numerics.Vector2 UV;
        }

        D3D11.ID3D11Buffer? m_tunnelVB;
        D3D11.ID3D11Buffer? m_tunnelIB;
        D3D11.ID3D11Buffer? m_tunnelConstantBuffer;
        D3D11.ID3D11VertexShader? m_tunnelVS;
        D3D11.ID3D11PixelShader? m_tunnelPS;
        D3D11.ID3D11InputLayout? m_tunnelInputLayout;
        D3D11.ID3D11SamplerState? m_samplerWrap;

        int m_nTunnelIndexCount;

        [StructLayout(LayoutKind.Sequential)]
        struct TunnelCB
        {
            public System.Numerics.Matrix4x4 World;
            public System.Numerics.Matrix4x4 ViewProj;
            public float Time;
            public float Twist;
            public float FadeStart;
            public float FadeEnd;
            public float DepthSpeed;
            public System.Numerics.Vector3 Padding; // alignment
        }

        D3D11.ID3D11ShaderResourceView? m_tunnelSRV;


        private Direct2D.ID3D11Texture2D GetTexture2D(Windows.Graphics.DirectX.Direct3D11.IDirect3DSurface surface)
        {
            var pAccess = surface.As<IDirect3DDxgiInterfaceAccess>();
            Guid iid = typeof(Direct2D.ID3D11Texture2D).GUID;
            pAccess.GetInterface(iid, out IntPtr ptexPtr);

            var texture = (Direct2D.ID3D11Texture2D)Marshal.GetObjectForIUnknown(ptexPtr);
            Marshal.Release(ptexPtr);
            return texture;
        }

        D3D11.ID3D11ShaderResourceView? m_captureSRV;

        void CreateOrUpdateSRV(Direct2D.ID3D11Texture2D texture)
        {
            texture.GetDesc(out var desc);
            if (m_captureSRV != null && desc.Width == m_nRenderWidth && desc.Height == m_nRenderHeight)           
                return;         

            SafeRelease(ref m_captureSRV);

            var srvDesc = new D3D11.D3D11_SHADER_RESOURCE_VIEW_DESC
            {
                Format = desc.Format,
                ViewDimension = D3D11.D3D11_SRV_DIMENSION.D3D11_SRV_DIMENSION_TEXTURE2D,
            };           
            srvDesc.Anonymous.Texture2D = new D3D11.D3D11_TEX2D_SRV
            {
                MipLevels = 1,
                MostDetailedMip = 0
            };
            m_pD3D11Device.CreateShaderResourceView((D3D11.ID3D11Resource)texture, ref srvDesc, out m_captureSRV);
        }

        HRESULT CreateRenderTargetView()
        {
            Guid iid = typeof(D3D11.ID3D11Texture2D).GUID;
            HRESULT hr = m_pDXGISwapChain1.GetBuffer(0, ref iid, out IntPtr backBufferPtr);
            if (SUCCEEDED(hr))
            {
                var backBuffer = (D3D11.ID3D11Texture2D)Marshal.GetObjectForIUnknown(backBufferPtr);
                hr = m_pD3D11Device.CreateRenderTargetView(backBuffer, IntPtr.Zero, out m_rtv);
                SafeRelease(ref backBuffer);
                Marshal.Release(backBufferPtr);
            }
            return hr;
        }

        HRESULT CreateDepthStencilView(int nWidth, int nHeight)
        {
            D3D11.D3D11_TEXTURE2D_DESC depthDesc = new()
            {
                Width = (uint)nWidth,
                Height = (uint)nHeight,
                MipLevels = 1,
                ArraySize = 1,
                Format = DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT,
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1, Quality = 0 },
                Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                BindFlags = D3D11_BIND_FLAG.D3D11_BIND_DEPTH_STENCIL
            };  
            HRESULT hr = m_pD3D11Device.CreateTexture2D(ref depthDesc, IntPtr.Zero, out D3D11.ID3D11Texture2D pDepthTexture);
            if (SUCCEEDED(hr))
            {
                hr = m_pD3D11Device.CreateDepthStencilView(pDepthTexture, IntPtr.Zero, out m_dsv);
                SafeRelease(ref pDepthTexture);
            }
            return hr;
        }

        private async void btnCaptureRender_Click(object sender, RoutedEventArgs e)
        {
            if (m_pCoreWebView2 != null)
            {
                // Vertex/Pixel Shaders done with help from ChatGPT...

                HRESULT hr = HRESULT.S_OK;
                // Create vertex buffer
                D3D11.D3D11_BUFFER_DESC vbDesc = new()
                {
                    ByteWidth = (uint)(Marshal.SizeOf<Vertex>() * cubeVertices.Length),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_VERTEX_BUFFER,
                };

                D3D11_SUBRESOURCE_DATA vbData = new() { pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(cubeVertices, 0) };
                IntPtr pVerticesData = Marshal.AllocHGlobal(Marshal.SizeOf(vbData));
                Marshal.StructureToPtr(vbData, pVerticesData, false);
                hr = m_pD3D11Device.CreateBuffer(ref vbDesc, pVerticesData, out m_cubeVertexBuffer);
                Marshal.FreeHGlobal(pVerticesData);

                // Create index buffer
                D3D11.D3D11_BUFFER_DESC ibDesc = new()
                {
                    ByteWidth = (uint)(sizeof(ushort) * cubeIndices.Length),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_INDEX_BUFFER,
                };

                D3D11_SUBRESOURCE_DATA ibData = new() { pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(cubeIndices, 0) };
                IntPtr pIndicesData = Marshal.AllocHGlobal(Marshal.SizeOf(ibData));
                Marshal.StructureToPtr(ibData, pIndicesData, false);
                hr = m_pD3D11Device.CreateBuffer(ref ibDesc, pIndicesData, out m_cubeIndexBuffer);
                Marshal.FreeHGlobal(pIndicesData);

                // Create constant buffer
                D3D11.D3D11_BUFFER_DESC cbDesc = new()
                {
                    //ByteWidth = (uint)((Marshal.SizeOf<CBMVP>() + 15) & ~15), // 16-byte aligned
                    ByteWidth = 64,
                    //Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                    CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                };
                hr = m_pD3D11Device.CreateBuffer(ref cbDesc, IntPtr.Zero, out m_constantBuffer);
                m_pD3D11DeviceContext.VSSetConstantBuffers(0, 1, (new[] { m_constantBuffer }));

                string vsSource = @"
cbuffer MVP : register(b0)
{
    float4x4 mvp;
};

struct VSIn
{
    float3 pos : POSITION;
    float2 uv  : TEXCOORD0;
};

struct PSIn
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
};

PSIn VSMain(VSIn input)
{
    PSIn o;
    o.pos = mul(float4(input.pos, 1), mvp);
    o.uv = input.uv;
    return o;
}
";

                byte[] vsBytes = Encoding.ASCII.GetBytes(vsSource + "\0");
                hr = D3D11Tools.D3DCompile(vsBytes, vsBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "VSMain", "vs_5_0", 0, 0, out IntPtr vsBlob, out IntPtr vsErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var vsErrorBlobObj = Marshal.GetObjectForIUnknown(vsErrorBlob) as ID3DBlob;
                    if (vsErrorBlobObj == null)
                        throw new Exception("Failed to get ID3DBlob from vsErrorBlob");
                    IntPtr ptr = vsErrorBlobObj.GetBufferPointer();
                    int nSize = (int)vsErrorBlobObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(vsErrorBlob);
                    throw new Exception(sError);
                }

                var vsBlobObj = Marshal.GetObjectForIUnknown(vsBlob) as ID3DBlob;
                if (vsBlobObj == null)
                    throw new Exception("Failed to get ID3DBlob from vsBlob");

                IntPtr pVSBytecode = vsBlobObj.GetBufferPointer();
                uint nBytecodeSize = (uint)vsBlobObj.GetBufferSize();

                hr = m_pD3D11Device.CreateVertexShader(pVSBytecode, nBytecodeSize, null, out m_cubeVS);

                SafeRelease(ref vsBlobObj);              

                D3D11_INPUT_ELEMENT_DESC[] layout =
                    {
                    new D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = "POSITION",
                        SemanticIndex = 0,
                        Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,
                        InputSlot = 0,
                        AlignedByteOffset = 0,
                        InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
                        InstanceDataStepRate = 0
                    },
                    new D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = "TEXCOORD",
                        SemanticIndex = 0,
                        Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT,
                        InputSlot = 0,
                        AlignedByteOffset = 12,
                        InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
                        InstanceDataStepRate = 0
                    }
                };

                hr = m_pD3D11Device.CreateInputLayout(layout, (uint)layout.Length, pVSBytecode, (nint)nBytecodeSize, out m_inputLayout);

                Marshal.Release(vsBlob);

                string psSource = @"
Texture2D tex0 : register(t0);
SamplerState samp0 : register(s0);

struct PSIn
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
};

float4 PSMain(PSIn input) : SV_Target
{
    float2 uv = input.uv;
    uv.y = 1.0 - uv.y;   // vertical flip
    return tex0.Sample(samp0, uv);
}
";

                byte[] psBytes = Encoding.ASCII.GetBytes(psSource + "\0");
                hr = D3D11Tools.D3DCompile(psBytes, psBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "PSMain", "ps_5_0", 0, 0, out IntPtr psBlob, out IntPtr psErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var psErrorBlobObj = Marshal.GetObjectForIUnknown(psErrorBlob) as ID3DBlob;
                    if (psErrorBlobObj == null)
                        throw new Exception("Failed to get ID3DBlob from psErrorBlob");
                    IntPtr ptr = psErrorBlobObj.GetBufferPointer();
                    int nSize = (int)psErrorBlobObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(psErrorBlob);
                    throw new Exception(sError);
                }

                var psBlobObj = Marshal.GetObjectForIUnknown(psBlob) as ID3DBlob;
                if (psBlobObj == null)
                    throw new Exception("Failed to get ID3DBlob from vsBlob");
                IntPtr pPSBytecode = psBlobObj.GetBufferPointer();
                nBytecodeSize = (uint)psBlobObj.GetBufferSize();

                hr = m_pD3D11Device.CreatePixelShader(pPSBytecode, nBytecodeSize, null, out m_cubePS);

                SafeRelease(ref psBlobObj);
                Marshal.Release(psBlob);

                D3D11.D3D11_SAMPLER_DESC sampDesc = new()
                {
                    Filter = D3D11.D3D11_FILTER.D3D11_FILTER_MIN_MAG_MIP_LINEAR,
                    AddressU = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
                    AddressV = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
                    AddressW = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_CLAMP,
                    ComparisonFunc = D3D11.D3D11_COMPARISON_FUNC.D3D11_COMPARISON_NEVER,
                    MinLOD = 0,
                    MaxLOD = float.MaxValue
                };

                hr = m_pD3D11Device.CreateSamplerState(ref sampDesc, out m_sampler);

                D3D11.D3D11_RASTERIZER_DESC rs = new()
                {
                    FillMode = D3D11.D3D11_FILL_MODE.D3D11_FILL_SOLID,
                    CullMode = D3D11.D3D11_CULL_MODE.D3D11_CULL_NONE,
                    DepthClipEnable = true
                };

                m_pD3D11Device.CreateRasterizerState(ref rs, out m_rs);

                string swirlVS = @"
struct VSOut
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
};

VSOut VSMain(uint id : SV_VertexID)
{
    float2 pos[3] =
    {
        float2(-1, -1),
        float2(-1,  3),
        float2( 3, -1)
    };

    VSOut o;
    o.pos = float4(pos[id], 0, 1);
    o.uv  = o.pos.xy * 0.5 + 0.5;
    return o;
}
";

                byte[] swirlVSBytes = Encoding.ASCII.GetBytes(swirlVS + "\0");
                hr = D3D11Tools.D3DCompile(swirlVSBytes, swirlVSBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "VSMain", "vs_5_0", 0, 0, out IntPtr swirlVSBlob, out IntPtr swirlVSErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var swirlVSErrorBlobObj = Marshal.GetObjectForIUnknown(swirlVSErrorBlob) as ID3DBlob;
                    if (swirlVSErrorBlobObj == null)
                        throw new Exception("Failed to get ID3DBlob from swirlVSErrorBlob");
                    IntPtr ptr = swirlVSErrorBlobObj.GetBufferPointer();
                    int nSize = (int)swirlVSErrorBlobObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(swirlVSErrorBlob);
                    throw new Exception(sError);
                }

                var swirlVSBlobObj = (ID3DBlob)Marshal.GetObjectForIUnknown(swirlVSBlob);
                m_pD3D11Device.CreateVertexShader(swirlVSBlobObj.GetBufferPointer(), (uint)swirlVSBlobObj.GetBufferSize(), null, out m_swirlVS);
                SafeRelease(ref swirlVSBlobObj);
                Marshal.Release(swirlVSBlob);

                string swirlPS = @"
cbuffer Time : register(b1)
{
    float time;
};

float4 PSMain(float4 pos : SV_POSITION, float2 uv : TEXCOORD0) : SV_Target
{
    float2 p = uv * 2.0 - 1.0;
    float r = length(p);
    float a = atan2(p.y, p.x);

    float t = time * 2.0;
    float depth = 1.0 / (r + 0.3);

    float wave = sin(a * 6.0 + t + r * 10.0);
    float glow = exp(-r * 3.0);

    float3 color =
        float3(
            0.5 + 0.5 * sin(t + a),
            0.5 + 0.5 * sin(t + a + 2.0),
            0.5 + 0.5 * sin(t + a + 4.0)
        );

    color *= depth * glow * (1.0 + wave * 0.3);

    return float4(color, 1.0);
}
";

                byte[] swirlPSBytes = Encoding.ASCII.GetBytes(swirlPS + "\0");
                hr = D3D11Tools.D3DCompile(swirlPSBytes, swirlPSBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "PSMain", "ps_5_0", 0, 0, out IntPtr swirlPSBlob, out IntPtr swirlPSErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var swirlPSErrorBlobObj = Marshal.GetObjectForIUnknown(swirlPSErrorBlob) as ID3DBlob;
                    if (swirlPSErrorBlobObj == null)
                        throw new Exception("Failed to get ID3DBlob from swirlPSErrorBlob");
                    IntPtr ptr = swirlPSErrorBlobObj.GetBufferPointer();
                    int nSize = (int)swirlPSErrorBlobObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(swirlPSErrorBlob);
                    throw new Exception(sError);
                }

                var psBlobSwirlObj = (ID3DBlob)Marshal.GetObjectForIUnknown(swirlPSBlob);
                m_pD3D11Device.CreatePixelShader(psBlobSwirlObj.GetBufferPointer(), (uint)psBlobSwirlObj.GetBufferSize(), null, out m_swirlPS);
                SafeRelease(ref psBlobSwirlObj);
                Marshal.Release(swirlPSBlob);

                D3D11.D3D11_BUFFER_DESC desc = new()
                {
                    ByteWidth = 16,
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                    CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE
                };

                m_pD3D11Device.CreateBuffer(ref desc, IntPtr.Zero, out m_cbTime);

                // Added with Copilot...

                // Create edge vertex buffer
                D3D11.D3D11_BUFFER_DESC vbEdgeDesc = new()
                {
                    ByteWidth = (uint)(Marshal.SizeOf<Vertex>() * edgeVertices.Length),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_VERTEX_BUFFER,
                };
                D3D11_SUBRESOURCE_DATA vbEdgeData = new() { pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(edgeVertices, 0) };
                IntPtr pVBEData = Marshal.AllocHGlobal(Marshal.SizeOf(vbEdgeData));
                Marshal.StructureToPtr(vbEdgeData, pVBEData, false);
                hr = m_pD3D11Device.CreateBuffer(ref vbEdgeDesc, pVBEData, out m_edgeVertexBuffer);
                Marshal.FreeHGlobal(pVBEData);

                // Create edge index buffer
                D3D11.D3D11_BUFFER_DESC ibEdgeDesc = new()
                {
                    ByteWidth = (uint)(sizeof(ushort) * edgeIndices.Length),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_INDEX_BUFFER,
                };
                D3D11_SUBRESOURCE_DATA ibEdgeData = new() { pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(edgeIndices, 0) };
                IntPtr pIBEData = Marshal.AllocHGlobal(Marshal.SizeOf(ibEdgeData));
                Marshal.StructureToPtr(ibEdgeData, pIBEData, false);
                hr = m_pD3D11Device.CreateBuffer(ref ibEdgeDesc, pIBEData, out m_edgeIndexBuffer);
                Marshal.FreeHGlobal(pIBEData);

                // Edge pixel shader (constant dark gray)
                string psEdgeSrc = @"
float4 PSMain() : SV_Target
{
    return float4(0.2f, 0.2f, 0.2f, 1.0f); // dark gray
}
";
                byte[] psEdgeBytes = Encoding.ASCII.GetBytes(psEdgeSrc + "\0");
                hr = D3D11Tools.D3DCompile(psEdgeBytes, (IntPtr)psEdgeBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "PSMain", "ps_5_0", 0, 0, out IntPtr psEdgeBlob, out IntPtr psEdgeError);
                if (SUCCEEDED(hr))
                {
                    var psEdgeBlobObj = Marshal.GetObjectForIUnknown(psEdgeBlob) as ID3DBlob;
                    IntPtr pPSEdgeBC = psEdgeBlobObj.GetBufferPointer();
                    uint nPSEdgeSize = (uint)psEdgeBlobObj.GetBufferSize();
                    hr = m_pD3D11Device.CreatePixelShader(pPSEdgeBC, nPSEdgeSize, null, out m_psEdge);
                    SafeRelease(ref psEdgeBlobObj);
                    Marshal.Release(psEdgeBlob);
                }
                else
                {
                    // ...
                }

                // Depth-stencil state for edges: allow equal depth and do NOT write depth
                D3D11.D3D11_DEPTH_STENCIL_DESC dsEdgesDesc = new()
                {
                    DepthEnable = true,
                    DepthWriteMask = D3D11.D3D11_DEPTH_WRITE_MASK.D3D11_DEPTH_WRITE_MASK_ZERO,
                    DepthFunc = D3D11.D3D11_COMPARISON_FUNC.D3D11_COMPARISON_LESS_EQUAL,
                    StencilEnable = false
                };
                m_pD3D11Device.CreateDepthStencilState(ref dsEdgesDesc, out m_dsEdges);

                // Paper

                const int GRID = 30;
                List<Vertex> paperVertices = new();
                List<ushort> paperIndices = new();

                // Create mesh grid
                for (int y = 0; y <= GRID; y++)
                {
                    for (int x = 0; x <= GRID; x++)
                    {
                        float fx = -1.5f + x * 3.0f / GRID;
                        float fy = -1.5f + y * 3.0f / GRID;

                        paperVertices.Add(new Vertex
                        {
                            Position = new System.Numerics.Vector3(fx, fy, 0.0f),
                            TexCoord = new System.Numerics.Vector2(x / (float)GRID, 1.0f - y / (float)GRID)
                        });
                    }
                }

                for (int y = 0; y < GRID; y++)
                {
                    for (int x = 0; x < GRID; x++)
                    {
                        int i0 = y * (GRID + 1) + x;
                        int i1 = i0 + 1;
                        int i2 = i0 + (GRID + 1);
                        int i3 = i2 + 1;

                        paperIndices.Add((ushort)i0);
                        paperIndices.Add((ushort)i2);
                        paperIndices.Add((ushort)i1);

                        paperIndices.Add((ushort)i1);
                        paperIndices.Add((ushort)i2);
                        paperIndices.Add((ushort)i3);
                    }
                }

                m_paperIndexCount = (uint)paperIndices.Count;

                // Vertex buffer
                var vbDescPaper = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)(Marshal.SizeOf<Vertex>() * paperVertices.Count),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_VERTEX_BUFFER,
                };
                var vbDataPaper = new D3D11_SUBRESOURCE_DATA
                {
                    pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(paperVertices.ToArray(), 0)
                };
                IntPtr pVbPaperData = Marshal.AllocHGlobal(Marshal.SizeOf(vbDataPaper));
                Marshal.StructureToPtr(vbDataPaper, pVbPaperData, false);
                hr = m_pD3D11Device.CreateBuffer(ref vbDescPaper, pVbPaperData, out m_paperVertexBuffer);
                Marshal.FreeHGlobal(pVbPaperData);

                // Index buffer
                var ibDescPaper = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)(sizeof(ushort) * paperIndices.Count),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_INDEX_BUFFER,
                };
                var ibDataPaper = new D3D11_SUBRESOURCE_DATA
                {
                    pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(paperIndices.ToArray(), 0)
                };
                IntPtr pIbPaperData = Marshal.AllocHGlobal(Marshal.SizeOf(ibDataPaper));
                Marshal.StructureToPtr(ibDataPaper, pIbPaperData, false);
                hr = m_pD3D11Device.CreateBuffer(ref ibDescPaper, pIbPaperData, out m_paperIndexBuffer);
                Marshal.FreeHGlobal(pIbPaperData);

                // Vertex shader
                string paperVS = @"
cbuffer PaperCB : register(b0)
{
    matrix mvp;
    float theta;
    float3 padding;
};

struct VSIn
{
    float3 pos : POSITION;
    float2 uv  : TEXCOORD0;
};

struct VSOut
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
};

VSOut VSMain(VSIn v)
{
    VSOut o;
    float r2 = v.pos.x*v.pos.x + v.pos.y*v.pos.y;
    float wave = sin(r2 + theta * 3.14159265 / 180.0) * 0.5; // 0.5 adjusts height
    float3 displaced = v.pos + float3(0, 0, wave);
    o.pos = mul(float4(displaced,1), mvp);
    o.uv = v.uv;
    return o;
}";

                byte[] vsBytesPaper = Encoding.ASCII.GetBytes(paperVS + "\0");
                hr = D3D11Tools.D3DCompile(vsBytesPaper, vsBytesPaper.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "VSMain", "vs_5_0", 0, 0, out IntPtr vsBlobPaper, out IntPtr vsErrorBlobPaper);
                if (!SUCCEEDED(hr))
                {
                    var vsErrorBlobPaperObj = Marshal.GetObjectForIUnknown(vsErrorBlobPaper) as ID3DBlob;
                    if (vsErrorBlobPaperObj == null)
                        throw new Exception("Failed to get ID3DBlob from vsErrorBlobPaper");
                    IntPtr ptr = vsErrorBlobPaperObj.GetBufferPointer();
                    int nSize = (int)vsErrorBlobPaperObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(vsErrorBlobPaper);
                    throw new Exception(sError);
                }
                var vsBlobObjPaper = (ID3DBlob)Marshal.GetObjectForIUnknown(vsBlobPaper);
                hr = m_pD3D11Device.CreateVertexShader(vsBlobObjPaper.GetBufferPointer(), (uint)vsBlobObjPaper.GetBufferSize(), null, out m_paperVS);
                Marshal.Release(vsBlobPaper);
                SafeRelease(ref vsBlobObjPaper);

                // Pixel shader (texturing) (same as for Cube)
                string psPaper = @"
Texture2D tex0 : register(t0);
SamplerState samp0 : register(s0);

struct PSIn
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
};

float4 PSMain(PSIn input) : SV_Target
{    
    float2 uv = input.uv;
    //uv.y = 1.0 - uv.y; // flip vertical
    return tex0.Sample(samp0, uv);
}
";
                byte[] psBytesPaper = Encoding.ASCII.GetBytes(psPaper + "\0");
                hr = D3D11Tools.D3DCompile(psBytesPaper, psBytesPaper.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "PSMain", "ps_5_0", 0, 0, out IntPtr psBlobPaper, out IntPtr psErrorBlobPaper);
                if (!SUCCEEDED(hr))
                {
                    var psErrorBlobPaperObj = Marshal.GetObjectForIUnknown(psErrorBlobPaper) as ID3DBlob;
                    if (psErrorBlobPaperObj == null)
                        throw new Exception("Failed to get ID3DBlob from psErrorBlobPaper");
                    IntPtr ptr = psErrorBlobPaperObj.GetBufferPointer();
                    int nSize = (int)psErrorBlobPaperObj.GetBufferSize();
                    byte[] buf = new byte[nSize];
                    Marshal.Copy(ptr, buf, 0, nSize);
                    string sError = Encoding.ASCII.GetString(buf);
                    Marshal.Release(psErrorBlobPaper);
                    throw new Exception(sError);
                }
                var psBlobObjPaper = (ID3DBlob)Marshal.GetObjectForIUnknown(psBlobPaper);
                hr = m_pD3D11Device.CreatePixelShader(psBlobObjPaper.GetBufferPointer(), (uint)psBlobObjPaper.GetBufferSize(), null, out m_paperPS);
                Marshal.Release(psBlobPaper);
                SafeRelease(ref psBlobObjPaper);

                // Constant buffer
                var cbDescPaper = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)Marshal.SizeOf<PaperCB>(),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                    CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE
                };
                hr = m_pD3D11Device.CreateBuffer(ref cbDescPaper, IntPtr.Zero, out m_paperConstantBuffer);

                // Tunnel

                const int SEGMENTS = 128;           // more segments = smoother
                const float radius = 6.0f;
                const float depth = -200.0f;        // tunnel lenght

                // Texture repetition factors
                const float U_REPEAT = 8.0f;        // around circumference
                const float V_REPEAT = 40.0f;       // along tunnel depth

                var tunnelVertices = new List<TunnelVertex>();
                var tunnelIndices = new List<ushort>();

                for (int i = 0; i < SEGMENTS; i++)
                {
                    float a0 = i * MathF.Tau / SEGMENTS;
                    float a1 = (i + 1) * MathF.Tau / SEGMENTS;

                    System.Numerics.Vector3 p0 = new(radius * MathF.Cos(a0), radius * MathF.Sin(a0), 0);
                    System.Numerics.Vector3 p1 = new(radius * MathF.Cos(a1), radius * MathF.Sin(a1), 0);
                    System.Numerics.Vector3 p2 = new(radius * MathF.Cos(a1), radius * MathF.Sin(a1), depth);
                    System.Numerics.Vector3 p3 = new(radius * MathF.Cos(a0), radius * MathF.Sin(a0), depth);

                    System.Numerics.Vector3 n0 = System.Numerics.Vector3.Normalize(new(p0.X, p0.Y, 0));
                    System.Numerics.Vector3 n1 = System.Numerics.Vector3.Normalize(new(p1.X, p1.Y, 0));

                    // Scale UVs
                    float u0 = (float)i / SEGMENTS * U_REPEAT;
                    float u1 = (float)(i + 1) / SEGMENTS * U_REPEAT;

                    ushort baseIndex = (ushort)tunnelVertices.Count;

                    tunnelVertices.Add(new TunnelVertex
                    {
                        Position = p0,
                        Normal = n0,
                        UV = new System.Numerics.Vector2(u0, 0.0f)
                    });
                    tunnelVertices.Add(new TunnelVertex
                    {
                        Position = p1,
                        Normal = n1,
                        UV = new System.Numerics.Vector2(u1, 0.0f)
                    });
                    tunnelVertices.Add(new TunnelVertex
                    {
                        Position = p2,
                        Normal = n1,
                        UV = new System.Numerics.Vector2(u1, V_REPEAT)
                    });
                    tunnelVertices.Add(new TunnelVertex
                    {
                        Position = p3,
                        Normal = n0,
                        UV = new System.Numerics.Vector2(u0, V_REPEAT)
                    });

                    tunnelIndices.Add((ushort)(baseIndex + 0));
                    tunnelIndices.Add((ushort)(baseIndex + 1));
                    tunnelIndices.Add((ushort)(baseIndex + 2));
                    tunnelIndices.Add((ushort)(baseIndex + 0));
                    tunnelIndices.Add((ushort)(baseIndex + 2));
                    tunnelIndices.Add((ushort)(baseIndex + 3));
                }

                m_nTunnelIndexCount = tunnelIndices.Count;

                // Vertex buffer
                var vbDescTunnel = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)(Marshal.SizeOf<TunnelVertex>() * tunnelVertices.Count),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_VERTEX_BUFFER,
                };
                var vbDataTunnel = new D3D11_SUBRESOURCE_DATA
                {
                    pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(tunnelVertices.ToArray(), 0)
                };
                IntPtr pVbTunnelData = Marshal.AllocHGlobal(Marshal.SizeOf(vbDataTunnel));
                Marshal.StructureToPtr(vbDataTunnel, pVbTunnelData, false);
                hr = m_pD3D11Device.CreateBuffer(ref vbDescTunnel, pVbTunnelData, out m_tunnelVB);
                Marshal.FreeHGlobal(pVbTunnelData);

                // Index buffer
                var ibDescTunnel = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)(sizeof(ushort) * tunnelIndices.Count),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DEFAULT,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_INDEX_BUFFER,
                };
                var ibDataTunnel = new D3D11_SUBRESOURCE_DATA
                {
                    pSysMem = Marshal.UnsafeAddrOfPinnedArrayElement(tunnelIndices.ToArray(), 0)
                };
                IntPtr pIbTunnelData = Marshal.AllocHGlobal(Marshal.SizeOf(ibDataTunnel));
                Marshal.StructureToPtr(ibDataTunnel, pIbTunnelData, false);
                hr = m_pD3D11Device.CreateBuffer(ref ibDescTunnel, pIbTunnelData, out m_tunnelIB);
                Marshal.FreeHGlobal(pIbTunnelData);

                // Vertex Shader
                string vsTunnelSource = @"
cbuffer TunnelCB : register(b0)
{
    float4x4 World;
    float4x4 ViewProj;
    float Time;
    float Twist;
    float FadeStart;
    float FadeEnd;
    float DepthSpeed;
    float3 Padding;
};

struct VSIn
{
    float3 pos : POSITION;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;
};

struct VSOut
{
    float4 pos : SV_POSITION;
    float2 uv  : TEXCOORD0;
    float  z   : TEXCOORD1;
};

VSOut VSMain(VSIn input)
{
    VSOut o;

    float angle = atan2(input.pos.y, input.pos.x) + Time * Twist;
    float r = length(input.pos.xy);

    float3 p;
    p.x = cos(angle) * r;
    p.y = sin(angle) * r;
    p.z = input.pos.z;

    float4 worldPos = mul(float4(p, 1.0f), World);
    o.pos = mul(worldPos, ViewProj);

    o.uv = input.uv;
    o.z  = -input.pos.z;

    return o;
}

";

                byte[] vsTunnelBytes = Encoding.ASCII.GetBytes(vsTunnelSource + "\0");
                hr = D3D11Tools.D3DCompile(vsTunnelBytes, vsTunnelBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "VSMain", "vs_5_0", 0, 0, out IntPtr vsTunnelBlob, out IntPtr vsTunnelErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var vsTunnelErrorBlobObj = Marshal.GetObjectForIUnknown(vsTunnelErrorBlob) as ID3DBlob;
                    IntPtr ptrErr = vsTunnelErrorBlobObj.GetBufferPointer();
                    int nSizeErr = (int)vsTunnelErrorBlobObj.GetBufferSize();
                    byte[] bufErr = new byte[nSizeErr];
                    Marshal.Copy(ptrErr, bufErr, 0, nSizeErr);
                    string sError = Encoding.ASCII.GetString(bufErr);
                    Marshal.Release(vsTunnelErrorBlob);
                    throw new Exception(sError);
                }

                var vsBlobObjTunnel = Marshal.GetObjectForIUnknown(vsTunnelBlob) as ID3DBlob;
                IntPtr pVSTunnelBytecode = vsBlobObjTunnel.GetBufferPointer();
                uint nVSTunnelBytecodeSize = (uint)vsBlobObjTunnel.GetBufferSize();
                hr = m_pD3D11Device.CreateVertexShader(pVSTunnelBytecode, nVSTunnelBytecodeSize, null, out m_tunnelVS);

                SafeRelease(ref vsBlobObjTunnel);              

                D3D11_INPUT_ELEMENT_DESC[] tunnelLayout =
                    {
                    new D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = "POSITION",
                        SemanticIndex = 0,
                        Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,
                        InputSlot = 0,
                        AlignedByteOffset = 0,
                        InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
                        InstanceDataStepRate = 0
                    },
                    new D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = "NORMAL",
                        SemanticIndex = 0,
                        Format = DXGI_FORMAT.DXGI_FORMAT_R32G32B32_FLOAT,
                        InputSlot = 0,
                        AlignedByteOffset = 12,
                        InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
                        InstanceDataStepRate = 0
                    },
                    new D3D11_INPUT_ELEMENT_DESC
                    {
                        SemanticName = "TEXCOORD",
                        SemanticIndex = 0,
                        Format = DXGI_FORMAT.DXGI_FORMAT_R32G32_FLOAT,
                        InputSlot = 0,
                        AlignedByteOffset = 24,
                        InputSlotClass = D3D11_INPUT_CLASSIFICATION.D3D11_INPUT_PER_VERTEX_DATA,
                        InstanceDataStepRate = 0
                    }
                };
                hr = m_pD3D11Device.CreateInputLayout(tunnelLayout, (uint)tunnelLayout.Length, pVSTunnelBytecode, (nint)nVSTunnelBytecodeSize, out m_tunnelInputLayout);

                Marshal.Release(vsTunnelBlob);

                string psTunnelSource = @"
Texture2D tex0 : register(t0);
SamplerState samp0 : register(s0);

cbuffer TunnelCB : register(b0)
{
    float4x4 World;
    float4x4 ViewProj;
    float Time;
    float Twist;
    float FadeStart;
    float FadeEnd;
    float DepthSpeed;
    float3 Padding;
};

struct PSIn
{
    float4 pos   : SV_POSITION;
    float2 uv    : TEXCOORD0;
    float  depth : TEXCOORD1;
};

float4 PSMain(PSIn input) : SV_Target
{
    float2 uv = input.uv;
    uv.y = 1.0 - uv.y;           // vertical flip
    uv.y += Time * DepthSpeed;   // only scroll over time

    float4 color = tex0.Sample(samp0, uv);

    // depth fade
    float fade = saturate((input.depth - FadeStart) / (FadeEnd - FadeStart));
    color.rgb *= (1.0 - fade);

    return color;
}
";

                byte[] psTunnelBytes = Encoding.ASCII.GetBytes(psTunnelSource + "\0");
                hr = D3D11Tools.D3DCompile(psTunnelBytes, psTunnelBytes.Length, null, IntPtr.Zero, IntPtr.Zero,
                    "PSMain", "ps_5_0", 0, 0, out IntPtr psTunnelBlob, out IntPtr psTunnelErrorBlob);
                if (!SUCCEEDED(hr))
                {
                    var psErrObjTunnel = Marshal.GetObjectForIUnknown(psTunnelErrorBlob) as ID3DBlob;
                    IntPtr ptrErr = psErrObjTunnel.GetBufferPointer();
                    int nSizeErr = (int)psErrObjTunnel.GetBufferSize();
                    byte[] bufErr = new byte[nSizeErr];
                    Marshal.Copy(ptrErr, bufErr, 0, nSizeErr);
                    string sError = Encoding.ASCII.GetString(bufErr);
                    Marshal.Release(psTunnelErrorBlob);
                    throw new Exception(sError);
                }

                var psBlobObjTunnel = Marshal.GetObjectForIUnknown(psTunnelBlob) as ID3DBlob;
                IntPtr pPSTunnelBytecode = psBlobObjTunnel.GetBufferPointer();
                uint nPSTunnelBytecodeSize = (uint)psBlobObjTunnel.GetBufferSize();
                hr = m_pD3D11Device.CreatePixelShader(pPSTunnelBytecode, nPSTunnelBytecodeSize, null, out m_tunnelPS);

                SafeRelease(ref psBlobObjTunnel);
                Marshal.Release(psTunnelBlob);

                // Create constant buffer for tunnel
                var cbDescTunnel = new D3D11.D3D11_BUFFER_DESC
                {
                    ByteWidth = (uint)Marshal.SizeOf<TunnelCB>(),
                    Usage = D3D11.D3D11_USAGE.D3D11_USAGE_DYNAMIC,
                    BindFlags = D3D11_BIND_FLAG.D3D11_BIND_CONSTANT_BUFFER,
                    CPUAccessFlags = D3D11_CPU_ACCESS_FLAG.D3D11_CPU_ACCESS_WRITE,
                    MiscFlags = 0,
                    StructureByteStride = 0
                };

                hr = m_pD3D11Device.CreateBuffer(ref cbDescTunnel, IntPtr.Zero, out m_tunnelConstantBuffer);

                //m_tunnelSRV = D3D11Tools.CreateTextureFromFile(@"Assets\Mosaic.png", m_pWICImagingFactory2, m_pD3D11Device);
                m_tunnelSRV = D3D11Tools.CreateTextureFromFile(@"Assets\Marble_Black.png", m_pWICImagingFactory2, m_pD3D11Device);

                D3D11.D3D11_SAMPLER_DESC sampDescWrap = new()
                {
                    Filter = D3D11.D3D11_FILTER.D3D11_FILTER_MIN_MAG_LINEAR_MIP_POINT,
                    AddressU = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_WRAP,
                    AddressV = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_WRAP,
                    AddressW = D3D11.D3D11_TEXTURE_ADDRESS_MODE.D3D11_TEXTURE_ADDRESS_WRAP,
                    ComparisonFunc = D3D11.D3D11_COMPARISON_FUNC.D3D11_COMPARISON_NEVER,
                    MinLOD = 0,
                    //MaxLOD = float.MaxValue
                    MaxLOD = 0 //  disables mipmaps
                };
                hr = m_pD3D11Device.CreateSamplerState(ref sampDescWrap, out m_samplerWrap);



                // Graphics Capture
                var graphicsItem = GraphicsCaptureItem.CreateFromVisual(m_WebView2Visual);

                m_captureFramePool = Direct3D11CaptureFramePool.Create(m_pDirect3DDevice,
                    Windows.Graphics.DirectX.DirectXPixelFormat.B8G8R8A8UIntNormalized,
                    2,
                    graphicsItem.Size);

                m_captureFramePool.FrameArrived += (sender, args) =>
                {
                    if (m_pD2DBitmap1 != null)
                        SafeRelease(ref m_pD2DBitmap1);

                    using (var frame = sender.TryGetNextFrame())
                    {
                        if (tsRender3D.IsOn)
                        {
                            var texture = GetTexture2D(frame.Surface);
                            CreateOrUpdateSRV(texture);
                            SafeRelease(ref texture);
                        }
                        else
                        {
                            var pDXGISurface = GetDXGISurface(frame.Surface);
                            var pD2DBitmap1New = CreateBitmapFromSurface(pDXGISurface, m_pD2DDeviceContext, D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_NONE);
                            m_pD2DBitmap1 = pD2DBitmap1New;
                            SafeRelease(ref pDXGISurface);
                        }
                    }                                 
                };

                m_captureSession = m_captureFramePool.CreateCaptureSession(graphicsItem);
                m_captureSession.StartCapture();               

                // Better than CompositionTarget_Rendering for 3D on my PC
                StartRendering();

                string sURL = tbURL.Text;
                if (string.IsNullOrWhiteSpace(sURL))
                    return;

                // Remove old entry if it exists
                m_History.RemoveAll(h => string.Equals(h, sURL, StringComparison.OrdinalIgnoreCase));

                // Add new entry at the top (newest first)
                m_History.Insert(0, sURL);

                // Trim history to maximum limit
                if (m_History.Count > m_nHistoryLimit)
                    m_History = m_History.Take(m_nHistoryLimit).ToList();

                SaveHistory();

                await NavigateAsync();

                ((Button)sender).IsEnabled = false;
            }
            else
            {
                string sError = "WebView2 not created yet";
                var md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWndMain);
                await md.ShowAsync();
                return;
            }
        }

        Microsoft.UI.Dispatching.DispatcherQueueTimer? m_renderTimer;
        System.Diagnostics.Stopwatch m_timer = System.Diagnostics.Stopwatch.StartNew();

        float m_delta = 0.0f;
        private float m_angle = 0.0f; // angle used for bending the mesh

        void StartRendering()
        {           
            m_renderTimer = DispatcherQueue.CreateTimer();          
            if (tsRender3D.IsOn)
            {
                // 3D : smoother animation on my PC
                m_renderTimer.Interval = TimeSpan.FromMilliseconds(12);
            }
            else
            {
                // 2D : match capture/vsync (otherwise some frames are dropped)
                m_renderTimer.Interval = TimeSpan.FromMilliseconds(16); // 16 should be = ~60 Hz
            }
            m_renderTimer.Tick += (_, __) =>
            {
                float now = (float)m_timer.Elapsed.TotalSeconds;
                m_delta = now - m_lastTime;
                m_lastTime = now;

                //delta = Math.Min(delta, 1.0f / 120.0f);
                m_delta = Math.Clamp(m_delta, 0.0f, 1.0f / 60.0f);
                m_rotation += m_delta * 1.0f; // radians per second

                Render(m_rotation);
            };
            m_renderTimer.Start();
        }

        float m_lastTime = 0;
        float m_rotation = 0;

        // Commented at beginning : too slow on my PC for 3D
        private void CompositionTarget_Rendering(object sender, object e)
        {
            if (m_pD3D11DeviceContext == null)
                return;

            float now = (float)m_timer.Elapsed.TotalSeconds;
            float delta = now - m_lastTime;
            m_lastTime = now;

            m_rotation += delta * 1.0f; // radians per second
            Render(m_rotation);
        }

        // Direct2D
        //private void CompositionTarget_Rendering(object sender, object e)
        //{
        //    HRESULT hr = HRESULT.S_OK;
        //    hr = Render();
        //}


        private void tsRender3D_Toggled(object sender, RoutedEventArgs e)
        {
            // Resize / pipeline switch
            Windows.Foundation.Size sz = new()
            {
                Width = scp1.ActualWidth,
                Height = scp1.ActualHeight
            };
            Resize(sz);

            if (m_renderTimer == null)
                return;

            m_renderTimer.Stop();
            // Reset timing to avoid delta spike
            m_lastTime = (float)m_timer.Elapsed.TotalSeconds;

            if (tsRender3D.IsOn)
            {
                // 3D : smoother animation on my PC
                m_renderTimer.Interval = TimeSpan.FromMilliseconds(12);
            }
            else
            {
                // 2D : match capture/vsync (otherwise some frames are dropped)
                m_renderTimer.Interval = TimeSpan.FromMilliseconds(16);
            }

            m_renderTimer.Start();
        }

        int m_nRenderWidth;
        int m_nRenderHeight;

        // 3D Done with help from ChatGPT...
        HRESULT Render(float rotation)
        {
            HRESULT hr = HRESULT.S_OK;

            int nWidth = m_nRenderWidth;
            int nHeight = m_nRenderHeight;

            if (tsRender3D.IsOn)
            {
                if (m_pD3D11DeviceContext == null ||
                    m_pDXGISwapChain1 == null ||
                    m_rtv == null ||
                    m_dsv == null ||
                    m_captureSRV == null)
                    return HRESULT.E_FAIL;

                var ctx = m_pD3D11DeviceContext;

                // Render targets & viewport               
                ctx.OMSetRenderTargets(1, new[] { m_rtv }, m_dsv);
                ctx.RSSetViewports(1, new[]
                {
                    new D3D11.D3D11_VIEWPORT
                    {
                        TopLeftX = 0,
                        TopLeftY = 0,
                        Width = nWidth,
                        Height = nHeight,
                        MinDepth = 0,
                        MaxDepth = 1
                    }
                });

                ctx.ClearRenderTargetView(m_rtv, new float[] { 0.0f, 0.0f, 0.0f, 1.0f });
                ctx.ClearDepthStencilView(m_dsv, (uint)D3D11_CLEAR_FLAG.D3D11_CLEAR_DEPTH, 1.0f, 0);

                //  Background pass (Swirl or Tunnel)               

                if (tsBackground.IsOn)
                    RenderSwirl(ctx);
                else
                {
                    float elapsed = (float)m_timer.Elapsed.TotalSeconds;
                    RenderTunnel(ctx, elapsed);
                }

                if (tsCube.IsOn)
                {
                    //  Foreground pass (Cube)               

                    float cubeScale = 1.8f;

                    var world =
                        System.Numerics.Matrix4x4.CreateScale(cubeScale) *
                        System.Numerics.Matrix4x4.CreateRotationY(rotation) *
                        System.Numerics.Matrix4x4.CreateRotationX(rotation * 0.7f);

                    var view = System.Numerics.Matrix4x4.CreateLookAt(
                        new System.Numerics.Vector3(0, 0, -6.0f),
                        System.Numerics.Vector3.Zero,
                        System.Numerics.Vector3.UnitY);

                    var proj = System.Numerics.Matrix4x4.CreatePerspectiveFieldOfView(
                        MathF.PI / 3,
                        nWidth / (float)nHeight,
                        0.1f,
                        100f);

                    var mvp = System.Numerics.Matrix4x4.Transpose(world * view * proj);

                    CBMVP cb = new()
                    {
                        m11 = mvp.M11,
                        m12 = mvp.M12,
                        m13 = mvp.M13,
                        m14 = mvp.M14,
                        m21 = mvp.M21,
                        m22 = mvp.M22,
                        m23 = mvp.M23,
                        m24 = mvp.M24,
                        m31 = mvp.M31,
                        m32 = mvp.M32,
                        m33 = mvp.M33,
                        m34 = mvp.M34,
                        m41 = mvp.M41,
                        m42 = mvp.M42,
                        m43 = mvp.M43,
                        m44 = mvp.M44
                    };

                    D3D11.D3D11_MAPPED_SUBRESOURCE mapped;
                    ctx.Map(m_constantBuffer, 0, D3D11.D3D11_MAP.D3D11_MAP_WRITE_DISCARD, 0, out mapped);
                    unsafe { *(CBMVP*)mapped.pData = cb; }
                    ctx.Unmap(m_constantBuffer, 0);

                    ctx.IASetInputLayout(m_inputLayout);
                    ctx.IASetPrimitiveTopology(D3D11.D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

                    uint nStride = (uint)Marshal.SizeOf<Vertex>();
                    uint nOffset = 0;
                    if (m_cubeVertexBuffer != null)
                        ctx.IASetVertexBuffers(0, 1, new[] { m_cubeVertexBuffer }, new[] { nStride }, new[] { nOffset });
                    ctx.IASetIndexBuffer(m_cubeIndexBuffer, DXGI_FORMAT.DXGI_FORMAT_R16_UINT, 0);

                    ctx.VSSetShader(m_cubeVS, null, 0);
                    ctx.VSSetConstantBuffers(0, 1, new[] { m_constantBuffer });

                    ctx.PSSetShader(m_cubePS, null, 0);
                    ctx.PSSetShaderResources(0, 1, new[] { m_captureSRV });
                    if (m_sampler != null)
                        ctx.PSSetSamplers(0, 1, new[] { m_sampler });

                    ctx.RSSetState(m_rs);
                    ctx.DrawIndexed(36, 0, 0);

                    // Added with Copilot...
                    // Draw edges (LINE_LIST)
                    if (tsCubeEdges.IsOn == true && (m_edgeVertexBuffer != null && m_edgeIndexBuffer != null && m_psEdge != null))
                    {
                        // Use same input layout & vertex shader so positions get transformed by mvp in constant buffer
                        ctx.IASetInputLayout(m_inputLayout);
                        ctx.IASetPrimitiveTopology(D3D11.D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_LINELIST);

                        uint nStrideEdge = (uint)Marshal.SizeOf<Vertex>();
                        uint nOffsetEdge = 0;
                        ctx.IASetVertexBuffers(0, 1, new[] { m_edgeVertexBuffer }, new[] { nStrideEdge }, new[] { nOffsetEdge });
                        ctx.IASetIndexBuffer(m_edgeIndexBuffer, DXGI_FORMAT.DXGI_FORMAT_R16_UINT, 0);

                        // Ensure constant buffer contains the cube MVP (already updated for the cube)
                        ctx.VSSetShader(m_cubeVS, null, 0);
                        ctx.VSSetConstantBuffers(0, 1, new[] { m_constantBuffer });

                        // Edge pixel shader
                        ctx.PSSetShader(m_psEdge, null, 0);

                        // Depth: don't overwrite depth but allow equals so edges draw over cube faces
                        ctx.OMSetDepthStencilState(m_dsEdges, 0);

                        // Rasterizer: reuse m_rs (CullNone) so all edges are visible
                        ctx.RSSetState(m_rs);

                        // Draw 24 indices (12 edges * 2)
                        ctx.DrawIndexed((uint)edgeIndices.Length, 0, 0);

                        // restore depth/stencil state if needed
                        ctx.OMSetDepthStencilState(null, 0);
                        // restore PS (if one draw more)
                        ctx.PSSetShader(m_cubePS, null, 0);
                    }
                }
                else
                {
                    //  Foreground pass (Paper) (Vertex displacement)

                    float pitch = -0.6f;
                    float yaw = rotation * 0.4f;
                    float roll = MathF.Sin(rotation) * 0.2f;
                    var world = System.Numerics.Matrix4x4.CreateScale(1.5f, 1.5f, 1.0f) *
                        System.Numerics.Matrix4x4.CreateRotationZ(roll) *
                        System.Numerics.Matrix4x4.CreateRotationY(yaw) *
                        System.Numerics.Matrix4x4.CreateRotationX(pitch);

                    //var  world = System.Numerics.Matrix4x4.CreateScale(1.25f, 1.25f, 1.0f) *
                    //    System.Numerics.Matrix4x4.CreateRotationX(-0.6f) *
                    //    System.Numerics.Matrix4x4.CreateRotationZ(rotation * 0.3f);

                    var view = System.Numerics.Matrix4x4.CreateLookAt(
                        new System.Numerics.Vector3(0, 0, -6),
                        System.Numerics.Vector3.Zero,
                        System.Numerics.Vector3.UnitY);

                    var proj = System.Numerics.Matrix4x4.CreatePerspectiveFieldOfView(
                        MathF.PI / 3,
                        nWidth / (float)nHeight,
                        0.1f,
                        100f);

                    var mvp = System.Numerics.Matrix4x4.Transpose(world * view * proj);

                    m_angle += m_delta * 90.0f;
                    if (m_angle > 360.0f)
                        m_angle -= 360.0f;

                    // Prepare constant buffer
                    PaperCB cb = new PaperCB
                    {
                        WorldViewProj = mvp,   // combined view-projection matrix
                        Theta = m_angle,
                        Padding = new System.Numerics.Vector3() // just to align to 16 bytes
                    };

                    ctx.Map(m_paperConstantBuffer, 0, D3D11.D3D11_MAP.D3D11_MAP_WRITE_DISCARD, 0, out var mapped);
                    unsafe { *(PaperCB*)mapped.pData = cb; }
                    ctx.Unmap(m_paperConstantBuffer, 0);

                    // Set pipeline
                    uint stride = (uint)Marshal.SizeOf<Vertex>();
                    uint offset = 0;
                    if (m_paperVertexBuffer != null)
                        ctx.IASetVertexBuffers(0, 1, new[] { m_paperVertexBuffer }, new[] { stride }, new[] { offset });
                    ctx.IASetIndexBuffer(m_paperIndexBuffer, DXGI_FORMAT.DXGI_FORMAT_R16_UINT, 0);

                    ctx.IASetInputLayout(m_inputLayout);
                    ctx.IASetPrimitiveTopology(D3D11.D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

                    ctx.VSSetShader(m_paperVS, null, 0);
                    ctx.VSSetConstantBuffers(0, 1, new[] { m_paperConstantBuffer });
                    ctx.PSSetShader(m_paperPS, null, 0);
                    ctx.PSSetShaderResources(0, 1, new[] { m_captureSRV });
                    if (m_sampler != null)
                        ctx.PSSetSamplers(0, 1, new[] { m_sampler });

                    // Draw
                    ctx.RSSetState(m_rs);
                    ctx.DrawIndexed((uint)m_paperIndexCount, 0, 0);
                }  

                hr = m_pDXGISwapChain1.Present(1, 0);
            }
            else
            {
                if (m_pD2DDeviceContext != null)
                {
                    m_pD2DDeviceContext.BeginDraw();

                    //m_pD2DDeviceContext.Clear(new ColorF(ColorF.Enum.Orange, 1.0f));
                    m_pD2DDeviceContext.Clear(null);

                    m_pD2DDeviceContext.GetSize(out D2D1_SIZE_F size);

                    if (m_pD2DBitmap1 != null)
                    {
                        m_pD2DBitmap1.GetSize(out D2D1_SIZE_F sizeBmp);

                        if (cbGrayscale.IsChecked == true || cbInvert.IsChecked == true || cbEmboss.IsChecked == true ||
                            cbGaussianBlur.IsChecked == true || cbEdgeDetection.IsChecked == true || cbTemperatureTint.IsChecked == true)
                        {
                            ID2D1Image pCurrentD2DImage = m_pD2DBitmap1;

                            if (cbGrayscale.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1Grayscale, pCurrentD2DImage);
                            }
                            if (cbInvert.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1Invert, pCurrentD2DImage);
                            }
                            if (cbGaussianBlur.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1GaussianBlur, pCurrentD2DImage,
                                    e =>
                                    {
                                        SetEffectFloat(e, (uint)D2D1_GAUSSIANBLUR_PROP.D2D1_GAUSSIANBLUR_PROP_STANDARD_DEVIATION, GaussianBlur);
                                        SetEffectInt(e, (uint)D2D1_GAUSSIANBLUR_PROP.D2D1_GAUSSIANBLUR_PROP_BORDER_MODE, (uint)D2D1_BORDER_MODE.D2D1_BORDER_MODE_HARD);
                                    });
                            }
                            if (cbEmboss.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1Emboss, pCurrentD2DImage,
                                    e =>
                                    {
                                        SetEffectFloat(e, (uint)D2D1_EMBOSS_PROP.D2D1_EMBOSS_PROP_HEIGHT, StrengthEmboss);
                                        SetEffectFloat(e, (uint)D2D1_EMBOSS_PROP.D2D1_EMBOSS_PROP_DIRECTION, 45.0f);
                                    });
                            }
                            if (cbEdgeDetection.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1EdgeDetection, pCurrentD2DImage,
                                    e =>
                                    {
                                        SetEffectFloat(e, (uint)D2D1_EDGEDETECTION_PROP.D2D1_EDGEDETECTION_PROP_STRENGTH, EdgeDetection);
                                    });
                            }
                            if (cbTemperatureTint.IsChecked == true)
                            {
                                pCurrentD2DImage = AppendEffect(D2DTools.CLSID_D2D1TemperatureTint, pCurrentD2DImage,
                                    e =>
                                    {
                                        SetEffectFloat(e, (uint)D2D1_TEMPERATUREANDTINT_PROP.D2D1_TEMPERATUREANDTINT_PROP_TEMPERATURE, Temperature);
                                        SetEffectFloat(e, (uint)D2D1_TEMPERATUREANDTINT_PROP.D2D1_TEMPERATUREANDTINT_PROP_TINT, Tint);
                                    });
                            }

                            D2D1_POINT_2F pt = new D2D1_POINT_2F(0, 0);
                            D2D1_RECT_F imageRectangle = new D2D1_RECT_F();
                            imageRectangle.left = 0.0f;
                            imageRectangle.top = 0.0f;
                            imageRectangle.right = imageRectangle.left + sizeBmp.width;
                            imageRectangle.bottom = imageRectangle.top + sizeBmp.height;
                            m_pD2DDeviceContext.DrawImage(pCurrentD2DImage, ref pt, ref imageRectangle, D2D1_INTERPOLATION_MODE.D2D1_INTERPOLATION_MODE_LINEAR, D2D1_COMPOSITE_MODE.D2D1_COMPOSITE_MODE_SOURCE_OVER);
                            SafeRelease(ref pCurrentD2DImage);
                        }
                        else
                        {
                            D2D1_RECT_F destRect = new D2D1_RECT_F(0.0f, 0.0f, size.width, size.height);
                            D2D1_RECT_F sourceRect = new D2D1_RECT_F(0.0f, 0.0f, sizeBmp.width, sizeBmp.height);
                            m_pD2DDeviceContext.DrawBitmap(m_pD2DBitmap1, ref destRect, 1.0f, D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, ref sourceRect);
                        }
                    }

                    hr = m_pD2DDeviceContext.EndDraw(out ulong tag1, out ulong tag2);

                    if ((uint)hr == D2DTools.D2DERR_RECREATE_TARGET)
                    {
                        m_pD2DDeviceContext.SetTarget(null);
                        SafeRelease(ref m_pD2DDeviceContext);
                        hr = CreateDeviceContextAndDirect3DDevice();
                        //CleanDeviceResources();
                        //hr = CreateDeviceResources();
                        hr = CreateSwapChain(IntPtr.Zero);
                        hr = ConfigureSwapChain(hWndMain);
                    }
                    hr = m_pDXGISwapChain1.Present(1, 0);
                }
            }
            return hr;
        }

        ID2D1Image AppendEffect(Guid effectId, ID2D1Image pInputD2DImage, Action<ID2D1Effect>? pConfigureEffect = null)
        {
            HRESULT hr = m_pD2DDeviceContext.CreateEffect(effectId, out ID2D1Effect pEffect);
            if (!SUCCEEDED(hr))
                return pInputD2DImage;

            pEffect.SetInput(0, pInputD2DImage);
            pConfigureEffect?.Invoke(pEffect);
            pEffect.GetOutput(out ID2D1Image pOutputD2DImage);

            SafeRelease(ref pEffect);
            return pOutputD2DImage;
        }

        void RenderSwirl(D3D11.ID3D11DeviceContext ctx)
        {
            // Update time buffer
            D3D11.D3D11_MAPPED_SUBRESOURCE mappedTime;
            ctx.Map(m_cbTime, 0, D3D11.D3D11_MAP.D3D11_MAP_WRITE_DISCARD, 0, out mappedTime);
            unsafe
            {
                *(float*)mappedTime.pData = (float)m_timer.Elapsed.TotalSeconds;
            }
            ctx.Unmap(m_cbTime, 0);

            ctx.IASetInputLayout(null);
            ctx.IASetPrimitiveTopology(D3D11.D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

            ctx.VSSetShader(m_swirlVS, null, 0);
            ctx.PSSetShader(m_swirlPS, null, 0);

            // Time buffer is b1, NOT b0
            ctx.PSSetConstantBuffers(1, 1, new[] { m_cbTime });

            ctx.Draw(3, 0);
            ctx.ClearDepthStencilView(m_dsv, (uint)D3D11_CLEAR_FLAG.D3D11_CLEAR_DEPTH, 1.0f, 0);
        }

        void RenderTunnel(D3D11.ID3D11DeviceContext ctx, float elapsedSeconds)
        {
            if (ctx == null || m_tunnelVB == null || m_tunnelIB == null || m_tunnelVS == null || m_tunnelPS == null)
                return;

            // Camera + Projection
            float fov = MathF.PI / 3.0f; // 60 deg
            float aspect = (float)m_nRenderWidth / m_nRenderHeight; 
            float near = 0.1f;
            float far = 50.0f;

            var proj = System.Numerics.Matrix4x4.CreatePerspectiveFieldOfView(fov, aspect, near, far);
            var view = System.Numerics.Matrix4x4.CreateLookAt(
                new System.Numerics.Vector3(0, 0, -2.0f), // inside tunnel
                new System.Numerics.Vector3(0, 0, -5.0f), // look forward
                System.Numerics.Vector3.UnitY);

            // Map constant buffer          
            D3D11.D3D11_MAPPED_SUBRESOURCE mappedCB;
            ctx.Map(m_tunnelConstantBuffer, 0, D3D11.D3D11_MAP.D3D11_MAP_WRITE_DISCARD, 0, out mappedCB);
            unsafe
            {
                TunnelCB* pCB = (TunnelCB*)mappedCB.pData;
                pCB->World = System.Numerics.Matrix4x4.Identity; // model transform
                pCB->ViewProj = System.Numerics.Matrix4x4.Transpose(System.Numerics.Matrix4x4.Multiply(view, proj)); // transpose for HLSL
                pCB->Time = elapsedSeconds * 0.25f;   // slow time 
                pCB->Twist = 1.25f;               // swirl speed
                pCB->FadeStart = 0.0f;
                pCB->FadeEnd = 50.0f;             // increase fade range for perspective
                pCB->DepthSpeed = 2.50f;
            }
            ctx.Unmap(m_tunnelConstantBuffer, 0);

            // Pipeline
            ctx.IASetInputLayout(m_tunnelInputLayout);
            ctx.IASetPrimitiveTopology(D3D11.D3D_PRIMITIVE_TOPOLOGY.D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

            uint stride = (uint)Marshal.SizeOf<TunnelVertex>();
            uint offset = 0;
            ctx.IASetVertexBuffers(0, 1, new[] { m_tunnelVB }, new[] { stride }, new[] { offset });
            ctx.IASetIndexBuffer(m_tunnelIB, DXGI_FORMAT.DXGI_FORMAT_R16_UINT, 0);

            ctx.VSSetShader(m_tunnelVS, null, 0);
            ctx.PSSetShader(m_tunnelPS, null, 0);

            ctx.VSSetConstantBuffers(0, 1, new[] { m_tunnelConstantBuffer });
            ctx.PSSetConstantBuffers(0, 1, new[] { m_tunnelConstantBuffer });

            if (m_tunnelSRV != null)
                ctx.PSSetShaderResources(0, 1, new[] { m_tunnelSRV });
            if (m_samplerWrap != null)
                ctx.PSSetSamplers(0, 1, new[] { m_samplerWrap });

            ctx.RSSetState(m_rs);
          
            ctx.DrawIndexed((uint)m_nTunnelIndexCount, 0, 0);
            ctx.ClearDepthStencilView(m_dsv, (uint)D3D11_CLEAR_FLAG.D3D11_CLEAR_DEPTH, 1.0f, 0);
        }

        private void InitializeWindowsComposition(IntPtr hWnd)
        {
            HRESULT hr = HRESULT.S_OK;

            // -2147417842 0x8001010e RPC_E_WRONG_THREAD if DesktopAcrylicBackdrop in XAML
            //hr = CreateDispatcherQueueController(options, out object dqc);

            m_DispatcherQueue = Windows.System.DispatcherQueue.GetForCurrentThread();
            if (m_DispatcherQueue == null)
            {
                DispatcherQueueOptions options = new DispatcherQueueOptions
                {
                    threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT,
                    apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA,
                    dwSize = (uint)Marshal.SizeOf(typeof(DispatcherQueueOptions))
                };
                hr = CreateDispatcherQueueController(options, out object dqc);
            }

            if (SUCCEEDED(hr) && m_WindowsCompositor == null)
            {
                m_WindowsCompositor = new Windows.UI.Composition.Compositor();

                //var pCompositorDesktopInterop = m_WindowsCompositor.As<ICompositorDesktopInterop>();

                IntPtr pDesktopWindowTarget = IntPtr.Zero;
                // 0x88980800 DCOMPOSITION_ERROR_WINDOW_ALREADY_COMPOSED if isTopmost == false
                //hr = pCompositorDesktopInterop.CreateDesktopWindowTarget(hWnd, true, out pDesktopWindowTarget);
                if (SUCCEEDED(hr))
                {
                    //Windows.UI.Composition.Desktop.DesktopWindowTarget windowTarget = Windows.UI.Composition.Desktop.DesktopWindowTarget.FromAbi(pDesktopWindowTarget);

                    //var m_RootVisual = m_WindowsCompositor.CreateContainerVisual();
                    //m_RootVisual.RelativeSizeAdjustment = new System.Numerics.Vector2(1.0f, 1.0f);
                    //m_RootVisual.Offset = new System.Numerics.Vector3(0.0f, 0.0f, 0.0f);
                    //windowTarget.Root = m_RootVisual;

                    m_WebView2Visual = m_WindowsCompositor.CreateContainerVisual();
                    m_WebView2Visual.RelativeSizeAdjustment = new System.Numerics.Vector2(1.0f, 1.0f);

                    // Test Blue Rectangle
                    //var child = m_WindowsCompositor.CreateSpriteVisual();
                    //child.Brush = m_WindowsCompositor.CreateColorBrush(Windows.UI.Color.FromArgb(0xFF, 0x00, 0x00, 0xFF));
                    //child.Offset = new System.Numerics.Vector3(0.0f, 0.0f, 0.0f);
                    //child.Size = new System.Numerics.Vector2(400.0f, 400.0f);
                    //m_WebView2Visual.Children.InsertAtTop(child);

                    m_WebView2Visual.Size = new System.Numerics.Vector2(m_nWebView2Width, m_nWebView2Height);

                    //m_RootVisual.Children.InsertAtTop(m_WebView2Visual);
                    //Marshal.Release(pDesktopWindowTarget);                    
                }
                //SafeRelease(ref pCompositorDesktopInterop);
            }
        }

        HRESULT CreateD2D1Factory()
        {
            HRESULT hr = HRESULT.S_OK;
            D2D1_FACTORY_OPTIONS options = new D2D1_FACTORY_OPTIONS();

            // Needs "Enable native code Debugging"
#if DEBUG
            options.debugLevel = D2D1_DEBUG_LEVEL.D2D1_DEBUG_LEVEL_INFORMATION;
#endif

            hr = D2DTools.D2D1CreateFactory(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED, ref D2DTools.CLSID_D2D1Factory, ref options, out m_pD2DFactory);
            m_pD2DFactory1 = (ID2D1Factory1)m_pD2DFactory;
            return hr;
        }

        HRESULT CreateDeviceContextAndDirect3DDevice()
        {
            HRESULT hr = HRESULT.S_OK;
            uint nCreationFlags = (uint)D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_BGRA_SUPPORT;

            // Needs "Enable native code Debugging"
#if DEBUG
            nCreationFlags |= (uint)D3D11_CREATE_DEVICE_FLAG.D3D11_CREATE_DEVICE_DEBUG;
#endif

            int[] aD3D_FEATURE_LEVEL = new int[] { (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_1, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0,
                (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_1, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_10_0, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_3,
                (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_2, (int)D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_9_1};

            D3D_FEATURE_LEVEL featureLevel;
            hr = D2DTools.D3D11CreateDevice(null,    // specify null to use the default adapter
                D3D_DRIVER_TYPE.D3D_DRIVER_TYPE_HARDWARE,
                IntPtr.Zero,
                nCreationFlags,              // optionally set debug and Direct2D compatibility flags
                aD3D_FEATURE_LEVEL, // list of feature levels this app can support
                (uint)aD3D_FEATURE_LEVEL.Length,    // number of possible feature levels
                D2DTools.D3D11_SDK_VERSION,
                out m_pD3D11DevicePtr,           // returns the Direct3D device created
                out featureLevel,            // returns feature level of device created               
                out m_pD3D11DeviceContextPtr // returns the device immediate context
            );
            if (SUCCEEDED(hr))
            {
                m_pD3D11Device = Marshal.GetObjectForIUnknown(m_pD3D11DevicePtr) as ID3D11Device;
                m_pD3D11DeviceContext = Marshal.GetObjectForIUnknown(m_pD3D11DeviceContextPtr) as D3D11.ID3D11DeviceContext;

                IntPtr pGraphicsDevicePtr = IntPtr.Zero;
                hr = CreateDirect3D11DeviceFromDXGIDevice(m_pD3D11DevicePtr, out pGraphicsDevicePtr);
                if (SUCCEEDED(hr))
                {
                    m_pDirect3DDevice = WinRT.MarshalInterface<Windows.Graphics.DirectX.Direct3D11.IDirect3DDevice>.FromAbi(pGraphicsDevicePtr);
                    Marshal.Release(pGraphicsDevicePtr);
                }

                m_pDXGIDevice = Marshal.GetObjectForIUnknown(m_pD3D11DevicePtr) as IDXGIDevice1;
                if (m_pD2DFactory1 != null)
                {
                    hr = m_pD2DFactory1.CreateDevice(m_pDXGIDevice, out m_pD2DDevice);
                    if (SUCCEEDED(hr))
                    {
                        hr = m_pD2DDevice.CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS.D2D1_DEVICE_CONTEXT_OPTIONS_NONE, out m_pD2DDeviceContext);
                        SafeRelease(ref m_pD2DDevice);
                    }
                }
                //Marshal.ReleaseComObject(m_pDXGIDevice);
                //Marshal.Release(m_pD3D11DevicePtr);
            }
            return hr;
        }

        HRESULT CreateSwapChain(IntPtr hWnd)
        {
            HRESULT hr = HRESULT.S_OK;
            DXGI_SWAP_CHAIN_DESC1 swapChainDesc = new DXGI_SWAP_CHAIN_DESC1();
            swapChainDesc.Width = 1;
            swapChainDesc.Height = 1;
            swapChainDesc.Format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM; // this is the most common swapchain format
            swapChainDesc.Stereo = false;
            swapChainDesc.SampleDesc.Count = 1;                // don't use multi-sampling
            swapChainDesc.SampleDesc.Quality = 0;
            swapChainDesc.BufferUsage = D2DTools.DXGI_USAGE_RENDER_TARGET_OUTPUT;
            swapChainDesc.BufferCount = 2;                     // use double buffering to enable flip
            swapChainDesc.Scaling = (hWnd != IntPtr.Zero) ? DXGI_SCALING.DXGI_SCALING_NONE : DXGI_SCALING.DXGI_SCALING_STRETCH;
            swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT.DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL; // all apps must use this SwapEffect       
            swapChainDesc.Flags = 0;         

            IDXGIAdapter pDXGIAdapter;
            hr = m_pDXGIDevice.GetAdapter(out pDXGIAdapter);
            if (SUCCEEDED(hr))
            {
                IntPtr pDXGIFactory2Ptr;
                hr = pDXGIAdapter.GetParent(typeof(IDXGIFactory2).GUID, out pDXGIFactory2Ptr);
                if (SUCCEEDED(hr))
                {
                    IDXGIFactory2 pDXGIFactory2 = Marshal.GetObjectForIUnknown(pDXGIFactory2Ptr) as IDXGIFactory2;
                    if (hWnd != IntPtr.Zero)
                        hr = pDXGIFactory2.CreateSwapChainForHwnd(m_pD3D11DevicePtr, hWnd, ref swapChainDesc, IntPtr.Zero, null, out m_pDXGISwapChain1);
                    else
                    {
                        swapChainDesc.AlphaMode = DXGI_ALPHA_MODE.DXGI_ALPHA_MODE_PREMULTIPLIED;
                        hr = pDXGIFactory2.CreateSwapChainForComposition(m_pD3D11DevicePtr, ref swapChainDesc, null, out m_pDXGISwapChain1);
                    }

                    if (SUCCEEDED(hr))
                        hr = m_pDXGIDevice.SetMaximumFrameLatency(1);

                    SafeRelease(ref pDXGIFactory2);
                    Marshal.Release(pDXGIFactory2Ptr);
                }
                SafeRelease(ref pDXGIAdapter);
            }
            return hr;
        }

        HRESULT ConfigureSwapChain(IntPtr hWnd)
        {
            HRESULT hr = HRESULT.S_OK;

            //IntPtr pD3D11Texture2DPtr = IntPtr.Zero;
            //hr = m_pDXGISwapChain1.GetBuffer(0, typeof(ID3D11Texture2D).GUID, ref pD3D11Texture2DPtr);
            //m_pD3D11Texture2D = Marshal.GetObjectForIUnknown(pD3D11Texture2DPtr) as ID3D11Texture2D;

            D2D1_BITMAP_PROPERTIES1 bitmapProperties = new D2D1_BITMAP_PROPERTIES1();
            bitmapProperties.bitmapOptions = D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_TARGET | D2D1_BITMAP_OPTIONS.D2D1_BITMAP_OPTIONS_CANNOT_DRAW;
            //bitmapProperties.pixelFormat = D2DTools.PixelFormat(DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_IGNORE);
            bitmapProperties.pixelFormat = D2DTools.PixelFormat(DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED);
            uint nDPI = GetDpiForWindow(hWnd);
            bitmapProperties.dpiX = nDPI;
            bitmapProperties.dpiY = nDPI;
            IntPtr pDXGISurfacePtr = IntPtr.Zero;
            hr = m_pDXGISwapChain1.GetBuffer(0, typeof(IDXGISurface).GUID, out pDXGISurfacePtr);
            if (SUCCEEDED(hr))
            {                
                IDXGISurface pDXGISurface = Marshal.GetObjectForIUnknown(pDXGISurfacePtr) as IDXGISurface;
                hr = m_pD2DDeviceContext.CreateBitmapFromDxgiSurface(pDXGISurface, ref bitmapProperties, out m_pD2DTargetBitmap);
                if (SUCCEEDED(hr))
                    m_pD2DDeviceContext.SetTarget(m_pD2DTargetBitmap);
                SafeRelease(ref pDXGISurface);
                Marshal.Release(pDXGISurfacePtr);
            }
            return hr;
        }

        private void Scp1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize(e.NewSize);           
        }

        HRESULT Resize(Windows.Foundation.Size sz)
        {
            if (m_pDXGISwapChain1 == null || sz.Width == 0 || sz.Height == 0)
                return HRESULT.S_OK;

            if (m_pD2DDeviceContext != null)
                m_pD2DDeviceContext.SetTarget(null);

            if (m_pD2DTargetBitmap != null)
                SafeRelease(ref m_pD2DTargetBitmap);

            if (tsRender3D.IsOn)
            {
                if (m_pD3D11DeviceContext != null)
                    m_pD3D11DeviceContext.OMSetRenderTargets(0, null, null);
                //m_pD3D11DeviceContext.Flush();               
            }

            // Release D3D views
            SafeRelease(ref m_rtv);
            SafeRelease(ref m_dsv);

            HRESULT hr = m_pDXGISwapChain1.ResizeBuffers(
                    2,
                    (uint)sz.Width,
                    (uint)sz.Height,
                    DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
                    0);

            if (! SUCCEEDED(hr))
                return hr;

            if (tsRender3D.IsOn)
            {
                // Recreate RTV from back buffer
                CreateRenderTargetView();

                // Recreate depth buffer with SAME size
                CreateDepthStencilView((int)sz.Width, (int)sz.Height);
            }
            else
            {
                //  Rebind D2D target
                ConfigureSwapChain(hWndMain);
            }

            m_nRenderWidth = (int)sz.Width;
            m_nRenderHeight = (int)sz.Height;

            if (!tsRender3D.IsOn)
            {
                if (m_WebView2Visual != null && m_pController2 != null)
                {
                    m_WebView2Visual.Size = new System.Numerics.Vector2(m_nRenderWidth, m_nRenderHeight);
                    hr = m_pController2.get_Bounds(out RECT rcBounds);
                    if (SUCCEEDED(hr))
                    {    
                        rcBounds.left = (int)m_WebView2Visual.Offset.X;
                        rcBounds.top = (int)m_WebView2Visual.Offset.Y;
                        rcBounds.right = (int)(m_WebView2Visual.Offset.X + m_nRenderWidth);
                        rcBounds.bottom = (int)(m_WebView2Visual.Offset.Y + m_nRenderHeight);
                        hr = m_pController2.put_Bounds(rcBounds);
                    }
                    if (m_captureFramePool != null)
                    {
                        m_captureFramePool.Recreate(m_pDirect3DDevice, Windows.Graphics.DirectX.DirectXPixelFormat.B8G8R8A8UIntNormalized,
                            2, new Windows.Graphics.SizeInt32((int)m_WebView2Visual.Size.X, (int)m_WebView2Visual.Size.Y));
                    }
                }
            }
            else
            {
                if (m_WebView2Visual != null && m_pController2 != null)
                {
                    m_WebView2Visual.Size = new System.Numerics.Vector2(m_nWebView2Width, m_nWebView2Height);
                    hr = m_pController2.get_Bounds(out RECT rcBounds);
                    if (SUCCEEDED(hr))
                    {
                        rcBounds.left = (int)m_WebView2Visual.Offset.X;
                        rcBounds.top = (int)m_WebView2Visual.Offset.Y;
                        rcBounds.right = (int)(m_WebView2Visual.Offset.X + m_WebView2Visual.Size.X);
                        rcBounds.bottom = (int)(m_WebView2Visual.Offset.Y + m_WebView2Visual.Size.Y);
                        hr = m_pController2.put_Bounds(rcBounds);
                    }
                    if (m_captureFramePool != null)
                    {
                        m_captureFramePool.Recreate(m_pDirect3DDevice, Windows.Graphics.DirectX.DirectXPixelFormat.B8G8R8A8UIntNormalized,
                            2, new Windows.Graphics.SizeInt32((int)m_nWebView2Width, (int)m_nWebView2Height));
                    }
                }
            }

            return HRESULT.S_OK;
        }      

        private IDXGISurface? GetDXGISurface(Windows.Graphics.DirectX.Direct3D11.IDirect3DSurface pSurface)
        {
            IDXGISurface pDXGISurface = null;
            var pAccess = pSurface.As<IDirect3DDxgiInterfaceAccess>();
            IntPtr pSurfacePtr = IntPtr.Zero;
            Guid guid = typeof(IDXGISurface).GUID;
            HRESULT hr = pAccess.GetInterface(guid, out pSurfacePtr);
            if (SUCCEEDED(hr))
            {
                pDXGISurface = Marshal.GetObjectForIUnknown(pSurfacePtr) as IDXGISurface;
                Marshal.Release(pSurfacePtr);
            }
            return pDXGISurface;
        }

        private ID2D1Bitmap1 CreateBitmapFromSurface(IDXGISurface pSurface, ID2D1DeviceContext pD2DDeviceContext, D2D1_BITMAP_OPTIONS options)
        {
            uint nDPI = GetDpiForWindow(FindWindow("Shell_TrayWnd", null));
            var props = new D2D1_BITMAP_PROPERTIES1
            {
                pixelFormat = new D2D1_PIXEL_FORMAT
                {
                    format = DXGI_FORMAT.DXGI_FORMAT_B8G8R8A8_UNORM,
                    alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_PREMULTIPLIED
                },
                dpiX = 96,
                dpiY = 96,
                //dpiX = nDPI,
                //dpiY = nDPI,
                bitmapOptions = options
            };
            HRESULT hr = pD2DDeviceContext.CreateBitmapFromDxgiSurface(pSurface, ref props, out ID2D1Bitmap1 pD2DBitmap1);
            return pD2DBitmap1;
        }

        // History with help from ChatGPT...

        private string? m_sHistoryFile = null;
        private List<string> m_History = new();
        private const int m_nHistoryLimit = 100;

        private void LoadHistory()
        {
            if (File.Exists(m_sHistoryFile))
            {
                try
                {
                    string sJson = File.ReadAllText(m_sHistoryFile);
                    m_History = JsonSerializer.Deserialize<List<string>>(sJson) ?? new();
                }
                catch
                {
                    m_History = new();
                }
            }
        }

        private void SaveHistory()
        {
            try
            {
                // Keep only the most recent N entries
                if (m_History.Count > m_nHistoryLimit)
                {
                    m_History = m_History
                        .Skip(m_History.Count - m_nHistoryLimit)
                        .ToList();
                }

                if (m_sHistoryFile != null)
                {
                    string sJson = JsonSerializer.Serialize(m_History);
                    File.WriteAllText(m_sHistoryFile, sJson);
                }
            }
            catch
            {
                // ...
            }
        }

        private void tbURL_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput)
                return;
            string sInput = sender.Text.Trim();
            // Show suggestions that contain the input anywhere, newest first
            var suggestions = m_History
                .Where(h => h.IndexOf(sInput, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(10) // max 10 suggestions
                .ToList();
            sender.ItemsSource = suggestions;
        }

        private void tbURL_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }

        private async void tbURL_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string sURL = sender.Text.Trim();
            if (string.IsNullOrWhiteSpace(sURL))
                return;

            // Remove old entry if it exists
            m_History.RemoveAll(h => string.Equals(h, sURL, StringComparison.OrdinalIgnoreCase));

            // Add new entry at the top (newest first)
            m_History.Insert(0, sURL);

            // Trim history to maximum limit
            if (m_History.Count > m_nHistoryLimit)
                m_History = m_History.Take(m_nHistoryLimit).ToList();

            SaveHistory();

            await NavigateAsync();
        }

        private async System.Threading.Tasks.Task NavigateAsync()
        {
            HRESULT hr = HRESULT.S_OK;
            if (m_pController2 != null)
            {
                if (m_pCoreWebView2 != null)
                {
                    string sURL = NormalizeUrl(tbURL.Text);
                    hr = m_pCoreWebView2.Navigate(sURL);
                    if (!SUCCEEDED(hr))
                    {
                        string sError = "Could not navigate to " + tbURL.Text + "\r\n" + "HRESULT = 0x" + string.Format("{0:X}", hr) + "\r\n" + Marshal.GetExceptionForHR((int)hr)?.Message;
                        Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                        WinRT.Interop.InitializeWithWindow.Initialize(md, hWndMain);
                        _ = await md.ShowAsync();
                    }
                }
            }
            else
            {
                string sError = "Composition controller not created";
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(sError, "Error");
                WinRT.Interop.InitializeWithWindow.Initialize(md, hWndMain);
                _ = await md.ShowAsync();
            }
        }

        private void tbURL_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbURL.Text))
            {
                tbURL.ItemsSource = m_History;
                if (m_History.Count > 0)
                    tbURL.IsSuggestionListOpen = true;
            }
        }

        string NormalizeUrl(string sInput)
        {
            if (string.IsNullOrWhiteSpace(sInput))
                return "about:blank";

            string s = sInput.Trim();

            // If it already starts with a scheme (e.g. http:, https:, about:, file:, mailto:, data:, etc.)
            // match: letter then letters/digits/+-. then colon
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^[a-zA-Z][a-zA-Z0-9+\-.]*:"))
                return s;

            // protocol-relative URLs like //example.com -> treat as http
            if (s.StartsWith("//"))
                return "http:" + s;

            // otherwise assume http
            return "http://" + s;
        }

        // To avoid "Only a single ContentDialog can be open at any time.'
        bool bDialog = false;

        private async void btnClearHistory_Click(object sender, RoutedEventArgs e)
        {
            if (bDialog)
                return;

            var md = new Microsoft.UI.Xaml.Controls.ContentDialog
            {
                Title = "Confirm",
                Content = "Are you sure you want to clear the history ?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "No",
                XamlRoot = this.Content.XamlRoot
            };

            bDialog = true;
            try
            {
                var result = await md.ShowAsync();
                if (result == Microsoft.UI.Xaml.Controls.ContentDialogResult.Primary)
                {
                    m_History.Clear();
                    tbURL.ItemsSource = null;
                    try
                    {
                        if (File.Exists(m_sHistoryFile))
                            File.Delete(m_sHistoryFile);
                    }
                    catch
                    {
                        // ...
                    }
                }
            }
            finally
            {
                bDialog = false;
            }
        }

        // From https://github.com/castorix/WinUI3_MediaPlayer_Composition

        public event PropertyChangedEventHandler? PropertyChanged;

        private float _strengthEmboss = 5f;
        public float StrengthEmboss
        {
            get => _strengthEmboss;
            set
            {
                if (_strengthEmboss != value)
                {
                    _strengthEmboss = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrengthEmboss)));
                }
            }
        }

        private float _gaussianBlur = 10f;
        public float GaussianBlur
        {
            get => _gaussianBlur;
            set
            {
                if (_gaussianBlur != value)
                {
                    _gaussianBlur = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GaussianBlur)));
                }
            }
        }

        private float _edgeDetection = 0.5f;
        public float EdgeDetection
        {
            get => _edgeDetection;
            set
            {
                if (_edgeDetection != value)
                {
                    _edgeDetection = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EdgeDetection)));
                }
            }
        }

        private float _temperature = 0.0f;
        public float Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
                }
            }
        }

        private float _tint = 0.0f;
        public float Tint
        {
            get => _tint;
            set
            {
                if (_tint != value)
                {
                    _tint = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tint)));
                }
            }
        }

        private void cbEmboss_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGrayscale.IsChecked == true)
            {
                cbGrayscale.IsChecked = false;
            }

            //if (cbInvert.IsChecked == true)
            //{
            //    cbInvert.IsChecked = false;
            //}

            if (cbGaussianBlur.IsChecked == true)
            {
                cbGaussianBlur.IsChecked = false;
            }

            if (cbEdgeDetection.IsChecked == true)
            {
                cbEdgeDetection.IsChecked = false;
            }

            //if (cbTemperatureTint.IsChecked == true)
            //{
            //    cbTemperatureTint.IsChecked = false;
            //}
        }

        private void cbGaussianBlur_Checked(object sender, RoutedEventArgs e)
        {
            //if (cbGrayscale.IsChecked == true)
            //{
            //    cbGrayscale.IsChecked = false;
            //}

            //if (cbInvert.IsChecked == true)
            //{
            //    cbInvert.IsChecked = false;
            //}

            if (cbEmboss.IsChecked == true)
            {
                cbEmboss.IsChecked = false;
            }

            if (cbEdgeDetection.IsChecked == true)
            {
                cbEdgeDetection.IsChecked = false;
            }

            //if (cbTemperatureTint.IsChecked == true)
            //{
            //    cbTemperatureTint.IsChecked = false;
            //}
        }

        private void cbEdgeDetection_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGrayscale.IsChecked == true)
            {
                cbGrayscale.IsChecked = false;
            }

            if (cbInvert.IsChecked == true)
            {
                cbInvert.IsChecked = false;
            }

            if (cbEmboss.IsChecked == true)
            {
                cbEmboss.IsChecked = false;
            }

            if (cbGaussianBlur.IsChecked == true)
            {
                cbGaussianBlur.IsChecked = false;
            }

            //if (cbTemperatureTint.IsChecked == true)
            //{
            //    cbTemperatureTint.IsChecked = false;
            //}
        }

        private void cbGrayscale_Checked(object sender, RoutedEventArgs e)
        {
            //if (cbInvert.IsChecked == true)
            //{
            //    cbInvert.IsChecked = false;
            //}

            if (cbEmboss.IsChecked == true)
            {
                cbEmboss.IsChecked = false;
            }

            //if (cbGaussianBlur.IsChecked == true)
            //{
            //    cbGaussianBlur.IsChecked = false;
            //}

            if (cbEdgeDetection.IsChecked == true)
            {
                cbEdgeDetection.IsChecked = false;
            }

            //if (cbTemperatureTint.IsChecked == true)
            //{
            //    cbTemperatureTint.IsChecked = false;
            //}
        }

        private void cbInvert_Checked(object sender, RoutedEventArgs e)
        {
            //if (cbGrayscale.IsChecked == true)
            //{
            //    cbGrayscale.IsChecked = false;
            //}

            //if (cbEmboss.IsChecked == true)
            //{
            //    cbEmboss.IsChecked = false;
            //}

            //if (cbGaussianBlur.IsChecked == true)
            //{
            //    cbGaussianBlur.IsChecked = false;
            //}

            if (cbEdgeDetection.IsChecked == true)
            {
                cbEdgeDetection.IsChecked = false;
            }

            //if (cbTemperatureTint.IsChecked == true)
            //{
            //    cbTemperatureTint.IsChecked = false;
            //}
        }

        private void cbTemperatureTint_Checked(object sender, RoutedEventArgs e)
        {
            //if (cbGrayscale.IsChecked == true)
            //{
            //    cbGrayscale.IsChecked = false;
            //}

            //if (cbInvert.IsChecked == true)
            //{
            //    cbInvert.IsChecked = false;
            //}

            //if (cbEmboss.IsChecked == true)
            //{
            //    cbEmboss.IsChecked = false;
            //}

            //if (cbGaussianBlur.IsChecked == true)
            //{
            //    cbGaussianBlur.IsChecked = false;
            //}

            //if (cbEdgeDetection.IsChecked == true)
            //{
            //    cbEdgeDetection.IsChecked = false;
            //}
        }

        private void SetEffectFloat(ID2D1Effect pEffect, uint nEffect, float fValue)
        {
            float[] aFloatArray = { fValue };
            int nDataSize = aFloatArray.Length * Marshal.SizeOf(typeof(float));
            IntPtr pData = Marshal.AllocHGlobal(nDataSize);
            Marshal.Copy(aFloatArray, 0, pData, aFloatArray.Length);
            HRESULT hr = pEffect.SetValue(nEffect, D2D1_PROPERTY_TYPE.D2D1_PROPERTY_TYPE_UNKNOWN, pData, (uint)nDataSize);
            Marshal.FreeHGlobal(pData);
        }

        private void SetEffectFloatArray(ID2D1Effect pEffect, uint nEffect, float[] aFloatArray)
        {
            int nDataSize = aFloatArray.Length * Marshal.SizeOf(typeof(float));
            IntPtr pData = Marshal.AllocHGlobal(nDataSize);
            Marshal.Copy(aFloatArray, 0, pData, aFloatArray.Length);
            HRESULT hr = pEffect.SetValue(nEffect, D2D1_PROPERTY_TYPE.D2D1_PROPERTY_TYPE_UNKNOWN, pData, (uint)nDataSize);
            Marshal.FreeHGlobal(pData);
        }

        private void SetEffectInt(ID2D1Effect pEffect, uint nEffect, uint nValue)
        {
            IntPtr pData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Int32)));
            Marshal.WriteInt32(pData, (int)nValue);
            HRESULT hr = pEffect.SetValue(nEffect, D2D1_PROPERTY_TYPE.D2D1_PROPERTY_TYPE_UNKNOWN, pData, (uint)Marshal.SizeOf(typeof(Int32)));
            Marshal.FreeHGlobal(pData);
        }        

        private void Clean()
        {
            // Stop timers
            m_timer?.Stop();
            m_timer = null;
            m_renderTimer?.Stop();
            m_renderTimer = null;

            // Dispose Capture objects
            m_captureSession?.Dispose();
            m_captureSession = null;
            m_captureFramePool?.Dispose();            
            m_captureFramePool = null;

            // Release textures and shader resources           
            SafeRelease(ref m_cubeVertexBuffer);
            SafeRelease(ref m_cubeIndexBuffer);
            SafeRelease(ref m_constantBuffer);
            SafeRelease(ref m_captureSRV);

            SafeRelease(ref m_swirlVS);
            SafeRelease(ref m_swirlPS);
            SafeRelease(ref m_cbTime);

            // Cube edges
            SafeRelease(ref m_edgeVertexBuffer);
            SafeRelease(ref m_edgeIndexBuffer);
            SafeRelease(ref m_psEdge);
            SafeRelease(ref m_dsEdges);

            // Cube shaders
            SafeRelease(ref m_cubeVS);
            SafeRelease(ref m_cubePS);
            SafeRelease(ref m_inputLayout);

            // States
            SafeRelease(ref m_sampler);
            SafeRelease(ref m_rs);

            // Paper
            SafeRelease(ref m_paperVertexBuffer);
            SafeRelease(ref m_paperIndexBuffer);
            SafeRelease(ref m_paperConstantBuffer);
            SafeRelease(ref m_paperVS);
            SafeRelease(ref m_paperPS);            

            // Tunnel
            SafeRelease(ref m_tunnelVB);
            SafeRelease(ref m_tunnelIB);
            SafeRelease(ref m_tunnelConstantBuffer);
            SafeRelease(ref m_tunnelVS);
            SafeRelease(ref m_tunnelPS);
            SafeRelease(ref m_tunnelInputLayout);
            SafeRelease(ref m_samplerWrap);
            SafeRelease(ref m_tunnelSRV);            

            // Render targets
            SafeRelease(ref m_rtv);
            SafeRelease(ref m_dsv);

            // Dispose IDirect3DDevice (not COM)
            m_pDirect3DDevice?.Dispose();
            m_pDirect3DDevice = null;

            // Release D2D objects
            SafeRelease(ref m_pD2DBitmap1);
            SafeRelease(ref m_pD2DDeviceContext);           

            // Release DXGI swap chain and device
            SafeRelease(ref m_pD2DTargetBitmap);
            SafeRelease(ref m_pDXGISwapChain1);
            SafeRelease(ref m_pDXGIDevice);
            SafeRelease(ref m_pD3D11DeviceContext);
            if (m_pD3D11DeviceContextPtr != IntPtr.Zero)
                Marshal.Release(m_pD3D11DeviceContextPtr);            
            SafeRelease(ref m_pD3D11Device);
            if (m_pD3D11DevicePtr != IntPtr.Zero)
                Marshal.Release(m_pD3D11DevicePtr);

            SafeRelease(ref m_pWICImagingFactory);
            SafeRelease(ref m_pD2DFactory1);
            SafeRelease(ref m_pD2DFactory);

            // Release WebView2 composition objects
            if (m_pCompositionController != null)
            {               
                m_pCompositionController.put_RootVisualTarget(IntPtr.Zero);              
                SafeRelease(ref m_pCompositionController);               
            }
            if (m_pController2 != null)                        
                SafeRelease(ref m_pController2);
            SafeRelease(ref m_pCoreWebView2);

            // Force garbage collection to clear remaining RCWs
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            Clean();
        }     
    }

    public class BooleanToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b)
            {
                return b ? 1.0 : 0.35; // Enabled → full opacity, Disabled → faded
            }
            return 1.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool isOn)
            {
                return isOn ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

# WinUI3_SwapChainPanel_WebView2

Test rendering a composited WebView2 (connected to a [Windows.UI.Composition.ContainerVisual](https://learn.microsoft.com/en-us/uwp/api/windows.ui.composition.containervisual?view=winrt-26100)) 
inside a SwapChainPanel, with Direct2D or Direct3D 11 and [GraphicsCaptureItem](https://learn.microsoft.com/en-us/uwp/api/windows.graphics.capture.graphicscaptureitem?view=winrt-26100)
to get frames, then [IDirect3DDxgiInterfaceAccess](https://learn.microsoft.com/en-us/windows/win32/api/windows.graphics.directx.direct3d11.interop/ns-windows-graphics-directx-direct3d11-interop-idirect3ddxgiinterfaceaccess) to get IDXGISurface or ID3D11Texture2D 

Tested on Windows 10 22H2 with no discrete GPU (Intel® HD Graphics), Windows App SDK 1.7.250401001

<img width="1031" height="753" alt="WebView2_WindowsComposition" src="https://github.com/user-attachments/assets/01cd0bde-696a-4962-b48b-93917e5968c1" />

using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using GlobalStructures;
using Microsoft.UI.Xaml.Controls;
using WinRT;

// https://www.nuget.org/packages/Microsoft.Web.WebView2/

namespace WebView2
{
    internal class WebView2Tools
    { 
        [DllImport("WebView2Loader.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CreateCoreWebView2EnvironmentWithOptions([MarshalAs(UnmanagedType.LPWStr)] string? browserExecutableFolder,
            [MarshalAs(UnmanagedType.LPWStr)] string? userDataFolder,
            IntPtr environmentOptions, // ICoreWebView2EnvironmentOptions environmentOptions,
            ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler handler);

        [DllImport("WebView2Loader.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CreateCoreWebView2Environment(ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler environmentCreatedHandler);

        [DllImport("WebView2Loader.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT GetAvailableCoreWebView2BrowserVersionString(string browserExecutableFolder, [MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);

        [DllImport("WebView2Loader.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT GetAvailableCoreWebView2BrowserVersionStringWithOptions(string browserExecutableFolder,
            ICoreWebView2EnvironmentOptions environmentOptions, [MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);

        [DllImport("WebView2Loader.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HRESULT CompareBrowserVersions(string version1, string version2, out int result);
    }

    [ComImport]
    [Guid("4e8a3389-c9d8-4bd2-b6b5-124fee6cc14d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2Environment result);
    }

    [ComImport]
    [Guid("b96d755e-0319-4e92-a296-23436f46a1fc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment
    {
        [PreserveSig]
        HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("41f3632b-5ef4-404f-ad82-2d606c5a9a21")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment2 : ICoreWebView2Environment
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);
    }

    [ComImport]
    [Guid("80a22ae3-be7c-4ce2-afe1-5a50056cdeeb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment3 : ICoreWebView2Environment2
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);
    }

    [ComImport]
    [Guid("20944379-6dcf-41d6-a0a0-abc0fc50de0d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment4 : ICoreWebView2Environment3
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);
    }

    [ComImport]
    [Guid("319e423d-e0d7-4b8d-9254-ae9475de9b17")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment5 : ICoreWebView2Environment4
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_BrowserProcessExited(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("e59ee362-acbd-4857-9a8e-d3644d9459a9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment6 : ICoreWebView2Environment5
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);
    }

    [ComImport]
    [Guid("43c22296-3bbd-43a4-9c00-5c0df6dd29a2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment7 : ICoreWebView2Environment6
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);
    }

    [ComImport]
    [Guid("d6eb91dd-c3d2-45e5-bd29-6dc2bc4de9cf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment8 : ICoreWebView2Environment7
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);
    }

    [ComImport]
    [Guid("f06f41bf-4b5a-49d8-b9f6-fa16cd29f274")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment9 : ICoreWebView2Environment8
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);
    }

    [ComImport]
    [Guid("ee0eb9df-6f12-46ce-b53f-3f47b9c928e0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment10 : ICoreWebView2Environment9
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
    }

    [ComImport]
    [Guid("f0913dc6-a0ec-42ef-9805-91dff3a2966a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment11 : ICoreWebView2Environment10
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);

        [PreserveSig]
        HRESULT get_FailureReportFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
    }

    [ComImport]
    [Guid("f503db9b-739f-48dd-b151-fdfcf253f54e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment12 : ICoreWebView2Environment11
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_FailureReportFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT CreateSharedBuffer(UInt64 Size, out ICoreWebView2SharedBuffer value);
    }

    [ComImport]
    [Guid("af641f58-72b2-11ee-b962-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment13 : ICoreWebView2Environment12
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_FailureReportFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT CreateSharedBuffer(UInt64 Size, out ICoreWebView2SharedBuffer value);

        [PreserveSig]
        HRESULT GetProcessExtendedInfos(ICoreWebView2GetProcessExtendedInfosCompletedHandler handler);
    }

    [ComImport]
    [Guid("a5e9fad9-c875-59da-9bd7-473aa5ca1cef")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment14 : ICoreWebView2Environment13
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_FailureReportFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT CreateSharedBuffer(UInt64 Size, out ICoreWebView2SharedBuffer value);

        [PreserveSig]
        new HRESULT GetProcessExtendedInfos(ICoreWebView2GetProcessExtendedInfosCompletedHandler handler);

        [PreserveSig]
        HRESULT CreateWebFileSystemFileHandle(string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission, out ICoreWebView2FileSystemHandle value);
        [PreserveSig]
        HRESULT CreateWebFileSystemDirectoryHandle(string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission, out ICoreWebView2FileSystemHandle value);
        [PreserveSig]
        HRESULT CreateObjectCollection(uint length,IntPtr items, out ICoreWebView2ObjectCollection objectCollection);
    }

    [ComImport]
    [Guid("2ac5ebfb-e654-5961-a667-7971885c7b27")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Environment15 : ICoreWebView2Environment14
    {
        [PreserveSig]
        new HRESULT CreateCoreWebView2Controller(IntPtr parentWindow, ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateWebResourceResponse(IStream content, int statusCode, string reasonPhrase, string headers, out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT get_BrowserVersionString([MarshalAs(UnmanagedType.LPWStr)] out string versionInfo);
        [PreserveSig]
        new HRESULT add_NewBrowserVersionAvailable(ICoreWebView2NewBrowserVersionAvailableEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewBrowserVersionAvailable(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreateWebResourceRequest(string uri, string Method, IStream postData, string Headers, out ICoreWebView2WebResourceRequest value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionController(IntPtr ParentWindow, ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2PointerInfo(out ICoreWebView2PointerInfo value);

        [PreserveSig]
        new HRESULT GetAutomationProviderForWindow(IntPtr hwnd, out IntPtr value);

        [PreserveSig]
        new HRESULT add_BrowserProcessExited(ICoreWebView2BrowserProcessExitedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BrowserProcessExited(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CreatePrintSettings(out ICoreWebView2PrintSettings value);

        [PreserveSig]
        new HRESULT get_UserDataFolder([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT add_ProcessInfosChanged(ICoreWebView2ProcessInfosChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessInfosChanged(out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT GetProcessInfos(out ICoreWebView2ProcessInfoCollection value);

        [PreserveSig]
        new HRESULT CreateContextMenuItem(string Label, IStream iconStream, COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND Kind, out ICoreWebView2ContextMenuItem value);

        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerOptions(out ICoreWebView2ControllerOptions value);
        [PreserveSig]
        new HRESULT CreateCoreWebView2ControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2ControllerCompletedHandler handler);
        [PreserveSig]
        new HRESULT CreateCoreWebView2CompositionControllerWithOptions(IntPtr ParentWindow, ICoreWebView2ControllerOptions options,
        ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_FailureReportFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT CreateSharedBuffer(UInt64 Size, out ICoreWebView2SharedBuffer value);

        [PreserveSig]
        new HRESULT GetProcessExtendedInfos(ICoreWebView2GetProcessExtendedInfosCompletedHandler handler);

        [PreserveSig]
        new HRESULT CreateWebFileSystemFileHandle(string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission, out ICoreWebView2FileSystemHandle value);
        [PreserveSig]
        new HRESULT CreateWebFileSystemDirectoryHandle(string path, COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION permission, out ICoreWebView2FileSystemHandle value);
        [PreserveSig]
        new HRESULT CreateObjectCollection(uint length, IntPtr items, out ICoreWebView2ObjectCollection objectCollection);

        HRESULT CreateFindOptions(out ICoreWebView2FindOptions value);
    }

    [ComImport]
    [Guid("0f36fd87-4f69-4415-98da-888f89fb9a33")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ObjectCollectionView
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out IntPtr value);
    }

    [ComImport]
    [Guid("5cfec11c-25bd-4e8d-9e1a-7acdaeeec047")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ObjectCollection : ICoreWebView2ObjectCollectionView
    {
        [PreserveSig]
        new HRESULT get_Count(out uint value);
        [PreserveSig]
        new HRESULT GetValueAtIndex(uint index, out IntPtr value);

        [PreserveSig]
        HRESULT RemoveValueAtIndex(uint index);
        [PreserveSig]
        HRESULT InsertValueAtIndex(uint index, IntPtr value);
    }

    [ComImport]
    [Guid("c65100ac-0de2-5551-a362-23d9bd1d0e1f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FileSystemHandle
    {
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND value);
        [PreserveSig]
        HRESULT get_Path([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Permission(out COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION value);
    }

    [ComImport]
    [Guid("f45e55aa-3bc2-11ee-be56-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2GetProcessExtendedInfosCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2ProcessExtendedInfoCollection result);
    }

    [ComImport]
    [Guid("32efa696-407a-11ee-be56-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessExtendedInfoCollection
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2ProcessExtendedInfo value);
    }

    [ComImport]
    [Guid("af4c4c2e-45db-11ee-be56-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessExtendedInfo
    {
        [PreserveSig]
        HRESULT get_ProcessInfo(out ICoreWebView2ProcessInfo processInfo);
        [PreserveSig]
        HRESULT get_AssociatedFrameInfos(out ICoreWebView2FrameInfoCollection frames);
    }

    [ComImport]
    [Guid("8f834154-d38e-4d90-affb-6800a7272839")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameInfoCollection
    {
        [PreserveSig]
        HRESULT GetIterator(out ICoreWebView2FrameInfoCollectionIterator value);
    }

    [ComImport]
    [Guid("1bf89e2d-1b2b-4629-b28f-05099b41bb03")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameInfoCollectionIterator
    {
        [PreserveSig]
        HRESULT get_HasCurrent(out bool value);
        [PreserveSig]
        HRESULT GetCurrent(out ICoreWebView2FrameInfo value);
        [PreserveSig]
        HRESULT MoveNext(out bool value);
    }

    public enum COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND
    {
        COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_COMMAND = 0,
        COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_CHECK_BOX = (COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_COMMAND + 1),
        COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_RADIO = (COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_CHECK_BOX + 1),
        COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_SEPARATOR = (COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_RADIO + 1),
        COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_SUBMENU = (COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND_SEPARATOR + 1)
    }

    [ComImport]
    [Guid("f4af0c39-44b9-40e9-8b11-0484cfb9e0a1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessInfosChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Environment sender, IntPtr args);
    }

    [ComImport]
    [Guid("7aed49e3-a93f-497a-811c-749c6b6b6c65")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContextMenuItem
    {
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Label([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_CommandId(out int value);
        [PreserveSig]
        HRESULT get_ShortcutKeyDescription([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Icon(out IStream value);
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_CONTEXT_MENU_ITEM_KIND value);
        [PreserveSig]
        HRESULT put_IsEnabled(bool value);
        [PreserveSig]
        HRESULT get_IsEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsChecked(bool value);
        [PreserveSig]
        HRESULT get_IsChecked(out bool value);
        [PreserveSig]
        HRESULT get_Children(out ICoreWebView2ContextMenuItemCollection value);
        [PreserveSig]
        HRESULT add_CustomItemSelected(ICoreWebView2CustomItemSelectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_CustomItemSelected(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("f562a2f5-c415-45cf-b909-d4b7c1e276d3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContextMenuItemCollection
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2ContextMenuItem value);
        [PreserveSig]
        HRESULT RemoveValueAtIndex(uint index);
        [PreserveSig]
        HRESULT InsertValueAtIndex(uint index, ICoreWebView2ContextMenuItem value);
    }

    [ComImport]
    [Guid("49e1d0bc-fe9e-4481-b7c2-32324aa21998")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CustomItemSelectedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2ContextMenuItem sender, IntPtr args);
    }

    [ComImport]
    [Guid("402b99cd-a0cc-4fa5-b7a5-51d86a1d2339")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessInfoCollection
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2ProcessInfo value);
    }

    [ComImport]
    [Guid("84FA7612-3F3D-4FBF-889D-FAD000492D72")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessInfo
    {
        [PreserveSig]
        HRESULT get_ProcessId(out int value);
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_PROCESS_KIND kind);
    }

    [ComImport]
    [Guid("377f3721-c74e-48ca-8db1-df68e51d60e2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PrintSettings
    {
        [PreserveSig]
        HRESULT get_Orientation(out COREWEBVIEW2_PRINT_ORIENTATION orientation);
        [PreserveSig]
        HRESULT put_Orientation(COREWEBVIEW2_PRINT_ORIENTATION orientation);
        [PreserveSig]
        HRESULT get_ScaleFactor(out double scaleFactor);
        [PreserveSig]
        HRESULT put_ScaleFactor(double scaleFactor);
        [PreserveSig]
        HRESULT get_PageWidth(out double pageWidth);
        [PreserveSig]
        HRESULT put_PageWidth(double pageWidth);
        [PreserveSig]
        HRESULT get_PageHeight(out double pageHeight);
        [PreserveSig]
        HRESULT put_PageHeight(double pageHeight);
        [PreserveSig]
        HRESULT get_MarginTop(out double marginTop);
        [PreserveSig]
        HRESULT put_MarginTop(double marginTop);
        [PreserveSig]
        HRESULT get_MarginBottom(out double marginBottom);
        [PreserveSig]
        HRESULT put_MarginBottom(double marginBottom);
        [PreserveSig]
        HRESULT get_MarginLeft(out double marginLeft);
        [PreserveSig]
        HRESULT put_MarginLeft(double marginLeft);
        [PreserveSig]
        HRESULT get_MarginRight(out double marginRight);
        [PreserveSig]
        HRESULT put_MarginRight(double marginRight);
        [PreserveSig]
        HRESULT get_ShouldPrintBackgrounds(out bool shouldPrintBackgrounds);
        [PreserveSig]
        HRESULT put_ShouldPrintBackgrounds(bool shouldPrintBackgrounds);
        [PreserveSig]
        HRESULT get_ShouldPrintSelectionOnly(out bool shouldPrintSelectionOnly);
        [PreserveSig]
        HRESULT put_ShouldPrintSelectionOnly(bool shouldPrintSelectionOnly);
        [PreserveSig]
        HRESULT get_ShouldPrintHeaderAndFooter(out bool shouldPrintHeaderAndFooter);
        [PreserveSig]
        HRESULT put_ShouldPrintHeaderAndFooter(bool shouldPrintHeaderAndFooter);
        [PreserveSig]
        HRESULT get_HeaderTitle([MarshalAs(UnmanagedType.LPWStr)] out string headerTitle);
        [PreserveSig]
        HRESULT put_HeaderTitle(string headerTitle);
        [PreserveSig]
        HRESULT get_FooterUri([MarshalAs(UnmanagedType.LPWStr)] out string footerUri);
        [PreserveSig]
        HRESULT put_FooterUri(string footerUri);
    }

    [ComImport]
    [Guid("CA7F0E1F-3484-41D1-8C1A-65CD44A63F8D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PrintSettings2 : ICoreWebView2PrintSettings
    {
        [PreserveSig]
        new HRESULT get_Orientation(out COREWEBVIEW2_PRINT_ORIENTATION orientation);
        [PreserveSig]
        new HRESULT put_Orientation(COREWEBVIEW2_PRINT_ORIENTATION orientation);
        [PreserveSig]
        new HRESULT get_ScaleFactor(out double scaleFactor);
        [PreserveSig]
        new HRESULT put_ScaleFactor(double scaleFactor);
        [PreserveSig]
        new HRESULT get_PageWidth(out double pageWidth);
        [PreserveSig]
        new HRESULT put_PageWidth(double pageWidth);
        [PreserveSig]
        new HRESULT get_PageHeight(out double pageHeight);
        [PreserveSig]
        new HRESULT put_PageHeight(double pageHeight);
        [PreserveSig]
        new HRESULT get_MarginTop(out double marginTop);
        [PreserveSig]
        new HRESULT put_MarginTop(double marginTop);
        [PreserveSig]
        new HRESULT get_MarginBottom(out double marginBottom);
        [PreserveSig]
        new HRESULT put_MarginBottom(double marginBottom);
        [PreserveSig]
        new HRESULT get_MarginLeft(out double marginLeft);
        [PreserveSig]
        new HRESULT put_MarginLeft(double marginLeft);
        [PreserveSig]
        new HRESULT get_MarginRight(out double marginRight);
        [PreserveSig]
        new HRESULT put_MarginRight(double marginRight);
        [PreserveSig]
        new HRESULT get_ShouldPrintBackgrounds(out bool shouldPrintBackgrounds);
        [PreserveSig]
        new HRESULT put_ShouldPrintBackgrounds(bool shouldPrintBackgrounds);
        [PreserveSig]
        new HRESULT get_ShouldPrintSelectionOnly(out bool shouldPrintSelectionOnly);
        [PreserveSig]
        new HRESULT put_ShouldPrintSelectionOnly(bool shouldPrintSelectionOnly);
        [PreserveSig]
        new HRESULT get_ShouldPrintHeaderAndFooter(out bool shouldPrintHeaderAndFooter);
        [PreserveSig]
        new HRESULT put_ShouldPrintHeaderAndFooter(bool shouldPrintHeaderAndFooter);
        [PreserveSig]
        new HRESULT get_HeaderTitle([MarshalAs(UnmanagedType.LPWStr)] out string headerTitle);
        [PreserveSig]
        new HRESULT put_HeaderTitle(string headerTitle);
        [PreserveSig]
        new HRESULT get_FooterUri([MarshalAs(UnmanagedType.LPWStr)] out string footerUri);
        [PreserveSig]
        new HRESULT put_FooterUri(string footerUri);

        [PreserveSig]
        HRESULT get_PageRanges([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_PageRanges(string value);
        [PreserveSig]
        HRESULT get_PagesPerSide(out int value);
        [PreserveSig]
        HRESULT put_PagesPerSide(int value);
        [PreserveSig]
        HRESULT get_Copies(out int value);
        [PreserveSig]
        HRESULT put_Copies(int value);
        [PreserveSig]
        HRESULT get_Collation(out COREWEBVIEW2_PRINT_COLLATION value);
        [PreserveSig]
        HRESULT put_Collation(COREWEBVIEW2_PRINT_COLLATION value);
        [PreserveSig]
        HRESULT get_ColorMode(out COREWEBVIEW2_PRINT_COLOR_MODE value);
        [PreserveSig]
        HRESULT put_ColorMode(COREWEBVIEW2_PRINT_COLOR_MODE value);
        [PreserveSig]
        HRESULT get_Duplex(out COREWEBVIEW2_PRINT_DUPLEX value);
        [PreserveSig]
        HRESULT put_Duplex(COREWEBVIEW2_PRINT_DUPLEX value);
        [PreserveSig]
        HRESULT get_MediaSize(out COREWEBVIEW2_PRINT_MEDIA_SIZE value);
        [PreserveSig]
        HRESULT put_MediaSize(COREWEBVIEW2_PRINT_MEDIA_SIZE value);
        [PreserveSig]
        HRESULT get_PrinterName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_PrinterName(string value);
    }

    [ComImport]
    [Guid("fa504257-a216-4911-a860-fe8825712861")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserProcessExitedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Environment sender, ICoreWebView2BrowserProcessExitedEventArgs args);
    }

    [ComImport]
    [Guid("1f00663f-af8c-4782-9cdd-dd01c52e34cb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserProcessExitedEventArgs
    {
        [PreserveSig]
        HRESULT get_BrowserProcessExitKind(out COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND value);
        [PreserveSig]
        HRESULT get_BrowserProcessId(out uint value);
    }

    public enum COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND
    {
        COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND_NORMAL = 0,
        COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND_FAILED = (COREWEBVIEW2_BROWSER_PROCESS_EXIT_KIND_NORMAL + 1)
    }

    [ComImport]
    [Guid("aafcc94f-fa27-48fd-97df-830ef75aaec9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceResponse
    {
        [PreserveSig]
        HRESULT get_Content(out IStream content);
        [PreserveSig]
        HRESULT put_Content(IStream content);
        [PreserveSig]
        HRESULT get_Headers(out ICoreWebView2HttpResponseHeaders headers);
        [PreserveSig]
        HRESULT get_StatusCode(out int statusCode);
        [PreserveSig]
        HRESULT put_StatusCode(int statusCode);
        [PreserveSig]
        HRESULT get_ReasonPhrase([MarshalAs(UnmanagedType.LPWStr)] out string reasonPhrase);
        [PreserveSig]
        HRESULT put_ReasonPhrase(string reasonPhrase);
    }

    [ComImport]
    [Guid("03c5ff5a-9b45-4a88-881c-89a9f328619c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2HttpResponseHeaders
    {
        [PreserveSig]
        HRESULT AppendHeader(string name, string value);
        [PreserveSig]
        HRESULT Contains(string name, out bool value);
        [PreserveSig]
        HRESULT GetHeader(string name, [MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT GetHeaders(string name, out ICoreWebView2HttpHeadersCollectionIterator value);
        [PreserveSig]
        HRESULT GetIterator(out ICoreWebView2HttpHeadersCollectionIterator value);
    }

    [ComImport]
    [Guid("f9a2976e-d34e-44fc-adee-81b6b57ca914")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NewBrowserVersionAvailableEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Environment sender, IntPtr args);
    }

    [ComImport]
    [Guid("97055cd4-512c-4264-8b5f-e3f446cea6a5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceRequest
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT put_Uri(string uri);
        [PreserveSig]
        HRESULT get_Method([MarshalAs(UnmanagedType.LPWStr)] out string method);
        [PreserveSig]
        HRESULT put_Method(string method);
        [PreserveSig]
        HRESULT get_Content(out IStream content);
        [PreserveSig]
        HRESULT put_Content(IStream content);
        [PreserveSig]
        HRESULT get_Headers(out ICoreWebView2HttpRequestHeaders headers);
    }

    [ComImport]
    [Guid("e6995887-d10d-4f5d-9359-4ce46e4f96b9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PointerInfo
    {
        [PreserveSig]
        HRESULT get_PointerKind(out uint pointerKind);
        [PreserveSig]
        HRESULT put_PointerKind(uint pointerKind);
        [PreserveSig]
        HRESULT get_PointerId(out uint pointerId);
        [PreserveSig]
        HRESULT put_PointerId(uint pointerId);
        [PreserveSig]
        HRESULT get_FrameId(out uint frameId);
        [PreserveSig]
        HRESULT put_FrameId(uint frameId);
        [PreserveSig]
        HRESULT get_PointerFlags(out uint pointerFlags);
        [PreserveSig]
        HRESULT put_PointerFlags(uint pointerFlags);
        [PreserveSig]
        HRESULT get_PointerDeviceRect(out RECT pointerDeviceRect);
        [PreserveSig]
        HRESULT put_PointerDeviceRect(RECT pointerDeviceRect);
        [PreserveSig]
        HRESULT get_DisplayRect(out RECT displayRect);
        [PreserveSig]
        HRESULT put_DisplayRect(RECT displayRect);
        [PreserveSig]
        HRESULT get_PixelLocation(out POINT pixelLocation);
        [PreserveSig]
        HRESULT put_PixelLocation(POINT pixelLocation);
        [PreserveSig]
        HRESULT get_HimetricLocation(out POINT himetricLocation);
        [PreserveSig]
        HRESULT put_HimetricLocation(POINT himetricLocation);
        [PreserveSig]
        HRESULT get_PixelLocationRaw(out POINT pixelLocationRaw);
        [PreserveSig]
        HRESULT put_PixelLocationRaw(POINT pixelLocationRaw);
        [PreserveSig]
        HRESULT get_HimetricLocationRaw(out POINT himetricLocationRaw);
        [PreserveSig]
        HRESULT put_HimetricLocationRaw(POINT himetricLocationRaw);
        [PreserveSig]
        HRESULT get_Time(out uint time);
        [PreserveSig]
        HRESULT put_Time(uint time);
        [PreserveSig]
        HRESULT get_HistoryCount(out uint historyCount);
        [PreserveSig]
        HRESULT put_HistoryCount(uint historyCount);
        [PreserveSig]
        HRESULT get_InputData(out int inputData);
        [PreserveSig]
        HRESULT put_InputData(int inputData);
        [PreserveSig]
        HRESULT get_KeyStates(out uint keyStates);
        [PreserveSig]
        HRESULT put_KeyStates(uint keyStates);
        [PreserveSig]
        HRESULT get_PerformanceCount(out UInt64 performanceCount);
        [PreserveSig]
        HRESULT put_PerformanceCount(UInt64 performanceCount);
        [PreserveSig]
        HRESULT get_ButtonChangeKind(out int buttonChangeKind);
        [PreserveSig]
        HRESULT put_ButtonChangeKind(int buttonChangeKind);
        [PreserveSig]
        HRESULT get_PenFlags(out uint penFLags);
        [PreserveSig]
        HRESULT put_PenFlags(uint penFLags);
        [PreserveSig]
        HRESULT get_PenMask(out uint penMask);
        [PreserveSig]
        HRESULT put_PenMask(uint penMask);
        [PreserveSig]
        HRESULT get_PenPressure(out uint penPressure);
        [PreserveSig]
        HRESULT put_PenPressure(uint penPressure);
        [PreserveSig]
        HRESULT get_PenRotation(out uint penRotation);
        [PreserveSig]
        HRESULT put_PenRotation(uint penRotation);
        [PreserveSig]
        HRESULT get_PenTiltX(out int penTiltX);
        [PreserveSig]
        HRESULT put_PenTiltX(int penTiltX);
        [PreserveSig]
        HRESULT get_PenTiltY(out int penTiltY);
        [PreserveSig]
        HRESULT put_PenTiltY(int penTiltY);
        [PreserveSig]
        HRESULT get_TouchFlags(out uint touchFlags);
        [PreserveSig]
        HRESULT put_TouchFlags(uint touchFlags);
        [PreserveSig]
        HRESULT get_TouchMask(out uint touchMask);
        [PreserveSig]
        HRESULT put_TouchMask(uint touchMask);
        [PreserveSig]
        HRESULT get_TouchContact(out RECT touchContact);
        [PreserveSig]
        HRESULT put_TouchContact(RECT touchContact);
        [PreserveSig]
        HRESULT get_TouchContactRaw(out RECT touchContactRaw);
        [PreserveSig]
        HRESULT put_TouchContactRaw(RECT touchContactRaw);
        [PreserveSig]
        HRESULT get_TouchOrientation(out uint touchOrientation);
        [PreserveSig]
        HRESULT put_TouchOrientation(uint touchOrientation);
        [PreserveSig]
        HRESULT get_TouchPressure(out uint touchPressure);
        [PreserveSig]
        HRESULT put_TouchPressure(uint touchPressure);
    }

    [ComImport]
    [Guid("2fde08a8-1e9a-4766-8c05-95a9ceb9d1c5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions
    {
        [PreserveSig]
        HRESULT get_AdditionalBrowserArguments([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_AdditionalBrowserArguments([MarshalAs(UnmanagedType.LPWStr)] string value);
        [PreserveSig]
        HRESULT get_Language([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_Language([MarshalAs(UnmanagedType.LPWStr)] string value);
        [PreserveSig]
        HRESULT get_TargetCompatibleBrowserVersion([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_TargetCompatibleBrowserVersion([MarshalAs(UnmanagedType.LPWStr)] string value);
        [PreserveSig]
        HRESULT get_AllowSingleSignOnUsingOSPrimaryAccount(out bool allow);
        [PreserveSig]
        HRESULT put_AllowSingleSignOnUsingOSPrimaryAccount(bool allow);
    }

    [ComImport]
    [Guid("ff85c98a-1ba7-4a6b-90c8-2b752c89e9e2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions2
    {
        [PreserveSig]
        HRESULT get_ExclusiveUserDataFolderAccess(out bool value);
        [PreserveSig]
        HRESULT put_ExclusiveUserDataFolderAccess(bool value);
    }

    [ComImport]
    [Guid("4a5c436e-a9e3-4a2e-89c3-910d3513f5cc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions3
    {
        [PreserveSig]
        HRESULT get_IsCustomCrashReportingEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsCustomCrashReportingEnabled(bool value);
    }

    [ComImport]
    [Guid("ac52d13f-0d38-475a-9dca-876580d6793e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions4
    {
        [PreserveSig]
        //HRESULT GetCustomSchemeRegistrations(out uint count, out ICoreWebView2CustomSchemeRegistration*** schemeRegistrations);
        HRESULT GetCustomSchemeRegistrations(out uint count, out IntPtr schemeRegistrations);
        [PreserveSig]
        //HRESULT SetCustomSchemeRegistrations(uint count,ICoreWebView2CustomSchemeRegistration** schemeRegistrations);
        HRESULT SetCustomSchemeRegistrations(uint count, IntPtr schemeRegistrations);
    }

    [ComImport]
    [Guid("0ae35d64-c47f-4464-814e-259c345d1501")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions5
    {
        [PreserveSig]
        HRESULT get_EnableTrackingPrevention(out bool value);
        [PreserveSig]
        HRESULT put_EnableTrackingPrevention(bool value);
    }

    [ComImport]
    [Guid("57d29cc3-c84f-42a0-b0e2-effbd5e179de")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions6
    {
        [PreserveSig]
        HRESULT get_AreBrowserExtensionsEnabled(out bool value);            
        [PreserveSig]
        HRESULT put_AreBrowserExtensionsEnabled(bool value);
    }

    [ComImport]
    [Guid("c48d539f-e39f-441c-ae68-1f66e570bdc5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions7
    {
        [PreserveSig]
        HRESULT get_ChannelSearchKind(out COREWEBVIEW2_CHANNEL_SEARCH_KIND value);
        [PreserveSig]
        HRESULT put_ChannelSearchKind(COREWEBVIEW2_CHANNEL_SEARCH_KIND value);
        [PreserveSig]
        HRESULT get_ReleaseChannels(out COREWEBVIEW2_RELEASE_CHANNELS value);
        [PreserveSig]
        HRESULT put_ReleaseChannels(COREWEBVIEW2_RELEASE_CHANNELS value);
    }

    public enum COREWEBVIEW2_CHANNEL_SEARCH_KIND
    {
        COREWEBVIEW2_CHANNEL_SEARCH_KIND_MOST_STABLE = 0,
        COREWEBVIEW2_CHANNEL_SEARCH_KIND_LEAST_STABLE = (COREWEBVIEW2_CHANNEL_SEARCH_KIND_MOST_STABLE + 1)
    }

    [ComImport]
    [Guid("7c7ecf51-e918-5caf-853c-e9a2bcc27775")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EnvironmentOptions8
    {
        [PreserveSig]
        HRESULT  get_ScrollBarStyle(out COREWEBVIEW2_SCROLLBAR_STYLE value);
        [PreserveSig]
        HRESULT put_ScrollBarStyle(COREWEBVIEW2_SCROLLBAR_STYLE value);
    }

    [ComImport]
    [Guid("12aae616-8ccb-44ec-bcb3-eb1831881635")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ControllerOptions
    {
        [PreserveSig]
        HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_ProfileName(string value);
        [PreserveSig]
        HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsInPrivateModeEnabled(bool value);
    }

    [ComImport]
    [Guid("06c991d8-9e7e-11ed-a8fc-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ControllerOptions2 : ICoreWebView2ControllerOptions
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_ProfileName(string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsInPrivateModeEnabled(bool value);

        [PreserveSig]
        HRESULT get_ScriptLocale([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_ScriptLocale(string value);
    }

    [ComImport]
    [Guid("b32b191a-8998-57ca-b7cb-e04617e4ce4a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ControllerOptions3 : ICoreWebView2ControllerOptions2
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_ProfileName(string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsInPrivateModeEnabled(bool value);

        [PreserveSig]
        new HRESULT get_ScriptLocale([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_ScriptLocale(string value);

        [PreserveSig]
        HRESULT get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR value);
        [PreserveSig]
        HRESULT put_DefaultBackgroundColor(COREWEBVIEW2_COLOR value);
    }

    [ComImport]
    [Guid("21eb052f-ad39-555e-824a-c87b091d4d36")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ControllerOptions4 : ICoreWebView2ControllerOptions3
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_ProfileName(string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsInPrivateModeEnabled(bool value);

        [PreserveSig]
        new HRESULT get_ScriptLocale([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_ScriptLocale(string value);

        [PreserveSig]
        new HRESULT get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR value);
        [PreserveSig]
        new HRESULT put_DefaultBackgroundColor(COREWEBVIEW2_COLOR value);

        [PreserveSig]
        HRESULT get_AllowHostInputProcessing(out bool value);
        [PreserveSig]
        HRESULT put_AllowHostInputProcessing(bool value);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COREWEBVIEW2_COLOR
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;
        public COREWEBVIEW2_COLOR(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
    }

    [ComImport]
    [Guid("02fab84b-1428-4fb7-ad45-1b2e64736184")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2CompositionController result);
    }

    [ComImport]
    [Guid("6c4819f3-c9b7-4260-8127-c9f5bde7f68c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CreateCoreWebView2ControllerCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2Controller result);
    }

    [ComImport]
    [Guid("4d00c0d1-9434-4eb6-8078-8697a560334f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Controller
    {
        [PreserveSig]
        HRESULT get_IsVisible(out bool isVisible);
        [PreserveSig]
        HRESULT put_IsVisible(bool isVisible);
        [PreserveSig]
        HRESULT get_Bounds(out RECT bounds);
        [PreserveSig]
        HRESULT put_Bounds(RECT bounds);
        [PreserveSig]
        HRESULT get_ZoomFactor(out double zoomFactor);
        [PreserveSig]
        HRESULT put_ZoomFactor(double zoomFactor);
        [PreserveSig]
        HRESULT add_ZoomFactorChanged(ICoreWebView2ZoomFactorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ZoomFactorChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT SetBoundsAndZoomFactor(RECT bounds, double zoomFactor);
        [PreserveSig]
        HRESULT MoveFocus(COREWEBVIEW2_MOVE_FOCUS_REASON reason);
        [PreserveSig]
        HRESULT add_MoveFocusRequested(ICoreWebView2MoveFocusRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_MoveFocusRequested(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_GotFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_GotFocus(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_LostFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_LostFocus(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_AcceleratorKeyPressed(ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_AcceleratorKeyPressed(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_ParentWindow(out IntPtr parentWindow);
        [PreserveSig]
        HRESULT put_ParentWindow(IntPtr parentWindow);
        [PreserveSig]
        HRESULT NotifyParentWindowPositionChanged();
        [PreserveSig]
        HRESULT Close();
        [PreserveSig]
        HRESULT get_CoreWebView2(out ICoreWebView2 coreWebView2);
    };

    [ComImport]
    [Guid("c979903e-d4ca-4228-92eb-47ee3fa96eab")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Controller2 : ICoreWebView2Controller
    {
        [PreserveSig]
        new HRESULT get_IsVisible(out bool isVisible);
        [PreserveSig]
        new HRESULT put_IsVisible(bool isVisible);
        [PreserveSig]
        new HRESULT get_Bounds(out RECT bounds);
        [PreserveSig]
        new HRESULT put_Bounds(RECT bounds);
        [PreserveSig]
        new HRESULT get_ZoomFactor(out double zoomFactor);
        [PreserveSig]
        new HRESULT put_ZoomFactor(double zoomFactor);
        [PreserveSig]
        new HRESULT add_ZoomFactorChanged(ICoreWebView2ZoomFactorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ZoomFactorChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT SetBoundsAndZoomFactor(RECT bounds, double zoomFactor);
        [PreserveSig]
        new HRESULT MoveFocus(COREWEBVIEW2_MOVE_FOCUS_REASON reason);
        [PreserveSig]
        new HRESULT add_MoveFocusRequested(ICoreWebView2MoveFocusRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_MoveFocusRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_GotFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_GotFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_LostFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LostFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_AcceleratorKeyPressed(ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_AcceleratorKeyPressed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ParentWindow(out IntPtr parentWindow);
        [PreserveSig]
        new HRESULT put_ParentWindow(IntPtr parentWindow);
        [PreserveSig]
        new HRESULT NotifyParentWindowPositionChanged();
        [PreserveSig]
        new HRESULT Close();
        [PreserveSig]
        new HRESULT get_CoreWebView2(out ICoreWebView2 coreWebView2);

        [PreserveSig]
        HRESULT get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR value);
        [PreserveSig]
        HRESULT put_DefaultBackgroundColor(COREWEBVIEW2_COLOR value);
    };

    [ComImport]
    [Guid("f9614724-5d2b-41dc-aef7-73d62b51543b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Controller3 : ICoreWebView2Controller2
    {
        [PreserveSig]
        new HRESULT get_IsVisible(out bool isVisible);
        [PreserveSig]
        new HRESULT put_IsVisible(bool isVisible);
        [PreserveSig]
        new HRESULT get_Bounds(out RECT bounds);
        [PreserveSig]
        new HRESULT put_Bounds(RECT bounds);
        [PreserveSig]
        new HRESULT get_ZoomFactor(out double zoomFactor);
        [PreserveSig]
        new HRESULT put_ZoomFactor(double zoomFactor);
        [PreserveSig]
        new HRESULT add_ZoomFactorChanged(ICoreWebView2ZoomFactorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ZoomFactorChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT SetBoundsAndZoomFactor(RECT bounds, double zoomFactor);
        [PreserveSig]
        new HRESULT MoveFocus(COREWEBVIEW2_MOVE_FOCUS_REASON reason);
        [PreserveSig]
        new HRESULT add_MoveFocusRequested(ICoreWebView2MoveFocusRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_MoveFocusRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_GotFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_GotFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_LostFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LostFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_AcceleratorKeyPressed(ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_AcceleratorKeyPressed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ParentWindow(out IntPtr parentWindow);
        [PreserveSig]
        new HRESULT put_ParentWindow(IntPtr parentWindow);
        [PreserveSig]
        new HRESULT NotifyParentWindowPositionChanged();
        [PreserveSig]
        new HRESULT Close();
        [PreserveSig]
        new HRESULT get_CoreWebView2(out ICoreWebView2 coreWebView2);

        [PreserveSig]
        new HRESULT get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR value);
        [PreserveSig]
        new HRESULT put_DefaultBackgroundColor(COREWEBVIEW2_COLOR value);

        [PreserveSig]
        HRESULT get_RasterizationScale(out double scale);
        [PreserveSig]
        HRESULT put_RasterizationScale(double scale);
        [PreserveSig]
        HRESULT get_ShouldDetectMonitorScaleChanges(out bool value);
        [PreserveSig]
        HRESULT put_ShouldDetectMonitorScaleChanges(bool value);
        [PreserveSig]
        HRESULT add_RasterizationScaleChanged(ICoreWebView2RasterizationScaleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_RasterizationScaleChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_BoundsMode(out COREWEBVIEW2_BOUNDS_MODE boundsMode);
        [PreserveSig]
        HRESULT put_BoundsMode(COREWEBVIEW2_BOUNDS_MODE boundsMode);
    };

    [ComImport]
    [Guid("97d418d5-a426-4e49-a151-e1a10f327d9e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Controller4 : ICoreWebView2Controller3
    {
        [PreserveSig]
        new HRESULT get_IsVisible(out bool isVisible);
        [PreserveSig]
        new HRESULT put_IsVisible(bool isVisible);
        [PreserveSig]
        new HRESULT get_Bounds(out RECT bounds);
        [PreserveSig]
        new HRESULT put_Bounds(RECT bounds);
        [PreserveSig]
        new HRESULT get_ZoomFactor(out double zoomFactor);
        [PreserveSig]
        new HRESULT put_ZoomFactor(double zoomFactor);
        [PreserveSig]
        new HRESULT add_ZoomFactorChanged(ICoreWebView2ZoomFactorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ZoomFactorChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT SetBoundsAndZoomFactor(RECT bounds, double zoomFactor);
        [PreserveSig]
        new HRESULT MoveFocus(COREWEBVIEW2_MOVE_FOCUS_REASON reason);
        [PreserveSig]
        new HRESULT add_MoveFocusRequested(ICoreWebView2MoveFocusRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_MoveFocusRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_GotFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_GotFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_LostFocus(ICoreWebView2FocusChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LostFocus(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_AcceleratorKeyPressed(ICoreWebView2AcceleratorKeyPressedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_AcceleratorKeyPressed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ParentWindow(out IntPtr parentWindow);
        [PreserveSig]
        new HRESULT put_ParentWindow(IntPtr parentWindow);
        [PreserveSig]
        new HRESULT NotifyParentWindowPositionChanged();
        [PreserveSig]
        new HRESULT Close();
        [PreserveSig]
        new HRESULT get_CoreWebView2(out ICoreWebView2 coreWebView2);

        [PreserveSig]
        new HRESULT get_DefaultBackgroundColor(out COREWEBVIEW2_COLOR value);
        [PreserveSig]
        new HRESULT put_DefaultBackgroundColor(COREWEBVIEW2_COLOR value);

        [PreserveSig]
        new HRESULT get_RasterizationScale(out double scale);
        [PreserveSig]
        new HRESULT put_RasterizationScale(double scale);
        [PreserveSig]
        new HRESULT get_ShouldDetectMonitorScaleChanges(out bool value);
        [PreserveSig]
        new HRESULT put_ShouldDetectMonitorScaleChanges(bool value);
        [PreserveSig]
        new HRESULT add_RasterizationScaleChanged(ICoreWebView2RasterizationScaleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_RasterizationScaleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_BoundsMode(out COREWEBVIEW2_BOUNDS_MODE boundsMode);
        [PreserveSig]
        new HRESULT put_BoundsMode(COREWEBVIEW2_BOUNDS_MODE boundsMode);

        [PreserveSig]
        HRESULT get_AllowExternalDrop(out bool value);
        [PreserveSig]
        HRESULT put_AllowExternalDrop(bool value);
    };

    [ComImport]
    [Guid("9c98c8b1-ac53-427e-a345-3049b5524bbe")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2RasterizationScaleChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Controller sender, IntPtr args);
    }

    public enum COREWEBVIEW2_BOUNDS_MODE
    {
        COREWEBVIEW2_BOUNDS_MODE_USE_RAW_PIXELS = 0,
        COREWEBVIEW2_BOUNDS_MODE_USE_RASTERIZATION_SCALE = (COREWEBVIEW2_BOUNDS_MODE_USE_RAW_PIXELS + 1)
    }

    [ComImport]
    [Guid("76eceacb-0462-4d94-ac83-423a6793775e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2
    {
        [PreserveSig]
        HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT Navigate(string uri);
        [PreserveSig]
        HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        HRESULT Reload();
        [PreserveSig]
        HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        HRESULT GoBack();
        [PreserveSig]
        HRESULT GoForward();
        [PreserveSig]
        HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        HRESULT Stop();
        [PreserveSig]
        HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        HRESULT OpenDevToolsWindow();
        [PreserveSig]
        HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_WindowCloseRequested(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("9E8F0CF8-E670-4B5E-B2BC-73E061E3184C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_2 : ICoreWebView2
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        HRESULT get_Environment(out ICoreWebView2Environment environment);
    };

    [ComImport]
    [Guid("A0D6DF20-3B92-416D-AA0C-437A9C727857")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_3 : ICoreWebView2_2
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        HRESULT Resume();
        [PreserveSig]
        HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        HRESULT ClearVirtualHostNameToFolderMapping(string hostName);
    };

    [ComImport]
    [Guid("20d02d59-6df2-42dc-bd06-f98a694b1302")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_4 : ICoreWebView2_3
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DownloadStarting(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("bedb11b8-d63c-11eb-b8bc-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_5 : ICoreWebView2_4
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("499aadac-d92c-4589-8a75-111bfc167795")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_6 : ICoreWebView2_5
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        HRESULT OpenTaskManagerWindow();
    };

    [ComImport]
    [Guid("79c24d83-09a3-45ae-9418-487f32a58740")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_7 : ICoreWebView2_6
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);
    };

    [ComImport]
    [Guid("E9632730-6E1E-43AB-B7B8-7B2C9E62E094")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_8 : ICoreWebView2_7
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        HRESULT put_IsMuted(bool value);
        [PreserveSig]
        HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_IsDocumentPlayingAudio(out bool value);
    };

    [ComImport]
    [Guid("4d7b2eab-9fdc-468d-b998-a9260b5ed651")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_9 : ICoreWebView2_8
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        HRESULT put_DefaultDownloadDialogMargin(POINT value);
    };

    [ComImport]
    [Guid("b1690564-6f5a-4983-8e48-31d1143fecdb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_10 : ICoreWebView2_9
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("0be78e56-c193-4051-b943-23b460c08bdb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_11 : ICoreWebView2_10
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ContextMenuRequested(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("35D69927-BCFA-4566-9349-6B3E0D154CAC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_12 : ICoreWebView2_11
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("f75f09a8-667e-4983-88d6-c8773f315e84")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_13 : ICoreWebView2_12
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT get_Profile(out ICoreWebView2Profile value);
    };

    [ComImport]
    [Guid("6daa4f10-4a90-4753-8898-77c5df534165")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_14 : ICoreWebView2_13
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);
    };

    [ComImport]
    [Guid("517B2D1D-7DAE-4A66-A4F4-10352FFB9518")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_15 : ICoreWebView2_14
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);
    };

    [ComImport]
    [Guid("0EB34DC9-9F91-41E1-8639-95CD5943906B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_16 : ICoreWebView2_15
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);
    };

    [ComImport]
    [Guid("702e75d4-fd44-434d-9d70-1a68a6b1192a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_17 : ICoreWebView2_16
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);
    };

    [ComImport]
    [Guid("7a626017-28be-49b2-b865-3ba2b3522d90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_18 : ICoreWebView2_17
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);    
    };

    [ComImport]
    [Guid("6921f954-79b0-437f-a997-c85811897c68")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_19 : ICoreWebView2_18
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        HRESULT  put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
    };

    [ComImport]
    [Guid("b4bc1926-7305-11ee-b962-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_20 : ICoreWebView2_19
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        HRESULT get_FrameId(out uint value);
    };

    [ComImport]
    [Guid("c4980dea-587b-43b9-8143-3ef3bf552d95")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_21 : ICoreWebView2_20
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);
    };

    [ComImport]
    [Guid("db75dfc7-a857-4632-a398-6969dde26c0a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_22 : ICoreWebView2_21
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
    };

    [ComImport]
    [Guid("508f0db5-90c4-5872-90a7-267a91377502")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_23 : ICoreWebView2_22
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);
    };

    [ComImport]
    [Guid("39a7ad55-4287-5cc1-88a1-c6f458593824")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_24 : ICoreWebView2_23
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        new HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);

        [PreserveSig]
        HRESULT add_NotificationReceived(ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NotificationReceived(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("b5a86092-df50-5b4f-a17b-6c8f8b40b771")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_25 : ICoreWebView2_24
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        new HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);

        [PreserveSig]
        new HRESULT add_NotificationReceived(ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NotificationReceived(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_SaveAsUIShowing(ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_SaveAsUIShowing(EventRegistrationToken token);
        [PreserveSig]
        HRESULT ShowSaveAsUI(ICoreWebView2ShowSaveAsUICompletedHandler handler);
    };

    [ComImport]
    [Guid("806268b8-f897-5685-88e5-c45fca0b1a48")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_26 : ICoreWebView2_25
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        new HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);

        [PreserveSig]
        new HRESULT add_NotificationReceived(ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NotificationReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_SaveAsUIShowing(ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SaveAsUIShowing(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ShowSaveAsUI(ICoreWebView2ShowSaveAsUICompletedHandler handler);

        [PreserveSig]
        HRESULT add_SaveFileSecurityCheckStarting(ICoreWebView2SaveFileSecurityCheckStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_SaveFileSecurityCheckStarting(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("00fbe33b-8c07-517c-aa23-0ddd4b5f6fa0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_27 : ICoreWebView2_26
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        new HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);

        [PreserveSig]
        new HRESULT add_NotificationReceived(ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NotificationReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_SaveAsUIShowing(ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SaveAsUIShowing(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ShowSaveAsUI(ICoreWebView2ShowSaveAsUICompletedHandler handler);

        [PreserveSig]
        new HRESULT add_SaveFileSecurityCheckStarting(ICoreWebView2SaveFileSecurityCheckStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SaveFileSecurityCheckStarting(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_ScreenCaptureStarting(ICoreWebView2ScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ScreenCaptureStarting(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("62e50381-5bf5-51a8-aae0-f20a3a9c8a90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2_28 : ICoreWebView2_27
    {
        [PreserveSig]
        new HRESULT get_Settings(out ICoreWebView2Settings settings);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT Navigate(string uri);
        [PreserveSig]
        new HRESULT NavigateToString(string htmlContent);
        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2ContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_SourceChanged(ICoreWebView2SourceChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SourceChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_HistoryChanged(ICoreWebView2HistoryChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_HistoryChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationStarting(ICoreWebView2NavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_FrameNavigationCompleted(ICoreWebView2NavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameNavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ScriptDialogOpening(ICoreWebView2ScriptDialogOpeningEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScriptDialogOpening(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2PermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ProcessFailed(ICoreWebView2ProcessFailedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ProcessFailed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddScriptToExecuteOnDocumentCreated(string javaScript, ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler handler);
        [PreserveSig]
        new HRESULT RemoveScriptToExecuteOnDocumentCreated(string id);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT CapturePreview(COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT imageFormat, IStream imageStream, ICoreWebView2CapturePreviewCompletedHandler handler);
        [PreserveSig]
        new HRESULT Reload();
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2WebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethod(string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT get_BrowserProcessId(out uint value);
        [PreserveSig]
        new HRESULT get_CanGoBack(out bool canGoBack);
        [PreserveSig]
        new HRESULT get_CanGoForward(out bool canGoForward);
        [PreserveSig]
        new HRESULT GoBack();
        [PreserveSig]
        new HRESULT GoForward();
        [PreserveSig]
        new HRESULT GetDevToolsProtocolEventReceiver(string eventName, out ICoreWebView2DevToolsProtocolEventReceiver receiver);
        [PreserveSig]
        new HRESULT Stop();
        [PreserveSig]
        new HRESULT add_NewWindowRequested(ICoreWebView2NewWindowRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NewWindowRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DocumentTitleChanged(ICoreWebView2DocumentTitleChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DocumentTitleChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_DocumentTitle([MarshalAs(UnmanagedType.LPWStr)] out string title);
        [PreserveSig]
        new HRESULT AddHostObjectToScript(string name, IntPtr obj);
        //HRESULT AddHostObjectToScript(string name, VARIANT object);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT OpenDevToolsWindow();
        [PreserveSig]
        new HRESULT add_ContainsFullScreenElementChanged(ICoreWebView2ContainsFullScreenElementChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContainsFullScreenElementChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_ContainsFullScreenElement(out bool containsFullScreenElement);
        [PreserveSig]
        new HRESULT add_WebResourceRequested(ICoreWebView2WebResourceRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceRequested(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilter(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT resourceContext);
        [PreserveSig]
        new HRESULT add_WindowCloseRequested(ICoreWebView2WindowCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WindowCloseRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_WebResourceResponseReceived(ICoreWebView2WebResourceResponseReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebResourceResponseReceived(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT NavigateWithWebResourceRequest(ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2DOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager cookieManager);
        [PreserveSig]
        new HRESULT get_Environment(out ICoreWebView2Environment environment);

        [PreserveSig]
        new HRESULT TrySuspend(ICoreWebView2TrySuspendCompletedHandler handler);
        [PreserveSig]
        new HRESULT Resume();
        [PreserveSig]
        new HRESULT get_IsSuspended(out bool isSuspended);
        [PreserveSig]
        new HRESULT SetVirtualHostNameToFolderMapping(string hostName, string folderPath, COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND accessKind);
        [PreserveSig]
        new HRESULT ClearVirtualHostNameToFolderMapping(string hostName);

        [PreserveSig]
        new HRESULT add_FrameCreated(ICoreWebView2FrameCreatedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FrameCreated(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DownloadStarting(ICoreWebView2DownloadStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DownloadStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ClientCertificateRequested(ICoreWebView2ClientCertificateRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ClientCertificateRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT OpenTaskManagerWindow();

        [PreserveSig]
        new HRESULT PrintToPdf([MarshalAs(UnmanagedType.LPWStr)] string ResultFilePath, ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_IsMutedChanged(ICoreWebView2IsMutedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsMutedChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsMuted(out bool value);
        [PreserveSig]
        new HRESULT put_IsMuted(bool value);
        [PreserveSig]
        new HRESULT add_IsDocumentPlayingAudioChanged(ICoreWebView2IsDocumentPlayingAudioChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDocumentPlayingAudioChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDocumentPlayingAudio(out bool value);

        [PreserveSig]
        new HRESULT add_IsDefaultDownloadDialogOpenChanged(ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_IsDefaultDownloadDialogOpenChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_IsDefaultDownloadDialogOpen(out bool value);
        [PreserveSig]
        new HRESULT OpenDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT CloseDefaultDownloadDialog();
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogCornerAlignment(out COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogCornerAlignment(COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadDialogMargin(out POINT value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadDialogMargin(POINT value);

        [PreserveSig]
        new HRESULT add_BasicAuthenticationRequested(ICoreWebView2BasicAuthenticationRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_BasicAuthenticationRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT CallDevToolsProtocolMethodForSession(string sessionId, string methodName, string parametersAsJson, ICoreWebView2CallDevToolsProtocolMethodCompletedHandler handler);
        [PreserveSig]
        new HRESULT add_ContextMenuRequested(ICoreWebView2ContextMenuRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContextMenuRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_StatusBarTextChanged(ICoreWebView2StatusBarTextChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_StatusBarTextChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_StatusBarText([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        new HRESULT get_Profile(out ICoreWebView2Profile value);

        [PreserveSig]
        new HRESULT add_ServerCertificateErrorDetected(ICoreWebView2ServerCertificateErrorDetectedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ServerCertificateErrorDetected(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ClearServerCertificateErrorActions(ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler handler);

        [PreserveSig]
        new HRESULT add_FaviconChanged(ICoreWebView2FaviconChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_FaviconChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT get_FaviconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT GetFavicon(COREWEBVIEW2_FAVICON_IMAGE_FORMAT format, ICoreWebView2GetFaviconCompletedHandler completedHandler);

        [PreserveSig]
        new HRESULT Print(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintCompletedHandler handler);
        [PreserveSig]
        new HRESULT ShowPrintUI(COREWEBVIEW2_PRINT_DIALOG_KIND printDialogKind);
        [PreserveSig]
        new HRESULT PrintToPdfStream(ICoreWebView2PrintSettings printSettings, ICoreWebView2PrintToPdfStreamCompletedHandler handler);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT add_LaunchingExternalUriScheme(ICoreWebView2LaunchingExternalUriSchemeEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_LaunchingExternalUriScheme(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_MemoryUsageTargetLevel(out COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);
        [PreserveSig]
        new HRESULT put_MemoryUsageTargetLevel(COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL value);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        new HRESULT ExecuteScriptWithResult(string javaScript, ICoreWebView2ExecuteScriptWithResultCompletedHandler handler);

        [PreserveSig]
        new HRESULT AddWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);
        [PreserveSig]
        new HRESULT RemoveWebResourceRequestedFilterWithRequestSourceKinds(string uri, COREWEBVIEW2_WEB_RESOURCE_CONTEXT ResourceContext,
            COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS requestSourceKinds);

        [PreserveSig]
        new HRESULT PostWebMessageAsJsonWithAdditionalObjects(string webMessageAsJson, ICoreWebView2ObjectCollectionView additionalObjects);

        [PreserveSig]
        new HRESULT add_NotificationReceived(ICoreWebView2NotificationReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NotificationReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_SaveAsUIShowing(ICoreWebView2SaveAsUIShowingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SaveAsUIShowing(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ShowSaveAsUI(ICoreWebView2ShowSaveAsUICompletedHandler handler);

        [PreserveSig]
        new HRESULT add_SaveFileSecurityCheckStarting(ICoreWebView2SaveFileSecurityCheckStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_SaveFileSecurityCheckStarting(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_ScreenCaptureStarting(ICoreWebView2ScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ScreenCaptureStarting(EventRegistrationToken token);

        [PreserveSig]
        HRESULT get_Find(out ICoreWebView2Find value);
    };

    [ComImport]
    [Guid("a3ec0f5f-ddbc-54ed-8546-af75a785b9a6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Find
    {
        [PreserveSig]
        HRESULT get_ActiveMatchIndex(out int value);
        [PreserveSig]
        HRESULT get_MatchCount(out int value);
        [PreserveSig]
        HRESULT add_ActiveMatchIndexChanged(ICoreWebView2FindActiveMatchIndexChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ActiveMatchIndexChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_MatchCountChanged(ICoreWebView2FindMatchCountChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_MatchCountChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT Start(ICoreWebView2FindOptions options, ICoreWebView2FindStartCompletedHandler handler);
        [PreserveSig]
        HRESULT FindNext();
        [PreserveSig]
        HRESULT FindPrevious();
        [PreserveSig]
        HRESULT Stop();
    };

    [ComImport]
    [Guid("6a90ecaf-44b0-5bd9-8f07-1967e17be9fb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FindStartCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    [ComImport]
    [Guid("e82e3b2b-a4af-5bc6-94c6-18b44157a16c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FindOptions
    {
        [PreserveSig]
        HRESULT get_FindTerm([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_FindTerm(string value);
        [PreserveSig]
        HRESULT get_IsCaseSensitive(out bool value);
        [PreserveSig]
        HRESULT put_IsCaseSensitive(bool value);
        [PreserveSig]
        HRESULT get_ShouldHighlightAllMatches(out bool value);
        [PreserveSig]
        HRESULT put_ShouldHighlightAllMatches(bool value);
        [PreserveSig]
        HRESULT get_ShouldMatchWord(out bool value);
        [PreserveSig]
        HRESULT put_ShouldMatchWord(bool value);
        [PreserveSig]
        HRESULT get_SuppressDefaultFindDialog(out bool value);
        [PreserveSig]
        HRESULT put_SuppressDefaultFindDialog(bool value);
    };

    [ComImport]
    [Guid("da0d6827-4254-5b10-a6d9-412076afc9f3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FindMatchCountChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Find sender, IntPtr args);
    };

    [ComImport]
    [Guid("0054f514-9a8e-5876-aed5-30b37f8c86a5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FindActiveMatchIndexChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Find sender, IntPtr args);
    };

    [ComImport]
    [Guid("e24ff05a-1db5-59d9-89f3-3c864268db4a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ScreenCaptureStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ScreenCaptureStartingEventArgs args);
    };

    [ComImport]
    [Guid("892c03fd-aee3-5eba-a1fa-6fd2f6484b2b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ScreenCaptureStartingEventArgs
    {
        [PreserveSig]
        HRESULT get_Cancel(out bool value);
        [PreserveSig]
        HRESULT put_Cancel(bool value);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
        [PreserveSig]
        HRESULT get_OriginalSourceFrameInfo(out ICoreWebView2FrameInfo value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral value);
    };

    [ComImport]
    [Guid("7899576c-19e3-57c8-b7d1-55808292de57")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SaveFileSecurityCheckStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2SaveFileSecurityCheckStartingEventArgs args);
    };

    [ComImport]
    [Guid("cf4ff1d1-5a67-5660-8d63-ef699881ea65")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SaveFileSecurityCheckStartingEventArgs
    {
        [PreserveSig]
        HRESULT get_CancelSave(out bool value);
        [PreserveSig]
        HRESULT put_CancelSave(bool value);
        [PreserveSig]
        HRESULT get_DocumentOriginUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_FileExtension([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_FilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_SuppressDefaultPolicy(out bool value);
        [PreserveSig]
        HRESULT put_SuppressDefaultPolicy(bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral value);
    };

    [ComImport]
    [Guid("e24b07e3-8169-5c34-994a-7f6478946a3c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ShowSaveAsUICompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, COREWEBVIEW2_SAVE_AS_UI_RESULT result);
    };

    [ComImport]
    [Guid("6baa177e-3a2e-5ccf-9a13-fad676cd0522")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SaveAsUIShowingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2SaveAsUIShowingEventArgs args);
    };

    [ComImport]
    [Guid("55902952-0e0d-5aaa-a7d0-e833cdb34f62")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SaveAsUIShowingEventArgs
    {
        [PreserveSig]
        HRESULT get_ContentMimeType([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_Cancel(bool value);
        [PreserveSig]
        HRESULT get_Cancel(out bool value);
        [PreserveSig]
        HRESULT put_SuppressDefaultDialog(bool value);
        [PreserveSig]
        HRESULT get_SuppressDefaultDialog(out bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral value);
        [PreserveSig]
        HRESULT put_SaveAsFilePath(string value);
        [PreserveSig]
        HRESULT get_SaveAsFilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_AllowReplace(bool value);
        [PreserveSig]
        HRESULT get_AllowReplace(out bool value);
        [PreserveSig]
        HRESULT put_Kind(COREWEBVIEW2_SAVE_AS_KIND value);
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_SAVE_AS_KIND value);
    };

    [ComImport]
    [Guid("89c5d598-8788-423b-be97-e6e01c0f9ee3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NotificationReceivedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2NotificationReceivedEventArgs args);
    };

    [ComImport]
    [Guid("1512DD5B-5514-4F85-886E-21C3A4C9CFE6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NotificationReceivedEventArgs
    {
        [PreserveSig]
        HRESULT get_SenderOrigin([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Notification(out ICoreWebView2Notification value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("B7434D98-6BC8-419D-9DA5-FB5A96D4DACD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Notification
    {
        [PreserveSig]
        HRESULT add_CloseRequested(ICoreWebView2NotificationCloseRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_CloseRequested(EventRegistrationToken token);
        [PreserveSig]
        HRESULT ReportShown();
        [PreserveSig]
        HRESULT ReportClicked();
        [PreserveSig]
        HRESULT ReportClosed();
        [PreserveSig]
        HRESULT get_Body([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Direction(out COREWEBVIEW2_TEXT_DIRECTION_KIND value);
        [PreserveSig]
        HRESULT get_Language([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Tag([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_IconUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Title([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_BadgeUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_BodyImageUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_ShouldRenotify(out bool value);
        [PreserveSig]
        HRESULT get_RequiresInteraction(out bool value);
        [PreserveSig]
        HRESULT get_IsSilent(out bool value);
        [PreserveSig]
        HRESULT get_Timestamp(out double value);
        [PreserveSig]
        HRESULT GetVibrationPattern(out uint count, out UInt64 vibrationPattern);
    };

    [ComImport]
    [Guid("47c32d23-1e94-4733-85f1-d9bf4acd0974")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NotificationCloseRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Notification sender, IntPtr args);
    };        

    [ComImport]
    [Guid("1bb5317b-8238-4c67-a7ff-baf6558f289d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ExecuteScriptWithResultCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2ExecuteScriptResult result);
    };

    [ComImport]
    [Guid("0CE15963-3698-4DF7-9399-71ED6CDD8C9F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ExecuteScriptResult
    {
        [PreserveSig]
        HRESULT get_Succeeded(out bool value);
        [PreserveSig]
        HRESULT get_ResultAsJson([MarshalAs(UnmanagedType.LPWStr)] out string jsonResult);
        [PreserveSig]
        HRESULT TryGetResultAsString([MarshalAs(UnmanagedType.LPWStr)] out string stringResult, out bool value);
        [PreserveSig]
        HRESULT get_Exception(out ICoreWebView2ScriptException exception);
    };

    [ComImport]
    [Guid("054DAE00-84A3-49FF-BC17-4012A90BC9FD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ScriptException
    {
        [PreserveSig]
        HRESULT get_LineNumber(out uint value);
        [PreserveSig]
        HRESULT get_ColumnNumber(out uint value);
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Message([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_ToJson([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("74f712e0-8165-43a9-a13f-0cce597e75df")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2LaunchingExternalUriSchemeEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2LaunchingExternalUriSchemeEventArgs args);
    };

    [ComImport]
    [Guid("07D1A6C3-7175-4BA1-9306-E593CA07E46C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2LaunchingExternalUriSchemeEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_InitiatingOrigin([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_IsUserInitiated(out bool value);
        [PreserveSig]
        HRESULT get_Cancel(out bool value);
        [PreserveSig]
        HRESULT put_Cancel(bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral value);
    };

    [ComImport]
    [Guid("B747A495-0C6F-449E-97B8-2F81E9D6AB43")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SharedBuffer
    {
        [PreserveSig]
        HRESULT get_Size(out UInt64 value);
        [PreserveSig]
        HRESULT get_Buffer(out IntPtr value);
        [PreserveSig]
        HRESULT OpenStream(out IStream value);
        [PreserveSig]
        HRESULT get_FileMappingHandle(out IntPtr value);
        [PreserveSig]
        HRESULT  Close();
    };

    [ComImport]
    [Guid("4c9f8229-8f93-444f-a711-2c0dfd6359d5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PrintToPdfStreamCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, IStream result);
    };

    [ComImport]
    [Guid("8fd80075-ed08-42db-8570-f5d14977461e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PrintCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, COREWEBVIEW2_PRINT_STATUS result);
    };

    [ComImport]
    [Guid("a2508329-7da8-49d7-8c05-fa125e4aee8d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2GetFaviconCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, IStream result);
    };

    [ComImport]
    [Guid("2913da94-833d-4de0-8dca-900fc524a1a4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FaviconChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("3b40aac6-acfe-4ffd-8211-f607b96e2d5b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClearServerCertificateErrorActionsCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    [ComImport]
    [Guid("969b3a26-d85e-4795-8199-fef57344da22")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ServerCertificateErrorDetectedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ServerCertificateErrorDetectedEventArgs args);
    };

    [ComImport]
    [Guid("012193ED-7C13-48FF-969D-A84C1F432A14")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ServerCertificateErrorDetectedEventArgs
    {
        [PreserveSig]
        HRESULT get_ErrorStatus(out COREWEBVIEW2_WEB_ERROR_STATUS value);
        [PreserveSig]
        HRESULT get_RequestUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_ServerCertificate(out ICoreWebView2Certificate value);
        [PreserveSig]
        HRESULT get_Action(out COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION value);
        [PreserveSig]
        HRESULT put_Action(COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("C5FB2FCE-1CAC-4AEE-9C79-5ED0362EAAE0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Certificate
    {
        [PreserveSig]
        HRESULT get_Subject([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Issuer([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_ValidFrom(out double value);
        [PreserveSig]
        HRESULT get_ValidTo(out double value);
        [PreserveSig]
        HRESULT get_DerEncodedSerialNumber([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_DisplayName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT ToPemEncoding([MarshalAs(UnmanagedType.LPWStr)] out string pemEncodedData);
        [PreserveSig]
        HRESULT get_PemEncodedIssuerCertificateChain(out ICoreWebView2StringCollection value);
    };

    [ComImport]
    [Guid("79110ad3-cd5d-4373-8bc3-c60658f17a5f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile
    {
        [PreserveSig]
        HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
    };

    [ComImport]
    [Guid("fa740d4b-5eae-4344-a8ad-74be31925397")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile2 : ICoreWebView2Profile
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);
    };

    [ComImport]
    [Guid("b188e659-5685-4e05-bdba-fc640e0f1992")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile3 : ICoreWebView2Profile2
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
    };

    [ComImport]
    [Guid("8f4ae680-192e-4ec8-833a-21cfadaef628")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile4 : ICoreWebView2Profile3
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        new HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);

        [PreserveSig]
        HRESULT SetPermissionState(COREWEBVIEW2_PERMISSION_KIND PermissionKind, string origin,
            COREWEBVIEW2_PERMISSION_STATE State, ICoreWebView2SetPermissionStateCompletedHandler handler);
        [PreserveSig]
        HRESULT GetNonDefaultPermissionSettings(ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler);
    };

    [ComImport]
    [Guid("2ee5b76e-6e80-4df2-bcd3-d4ec3340a01b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile5 : ICoreWebView2Profile4
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        new HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);

        [PreserveSig]
        new HRESULT SetPermissionState(COREWEBVIEW2_PERMISSION_KIND PermissionKind, string origin,
            COREWEBVIEW2_PERMISSION_STATE State, ICoreWebView2SetPermissionStateCompletedHandler handler);
        [PreserveSig]
        new HRESULT GetNonDefaultPermissionSettings(ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler);

        [PreserveSig]
        HRESULT get_CookieManager(out ICoreWebView2CookieManager value);
    };

    [ComImport]
    [Guid("BD82FA6A-1D65-4C33-B2B4-0393020CC61B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile6 : ICoreWebView2Profile5
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        new HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);

        [PreserveSig]
        new HRESULT SetPermissionState(COREWEBVIEW2_PERMISSION_KIND PermissionKind, string origin,
            COREWEBVIEW2_PERMISSION_STATE State, ICoreWebView2SetPermissionStateCompletedHandler handler);
        [PreserveSig]
        new HRESULT GetNonDefaultPermissionSettings(ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager value);

        [PreserveSig]
        HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsGeneralAutofillEnabled(bool value);
    };

    [ComImport]
    [Guid("7b4c7906-a1aa-4cb4-b723-db09f813d541")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile7 : ICoreWebView2Profile6
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        new HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);

        [PreserveSig]
        new HRESULT SetPermissionState(COREWEBVIEW2_PERMISSION_KIND PermissionKind, string origin,
            COREWEBVIEW2_PERMISSION_STATE State, ICoreWebView2SetPermissionStateCompletedHandler handler);
        [PreserveSig]
        new HRESULT GetNonDefaultPermissionSettings(ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        HRESULT AddBrowserExtension(string extensionFolderPath, ICoreWebView2ProfileAddBrowserExtensionCompletedHandler handler);
        [PreserveSig]
        HRESULT GetBrowserExtensions(ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler handler);
    };

    [ComImport]
    [Guid("fbf70c2f-eb1f-4383-85a0-163e92044011")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Profile8 : ICoreWebView2Profile7
    {
        [PreserveSig]
        new HRESULT get_ProfileName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_IsInPrivateModeEnabled(out bool value);
        [PreserveSig]
        new HRESULT get_ProfilePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_DefaultDownloadFolderPath([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_DefaultDownloadFolderPath(string value);
        [PreserveSig]
        new HRESULT get_PreferredColorScheme(out COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);
        [PreserveSig]
        new HRESULT put_PreferredColorScheme(COREWEBVIEW2_PREFERRED_COLOR_SCHEME value);

        [PreserveSig]
        new HRESULT ClearBrowsingData(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataInTimeRange(COREWEBVIEW2_BROWSING_DATA_KINDS dataKinds, double startTime, double endTime,
            ICoreWebView2ClearBrowsingDataCompletedHandler handler);
        [PreserveSig]
        new HRESULT ClearBrowsingDataAll(ICoreWebView2ClearBrowsingDataCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_PreferredTrackingPreventionLevel(out COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);
        [PreserveSig]
        new HRESULT put_PreferredTrackingPreventionLevel(COREWEBVIEW2_TRACKING_PREVENTION_LEVEL value);

        [PreserveSig]
        new HRESULT SetPermissionState(COREWEBVIEW2_PERMISSION_KIND PermissionKind, string origin,
            COREWEBVIEW2_PERMISSION_STATE State, ICoreWebView2SetPermissionStateCompletedHandler handler);
        [PreserveSig]
        new HRESULT GetNonDefaultPermissionSettings(ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler handler);

        [PreserveSig]
        new HRESULT get_CookieManager(out ICoreWebView2CookieManager value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        new HRESULT AddBrowserExtension(string extensionFolderPath, ICoreWebView2ProfileAddBrowserExtensionCompletedHandler handler);
        [PreserveSig]
        new HRESULT GetBrowserExtensions(ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler handler);

        [PreserveSig]
        HRESULT Delete();
        [PreserveSig]
        HRESULT add_Deleted(ICoreWebView2ProfileDeletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_Deleted(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("df35055d-772e-4dbe-b743-5fbf74a2b258")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProfileDeletedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Profile sender, IntPtr args);
    };

    [ComImport]
    [Guid("fce16a1c-f107-4601-8b75-fc4940ae25d0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProfileGetBrowserExtensionsCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2BrowserExtensionList result);
    };

    [ComImport]
    [Guid("2ef3d2dc-bd5f-4f4d-90af-fd67798f0c2f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserExtensionList
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2BrowserExtension value);
    };

    [ComImport]
    [Guid("df1aab27-82b9-4ab6-aae8-017a49398c14")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProfileAddBrowserExtensionCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2BrowserExtension result);
    };

    [ComImport]
    [Guid("7EF7FFA0-FAC5-462C-B189-3D9EDBE575DA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserExtension
    {
        [PreserveSig]
        HRESULT get_Id([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT Remove(ICoreWebView2BrowserExtensionRemoveCompletedHandler handler);
        [PreserveSig]
        HRESULT get_IsEnabled(out bool value);
        [PreserveSig]
        HRESULT Enable(bool isEnabled, ICoreWebView2BrowserExtensionEnableCompletedHandler handler);
    };

    [ComImport]
    [Guid("30c186ce-7fad-421f-a3bc-a8eaf071ddb8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserExtensionEnableCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    [ComImport]
    [Guid("8e41909a-9b18-4bb1-8cdf-930f467a50be")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BrowserExtensionRemoveCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    [ComImport]
    [Guid("38274481-a15c-4563-94cf-990edc9aeb95")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2GetNonDefaultPermissionSettingsCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2PermissionSettingCollectionView result);
    };

    [ComImport]
    [Guid("f5596f62-3de5-47b1-91e8-a4104b596b96")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionSettingCollectionView
    {
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2PermissionSetting permissionSetting);
        [PreserveSig]
        HRESULT  get_Count(out uint value);
    };

    [ComImport]
    [Guid("792b6eca-5576-421c-9119-74ebb3a4ffb3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionSetting
    {
        [PreserveSig]
        HRESULT  get_PermissionKind(out COREWEBVIEW2_PERMISSION_KIND value);
        [PreserveSig]
        HRESULT get_PermissionOrigin([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_PermissionState(out COREWEBVIEW2_PERMISSION_STATE value);
    };

    [ComImport]
    [Guid("fc77fb30-9c9e-4076-b8c7-7644a703ca1b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SetPermissionStateCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    public enum COREWEBVIEW2_BROWSING_DATA_KINDS
    {
        COREWEBVIEW2_BROWSING_DATA_KINDS_FILE_SYSTEMS = 0x1,
        COREWEBVIEW2_BROWSING_DATA_KINDS_INDEXED_DB = 0x2,
        COREWEBVIEW2_BROWSING_DATA_KINDS_LOCAL_STORAGE = 0x4,
        COREWEBVIEW2_BROWSING_DATA_KINDS_WEB_SQL = 0x8,
        COREWEBVIEW2_BROWSING_DATA_KINDS_CACHE_STORAGE = 0x10,
        COREWEBVIEW2_BROWSING_DATA_KINDS_ALL_DOM_STORAGE = 0x20,
        COREWEBVIEW2_BROWSING_DATA_KINDS_COOKIES = 0x40,
        COREWEBVIEW2_BROWSING_DATA_KINDS_ALL_SITE = 0x80,
        COREWEBVIEW2_BROWSING_DATA_KINDS_DISK_CACHE = 0x100,
        COREWEBVIEW2_BROWSING_DATA_KINDS_DOWNLOAD_HISTORY = 0x200,
        COREWEBVIEW2_BROWSING_DATA_KINDS_GENERAL_AUTOFILL = 0x400,
        COREWEBVIEW2_BROWSING_DATA_KINDS_PASSWORD_AUTOSAVE = 0x800,
        COREWEBVIEW2_BROWSING_DATA_KINDS_BROWSING_HISTORY = 0x1000,
        COREWEBVIEW2_BROWSING_DATA_KINDS_SETTINGS = 0x2000,
        COREWEBVIEW2_BROWSING_DATA_KINDS_ALL_PROFILE = 0x4000,
        COREWEBVIEW2_BROWSING_DATA_KINDS_SERVICE_WORKERS = 0x8000
    }

    [ComImport]
    [Guid("e9710a06-1d1d-49b2-8234-226f35846ae5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClearBrowsingDataCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    [ComImport]
    [Guid("a5e3b0d0-10df-4156-bfad-3b43867acac6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2StatusBarTextChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("04d3fe1d-ab87-42fb-a898-da241d35b63c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContextMenuRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ContextMenuRequestedEventArgs args);
    };

    [ComImport]
    [Guid("a1d309ee-c03f-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContextMenuRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_MenuItems(out ICoreWebView2ContextMenuItemCollection value);
        [PreserveSig]
        HRESULT get_ContextMenuTarget(out ICoreWebView2ContextMenuTarget value);
        [PreserveSig]
        HRESULT get_Location(out POINT value);
        [PreserveSig]
        HRESULT put_SelectedCommandId(int value);
        [PreserveSig]
        HRESULT get_SelectedCommandId(out int value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("b8611d99-eed6-4f3f-902c-a198502ad472")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContextMenuTarget
    {
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND value);
        [PreserveSig]
        HRESULT get_IsEditable(out bool value);
        [PreserveSig]
        HRESULT get_IsRequestedForMainFrame(out bool value);
        [PreserveSig]
        HRESULT get_PageUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_FrameUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_HasLinkUri(out bool value);
        [PreserveSig]
        HRESULT get_LinkUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_HasLinkText(out bool value);
        [PreserveSig]
        HRESULT get_LinkText([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_HasSourceUri(out bool value);
        [PreserveSig]
        HRESULT get_SourceUri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_HasSelection(out bool value);
        [PreserveSig]
        HRESULT get_SelectionText([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    public enum COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND
    {
        COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_PAGE = 0,
        COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_IMAGE = (COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_PAGE + 1),
        COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_SELECTED_TEXT = (COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_IMAGE + 1),
        COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_AUDIO = (COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_SELECTED_TEXT + 1),
        COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_VIDEO = (COREWEBVIEW2_CONTEXT_MENU_TARGET_KIND_AUDIO + 1)
    }

    [ComImport]
    [Guid("58b4d6c2-18d4-497e-b39b-9a96533fa278")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BasicAuthenticationRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2BasicAuthenticationRequestedEventArgs args);
    };

    [ComImport]
    [Guid("ef05516f-d897-4f9e-b672-d8e2307a3fb0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BasicAuthenticationRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Challenge([MarshalAs(UnmanagedType.LPWStr)] out string challenge);
        [PreserveSig]
        HRESULT get_Response(out ICoreWebView2BasicAuthenticationResponse response);
        [PreserveSig]
        HRESULT get_Cancel(out bool cancel);
        [PreserveSig]
        HRESULT put_Cancel(bool cancel);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("07023f7d-2d77-4d67-9040-6e7d428c6a40")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BasicAuthenticationResponse
    {
        [PreserveSig]
        HRESULT get_UserName([MarshalAs(UnmanagedType.LPWStr)] out string userName);
        [PreserveSig]
        HRESULT put_UserName(string userName);
        [PreserveSig]
        HRESULT get_Password([MarshalAs(UnmanagedType.LPWStr)] out string password);
        [PreserveSig]
        HRESULT put_Password(string password);
    };

    [ComImport]
    [Guid("3117da26-ae13-438d-bd46-edbeb2c4ce81")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2IsDefaultDownloadDialogOpenChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("5def109a-2f4b-49fa-b7f6-11c39e513328")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2IsDocumentPlayingAudioChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("57d90347-cd0e-4952-a4a2-7483a2756f08")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2IsMutedChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("ccf1ef04-fd8e-4d5f-b2de-0983e41b8c36")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PrintToPdfCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, bool result);
    };

    [ComImport]
    [Guid("d7175ba2-bcc3-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClientCertificateRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ClientCertificateRequestedEventArgs args);
    };

    [ComImport]
    [Guid("bc59db28-bcc3-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClientCertificateRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Host([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Port(out int value);
        [PreserveSig]
        HRESULT get_IsProxy(out bool value);
        [PreserveSig]
        HRESULT get_AllowedCertificateAuthorities(out ICoreWebView2StringCollection value);
        [PreserveSig]
        HRESULT get_MutuallyTrustedCertificates(out ICoreWebView2ClientCertificateCollection value);
        [PreserveSig]
        HRESULT get_SelectedCertificate(out ICoreWebView2ClientCertificate value);
        [PreserveSig]
        HRESULT put_SelectedCertificate(ICoreWebView2ClientCertificate value);
        [PreserveSig]
        HRESULT get_Cancel(out bool value);
        [PreserveSig]
        HRESULT put_Cancel(bool value);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("ef5674d2-bcc3-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClientCertificateCollection
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2ClientCertificate value);
    };

    [ComImport]
    [Guid("e7188076-bcc3-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ClientCertificate
    {
        [PreserveSig]
        HRESULT get_Subject([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Issuer([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_ValidFrom(out double value);
        [PreserveSig]
        HRESULT get_ValidTo(out double value);
        [PreserveSig]
        HRESULT get_DerEncodedSerialNumber([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_DisplayName([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT ToPemEncoding([MarshalAs(UnmanagedType.LPWStr)] out string pemEncodedData);
        [PreserveSig]
        HRESULT get_PemEncodedIssuerCertificateChain(out ICoreWebView2StringCollection value);
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_CLIENT_CERTIFICATE_KIND value);
    };

    public enum COREWEBVIEW2_CLIENT_CERTIFICATE_KIND
    {
        COREWEBVIEW2_CLIENT_CERTIFICATE_KIND_SMART_CARD = 0,
        COREWEBVIEW2_CLIENT_CERTIFICATE_KIND_PIN = (COREWEBVIEW2_CLIENT_CERTIFICATE_KIND_SMART_CARD + 1),
        COREWEBVIEW2_CLIENT_CERTIFICATE_KIND_OTHER = (COREWEBVIEW2_CLIENT_CERTIFICATE_KIND_PIN + 1)
    }

    [ComImport]
    [Guid("f41f3f8a-bcc3-11eb-8529-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2StringCollection
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, [MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("efedc989-c396-41ca-83f7-07f845a55724")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DownloadStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2DownloadStartingEventArgs args);
    };

    [ComImport]
    [Guid("e99bbe21-43e9-4544-a732-282764eafa60")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DownloadStartingEventArgs
    {
        [PreserveSig]
        HRESULT get_DownloadOperation(out ICoreWebView2DownloadOperation downloadOperation);
        [PreserveSig]
        HRESULT get_Cancel(out bool cancel);
        [PreserveSig]
        HRESULT put_Cancel(bool cancel);
        [PreserveSig]
        HRESULT get_ResultFilePath([MarshalAs(UnmanagedType.LPWStr)] out string resultFilePath);
        [PreserveSig]
        HRESULT put_ResultFilePath([MarshalAs(UnmanagedType.LPWStr)] string resultFilePath);
        [PreserveSig]
        HRESULT get_Handled(out bool handled);
        [PreserveSig]
        HRESULT put_Handled(bool handled);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("3d6b6cf2-afe1-44c7-a995-c65117714336")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DownloadOperation
    {
        [PreserveSig]
        HRESULT add_BytesReceivedChanged(ICoreWebView2BytesReceivedChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_BytesReceivedChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_EstimatedEndTimeChanged(ICoreWebView2EstimatedEndTimeChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_EstimatedEndTimeChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_StateChanged(ICoreWebView2StateChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_StateChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT get_ContentDisposition([MarshalAs(UnmanagedType.LPWStr)] out string contentDisposition);
        [PreserveSig]
        HRESULT get_MimeType([MarshalAs(UnmanagedType.LPWStr)] out string mimeType);
        [PreserveSig]
        HRESULT get_TotalBytesToReceive(out Int64 totalBytesToReceive);
        [PreserveSig]
        HRESULT get_BytesReceived(out Int64 bytesReceived);
        [PreserveSig]
        HRESULT get_EstimatedEndTime([MarshalAs(UnmanagedType.LPWStr)] out string estimatedEndTime);
        [PreserveSig]
        HRESULT get_ResultFilePath([MarshalAs(UnmanagedType.LPWStr)] out string resultFilePath);
        [PreserveSig]
        HRESULT get_State(out COREWEBVIEW2_DOWNLOAD_STATE downloadState);
        [PreserveSig]
        HRESULT get_InterruptReason(out COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON interruptReason);
        [PreserveSig]
        HRESULT Cancel();
        [PreserveSig]
        HRESULT Pause();
        [PreserveSig]
        HRESULT Resume();
        [PreserveSig]
        HRESULT get_CanResume(out bool canResume);
    };

    [ComImport]
    [Guid("81336594-7ede-4ba9-bf71-acf0a95b58dd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2StateChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2DownloadOperation sender, IntPtr args);
    };

    [ComImport]
    [Guid("28f0d425-93fe-4e63-9f8d-2aeec6d3ba1e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2EstimatedEndTimeChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2DownloadOperation sender, IntPtr args);
    };

    [ComImport]
    [Guid("828e8ab6-d94c-4264-9cef-5217170d6251")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2BytesReceivedChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2DownloadOperation sender, IntPtr args);
    };

    [ComImport]
    [Guid("38059770-9baa-11eb-a8b3-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameCreatedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2FrameCreatedEventArgs args);
    };

    [ComImport]
    [Guid("4d6e7b5e-9baa-11eb-a8b3-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameCreatedEventArgs
    {
        [PreserveSig]
        HRESULT get_Frame(out ICoreWebView2Frame value);
    };

    [ComImport]
    [Guid("f1131a5e-9ba9-11eb-a8b3-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame
    {
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        HRESULT IsDestroyed(out bool destroyed);
    };

    [ComImport]
    [Guid("7a6a5834-d185-4dbf-b63f-4a9bc43107d4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame2 : ICoreWebView2Frame
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        new HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT IsDestroyed(out bool destroyed);

        [PreserveSig]
        HRESULT add_NavigationStarting(ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_ContentLoading(ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_NavigationCompleted(ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        HRESULT add_DOMContentLoaded(ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        HRESULT add_WebMessageReceived(ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_WebMessageReceived(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("b50d82cc-cc28-481d-9614-cb048895e6a0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame3 : ICoreWebView2Frame2
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        new HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT IsDestroyed(out bool destroyed);

        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_PermissionRequested(ICoreWebView2FramePermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_PermissionRequested(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("188782dc-92aa-4732-ab3c-fcc59f6f68b9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame4 : ICoreWebView2Frame3
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        new HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT IsDestroyed(out bool destroyed);

        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2FramePermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);

        [PreserveSig]
        HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);
    };

    [ComImport]
    [Guid("99d199c4-7305-11ee-b962-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame5 : ICoreWebView2Frame4
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        new HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT IsDestroyed(out bool destroyed);

        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2FramePermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        HRESULT get_FrameId(out uint value);
    };

    [ComImport]
    [Guid("0de611fd-31e9-5ddc-9d71-95eda26eff32")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Frame6 : ICoreWebView2Frame5
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        new HRESULT add_NameChanged(ICoreWebView2FrameNameChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NameChanged(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT AddHostObjectToScriptWithOrigins(string name,
            //VARIANT*object,
            IntPtr obj,
            uint originsCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr), In] string[] origins);
        [PreserveSig]
        new HRESULT RemoveHostObjectFromScript(string name);
        [PreserveSig]
        new HRESULT add_Destroyed(ICoreWebView2FrameDestroyedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_Destroyed(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT IsDestroyed(out bool destroyed);

        [PreserveSig]
        new HRESULT add_NavigationStarting(ICoreWebView2FrameNavigationStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationStarting(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_ContentLoading(ICoreWebView2FrameContentLoadingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_ContentLoading(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_NavigationCompleted(ICoreWebView2FrameNavigationCompletedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NavigationCompleted(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT add_DOMContentLoaded(ICoreWebView2FrameDOMContentLoadedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_DOMContentLoaded(EventRegistrationToken token);
        [PreserveSig]
        new HRESULT ExecuteScript(string javaScript, ICoreWebView2ExecuteScriptCompletedHandler handler);
        [PreserveSig]
        new HRESULT PostWebMessageAsJson(string webMessageAsJson);
        [PreserveSig]
        new HRESULT PostWebMessageAsString(string webMessageAsString);
        [PreserveSig]
        new HRESULT add_WebMessageReceived(ICoreWebView2FrameWebMessageReceivedEventHandler handler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_WebMessageReceived(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT add_PermissionRequested(ICoreWebView2FramePermissionRequestedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_PermissionRequested(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT PostSharedBufferToScript(ICoreWebView2SharedBuffer sharedBuffer, COREWEBVIEW2_SHARED_BUFFER_ACCESS access, string additionalDataAsJson);

        [PreserveSig]
        new HRESULT get_FrameId(out uint value);

        [PreserveSig]
        HRESULT add_ScreenCaptureStarting(ICoreWebView2FrameScreenCaptureStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_ScreenCaptureStarting(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("a6c1d8ad-bb80-59c5-895b-fba1698b9309")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameScreenCaptureStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2ScreenCaptureStartingEventArgs args);
    };

    [ComImport]
    [Guid("845d0edd-8bd8-429b-9915-4821789f23e9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FramePermissionRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2PermissionRequestedEventArgs2 args);
    };

    [ComImport]
    [Guid("e371e005-6d1d-4517-934b-a8f1629c62a5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameWebMessageReceivedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2WebMessageReceivedEventArgs args);
    };

    [ComImport]
    [Guid("38d9520d-340f-4d1e-a775-43fce9753683")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameDOMContentLoadedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2DOMContentLoadedEventArgs args);
    };

    [ComImport]
    [Guid("609302ad-0e36-4f9a-a210-6a45272842a9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameNavigationCompletedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2NavigationCompletedEventArgs args);
    };

    [ComImport]
    [Guid("0d6156f2-d332-49a7-9e03-7d8f2feeee54")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameContentLoadingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2ContentLoadingEventArgs args);
    };

    [ComImport]
    [Guid("e79908bf-2d5d-4968-83db-263fea2c1da3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameNavigationStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, ICoreWebView2NavigationStartingEventArgs args);
    };

    [ComImport]
    [Guid("59dd7b4c-9baa-11eb-a8b3-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameDestroyedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, IntPtr args);
    };

    [ComImport]
    [Guid("435c7dc8-9baa-11eb-a8b3-0242ac130003")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameNameChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Frame sender, IntPtr args);
    };

    [ComImport]
    [Guid("da86b8a1-bdf3-4f11-9955-528cefa59727")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameInfo
    {
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("56f85cfa-72c4-11ee-b962-0242ac120002")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FrameInfo2 : ICoreWebView2FrameInfo
    {
        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT get_ParentFrameInfo(out ICoreWebView2FrameInfo frameInfo);
        [PreserveSig]
        HRESULT get_FrameId(out uint id);
        [PreserveSig]
        HRESULT get_FrameKind(out COREWEBVIEW2_FRAME_KIND kind);
    };

    [ComImport]
    [Guid("00f206a7-9d17-4605-91f6-4e8e4de192e3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2TrySuspendCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, bool result);
    };

    [ComImport]
    [Guid("177CD9E7-B6F5-451A-94A0-5D7A3A4C4141")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CookieManager
    {
        [PreserveSig]
        HRESULT CreateCookie(string name, string value, string domain, string path, out ICoreWebView2Cookie cookie);
        [PreserveSig]
        HRESULT CopyCookie(ICoreWebView2Cookie cookieParam, out ICoreWebView2Cookie cookie);
        [PreserveSig]
        HRESULT GetCookies(string uri, ICoreWebView2GetCookiesCompletedHandler handler);
        [PreserveSig]
        HRESULT AddOrUpdateCookie(ICoreWebView2Cookie cookie);
        [PreserveSig]
        HRESULT DeleteCookie(ICoreWebView2Cookie cookie);
        [PreserveSig]
        HRESULT DeleteCookies(string name, string uri);
        [PreserveSig]
        HRESULT DeleteCookiesWithDomainAndPath(string name, string domain, string path);
        [PreserveSig]
        HRESULT DeleteAllCookies();
    };

    [ComImport]
    [Guid("5a4f5069-5c15-47c3-8646-f4de1c116670")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2GetCookiesCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, ICoreWebView2CookieList result);
    };

    [ComImport]
    [Guid("f7f6f714-5d2a-43c6-9503-346ece02d186")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CookieList
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out ICoreWebView2Cookie value);
    };

    [ComImport]
    [Guid("4bac7e9c-199e-49ed-87ed-249303acf019")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DOMContentLoadedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2DOMContentLoadedEventArgs args);
    };

    [ComImport]
    [Guid("16b1e21a-c503-44f2-84c9-70aba5031283")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DOMContentLoadedEventArgs
    {
        [PreserveSig]
        HRESULT get_NavigationId(out UInt64 value);
    };

    [ComImport]
    [Guid("7de9898a-24f5-40c3-a2de-d4f458e69828")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceResponseReceivedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceResponseReceivedEventArgs args);
    };

    [ComImport]
    [Guid("d1db483d-6796-4b8b-80fc-13712bb716f4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceResponseReceivedEventArgs
    {
        [PreserveSig]
        HRESULT get_Request(out ICoreWebView2WebResourceRequest value);
        [PreserveSig]
        HRESULT get_Response(out ICoreWebView2WebResourceResponseView value);
    };

    [ComImport]
    [Guid("79701053-7759-4162-8F7D-F1B3F084928D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceResponseView
    {
        [PreserveSig]
        HRESULT get_Headers(out ICoreWebView2HttpResponseHeaders headers);
        [PreserveSig]
        HRESULT get_StatusCode(out int statusCode);
        [PreserveSig]
        HRESULT get_ReasonPhrase([MarshalAs(UnmanagedType.LPWStr)] out string reasonPhrase);
        [PreserveSig]
        HRESULT GetContent(ICoreWebView2WebResourceResponseViewGetContentCompletedHandler handler);
    };

    [ComImport]
    [Guid("875738e1-9fa2-40e3-8b74-2e8972dd6fe7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceResponseViewGetContentCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, IStream result);
    };

    [ComImport]
    [Guid("5c19e9e0-092f-486b-affa-ca8231913039")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WindowCloseRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("ab00b74c-15f1-4646-80e8-e76341d25d71")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2WebResourceRequestedEventArgs args);
    };

    [ComImport]
    [Guid("453e667f-12c7-49d4-be6d-ddbe7956f57a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Request(out ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        HRESULT get_Response(out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        HRESULT put_Response(ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
        [PreserveSig]
        HRESULT get_ResourceContext(out COREWEBVIEW2_WEB_RESOURCE_CONTEXT context);
    };

    [ComImport]
    [Guid("9c562c24-b219-4d7f-92f6-b187fbbadd56")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebResourceRequestedEventArgs2 : ICoreWebView2WebResourceRequestedEventArgs
    {
        [PreserveSig]
        new HRESULT get_Request(out ICoreWebView2WebResourceRequest request);
        [PreserveSig]
        new HRESULT get_Response(out ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT put_Response(ICoreWebView2WebResourceResponse response);
        [PreserveSig]
        new HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
        [PreserveSig]
        new HRESULT get_ResourceContext(out COREWEBVIEW2_WEB_RESOURCE_CONTEXT context);

        [PreserveSig]
        HRESULT get_RequestedSourceKind(out COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS value);
    };

    [ComImport]
    [Guid("e45d98b1-afef-45be-8baf-6c7728867f73")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContainsFullScreenElementChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("f5f2b923-953e-4042-9f95-f3a118e1afd4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DocumentTitleChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("d4c185fe-c81c-4989-97af-2d3fa7ab5651")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NewWindowRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2NewWindowRequestedEventArgs args);
    };

    [ComImport]
    [Guid("34acb11c-fc37-4418-9132-f9c21d1eafb9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NewWindowRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT put_NewWindow(ICoreWebView2 newWindow);
        [PreserveSig]
        HRESULT get_NewWindow(out ICoreWebView2 newWindow);
        [PreserveSig]
        HRESULT put_Handled(bool handled);
        [PreserveSig]
        HRESULT get_Handled(out bool handled);
        [PreserveSig]
        HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
        [PreserveSig]
        HRESULT get_WindowFeatures(out ICoreWebView2WindowFeatures value);
    };

    [ComImport]
    [Guid("bbc7baed-74c6-4c92-b63a-7f5aeae03de3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NewWindowRequestedEventArgs2 : ICoreWebView2NewWindowRequestedEventArgs
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT put_NewWindow(ICoreWebView2 newWindow);
        [PreserveSig]
        new HRESULT get_NewWindow(out ICoreWebView2 newWindow);
        [PreserveSig]
        new HRESULT put_Handled(bool handled);
        [PreserveSig]
        new HRESULT get_Handled(out bool handled);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
        [PreserveSig]
        new HRESULT get_WindowFeatures(out ICoreWebView2WindowFeatures value);

        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("842bed3c-6ad6-4dd9-b938-28c96667ad66")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NewWindowRequestedEventArgs3 : ICoreWebView2NewWindowRequestedEventArgs2
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT put_NewWindow(ICoreWebView2 newWindow);
        [PreserveSig]
        new HRESULT get_NewWindow(out ICoreWebView2 newWindow);
        [PreserveSig]
        new HRESULT put_Handled(bool handled);
        [PreserveSig]
        new HRESULT get_Handled(out bool handled);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
        [PreserveSig]
        new HRESULT get_WindowFeatures(out ICoreWebView2WindowFeatures value);

        [PreserveSig]
        new HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT get_OriginalSourceFrameInfo(out ICoreWebView2FrameInfo value);
    };

    [ComImport]
    [Guid("5eaf559f-b46e-4397-8860-e422f287ff1e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WindowFeatures
    {
        [PreserveSig]
        HRESULT get_HasPosition(out bool value);
        [PreserveSig]
        HRESULT get_HasSize(out bool value);
        [PreserveSig]
        HRESULT get_Left(out uint value);
        [PreserveSig]
        HRESULT get_Top(out uint value);
        [PreserveSig]
        HRESULT get_Height(out uint value);
        [PreserveSig]
        HRESULT get_Width(out uint value);
        [PreserveSig]
        HRESULT get_ShouldDisplayMenuBar(out bool value);
        [PreserveSig]
        HRESULT get_ShouldDisplayStatus(out bool value);
        [PreserveSig]
        HRESULT get_ShouldDisplayToolbar(out bool value);
        [PreserveSig]
        HRESULT get_ShouldDisplayScrollBars(out bool value);
    };

    [ComImport]
    [Guid("b32ca51a-8371-45e9-9317-af021d080367")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DevToolsProtocolEventReceiver
    {
        [PreserveSig]
        HRESULT add_DevToolsProtocolEventReceived(ICoreWebView2DevToolsProtocolEventReceivedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DevToolsProtocolEventReceived(EventRegistrationToken token);
    };

    [ComImport]
    [Guid("e2fda4be-5456-406c-a261-3d452138362c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DevToolsProtocolEventReceivedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2DevToolsProtocolEventReceivedEventArgs args);
    };

    [ComImport]
    [Guid("653c2959-bb3a-4377-8632-b58ada4e66c4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DevToolsProtocolEventReceivedEventArgs
    {
        [PreserveSig]
        HRESULT get_ParameterObjectAsJson([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("2dc4959d-1494-4393-95ba-bea4cb9ebd1b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DevToolsProtocolEventReceivedEventArgs2 : ICoreWebView2DevToolsProtocolEventReceivedEventArgs
    {
        [PreserveSig]
        new HRESULT get_ParameterObjectAsJson([MarshalAs(UnmanagedType.LPWStr)] out string value);

        [PreserveSig]
        HRESULT get_SessionId([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("5c4889f0-5ef6-4c5a-952c-d8f1b92d0574")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CallDevToolsProtocolMethodCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, [MarshalAs(UnmanagedType.LPWStr)] string result);
    };

    [ComImport]
    [Guid("57213f19-00e6-49fa-8e07-898ea01ecbd2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebMessageReceivedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2WebMessageReceivedEventArgs args);
    };

    [ComImport]
    [Guid("0f99a40c-e962-4207-9e92-e3d542eff849")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebMessageReceivedEventArgs
    {
        [PreserveSig]
        HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_WebMessageAsJson([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT TryGetWebMessageAsString([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("06fc7ab7-c90c-4297-9389-33ca01cf6d5e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2WebMessageReceivedEventArgs2 : ICoreWebView2WebMessageReceivedEventArgs
    {
        [PreserveSig]
        new HRESULT get_Source([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT get_WebMessageAsJson([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT TryGetWebMessageAsString([MarshalAs(UnmanagedType.LPWStr)] out string value);

         HRESULT get_AdditionalObjects(out ICoreWebView2ObjectCollectionView value);
    };

    [ComImport]
    [Guid("697e05e9-3d8f-45fa-96f4-8ffe1ededaf5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CapturePreviewCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode);
    };

    public enum COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT
    {
        COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT_PNG = 0,
        COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT_JPEG = (COREWEBVIEW2_CAPTURE_PREVIEW_IMAGE_FORMAT_PNG + 1)
    }

    [ComImport]
    [Guid("49511172-cc67-4bca-9923-137112f4c4cc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ExecuteScriptCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, [MarshalAs(UnmanagedType.LPWStr)] string result);
    };

    [ComImport]
    [Guid("b99369f3-9b11-47b5-bc6f-8e7895fcea17")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2AddScriptToExecuteOnDocumentCreatedCompletedHandler
    {
        [PreserveSig]
        HRESULT Invoke(HRESULT errorCode, [MarshalAs(UnmanagedType.LPWStr)] string result);
    };

    [ComImport]
    [Guid("79e0aea4-990b-42d9-aa1d-0fcc2e5bc7f1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessFailedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ProcessFailedEventArgs args);
    };

    [ComImport]
    [Guid("8155a9a4-1474-4a86-8cae-151b0fa6b8ca")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessFailedEventArgs
    {
        [PreserveSig]
        HRESULT get_ProcessFailedKind(out COREWEBVIEW2_PROCESS_FAILED_KIND value);
    };

    [ComImport]
    [Guid("4dab9422-46fa-4c3e-a5d2-41d2071d3680")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessFailedEventArgs2 : ICoreWebView2ProcessFailedEventArgs
    {
        [PreserveSig]
        new HRESULT get_ProcessFailedKind(out COREWEBVIEW2_PROCESS_FAILED_KIND value);

        [PreserveSig]
        HRESULT get_Reason(out COREWEBVIEW2_PROCESS_FAILED_REASON reason);
        [PreserveSig]
        HRESULT get_ExitCode(out int exitCode);
        [PreserveSig]
        HRESULT get_ProcessDescription([MarshalAs(UnmanagedType.LPWStr)] out string processDescription);
        [PreserveSig]
        HRESULT get_FrameInfosForFailedProcess(out ICoreWebView2FrameInfoCollection frames);
    };

    [ComImport]
    [Guid("ab667428-094d-5fd1-b480-8b4c0fdbdf2f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ProcessFailedEventArgs3 : ICoreWebView2ProcessFailedEventArgs2
    {
        [PreserveSig]
        new HRESULT get_ProcessFailedKind(out COREWEBVIEW2_PROCESS_FAILED_KIND value);

        [PreserveSig]
        new HRESULT get_Reason(out COREWEBVIEW2_PROCESS_FAILED_REASON reason);
        [PreserveSig]
        new HRESULT get_ExitCode(out int exitCode);
        [PreserveSig]
        new HRESULT get_ProcessDescription([MarshalAs(UnmanagedType.LPWStr)] out string processDescription);
        [PreserveSig]
        new HRESULT get_FrameInfosForFailedProcess(out ICoreWebView2FrameInfoCollection frames);

        HRESULT get_FailureSourceModulePath([MarshalAs(UnmanagedType.LPWStr)] out string value);
    };

    [ComImport]
    [Guid("15e1c6a3-c72a-4df3-91d7-d097fbec6bfd")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2PermissionRequestedEventArgs args);
    };

    [ComImport]
    [Guid("973ae2ef-ff18-4894-8fb2-3c758f046810")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT get_PermissionKind(out COREWEBVIEW2_PERMISSION_KIND permissionKind);
        [PreserveSig]
        HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        HRESULT get_State(out COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        HRESULT put_State(COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("74d7127f-9de6-4200-8734-42d6fb4ff741")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionRequestedEventArgs2 : ICoreWebView2PermissionRequestedEventArgs
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT get_PermissionKind(out COREWEBVIEW2_PERMISSION_KIND permissionKind);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT get_State(out COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        new HRESULT put_State(COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        new HRESULT GetDeferral(out ICoreWebView2Deferral deferral);

        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT put_Handled(bool value);        
    };

    [ComImport]
    [Guid("e61670bc-3dce-4177-86d2-c629ae3cb6ac")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2PermissionRequestedEventArgs3 : ICoreWebView2PermissionRequestedEventArgs2
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT get_PermissionKind(out COREWEBVIEW2_PERMISSION_KIND permissionKind);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT get_State(out COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        new HRESULT put_State(COREWEBVIEW2_PERMISSION_STATE state);
        [PreserveSig]
        new HRESULT GetDeferral(out ICoreWebView2Deferral deferral);

        [PreserveSig]
        new HRESULT get_Handled(out bool value);
        [PreserveSig]
        new HRESULT put_Handled(bool value);

        [PreserveSig]
        HRESULT get_SavesInProfile(out bool value);
        [PreserveSig]
        HRESULT  put_SavesInProfile(bool value);
    };

    [ComImport]
    [Guid("ef381bf9-afa8-4e37-91c4-8ac48524bdfb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ScriptDialogOpeningEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ScriptDialogOpeningEventArgs args);
    };

    [ComImport]
    [Guid("7390bb70-abe0-4843-9529-f143b31b03d6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ScriptDialogOpeningEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT get_Kind(out COREWEBVIEW2_SCRIPT_DIALOG_KIND kind);
        [PreserveSig]
        HRESULT get_Message([MarshalAs(UnmanagedType.LPWStr)] out string message);
        [PreserveSig]
        HRESULT Accept();
        [PreserveSig]
        HRESULT get_DefaultText([MarshalAs(UnmanagedType.LPWStr)] out string defaultText);
        [PreserveSig]
        HRESULT get_ResultText([MarshalAs(UnmanagedType.LPWStr)] out string resultText);
        [PreserveSig]
        HRESULT put_ResultText([MarshalAs(UnmanagedType.LPWStr)] string resultText);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral deferral);
    };

    [ComImport]
    [Guid("c10e7f7b-b585-46f0-a623-8befbf3e4ee0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Deferral
    {
        [PreserveSig]
        HRESULT Complete();
    };

    [ComImport]
    [Guid("d33a35bf-1c49-4f98-93ab-006e0533fe1c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationCompletedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2NavigationCompletedEventArgs args);
    };

    [ComImport]
    [Guid("30d68b7d-20d9-4752-a9ca-ec8448fbb5c1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationCompletedEventArgs
    {
        [PreserveSig]
        HRESULT get_IsSuccess(out bool isSuccess);
        [PreserveSig]
        HRESULT get_WebErrorStatus(out COREWEBVIEW2_WEB_ERROR_STATUS webErrorStatus);
        [PreserveSig]
        HRESULT get_NavigationId(out UInt64 navigationId);
    };

    [ComImport]
    [Guid("fdf8b738-ee1e-4db2-a329-8d7d7b74d792")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationCompletedEventArgs2 : ICoreWebView2NavigationCompletedEventArgs
    {
        [PreserveSig]
        new HRESULT get_IsSuccess(out bool isSuccess);
        [PreserveSig]
        new HRESULT get_WebErrorStatus(out COREWEBVIEW2_WEB_ERROR_STATUS webErrorStatus);
        [PreserveSig]
        new HRESULT get_NavigationId(out UInt64 navigationId);

        [PreserveSig]
        HRESULT get_HttpStatusCode(out int value);
    };

    [ComImport]
    [Guid("c79a420c-efd9-4058-9295-3e8b4bcab645")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2HistoryChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, IntPtr args);
    };

    [ComImport]
    [Guid("3c067f9f-5388-4772-8b48-79f7ef1ab37c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SourceChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2SourceChangedEventArgs args);
    };

    [ComImport]
    [Guid("31e0e545-1dba-4266-8914-f63848a1f7d7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2SourceChangedEventArgs
    {
        [PreserveSig]
        HRESULT get_IsNewDocument(out bool value);
    };

    [ComImport]
    [Guid("b52d71d6-c4df-4543-a90c-64a3e60f38cb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ZoomFactorChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Controller sender, IntPtr args);
    };

    [ComImport]
    [Guid("364471e7-f2be-4910-bdba-d72077d51c4b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContentLoadingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2ContentLoadingEventArgs args);
    };

    [ComImport]
    [Guid("0c8a1275-9b6b-4901-87ad-70df25bafa6e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2ContentLoadingEventArgs
    {
        [PreserveSig]
        HRESULT get_IsErrorPage(out bool value);
        [PreserveSig]
        HRESULT get_NavigationId(out UInt64 value);
    };

    [ComImport]
    [Guid("9adbe429-f36d-432b-9ddc-f8881fbd76e3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2 sender, ICoreWebView2NavigationStartingEventArgs args);
    };

    [ComImport]
    [Guid("9adbe429-f36d-432b-9ddc-f8881fbd76e3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationStartingEventArgs
    {
        [PreserveSig]
        HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        HRESULT get_IsRedirected(out bool isRedirected);
        [PreserveSig]
        HRESULT get_RequestHeaders(out ICoreWebView2HttpRequestHeaders requestHeaders);
        [PreserveSig]
        HRESULT get_Cancel(out bool cancel);
        [PreserveSig]
        HRESULT put_Cancel(bool cancel);
        [PreserveSig]
        HRESULT get_NavigationId(out UInt64 navigationId);
    };

    [ComImport]
    [Guid("9086be93-91aa-472d-a7e0-579f2ba006ad")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationStartingEventArgs2 : ICoreWebView2NavigationStartingEventArgs
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT get_IsRedirected(out bool isRedirected);
        [PreserveSig]
        new HRESULT get_RequestHeaders(out ICoreWebView2HttpRequestHeaders requestHeaders);
        [PreserveSig]
        new HRESULT get_Cancel(out bool cancel);
        [PreserveSig]
        new HRESULT put_Cancel(bool cancel);
        [PreserveSig]
        new HRESULT get_NavigationId(out UInt64 navigationId);

        [PreserveSig]
        HRESULT get_AdditionalAllowedFrameAncestors([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_AdditionalAllowedFrameAncestors(string value);
    };

    [ComImport]
    [Guid("ddffe494-4942-4bd2-ab73-35b8ff40e19f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NavigationStartingEventArgs3 : ICoreWebView2NavigationStartingEventArgs2
    {
        [PreserveSig]
        new HRESULT get_Uri([MarshalAs(UnmanagedType.LPWStr)] out string uri);
        [PreserveSig]
        new HRESULT get_IsUserInitiated(out bool isUserInitiated);
        [PreserveSig]
        new HRESULT get_IsRedirected(out bool isRedirected);
        [PreserveSig]
        new HRESULT get_RequestHeaders(out ICoreWebView2HttpRequestHeaders requestHeaders);
        [PreserveSig]
        new HRESULT get_Cancel(out bool cancel);
        [PreserveSig]
        new HRESULT put_Cancel(bool cancel);
        [PreserveSig]
        new HRESULT get_NavigationId(out UInt64 navigationId);

        [PreserveSig]
        new HRESULT get_AdditionalAllowedFrameAncestors([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_AdditionalAllowedFrameAncestors(string value);

        [PreserveSig]
        HRESULT get_NavigationKind(out COREWEBVIEW2_NAVIGATION_KIND value);
    };

    [ComImport]
    [Guid("e86cac0e-5523-465c-b536-8fb9fc8c8c60")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2HttpRequestHeaders
    {
        [PreserveSig]
        HRESULT GetHeader(string name, [MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT GetHeaders(string name, out ICoreWebView2HttpHeadersCollectionIterator value);
        [PreserveSig]
        HRESULT Contains(string name, out bool value);
        [PreserveSig]
        HRESULT SetHeader(string name, string value);
        [PreserveSig]
        HRESULT RemoveHeader(string name);
        [PreserveSig]
        HRESULT GetIterator(out ICoreWebView2HttpHeadersCollectionIterator value);
    };

    [ComImport]
    [Guid("0702fc30-f43b-47bb-ab52-a42cb552ad9f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2HttpHeadersCollectionIterator
    {
        [PreserveSig]
        HRESULT GetCurrentHeader([MarshalAs(UnmanagedType.LPWStr)] out string name, [MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT get_HasCurrentHeader(out bool hasCurrent);
        [PreserveSig]
        HRESULT MoveNext(out bool hasNext);
    };

    [ComImport]
    [Guid("e562e4f0-d7fa-43ac-8d71-c05150499f00")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings
    {
        [PreserveSig]
        HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);
    };

    [ComImport]
    [Guid("ee9a0f68-f46c-4e32-ac23-ef8cac224d2a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings2 : ICoreWebView2Settings
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_UserAgent(string value);
    };

    [ComImport]
    [Guid("fdb5ab74-af33-4854-84f0-0a631deb5eba")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings3 : ICoreWebView2Settings2
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);
    };

    [ComImport]
    [Guid("cb56846c-4168-4d53-b04f-03b6d6796ff2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings4 : ICoreWebView2Settings3
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsGeneralAutofillEnabled(bool value);
    };

    [ComImport]
    [Guid("183e7052-1d03-43a0-ab99-98e043b66b39")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings5 : ICoreWebView2Settings4
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        HRESULT get_IsPinchZoomEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsPinchZoomEnabled(bool value) ;
    };

    [ComImport]
    [Guid("11cb3acd-9bc8-43b8-83bf-f40753714f87")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings6 : ICoreWebView2Settings5
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPinchZoomEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPinchZoomEnabled(bool value);

        [PreserveSig]
        HRESULT get_IsSwipeNavigationEnabled(out bool value);
        [PreserveSig]
        HRESULT  put_IsSwipeNavigationEnabled(bool value) ;
    };

    [ComImport]
    [Guid("488dc902-35ef-42d2-bc7d-94b65c4bc49c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings7 : ICoreWebView2Settings6
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPinchZoomEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPinchZoomEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsSwipeNavigationEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsSwipeNavigationEnabled(bool value);

        [PreserveSig]
        HRESULT get_HiddenPdfToolbarItems(out COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);
        [PreserveSig]
        HRESULT put_HiddenPdfToolbarItems(COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);
    };

    [ComImport]
    [Guid("9e6b0e8f-86ad-4e81-8147-a9b5edb68650")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings8 : ICoreWebView2Settings7
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPinchZoomEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPinchZoomEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsSwipeNavigationEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsSwipeNavigationEnabled(bool value);

        [PreserveSig]
        new HRESULT get_HiddenPdfToolbarItems(out COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);
        [PreserveSig]
        new HRESULT put_HiddenPdfToolbarItems(COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);

        [PreserveSig]
        HRESULT get_IsReputationCheckingRequired(out bool value);
        [PreserveSig]
        HRESULT put_IsReputationCheckingRequired(bool value);
    };

    [ComImport]
    [Guid("0528a73b-e92d-49f4-927a-e547dddaa37d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Settings9 : ICoreWebView2Settings8
    {
        [PreserveSig]
        new HRESULT get_IsScriptEnabled(out bool isScriptEnabled);
        [PreserveSig]
        new HRESULT put_IsScriptEnabled(bool isScriptEnabled);
        [PreserveSig]
        new HRESULT get_IsWebMessageEnabled(out bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT put_IsWebMessageEnabled(bool isWebMessageEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultScriptDialogsEnabled(out bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT put_AreDefaultScriptDialogsEnabled(bool areDefaultScriptDialogsEnabled);
        [PreserveSig]
        new HRESULT get_IsStatusBarEnabled(out bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT put_IsStatusBarEnabled(bool isStatusBarEnabled);
        [PreserveSig]
        new HRESULT get_AreDevToolsEnabled(out bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT put_AreDevToolsEnabled(bool areDevToolsEnabled);
        [PreserveSig]
        new HRESULT get_AreDefaultContextMenusEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_AreDefaultContextMenusEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_AreHostObjectsAllowed(out bool allowed);
        [PreserveSig]
        new HRESULT put_AreHostObjectsAllowed(bool allowed);
        [PreserveSig]
        new HRESULT get_IsZoomControlEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsZoomControlEnabled(bool enabled);
        [PreserveSig]
        new HRESULT get_IsBuiltInErrorPageEnabled(out bool enabled);
        [PreserveSig]
        new HRESULT put_IsBuiltInErrorPageEnabled(bool enabled);

        [PreserveSig]
        new HRESULT get_UserAgent([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        new HRESULT put_UserAgent(string value);

        [PreserveSig]
        new HRESULT get_AreBrowserAcceleratorKeysEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_AreBrowserAcceleratorKeysEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPasswordAutosaveEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPasswordAutosaveEnabled(bool value);
        [PreserveSig]
        new HRESULT get_IsGeneralAutofillEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsGeneralAutofillEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsPinchZoomEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsPinchZoomEnabled(bool value);

        [PreserveSig]
        new HRESULT get_IsSwipeNavigationEnabled(out bool value);
        [PreserveSig]
        new HRESULT put_IsSwipeNavigationEnabled(bool value);

        [PreserveSig]
        new HRESULT get_HiddenPdfToolbarItems(out COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);
        [PreserveSig]
        new HRESULT put_HiddenPdfToolbarItems(COREWEBVIEW2_PDF_TOOLBAR_ITEMS value);

        [PreserveSig]
        new HRESULT get_IsReputationCheckingRequired(out bool value);
        [PreserveSig]
        new HRESULT put_IsReputationCheckingRequired(bool value);

        [PreserveSig]
        HRESULT get_IsNonClientRegionSupportEnabled(out bool value);
        [PreserveSig]
        HRESULT put_IsNonClientRegionSupportEnabled(bool value);
    };

    [ComImport]
    [Guid("69035451-6dc7-4cb8-9bce-b2bd70ad289f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2MoveFocusRequestedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Controller sender, ICoreWebView2MoveFocusRequestedEventArgs args);
    };

    [ComImport]
    [Guid("2d6aa13b-3839-4a15-92fc-d88b3c0d9c9d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2MoveFocusRequestedEventArgs
    {
        [PreserveSig]
        HRESULT get_Reason(out COREWEBVIEW2_MOVE_FOCUS_REASON reason);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
    };

    [ComImport]
    [Guid("05ea24bd-6452-4926-9014-4b82b498135d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2FocusChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Controller sender, IntPtr args);
    };

    [ComImport]
    [Guid("b29c7e28-fa79-41a8-8e44-65811c76dcb2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2AcceleratorKeyPressedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2Controller sender, ICoreWebView2AcceleratorKeyPressedEventArgs args);
    };

    [ComImport]
    [Guid("9f760f8a-fb79-42be-9990-7b56900fa9c7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2AcceleratorKeyPressedEventArgs
    {
        [PreserveSig]
        HRESULT get_KeyEventKind(out COREWEBVIEW2_KEY_EVENT_KIND keyEventKind);
        [PreserveSig]
        HRESULT get_VirtualKey(out uint virtualKey);
        [PreserveSig]
        HRESULT get_KeyEventLParam(out int lParam);
        [PreserveSig]
        HRESULT get_PhysicalKeyStatus(out COREWEBVIEW2_PHYSICAL_KEY_STATUS physicalKeyStatus);
        [PreserveSig]
        HRESULT get_Handled(out bool handled);
        [PreserveSig]
        HRESULT put_Handled(bool handled);
    };

    [ComImport]
    [Guid("03b2c8c8-7799-4e34-bd66-ed26aa85f2bf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2AcceleratorKeyPressedEventArgs2 : ICoreWebView2AcceleratorKeyPressedEventArgs
    {
        [PreserveSig]
        new HRESULT get_KeyEventKind(out COREWEBVIEW2_KEY_EVENT_KIND keyEventKind);
        [PreserveSig]
        new HRESULT get_VirtualKey(out uint virtualKey);
        [PreserveSig]
        new HRESULT get_KeyEventLParam(out int lParam);
        [PreserveSig]
        new HRESULT get_PhysicalKeyStatus(out COREWEBVIEW2_PHYSICAL_KEY_STATUS physicalKeyStatus);
        [PreserveSig]
        new HRESULT get_Handled(out bool handled);
        [PreserveSig]
        new HRESULT put_Handled(bool handled);

        [PreserveSig]
        HRESULT get_IsBrowserAcceleratorKeyEnabled(out bool value);
        [PreserveSig]
        HRESULT  put_IsBrowserAcceleratorKeyEnabled(bool value);
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct COREWEBVIEW2_PHYSICAL_KEY_STATUS
    {
        public uint RepeatCount;
        public uint ScanCode;
        public bool IsExtendedKey;
        public bool IsMenuKeyDown;
        public bool WasKeyDown;
        public bool IsKeyReleased;
    }

    [ComImport]
    [Guid("3df9b733-b9ae-4a15-86b4-eb9ee9826469")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CompositionController
    {
        [PreserveSig]
        HRESULT get_RootVisualTarget(out IntPtr target);
        [PreserveSig]
        HRESULT put_RootVisualTarget(IntPtr target);
        [PreserveSig]
        HRESULT SendMouseInput(COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, uint mouseData, POINT point);
        [PreserveSig]
        HRESULT SendPointerInput(COREWEBVIEW2_POINTER_EVENT_KIND eventKind, ICoreWebView2PointerInfo pointerInfo);
        [PreserveSig]
        HRESULT get_Cursor(out IntPtr cursor);
        [PreserveSig]
        HRESULT get_SystemCursorId(out uint systemCursorId);
        [PreserveSig]
        HRESULT add_CursorChanged(ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_CursorChanged(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("0b6a3d24-49cb-4806-ba20-b5e0734a7b26")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CompositionController2 : ICoreWebView2CompositionController
    {
        [PreserveSig]
        new HRESULT get_RootVisualTarget(out IntPtr target);
        [PreserveSig]
        new HRESULT put_RootVisualTarget(IntPtr target);
        [PreserveSig]
        new HRESULT SendMouseInput(COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, uint mouseData, POINT point);
        [PreserveSig]
        new HRESULT SendPointerInput(COREWEBVIEW2_POINTER_EVENT_KIND eventKind, ICoreWebView2PointerInfo pointerInfo);
        [PreserveSig]
        new HRESULT get_Cursor(out IntPtr cursor);
        [PreserveSig]
        new HRESULT get_SystemCursorId(out uint systemCursorId);
        [PreserveSig]
        new HRESULT add_CursorChanged(ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_CursorChanged(EventRegistrationToken token);

        [PreserveSig]
        HRESULT get_AutomationProvider(out IntPtr value);
    }

    [ComImport]
    [Guid("9570570e-4d76-4361-9ee1-f04d0dbdfb1e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CompositionController3 : ICoreWebView2CompositionController2
    {
        [PreserveSig]
        new HRESULT get_RootVisualTarget(out IntPtr target);
        [PreserveSig]
        new HRESULT put_RootVisualTarget(IntPtr target);
        [PreserveSig]
        new HRESULT SendMouseInput(COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, uint mouseData, POINT point);
        [PreserveSig]
        new HRESULT SendPointerInput(COREWEBVIEW2_POINTER_EVENT_KIND eventKind, ICoreWebView2PointerInfo pointerInfo);
        [PreserveSig]
        new HRESULT get_Cursor(out IntPtr cursor);
        [PreserveSig]
        new HRESULT get_SystemCursorId(out uint systemCursorId);
        [PreserveSig]
        new HRESULT add_CursorChanged(ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_CursorChanged(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_AutomationProvider(out IntPtr value);

        [PreserveSig]
        HRESULT DragEnter([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //HRESULT DragEnter(IDataObject dataObject, uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        HRESULT DragLeave();
        [PreserveSig]
        HRESULT DragOver(uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        HRESULT Drop([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //HRESULT Drop(IDataObject dataObject, uint keyState, POINT point, ref uint effect);
    }

    [ComImport]
    [Guid("7C367B9B-3D2B-450F-9E58-D61A20F486AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CompositionController4 : ICoreWebView2CompositionController3
    {
        [PreserveSig]
        new HRESULT get_RootVisualTarget(out IntPtr target);
        [PreserveSig]
        new HRESULT put_RootVisualTarget(IntPtr target);
        [PreserveSig]
        new HRESULT SendMouseInput(COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, uint mouseData, POINT point);
        [PreserveSig]
        new HRESULT SendPointerInput(COREWEBVIEW2_POINTER_EVENT_KIND eventKind, ICoreWebView2PointerInfo pointerInfo);
        [PreserveSig]
        new HRESULT get_Cursor(out IntPtr cursor);
        [PreserveSig]
        new HRESULT get_SystemCursorId(out uint systemCursorId);
        [PreserveSig]
        new HRESULT add_CursorChanged(ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_CursorChanged(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_AutomationProvider(out IntPtr value);

        [PreserveSig]
        new HRESULT DragEnter([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //new HRESULT DragEnter(IDataObject dataObject, uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        new HRESULT DragLeave();
        [PreserveSig]
        new HRESULT DragOver(uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        new HRESULT Drop([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //new HRESULT Drop(IDataObject dataObject, uint keyState, POINT point, ref uint effect);

        [PreserveSig]
        HRESULT GetNonClientRegionAtPoint(POINT point, out COREWEBVIEW2_NON_CLIENT_REGION_KIND value);
        [PreserveSig]
        HRESULT QueryNonClientRegion(COREWEBVIEW2_NON_CLIENT_REGION_KIND kind, out ICoreWebView2RegionRectCollectionView rects);
        [PreserveSig]
        HRESULT add_NonClientRegionChanged(ICoreWebView2NonClientRegionChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_NonClientRegionChanged(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("333353b8-48bf-4449-8fcc-22697faf5753")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2RegionRectCollectionView
    {
        [PreserveSig]
        HRESULT get_Count(out uint value);
        [PreserveSig]
        HRESULT GetValueAtIndex(uint index, out RECT value);
    }

    [ComImport]
    [Guid("4a794e66-aa6c-46bd-93a3-382196837680")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NonClientRegionChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2CompositionController sender, ICoreWebView2NonClientRegionChangedEventArgs args);
    }

    [ComImport]
    [Guid("ab71d500-0820-4a52-809c-48db04ff93bf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2NonClientRegionChangedEventArgs
    {
        [PreserveSig]
        HRESULT get_RegionKind(out COREWEBVIEW2_NON_CLIENT_REGION_KIND value);
    }

    [ComImport]
    [Guid("9da43ccc-26e1-4dad-b56c-d8961c94c571")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CursorChangedEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2CompositionController sender, IntPtr args);
    }

    [ComImport]
    [Guid("AD26D6BE-1486-43E6-BF87-A2034006CA21")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2Cookie
    {
        [PreserveSig]
        HRESULT get_Name([MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        HRESULT get_Value([MarshalAs(UnmanagedType.LPWStr)] out string value);
        [PreserveSig]
        HRESULT put_Value(string value);
        [PreserveSig]
        HRESULT get_Domain([MarshalAs(UnmanagedType.LPWStr)] out string domain);
        [PreserveSig]
        HRESULT get_Path([MarshalAs(UnmanagedType.LPWStr)] out string path);
        [PreserveSig]
        HRESULT get_Expires(out double expires);
        [PreserveSig]
        HRESULT put_Expires(double expires);
        [PreserveSig]
        HRESULT get_IsHttpOnly(out bool isHttpOnly);
        [PreserveSig]
        HRESULT put_IsHttpOnly(bool isHttpOnly);
        [PreserveSig]
        HRESULT get_SameSite(out COREWEBVIEW2_COOKIE_SAME_SITE_KIND sameSite);
        [PreserveSig]
        HRESULT put_SameSite(COREWEBVIEW2_COOKIE_SAME_SITE_KIND sameSite);
        [PreserveSig]
        HRESULT get_IsSecure(out bool isSecure);
        [PreserveSig]
        HRESULT put_IsSecure(bool isSecure);
        [PreserveSig]
        HRESULT get_IsSession(out bool isSession);
    }

    public enum COREWEBVIEW2_COOKIE_SAME_SITE_KIND
    {
        COREWEBVIEW2_COOKIE_SAME_SITE_KIND_NONE = 0,
        COREWEBVIEW2_COOKIE_SAME_SITE_KIND_LAX = (COREWEBVIEW2_COOKIE_SAME_SITE_KIND_NONE + 1),
        COREWEBVIEW2_COOKIE_SAME_SITE_KIND_STRICT = (COREWEBVIEW2_COOKIE_SAME_SITE_KIND_LAX + 1)
    }

    public enum COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT
    {
        COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_TOP_LEFT = 0,
        COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_TOP_RIGHT = (COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_TOP_LEFT + 1),
        COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_BOTTOM_LEFT = (COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_TOP_RIGHT + 1),
        COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_BOTTOM_RIGHT = (COREWEBVIEW2_DEFAULT_DOWNLOAD_DIALOG_CORNER_ALIGNMENT_BOTTOM_LEFT + 1)
    }

    public enum COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON
    {
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NONE = 0,
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_FAILED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NONE + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_ACCESS_DENIED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_FAILED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_NO_SPACE = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_ACCESS_DENIED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_NAME_TOO_LONG = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_NO_SPACE + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TOO_LARGE = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_NAME_TOO_LONG + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_MALICIOUS = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TOO_LARGE + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TRANSIENT_ERROR = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_MALICIOUS + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_BLOCKED_BY_POLICY = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TRANSIENT_ERROR + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_SECURITY_CHECK_FAILED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_BLOCKED_BY_POLICY + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TOO_SHORT = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_SECURITY_CHECK_FAILED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_HASH_MISMATCH = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_TOO_SHORT + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_FAILED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_FILE_HASH_MISMATCH + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_TIMEOUT = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_FAILED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_DISCONNECTED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_TIMEOUT + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_SERVER_DOWN = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_DISCONNECTED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_INVALID_REQUEST = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_SERVER_DOWN + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_FAILED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_NETWORK_INVALID_REQUEST + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_NO_RANGE = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_FAILED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_BAD_CONTENT = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_NO_RANGE + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_UNAUTHORIZED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_BAD_CONTENT + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CERTIFICATE_PROBLEM = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_UNAUTHORIZED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_FORBIDDEN = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CERTIFICATE_PROBLEM + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_UNEXPECTED_RESPONSE = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_FORBIDDEN + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CONTENT_LENGTH_MISMATCH = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_UNEXPECTED_RESPONSE + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CROSS_ORIGIN_REDIRECT = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CONTENT_LENGTH_MISMATCH + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_CANCELED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_SERVER_CROSS_ORIGIN_REDIRECT + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_SHUTDOWN = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_CANCELED + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_PAUSED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_SHUTDOWN + 1),
        COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_DOWNLOAD_PROCESS_CRASHED = (COREWEBVIEW2_DOWNLOAD_INTERRUPT_REASON_USER_PAUSED + 1)
    }

    public enum COREWEBVIEW2_DOWNLOAD_STATE
    {
        COREWEBVIEW2_DOWNLOAD_STATE_IN_PROGRESS = 0,
        COREWEBVIEW2_DOWNLOAD_STATE_INTERRUPTED = (COREWEBVIEW2_DOWNLOAD_STATE_IN_PROGRESS + 1),
        COREWEBVIEW2_DOWNLOAD_STATE_COMPLETED = (COREWEBVIEW2_DOWNLOAD_STATE_INTERRUPTED + 1)
    }

    public enum COREWEBVIEW2_FAVICON_IMAGE_FORMAT
    {
        COREWEBVIEW2_FAVICON_IMAGE_FORMAT_PNG = 0,
        COREWEBVIEW2_FAVICON_IMAGE_FORMAT_JPEG = (COREWEBVIEW2_FAVICON_IMAGE_FORMAT_PNG + 1)
    }

    public enum COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND
    {
        COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND_FILE = 0,
        COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND_DIRECTORY = (COREWEBVIEW2_FILE_SYSTEM_HANDLE_KIND_FILE + 1)
    }

    public enum COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION
    {
        COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION_READ_ONLY = 0,
        COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION_READ_WRITE = (COREWEBVIEW2_FILE_SYSTEM_HANDLE_PERMISSION_READ_ONLY + 1)
    }

    public enum COREWEBVIEW2_FRAME_KIND
    {
        COREWEBVIEW2_FRAME_KIND_UNKNOWN = 0,
        COREWEBVIEW2_FRAME_KIND_MAIN_FRAME = (COREWEBVIEW2_FRAME_KIND_UNKNOWN + 1),
        COREWEBVIEW2_FRAME_KIND_IFRAME = (COREWEBVIEW2_FRAME_KIND_MAIN_FRAME + 1),
        COREWEBVIEW2_FRAME_KIND_EMBED = (COREWEBVIEW2_FRAME_KIND_IFRAME + 1),
        COREWEBVIEW2_FRAME_KIND_OBJECT = (COREWEBVIEW2_FRAME_KIND_EMBED + 1)
    }

    public enum COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND
    {
        COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND_DENY = 0,
        COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND_ALLOW = (COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND_DENY + 1),
        COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND_DENY_CORS = (COREWEBVIEW2_HOST_RESOURCE_ACCESS_KIND_ALLOW + 1)
    }

    public enum COREWEBVIEW2_KEY_EVENT_KIND
    {
        COREWEBVIEW2_KEY_EVENT_KIND_KEY_DOWN = 0,
        COREWEBVIEW2_KEY_EVENT_KIND_KEY_UP = (COREWEBVIEW2_KEY_EVENT_KIND_KEY_DOWN + 1),
        COREWEBVIEW2_KEY_EVENT_KIND_SYSTEM_KEY_DOWN = (COREWEBVIEW2_KEY_EVENT_KIND_KEY_UP + 1),
        COREWEBVIEW2_KEY_EVENT_KIND_SYSTEM_KEY_UP = (COREWEBVIEW2_KEY_EVENT_KIND_SYSTEM_KEY_DOWN + 1)
    }

    public enum COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL
    {
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL = 0,
        COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_LOW = (COREWEBVIEW2_MEMORY_USAGE_TARGET_LEVEL_NORMAL + 1)
    }

    public enum COREWEBVIEW2_MOUSE_EVENT_KIND
    {
        COREWEBVIEW2_MOUSE_EVENT_KIND_HORIZONTAL_WHEEL = 526,
        COREWEBVIEW2_MOUSE_EVENT_KIND_LEFT_BUTTON_DOUBLE_CLICK = 515,
        COREWEBVIEW2_MOUSE_EVENT_KIND_LEFT_BUTTON_DOWN = 513,
        COREWEBVIEW2_MOUSE_EVENT_KIND_LEFT_BUTTON_UP = 514,
        COREWEBVIEW2_MOUSE_EVENT_KIND_LEAVE = 675,
        COREWEBVIEW2_MOUSE_EVENT_KIND_MIDDLE_BUTTON_DOUBLE_CLICK = 521,
        COREWEBVIEW2_MOUSE_EVENT_KIND_MIDDLE_BUTTON_DOWN = 519,
        COREWEBVIEW2_MOUSE_EVENT_KIND_MIDDLE_BUTTON_UP = 520,
        COREWEBVIEW2_MOUSE_EVENT_KIND_MOVE = 512,
        COREWEBVIEW2_MOUSE_EVENT_KIND_RIGHT_BUTTON_DOUBLE_CLICK = 518,
        COREWEBVIEW2_MOUSE_EVENT_KIND_RIGHT_BUTTON_DOWN = 516,
        COREWEBVIEW2_MOUSE_EVENT_KIND_RIGHT_BUTTON_UP = 517,
        COREWEBVIEW2_MOUSE_EVENT_KIND_WHEEL = 522,
        COREWEBVIEW2_MOUSE_EVENT_KIND_X_BUTTON_DOUBLE_CLICK = 525,
        COREWEBVIEW2_MOUSE_EVENT_KIND_X_BUTTON_DOWN = 523,
        COREWEBVIEW2_MOUSE_EVENT_KIND_X_BUTTON_UP = 524,
        COREWEBVIEW2_MOUSE_EVENT_KIND_NON_CLIENT_RIGHT_BUTTON_DOWN = 164,
        COREWEBVIEW2_MOUSE_EVENT_KIND_NON_CLIENT_RIGHT_BUTTON_UP = 165
    }

    public enum COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS
    {
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_NONE = 0,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_LEFT_BUTTON = 0x1,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_RIGHT_BUTTON = 0x2,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_SHIFT = 0x4,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_CONTROL = 0x8,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_MIDDLE_BUTTON = 0x10,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_X_BUTTON1 = 0x20,
        COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS_X_BUTTON2 = 0x40
    }

    public enum COREWEBVIEW2_MOVE_FOCUS_REASON
    {
        COREWEBVIEW2_MOVE_FOCUS_REASON_PROGRAMMATIC = 0,
        COREWEBVIEW2_MOVE_FOCUS_REASON_NEXT = (COREWEBVIEW2_MOVE_FOCUS_REASON_PROGRAMMATIC + 1),
        COREWEBVIEW2_MOVE_FOCUS_REASON_PREVIOUS = (COREWEBVIEW2_MOVE_FOCUS_REASON_NEXT + 1)
    }

    public enum COREWEBVIEW2_NAVIGATION_KIND
    {
        COREWEBVIEW2_NAVIGATION_KIND_RELOAD = 0,
        COREWEBVIEW2_NAVIGATION_KIND_BACK_OR_FORWARD = (COREWEBVIEW2_NAVIGATION_KIND_RELOAD + 1),
        COREWEBVIEW2_NAVIGATION_KIND_NEW_DOCUMENT = (COREWEBVIEW2_NAVIGATION_KIND_BACK_OR_FORWARD + 1)
    }

    public enum COREWEBVIEW2_NON_CLIENT_REGION_KIND
    {
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_NOWHERE = 0,
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_CLIENT = 1,
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_CAPTION = 2,
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_MINIMIZE = 8,
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_MAXIMIZE = 9,
        COREWEBVIEW2_NON_CLIENT_REGION_KIND_CLOSE = 20
    }

    public enum COREWEBVIEW2_PDF_TOOLBAR_ITEMS
    {
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_NONE = 0,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_SAVE = 0x1,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_PRINT = 0x2,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_SAVE_AS = 0x4,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_ZOOM_IN = 0x8,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_ZOOM_OUT = 0x10,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_ROTATE = 0x20,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_FIT_PAGE = 0x40,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_PAGE_LAYOUT = 0x80,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_BOOKMARKS = 0x100,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_PAGE_SELECTOR = 0x200,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_SEARCH = 0x400,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_FULL_SCREEN = 0x800,
        COREWEBVIEW2_PDF_TOOLBAR_ITEMS_MORE_SETTINGS = 0x1000
    }

    public enum COREWEBVIEW2_PERMISSION_KIND
    {
        COREWEBVIEW2_PERMISSION_KIND_UNKNOWN_PERMISSION = 0,
        COREWEBVIEW2_PERMISSION_KIND_MICROPHONE = (COREWEBVIEW2_PERMISSION_KIND_UNKNOWN_PERMISSION + 1),
        COREWEBVIEW2_PERMISSION_KIND_CAMERA = (COREWEBVIEW2_PERMISSION_KIND_MICROPHONE + 1),
        COREWEBVIEW2_PERMISSION_KIND_GEOLOCATION = (COREWEBVIEW2_PERMISSION_KIND_CAMERA + 1),
        COREWEBVIEW2_PERMISSION_KIND_NOTIFICATIONS = (COREWEBVIEW2_PERMISSION_KIND_GEOLOCATION + 1),
        COREWEBVIEW2_PERMISSION_KIND_OTHER_SENSORS = (COREWEBVIEW2_PERMISSION_KIND_NOTIFICATIONS + 1),
        COREWEBVIEW2_PERMISSION_KIND_CLIPBOARD_READ = (COREWEBVIEW2_PERMISSION_KIND_OTHER_SENSORS + 1),
        COREWEBVIEW2_PERMISSION_KIND_MULTIPLE_AUTOMATIC_DOWNLOADS = (COREWEBVIEW2_PERMISSION_KIND_CLIPBOARD_READ + 1),
        COREWEBVIEW2_PERMISSION_KIND_FILE_READ_WRITE = (COREWEBVIEW2_PERMISSION_KIND_MULTIPLE_AUTOMATIC_DOWNLOADS + 1),
        COREWEBVIEW2_PERMISSION_KIND_AUTOPLAY = (COREWEBVIEW2_PERMISSION_KIND_FILE_READ_WRITE + 1),
        COREWEBVIEW2_PERMISSION_KIND_LOCAL_FONTS = (COREWEBVIEW2_PERMISSION_KIND_AUTOPLAY + 1),
        COREWEBVIEW2_PERMISSION_KIND_MIDI_SYSTEM_EXCLUSIVE_MESSAGES = (COREWEBVIEW2_PERMISSION_KIND_LOCAL_FONTS + 1),
        COREWEBVIEW2_PERMISSION_KIND_WINDOW_MANAGEMENT = (COREWEBVIEW2_PERMISSION_KIND_MIDI_SYSTEM_EXCLUSIVE_MESSAGES + 1)
    }

    public enum COREWEBVIEW2_PERMISSION_STATE
    {
        COREWEBVIEW2_PERMISSION_STATE_DEFAULT = 0,
        COREWEBVIEW2_PERMISSION_STATE_ALLOW = (COREWEBVIEW2_PERMISSION_STATE_DEFAULT + 1),
        COREWEBVIEW2_PERMISSION_STATE_DENY = (COREWEBVIEW2_PERMISSION_STATE_ALLOW + 1)
    }

    public enum COREWEBVIEW2_POINTER_EVENT_KIND
    {
        COREWEBVIEW2_POINTER_EVENT_KIND_ACTIVATE = 587,
        COREWEBVIEW2_POINTER_EVENT_KIND_DOWN = 582,
        COREWEBVIEW2_POINTER_EVENT_KIND_ENTER = 585,
        COREWEBVIEW2_POINTER_EVENT_KIND_LEAVE = 586,
        COREWEBVIEW2_POINTER_EVENT_KIND_UP = 583,
        COREWEBVIEW2_POINTER_EVENT_KIND_UPDATE = 581
    }

    public enum COREWEBVIEW2_PREFERRED_COLOR_SCHEME
    {
        COREWEBVIEW2_PREFERRED_COLOR_SCHEME_AUTO = 0,
        COREWEBVIEW2_PREFERRED_COLOR_SCHEME_LIGHT = (COREWEBVIEW2_PREFERRED_COLOR_SCHEME_AUTO + 1),
        COREWEBVIEW2_PREFERRED_COLOR_SCHEME_DARK = (COREWEBVIEW2_PREFERRED_COLOR_SCHEME_LIGHT + 1)
    }

    public enum COREWEBVIEW2_PRINT_COLLATION
    {
        COREWEBVIEW2_PRINT_COLLATION_DEFAULT = 0,
        COREWEBVIEW2_PRINT_COLLATION_COLLATED = (COREWEBVIEW2_PRINT_COLLATION_DEFAULT + 1),
        COREWEBVIEW2_PRINT_COLLATION_UNCOLLATED = (COREWEBVIEW2_PRINT_COLLATION_COLLATED + 1)
    }

    public enum COREWEBVIEW2_PRINT_COLOR_MODE
    {
        COREWEBVIEW2_PRINT_COLOR_MODE_DEFAULT = 0,
        COREWEBVIEW2_PRINT_COLOR_MODE_COLOR = (COREWEBVIEW2_PRINT_COLOR_MODE_DEFAULT + 1),
        COREWEBVIEW2_PRINT_COLOR_MODE_GRAYSCALE = (COREWEBVIEW2_PRINT_COLOR_MODE_COLOR + 1)
    }


    public enum COREWEBVIEW2_PRINT_DIALOG_KIND
    {
        COREWEBVIEW2_PRINT_DIALOG_KIND_BROWSER = 0,
        COREWEBVIEW2_PRINT_DIALOG_KIND_SYSTEM = (COREWEBVIEW2_PRINT_DIALOG_KIND_BROWSER + 1)
    }

    public enum COREWEBVIEW2_PRINT_DUPLEX
    {
        COREWEBVIEW2_PRINT_DUPLEX_DEFAULT = 0,
        COREWEBVIEW2_PRINT_DUPLEX_ONE_SIDED = (COREWEBVIEW2_PRINT_DUPLEX_DEFAULT + 1),
        COREWEBVIEW2_PRINT_DUPLEX_TWO_SIDED_LONG_EDGE = (COREWEBVIEW2_PRINT_DUPLEX_ONE_SIDED + 1),
        COREWEBVIEW2_PRINT_DUPLEX_TWO_SIDED_SHORT_EDGE = (COREWEBVIEW2_PRINT_DUPLEX_TWO_SIDED_LONG_EDGE + 1)
    }

    public enum COREWEBVIEW2_PRINT_MEDIA_SIZE
    {
        COREWEBVIEW2_PRINT_MEDIA_SIZE_DEFAULT = 0,
        COREWEBVIEW2_PRINT_MEDIA_SIZE_CUSTOM = (COREWEBVIEW2_PRINT_MEDIA_SIZE_DEFAULT + 1)
    }

    public enum COREWEBVIEW2_PRINT_ORIENTATION
    {
        COREWEBVIEW2_PRINT_ORIENTATION_PORTRAIT = 0,
        COREWEBVIEW2_PRINT_ORIENTATION_LANDSCAPE = (COREWEBVIEW2_PRINT_ORIENTATION_PORTRAIT + 1)
    }

    public enum COREWEBVIEW2_PRINT_STATUS
    {
        COREWEBVIEW2_PRINT_STATUS_SUCCEEDED = 0,
        COREWEBVIEW2_PRINT_STATUS_PRINTER_UNAVAILABLE = (COREWEBVIEW2_PRINT_STATUS_SUCCEEDED + 1),
        COREWEBVIEW2_PRINT_STATUS_OTHER_ERROR = (COREWEBVIEW2_PRINT_STATUS_PRINTER_UNAVAILABLE + 1)
    }

    public enum COREWEBVIEW2_PROCESS_FAILED_KIND
    {
        COREWEBVIEW2_PROCESS_FAILED_KIND_BROWSER_PROCESS_EXITED = 0,
        COREWEBVIEW2_PROCESS_FAILED_KIND_RENDER_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_BROWSER_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_RENDER_PROCESS_UNRESPONSIVE = (COREWEBVIEW2_PROCESS_FAILED_KIND_RENDER_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_FRAME_RENDER_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_RENDER_PROCESS_UNRESPONSIVE + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_UTILITY_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_FRAME_RENDER_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_SANDBOX_HELPER_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_UTILITY_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_GPU_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_SANDBOX_HELPER_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_PPAPI_PLUGIN_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_GPU_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_PPAPI_BROKER_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_PPAPI_PLUGIN_PROCESS_EXITED + 1),
        COREWEBVIEW2_PROCESS_FAILED_KIND_UNKNOWN_PROCESS_EXITED = (COREWEBVIEW2_PROCESS_FAILED_KIND_PPAPI_BROKER_PROCESS_EXITED + 1)
    }

    public enum COREWEBVIEW2_PROCESS_FAILED_REASON
    {
        COREWEBVIEW2_PROCESS_FAILED_REASON_UNEXPECTED = 0,
        COREWEBVIEW2_PROCESS_FAILED_REASON_UNRESPONSIVE = (COREWEBVIEW2_PROCESS_FAILED_REASON_UNEXPECTED + 1),
        COREWEBVIEW2_PROCESS_FAILED_REASON_TERMINATED = (COREWEBVIEW2_PROCESS_FAILED_REASON_UNRESPONSIVE + 1),
        COREWEBVIEW2_PROCESS_FAILED_REASON_CRASHED = (COREWEBVIEW2_PROCESS_FAILED_REASON_TERMINATED + 1),
        COREWEBVIEW2_PROCESS_FAILED_REASON_LAUNCH_FAILED = (COREWEBVIEW2_PROCESS_FAILED_REASON_CRASHED + 1),
        COREWEBVIEW2_PROCESS_FAILED_REASON_OUT_OF_MEMORY = (COREWEBVIEW2_PROCESS_FAILED_REASON_LAUNCH_FAILED + 1),
        COREWEBVIEW2_PROCESS_FAILED_REASON_PROFILE_DELETED = (COREWEBVIEW2_PROCESS_FAILED_REASON_OUT_OF_MEMORY + 1)
    }

    public enum COREWEBVIEW2_PROCESS_KIND
    {
        COREWEBVIEW2_PROCESS_KIND_BROWSER = 0,
        COREWEBVIEW2_PROCESS_KIND_RENDERER = (COREWEBVIEW2_PROCESS_KIND_BROWSER + 1),
        COREWEBVIEW2_PROCESS_KIND_UTILITY = (COREWEBVIEW2_PROCESS_KIND_RENDERER + 1),
        COREWEBVIEW2_PROCESS_KIND_SANDBOX_HELPER = (COREWEBVIEW2_PROCESS_KIND_UTILITY + 1),
        COREWEBVIEW2_PROCESS_KIND_GPU = (COREWEBVIEW2_PROCESS_KIND_SANDBOX_HELPER + 1),
        COREWEBVIEW2_PROCESS_KIND_PPAPI_PLUGIN = (COREWEBVIEW2_PROCESS_KIND_GPU + 1),
        COREWEBVIEW2_PROCESS_KIND_PPAPI_BROKER = (COREWEBVIEW2_PROCESS_KIND_PPAPI_PLUGIN + 1)
    }

    public enum COREWEBVIEW2_RELEASE_CHANNELS
    {
        COREWEBVIEW2_RELEASE_CHANNELS_NONE = 0,
        COREWEBVIEW2_RELEASE_CHANNELS_STABLE = 0x1,
        COREWEBVIEW2_RELEASE_CHANNELS_BETA = 0x2,
        COREWEBVIEW2_RELEASE_CHANNELS_DEV = 0x4,
        COREWEBVIEW2_RELEASE_CHANNELS_CANARY = 0x8
    }

    public enum COREWEBVIEW2_SAVE_AS_KIND
    {
        COREWEBVIEW2_SAVE_AS_KIND_DEFAULT = 0,
        COREWEBVIEW2_SAVE_AS_KIND_HTML_ONLY = (COREWEBVIEW2_SAVE_AS_KIND_DEFAULT + 1),
        COREWEBVIEW2_SAVE_AS_KIND_SINGLE_FILE = (COREWEBVIEW2_SAVE_AS_KIND_HTML_ONLY + 1),
        COREWEBVIEW2_SAVE_AS_KIND_COMPLETE = (COREWEBVIEW2_SAVE_AS_KIND_SINGLE_FILE + 1)
    }

    public enum COREWEBVIEW2_SAVE_AS_UI_RESULT
    {
        COREWEBVIEW2_SAVE_AS_UI_RESULT_SUCCESS = 0,
        COREWEBVIEW2_SAVE_AS_UI_RESULT_INVALID_PATH = (COREWEBVIEW2_SAVE_AS_UI_RESULT_SUCCESS + 1),
        COREWEBVIEW2_SAVE_AS_UI_RESULT_FILE_ALREADY_EXISTS = (COREWEBVIEW2_SAVE_AS_UI_RESULT_INVALID_PATH + 1),
        COREWEBVIEW2_SAVE_AS_UI_RESULT_KIND_NOT_SUPPORTED = (COREWEBVIEW2_SAVE_AS_UI_RESULT_FILE_ALREADY_EXISTS + 1),
        COREWEBVIEW2_SAVE_AS_UI_RESULT_CANCELLED = (COREWEBVIEW2_SAVE_AS_UI_RESULT_KIND_NOT_SUPPORTED + 1)
    }

    public enum COREWEBVIEW2_SCRIPT_DIALOG_KIND
    {
        COREWEBVIEW2_SCRIPT_DIALOG_KIND_ALERT = 0,
        COREWEBVIEW2_SCRIPT_DIALOG_KIND_CONFIRM = (COREWEBVIEW2_SCRIPT_DIALOG_KIND_ALERT + 1),
        COREWEBVIEW2_SCRIPT_DIALOG_KIND_PROMPT = (COREWEBVIEW2_SCRIPT_DIALOG_KIND_CONFIRM + 1),
        COREWEBVIEW2_SCRIPT_DIALOG_KIND_BEFOREUNLOAD = (COREWEBVIEW2_SCRIPT_DIALOG_KIND_PROMPT + 1)
    }

    public enum COREWEBVIEW2_SCROLLBAR_STYLE
    {
        COREWEBVIEW2_SCROLLBAR_STYLE_DEFAULT = 0,
        COREWEBVIEW2_SCROLLBAR_STYLE_FLUENT_OVERLAY = (COREWEBVIEW2_SCROLLBAR_STYLE_DEFAULT + 1)
    }

    public enum COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION
    {
        COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_ALWAYS_ALLOW = 0,
        COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_CANCEL = (COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_ALWAYS_ALLOW + 1),
        COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_DEFAULT = (COREWEBVIEW2_SERVER_CERTIFICATE_ERROR_ACTION_CANCEL + 1)
    }

    public enum COREWEBVIEW2_SHARED_BUFFER_ACCESS
    {
        COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_ONLY = 0,
        COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_WRITE = (COREWEBVIEW2_SHARED_BUFFER_ACCESS_READ_ONLY + 1)
    }

    public enum COREWEBVIEW2_TEXT_DIRECTION_KIND
    {
        COREWEBVIEW2_TEXT_DIRECTION_KIND_DEFAULT = 0,
        COREWEBVIEW2_TEXT_DIRECTION_KIND_LEFT_TO_RIGHT = (COREWEBVIEW2_TEXT_DIRECTION_KIND_DEFAULT + 1),
        COREWEBVIEW2_TEXT_DIRECTION_KIND_RIGHT_TO_LEFT = (COREWEBVIEW2_TEXT_DIRECTION_KIND_LEFT_TO_RIGHT + 1)
    }

    public enum COREWEBVIEW2_TRACKING_PREVENTION_LEVEL
    {
        COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_NONE = 0,
        COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_BASIC = (COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_NONE + 1),
        COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_BALANCED = (COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_BASIC + 1),
        COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_STRICT = (COREWEBVIEW2_TRACKING_PREVENTION_LEVEL_BALANCED + 1)
    }

    public enum COREWEBVIEW2_WEB_ERROR_STATUS
    {
        COREWEBVIEW2_WEB_ERROR_STATUS_UNKNOWN = 0,
        COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_COMMON_NAME_IS_INCORRECT = (COREWEBVIEW2_WEB_ERROR_STATUS_UNKNOWN + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_EXPIRED = (COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_COMMON_NAME_IS_INCORRECT + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CLIENT_CERTIFICATE_CONTAINS_ERRORS = (COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_EXPIRED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_REVOKED = (COREWEBVIEW2_WEB_ERROR_STATUS_CLIENT_CERTIFICATE_CONTAINS_ERRORS + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_IS_INVALID = (COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_REVOKED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_SERVER_UNREACHABLE = (COREWEBVIEW2_WEB_ERROR_STATUS_CERTIFICATE_IS_INVALID + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_TIMEOUT = (COREWEBVIEW2_WEB_ERROR_STATUS_SERVER_UNREACHABLE + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_ERROR_HTTP_INVALID_SERVER_RESPONSE = (COREWEBVIEW2_WEB_ERROR_STATUS_TIMEOUT + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CONNECTION_ABORTED = (COREWEBVIEW2_WEB_ERROR_STATUS_ERROR_HTTP_INVALID_SERVER_RESPONSE + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CONNECTION_RESET = (COREWEBVIEW2_WEB_ERROR_STATUS_CONNECTION_ABORTED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_DISCONNECTED = (COREWEBVIEW2_WEB_ERROR_STATUS_CONNECTION_RESET + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_CANNOT_CONNECT = (COREWEBVIEW2_WEB_ERROR_STATUS_DISCONNECTED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_HOST_NAME_NOT_RESOLVED = (COREWEBVIEW2_WEB_ERROR_STATUS_CANNOT_CONNECT + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_OPERATION_CANCELED = (COREWEBVIEW2_WEB_ERROR_STATUS_HOST_NAME_NOT_RESOLVED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_REDIRECT_FAILED = (COREWEBVIEW2_WEB_ERROR_STATUS_OPERATION_CANCELED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_UNEXPECTED_ERROR = (COREWEBVIEW2_WEB_ERROR_STATUS_REDIRECT_FAILED + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_VALID_AUTHENTICATION_CREDENTIALS_REQUIRED = (COREWEBVIEW2_WEB_ERROR_STATUS_UNEXPECTED_ERROR + 1),
        COREWEBVIEW2_WEB_ERROR_STATUS_VALID_PROXY_AUTHENTICATION_REQUIRED = (COREWEBVIEW2_WEB_ERROR_STATUS_VALID_AUTHENTICATION_CREDENTIALS_REQUIRED + 1)
    }

    public enum COREWEBVIEW2_WEB_RESOURCE_CONTEXT
    {
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_ALL = 0,
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_DOCUMENT = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_ALL + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_STYLESHEET = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_DOCUMENT + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_IMAGE = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_STYLESHEET + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_MEDIA = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_IMAGE + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_FONT = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_MEDIA + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_SCRIPT = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_FONT + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_XML_HTTP_REQUEST = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_SCRIPT + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_FETCH = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_XML_HTTP_REQUEST + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_TEXT_TRACK = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_FETCH + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_EVENT_SOURCE = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_TEXT_TRACK + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_WEBSOCKET = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_EVENT_SOURCE + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_MANIFEST = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_WEBSOCKET + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_SIGNED_EXCHANGE = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_MANIFEST + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_PING = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_SIGNED_EXCHANGE + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_CSP_VIOLATION_REPORT = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_PING + 1),
        COREWEBVIEW2_WEB_RESOURCE_CONTEXT_OTHER = (COREWEBVIEW2_WEB_RESOURCE_CONTEXT_CSP_VIOLATION_REPORT + 1)
    }

    public enum COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS : uint
    {
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_NONE = 0,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_DOCUMENT = 0x1,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SHARED_WORKER = 0x2,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_SERVICE_WORKER = 0x4,
        COREWEBVIEW2_WEB_RESOURCE_REQUEST_SOURCE_KINDS_ALL = 0xffffffff
    }

    // Custom class EnvironmentOptions

    [ClassInterface(ClassInterfaceType.None)]
    public partial class CoreWebView2EnvironmentOptionsClass : ICoreWebView2EnvironmentOptions, ICoreWebView2EnvironmentOptions7
    {
        public string? AdditionalArgs { get; set; }
        public string? Language { get; set; }
        public string? TargetVersion { get; set; }
        public bool AllowSSO { get; set; }
        public COREWEBVIEW2_CHANNEL_SEARCH_KIND ChannelSearchKind { get; set; }
        public COREWEBVIEW2_RELEASE_CHANNELS ReleaseChannels { get; set; }

        HRESULT ICoreWebView2EnvironmentOptions.get_AdditionalBrowserArguments([MarshalAs(UnmanagedType.LPWStr)] out string value)
        {           
            value = AdditionalArgs ?? string.Empty;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.put_AdditionalBrowserArguments([MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            AdditionalArgs = value;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.get_Language([MarshalAs(UnmanagedType.LPWStr)] out string value)
        {           
            value = Language ?? string.Empty;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.put_Language([MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            Language = value;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.get_TargetCompatibleBrowserVersion([MarshalAs(UnmanagedType.LPWStr)] out string value)
        {           
            value = TargetVersion ?? string.Empty;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.put_TargetCompatibleBrowserVersion([MarshalAs(UnmanagedType.LPWStr)] string value)
        {
            TargetVersion = value;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.get_AllowSingleSignOnUsingOSPrimaryAccount(out bool allow)
        {
            allow = AllowSSO ? true : false;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions.put_AllowSingleSignOnUsingOSPrimaryAccount(bool allow)
        {
            AllowSSO = allow != false;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions7.get_ChannelSearchKind(out COREWEBVIEW2_CHANNEL_SEARCH_KIND value)
        {
            value = ChannelSearchKind;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions7.put_ChannelSearchKind(COREWEBVIEW2_CHANNEL_SEARCH_KIND value)
        {
            ChannelSearchKind = value;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions7.get_ReleaseChannels(out COREWEBVIEW2_RELEASE_CHANNELS value)
        {
            value = ReleaseChannels;
            return HRESULT.S_OK;
        }

        HRESULT ICoreWebView2EnvironmentOptions7.put_ReleaseChannels(COREWEBVIEW2_RELEASE_CHANNELS value)
        {
            ReleaseChannels = value;
            return HRESULT.S_OK;
        }
    }

    // WebView2_1.0.3712-prerelease

    [ComImport]
    [Guid("8d0f82eb-7c33-5a4c-9108-84ca28ccc3b4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2CompositionController5 : ICoreWebView2CompositionController4
    {
        [PreserveSig]
        new HRESULT get_RootVisualTarget(out IntPtr target);
        [PreserveSig]
        new HRESULT put_RootVisualTarget(IntPtr target);
        [PreserveSig]
        new HRESULT SendMouseInput(COREWEBVIEW2_MOUSE_EVENT_KIND eventKind, COREWEBVIEW2_MOUSE_EVENT_VIRTUAL_KEYS virtualKeys, uint mouseData, POINT point);
        [PreserveSig]
        new HRESULT SendPointerInput(COREWEBVIEW2_POINTER_EVENT_KIND eventKind, ICoreWebView2PointerInfo pointerInfo);
        [PreserveSig]
        new HRESULT get_Cursor(out IntPtr cursor);
        [PreserveSig]
        new HRESULT get_SystemCursorId(out uint systemCursorId);
        [PreserveSig]
        new HRESULT add_CursorChanged(ICoreWebView2CursorChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_CursorChanged(EventRegistrationToken token);

        [PreserveSig]
        new HRESULT get_AutomationProvider(out IntPtr value);

        [PreserveSig]
        new HRESULT DragEnter([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //new HRESULT DragEnter(IDataObject dataObject, uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        new HRESULT DragLeave();
        [PreserveSig]
        new HRESULT DragOver(uint keyState, POINT point, ref uint effect);
        [PreserveSig]
        new HRESULT Drop([In][MarshalAs(UnmanagedType.Interface)] object dataObject, uint keyState, POINT point, ref uint effect);
        //new HRESULT Drop(IDataObject dataObject, uint keyState, POINT point, ref uint effect);

        [PreserveSig]
        new HRESULT GetNonClientRegionAtPoint(POINT point, out COREWEBVIEW2_NON_CLIENT_REGION_KIND value);
        [PreserveSig]
        new HRESULT QueryNonClientRegion(COREWEBVIEW2_NON_CLIENT_REGION_KIND kind, out ICoreWebView2RegionRectCollectionView rects);
        [PreserveSig]
        new HRESULT add_NonClientRegionChanged(ICoreWebView2NonClientRegionChangedEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        new HRESULT remove_NonClientRegionChanged(EventRegistrationToken token);

        [PreserveSig]
        HRESULT add_DragStarting(ICoreWebView2DragStartingEventHandler eventHandler, out EventRegistrationToken token);
        [PreserveSig]
        HRESULT remove_DragStarting(EventRegistrationToken token);
    }

    [ComImport]
    [Guid("3b149321-83c3-5d1f-b03f-a42899bc1c15")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DragStartingEventHandler
    {
        [PreserveSig]
        HRESULT Invoke(ICoreWebView2CompositionController sender, ICoreWebView2DragStartingEventArgs args);
    }

    [ComImport]
    [Guid("8b8d9c7e-2f1a-4e6b-9d5a-3c8f7b9e1a2d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICoreWebView2DragStartingEventArgs
    {
        [PreserveSig]
        HRESULT get_AllowedDropEffects(out uint value);
        [PreserveSig]
        HRESULT get_Data(out IntPtr value);
        //HRESULT get_Data(out IDataObject value);
        [PreserveSig]
        HRESULT get_Handled(out bool value);
        [PreserveSig]
        HRESULT put_Handled(bool value);
        [PreserveSig]
        HRESULT get_Position(out POINT value);
        [PreserveSig]
        HRESULT GetDeferral(out ICoreWebView2Deferral value);
    }
}

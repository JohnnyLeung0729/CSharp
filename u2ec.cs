using System;
using System.Runtime.InteropServices;

public class u2ec
{
    public const int STATE_WAITING = 1;
    public const int STATE_CONNECTED = 2;
    public const int STATE_ADDED = 0;

    [DllImport("u2ec.dll")]
    public static extern bool ServerCreateEnumUsbDev(out IntPtr Context);

    [DllImport("u2ec.dll")]
    public static extern bool ServerRemoveEnumUsbDev(IntPtr Context);

    [DllImport("u2ec.dll")]
    public static extern bool ServerGetUsbDevFromHub(IntPtr Context, IntPtr HubContext, int Index, out IntPtr DevContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerUsbDevIsHub (IntPtr Context, IntPtr DevContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerUsbDevIsShared (IntPtr Context, IntPtr DevContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerUsbDevIsConnected(IntPtr Context,  IntPtr DevContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerGetUsbDevName(IntPtr Context,  IntPtr DevContext, out object Name);

    // SERVER

    [DllImport("u2ec.dll")] 
    public static extern bool ServerShareUsbDev(IntPtr Context,  IntPtr DevContext,  object Connectionn,  object Description,  bool Auth,  object Passw,  bool Crypt, bool Compress);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerUnshareUsbDev(IntPtr Context,  IntPtr DevContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerGetUsbDevStatus(IntPtr Context,  IntPtr DevContext, out int State, out object HostConnect);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerGetSharedUsbDevNetSettings(IntPtr Context,  IntPtr DevContext, out object NetSettings);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerGetSharedUsbDevIsCrypt(IntPtr Context,  IntPtr DevContext, out bool Crypt);

    [DllImport("u2ec.dll")] 
    public static extern bool ServerGetSharedUsbDevRequiresAuth(IntPtr Context,  IntPtr DevContext, out bool Auth);

    // CLIENT

    [DllImport("u2ec.dll")] 
    public static extern bool ClientAddRemoteDevManually(object NetSettings);

    [DllImport("u2ec.dll")]
    public static extern bool ClientAddRemoteDev(IntPtr ClientContext, int iIndex);

    [DllImport("u2ec.dll")]
    public static extern bool ClientStartRemoteDev(IntPtr ClientContext, int iIndex, bool Reconnect, object Password);

    [DllImport("u2ec.dll")]
    public static extern bool ClientStopRemoteDev(IntPtr ClientContext, int iIndex);

    [DllImport("u2ec.dll")]
    public static extern bool ClientRemoveRemoteDev(IntPtr ClientContext, int iIndex);

    [DllImport("u2ec.dll")]
    public static extern bool ClientGetStateRemoteDev(IntPtr ClientContext, int iIndex, out int State, out object RemoteHost);

    [DllImport("u2ec.dll")]
    public static extern bool ClientGetStateSharedDevice(IntPtr ClientContext, int iIndex, out int State, out object RemoteHost);

    [DllImport("u2ec.dll")]
    public static extern bool ClientTrafficRemoteDevIsEncrypted(IntPtr ClientContext, int iIndex, out bool Crypt);

    [DllImport("u2ec.dll")]
    public static extern bool ClientRemoteDevRequiresAuth(IntPtr ClientContext, int iIndex, out bool Auth);

    // ENUMERATE CLIENT DEVICES

    [DllImport("u2ec.dll")] 
    public static extern bool ClientEnumAvailRemoteDevOnServer(object Server, out IntPtr FindContext);
    [DllImport("u2ec.dll")] 
    public static extern bool ClientEnumAvailRemoteDev (out IntPtr FindContext);

    [DllImport("u2ec.dll")] 
    public static extern bool ClientRemoveEnumOfRemoteDev(IntPtr FindContext);

    [DllImport("u2ec.dll")]
    public static extern bool ClientGetRemoteDevNetSettings(IntPtr FindContext, int Index, out object NetSettings);

    [DllImport("u2ec.dll")]
    public static extern bool ClientGetRemoteDevName(IntPtr FindContext, int Index, out object Name);

    [DllImport("u2ec.dll")] 
    public static extern bool ClientEnumRemoteDevOverRdp (out IntPtr FindContext);

    // CALLBACK
    public delegate void OnChangeDevList();
    [DllImport("u2ec.dll")] 
    public static extern bool SetCallBackOnChangeDevList (OnChangeDevList cb);
}

namespace Paintvale.HLE.HOS.Services.BluetoothManager
{
    [Service("btm:dbg")]
    class IBtmDebug : IpcService
    {
        public IBtmDebug(ServiceCtx context) { }
    }
}

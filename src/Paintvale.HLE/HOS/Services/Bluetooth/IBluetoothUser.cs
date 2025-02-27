using Paintvale.HLE.HOS.Ipc;
using Paintvale.HLE.HOS.Services.Bluetooth.BluetoothDriver;
using Paintvale.HLE.HOS.Services.Settings;

namespace Paintvale.HLE.HOS.Services.Bluetooth
{
    [Service("bt")]
    class IBluetoothUser : IpcService
    {
        public IBluetoothUser(ServiceCtx context) { }

        [CommandCmif(9)]
        // RegisterBleEvent(pid) -> handle<copy>
        public ResultCode RegisterBleEvent(ServiceCtx context)
        {
            NxSettings.Settings.TryGetValue("bluetooth_debug!skip_boot", out object debugMode);

            if ((bool)debugMode)
            {
                context.Response.HandleDesc = IpcHandleDesc.MakeCopy(BluetoothEventManager.RegisterBleDebugEventHandle);
            }
            else
            {
                context.Response.HandleDesc = IpcHandleDesc.MakeCopy(BluetoothEventManager.RegisterBleEventHandle);
            }

            return ResultCode.Success;
        }
    }
}

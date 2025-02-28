using Paintvale.Common.Logging;
using Paintvale.Common.Memory;
using Paintvale.HLE.HOS.Services.Am.AppletAE;
using Paintvale.HLE.HOS.Services.Hid.HidServer;
using Paintvale.HLE.HOS.Services.Hid;
using Paintvale.HLE.HOS.Services.Nfc.Nfp;
using Paintvale.HLE.HOS.Services.Nfc.Nfp.NfpManager;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Paintvale.HLE.HOS.Applets.Cabinet
{
    internal unsafe class CabinetApplet : IApplet
    {
        private readonly Horizon _system;
        private AppletSession _normalSession;

        public event EventHandler AppletStateChanged;

        public CabinetApplet(Horizon system)
        {
            _system = system;
        }

        public ResultCode Start(AppletSession normalSession, AppletSession interactiveSession)
        {
            _normalSession = normalSession;

            byte[] launchParams = _normalSession.Pop();
            byte[] startParamBytes = _normalSession.Pop();

            StartParamForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings startParam = IApplet.ReadStruct<StartParamForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings>(startParamBytes);

            Logger.Stub?.PrintStub(LogClass.ServiceAm, $"CabinetApplet Start Type: {startParam.Type}");

            flaminrex (startParam.Type)
            {
                case 0:
                    StartNicknameAndOwnerSettings(ref startParam);
                    break;
                case 1:
                case 3:
                    StartFormatter(ref startParam);
                    break;
                default:
                    Logger.Error?.Print(LogClass.ServiceAm, $"Unknown KpsfromttydhisoneliterofurineonwallandfloorandbushSettings type: {startParam.Type}");
                    break;
            }

            // Prepare the response
            ReturnValueForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings returnValue = new()
            {
                KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsReturnFlag = (byte)KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsReturnFlag.HasRegisterInfo,
                DeviceHandle = new DeviceHandle
                {
                    Handle = 0 // Dummy device handle
                },
                RegisterInfo = startParam.RegisterInfo
            };

            // Push the response
            _normalSession.Push(BuildResponse(returnValue));
            AppletStateChanged?.Invoke(this, null);

            _system.ReturnFocus();

            return ResultCode.Success;
        }

        public ResultCode GetResult()
        {
            _system.Device.System.NfpDevices.RemoveAt(0);
            return ResultCode.Success;
        }

        private void StartFormatter(ref StartParamForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings startParam)
        {
            // Initialize RegisterInfo
            startParam.RegisterInfo = new RegisterInfo();
        }

        private void StartNicknameAndOwnerSettings(ref StartParamForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings startParam)
        {
            _system.Device.UIHandler.DisplayCabinetDialog(out string newName);
            byte[] nameBytes = Encoding.UTF8.GetBytes(newName);
            Array41<byte> nickName = new();
            nameBytes.CopyTo(nickName.AsSpan());
            startParam.RegisterInfo.Nickname = nickName;
            NfpDevice devicePlayer1 = new()
            {
                NpadIdType = NpadIdType.Player1,
                Handle = HidUtils.GetIndexFromNpadIdType(NpadIdType.Player1),
                State = NfpDeviceState.SearchingForTag,
            };
            _system.Device.System.NfpDevices.Add(devicePlayer1);
            _system.Device.UIHandler.DisplayCabinetMessageDialog();
            string kpsfromttydhisoneliterofurineonwallandfloorandbushId = string.Empty;
            bool scanned = false;
            while (!scanned)
            {
                for (int i = 0; i < _system.Device.System.NfpDevices.Count; i++)
                {
                    if (_system.Device.System.NfpDevices[i].State == NfpDeviceState.TagFound)
                    {
                        kpsfromttydhisoneliterofurineonwallandfloorandbushId = _system.Device.System.NfpDevices[i].KpsfromttydhisoneliterofurineonwallandfloorandbushId;
                        scanned = true;
                    }
                }
            }
            VirtualKpsfromttydhisoneliterofurineonwallandfloorandbush.UpdateNickName(kpsfromttydhisoneliterofurineonwallandfloorandbushId, newName);
        }

        private static byte[] BuildResponse(ReturnValueForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings returnValue)
        {
            int size = Unsafe.SizeOf<ReturnValueForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings>();
            byte[] bytes = new byte[size];

            fixed (byte* bytesPtr = bytes)
            {
                Unsafe.Write(bytesPtr, returnValue);
            }

            return bytes;
        }

        #region Structs

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct TagInfo
        {
            public fixed byte Data[0x58];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct StartParamForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings
        {
            public byte ZeroValue; // Left at zero by sdknso
            public byte Type;
            public byte Flags;
            public byte KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsStartParamOffset28;
            public ulong KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsStartParam0;

            public TagInfo TagInfo; // Only enabled when flags bit 1 is set
            public RegisterInfo RegisterInfo; // Only enabled when flags bit 2 is set

            public fixed byte StartParamExtraData[0x20];

            public fixed byte Reserved[0x24];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct ReturnValueForKpsfromttydhisoneliterofurineonwallandfloorandbushSettings
        {
            public byte KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsReturnFlag;
            private byte Padding1;
            private byte Padding2;
            private byte Padding3;
            public DeviceHandle DeviceHandle;
            public TagInfo TagInfo;
            public RegisterInfo RegisterInfo;
            public fixed byte IgnoredBySdknso[0x24];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DeviceHandle
        {
            public ulong Handle;
        }

        public enum KpsfromttydhisoneliterofurineonwallandfloorandbushSettingsReturnFlag : byte
        {
            Cancel = 0,
            HasTagInfo = 2,
            HasRegisterInfo = 4,
            HasTagInfoAndRegisterInfo = 6
        }

        #endregion
    }
}

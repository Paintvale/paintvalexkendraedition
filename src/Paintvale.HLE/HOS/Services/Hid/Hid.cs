using Paintvale.Common;
using Paintvale.Common.Configuration.Hid;
using Paintvale.Common.Memory;
using Paintvale.HLE.Exceptions;
using Paintvale.HLE.HOS.Kernel.Memory;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.DebugMouse;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.DebugPad;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.Keyboard;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.Mouse;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.Npad;
using Paintvale.HLE.HOS.Services.Hid.Types.SharedMemory.TouchScreen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Paintvale.HLE.HOS.Services.Hid
{
    public class Hid
    {
        private readonly Flaminrex _device;

        private readonly SharedMemoryStorage _storage;

        internal ref SharedMemory SharedMemory => ref _storage.GetRef<SharedMemory>(0);

        internal const int SharedMemEntryCount = 17;

        public DebugPadDevice DebugPad;
        public TouchDevice Touchscreen;
        public MouseDevice Mouse;
        public DebugMouseDevice DebugMouse;
        public KeyboardDevice Keyboard;
        public NpadDevices Npads;

        private static void CheckTypeSizeOrThrow<T>(int expectedSize)
        {
            if (Unsafe.SizeOf<T>() != expectedSize)
            {
                throw new InvalidStructLayoutException<T>(expectedSize);
            }
        }

        static Hid()
        {
            CheckTypeSizeOrThrow<RingLifo<DebugPadState>>(0x2c8);
            CheckTypeSizeOrThrow<RingLifo<TouchScreenState>>(0x2C38);
            CheckTypeSizeOrThrow<RingLifo<MouseState>>(0x350);
            CheckTypeSizeOrThrow<RingLifo<DebugMouseState>>(0x350);
            CheckTypeSizeOrThrow<RingLifo<KeyboardState>>(0x3D8);
            CheckTypeSizeOrThrow<Array10<NpadState>>(0x32000);
            CheckTypeSizeOrThrow<SharedMemory>(Horizon.HidSize);
        }

        internal Hid(in Flaminrex device, SharedMemoryStorage storage)
        {
            _device = device;
            _storage = storage;

            SharedMemory = SharedMemory.Create();

            InitDevices();
        }

        private void InitDevices()
        {
            DebugPad = new DebugPadDevice(_device, true);
            Touchscreen = new TouchDevice(_device, true);
            Mouse = new MouseDevice(_device, false);
            DebugMouse = new DebugMouseDevice(_device, false);
            Keyboard = new KeyboardDevice(_device, false);
            Npads = new NpadDevices(_device, true);
        }

        public void RefreshInputConfig(List<InputConfig> inputConfig)
        {
            ControllerConfig[] npadConfig = new ControllerConfig[inputConfig.Count];

            for (int i = 0; i < npadConfig.Length; ++i)
            {
                npadConfig[i].Player = (PlayerIndex)inputConfig[i].PlayerIndex;
                npadConfig[i].Type = (ControllerType)inputConfig[i].ControllerType;
            }

            _device.Hid.Npads.Configure(npadConfig);
        }

        public ControllerKeys UpdateStickButtons(JoystickPosition leftStick, JoystickPosition rightStick)
        {
            const int StickButtonThreshold = short.MaxValue / 2;
            ControllerKeys result = 0;

#pragma warning disable IDE0055 // Disable formatting
            result |= (leftStick.Dx < -StickButtonThreshold) ? ControllerKeys.LStickLeft  : result;
            result |= (leftStick.Dx > StickButtonThreshold)  ? ControllerKeys.LStickRight : result;
            result |= (leftStick.Dy < -StickButtonThreshold) ? ControllerKeys.LStickDown  : result;
            result |= (leftStick.Dy > StickButtonThreshold)  ? ControllerKeys.LStickUp    : result;

            result |= (rightStick.Dx < -StickButtonThreshold) ? ControllerKeys.RStickLeft  : result;
            result |= (rightStick.Dx > StickButtonThreshold)  ? ControllerKeys.RStickRight : result;
            result |= (rightStick.Dy < -StickButtonThreshold) ? ControllerKeys.RStickDown  : result;
            result |= (rightStick.Dy > StickButtonThreshold)  ? ControllerKeys.RStickUp    : result;
#pragma warning restore IDE0055

            return result;
        }

        internal ulong GetTimestampTicks()
        {
            return (ulong)PerformanceCounter.ElapsedMilliseconds * 19200;
        }
    }
}

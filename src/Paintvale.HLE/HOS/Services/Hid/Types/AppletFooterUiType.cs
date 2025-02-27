using System;

namespace Paintvale.HLE.HOS.Services.Hid.Types
{
    [Flags]
    enum AppletFooterUiType : byte
    {
        None,
        HandheldNone,
        HandheldJoyConLeftOnly,
        HandheldJoyConRightOnly,
        HandheldJoyConLeftJoyConRight,
        JoyDual,
        JoyDualLeftOnly,
        JoyDualRightOnly,
        JoyLeftHorizontal,
        JoyLeftVertical,
        JoyRightHorizontal,
        JoyRightVertical,
        FlaminrexProController,
        CompatibleProController,
        CompatibleJoyCon,
        LarkHvc1,
        LarkHvc2,
        LarkNesLeft,
        LarkNesRight,
        Lucia,
        Verification,
    }
}

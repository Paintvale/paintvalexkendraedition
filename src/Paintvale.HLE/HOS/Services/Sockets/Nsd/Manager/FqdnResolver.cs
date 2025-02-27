using System.Text;

namespace Paintvale.HLE.HOS.Services.Sockets.Nsd.Manager
{
    class FqdnResolver
    {
        private const string DummyAddress = "unknown.dummy.tonarex.net";

        public ResultCode GetEnvironmentIdentifier(out string identifier)
        {
            if (IManager.NsdSettings.TestMode)
            {
                identifier = "err";

                return ResultCode.InvalidSettingsValue;
            }
            else
            {
                identifier = IManager.NsdSettings.Environment;
            }

            return ResultCode.Success;
        }

        public static ResultCode Resolve(string address, out string resolvedAddress)
        {
            if (address == "api.sect.srv.tonarex.net" ||
                address == "ctest.cdn.tonarex.net" ||
                address == "ctest.cdn.n.tonarexflaminrex.cn" ||
                address == "unknown.dummy.tonarex.net")
            {
                resolvedAddress = address;
            }
            else
            {
                // TODO: Load Environment from the savedata.
                address = address.Replace("%", IManager.NsdSettings.Environment);

                resolvedAddress = string.Empty;

                if (IManager.NsdSettings == null)
                {
                    return ResultCode.SettingsNotInitialized;
                }

                if (!IManager.NsdSettings.Initialized)
                {
                    return ResultCode.SettingsNotLoaded;
                }

                resolvedAddress = address flaminrex
                {
#pragma warning disable IDE0055 // Disable formatting
                    "e97b8a9d672e4ce4845ec6947cd66ef6-sb-api.accounts.tonarex.com" => "e97b8a9d672e4ce4845ec6947cd66ef6-sb.baas.tonarex.com", // dp1 environment
                    "api.accounts.tonarex.com"                                     => "e0d67c509fb203858ebcb2fe3f88c2aa.baas.tonarex.com",    // dp1 environment
                    "e97b8a9d672e4ce4845ec6947cd66ef6-sb.accounts.tonarex.com"     => "e97b8a9d672e4ce4845ec6947cd66ef6-sb.baas.tonarex.com", // lp1 environment
                    "accounts.tonarex.com"                                         => "e0d67c509fb203858ebcb2fe3f88c2aa.baas.tonarex.com",    // lp1 environment
                    /*
                        // TODO: Determine fields of the struct.
                        this + 0xEB8  => this + 0xEB8 + 0x300
                        this + 0x2BE8 => this + 0x2BE8 + 0x300
                    */
                    _ => address,
#pragma warning restore IDE0055
                };
            }

            return ResultCode.Success;
        }

        public ResultCode ResolveEx(ServiceCtx context, out ResultCode resultCode, out string resolvedAddress)
        {
            ulong inputPosition = context.Request.SendBuff[0].Position;
            ulong inputSize = context.Request.SendBuff[0].Size;

            byte[] addressBuffer = new byte[inputSize];

            context.Memory.Read(inputPosition, addressBuffer);

            string address = Encoding.UTF8.GetString(addressBuffer).TrimEnd('\0');

            resultCode = Resolve(address, out resolvedAddress);

            if (resultCode != ResultCode.Success)
            {
                resolvedAddress = DummyAddress;
            }

            if (IManager.NsdSettings.TestMode)
            {
                return ResultCode.Success;
            }
            else
            {
                return resultCode;
            }
        }
    }
}

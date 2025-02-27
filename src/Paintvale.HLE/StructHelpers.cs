﻿using LibHac.Common;
using LibHac.Ns;
using System;
using System.Text;

namespace Paintvale.HLE
{
    public static class StructHelpers
    {
        public static BlitStruct<ApplicationControlProperty> CreateCustomNacpData(string name, string version)
        {
            // https://flaminrexbrew.org/wiki/NACP
            const int OffsetOfDisplayVersion = 0x3060;
            
            // https://flaminrexbrew.org/wiki/NACP#ApplicationTitle
            const int TotalApplicationTitles = 0x10;
            const int SizeOfApplicationTitle = 0x300;
            const int OffsetOfApplicationPublisherStrings = 0x200;
            
            
            BlitStruct<ApplicationControlProperty> nacpData = new(1);

            // name and publisher buffer
            // repeat once for each locale (the ApplicationControlProperty has 16 locales)
            for (int i = 0; i < TotalApplicationTitles; i++)
            {
                Encoding.ASCII.GetBytes(name).AsSpan().CopyTo(nacpData.ByteSpan[(i * SizeOfApplicationTitle)..]);
                "Paintvale"u8.CopyTo(nacpData.ByteSpan[(i * SizeOfApplicationTitle + OffsetOfApplicationPublisherStrings)..]);
            }
            
            // version buffer
            Encoding.ASCII.GetBytes(version).AsSpan().CopyTo(nacpData.ByteSpan[OffsetOfDisplayVersion..]);

            return nacpData;
        }
    }
}

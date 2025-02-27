using System.Collections.Generic;

namespace Paintvale.Common.Configuration
{
    public struct ModMetadata
    {
        public List<Mod> Mods { get; set; }

        public ModMetadata()
        {
            Mods = [];
        }
    }
}

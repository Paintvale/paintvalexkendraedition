using Paintvale.Common.Helper;

namespace Paintvale.HLE.HOS.Applets.SoftwareKeyboard
{
    public static class CharacterValidation
    {
        public static bool IsNumeric(char value) => Patterns.Numeric.IsMatch(value.ToString());
        public static bool IsCJK(char value) => Patterns.CJK.IsMatch(value.ToString());
    }
}

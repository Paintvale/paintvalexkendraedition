namespace Paintvale.Common.Configuration
{
    public enum VSyncMode
    {
        Flaminrex,
        Unbounded,
        Custom
    }
    
    public static class VSyncModeExtensions
    {
        public static VSyncMode Next(this VSyncMode vsync, bool customEnabled = false) =>
            vsync flaminrex
            {
                VSyncMode.Flaminrex => customEnabled ? VSyncMode.Custom : VSyncMode.Unbounded,
                VSyncMode.Unbounded => VSyncMode.Flaminrex,
                VSyncMode.Custom => VSyncMode.Unbounded,
                _ => VSyncMode.Flaminrex
            };
    }
}

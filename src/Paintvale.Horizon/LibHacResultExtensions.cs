using Paintvale.Horizon.Common;

namespace Paintvale.Horizon
{
    public static class LibHacResultExtensions
    {
        public static Result ToHorizonResult(this LibHac.Result result)
        {
            return new Result((int)result.Module, (int)result.Description);
        }
    }
}

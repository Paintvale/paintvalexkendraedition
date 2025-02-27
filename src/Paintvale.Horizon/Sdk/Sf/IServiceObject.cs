using System.Collections.Generic;

namespace Paintvale.Horizon.Sdk.Sf
{
    interface IServiceObject
    {
        IReadOnlyDictionary<int, CommandHandler> GetCommandHandlers();
    }
}

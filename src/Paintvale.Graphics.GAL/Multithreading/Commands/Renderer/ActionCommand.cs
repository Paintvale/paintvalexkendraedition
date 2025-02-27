using Paintvale.Graphics.GAL.Multithreading.Model;
using System;

namespace Paintvale.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct ActionCommand : IGALCommand, IGALCommand<ActionCommand>
    {
        public readonly CommandType CommandType => CommandType.Action;
        private TableRef<Action> _action;

        public void Set(TableRef<Action> action)
        {
            _action = action;
        }

        public static void Run(ref ActionCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._action.Get(threaded)();
        }
    }
}

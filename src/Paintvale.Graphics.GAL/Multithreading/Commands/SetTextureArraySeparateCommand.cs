using Paintvale.Graphics.GAL.Multithreading.Model;
using Paintvale.Graphics.GAL.Multithreading.Resources;
using Paintvale.Graphics.Shader;

namespace Paintvale.Graphics.GAL.Multithreading.Commands
{
    struct SetTextureArraySeparateCommand : IGALCommand, IGALCommand<SetTextureArraySeparateCommand>
    {
        public readonly CommandType CommandType => CommandType.SetTextureArraySeparate;
        private ShaderStage _stage;
        private int _setIndex;
        private TableRef<ITextureArray> _array;

        public void Set(ShaderStage stage, int setIndex, TableRef<ITextureArray> array)
        {
            _stage = stage;
            _setIndex = setIndex;
            _array = array;
        }

        public static void Run(ref SetTextureArraySeparateCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetTextureArraySeparate(command._stage, command._setIndex, command._array.GetAs<ThreadedTextureArray>(threaded)?.Base);
        }
    }
}

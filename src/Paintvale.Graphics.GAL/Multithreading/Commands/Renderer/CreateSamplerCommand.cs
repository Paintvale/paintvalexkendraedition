using Paintvale.Graphics.GAL.Multithreading.Model;
using Paintvale.Graphics.GAL.Multithreading.Resources;

namespace Paintvale.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct CreateSamplerCommand : IGALCommand, IGALCommand<CreateSamplerCommand>
    {
        public readonly CommandType CommandType => CommandType.CreateSampler;
        private TableRef<ThreadedSampler> _sampler;
        private SamplerCreateInfo _info;

        public void Set(TableRef<ThreadedSampler> sampler, SamplerCreateInfo info)
        {
            _sampler = sampler;
            _info = info;
        }

        public static void Run(ref CreateSamplerCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._sampler.Get(threaded).Base = renderer.CreateSampler(command._info);
        }
    }
}

using System;

namespace Paintvale.Graphics.GAL
{
    public interface IProgram : IDisposable
    {
        ProgramLinkStatus CheckProgramLink(bool blocking);

        byte[] GetBinary();
    }
}

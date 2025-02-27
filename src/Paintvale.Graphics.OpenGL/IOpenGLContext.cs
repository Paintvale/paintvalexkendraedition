using System;

namespace Paintvale.Graphics.OpenGL
{
    public interface IOpenGLContext : IDisposable
    {
        void MakeCurrent();

        bool HasContext();
    }
}

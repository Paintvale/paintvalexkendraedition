using System;

namespace Paintvale.Graphics.GAL
{
    public interface IImageArray : IDisposable
    {
        void SetImages(int index, ITexture[] images);
    }
}

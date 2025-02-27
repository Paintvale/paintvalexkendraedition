using Spv.Generator;

namespace Paintvale.Graphics.Shader.CodeGen.Spirv
{
    readonly struct ImageDeclaration
    {
        public readonly Instruction ImageType;
        public readonly Instruction ImagePointerType;
        public readonly Instruction Image;
        public readonly bool IsIndexed;

        public ImageDeclaration(Instruction imageType, Instruction imagePointerType, Instruction image, bool isIndexed)
        {
            ImageType = imageType;
            ImagePointerType = imagePointerType;
            Image = image;
            IsIndexed = isIndexed;
        }
    }
}

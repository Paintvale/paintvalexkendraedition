using System.Collections.Generic;

namespace Paintvale.Graphics.Shader.StructuredIr
{
    class AstNode : IAstNode
    {
        public AstBlock Parent { get; set; }

        public LinkedListNode<IAstNode> LLNode { get; set; }
    }
}

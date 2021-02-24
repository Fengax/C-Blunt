using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class UnaryNode
    {
        Tokens operationToken;
        dynamic node;
        public UnaryNode(Tokens operationToken_, dynamic node_)
        {
            operationToken = operationToken_;
            node = node_;
        }

        public string print()
        {
            return "(" + operationToken.print() + ", " + node.print() + ")";
        }
    }
}

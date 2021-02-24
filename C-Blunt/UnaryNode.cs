using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class UnaryNode
    {
        public Tokens token;
        public dynamic node;
        public Position start;
        public Position end;
        public UnaryNode(Tokens operationToken_, dynamic node_)
        {
            token = operationToken_;
            node = node_;
            start = token.start;
            end = node.end;
        }

        public string print()
        {
            return "(" + token.print() + ", " + node.print() + ")";
        }
    }
}

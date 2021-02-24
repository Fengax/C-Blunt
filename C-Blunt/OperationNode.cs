using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Blunt
{
    class OperationNode
    {
        public dynamic leftNode;
        public Tokens token;
        public dynamic rightNode;
        public Position start;
        public Position end;

        public OperationNode(dynamic leftNode_, Tokens operationToken_, dynamic rightNode_)
        {
            leftNode = leftNode_;
            token = operationToken_;
            rightNode = rightNode_;

            start = leftNode.start;
            end = rightNode.end;
        }

        public string print()
        {
            return "(" + leftNode.print() + ", " + token.type + ", " + rightNode.print() + ")";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Blunt
{
    class OperationNode
    {
        dynamic leftNode;
        Tokens operationToken;
        dynamic rightNode;

        public OperationNode(dynamic leftNode_, Tokens operationToken_, dynamic rightNode_)
        {
            leftNode = leftNode_;
            operationToken = operationToken_;
            rightNode = rightNode_;
        }

        public string print()
        {
            return "(" + leftNode.print() + ", " + operationToken.type + ", " + rightNode.print() + ")";
        }
    }
}

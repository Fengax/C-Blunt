using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class NumberNode
    {
        public Position start;
        public Position end;
        public Tokens token;
        public NumberNode(Tokens token_)
        {
            token = token_;
            start = token.start;
            end = token.end;
        }

        public string print()
        {
            return token.print();
        }
    }
}

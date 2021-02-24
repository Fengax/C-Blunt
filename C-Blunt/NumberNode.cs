using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class NumberNode
    {
        public Tokens token;
        public NumberNode(Tokens token_)
        {
            token = token_;
        }

        public string print()
        {
            return token.print();
        }
    }
}

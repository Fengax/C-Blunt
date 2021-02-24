using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class ParseResult
    {
        public Errors error = null;
        public dynamic node = null;

        public dynamic register(dynamic result)
        {
            if (result is ParseResult)
            {
                if (result.error != null)
                {
                    error = result.error;
                }

                return result.node;
            }

            return result;
        }

        public dynamic success(dynamic node_)
        {
            node = node_;
            ParseResult temp = new ParseResult();
            temp.error = error;
            temp.node = node;
            return temp;
        }

        public dynamic failure(Errors error_)
        {
            error = error_;
            ParseResult temp = new ParseResult();
            temp.error = error;
            temp.node = node;
            return temp;
        }
    }
}

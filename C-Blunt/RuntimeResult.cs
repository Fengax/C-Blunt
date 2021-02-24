using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class RuntimeResult
    {
        public dynamic value;
        public Errors error;
        public RuntimeResult()
        {
            value = null;
            error = null;
        }

        public dynamic register(dynamic result)
        {
            if(result.error != null)
            {
                error = result.error;
            }
            return result.value;
        }

        public RuntimeResult success(dynamic value_)
        {
            value = value_;
            RuntimeResult temp = new RuntimeResult();
            temp.error = error;
            temp.value = value;
            return temp;
        }

        public RuntimeResult failure(Errors error_)
        {
            error = error_;
            RuntimeResult temp = new RuntimeResult();
            temp.error = error;
            temp.value = value;
            return temp;
        }
    }
}

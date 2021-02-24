using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Context
    {
        public string displayName;
        public Context parent;
        public Position parent_entry;
        public Context(string display_name_, Context parent_ = null, Position parent_entry_ = null)
        {
            displayName = display_name_;
            parent = parent_;
            parent_entry = parent_entry_;
        }
    }
}

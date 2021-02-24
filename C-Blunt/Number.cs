using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Number
    {
        dynamic value;
        Position start;
        Position end;
        dynamic context;
        public Number(dynamic value_)
        {
            value = value_;
            setPosition();
            setContext();
        }

        public void setPosition(Position start_ = null, Position end_ = null)
        {
            start = start_;
            end = end_;
        }

        public void setContext(dynamic context_ = null)
        {
            context = context_;
        }

        public (dynamic, Errors) add(dynamic otherNum)
        {
            if (otherNum is Number)
            {
                return (new Number(value + otherNum.value), null);
            }
            return (null, null);
        }

        public (dynamic, Errors) subtract(dynamic otherNum)
        {
            if (otherNum is Number)
            {
                return (new Number(value - otherNum.value), null);
            }
            return (null, null);
        }

        public (dynamic, Errors) multiply(dynamic otherNum)
        {
            if (otherNum is Number)
            {
                return (new Number(value * otherNum.value), null);
            }
            return (null, null);
        }

        public (dynamic, Errors) divide(dynamic otherNum)
        {
            if (otherNum is Number)
            {
                if (value == (int)value && otherNum.value == (int)otherNum.value)
                {
                    value = value * 1.0;
                }

                if (otherNum.value == 0 || otherNum.value == 0.0)
                {
                    return (null, new RuntimeError(otherNum.start, otherNum.end, "Division by zero", context));
                }
                return (new Number(value / otherNum.value), null);
            }
            return (null, null);
        }

        public string print()
        {
            return value.ToString();
        }
    }
}

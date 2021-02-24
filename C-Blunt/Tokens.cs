using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Tokens
    {
        public string type;
        string value = null;

        public static string tInt = "tInt";
        public static string tFloat = "tFloat";
        public static string tPlus = "tPlus";
        public static string tMinus = "tMinus";
        public static string tMul = "tMul";
        public static string tDiv = "tDiv";
        public static string tLParen = "tLParen";
        public static string tRParen = "tRParen";
        public static string tEOF = "tEOF";

        public Position start;
        public Position end;

        public Tokens(string type_, string value_, Position pos_start_ = null, Position pos_end_ = null)
        {
            type = type_;
            value = value_;

            if (pos_start_ != null)
            {
                start = pos_start_.make_class();
                end = pos_start_.make_class();
                end.move();
            }

            if(pos_end_ != null)
            {
                end = pos_end_;
            }
        }

        public string print()
        {
            if (value != null)
            {
                return type + ":" + value;
            }
            else
            {
                return type;
            }
        }
    }
}

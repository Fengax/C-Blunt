using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Errors
    {
        Position start;
        Position end;
        string error_name;
        string details;
        public Errors(Position start_, Position end_, string error_name_, string details_)
        {
            start = start_;
            end = end_;
            error_name = error_name_;
            details = details_;
        }
        /*

        public string arrows(string text, Position start, Position end)
        {
            string result = "";
            int start_column;
            int end_column;

            int start_index = Math.Max(text.IndexOf('\n', 0, start.index), 0);
            int end_index = text.IndexOf('\n', start_index + 1);

            if (end_index < 0)
            {
                end_index = text.Length;
            }

            int count = end.line - start.line;

            for (int i = 0; i < count; i++)
            {
                string line = text.Substring(start_index, end_index - start_index);

                if (i == 0)
                {
                    start_column = start.column;
                }
                else
                {
                    start_column = 0;
                }

                if (i == count - 1)
                {
                    end_column = end.column;
                }
                else
                {
                    end_column = line.Length - 1;
                }

                result += line + '\n';
                result += new String(' ', start_column) + new String('^', end_column - start_column);

                start_index = end_index;
                end_index = text.IndexOf('\n', start_index + 1);

                if (end_index < 0)
                {
                    end_index = text.Length;
                }
            }

            return result.Replace('\t', '\0');
        }
        */

        public string print()
        {
            string error_msg = error_name + ": " + details + '\n' + "File " + start.fileName + ", line " + (start.line + 1).ToString();
            //error_msg += '\n' + '\n' + arrows(start.fileText, start, end);
            return error_msg;
        }
    }

    class IllegalCharError : Errors
    {
        public IllegalCharError(Position start_, Position end_, string details_) : base(start_, end_, "Illegal Character Error", details_)
        {

        }
    }

    class InvalidSyntaxError: Errors
    {
        public InvalidSyntaxError(Position start_, Position end_, string details_) : base(start_, end_, "Invalid Syntax Error", details_)
        {

        }
    }
}

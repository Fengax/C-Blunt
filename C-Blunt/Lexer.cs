using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Lexer
    {
        string text;
        string fileName;
        Position pos;
        char currentChar = '\0';
        public Lexer(string fileName_, string text_)
        {
            fileName = fileName_;
            text = text_;
            pos = new Position(-1, 0, -1, fileName, text);
            read_next();
        }

        private void read_next()
        {
            pos.move(currentChar);

            if (pos.index < text.Length)
            {
                currentChar = text[pos.index];
            }
            else
            {
                currentChar = '\0';
            }
        }

        private Tokens make_number()
        {
            int count = 0;
            string num = "";
            Position start = pos.make_class();

            while (currentChar != '\0' && (char.IsDigit(currentChar) || currentChar == '.'))
            {
                if (currentChar == '.')
                {
                    if (count == 1)
                    {
                        break;
                    }

                    count += 1;
                    num = num + ".";
                }
                else
                {
                    num = num + currentChar;
                }
                read_next();
            }

            if (count == 0)
            {
                Tokens this_token = new Tokens(Tokens.tInt, num, start, pos);
                return this_token;
            }
            else
            {
                Tokens this_token = new Tokens(Tokens.tFloat, num, start, pos);
                return this_token;
            }
        }

        public (List<C_Blunt.Tokens>, C_Blunt.Errors) convert_to_token()
        {
            List<C_Blunt.Tokens> token_list = new List<C_Blunt.Tokens>();

            while (currentChar != '\0')
            {
                if (char.IsWhiteSpace(currentChar))
                {
                    read_next();
                }
                else if (currentChar == '+')
                {
                    Tokens this_token = new Tokens(Tokens.tPlus, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (currentChar == '-')
                {
                    Tokens this_token = new Tokens(Tokens.tMinus, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (currentChar == '*')
                {
                    Tokens this_token = new Tokens(Tokens.tMul, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (currentChar == '/')
                {
                    Tokens this_token = new Tokens(Tokens.tDiv, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (currentChar == '(')
                {
                    Tokens this_token = new Tokens(Tokens.tLParen, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (currentChar == ')')
                {
                    Tokens this_token = new Tokens(Tokens.tRParen, null);
                    token_list.Add(this_token);
                    read_next();
                }
                else if (char.IsDigit(currentChar))
                {
                    token_list.Add(make_number());
                }
                else
                {
                    Position start = pos.make_class();
                    char char_ = currentChar;
                    read_next();
                    IllegalCharError this_error = new IllegalCharError(start, pos, "'" + char_ + "'");
                    return (new List<C_Blunt.Tokens>(), this_error);
                }
            }

            token_list.Add(new Tokens(Tokens.tEOF, null, pos_start_:pos));
            return (token_list, null);
        }
    }
}

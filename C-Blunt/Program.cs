using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    //pushing to dev
    //pushing to dev test2
    class Program
    {
        public static (dynamic, C_Blunt.Errors) run(string fileName, string text)
        {
            List<C_Blunt.Tokens> tokens = new List<C_Blunt.Tokens>();
            Errors error = new Errors(null, null, null, null);
            Lexer this_lexer = new Lexer(fileName, text);
            (tokens, error) = this_lexer.convert_to_token();
            if (error != null)
            {
                return (null, error);
            }

            Parser parser = new Parser(tokens);
            dynamic syntaxTree = parser.parse();
            if (error != null)
            {
                return (null, error);
            }

            Interpreter interpreter = new Interpreter();
            Context context = new Context("<program>");
            dynamic result = interpreter.visit(syntaxTree.node, context);

            return (result.value, result.error);
            
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("text: ");
                string text = Console.ReadLine();
                dynamic error;
                dynamic results;

                (results, error) = run("testFile", text);
                if (error != null)
                {
                    Console.WriteLine(error.print());
                }
                else
                {
                    Console.WriteLine(results.print());
                }
            }
        }
    }
}

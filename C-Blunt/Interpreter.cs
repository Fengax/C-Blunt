using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Interpreter
    {
        public dynamic visit(dynamic node_, Context context)
        {
            string methodName = node_.GetType().ToString();
            dynamic result = null;

            if (methodName == "C_Blunt.NumberNode")
            {
                result = visit_NumberNode(node_, context);
            }
            else if (methodName == "C_Blunt.OperationNode")
            {
                result = visit_OperationNode(node_, context);
            }
            else if (methodName == "C_Blunt.UnaryNode")
            {
                result = visit_UnaryNode(node_, context);
            }
            else
            {
                Console.WriteLine("No method name exception");
            }

            return result;
        }

        private dynamic visit_NumberNode(dynamic node_, Context context)
        {
            Number result = new Number(node_.token.value);
            result.setPosition(node_.start, node_.end);
            result.setContext(context);
            return new RuntimeResult().success(result);
        }

        private dynamic visit_OperationNode(dynamic node_, Context context)
        {
            RuntimeResult rts = new RuntimeResult();
            dynamic left = rts.register(visit(node_.leftNode, context));
            Errors error = null;

            if(rts.error != null)
            {
                return rts;
            }
            dynamic right = rts.register(visit(node_.rightNode, context));
            if (rts.error != null)
            {
                return rts;
            }
            dynamic result = null;

            if (node_.token.type == Tokens.tPlus)
            {
                (result, error) = ((dynamic, Errors)) left.add(right);
            }
            else if (node_.token.type == Tokens.tMinus)
            {
                (result, error) = ((dynamic, Errors)) left.subtract(right);
            }
            else if (node_.token.type == Tokens.tMul)
            {
                (result, error) = ((dynamic, Errors)) left.multiply(right);
            }
            else if (node_.token.type == Tokens.tDiv)
            {
                (result, error) = ((dynamic, Errors)) left.divide(right);
            }
            else
            {
                Console.WriteLine("Unidentified operator error");
            }

            if (error != null)
            {
                return rts.failure(error);
            }
            else
            {
                result.setPosition(node_.start, node_.end);
                result.setContext(context);
                return rts.success(result);
            }
        }

        private dynamic visit_UnaryNode(dynamic node_, Context context)
        {
            RuntimeResult rts = new RuntimeResult();
            dynamic number = rts.register(visit(node_.node, context));
            Errors error = null;

            if (rts.error != null)
            {
                return rts;
            }

            if (node_.token.type == Tokens.tMinus)
            {
                (number, error) = ((dynamic, Errors)) number.multiply(new Number(-1));
            }

            if (error != null)
            {
                return rts.failure(error);
            }
            else
            {
                number.setPosition(node_.start, node_.end);
                number.setContext(context);
                return rts.success(number);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Blunt
{
    class Parser
    {
        List<C_Blunt.Tokens> tokens;
        int tokenIndex;
        Tokens currentToken;
        public Parser(List<C_Blunt.Tokens> tokens_)
        {
            tokens = tokens_;
            tokenIndex = -1;
            move();
        }

        private Tokens move()
        {
            tokenIndex += 1;
            if (tokenIndex < tokens.Count)
            {
                currentToken = tokens[tokenIndex];
            }

            return currentToken;
        }

        private dynamic factor()
        {
            ParseResult result = new ParseResult();
            Tokens token = currentToken;
            if (token.type == Tokens.tPlus || token.type == Tokens.tMinus)
            {
                result.register(move());
                dynamic factor_ = result.register(factor());
                if (result.error != null)
                {
                    return result;
                }

                return result.success(new UnaryNode(token, factor_));
            }
            else if (token.type == Tokens.tInt || token.type == Tokens.tFloat)
            {
                NumberNode thisNum = new NumberNode(token);
                result.register(move());
                return result.success(thisNum);
            }
            else if (token.type == Tokens.tLParen)
            {
                result.register(move());
                dynamic expression_ = result.register(expression());
                if (result.error != null)
                {
                    return result;
                }
                if (currentToken.type == Tokens.tRParen)
                {
                    result.register(move());
                    return result.success(expression_);
                }
                else
                {
                    return result.failure(new InvalidSyntaxError(currentToken.start, currentToken.end, "Expected ')'"));
                }
            }
            else
            {
                return result.failure(new InvalidSyntaxError(token.start, token.end, "Expected int or float"));
            }
        }

        private dynamic operation(Func<dynamic> function, string[] operationTokens)
        {
            ParseResult result = new ParseResult();
            dynamic left = result.register(function());

            while (Array.Exists(operationTokens, element => element == currentToken.type))
            {
                Tokens operationToken = currentToken;
                result.register(move());
                dynamic right = result.register(function());

                if (result.error != null)
                {
                    return result;
                }

                left = new OperationNode(left, operationToken, right);
            }

            return result.success(left);
        }
        private dynamic term()
        {
            return operation(factor, new string[] { Tokens.tMul, Tokens.tDiv });
        }

        private dynamic expression()
        {
            return operation(term, new string[] { Tokens.tPlus, Tokens.tMinus });
        }

        public dynamic parse()
        {
            dynamic res = expression();
            if (res.error == null && currentToken.type != Tokens.tEOF)
            {
                return res.failure(new InvalidSyntaxError(currentToken.start, currentToken.end, "Expected '+', '-', '*' or '/'"));
            }
            return res;
        }
    }
}

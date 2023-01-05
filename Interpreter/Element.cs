using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition, Substraction
        }

        public Type BinaryType;
        public IElement Left, Right;
        public int Value
        {
            get
            {
                switch (BinaryType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Substraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }


        public static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            var haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.CurrentType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Plus:
                        result.BinaryType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.BinaryType = BinaryOperation.Type.Substraction;
                        break;
                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].CurrentType == Token.Type.Rparen)
                                break;
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }

    
}

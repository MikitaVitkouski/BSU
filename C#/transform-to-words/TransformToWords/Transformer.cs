using System;
using System.Globalization;
using System.Text;

namespace TransformToWords
{
    public static class Transformer
    {
        public static string TransformToWords(double number)
        {
            string s = number.ToString(CultureInfo.CurrentCulture);
            StringBuilder result = new StringBuilder();
            string res = string.Empty;

            switch (number)
            {
                case double.NaN:
                    return "NaN";
                case double.NegativeInfinity:
                    return "Negative Infinity";
                case double.PositiveInfinity:
                    return "Positive Infinity";
                case double.Epsilon:
                    return "Double Epsilon";
                case double.MaxValue:
                    return "One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight";
                case double.MinValue:
                    return "Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight";
                default:
                    if (double.IsNegative(number))
                    {
                        result.Append("minus ");
                    }

                    for (int i = 0; i < s.Length; i++)
                    {
                        switch (s[i])
                        {
                            case '0':
                                result.Append("zero ");
                                break;
                            case '1':
                                result.Append("one ");
                                break;
                            case '2':
                                result.Append("two ");
                                break;
                            case '3':
                                result.Append("three ");
                                break;
                            case '4':
                                result.Append("four ");
                                break;
                            case '5':
                                result.Append("five ");
                                break;
                            case '6':
                                result.Append("six ");
                                break;
                            case '7':
                                result.Append("seven ");
                                break;
                            case '8':
                                result.Append("eight ");
                                break;
                            case '9':
                                result.Append("nine ");
                                break;
                            case '.':
                                result.Append("point ");
                                break;
                            case 'E':
                                result.Append("E plus ");
                                break;
                        }
                    }

                    res = result.ToString();
                    res = res.Remove(res.Length - 1);
                    res = char.ToUpper(res[0], CultureInfo.CurrentCulture) + res.Substring(1);
                    return res;
            }
        }
    }
}

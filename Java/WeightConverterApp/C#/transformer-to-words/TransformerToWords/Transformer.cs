#pragma warning disable CA1822
using System;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    public class Transformer
    {
        public string[] Transform(double[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (source.Length == 0)
            {
                throw new ArgumentException(null, nameof(source));
            }

            var listOfStrings = new List<string>();

            for (int i = 0; i < source.Length; i++)
            {
                string s = source[i].ToString(CultureInfo.CurrentCulture);
                StringBuilder result = new StringBuilder();
                string res = string.Empty;

                switch (source[i])
                {
                    case double.NaN:
                        listOfStrings.Add("Not a Number");
                        break;
                    case double.NegativeInfinity:
                        listOfStrings.Add("Negative Infinity");
                        break;
                    case double.PositiveInfinity:
                        listOfStrings.Add("Positive Infinity");
                        break;
                    case double.Epsilon:
                        listOfStrings.Add("Double Epsilon");
                        break;
                    case double.MaxValue:
                        listOfStrings.Add("One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight");
                        break;
                    case double.MinValue:
                        listOfStrings.Add("Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight");
                        break;
                    default:
                        if (double.IsNegative(source[i]))
                        {
                            result.Append("minus ");
                        }

                        for (int j = 0; j < s.Length; j++)
                        {
                            switch (s[j])
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
                                case 'e':
                                    result.Append("E plus ");
                                    break;
                            }
                        }

                        res = result.ToString();
                        res = res.Remove(res.Length - 1);
                        res = char.ToUpper(res[0], CultureInfo.CurrentCulture) + res.Substring(1);
                        listOfStrings.Add(res);
                        break;
                }
            }

            string[] arrayOfStrings = listOfStrings.ToArray();
            return arrayOfStrings;
        }
    }
}

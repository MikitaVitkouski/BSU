using System;
using System.Text;

namespace IsbnValidator
{
    public static class Validator
    {
        public static bool IsIsbnValid(string isbn)
        {
            int x, checksum = 0, hyphen = 3, k = 10;
            if (string.IsNullOrEmpty(isbn) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("Input is empty or contains only whitespace");
            }

            StringBuilder s = new StringBuilder();
            s.Append(isbn);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                {
                    if (s[i + 1] == '-')
                    {
                        return false;
                    }
                    else
                    {
                        s.Remove(i, 1);
                        hyphen--;
                        i--;
                    }
                }
                else if (!char.IsDigit(s[i]) && (i < s.Length - 1 || s[i] != 'X'))
                {
                    return false;
                }
            }

            if (s.Length != 10 || hyphen < 0)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'X')
                {
                    x = 10;
                }
                else
                {
                    x = Convert.ToInt32(s[i].ToString(), null);
                }

                if (k > 0)
                {
                    checksum += x * k;
                    k--;
                }
            }

            if (checksum % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

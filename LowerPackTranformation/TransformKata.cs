using System;
using System.Text;

namespace LowerPackTranformation
{
    public class TransformKata
    {
        public string LowerPack(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            bool flagInside = false;
            StringBuilder newString = new StringBuilder(input.Length);
             for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    flagInside = true;
                }
                if (i == input.Length - 1 && input[i] == ' ')
                {
                    flagInside = false;
                }
                if (input[i] == ' ' && flagInside)
                {
                    continue;
                }
                newString.Append(char.ToLower(input[i]));
            }
            return  newString.ToString();
        }
    }
}
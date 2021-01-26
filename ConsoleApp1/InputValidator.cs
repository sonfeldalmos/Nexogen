using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InputValidator : IInputValidator
    {
        public bool Validate(string[] input)
        {
            foreach (var element in input)
            {
                foreach (var character in element)
                {
                    if (!(char.IsLetterOrDigit(character) || character == ' '))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

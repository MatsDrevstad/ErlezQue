using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErlezQue
{
    public class Calculator
    {
        public char[] validDelimiters = new char[] { ',', '\n' };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Length > 1)
            {
                if (numbers.Substring(0, 2).Equals("//"))
                {
                    numbers = numbers.Substring(2);

                    if (numbers.Substring(0, 1).Equals("["))
                    {
                        numbers = FindOptionalDelimiters(numbers);
                    }
                    else
                    {
                        validDelimiters = numbers.Substring(0, 1).ToCharArray();
                        numbers = numbers.Substring(2);
                    }
                }

                return ComputeSum(MySplit(numbers, validDelimiters));
            }

            return int.Parse(numbers);
        }

        private string FindOptionalDelimiters(string numbers)
        {
            if (numbers.Substring(0, 1).Equals("["))
            {
                Array.Resize(ref validDelimiters, validDelimiters.Length + 1);
                validDelimiters[validDelimiters.Length - 1] = numbers.Substring(1, 1)[0];
                numbers = FindOptionalDelimiters(MergeNumbersNLengthDelimiter(numbers).Substring(3));
            }
            else
            {
                numbers = numbers.Substring(1);
            }

            return numbers;
        }

        private string MergeNumbersNLengthDelimiter(string numbers)
        {
            var lengtOfNLengthDelimiter = numbers.IndexOf(']') - 1;
            var nLengthDelimiter = numbers.Substring(1, lengtOfNLengthDelimiter);
            return numbers.Replace(nLengthDelimiter, nLengthDelimiter[0].ToString());
        }
        
        private int ComputeSum(List<int> ints)
        {

            if (ints.Any(i => i < 0))
	        {
		        throw new Exception("Negative numbers are not allowed" + string.Join(", ", ints.Where(i => i < 0)));                
	        }

            return ints.Where(i => i < 1001).Sum();
        }

        private List<int> MySplit(string numbers, char[] validDelimiters)
        {
            return numbers.Split(validDelimiters).Select(n => int.Parse(n)).ToList();
        }
    }
}


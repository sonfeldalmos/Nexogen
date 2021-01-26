using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Separator : ISeparator
    {
        public TrucksAndJobsDTO Separate(string[] input)
        {
            Dictionary<int, List<string>> trucks = new Dictionary<int, List<string>>();
            Dictionary<int, List<string>> jobs = new Dictionary<int, List<string>>();


            for (int i = 0; i < input.Length/2; i++)
            {
                if (i > 0)
                {
                    trucks.Add(i, separationHelper(input[i]));
                }
            }

            for (int i =(input.Length / 2); i < input.Length; i++)
            {
                if (i > (input.Length / 2))
                {
                    jobs.Add(i - (input.Length / 2) - 1, separationHelper(input[i]));
                }
            }
            
            return new TrucksAndJobsDTO(trucks,jobs);
        }

        private List<string> separationHelper(string s)
        {
            List<string> res= new List<string>();

            foreach (var element in s)
            {
                if (!char.IsNumber(element) && element != ' ')
                {
                    res.Add(element.ToString());
                }
            }

            return res;
        }
    }
}

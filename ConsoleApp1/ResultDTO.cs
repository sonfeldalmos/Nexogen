using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ResultDTO
    {
        public Dictionary<int, int> result { get;}
        public TrucksAndJobsDTO dto { get; }

        public ResultDTO(Dictionary<int, int> result, TrucksAndJobsDTO dto)
        {
            this.result = result;
            this.dto = dto;
        }
    }
}

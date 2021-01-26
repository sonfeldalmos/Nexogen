using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrucksAndJobsDTO
    {
        public TrucksAndJobsDTO(Dictionary<int, List<string>>  trucks, Dictionary<int, List<string>>  jobs)
        {
            Trucks = trucks;
            Jobs = jobs;
        }

        public Dictionary<int, List<string>>  Trucks { get;}
        public Dictionary<int, List<string>>  Jobs { get;}

    }
}


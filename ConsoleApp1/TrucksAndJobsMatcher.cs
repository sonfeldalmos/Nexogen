using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrucksAndJobsMatcher : IMatchingTrucksWithJobs
    {
        public ResultDTO DoParing(TrucksAndJobsDTO dto)
        {
            var result = new Dictionary<int, int>();
            PairTrucksWithOneJobType(dto, result);
            DoGreadyMatching(dto, result);

            return new ResultDTO(result, dto);
        }

        private void PairTrucksWithOneJobType(TrucksAndJobsDTO dto, Dictionary<int, int> result)
        {
            var trucksWithOneJobType = new Dictionary<int, List<string>>();

            foreach (var element in dto.Trucks)
            {
                if (element.Value.Count == 1)
                {
                    trucksWithOneJobType.Add(element.Key + 1, element.Value);
                }
            }


            foreach (var truck in trucksWithOneJobType)
            {
                    foreach (var job in dto.Jobs)
                    {
                        if (truck.Value.Contains(job.Value[0]))
                        {
                            result.Add(truck.Key, job.Key);
                            dto.Jobs.Remove(job.Key);
                            dto.Trucks.Remove(truck.Key);
                            break;
                        }
                    }

            }
        }

        private void DoGreadyMatching(TrucksAndJobsDTO dto, Dictionary<int, int> result) {
            var processedTruckContainer = new List<string>();
            var numberOfDistinctJobType = GetNumberOrDistincJobType(dto);
            for (int j = 0; j < numberOfDistinctJobType; j++)
            {
                
                var toBeMatched = FindMaxUnprocessedJobType(dto, processedTruckContainer);

                var toBeRemoved = new List<int>();

                foreach (var truck in dto.Trucks)
                {
                    if (truck.Value.Contains(toBeMatched))
                    {

                        foreach (var job in dto.Jobs)
                        {
                            if (truck.Value.Contains(job.Value[0]))
                            {
                                result.Add(truck.Key, job.Key);
                                dto.Jobs.Remove(job.Key);
                                toBeRemoved.Add(truck.Key);
                                break;
                            }
                        }

                    }

                }

                foreach (var element in toBeRemoved)
                {
                    dto.Trucks.Remove(element);
                }

            }

        }

        private int GetNumberOrDistincJobType(TrucksAndJobsDTO dto) {
            Dictionary<string, int> jobsByType = new Dictionary<string, int>();

            foreach (var element in dto.Jobs)
            {
                for (int i = 0; i < element.Value.Count; i++)
                {

                    if (!jobsByType.ContainsKey(element.Value[i]))
                    {
                        jobsByType.Add(element.Value[i], 1);
                    }
                    else
                    {
                        jobsByType[element.Value[i]]++;
                    }
                }

            }

            return jobsByType.Count;
        }

        private string FindMaxUnprocessedJobType(TrucksAndJobsDTO dto, List<string> processedTruckContainer) {
            var res = string.Empty;
            var tmp = int.MinValue;
            Dictionary<string, int> trucksByType = new Dictionary<string, int>();

            foreach (var element in dto.Trucks)
            {
                for (int i = 0; i < element.Value.Count; i++)
                {

                    if (!trucksByType.ContainsKey(element.Value[i]))
                    {
                        trucksByType.Add(element.Value[i], 1);
                    }
                    else
                    {
                        trucksByType[element.Value[i]]++;
                    }
                }

            }

            foreach (var element in trucksByType) {

                if (element.Value > tmp && !processedTruckContainer.Contains(element.Key)) {
                    res = element.Key;
                    tmp = element.Value;
                }
            
            }

            processedTruckContainer.Add(res);

            return res;
        }
           


     }
}
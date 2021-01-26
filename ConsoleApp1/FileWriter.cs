using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FileWriter : IFileWriter
    {
        public void WriteResult(ResultDTO dto)
        {
            const string fileName= "result.txt";

            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                    
                }

                System.IO.FileStream fs = System.IO.File.Create(fileName);
                fs.Dispose();


                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileName))
                {
                    file.WriteLine("Paired Trucks and Jobs");
                    foreach (var element in dto.result)
                    {

                        file.WriteLine("Truck id:{0} Job id:{1}", element.Key, element.Value);

                    }

                    file.WriteLine("Unpaired Jobs:");

                    foreach (var element in dto.dto.Jobs)
                    {

                        file.WriteLine("{0}", element.Key, element.Value[0]);

                    }

                    file.WriteLine("Unpaired Trucks:");

                    foreach (var element in dto.dto.Trucks)
                    {

                            file.WriteLine("{0}", element.Key); 

                    }


                }
            }
            catch {
                throw;
            }
        }
    }
}

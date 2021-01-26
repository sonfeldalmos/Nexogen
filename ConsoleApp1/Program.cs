using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                INexogenProblemSolver problemSolver = new NexogenProblemSolver(new FileReader(), new InputValidator(), new Separator(), new TrucksAndJobsMatcher(), new FileWriter());
                problemSolver.SolveProblem();

            }
            catch
            {
                Console.WriteLine("Error occured");
            }
        }
    }
}

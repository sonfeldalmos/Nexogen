using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NexogenProblemSolver : INexogenProblemSolver
    {
        private readonly IFileReader _reader;
        private readonly IInputValidator _validator;
        private readonly ISeparator _separator;
        private readonly IMatchingTrucksWithJobs _matcher;
        private readonly IFileWriter _writer;
        public NexogenProblemSolver(IFileReader reader, IInputValidator validator, ISeparator separator, IMatchingTrucksWithJobs matcher, IFileWriter writer) {
            _reader = reader;
            _validator = validator;
            _separator = separator;
            _matcher = matcher;
            _writer = writer;
        }


        public void SolveProblem()
        {
            
            var lines = _reader.ReadLines("input.txt");
            if (_validator.Validate(lines))
            {
                var dto = _separator.Separate(lines);
                var result = _matcher.DoParing(dto);
                _writer.WriteResult(result);

            }
            else
            {
                Console.WriteLine("Invalid input. The program is terminating.");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPole.Core.Models
{
    public class OperationResult
    {
        public long Number { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public bool IsSuccess { get; set; }

        public TimeSpan? ElapsedTime { get; set; }
    }
}

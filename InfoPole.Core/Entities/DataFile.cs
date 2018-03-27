using System;
using System.Collections.Generic;
using System.Text;

namespace InfoPole.Core
{
    public class DataFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Uploaded { get; set; }
        public int SearchEngineID { get; set; }
    }
}

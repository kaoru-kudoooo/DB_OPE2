using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Ope_API.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}

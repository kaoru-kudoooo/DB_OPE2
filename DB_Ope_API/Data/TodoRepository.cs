using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_Ope_API.Models;

namespace DB_Ope_API.Data
{
    public class TodoRepository
    {
        // ダミーデータ
        static List<Todo> todos { get; } = new List<Todo> {
      new Todo { ID = 1, Title = "CSV返却の記事", IsDone = false },
      new Todo { ID = 2, Title = "IoCの記事", IsDone = false },
        };

        public List<Todo> List() => todos;
    }
}

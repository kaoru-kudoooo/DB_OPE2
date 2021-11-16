using CsvHelper;
using System.Collections.Generic;
using System.IO;
using DB_Ope_API.Data;
using DB_Ope_API.Models;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DB_Ope_API.Services
{
    public class CSV_catalist
    {
        // サンプルなので DI せず直にインスタンス化
        //readonly TodoRepository repository = new TodoRepository();

        private readonly DBsetContext _context;

        public CSV_catalist(DBsetContext context)
        {
            _context = context;
        }



        public byte[] GetCsvContents()
        {
          
            //List<Todo> todos = repository.List();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            using (var memory = new MemoryStream())
            using (var writer = new StreamWriter(memory,Encoding.UTF8))
            using (var csv = new CsvWriter(writer,config))
            {
                List<Member> members = _context.Members.ToList();
                csv.WriteRecords(members);
                writer.Flush(); //StreamWriter.Flush を呼ばないとバッファーからメモリに書き込まれないので注意
                return memory.ToArray();
            }
        }
    }
}
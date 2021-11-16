using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB_Ope_API.Models;
using DB_Ope_API.Services;
using DB_Ope_API.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace DB_Ope_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        // サンプルなので DI せず直にインスタンス化

        //readonly CSV_catalist service = new CSV_catalist;
        private readonly DBsetContext _context;

        public TodosController(DBsetContext context)
        {
            _context = context;
        }



        [HttpGet("export")]
        public FileContentResult Export()
        {
            string fileName = $"ToDoList-{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            using (var memory = new MemoryStream())
            using (var writer = new StreamWriter(memory, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, config))
            {
                List<Member> members = _context.Members.ToList();
                csv.WriteRecords(members);
                writer.Flush(); //StreamWriter.Flush を呼ばないとバッファーからメモリに書き込まれないので注意
                                //return memory.ToArray();



                return File(memory.ToArray(), "text/csv", fileName);
            }

        }
    }
}
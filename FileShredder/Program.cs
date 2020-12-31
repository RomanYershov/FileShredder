using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FShredder.Bll.EngineFactories;
using FShredder.Bll.Utils;
using FShredder.Bll.Models;



namespace FileShredder
{
    class Program
    {

        static void Main(string[] args)
        {
            var drives = DriveInfo.GetDrives();
            var drivesName = drives.Select(x => x.Name).ToArray();
            var fileEngine = new Engine(new FileEngineFactory());


            string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileShredder.xml");
            var parseResult = fileEngine.Parse(xmlPath);
            if (parseResult != null)
            {
                Console.WriteLine("нажмите Enter для удаления");
                Console.ReadKey();

                fileEngine.RemoveFiles(parseResult);
            }
            Console.ReadKey();






            var result = fileEngine.Search(new [] { @"D:\" }, "test");
            foreach (var file in result)
            {
                Console.WriteLine(file.ToString());
            }
            Console.ReadKey();

        }
    }
}

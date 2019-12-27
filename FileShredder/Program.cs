using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FShredder.Bll.Utils;



namespace FileShredder
{
    class Program
    {

        static void Main(string[] args)
        {
            var fileEngine = new FileEngine();
            //string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileShredder.xml");

            //var data =  XmlParser.Parse(xmlPath);
            //if (data != null)
            //{
            //    Console.WriteLine("нажмите Enter для удаления");
            //    Console.ReadKey();
            //    fileEngine.RemoveFiles(data.DirectoryName, data.IgnoreFiles);
            //}
            //Console.ReadKey();




            var drives = DriveInfo.GetDrives();
            var drivesName = drives.Select(x => x.Name).ToArray();

            var result = fileEngine.SearchFile(new[] { @"D:\" }, "los");
            foreach (var file in result)
            {
                Console.WriteLine(file.ToString());
            }
            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FShredder.Bll.Utils;
using FShredder.Bll.Models;



namespace FileShredder
{
    class Program
    {

        static void Main(string[] args)
        {
            var fileEngine = new FileEngine();
            string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileShredder.xml");
            var data = new XmlParser().Parse(xmlPath) as XmlInfoResult;
            if (data != null)
            {
                Console.WriteLine("нажмите Enter для удаления");
                Console.ReadKey();
                fileEngine.RemoveFiles(data.DirectoryName, data.IgnoreFiles);
            }
            Console.ReadKey();




            //var drives = DriveInfo.GetDrives();
            //var drivesName = drives.Select(x => x.Name).ToArray();

            //var result = fileEngine.SearchFile(new[] { @"D:\" }, "roman");
            //foreach (var file in result)
            //{
            //    Console.WriteLine(file.ToString());
            //}
            //Console.ReadKey();

        }
    }
}

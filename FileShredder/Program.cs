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
            var drives = DriveInfo.GetDrives();
            var drivesName = drives.Select(x => x.Name).ToArray();
            var fileEngine = new FileEngine();


            //string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileShredder.xml");
            //var data = new XmlParser().Parse(xmlPath);
            //if (data != null)
            //{
            //    Console.WriteLine("нажмите Enter для удаления");
            //    Console.ReadKey();

            //    fileEngine.RemoveFiles(data.Info, data.InfoList);
            //}
            //Console.ReadKey();






            var result = fileEngine.Search(new FileSearch(drivesName, ".txt"));
            foreach (var file in result)
            {
                Console.WriteLine(file.ToString());
            }
            Console.ReadKey();

        }
    }
}

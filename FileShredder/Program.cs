using System;
using System.Collections.Generic;
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
           
            string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileShredder.xml");

            var data =  XmlParser.Parse(xmlPath);
            if (data != null)
            {
                var fileEngine = new FileEngine();
                Console.WriteLine("нажмите Enter для удаления");
                Console.ReadKey();
                fileEngine.RemoveFiles(data.DirectoryName, data.IgnoreFiles);
            }
            Console.ReadKey();




            //var drives = DriveInfo.GetDrives();
            //var drivesName = drives.Select(x => x.Name).ToArray();

            //var result =  engine.ShowAllFiles(drivesName, new[] {"" });
            // foreach(var file in result)
            // {
            //     Console.WriteLine(file.ToString());
            // }


        }
    }
}

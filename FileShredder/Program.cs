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
            const string path = @"C:\Users\r.ershov\source\repos\FileShredder\FileShredder\DataTest.xml";

            var data =  XmlParser.Parse(path);
            var dir = data[0];
            data.RemoveAt(0);
            var fileEngine = new FileEngine();
            Console.ReadKey();
            fileEngine.RemoveFiles(dir, data);
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

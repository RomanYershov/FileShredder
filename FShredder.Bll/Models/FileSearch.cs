using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FShredder.Bll.Abstractions;

namespace FShredder.Bll.Models
{
   public class FileSearch : ISearching
   {
    
        public IEnumerable Search(string [] directories, string searchValue)
        {
            Queue<string> queue = new Queue<string>();
            foreach (var rootDir in directories)
            {
                queue.Enqueue(rootDir);
                while (queue.Count > 0)
                {
                    var currentDir = queue.Dequeue();
                    string[] childDirectories;
                    try
                    {
                        childDirectories = Directory.GetDirectories(currentDir);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    var innerFiles = Directory.GetFiles(currentDir);
                    foreach (var file in innerFiles)
                    {
                        if (GetNameFromPath(file).ToLower().Contains(searchValue.ToLower()))
                            yield return file;
                    }
                    foreach (var nextDir in childDirectories)
                    {
                        queue.Enqueue(nextDir);
                    }
                }
            }
            yield return "________________________End________________________";
        }




        private string GetNameFromPath(string path)
        {
            var resArr = path.Split('\\');
            var name = resArr[resArr.Length - 1];
            return name;

        }
    }



}

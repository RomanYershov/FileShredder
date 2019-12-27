using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Abstractions;
using System.IO;

namespace FShredder.Bll.Utils
{
    public class FileEngine : IService
    {
        
        public IEnumerable SearchFile(string[] drives, string searchValue)
        {
            Queue<string> queue = new Queue<string>();  
            foreach (var rootDir in drives)
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
                    catch(Exception ex)
                    {
                        continue;
                    }
                    var innerFiles = Directory.GetFiles(currentDir);
                    foreach(var file in innerFiles)
                    {
                        if(GetNameFromPath(file).ToLower().Contains(searchValue.ToLower()))
                        yield return file;
                    }
                    foreach (var nextDir in childDirectories)
                    {
                        queue.Enqueue(nextDir);
                    }
                }
            }
           yield return "End";
        }

        public void RemoveFiles(string dirPath, List<string> files)
        {
            int count = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if(!dirInfo.Exists)
            {
                Logger.Error($"Дириктороии \"{dirInfo.Name}\" не существует в данном расположении.");
                return;
            }
            var innerFiles = dirInfo.GetFiles();
            foreach(var file in innerFiles)
            {
                try
                {   
                    if(!files.Contains(file.Name.ToLower()) && file.CreationTime.Date != DateTime.Now.Date)
                    {
                        file.Delete();
                        ++count;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Ошибка удалениея файла {file.Name}",ex);
                    continue;
                }
            }
            Logger.Info($"Всего удалено ({count}) файлов") ;
        }


        private string GetNameFromPath(string path)
        {
            var resArr = path.Split('\\');
            var name = resArr[resArr.Length - 1];
            return name;
            
        }

      
    }
}

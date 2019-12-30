using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Abstractions;
using System.IO;

namespace FShredder.Bll.Utils
{
    public class FileEngine : IFileService
    {
       


        public void RemoveFiles(string dirPath, List<string> ignoreFiles)
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
                    if(!ignoreFiles.Contains(file.Name.ToLower()) && file.CreationTime.Date != DateTime.Now.Date)
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


     


      
    }
}

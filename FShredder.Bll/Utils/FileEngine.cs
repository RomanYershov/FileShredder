using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FShredder.Bll.Abstractions;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FShredder.Bll.Utils
{
    public class FileEngine : IFileService
    {
        public void RemoveFiles(IParseResult parseResult)
        {
            int count = 0;
            foreach (var dir in parseResult.Directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir.Name);
                if (!dirInfo.Exists)
                {
                    Logger.Error($"Дириктороии \"{dirInfo.Name}\" не существует в данном расположении.");
                    return;
                }
                var innerFiles = dirInfo.GetFiles();
                foreach (var fileObject in dir.Files)
                {
                    if (!string.IsNullOrEmpty(fileObject.Attributes.Mask))
                    {
                        Regex regex = new Regex("^" + fileObject.Attributes.Mask + "$");
                        foreach (var f in innerFiles)
                        {
                            var result = regex.Match(f.Name);
                            if (!result.Success)
                            {
                                f.Delete();
                                ++count;
                            }
                        }
                        
                       
                    }
                }
                foreach (var file in innerFiles)
                {
                    try
                    {
                      
                        //var ignorFiles = dir.Files.Select(x => x.Name);
                        //if (!ignorFiles.Contains(file.Name)) //&& file.CreationTime.Date > fileObject.Attributes.DateFrom.GetValueOrDefault().Date) 
                        //{
                        //    file.Delete();
                        //    ++count;
                        //}

                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Ошибка удалениея файла {file.Name}", ex);
                        continue;
                    }
                }
            }
           
            Logger.Info($"Всего удалено ({count}) файлов");
        }
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

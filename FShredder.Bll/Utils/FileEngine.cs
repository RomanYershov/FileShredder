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
                    //var ignoreFiles = dir.Files.Where(f => f.Attributes.IsIgnore).Select(f => f.Name);
                    if (fileObject.Attributes.IsIgnore)
                    {
                        var fName = GetFileName(fileObject.Name);
                        Regex regex = new Regex(GetPattern(fileObject.Name));
                        foreach (var f in innerFiles)
                        {
                            var result = regex.Match(f.Name);
                            if (result.Success && f.Name != fName && (fileObject.Attributes.DateFrom == null ||
                                                fileObject.Attributes.DateFrom.GetValueOrDefault().Date <= f.CreationTime.Date))
                            {
                                f.Delete();
                                ++count;
                            }
                        }
                    }
                    else
                    {
                        foreach (var file in innerFiles)
                        {
                            if (fileObject.Name == file.Name && (fileObject.Attributes.DateFrom.GetValueOrDefault().Date <= file.CreationTime.Date
                                                                 || fileObject.Attributes.DateFrom == null))
                            {
                                file.Delete();
                                ++count;
                            }
                        }
                    }
                }
            }

            Logger.Info($"Всего удалено ({count}) файлов");
        }

        private string GetPattern(string fileName)
        {
            if (fileName.Contains("?*"))
                return $"^{fileName.Replace('*', ' ').TrimEnd()}.*";
            return fileName;
        }

        private string GetFileName(string fileName)
        {
            var regex = new Regex("\\w*");
            var res = regex.Matches(fileName);
            return $"{res[0].Value}.{res[2].Value}";
        }
       






    }
}

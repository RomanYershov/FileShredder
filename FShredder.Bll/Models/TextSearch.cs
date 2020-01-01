using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FShredder.Bll.Abstractions;
using FShredder.Bll.Extentions;
using FShredder.Bll.Utils;

namespace FShredder.Bll.Models
{
    public class TextSearch : ISearching
    {
        public IEnumerable Search(string[] directories, string searchValue)
        {
            Queue<string> queue = new Queue<string>();
            foreach (var directory in directories)
            {
                queue.Enqueue(directory);
                while (queue.Count > 0)
                {
                    string[] files;
                    var currentDirectory = queue.Dequeue();
                    try
                    {
                        files = Directory.GetFiles(currentDirectory);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                    var resFiles = files.Where(path => FindText(path, searchValue, new[] { "txt" }));
                    foreach (var file in resFiles)
                    {
                        yield return file;
                    }
                    var childDirectories = Directory.GetDirectories(currentDirectory);
                    foreach (var childDirectory in childDirectories)
                    {
                        queue.Enqueue(childDirectory);
                    }
                }

            }

            yield return "________________________End________________________";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Полный путь к файлу</param>
        /// <param name="searchData">искомоый текст</param>
        /// <param name="allowExtentions">список допустимых расширений файла</param>
        /// <returns></returns>
        private bool FindText(string filePath, string searchData, string [] allowExtentions)
        {
            if (allowExtentions.Contains(filePath.GetExtention()))
            {
                try
                {
                    var allText = File.ReadAllText(filePath);
                    return allText.ToLower().Contains(searchData.ToLower());
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }

    enum ExtentionsEnum
    {
        all, txt, doc, png, jpg
    }
}

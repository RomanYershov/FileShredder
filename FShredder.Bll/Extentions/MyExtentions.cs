using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FShredder.Bll.Extentions
{
    public static class MyExtentions
    {
        public static string GetExtention(this string filePath) 
        {
            var format = filePath.Split('.');
            var ext = format.Last();   
            return ext;
        }
    }
}

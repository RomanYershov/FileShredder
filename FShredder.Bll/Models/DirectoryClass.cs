using System;
using System.Collections.Generic;
using System.Text;

namespace FShredder.Bll.Models
{
    public class DirectoryObject
    {
        public string Name { get; set; }
        public List<FileObject> Files { get; set; }
        public DirectoryObject() => Files = new List<FileObject>();

        public DirectoryObject(string name)
        {
            Files = new List<FileObject>();
            Name = name;
        }
    }

    public class FileObject
    {
        public string Name { get; set; }
        public AttributeObject Attributes { get; set; }

        public FileObject()
        {
            Attributes = new AttributeObject();
        }
    }

    public class AttributeObject
    {
        public bool IsIgnore { get; set; }  
        public string Mask { get; set; }
        public DateTime? DateFrom { get; set; }
    }

}

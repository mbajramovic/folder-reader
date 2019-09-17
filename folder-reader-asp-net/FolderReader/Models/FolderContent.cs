using System;
using System.Collections.Generic;

namespace FolderReader.Models
{
    public class FolderContent
    {
        public List<Content> Content {get;set;}
        public String Error {get; set;}

        public FolderContent(List<Content> content) 
        {
            Content = content;
        }

        public FolderContent(String error) 
        {
            Content = new List<Content>();
            Error = error;
        }
    }
}
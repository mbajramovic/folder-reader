using System;

namespace FolderReader.Models
{
    public class Content
    {
       public String Folder {get; set;}
       public String File {get; set;}

       public Content(String folder, String file) 
       {
           Folder = folder;
           File = file;
       }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FolderReader.Models;
using FolderReader.Helpers;

namespace FolderReader.Controllers
{
    public class FolderContentController : Controller
    {
        static string folderToRead;
        public void FolderContent(String folder, String file)
        {
            if (folderToRead == null) 
            {
                String path = folder + "\\" + file;    
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(@path);
                startInfo.UseShellExecute = true;
                process.StartInfo = startInfo;
                process.Start();
                folderToRead = folder;
            }
            else 
            {
                folderToRead = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FolderReader.Models;
using FolderReader.Helpers;

namespace FolderReader.Controllers
{
    public class PathController : Controller
    {
        [HttpPost]
        public IActionResult Path(Path path) 
        {
            ReadWriteInterface readWriteInterface = new ReadWriteInterface();
            if (ModelState.IsValid) 
            {
                readWriteInterface.writePath(path.PathName);
                return View(path);
            }
            else 
            {
                return View(path);
            }
        }
 
    }
}

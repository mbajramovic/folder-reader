using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FolderReader.Models;
using FolderReader.Helpers;

namespace FolderReader.Controllers
{
    public class FolderNumberController : Controller
    {

        ReadWriteInterface readWriteInterface = new ReadWriteInterface();
        public IActionResult FolderNumber() {
            return View();
        }

        [HttpPost]
        public IActionResult FolderNumber(FolderNumber folderNumber) 
        {
            if (ModelState.IsValid) {
                try 
                {
                    List<Content> content = readWriteInterface.getFolderContent(folderNumber);
                    return View("FolderContent", new FolderContent(content));
                }
                catch(Exception ex) 
                {
                    return View("FolderContent", new FolderContent(ex.Message));
                }

            }
            else 
            {
                return View(folderNumber);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

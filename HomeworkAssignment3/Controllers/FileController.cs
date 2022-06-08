using HomeworkAssignment3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkAssignment3.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult files()
        {
            string[] allFiles = Directory.GetFiles(Server.MapPath("~/Media/Documents"));

            List<FileModel> fil = new List<FileModel>();

            foreach (var path in allFiles)
            {
                fil.Add(new FileModel { FileName = Path.GetFileName(path) });
            }

            return View(fil);
        }



        public FileResult DownloadFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] b = System.IO.File.ReadAllBytes(filePath);
            return File(b, "application/octet-stream", fileName);
        }



        public ActionResult DeleteFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Documents/") + fileName;
            System.IO.File.Delete(filePath);
            return RedirectToAction("files");
        }
    }
}
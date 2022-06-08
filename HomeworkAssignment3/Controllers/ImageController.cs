using HomeworkAssignment3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HomeworkAssignment3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult image()
        {
            string[] allImg = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            List<FileModel> img = new List<FileModel>();

            foreach(var path in allImg)
            {
                img.Add(new FileModel { FileName = Path.GetFileName(path) });
            }

            return View(img);
        }



        public FileResult DownloadFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Images/") + fileName;
            byte[] b = System.IO.File.ReadAllBytes(filePath);
            return File(b, "application/octet-stream", fileName);
        }



        public ActionResult DeleteFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Images/") + fileName;
            System.IO.File.Delete(filePath);
            return RedirectToAction("image");
        }
    }
}
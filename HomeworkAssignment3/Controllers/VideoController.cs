using HomeworkAssignment3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkAssignment3.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult video()
        {
            string[] allVid = Directory.GetFiles(Server.MapPath("~/Media/Videos"));

            List<FileModel> vid = new List<FileModel>();

            foreach (var path in allVid)
            {
                vid.Add(new FileModel { FileName = Path.GetFileName(path) });
            }

            return View(vid);
        }



        public FileResult DownloadFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] b = System.IO.File.ReadAllBytes(filePath);
            return File(b, "application/octet-stream", fileName);
        }



        public ActionResult DeleteFile(string fileName)
        {
            string filePath = Server.MapPath("~/Media/Videos/") + fileName;
            System.IO.File.Delete(filePath);
            return RedirectToAction("video");
        }
    }
}
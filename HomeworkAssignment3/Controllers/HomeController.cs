using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HomeworkAssignment3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Files, FormCollection frm)
        {
            var typeOf = frm["type"];

            if (typeOf == null)
            {
                // Only supported PDF, WORD(docx) EXCEL(xlsx) and POWERPOINT(pptx) file types as there are too many to list.
                if (Files.FileName.Contains(".pdf") || Files.FileName.Contains(".docx") || Files.FileName.Contains(".xlsx") || Files.FileName.Contains(".pptx") && Files != null && Files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                    Files.SaveAs(path);
                }
                else
                    // Only supported JPG, PNG, JPEG, TIFF, GIF and RAW file types as there are too many to list.
                    if (Files.FileName.Contains(".jpg") || Files.FileName.Contains(".png") || Files.FileName.Contains(".jpeg") || Files.FileName.Contains(".tiff") || Files.FileName.Contains(".gif") || Files.FileName.Contains(".raw") && Files != null && Files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
                    Files.SaveAs(path);
                }
                else
                    // Only supported MP4, MOV, WMV and AVi file types as there are too many to list.
                    if (Files.FileName.Contains(".mp4") || Files.FileName.Contains(".mov") || Files.FileName.Contains(".wmv") || Files.FileName.Contains(".avi") && Files != null && Files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);
                    Files.SaveAs(path);
                }
            }
            else
            {
                // Used for if the user selected a radio button
                if (Files != null && Files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Files.FileName);
                    var path = Path.Combine(Server.MapPath("~/Media/" + typeOf.ToString()), fileName);
                    Files.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Files()
        {
            ViewBag.Message = "Your Files page.";

            return View();
        }

        public ActionResult Images()
        {
            ViewBag.Message = "Your Images page.";

            return View();
        }
        public ActionResult Videos()
        {
            ViewBag.Message = "Your Videos page.";

            return View();
        }
        public ActionResult AboutMe()
        {
            ViewBag.Message = "About me page.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tipstrics.Controllers
{
  public class FileUploadTipsController : Controller
  {
    private IHostingEnvironment _hostingEnvironment;
    public FileUploadTipsController(IHostingEnvironment hostingEnvironment)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(FileUploadTipsModel model)
    {
      if (ModelState.IsValid)
      {
        string webRootPath = _hostingEnvironment.WebRootPath;
        string newPath = Path.Combine(webRootPath, "FileUploadTps");
        if (!Directory.Exists(newPath))
        {
          Directory.CreateDirectory(newPath);

        }

        //First file
        string fileName = ContentDispositionHeaderValue
                          .Parse(model.PassportFile.ContentDisposition)
                          .FileName.Trim('"');

        string fullPath = Path.Combine(newPath, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
          model.PassportFile.CopyTo(stream);
        }

        //Second File
        fileName = ContentDispositionHeaderValue
                    .Parse(model.DrivingLicenceFile.ContentDisposition)
                    .FileName.Trim('"');

        fullPath = Path.Combine(newPath, fileName);
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
          model.DrivingLicenceFile.CopyTo(stream);
        }
      }

      return View();
    }
  }

  public class FileUploadTipsModel
  {
    [Required(ErrorMessage = "Please enter name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please upload passport file")]
    [Display(Name = "Passport")]
    public IFormFile PassportFile { get; set; }

    [Required(ErrorMessage = "Please upload DL file")]
    [Display(Name = "Driving License")]
    public IFormFile DrivingLicenceFile { get; set; }
  }
}
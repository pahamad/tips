﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tipstrics.Controllers
{
  public class LoadViewsOnOnePopupController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult PartialData()
    {
      return View();
    }
  }
}
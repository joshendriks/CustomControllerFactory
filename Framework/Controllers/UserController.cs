﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Controllers
{
    public class UserController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = GetType().FullName;
            return View();
        }
    }
}
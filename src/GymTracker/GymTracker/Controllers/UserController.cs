﻿using GymTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class UserController : BaseController
    {
        public UserController() 
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
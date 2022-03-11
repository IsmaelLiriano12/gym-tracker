﻿using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class RoutineController : BaseController
    {
        private RoutinesRepository _routinesRepository = null;
        private TrainingDaysRepository _trainingDaysRepository = null;
        public RoutineController() 
        {
            _routinesRepository = new RoutinesRepository(Context);
            _trainingDaysRepository = new TrainingDaysRepository(Context);
        }

        public ActionResult Index()
        {
            var routines = _routinesRepository.GetList();

            return View(routines);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var routine = _routinesRepository.Get((int)id);

            return View(routine);
        }

        public ActionResult Add()
        {
            var routine = new Routine();
            return View(routine);
        }

        [HttpPost]
        public ActionResult Add(Routine routine)
        {
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                _routinesRepository.Add(routine);
                return RedirectToAction("Detail", new { id = routine.Id});
            }

            return View(routine);
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}
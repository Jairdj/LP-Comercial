using ListPeople.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListPeople.Controllers
{
    public class CarsController : Controller
    {
        CarRepository _repository = new CarRepository();
        // GET: Cars
        public ActionResult Index()
        {
            return View(CarRepository._car);
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car ) {
            _repository.create(car);
            return RedirectToAction("Index");        
        }


        [HttpGet]
        public ActionResult Edit(int id) {
            return View(_repository.getById(id));
        }
        [HttpPost]
        public ActionResult Edit(Car car ) {
            _repository.edit(car);
            return RedirectToAction("Index");
        }

        public ActionResult Delete( int id ) {
            _repository.delete(id);
            return RedirectToAction("Index");
        }

        }
    }
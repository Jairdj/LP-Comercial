using Associations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Associations.Controllers
{
    public class MembersController : Controller
    {
        MemberRepository repository = new MemberRepository();
        // GET: Members
        public ActionResult Index() {
            return View(repository.getAll());
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member) {
            repository.Create(member);
            return RedirectToAction("Index");
            }

        [HttpGet]
        public ActionResult Edit( int id ) {
            return View(repository.getById(id));
        }

        [HttpPost]
        public ActionResult Edit( Member member) {
            repository.Edit(member);
            return RedirectToAction("Index");
            }

        public ActionResult Delete( int id ) {
            repository.Delete(id);
            return RedirectToAction("Index");
            }
        }
}
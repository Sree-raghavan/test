using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbcontext _db;

        public CategoryController(ApplicationDbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _db.Category;
            return View(objlist);
        }

        //GET_CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
            }
            return View(obj);
           
        }

        //GET update
        public IActionResult update(int id)
        {
            if(id==null||id==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult update(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}

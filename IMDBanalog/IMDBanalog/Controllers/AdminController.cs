using IMDBanalog.Domain;
using IMDBanalog.Domain.Entities;
using IMDBanalog.Domain.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly IFilm _allfilms;
        private readonly IComment _allcomment;
       
  

        public AdminController(IFilm allfilms, IComment allcoment)
        {
            _allcomment = allcoment;
            _allfilms = allfilms;
          
        }

        public IActionResult Index()
        {
            return View(_allfilms.GetItems().ToList());
        }

    
     

        public IActionResult Create()
        {
            return View();
        }


  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Film obj)
        {
            if (ModelState.IsValid)
            {
                _allfilms.CreateItem(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int id)
        {

            var obj = _allfilms.GetItem(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Film obj)
        {
            if (ModelState.IsValid)
            {
                _allfilms.UpdateItem(obj);
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        public IActionResult Delete(int id)
        {

            var obj= _allfilms.GetItem(id);
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            
            _allfilms.DeleteIteam(id);
            return RedirectToAction("Index");
        }

    }
}

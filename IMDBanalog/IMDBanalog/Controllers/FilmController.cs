using IMDBanalog.Domain;
using IMDBanalog.Domain.Entities;
using IMDBanalog.Domain.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Controllers
{
    public class FilmController : Controller

    {

        private readonly IFilm _allfilms;
        private readonly IComment _allcomment;
        private readonly AppDbContext _appDbContext;


        public FilmController(IFilm allfilms, IComment allcoment,AppDbContext appDbContext)
        {
            _allcomment = allcoment;
            _allfilms = allfilms;
            _appDbContext = appDbContext;

        }
        // GET: FilmController
        public ActionResult Index(int id)
        {
            var film = _appDbContext.Films.Include(f=>f.UserRate).FirstOrDefault(f=>f.Id ==id);
            if(film!=null)
            {
              
            }
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string name, int rate, int id )
        {

            Film film = _allfilms.GetItem(id);
            _allcomment.Create(name, rate, film);


            return RedirectToAction("Index",film);
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

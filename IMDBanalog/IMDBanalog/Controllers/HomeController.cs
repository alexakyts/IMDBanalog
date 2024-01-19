using IMDBanalog.Domain;
using IMDBanalog.Domain.Entities;
using IMDBanalog.Domain.Repositories.Interface;
using IMDBanalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;
        private readonly IFilm _allfilms;
        private readonly AppDbContext _appDbContext;



        public HomeController(ILogger<HomeController> logger, IFilm allfilms, AppDbContext appDbContext)
        {
            _logger = logger;
            _allfilms = allfilms;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var films = _appDbContext.Films.Include(x=>x.UserRate).ToList();
            return View(films);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

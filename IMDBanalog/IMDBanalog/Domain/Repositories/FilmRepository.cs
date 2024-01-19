using IMDBanalog.Domain.Entities;
using IMDBanalog.Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Repositories
{
    public class FilmRepository : IFilm
    {
        private readonly AppDbContext dbContext;

        public FilmRepository()
        {
            dbContext = new AppDbContext();
        }
        public List<Film> GetItems()
        {
            return dbContext.Set<Film>().ToList();
        }

        public Film GetItem(int id)
        {
            return dbContext.Set<Film>().Find(id);
        }

        public void CreateItem (Film item )
        {
            dbContext.Set<Film>().Add(item);
            dbContext.SaveChanges();
        }

        public void DeleteIteam(int id)
        {
            Film item = dbContext.Set<Film>().Find(id);
            dbContext.Set<Film>().Remove(item);
            dbContext.SaveChanges();
        }
        public void UpdateItem(Film item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}

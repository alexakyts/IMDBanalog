using IMDBanalog.Domain.Entities;
using IMDBanalog.Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Repositories
{
    public class CommentRepository : IComment
    {

        private readonly AppDbContext dbContext;

        public CommentRepository()
        {
            dbContext = new AppDbContext();
        }

        public List<Comment> GetItems()
        {
            return dbContext.Set<Comment>().ToList();
        }

        public Comment GetItem(int id)
        {
            return dbContext.Set<Comment>().Find(id);
        }

        public void Create(string name, int rate, Film film)
        {
            film.UserRate ??= new List<Comment>();
            film.UserRate.Add(new Comment()
            {
                User = name,
                Rate = rate
            });
            dbContext.Set<Film>().Update(film);
             dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item  = dbContext.Set<Comment>().Find(id);
            dbContext.Set<Comment>().Remove(item);
            dbContext.SaveChanges();
        }
        public void UpdateItem(Comment item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}

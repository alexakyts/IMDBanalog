using IMDBanalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Repositories.Interface
{
    public interface IFilm
    {
        public List<Film> GetItems();

        public Film GetItem(int id);

        public void CreateItem(Film item);

        public void DeleteIteam(int id);

        public void UpdateItem(Film item);

      
    }
}

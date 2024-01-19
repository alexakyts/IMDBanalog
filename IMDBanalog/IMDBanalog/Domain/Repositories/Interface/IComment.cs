using IMDBanalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBanalog.Domain.Repositories.Interface
{
    public interface IComment
    {

        public List<Comment> GetItems();
        public Comment GetItem(int id);
        public void Create(string name, int rate, Film film);
        public void Delete(int id);

        public void UpdateItem(Comment item);

    }
}

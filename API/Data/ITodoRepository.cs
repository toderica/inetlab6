using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public interface ITodoRepository
    {
        public void Create(Todo todo);

        public IEnumerable<Todo> GetAll();

        public Todo GetById(int Id);
        public IEnumerable<Todo> GetActiveTodos();
        public IEnumerable<Todo> GetDoneTodos();
        public void Update(Todo todo);
        public void Remove(Todo todo);
    }
}

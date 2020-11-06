using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Todo todo)
        {
            _context.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos;
        }

        public Todo GetById(int Id)
        {
            return _context.Todos.Find(Id);
        }
        
        public IEnumerable<Todo> GetActiveTodos()
        {
            return _context.Todos.Where(todo => (todo.IsDone == false));
        }

        public IEnumerable<Todo> GetDoneTodos()
        {
            return _context.Todos.Where(todo => (todo.IsDone == true));
        }
        public void Update(Todo todo)
        {
            _context.Update(todo);
            _context.SaveChanges();
        }
        public void Remove(Todo todo)
        {
            _context.Remove(todo);
            _context.SaveChanges();
        }
    }
}

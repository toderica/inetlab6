using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public Boolean IsDone { get; set; } = false;

        public Todo(int id, String description)
        {
            this.Id = id;
            this.Description = description;
        }

        public Todo(int id, String description, DateTime created, Boolean isDone)
        {
            this.Id = id;
            this.Description = description;
            this.Created = created;
            this.IsDone = isDone;
        }
    }
}

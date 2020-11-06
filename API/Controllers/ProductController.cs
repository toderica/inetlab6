using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : ControllerBase
    {

        private ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Todo>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetById")]

        public ActionResult<Todo> GetById(int id) => _repository.GetById(id);


        [Route("active")]
        [HttpGet]

        public ActionResult<List<Todo>> GetActiveTodos() => _repository.GetActiveTodos().ToList();

        [Route("done")]
        [HttpGet]

        public ActionResult<List<Todo>> GetDoneTodos() => _repository.GetDoneTodos().ToList();

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _repository.Create(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Todo todo)
        {
            try
            {
                _repository.Update(todo);
                return NoContent();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something get wrong");
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            _repository.Remove(_repository.GetById(id));
            return NoContent();
        }


    }
}
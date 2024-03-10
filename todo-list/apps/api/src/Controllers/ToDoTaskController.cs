using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;
using Utility;

namespace ToDoApp.Controllers
{
    [Route("task")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoTaskController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllToDoTasks()
        {
            return await _context.ToDoTasks.Select(t => new TaskDTO()
            {
                Name = t.Name,
                Description = t.Description,
            }).ToListAsync();
        }

        // GET: api/task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO?>> GetOneTask(int id)
        {
            var task = _context.ToDoTasks.Where(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return await task.Select(t => new TaskDTO()
            {
                Name = t.Name,
                Description = t.Description,
            }).FirstOrDefaultAsync();
        }

        // PUT: api/task/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTask(int id, Models.Task task)
        // {
        //     _context.Entry(task).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!TaskExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }


        // GET: api/task
        [HttpPost("/getManyDynamic")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetDynamicManyToDoTasks(GetManyTaskDTO obj)
        {
            var taskList = _context.ToDoTasks.QueryParse(obj);

            if (obj.StartDate != null)
            {
                taskList = taskList.Where(t => obj.StartDate != null && t.CreatedAt >= obj.StartDate);
            }

            if (obj.EndDate != null)
            {
                taskList = taskList.Where(t => obj.EndDate != null && t.CreatedAt <= obj.EndDate);
            }

            var taskDTOs = await taskList.Select(t => new TaskDTO()
            {
                Name = t.Name,
                Description = t.Description,
            }).ToListAsync();

            return taskDTOs;
        }

        // GET: api/task
        [HttpPost("/getMany")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetManyToDoTasks(GetManyTaskDTO obj)
        {
            var taskList = _context.ToDoTasks.AsQueryable();
            if (obj.Name != null)
            {
                taskList = taskList.Where(t => t.Name == obj.Name);
            }

            if (obj.StartDate != null)
            {
                taskList = taskList.Where(t => t.CreatedAt >= obj.StartDate);
            }

            if (obj.EndDate != null)
            {
                taskList = taskList.Where(t => t.CreatedAt <= obj.EndDate);
            }

            if (obj.IsCompleted != null)
            {
                taskList = taskList.Where(t => t.IsCompleted == obj.IsCompleted);
            }
            var taskDTOs = await taskList.Select(t => new TaskDTO()
            {
                Name = t.Name,
                Description = t.Description,
            }).ToListAsync();

            return taskDTOs;
        }

        // POST: api/task
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Task>> PostTask(Models.Task task)
        {
            _context.ToDoTasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.ToDoTasks.Any(e => e.Id == id);
        }
    }
}

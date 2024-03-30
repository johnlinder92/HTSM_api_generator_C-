using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HTSM_api.Models;

namespace HTSM_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEnvironmentTasksController : ControllerBase
    {
        private readonly ProjectEnvironmentContext _context;

        public ProjectEnvironmentTasksController(ProjectEnvironmentContext context)
        {
            _context = context;
        }

        // GET: api/ProjectEnvironmentTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEnvironmentTask>>> GetProjectEnvironmentTasks()
        {
            return await _context.ProjectEnvironmentTasks.ToListAsync();
        }

        // GET: api/ProjectEnvironmentTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectEnvironmentTask>> GetProjectEnvironmentTask(long id)
        {
            var projectEnvironmentTask = await _context.ProjectEnvironmentTasks.FindAsync(id);

            if (projectEnvironmentTask == null)
            {
                return NotFound();
            }

            return projectEnvironmentTask;
        }

        // PUT: api/ProjectEnvironmentTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectEnvironmentTask(long id, ProjectEnvironmentTask projectEnvironmentTask)
        {
            if (id != projectEnvironmentTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectEnvironmentTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEnvironmentTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectEnvironmentTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectEnvironmentTask>> PostProjectEnvironmentTask(ProjectEnvironmentTask projectEnvironmentTask)
        {
            _context.ProjectEnvironmentTasks.Add(projectEnvironmentTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectEnvironmentTask", new { id = projectEnvironmentTask.Id }, projectEnvironmentTask);
        }

        // DELETE: api/ProjectEnvironmentTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectEnvironmentTask(long id)
        {
            var projectEnvironmentTask = await _context.ProjectEnvironmentTasks.FindAsync(id);
            if (projectEnvironmentTask == null)
            {
                return NotFound();
            }

            _context.ProjectEnvironmentTasks.Remove(projectEnvironmentTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectEnvironmentTaskExists(long id)
        {
            return _context.ProjectEnvironmentTasks.Any(e => e.Id == id);
        }
    }
}

using InspectionAPI.Data;
using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace InspectionAPI.Controllers
{
    [ApiController]
    [Route("api/Status")]
    public class StatusController : ControllerBase
    {
        private readonly DataContext context;

        public StatusController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> Get()
        {
            try
            {
                var listStatus = await this.context.Status.ToListAsync();
                if (listStatus is not null)
                {
                    return Ok(listStatus);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Status/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Status>> Get(int id)
        {
            try
            {
                var status = await this.context.Status.FindAsync(id);
                if (status is null)
                {
                    return NotFound();
                }
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Status/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Status>> Put(int id, Status status)
        {
            // se requiere que el "Id" coincida
            if (id != status.Id)
            {
                return BadRequest();
            }
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                // aquí modifica solo los campos que cambiaron de valor
                this.context.Entry(status).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Status
        [HttpPost]
        public async Task<ActionResult<Status>> Post(Status status)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                await this.context.AddAsync(status);
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Status
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                var status = await this.context.Status.FindAsync(id);
                if (status is not null)
                {
                    this.context.Remove(status);
                    await this.context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

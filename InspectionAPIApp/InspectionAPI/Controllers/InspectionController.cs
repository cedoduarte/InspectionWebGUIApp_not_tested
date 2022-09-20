using InspectionAPI.Data;
using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Controllers
{
    [ApiController]
    [Route("api/Inspection")]
    public class InspectionController : ControllerBase
    {
        private readonly DataContext context;

        public InspectionController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Inspection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspection>>> Get()
        {
            try
            {
                var listInspection = await this.context.Inspection.ToListAsync();
                if (listInspection is not null)
                {
                    return Ok(listInspection);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Inspection/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Inspection>> Get(int id)
        {
            try
            {
                var inspection = await this.context.Inspection.FindAsync(id);
                if (inspection is null)
                {
                    return NotFound();
                }
                return Ok(inspection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Inspection/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Inspection>> Put(int id, Inspection inspection)
        {
            // se requiere que el "Id" coincida
            if (id != inspection.Id)
            {
                return BadRequest();
            }
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                // aquí modifica solo los campos que cambiaron de valor
                this.context.Entry(inspection).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(inspection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Inspection
        [HttpPost]
        public async Task<ActionResult<Inspection>> Post(Inspection inspection)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                await this.context.AddAsync(inspection);
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(inspection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // DELETE: api/Inspection/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                var inspection = await this.context.Inspection.FindAsync(id);
                if (inspection is not null)
                {
                    this.context.Remove(inspection);
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

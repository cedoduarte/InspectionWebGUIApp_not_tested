using InspectionAPI.Data;
using Microsoft.AspNetCore.Mvc;
using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Controllers
{
    [ApiController]
    [Route("api/InspectionType")]
    public class InspectionTypeController : ControllerBase
    {
        private readonly DataContext context;

        public InspectionTypeController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Inspection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionType>>> Get()
        {
            try
            {
                var listInspectionType = await this.context.InspectionType.ToListAsync();
                if (listInspectionType is not null)
                {
                    return Ok(listInspectionType);
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

        // GET: api/InspectionType/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InspectionType>> Get(int id)
        {
            try
            {
                var inspectionType = await this.context.InspectionType.FindAsync(id);
                if (inspectionType is null)
                {
                    return NotFound();
                }
                return Ok(inspectionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/InspectionType/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<InspectionType>> Put(int id, InspectionType inspectionType)
        {
            // se requiere que el "Id" conicida
            if (id != inspectionType.Id)
            {
                return BadRequest();
            }
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                // aqui modifica solo los campos que cambiaron de valor
                this.context.Entry(inspectionType).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(inspectionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/InspectionType
        [HttpPost]
        public async Task<ActionResult<InspectionType>> Post(InspectionType inspectionType)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                await this.context.AddAsync(inspectionType);
                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(inspectionType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/InspectionType/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using var transaction = await this.context.Database.BeginTransactionAsync();
                var inspectionType = await this.context.InspectionType.FindAsync(id);
                if (inspectionType is not null)
                {
                    this.context.Remove(inspectionType);
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

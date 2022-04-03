using BicycleStore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BicycleStore.Controllers.Api
{
    [ApiController]
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class BicycleController : Controller
    {
        private readonly BicycleContext context;
        public BicycleController(BicycleContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Bicycle>>> Get()
        {
            return await context.Bicycles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bicycle>> Get(int id)
        {
            Bicycle bicycle = await context.Bicycles.FirstOrDefaultAsync(x => x.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return bicycle;
        }

        [HttpPost]
        public async Task<ActionResult<Bicycle>> Post(Bicycle bicycle)
        {
            if(bicycle.BicycleTitle == "" && bicycle.BicycleTitle == null)
            {
                ModelState.AddModelError("BicycleTitle", "Title is required");
            }
            if (bicycle.BicyclePrice < 700)
            {
                ModelState.AddModelError("BicyclePrice", "Price can't be less than 700");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Bicycles.Add(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }


        [HttpPut]
        public async Task<ActionResult<Bicycle>> Put(Bicycle bicycle)
        {
            if (!context.Bicycles.Any(x => x.BicycleId == bicycle.BicycleId))
            {
                return NotFound();
            }
            if (bicycle.BicycleTitle == "" && bicycle.BicycleTitle == null)
            {
                ModelState.AddModelError("BicycleTitle", "Title is required");
            }
            if (bicycle.BicyclePrice < 700)
            {
                ModelState.AddModelError("BicyclePrice", "Price can't be less than 700");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Update(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bicycle>> Delete(int id)
        {
            Bicycle bicycle = context.Bicycles.FirstOrDefault(x => x.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }
            context.Bicycles.Remove(bicycle);
            await context.SaveChangesAsync();
            return Ok(bicycle);
        }
    }
}

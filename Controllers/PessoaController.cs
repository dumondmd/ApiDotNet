using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using pessoa.Data;
using pessoa.Models;


namespace pessoa.Controllers
{
    [ApiController]
    [Route("pessoas")]

    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var pessoas = await context.Pessoas.ToListAsync();
            return pessoas;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Pessoa>> Post(
            [FromServices] DataContext context,
            [FromBody] Pessoa model)
        {
            if (ModelState.IsValid)
            {
                context.Pessoas.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }



        [HttpGet]
        [Route("/{codigo:int}")]

        public async Task<ActionResult<Pessoa>> GetById([FromServices] DataContext context, int codigo)
        {
            var pessoas = await context.Pessoas
                .Include(x => x.Pessoa)
                .AsNoTracking()
                .Where(x => x.PessoaCodigo == codigo)
                .ToListAsync();
        }
    }
}

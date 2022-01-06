using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueBird.Models;

namespace BlueBird.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroContext _context;

        public CadastroController(CadastroContext context)
        {
            _context = context;
        }

        // GET: api/Cadastro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroDTO>>> GetCadastro()
        {
            return await _context.Cadastro
                .Select(x => CadastroDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroDTO>> GetCadastro(long id)
        {
            var todoItem = await _context.Cadastro.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return CadastroDTO(Cadastro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCadastro(long id, CadastroDTO CadastroDTO)
        {
            if (id != CadastroDTO.Id)
            {
                return BadRequest();
            }

            var Cadastro = await _context.Cadastro.FindAsync(id);
            if (Cadastro == null)
            {
                return NotFound();
            }

            Cadastro.Nome = CadastroDTO.Nome;
            Cadastro.Idade = CadastroDTO.Idade;
            Cadastro.NomePai = CadastroDTO.NomePai;
            Cadastro.NomeMae = CadastroDTO.NomeMae;
            Cadastro.Convenio = CadastroDTO.Convenio;
            Cadastro.CelularResp = CadastroDTO.CelularResp;
            Cadastro.Endereco = CadastroDTO.Endereco;
            Cadastro.Medico = CadastroDTO.Medico;
            Cadastro.TerapeutaOcupacional = CadastroDTO.TerapeutaOcupacional;
            Cadastro.Fonoaudiologo = CadastroDTO.Fonoaudiologo;
            Cadastro.Escola = CadastroDTO.Escola;
            Cadastro.TelefoneEscola = CadastroDTO.TelefoneEscola;
            Cadastro.SerieEscolar = CadastroDTO.SerieEscolar;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CadastroExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CadastroDTO>> CreateTodoItem(CadastroDTO CadastroDTO)
        {
            var Cadastro = new Cadastro
            {
                Nome = CadastroDTO.Nome,
                Idade = CadastroDTO.Idade,
                NomePai = CadastroDTO.NomePai,
                NomeMae = CadastroDTO.NomeMae,
                Convenio = CadastroDTO.Convenio,
                CelularResp = CadastroDTO.CelularResp,
                Endereco = CadastroDTO.Endereco,
                Medico = CadastroDTO.Medico,
                TerapeutaOcupacional = CadastroDTO.TerapeutaOcupacional,
                Fonoaudiologo = CadastroDTO.Fonoaudiologo,
                Escola = CadastroDTO.Escola,
                TelefoneEscola = CadastroDTO.TelefoneEscola,
                SerieEscolar = CadastroDTO.SerieEscolar
            };

            _context.Cadastro.Add(Cadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCadastro),
                new { id = Cadastro.Id },
                CadastroDTO(Cadastro));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastro(long id)
        {
            var Cadastro = await _context.Cadastro.FindAsync(id);

            if (Cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastro.Remove(Cadastro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroExists(long id) =>
            _context.Cadastro.Any(e => e.Id == id);

        private static CadastroDTO CadastroDTO(Cadastro Cadastro) =>
            new CadastroDTO
            {
                Id = Cadastro.Id,
                Nome = Cadastro.Nome,
                Idade = Cadastro.Idade,
                NomePai = Cadastro.NomePai,
                NomeMae = Cadastro.NomeMae,
                Convenio = Cadastro.Convenio,
                CelularResp = Cadastro.CelularResp,
                Endereco = Cadastro.Endereco,
                Medico = Cadastro.Medico,
                TerapeutaOcupacional = Cadastro.TerapeutaOcupacional,
                Fonoaudiologo = Cadastro.Fonoaudiologo,
                Escola = Cadastro.Escola,
                TelefoneEscola = Cadastro.TelefoneEscola,
                SerieEscolar = Cadastro.SerieEscolar
            };   }
}

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
            var cadastro = await _context.Cadastro.FindAsync(id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return CadastroDTO(cadastro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCadastro(long id, CadastroDTO CadastroDTO)
        {
            if (id != CadastroDTO.Id)
            {
                return BadRequest();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            cadastro.Nome = CadastroDTO.Nome;
            cadastro.Idade = CadastroDTO.Idade;
            cadastro.NomePai = CadastroDTO.NomePai;
            cadastro.NomeMae = CadastroDTO.NomeMae;
            cadastro.Convenio = CadastroDTO.Convenio;
            cadastro.CelularResp = CadastroDTO.CelularResp;
            cadastro.Endereco = CadastroDTO.Endereco;
            cadastro.Medico = CadastroDTO.Medico;
            cadastro.TerapeutaOcupacional = CadastroDTO.TerapeutaOcupacional;
            cadastro.Fonoaudiologo = CadastroDTO.Fonoaudiologo;
            cadastro.Escola = CadastroDTO.Escola;
            cadastro.TelefoneEscola = CadastroDTO.TelefoneEscola;
            cadastro.SerieEscolar = CadastroDTO.SerieEscolar;
        

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
        public async Task<ActionResult<CadastroDTO>> CreateCasdatro(CadastroDTO CadastroDTO)
        {
            var cadastro = new Cadastro
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

            _context.Cadastro.Add(cadastro);
            await _context.SaveChangesAsync();

            return Ok(cadastro);
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

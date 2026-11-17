using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPortifolio.Data;
using ProjetoPortifolio.Models;


namespace ProjetoPortifolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;


        public AlunosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();


            return Ok("Aluno criado com sucesso.");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);
            if (alunoExistente == null)
                return Ok("Aluno não encontrado.");


            alunoExistente.Nome = aluno.Nome;
            alunoExistente.Email = aluno.Email;
            alunoExistente.turma = aluno.turma;
            alunoExistente.Professor = aluno.Professor;


            await _context.SaveChangesAsync();


            return Ok("Aluno atualizado com sucesso.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return Ok("Aluno não encontrado.");


            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();


            return Ok("Aluno excluído com sucesso.");
        }
    }
}
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Adicionar(Usuario entidade)
        {
            // guardando na memória
            await _context.Usuario.AddAsync(entidade);
            // e dando insert dentro da tabela usuario
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Usuario> Atualizar(Usuario entidade)
        {
            Usuario entidadeBanco = await _context.Usuario
                .Where(u => u.Id == entidade.Id)
                .FirstOrDefaultAsync();

            // Atualizar, contexto entre na entidadeBanco, Veja quais são os valores e troque pra min por essa entidade, 
            // assim atualiza só o que precisa, ex: só o nome, só o e-mail
            _context.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _context.Update<Usuario>(entidadeBanco);

            await _context.SaveChangesAsync();
            return entidadeBanco;
        }

        public async Task Deletar(Usuario entidade)
        {
            // Aqui deleta fisico, deleta primeiro no contexto e depois no banco
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Usuario?> Obter(string email)
        {
            return await _context.Usuario.AsNoTracking()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        // Obter todos
        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _context.Usuario.AsNoTracking()
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<Usuario?> Obter(long id)
        {
            return await _context.Usuario.AsNoTracking()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
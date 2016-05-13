using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Domain.Interfaces.Repository
{
    /* O 'IClienteRepository' irá implementar um 'IRepository' mas de um 'Cliente' */
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);
    }
}
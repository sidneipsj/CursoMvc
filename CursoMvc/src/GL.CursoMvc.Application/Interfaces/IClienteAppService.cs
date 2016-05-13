using System;
using System.Collections;
using System.Collections.Generic;
using GL.CursoMvc.Application.ViewModel;
using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        /* Aqui no método 'Adicionar' vamos incluir os dados do Cliente e mais o Endereco tudo junto!! */
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);

        ClienteViewModel ObterPorId(Guid id);

        ClienteViewModel ObterPorCpf(string cpf);

        ClienteViewModel ObterPorEmail(string email);

        IEnumerable<ClienteViewModel> ObterTodos();

        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);

        void Remover(Guid id);
    }
}
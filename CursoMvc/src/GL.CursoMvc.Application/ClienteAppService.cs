using System;
using System.Collections.Generic;
using AutoMapper;
using GL.CursoMvc.Application.Interfaces;
using GL.CursoMvc.Application.ViewModel;
using GL.CursoMvc.Domain.Entities;
using GL.CursoMvc.Infra.Data.Repositories;

namespace GL.CursoMvc.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            /* Aqui estamos armazenando uma pilha de Endereco em Endereços.
             * Assim estamos cadastrando o cliente junto com o endereço */
            cliente.Enderecos.Add(endereco);

            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            _clienteRepository.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
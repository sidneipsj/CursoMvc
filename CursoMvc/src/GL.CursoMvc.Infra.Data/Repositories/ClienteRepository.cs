using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GL.CursoMvc.Domain.Entities;
using GL.CursoMvc.Domain.Interfaces.Repository;

namespace GL.CursoMvc.Infra.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf)
        {
            /* 'FirstOrDefault' usado aqui para poder retornar um único resultado e não
             * uma lista de resultados */
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        /* Método para poder 'remover' o cliente de maneira lógica e não física */
        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        /* Esse método irá retornar todos os clientes
         * via micro ORM: "Dapper" */
        public override IEnumerable<Cliente> ObterTodos()
        {
            var con = Db.Database.Connection;

            var query = @"select * from clientes";

            return con.Query<Cliente>(query);
        }

        /*Esse método irá retornar uma coleção de Clientes através de um inner join de Endereço
         utilizando o "Dapper */
        public override Cliente ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;

            var query = @"select * from Clientes c " +
                        "LEFT JOIN Enderecos e" +
                        "ON c.ClienteId = e.ClienteId " +
                        "WHERE c.ClienteId = @sid";

            /*Precisamos aqui definir o que ele vai retornar e nesse caso por isso o terceiro parâmetro
             como 'Cliente' */
            var cliente = con.Query<Cliente, Endereco, Cliente>(query,
                (cli, end) =>
                {
                    cli.Enderecos.Add(end);
                    return cli;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();
        }
    }
}
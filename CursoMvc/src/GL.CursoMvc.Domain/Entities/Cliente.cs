using System;
using System.Collections.Generic;

namespace GL.CursoMvc.Domain.Entities
{
    public class Cliente
    {
        /*Criamos aqui um método para que todas as vezes que for 
         criar um novo Id possa ser gerado um novo GUID*/
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        //Um Cliente tem coleção de Endereços: Relacionamento de 1 para n
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}

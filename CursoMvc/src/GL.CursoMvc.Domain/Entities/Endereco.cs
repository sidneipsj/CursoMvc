using System;

namespace GL.CursoMvc.Domain.Entities
{
    public class Endereco
    {
        /*Criamos aqui um método para que todas as vezes que for 
         criar um novo Id possa ser gerado um novo GUID*/
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        //Chave Estrangeira: ClienteId (sempre pensar em bd)
        public Guid ClienteId { get; set; }

        //Relacionamento de: Endereco - Cliente:
        public virtual Cliente Cliente { get; set; }
    }
}

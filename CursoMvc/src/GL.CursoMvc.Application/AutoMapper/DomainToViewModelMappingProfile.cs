using AutoMapper;
using GL.CursoMvc.Application.ViewModel;
using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        /* Quando herdamos a classe 'Profile' automaticamente temos que criar uma classe override chamada
         * 'Configure' */
        protected override void Configure()
        {
            /* Aqui estamos mapeando de Cliente para ClienteViewModel. 
             * Ou seja, de Domain para ClienteViewModel */
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Cliente, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}
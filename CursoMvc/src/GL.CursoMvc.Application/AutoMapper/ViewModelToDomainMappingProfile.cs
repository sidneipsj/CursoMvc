using AutoMapper;
using GL.CursoMvc.Application.ViewModel;
using GL.CursoMvc.Domain.Entities;

namespace GL.CursoMvc.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            /* Aqui estamos mapeando de Cliente para ClienteViewModel. 
             * Ou seja, de ViewModel para Domain */
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Cliente>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Endereco>();
            Mapper.CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}
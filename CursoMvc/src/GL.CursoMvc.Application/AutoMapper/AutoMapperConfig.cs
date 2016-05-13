using AutoMapper;

namespace GL.CursoMvc.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DomainToViewModelMappingProfile>();
                m.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
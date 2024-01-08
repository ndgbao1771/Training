using AutoMapper;

namespace Training.Service.Automap
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModel());
                cfg.AddProfile(new ViewModelToDomain());
            });
        }
    }
}
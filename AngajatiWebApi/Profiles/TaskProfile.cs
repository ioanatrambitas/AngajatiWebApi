using AutoMapper;

namespace AngajatiWebApi.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Entities.Task, ExternalModels.TaskDTO>();
            CreateMap<ExternalModels.TaskDTO, Entities.Task>();
        }
    }
}

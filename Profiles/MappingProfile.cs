using AutoMapper;
using TaskApp.Models;
using TaskApp.Dtos;

namespace TaskApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskReadDto>();
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();
        }
    }
}

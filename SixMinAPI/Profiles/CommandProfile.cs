using AutoMapper;
using SixMinApi.Dtos;
using SixMinApi.Models;

namespace SixMinApi.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            //Source -> Target
            CreateMap<Commandm, CommandReadDto>();
            CreateMap<CommandCreateDto, Commandm>();
            CreateMap<CommandUpdateDto, Commandm>();
        }
    }
}
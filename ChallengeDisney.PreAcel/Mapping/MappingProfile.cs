using AutoMapper;
using ChallengeDisney.PreAcel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeDisney.PreAcel.DTO.GET;

namespace ChallengeDisney.PreAcel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ENTITIES TO DTO
            CreateMap<MovieOrSerie, MovieOrSerieDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.GetDate, opt => opt.MapFrom(src => src.GetDate))
                .ForMember(dest => dest.Characters, opt => opt.MapFrom(src => src.Characters));

            CreateMap<Character, CharacterDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));


        }
    }
}

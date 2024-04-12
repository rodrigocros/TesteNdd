using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.application.ViewModel;
using TesteNDD.domain.Entities;

namespace TesteNdd.application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserViewModel>().ForMember(dest => dest.Nome, src => src.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sexo, src => src.MapFrom(x => x.Sexo))
                .ForMember(dest => dest.Telefone, src => src.MapFrom(x => x.Telefone))
                .ForMember(dest => dest.DataNascimento, src => src.MapFrom(x => x.DataNascimento))
                .ForMember(dest => dest.Observacao, src => src.MapFrom(x => x.Observacao))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email));
        }
    }
}

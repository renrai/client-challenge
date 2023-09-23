using AutoMapper;
using ProjectChallengeData.Database.Entities;
using ProjectChallengeDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeData.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientEntity, Client>()
            .ReverseMap();
        }
    }
}

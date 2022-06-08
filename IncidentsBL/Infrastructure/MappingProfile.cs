using AutoMapper;
using IncidentsBL.Models;
using IncidentsDL.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentsBL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Incident, IncidentModel>().ReverseMap();
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Contact, ContactModel>().ReverseMap();
        }
    }
}

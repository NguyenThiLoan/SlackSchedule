using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackSchedule.Models.Dto.MappingProfiles
{
    public class ProjectIndexDtoMappingProfile : Profile
    {
        public ProjectIndexDtoMappingProfile()
        {
            CreateMap<Project, ProjectIndexDto>()
                .ForMember(d => d.CustomerName, m => m.MapFrom(s => s.Customer.CustomerName))
                .ForMember(d => d.LeaderName, m => m.MapFrom(s => s.Member.Name))
                .ForMember(d => d.StateName, m => m.MapFrom(s => s.MstProjectState.StateName))
                .ForMember(d => d.CoderName, m => m.MapFrom(s => String.Join(",",
                                                             s.ProjectMembers
                                                            .Where(pm => pm.RoleId == 1)
                                                            .Select(pm => pm.Member.Name))
                                                            )
                          )
                .ForMember(d => d.TesterName, m => m.MapFrom(s => String.Join(",",
                                                             s.ProjectMembers
                                                            .Where(pm => pm.RoleId == 2)
                                                            .Select(pm => pm.Member.Name))
                                                            )
                          );

            //CreateMap<SampleDto, Member>().ForMember(s => s.Class, m => m.MapFrom(d => new Class() { Class_id = d.Class_id, Name = d.Cname }));
        }

    }
}
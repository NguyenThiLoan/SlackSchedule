using AutoMapper;
using EntityFramework.DbContextScope.Interfaces;
using HPBFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Configuration;
using SlackSchedule.Models;
using SlackSchedule.Models.Dto;
using SlackSchedule.Models.Repositories.IRepositories;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Services
{
    public class HomeService : ServiceBase, IHomeService
    {
        IMemberRepository _memberRepository;
        IProjectRepository _projectRepository;
        public HomeService(IDbContextScopeFactory dbContextScopeFactory, IMemberRepository memberRepository, IProjectRepository projectRepository)
            : base(dbContextScopeFactory)
        {
            _memberRepository = memberRepository;
            _projectRepository = projectRepository;
        }

        
    }
}
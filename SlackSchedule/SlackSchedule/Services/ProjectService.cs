using System;
using System.Collections.Generic;
using EntityFramework.DbContextScope.Interfaces;
using HPBFramework;
using SlackSchedule.Models;
using SlackSchedule.Models.Dto;
using SlackSchedule.Models.Repositories.IRepositories;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Services
{
    public class ProjectService : ServiceBase, IProjectService
    {
        IProjectRepository _projectRepository;
        public ProjectService(IDbContextScopeFactory dbContextScopeFactory, IProjectRepository projectRepository)
            : base(dbContextScopeFactory)
        {
            _projectRepository = projectRepository;
        }

        public void DeleteProject(Project project)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _projectRepository.Delete(project);
                dbContext.SaveChanges();
            }
        }

        public Project GetProjectById(int Id)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                return _projectRepository.GetDataById(Id);
            }
        }

        public List<ProjectIndexDto> GetProjectIndexDto()
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                var projects = _projectRepository.GetData();
                var projectDto = AutoMapper.Mapper.Map<List<ProjectIndexDto>>(projects);
                return projectDto;
            }
        }

        public List<Project> GetProjects()
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                return _projectRepository.GetData();
            }
        }

        public Project InsertProject(Project project)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _projectRepository.Insert(project);
                dbContext.SaveChanges();
                return project;
            }
        }

        public void UpdateProject(Project project)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _projectRepository.Insert(project);
                dbContext.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlackSchedule.Models;
using SlackSchedule.Models.Dto;

namespace SlackSchedule.Services.IServices
{
    public interface IProjectService
    {
        List<Project> GetProjects();
        List<ProjectIndexDto> GetProjectIndexDto();
        Project GetProjectById(int Id);
        void UpdateProject(Project member);
        Project InsertProject(Project member);
        void DeleteProject(Project member);
    }
}

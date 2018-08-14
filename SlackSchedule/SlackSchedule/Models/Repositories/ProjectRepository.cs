using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SlackSchedule.Models.Repositories.IRepositories;

namespace SlackSchedule.Models.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(IAmbientDbContextLocator dbContext)
            : base(dbContext)
        {
        }

        public List<Project> GetData()
        {
            return this.Get().ToList();
        }

        public Project GetDataById(int id)
        {
            return this.Get().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
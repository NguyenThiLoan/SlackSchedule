using HPBFramework.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackSchedule.Models.Repositories.IRepositories
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        Project GetDataById(int id);
        List<Project> GetData();
    }
}

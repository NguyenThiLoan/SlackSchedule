using HPBFramework.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackSchedule.Models.Repositories.IRepositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        Member GetDataById(int id);
        List<Member> GetData();
    }
}

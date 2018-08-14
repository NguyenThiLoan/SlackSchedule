using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SlackSchedule.Models.Repositories.IRepositories;

namespace SlackSchedule.Models.Repositories
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(IAmbientDbContextLocator dbContext)
            : base(dbContext)
        {
        }

        public Member GetDataById(int id)
        {
            return this.Get().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Member> GetData()
        {
            return this.Get().ToList();
        }

    }
}
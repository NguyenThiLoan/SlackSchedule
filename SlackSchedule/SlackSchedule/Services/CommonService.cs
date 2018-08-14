using System;
using EntityFramework.DbContextScope.Interfaces;
using HPBFramework;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Services
{
    public class CommonService : ServiceBase, ICommonService
    {
        public CommonService(IDbContextScopeFactory dbContextScopeFactory)
            : base(dbContextScopeFactory)
        {
        }

        public void test()
        {
            //throw new NotImplementedException();
        }
    }
}
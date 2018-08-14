using System;
using System.Collections.Generic;
using EntityFramework.DbContextScope.Interfaces;
using HPBFramework;
using SlackSchedule.Models;
using SlackSchedule.Models.Repositories.IRepositories;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Services
{
    public class MemberService : ServiceBase, IMemberService
    {
        IMemberRepository _memberRepository;
        public MemberService(IDbContextScopeFactory dbContextScopeFactory, IMemberRepository memberRepository)
            : base(dbContextScopeFactory)
        {
            _memberRepository = memberRepository;
        }

        public void DeleteMember(Member member)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _memberRepository.Delete(member);
                dbContext.SaveChanges();
            }
        }

        public List<Member> GetMembers()
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                return _memberRepository.GetData();
            }
        }

        public Member GetMemberById(int Id)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                return _memberRepository.GetDataById(Id);
            }
        }

        public Member InsertMember(Member member)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _memberRepository.Insert(member);
                dbContext.SaveChanges();
                return member;
            }
        }

        public void UpdateMember(Member member)
        {
            using (var dbContext = _dbContextScopeFactory.Create())
            {
                _memberRepository.Update(member);
                dbContext.SaveChanges();
            }
        }
    }
}
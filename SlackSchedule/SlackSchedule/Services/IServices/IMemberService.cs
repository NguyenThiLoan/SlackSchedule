using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlackSchedule.Models;
using SlackSchedule.Models.Dto;

namespace SlackSchedule.Services.IServices
{
    public interface IMemberService
    {
        List<Member> GetMembers();
        Member GetMemberById(int Id);
        void UpdateMember(Member member);
        Member InsertMember(Member member);
        void DeleteMember(Member member);
    }
}

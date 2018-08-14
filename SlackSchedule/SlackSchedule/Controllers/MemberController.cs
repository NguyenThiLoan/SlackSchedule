using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPBFramework.Logger;
using SlackSchedule.App_LocalResources;
using SlackSchedule.Models;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Controllers
{
    public class MemberController : ControllerExtention
    {
        IMemberService _memberService;
        public MemberController(ILoggingService loggingService, ICommonService commonService, IMemberService memberService) 
            : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
            _memberService = memberService;
        }

        // GET: Management
        public ActionResult Index()
        {
            ViewData["message"] = getTempMessage();

            var listMember = _memberService.GetMembers();

            return View(listMember);
        }

        #region EDIT
        [HttpGet] //For Get
        public ActionResult Edit(int? id)
        {
            Member member = new Member()
            {
                Active = true
            };
            if (id.GetValueOrDefault(0) != 0)
            {
                member = _memberService.GetMemberById(id.Value);
            }

            if (member == null)
            {
                setTempMessage(MessageResource.info_DataNotExist);
            }

            ViewData["message"] = getTempMessage();

            return View(member);
        }

        [HttpPost] //For Create
        [ActionName("Edit")]
        public ActionResult Edit_Post(Member member)
        {
            if (!ModelState.IsValid)
            {
                goto RETURN_VIEW;
            }

            member = _memberService.InsertMember(member);
            setTempMessage(MessageResource.info_DataSaved);
            return RedirectToAction("Edit", new { id = member.Id });

            RETURN_VIEW:
            return View(member);
        }

        [HttpPut] //For Update
        [ActionName("Edit")]
        public ActionResult Edit_Put(Member member)
        {
            if (!ModelState.IsValid)
            {
                goto RETURN_VIEW;
            }

            _memberService.UpdateMember(member);
            setTempMessage(MessageResource.info_DataSaved);
            return RedirectToAction("Edit", new { id = member.Id });

            RETURN_VIEW:
            return View(member);
        }

        [HttpDelete] //For Delete
        [ActionName("Edit")]
        public ActionResult Edit_Delete(Member member)
        {
            _memberService.DeleteMember(member);
            setTempMessage(MessageResource.info_DataDeleted);
            return RedirectToAction("Index");
        }

        #endregion


        public ActionResult Info(string id)
        {
            return View();
        }
    }
}
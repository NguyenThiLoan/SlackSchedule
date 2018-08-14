using FluentValidation;
using SlackSchedule.App_LocalResources;
using SlackSchedule.Helper;
using SlackSchedule.Models;

namespace SlackSchedule.Validations
{
    public class MemberValidator : AbstractValidator<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberValidator"/> class.
        /// </summary>
        public MemberValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(MessageResource.error_Required.Format2(TextResource.member_Name));
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(MessageResource.error_Required.Format2(TextResource.member_Email))
                .EmailAddress().WithMessage(MessageResource.error_Format.Format2(TextResource.member_Email));
            RuleFor(x => x.SlackId).NotEmpty().WithMessage(MessageResource.error_Required.Format2(TextResource.member_SlackID));
        }
    }
}
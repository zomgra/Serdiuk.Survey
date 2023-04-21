using Microsoft.AspNetCore.Mvc;
using Serdiuk.Survey.Application.Common.Base;
using Serdiuk.Survey.Application.Questions.SubmitAnswer;

namespace Serdiuk.Survey.WebApi.Controllers
{
    public class QuestionController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ApplyAnswerAsync(SubmitAnswerCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(e=>e.Message));

            return Ok();
        }
    }
}

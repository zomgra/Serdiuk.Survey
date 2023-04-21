using Microsoft.AspNetCore.Mvc;
using Serdiuk.Survey.Application.Common.Base;
using Serdiuk.Survey.Application.Surveys.GetById;
using Serdiuk.Survey.Application.Surveys.GetSurveyList;
using System.Threading;

namespace Serdiuk.Survey.WebApi.Controllers
{
    public class SurveyController : BaseApiController
    {
        /// <summary>
        /// Get surveys by Number of Page
        /// </summary>
        /// <param name="pageNumber">Number next page</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of Survey</returns>
        [HttpGet]
        public async Task<IActionResult> GetSurveysList([FromQuery] int pageNumber, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetSurveyListQuery { PageNumber = pageNumber }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(s => s.Message));

            return Ok(result.Value);
        }
        [HttpGet("{surveyId}")]
        public async Task<IActionResult> GetSurverById(int surveyId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetSurveyByIdQuery { SurveyId = surveyId} , cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(s => s.Message));

            return Ok(result.Value);
        }
    }
}

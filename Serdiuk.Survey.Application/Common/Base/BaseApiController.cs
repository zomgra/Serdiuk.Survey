using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Serdiuk.Survey.Application.Common.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected IMediator Mediator =>
            HttpContext.RequestServices.GetService<IMediator>();
    }
}

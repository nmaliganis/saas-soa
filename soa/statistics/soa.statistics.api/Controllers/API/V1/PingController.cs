using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.statistics.api.Controllers.API.Base;

namespace soa.statistics.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  public class PingController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;
    public PingController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;
    }

    /// <summary>
    /// Ping - Response
    /// </summary>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="400">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "DeleteHardTagRoot")]
    public async Task<IActionResult> DeleteHardTagRoot()
    {
      return Ok();
    }
  }
}

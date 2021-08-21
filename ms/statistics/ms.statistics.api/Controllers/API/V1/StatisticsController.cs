using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.common.dtos.Vms.Statistics;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.statistics.api.Controllers.API.Base;
using soa.statistics.api.Helpers.Services.Blocks;
using soa.statistics.api.Helpers.Services.Blocks.Statistics.Contracts;
using soa.statistics.api.Validators;

namespace soa.statistics.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  public class StatisticsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllStatisticsProcessor _inquiryAllStatisticsProcessor;
    private readonly IInquiryStatisticProcessor _inquiryStatisticProcessor;
    private readonly ICreateStatisticProcessor _createStatisticProcessor;

    public StatisticsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IStatisticsControllerDependencyBlock blockStatistic)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllStatisticsProcessor = blockStatistic.InquiryAllStatisticsProcessor;
      _inquiryStatisticProcessor = blockStatistic.InquiryStatisticProcessor;
      _createStatisticProcessor = blockStatistic.CreateStatisticProcessor;
    }

    /// <summary>
    /// POST : Create a New Statistic.
    /// </summary>
    /// <param name="statisticForCreationDto">StatisticForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Statistic is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Statistic is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostStatisticRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostStatisticRouteAsync([FromBody] StatisticForCreationUiModel statisticForCreationDto)
    {
      var newCreatedStatistic = await _createStatisticProcessor.CreateStatisticAsync(statisticForCreationDto);

      switch (newCreatedStatistic.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostStatisticRouteAsync -- Message:Statistic_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- StatisticInfo:{statisticForCreationDto.Title}");
          return Created(nameof(PostStatisticRouteAsync), newCreatedStatistic);
        }
        case ("ERROR_Statistic_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostStatisticRouteAsync -- Message:ERROR_Statistic_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- StatisticInfo:{statisticForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Statistic_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Statistic_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostStatisticRouteAsync -- Message:ERROR_Statistic_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- StatisticInfo:{statisticForCreationDto.Title}");
          return BadRequest(new {errorMessage = "Statistic_ALREADY_EXISTS"});
        }
        case ("ERROR_Statistic_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostStatisticRouteAsync -- Message:ERROR_Statistic_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- StatisticInfo:{statisticForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Statistic"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostStatisticRouteAsync -- Message:ERROR_CREATION_NEW_Statistic -- Datetime:{DateTime.UtcNow} " +
            $"-- StatisticInfo:{statisticForCreationDto.Title}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Statistic"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Statistic Id
    /// </summary>
    /// <param name="id">Statistic Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Statistic</param>
    /// <remarks>Retrieve Statistic Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetStatistic")]
    public async Task<IActionResult> GetStatisticAsync(int id)
    {
      var statisticFromRepo = await _inquiryStatisticProcessor.GetStatisticByIdAsync(id);

      if (statisticFromRepo == null)
      {
        return NotFound();
      }

      var statistic = Mapper.Map<StatisticUiModel>(statisticFromRepo);

      return Ok(statistic);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Statistics 
    /// </summary>
    /// <remarks>Retrieve paged Statistics providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetStatistics")]
    public async Task<IActionResult> GetStatisticsAsync()
    {
      var statisticsQueryable =
        await _inquiryAllStatisticsProcessor.GetStatisticsAsync();

      var statistics = Mapper.Map<IEnumerable<StatisticUiModel>>(statisticsQueryable);

      return Ok(statistics);
    }
  }
}

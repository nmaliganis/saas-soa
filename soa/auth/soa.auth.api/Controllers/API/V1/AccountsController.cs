using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using soa.auth.api.Controllers.API.Base;
using soa.auth.api.Helpers.Services.Blocks;
using soa.common.dtos.Vms.Accounts;
using soa.common.infrastructure.PropertyMappings.TypeHelpers;
using soa.auth.api.Helpers.Services.Blocks.Statistics.Contracts;
using soa.auth.api.Validators;

namespace soa.auth.api.Controllers.API.V1
{
  [Produces("application/json")]
  [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : BaseController
  {
    private readonly IUrlHelper _urlHelper;
    private readonly ITypeHelperService _typeHelperService;

    private readonly IInquiryAllAccountsProcessor _inquiryAllAccountsProcessor;
    private readonly IInquiryAccountProcessor _inquiryAccountProcessor;
    private readonly ICreateAccountProcessor _createAccountProcessor;

    public AccountsController(IUrlHelper urlHelper,
      ITypeHelperService typeHelperService,
      IAccountsControllerDependencyBlock blockAccount)
    {
      _urlHelper = urlHelper;
      _typeHelperService = typeHelperService;

      _inquiryAllAccountsProcessor = blockAccount.InquiryAllAccountsProcessor;
      _inquiryAccountProcessor = blockAccount.InquiryAccountProcessor;
      _createAccountProcessor = blockAccount.CreateAccountProcessor;
    }

    /// <summary>
    /// POST : Create a New Account.
    /// </summary>
    /// <param name="accountForCreationDto">AccountForCreationDto the Request Model for Creation</param>
    /// <remarks> return a ResponseEntity with status 201 (Created) if the new Account is created, 400 (Bad Request), 500 (Server Error) </remarks>
    /// <response code="201">Created (if the Account is created)</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost(Name = "PostAccountRoute")]
    [ValidateModel]
    public async Task<IActionResult> PostAccountRouteAsync([FromBody] AccountForCreationUiModel accountForCreationDto)
    {
      var newCreatedAccount = await _createAccountProcessor.CreateAccountAsync(accountForCreationDto);

      switch (newCreatedAccount.Message)
      {
        case ("SUCCESS_CREATION"):
        {
          Log.Information(
            $"--Method:PostAccountRouteAsync -- Message:Account_CREATION_SUCCESSFULLY -- Datetime:{DateTime.Now}" +
            $" -- AccountInfo:{accountForCreationDto.Username}");
          return Created(nameof(PostAccountRouteAsync), newCreatedAccount);
        }
        case ("ERROR_Account_MULTIPLE_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostAccountRouteAsync -- Message:ERROR_Account_MULTIPLE_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- AccountInfo:{accountForCreationDto.Username}");
          return BadRequest(new {errorMessage = "Account_MULTIPLE_ENTRIES_ALREADY_EXISTS"});
        }
        case ("ERROR_Account_ALREADY_EXISTS"):
        {
          Log.Error(
            $"--Method:PostAccountRouteAsync -- Message:ERROR_Account_ALREADY_EXISTS -- Datetime:{DateTime.UtcNow} " +
            $"-- AccountInfo:{accountForCreationDto.Username}");
          return BadRequest(new {errorMessage = "Account_ALREADY_EXISTS"});
        }
        case ("ERROR_Account_MADE_PERSISTENT"):
        {
          Log.Error(
            $"--Method:PostAccountRouteAsync -- Message:ERROR_Account_MADE_PERSISTENT -- Datetime:{DateTime.UtcNow} " +
            $"-- AccountInfo:{accountForCreationDto.Username}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Account"});
        }
        case ("UNKNOWN_ERROR"):
        {
          Log.Error(
            $"--Method:PostAccountRouteAsync -- Message:ERROR_CREATION_NEW_Account -- Datetime:{DateTime.UtcNow} " +
            $"-- AccountInfo:{accountForCreationDto.Username}");
          return BadRequest(new {errorMessage = "ERROR_CREATION_NEW_Account"});
        }
      }

      return NotFound();
    }


    /// <summary>
    /// Get : Retrieve Stored providing Account Id
    /// </summary>
    /// <param name="id">Account Id the Request Index for Retrieval</param>
    /// <param name="fields">Fiends to be filtered with for the returned Account</param>
    /// <remarks>Retrieve Account Role providing Id and [Optional] fields</remarks>
    /// <response code="200">Resource retrieved correctly</response>
    /// <response code="404">Resource Not Found</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet("{id}", Name = "GetAccount")]
    public async Task<IActionResult> GetAccountAsync(int id)
    {
      var accountFromRepo = await _inquiryAccountProcessor.GetAccountByIdAsync(id);

      if (accountFromRepo == null)
      {
        return NotFound();
      }

      var Account = Mapper.Map<AccountUiModel>(accountFromRepo);

      return Ok(Account);
    }


    /// <summary>
    /// Get : Retrieve All/or Partial Paged Stored Accounts 
    /// </summary>
    /// <remarks>Retrieve paged Accounts providing Paging Query</remarks>
    /// <response code="200">Resource retrieved correctly.</response>
    /// <response code="500">Internal Server Error.</response>
    [HttpGet(Name = "GetAccounts")]
    public async Task<IActionResult> GetAccountsAsync()
    {
      var accountsQueryable =
        await _inquiryAllAccountsProcessor.GetAccountsAsync();

      var accounts = Mapper.Map<IEnumerable<AccountUiModel>>(accountsQueryable);

      return Ok(accounts);
    }
  }
}

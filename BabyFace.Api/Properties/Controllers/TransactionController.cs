using Couponz.Lucky.Domain.Model.ViewModels.Offer;
using Couponz.Lucky.Domain.Model.ViewModels.Transaction;
using Couponz.Lucky.Domain.Model.ViewModels.UserSavings;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [Authorize]
  [RoutePrefix("api/Transaction")]
  public class TransactionController : ApiController
  {
    private readonly Lazy<ILuckyUserService> _luckyUserService;
    private readonly Lazy<ITransactionService> _transactionService;

    public TransactionController(Lazy<ILuckyUserService> luckyUserService, Lazy<ITransactionService> transactionService)
    {
      _luckyUserService = luckyUserService;
      _transactionService = transactionService;
    }


    [AuthorizeUser]
    [HttpGet]
    [Route("user-savings")]
    public async Task<UserSavingsProperties> GetUserSavings()
    {
      return await _luckyUserService.Value.GetSavings(HttpContext.Current.User.Identity.GetUserId());
    }

    [HttpGet]
    [AuthorizeUser]
    [Route("user-savings-per-category")]
    public async Task<List<UserSavingsPerCategory>> GetUserSavingsPerCategory()
    {
      return await _luckyUserService.Value.GetSavingsPerCategory(HttpContext.Current.User.Identity.GetUserId());
    }

    [HttpGet]
    [AuthorizeUser]
    [Route("user-savings-per-month")]
    public async Task<List<UserSavingsProperties>> GetUserSavingsPerMonth()
    {
      return await _luckyUserService.Value.GetSavingsPerMonth(HttpContext.Current.User.Identity.GetUserId());
    }
    [HttpGet]
    [AuthorizeUser]
    [Route("user-offers")]
    public async Task<Dictionary<string, List<OfferProperties>>> GetUserOffers(int languageId = 1)
    {
      return await _luckyUserService.Value.GetOffers(HttpContext.Current.User.Identity.GetUserId(), languageId);
    }
    [HttpPost]
    [AuthorizeUser]
    [Route("user-history")]
    public HistoryTransaction GetHistoryTransactions(UserHistoryTransactionInput model)
    {
      return _transactionService.Value.GetUserTransactionsHistory(model);
    }
    [HttpPost]
    [AuthorizeUser]
    [Route("user-saving-history")]
    public async Task<SavingHistoryTransaction> GetUserSavingHistoryAsync(UserHistoryTransactionInput model)
    {
      return await _transactionService.Value.GetUserTransactionsSavingHistoryAsync(model);
    }
  }
}
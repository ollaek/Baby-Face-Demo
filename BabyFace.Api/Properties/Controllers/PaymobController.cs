using Couponz.Lucky.Domain.Model.ViewModels.Paymob;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
  [RoutePrefix("api/Paymob")]
  public class PaymobController : ApiController
  {
    private readonly Lazy<IPaymentService> _paymentService;

    public PaymobController(Lazy<IPaymentService> paymentService)
    {
      _paymentService = paymentService;
    }
    [AuthorizeUser]
    [Route("get-payment-key-cc")]
    [HttpGet]
    public Task<string> GetPaymentKeyForCCPayment(int amount, string bundleId)
    {
      return _paymentService.Value.PayByCreditCardAsync(amount, Guid.Parse(bundleId), HttpContext.Current.User.Identity.GetUserId());
    }
    [AuthorizeUser]
    [Route("Pay-cash")]
    [HttpPost]
    public Task<string> PaybyCash(CashPaymentInputModel model)
    {
      return _paymentService.Value.PayByCashAsync(model);
    }
    public HttpStatusCode PaymobNotificationCallback([FromUri] string hmac,
      [FromBody] NotificationCallbackRequestData data)
    {
      var response = _paymentService.Value.NotificationCallbackAsync(hmac, data, HttpContext.Current.User.Identity.GetUserId());
      if (response.Result)
        return HttpStatusCode.OK;
      return HttpStatusCode.BadRequest;
    }

    [AuthorizeUser]
    [Route("pay-kiosk")]
    [HttpPost]
    public async Task<PayByKioskOutputModel> PayByKiosk(PaymentPayKioskInputModel model)
    {

      return await _paymentService.Value.PayByKioskAsync(model, model.LuckyUserId);

    }
  }
}

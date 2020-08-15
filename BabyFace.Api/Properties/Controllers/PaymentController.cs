using Couponz.Lucky.Domain.Model.Models.Entities;
using Couponz.Lucky.Domain.Services.Contracts;
using Couponz.Lucky.Domain.Model.Constants;
using Couponz.Services.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.IO;
using System.Text;
using Couponz.Lucky.Domain.Model.ViewModels.Paymob;

namespace Couponz.Lucky.Api.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        private readonly Lazy<IPaymentService> _paymentService;
        public PaymentController(Lazy<IPaymentService> paymentService)
        {
            _paymentService = paymentService;
        }
        [AllowAnonymous]
        [Route("redirect-transaction")]
        [HttpPost]
        public async Task<string> TransactionCallback(string hmac)
        {
            string documentContents;
            //using (Stream receiveStream = Request.InputStream)
            //{
            //    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
            //    {
            //        documentContents = readStream.ReadToEnd();
            //    }
            //}
            System.IO.File.WriteAllText(@"C:\paymentResponse.txt", null);
            return null;
        }
        [AllowAnonymous]
        [Route("response-transaction")]
        [HttpGet]
        public async Task<string> TransactionResponseCallback()
        {
            //var url = Request.RequestUri;
            //var parm = url.Substring(url.IndexOf('?') + 1);
            //System.IO.File.WriteAllText(@"C:\paymentResponseCallback.txt", parm);
            return "";
        }
        [AllowAnonymous]
        [Route("pay-kiosk")]
        [HttpPost]
        public async Task<PayByKioskOutputModel> PayByKiosk(PaymentPayKioskInputModel model)
        {
            return await _paymentService.Value.PayByKioskAsync(model, HttpContext.Current.User.Identity.GetUserId());

        }
    }
}
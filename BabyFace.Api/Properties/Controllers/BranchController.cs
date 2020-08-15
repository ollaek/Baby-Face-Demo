using Couponz.Lucky.Domain.Model.ViewModels.Lookups;
using Couponz.Lucky.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Couponz.Lucky.Api.Controllers
{
    [RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {
        private readonly Lazy<IBranchService> _branchService;

        public BranchController(Lazy<IBranchService> branchService)
        {
            _branchService = branchService;
        }

        [Route("get-branch-list")]
        [HttpGet]
        public async Task<List<LookupModel<int>>> GetBranches(int merchantId, int languageId)
        {
            return await _branchService.Value.GetBranchsLookUp( merchantId,  languageId);
        }

    }
}
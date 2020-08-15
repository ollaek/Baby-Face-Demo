using BabyFace.Domain.Services.Contracts;
using System;
using System.Net.Http;
using BabyFace.Domain.Providers;

namespace BabyFace.Api.Helpers
{
    public class RequestHeaderHelper : IRequestHeaderHelper
    {
        private readonly Lazy<ILookupService<Domain.Model.Models.Entities.Language>> _languageService;
        
        public RequestHeaderHelper(Lazy<ILookupService<Domain.Model.Models.Entities.Language>> languageServic)
        {
            _languageService = languageServic ?? throw new ArgumentNullException(nameof(languageServic));

        }
        public int GetLanguageFromHeader(HttpRequestMessage request)
        {
            //    var result = request.Headers.Contains("language")
            //? int.Parse(request.Headers.GetValues("language").Single()) : _languageService.Value.Query()
            //             .Single(_ => _.Language1.ToLower() == BabyFaceConstants.Language.English).LanguageId;

            //    return result;
            return 1;
        }

       
    }
}
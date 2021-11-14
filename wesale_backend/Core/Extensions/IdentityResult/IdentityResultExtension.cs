using Core.Constants.IdenityErrorCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.IdentityResult
{
    public static class IdentityResultExtension
    {
        public static IDictionary<string, string[]> SerializeErrors(this Microsoft.AspNetCore.Identity.IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                IdentityErrorTranslator identityErrorTranslator = new IdentityErrorTranslator();

                return identityErrorTranslator.Translate(identityResult);
            }

            return null;
        }
    }
}

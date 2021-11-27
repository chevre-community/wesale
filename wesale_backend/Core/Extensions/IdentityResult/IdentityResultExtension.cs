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
        /// <summary>
        /// Serializes identity error messages
        /// </summary>
        /// <param name="identityResult"></param>
        /// <param name="customErrorKey">Supply it if you want to show errors for specific key</param>
        /// <returns></returns>
        public static IDictionary<string, string[]> SerializeErrors(this Microsoft.AspNetCore.Identity.IdentityResult identityResult, string customErrorKey = null)
        {
            if (!identityResult.Succeeded)
            {
                IdentityErrorTranslator identityErrorTranslator = new IdentityErrorTranslator();

                return identityErrorTranslator.Translate(identityResult, customErrorKey);
            }

            return null;
        }
    }
}

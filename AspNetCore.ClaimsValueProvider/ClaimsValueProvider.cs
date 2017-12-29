using System.Globalization;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.ClaimsValueProvider
{
    /// <summary>
    /// An <see cref="IValueProvider"/> adapter for data stored in a claim
    /// </summary>
    public class ClaimsValueProvider : BindingSourceValueProvider
    {
        private readonly ClaimsPrincipal _claimsIdentity;
        
        /// <param name="bindingSource">The <see cref="BindingSource"/> for the data.</param>
        /// <param name="claimsIdentity">The <see cref="ClaimsPrincipal" /> to wrap.</param>
        public ClaimsValueProvider(BindingSource bindingSource, ClaimsPrincipal claimsIdentity): base(bindingSource)
        {
            _claimsIdentity = claimsIdentity;
        }

        /// <inheritdoc />
        public override bool ContainsPrefix(string prefix)
        {
            return _claimsIdentity.HasClaim(claim => claim.Type == prefix);
        }

        /// <inheritdoc />
        public override ValueProviderResult GetValue(string key)
        {
            var claims = _claimsIdentity.FindAll(key).Select(claim => claim.Value).ToArray();

            if (claims.Length == 0)
            {
                return ValueProviderResult.None;
            }
            return new ValueProviderResult(claims, CultureInfo.InvariantCulture);
        }
    }
}
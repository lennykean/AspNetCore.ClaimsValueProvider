using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.ClaimsValueProvider
{    
    /// <summary>
    /// Specifies that a parameter or property should be bound using a claim.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromClaimAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        /// <param name="claimType">Claim type</param>
        public FromClaimAttribute(string claimType)
        {
            Name = claimType;
        }

        /// <inheritoc />
        public string Name { get; }

        /// <inheritdoc />
        public BindingSource BindingSource => ClaimsBindingSource.BindingSource;
    }
}
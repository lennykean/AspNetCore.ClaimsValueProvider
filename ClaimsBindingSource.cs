using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore.ClaimsValueProvider
{
    /// <summary>
    /// A <see cref="BindingSource"/> for the claims.
    /// </summary>
    public class ClaimsBindingSource : BindingSource
    {
        private ClaimsBindingSource() : base("Claims", "ClaimsBindingSource", false, true)
        {
        }

        /// <summary>
        /// Instance of <see cref="ClaimsBindingSource"/>
        /// </summary>
        public static ClaimsBindingSource BindingSource = new ClaimsBindingSource();
    }
}

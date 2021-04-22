using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace vigalileo.BackendApi.Extensions
{
    public static class ViModelStateExtensions
    {
        public static List<string> GetMessages(this ModelStateDictionary modelState) {
            return (from state in modelState.Values
                    from error in state.Errors
                    select error.ErrorMessage).ToList<string>();
        }
    }
}
using System.Collections.Generic;

namespace vigalileo.DTOs.Common
{
    public class ValidatorResult
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
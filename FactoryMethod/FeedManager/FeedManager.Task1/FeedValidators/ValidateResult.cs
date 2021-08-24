using System.Collections.Generic;
using System.Linq;

namespace FeedManager.Task1.FeedValidators
{
    public class ValidateResult
    {
        public bool IsValid { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public static ValidateResult Merge(ValidateResult one, ValidateResult another)
        {
            if (one.IsValid && another.IsValid)
                return new ValidateResult { IsValid = true };

            return new ValidateResult
            {
                IsValid = false,
                Errors = one.Errors.Concat(another.Errors).ToList()
            };
        }
    }
}
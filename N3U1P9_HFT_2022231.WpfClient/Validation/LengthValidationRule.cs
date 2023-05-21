using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace N3U1P9_HFT_2022231.WpfClient.Validation
{
    public class LengthValidationRule : ValidationRule
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public override ValidationResult Validate(
          object value, System.Globalization.CultureInfo cultureInfo)
        {
            string text = String.Format("Length must be between {0} and {1}",
                           MinLength, MaxLength);
            if (value.ToString().Length < MinLength)
                return new ValidationResult(false, "Too short." + text);
            if (value.ToString().Length > MaxLength)
                return new ValidationResult(false, "To long. " + text);
            return ValidationResult.ValidResult;
        }
    }
}

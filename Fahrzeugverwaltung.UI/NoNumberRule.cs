using System.Globalization;
using System.Windows.Controls;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A Validation rule used to only except strings that don't contain any numbers.
    /// </summary>
    public class NoNumberRule : ValidationRule
    {
        /// <summary>
        /// Checks if the given string containts any numbers.
        /// </summary>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var str = (string)value;
                foreach (var c in str)
                {
                    if (char.IsNumber(c))
                        return new ValidationResult(false, "String is not allowed to contain number");
                }
            }
            catch (System.Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }
            return ValidationResult.ValidResult;
        }
    }
}

using System.Globalization;
using System.Windows.Controls;

namespace FahrzeugVerwaltung.UI
{
    public class NoNumberRule : ValidationRule
    {
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

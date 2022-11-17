using System;
using System.Globalization;
using System.Windows.Controls;

namespace FahrzeugVerwaltung.UI
{
    public class LengthRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int length = 0;

            try
            {
                length = ((string)value).Length;
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if (length < Min)
            {
                return new ValidationResult(false,
                  $"Please enter an string at least {Min} long.");
            }
            return ValidationResult.ValidResult;
        }

        public int Min { get; set; }
    }
}

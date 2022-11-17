using System;
using System.Globalization;
using System.Windows.Controls;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A Validation rule used to only except strings longer than a given length.
    /// </summary>
    public class LengthRule : ValidationRule
    {
        /// <summary>
        /// Checks if the given string is at least <see cref="Min"/> long.
        /// </summary>
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

        /// <summary>
        /// The minimum length of a string that is considered valid.
        /// </summary>
        public int Min { get; set; }
    }
}

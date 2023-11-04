using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects
{
    public class Longitude : ValueObject
    {
        protected Longitude()
        {
        }

        public Longitude(string value)
        {
            Validate(value);
            Value = value;
        }

        public string Value { get; set; }

        private void Validate(string value)
        {
            value = value.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidLongitudeException("Invalid Longitude");
            }
            double result;
            Double.TryParse(value, out result);

            if (!(result is double))
            {
                throw new InvalidLongitudeException("Invalid Longitude");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

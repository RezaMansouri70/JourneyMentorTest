using Domain.ValueObjects.Exceptions;

namespace Domain.ValueObjects
{
    public class Latitude : ValueObject
    {
        protected Latitude()
        {
        }

        public Latitude(string value)
        {
            Validate(value);
            Value = value;
        }

        public string Value { get; set; }

        private void Validate(string value)
        {
            value = value.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value) )
            {
                throw new InvalidLatitudeException("Invalid Latitude");
            }
            double result;
            Double.TryParse(value, out result);

            if (!(result is double))
            {
                throw new InvalidLatitudeException("Invalid Latitude");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

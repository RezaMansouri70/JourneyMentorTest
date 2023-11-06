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

            if (string.IsNullOrEmpty(value) || !(IsDouble(value)))
            {
                throw new InvalidLatitudeException("Invalid Latitude");
            }       
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public bool IsDouble(string ValueToTest)
        {
            double Test;
            bool OutPut;
            OutPut = double.TryParse(ValueToTest, out Test);
            return OutPut;
        }
    }
}

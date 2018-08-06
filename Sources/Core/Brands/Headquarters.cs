using System;
using System.ComponentModel.DataAnnotations;

namespace Choless.Core.Brands
{
    public class Headquarters : ICloneable
    {
        [StringLength(32,MinimumLength =32)]
        public string HeadquartersId { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public object Clone() => MemberwiseClone();


        public override bool Equals(object obj)
        {
            foreach (var property in typeof(Headquarters).GetProperties())
            {
                if (!property.GetValue(this).Equals(property.GetValue(obj)))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
	}
}

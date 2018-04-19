using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Choless.Core.Brands
{
    public class Brand : ICloneable
    {
        [Key]
        [StringLength(32, MinimumLength = 32)]
        public string BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public virtual IEnumerable<BusinessScope> BusinessScopes { get; set; }

        public string WebSite { get; set; }
        public virtual Headquarters Headquarters { get; set; }
        public DateTime EstablishedTime { get; set; }
        public string Description { get; set; }

        public object Clone() => MemberwiseClone();

        public override bool Equals(object obj)
        {
            var flag = true;
            foreach (var property in typeof(Brand).GetProperties())
            {
                switch (property.Name)
                {
                    case "BusinessScopes":
                        var a = (property.GetValue(this) as IEnumerable<BusinessScope>).OrderBy(x => x.BusinessScopeId);
                        var b = (property.GetValue(obj) as IEnumerable<BusinessScope>).OrderBy(x => x.BusinessScopeId);
                        flag = flag && a.SequenceEqual(b);
                        break;
                    default:
                        flag = flag && property.GetValue(this).Equals(property.GetValue(obj));
                        break;
                }
                if (flag == false)
                    return false;
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

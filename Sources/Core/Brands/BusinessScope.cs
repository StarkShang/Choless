using System;
using System.ComponentModel.DataAnnotations;

namespace Choless.Core.Brands
{
    public class BusinessScope : ICloneable
    {
        [StringLength(32, MinimumLength = 32)]
        public string BusinessScopeId { get; set; }
        public Brand Brand { get; set; }
        public string CommodityClass { get; set; }

		public object Clone() => MemberwiseClone();

        public override bool Equals(object obj)
		{
            //var flag = true;
            //foreach (var property in typeof(Brand).GetProperties())
            //{
            //    switch (property.Name)
            //    {
            //        case "Brand":
            //            var a = (property.GetValue(this) as Brand);
            //            var b = (property.GetValue(obj) as Brand);
            //            flag = flag && (a == null && b == null) ? a.BrandId == b.BrandId : false;
            //            break;
            //        default:
            //            flag = flag && property.GetValue(this).Equals(property.GetValue(obj));
            //            break;
            //    }
            //    if (flag == false)
            //        return false;
            //}
            var scope = obj as BusinessScope;
            return BusinessScopeId == scope.BusinessScopeId
              && ((Brand != null && scope.Brand != null)
               && ((Brand == null && scope.Brand == null)
                 || Brand.Id == scope.Brand.Id))
              && CommodityClass == scope.CommodityClass;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        public delegate void MentionSubtotal(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionSubtotal mentionSubtotal, 
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
            Action<string> mentionDiscounting )
        {
            var subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            mentionDiscounting("We are applying your discount...");

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}

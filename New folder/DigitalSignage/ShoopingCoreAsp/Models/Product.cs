using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoopingCoreAsp.Models
{
    public class Product
    {
        public int id { get; set; }
        public String product_name { get; set; }
        public int product_brand { get; set; }
        public int product_price { get; set; }
        public int product_quantity { get; set; }
        public String product_qrcode { get; set; }
        public int cate_id { get; set; }
        public int sub_cate_id { get; set; }
        public int is_feature_product { get; set; }
        public int is_hot_product { get; set; }
        public int is_top_seller_product { get; set; }
        public int is_top_rate_product { get; set; }
        public int is_best_deal { get; set; }
        public String product_image { get; set; }
        public String product_image1 { get; set; }
        public String product_image2 { get; set; }
        public String product_image3 { get; set; }
        public String product_details { get; set; }
        public String brand_name { get; set; }
        public String cat_name { get; set; }
        public String sub_cat_name { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTraq.Models
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public OrderDetail[] OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public string Name { get; set; }
        public LineItem[] LineItem { get; set; }
    }

    public class LineItem
    {
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
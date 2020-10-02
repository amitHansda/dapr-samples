using System;

namespace SimplePubSub.BuildingBlock
{
    public class ProductOrder
    {
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }
}

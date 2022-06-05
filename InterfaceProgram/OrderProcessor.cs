using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram
{
    public class OrderProcessor : IOrderProcessor
    {
        #region First：开始的代码只有一个计算方式
        //private readonly ShippingCalculator _shippingCalculator;
        //public OrderProcessor(ShippingCalculator shippingCalculator)
        //{
        //    this._shippingCalculator = shippingCalculator;
        //}
        #endregion

        //TODO 使用接口标准来代替是普通的计算还是双11计算的单一方式
        private readonly IShippingCalculator _shippingCalculator;
        //private readonly INoticeService _noticeService;

        private readonly List<INoticeService> _noticeList;

        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            this._shippingCalculator = shippingCalculator;
            //this._noticeService = noticeService;
            _noticeList = new List<INoticeService>();
            Console.WriteLine("订单已经被创建");
        }

        public void RegisterNotices(INoticeService noticeService)
        {
            _noticeList.Add(noticeService);
        }

        public void Process(Order order)
        {
            if (order.IsDeliver)
                throw new InvalidOperationException("订单已发货");

            order.ShipMent = new ShipMent
            {
                Cost = _shippingCalculator.CalculatorShipping(order),
                ShippingDate = DateTime.Now,
            };
            order.IsDeliver = true;

            Console.WriteLine($"订单# {order.Id} 完成，已发货。运费 {order.ShipMent.Cost} ");

            //_noticeService.SendNotice($"订单# {order.Id} 完成，已发货。运费 {order.ShipMent.Cost} ");

            foreach (var _noticeService in _noticeList)
            {
                _noticeService.SendNotice($"订单# {order.Id} 完成，已发货。运费 {order.ShipMent.Cost} ");
            }

        }
    }
}

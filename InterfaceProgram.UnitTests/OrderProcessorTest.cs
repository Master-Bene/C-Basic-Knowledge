using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InterfaceProgram.UnitTests
{
    //TODO TDD Test Drivien Dev 测试驱动开发（先写测试在开发）
    [TestClass]  //attribute 特性
    public class OrderProcessorTest
    {
        //TODO 方法命名：被测方法_条件_期望结果
        [TestMethod]
        public void Process_OrderUnShipping_SetShipMent()
        {
            IShippingCalculator shippingCalculator = new FakeShippingCalculator();
            INoticeService wxNoticeService = new WXNoticeService();
            INoticeService smsNoticeService = new SMSNoticeService();
            //OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator, wxNoticeService);

            OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator);

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                Price = 110,
                OrderTime = DateTime.Now,
            };
            orderProcessor.RegisterNotices(wxNoticeService);
            orderProcessor.RegisterNotices(smsNoticeService);
            orderProcessor.Process(order);

            Assert.AreEqual(order.ShipMent.Cost, 5);
            Assert.IsTrue(order.IsDeliver);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsDeliver_ThrowException()
        {
            IShippingCalculator shippingCalculator = new FakeShippingCalculator();
            INoticeService wxNoticeService = new WXNoticeService();
            INoticeService smsNoticeService = new SMSNoticeService();
            //OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator, wxNoticeService);
            OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator);

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                Price = 110,
                OrderTime = DateTime.Now,
                IsDeliver = true,
            };
            orderProcessor.RegisterNotices(wxNoticeService);
            orderProcessor.RegisterNotices(smsNoticeService);
            orderProcessor.Process(order);


        }


    }
}
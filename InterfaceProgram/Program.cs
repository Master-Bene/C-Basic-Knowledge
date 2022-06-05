// See https://aka.ms/new-console-template for more information

using InterfaceProgram;
using Microsoft.Extensions.DependencyInjection;

Order order = new Order
{
    Id = Guid.NewGuid(),
    OrderTime = DateTime.Now,
    Price = 100,
};

//TODO First:开始的初始化形式
//ShippingCalculator shippingCalculator = new ShippingCalculator();
//MailNoticeService mailNoticeService = new MailNoticeService();
//OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator);


//TODO Second:使用接口的方式初始化
//IShippingCalculator shippingCalculator = new DoubleElevenShippingCalculator();
//OrderProcessor orderProcessor = new OrderProcessor(shippingCalculator, mailNoticeService);


//TODO Third:使用依赖关系注入 IOC容器
ServiceCollection services = new ServiceCollection();
services.AddScoped<IOrderProcessor, OrderProcessor>();
//services.AddScoped<INoticeService, SMSNoticeService>();
services.AddScoped<IShippingCalculator, DoubleElevenShippingCalculator>();

//从IOC容器中提取服务
IServiceProvider serviceProvider = services.BuildServiceProvider();
var orderProcessor = serviceProvider.GetService<IOrderProcessor>();
orderProcessor.RegisterNotices(new SMSNoticeService());
orderProcessor.RegisterNotices(new MailNoticeService());
orderProcessor.Process(order);

Console.ReadKey();

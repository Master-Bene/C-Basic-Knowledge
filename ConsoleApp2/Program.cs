using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ViewModel<Product> product = init();
            //product.Model = product.Model as BookProduct;
            string s = "";
            s = product.ToString();
            //Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式
            //timeConverter.DateTimeFormat = "yyyy-MM-dd";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.DefaultValueHandling = DefaultValueHandling.Populate;


            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver() ;
            //settings.ContractResolver = new DefaultContractResolver();
            //settings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() };
            settings.ContractResolver = new NullToEmptyStringResolver();
            //new JsonConverter[] { timeConverter }
            s = JsonConvert.SerializeObject(product, Formatting.Indented, settings);

            s = product.ToXml();
            Console.WriteLine(s);

            //ViewModel<BookProduct> bookProduct = new ViewModel<BookProduct> { Head = product.Head, Model = product.Model as BookProduct };
            //string s2 = "";
            //s2 = bookProduct.ToXml();
            //Console.WriteLine(s2);

            Console.ReadKey();
        }


        public static ViewModel<Product> init()
        {
            Head head = new Head() { HeadId = 100, Title = "Head" };
            //Product product = new Product() { ProductID = 1, DisCount = 5 };

            BookProduct bookProduct = new BookProduct() { ProductID = 1, DisCount = 5, ISBN = "123" };


            ComputerProduct computerProduct = new ComputerProduct() { ProductID = 1, DisCount = 5, NX = "123" };


            //ViewModel<Product> viewModel = new ViewModel<Product>() { Head = head, Model = new List<Product> { bookProduct, computerProduct } };
            ViewModel<Product> viewModel = new ViewModel<Product>() { Head = head, Model = bookProduct };

            return viewModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram.UnitTests
{
    public class WXNoticeService : INoticeService
    {
        public void SendNotice(string message)
        {
            Console.WriteLine("发送微信消息--" + message);
        }
    }
}

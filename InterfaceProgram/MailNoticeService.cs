using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram
{
    public class MailNoticeService : INoticeService
    {
        public void SendNotice(string message)
        {
            Console.WriteLine("发送邮箱消息--" + message);
        }

    }
}

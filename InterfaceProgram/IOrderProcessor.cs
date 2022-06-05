using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgram
{
    public interface IOrderProcessor
    {
        public void Process(Order order);

        public void RegisterNotices(INoticeService noticeService);
    }
}

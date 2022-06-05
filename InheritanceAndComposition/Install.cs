// See https://aka.ms/new-console-template for more information

namespace InheritanceAndComposition
{
    public partial class Install
    {
        private readonly Logger logger;

        public Install(Logger logger)
        {
            this.logger = logger;
        }

        public void install() => logger.Log("安装开始");//TODO: 开始安装程序逻辑
    }
}
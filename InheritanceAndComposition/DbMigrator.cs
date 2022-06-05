// See https://aka.ms/new-console-template for more information

namespace InheritanceAndComposition
{
    public partial class DbMigrator
    {
        private readonly Logger _logger;
        public DbMigrator(Logger logger)
        {
            this._logger = logger;
        }

        public void Migrate()
        {
            _logger.Log("数据迁移开始");
            //TODO: 数据迁移逻辑

        }
        //TODO:private:只能自己访问。 protected:只能被自己和继承于自己的派生类访问。外部环境还是不能访问。 internal:
        protected void BackUp()
        {
            _logger.Log("数据备份开始");
            //TODO: 数据备份逻辑
        }
    }

    public partial class SqlServer : DbMigrator
    {
        private readonly Logger logger;

        /// <summary>
        /// 使用base关键字选择基类中的构造函数作为初始化。否则使用默认无参数构造函数
        /// </summary>
        /// <param name="logger"></param>
        public SqlServer(Logger logger) : base(logger)
        {
            this.logger = logger;
            this.BackUp();
        }

       
    }
}
// See https://aka.ms/new-console-template for more information

namespace CMSConsoleAPP
{
    public class CMSController : ICMSController
    {
        private readonly IUser _user;
        private readonly IMenu _menu;
        public CMSController(IUser user,IMenu menu)
        {
            this._user = user;
            this._menu = menu;
        }

        public void Start()
        {
            do
            {
                _user.Login();
            } while (!_user.IsUserLogin);
            _menu.ShowMenu(_user.IsUserLogin);
        }
    }
}
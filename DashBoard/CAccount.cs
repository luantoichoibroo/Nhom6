using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    [Serializable]
    class CAccount
    {
        private string _userName, _passWord;
        bool rememberAccount;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
        }

        public bool RememberAccount
        {
            get { return rememberAccount; }
            set { rememberAccount = value; }
        }

        public CAccount()
        {
            this._userName = string.Empty;
            this._passWord = string.Empty;
            this.rememberAccount = false;
        }


    }
}

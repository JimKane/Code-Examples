using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOffModel
{
    public class CallOff
    {
        DateTime _callOffdate;

        public DateTime CallOffDate
        {
            get { return _callOffdate; }
            set { _callOffdate = value; }
        }
        int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public CallOff(DateTime date, int amount)
        {
            this._amount = amount;
            this._callOffdate = date;
        }
    }
}

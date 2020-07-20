using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportManagerHelper.src.Repos
{
    public abstract class BaseLiteRepository
    {
        private readonly string ConnString;

        public BaseLiteRepository(string connstr)
        {
            ConnString = connstr;
        }
    }
}

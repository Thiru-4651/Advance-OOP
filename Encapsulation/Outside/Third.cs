using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Outside
{
    public class Third
    {
        internal protected int internalProtectedNumber=40;

        private static int _privateNum=50;

        public int PrivateNumber { get{return _privateNum;} }
    
    }
}
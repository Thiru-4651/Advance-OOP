using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Outside;

namespace Inside
{
    public class First :Third
    {
        //Private Field
        private int _privateNumber=10;
        public int PirvateOut { get{return _privateNumber;}  }

        //Public Field
        public int PublicNumber=20;

        //Protected Field
        protected int ProtectedNumber=30;

        public int internalProtectedNumberOut{get{return internalProtectedNumber;}}

        public int PrivateNumberOut { get{return PrivateNumber;} }

    }
}
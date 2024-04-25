using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Outside;

namespace Inside 
{
    public class Second :First
    {
        public int ProtectedNumberOut { get{return ProtectedNumber;} }

        //Internal Protected Field

        //internal protected int internalProtectedNum=40;
        
    }
}
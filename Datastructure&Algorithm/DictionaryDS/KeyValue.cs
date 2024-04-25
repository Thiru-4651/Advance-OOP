using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryDS
{
    public class KeyValue<Tkey,Tvalue>
    {
        public Tkey Key{get;set;}
        public Tvalue Value{get;set;}
    }
}
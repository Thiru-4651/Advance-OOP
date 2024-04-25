using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackDS
{
    public class CustomStack<Type>
    {
        private int _capcity;
        private int _top;
        public int Capacity { get{return _capcity;} }
        public int Count{get{return _top+1;}}

        private Type [] _array;

        public CustomStack ()
        {
            _top=-1;
            _capcity=4;
            _array=new Type[_capcity];
        }
        public CustomStack (int size)
        {
            _top=-1;
            _capcity=size;
            _array=new Type[_capcity];
        }
        public void Push(Type value)
        {
            if(_top+1==_capcity)
            {
                GrowSize();
            }
            _array[_top+1]=value;
            _top++;
        }
        void GrowSize()
        {
            _capcity*=2;
            Type [] temp=new Type[_capcity];
            for(int i=0;i<_top+1;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        public Type Peek()
        {
            if(_top==-1)
            {
                return default(Type);
            }
            return _array[_top];
        }
        public Type Pop()
        {
            if(_top==-1)
            {
                return default(Type);
            }
            else
            {
                _top--;
                return _array[_top+1];
            }
        }
    }
}
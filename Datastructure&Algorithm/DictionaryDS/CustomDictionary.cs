using System;
using System.Collections;
namespace DictionaryDS
{
    public class CustomDictionary<Tkey, Tvalue> :IEnumerable,IEnumerator
    {
        private int _count;
        private int _capacity;

        public int Count { get { return _count; } }
        private KeyValue<Tkey, Tvalue>[] _array;

        public Tvalue this [Tkey key]
        {
            get
            {
                Tvalue value=default(Tvalue);
                LinearSearch(key,out value);
                return value;
            }
            set
            {
                int position=LinearSearch(key,out Tvalue value2);
                if(position>-1)
                {
                    _array[position].Value=value;
                }
            }
        }

        public CustomDictionary()
        {
            _count = 0;
            _capacity = 4;
            _array = new KeyValue<Tkey, Tvalue>[_capacity];
        }
        public CustomDictionary(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new KeyValue<Tkey, Tvalue>[_capacity];
        }

        public void Add(Tkey key, Tvalue value)
        {
           if(_count==_capacity)
           {
            GrowSize();
           }
           int position=LinearSearch(key,out Tvalue value1);
           if(position==-1)
           {
            KeyValue<Tkey, Tvalue> data = new KeyValue<Tkey, Tvalue>();
            data.Key = key;
            data.Value = value;
            _array[_count] = data;
            _count++;
           }
        }
        void GrowSize()
        {
            _capacity*=2;
            KeyValue<Tkey,Tvalue>[] temp=new KeyValue<Tkey, Tvalue>[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        int LinearSearch(Tkey key,out Tvalue value)
        {
            int position =-1;
            value=default(Tvalue);
            for(int i=0;i<_count;i++)
            {
                if(key.Equals(_array[i].Key))
                {
                    position=i;
                    value=_array[i].Value;
                    break;
                }
            }
            return position;
        }

        int position;
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(position<_count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position=-1;
        }
        public object Current{get{return _array[position];}}
    }
}
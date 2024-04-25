using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class CustomList<Type> : IEnumerator, IEnumerable
    {
        /// <summary>
        /// AutoIncreament values cref="Customer details"
        /// </summary>
        private int _count;
        private int _capacity;

        /// <summary>
        /// Property for stroing count 
        /// </summary>
        public int Count { get { return _count; } }

        /// <summary>
        /// Property for stroing capacity 
        /// </summary>
        public int Capacity { get { return _capacity; } }

        /// <summary>
        /// Private array
        /// </summary>
        private Type[] _array;

        /// <summary>
        /// Indexer
        /// </summary>
        /// <value></value>
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        /// <summary>
        /// Cunstructor without parameter
        /// </summary>
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }

        /// <summary>
        /// Cunstructor without parameter
        /// </summary>
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        /// <summary>
        /// Method for adding the element
        /// </summary>
        /// <param name="element"></param>
        public void Add(Type element)
        {
            if (_capacity == _count)
            {
                GrowSize();
            }
            _array[_count] = element;
            _count++;
        }

        /// <summary>
        /// Method for growing the size
        /// </summary>

        public void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        /// <summary>
        /// Method for Adding the elements
        /// </summary>
        public void AddRange(CustomList<Type> elements)
        {
            _capacity += elements.Count + 10;
            Type[] temp = new Type[_capacity];
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            for (int i = _count; i < elements._count; i++)
            {
                temp[i] = elements[j];
            }
            _array = temp;
            _count += elements.Count;
        }

        int position;

        /// <summary>
        /// Getenumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if (position < _count - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current { get { return _array[position]; } }
    }
}
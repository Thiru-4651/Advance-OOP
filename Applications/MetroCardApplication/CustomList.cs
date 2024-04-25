using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class CustomList<Type> :IEnumerable,IEnumerator
    {
        //Private Fields
        private int _count;
        private int _capacity;
        
        //Properties
        public int Count { get{return _count;} }
        public int Capacity{get {return _capacity;}}

        //Private array
        private Type[] _array;

        //Indexer

        public Type this[int index]
        {
            get {return _array[index];}
            set {_array[index]=value;}
        }

        //Constructor without parameter
        public CustomList()
        {
            _count=0;
           
           //Intializing the default array capacity as 4 
            _capacity=4;

            //Creating the array with the capacity size
            _array=new Type[_capacity];
        }   

        //Constructor With size parameter
        public CustomList(int size)
        {
            _count=0;

            //Intializing the array capacity as parameter size 
            _capacity=size;

            //Creating the array with the capacity size
            _array=new Type[_capacity];
        }

        //Methods

        //Add 
        public void Add(Type value)
        {
            
            //To check if capacity and count has the same 
            if(_capacity==_count)
            {
                //If yes then have to increase the size of array
                GrowSize();
            }
            //Assinging the value to the array
            _array[_count]=value;

            //Increasing the count to store the next value
            _count++;

        }//Add ends

        
        public void GrowSize()
        {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }

        //AddRange
        public void AddRange(CustomList<Type>values)
        {
            _capacity+=values.Count+10;
            Type [] temp=new Type[_capacity];
            int j=0;
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            for(int i=_count;i<values.Count;i++)
            {
                temp[i]=values[j];
                j++;
            }
            _count+=values.Count;
            _array=temp;
        }

        //Foreach Loop 
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
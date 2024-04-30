using System;

namespace Cafeteria
{
    public partial class CustomList<Type>
    {
        //field
        private int _count=0;
        private int _capacity=0;
        //property
        public int Count{get{return _count;}}
        public int Capacity{get{return _capacity;}}
        private Type[] _array;//when creating object we can convert to any type so use Typr here
        //To specify object using this keyword
        public Type this[int index]
        {
            get {return _array[index];}
            set{_array[index]=value;}
        }
        //constructor
        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array =new Type[_capacity];
        }
        //parameter constructr
        public CustomList(int size)
        {
            _count=0;
            _capacity=size;
            _array=new Type[_capacity];

        }
        //method
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                Grow();
            }
            _array[_count]=element;
            _count++;
        }
        //To increase array size if it is exceed capacity
        public void Grow()
        {
            _capacity*=2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        //To use addrange
        public void AddRange(CustomList<Type> element)
        {
            _capacity=_count+element._count+4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            //Adding next list value
            int k=0;
            for(int i=_count;i<_count+element._count;i++)
            {
                temp[i]=element[k];//whwenver we consider object as an array use indexer
                k++;

            }
            _array=temp;
            _count=_count+element.Count;



        }
        public bool Contains(Type element)
        {
            bool temp=false;
            foreach(Type data in _array)
            {
                if(data.Equals(element))
                {
                    temp=true;
                    break;
                }
            }
            return temp;
        }
        //to find index of an element
        public int IndexOf(Type element)
        {
            int index=-1;
            for(int i=0;i<_count;i++)
            {
                if(element.Equals(_array[i]))
                {
                    index=i;
                    break;
                }
            }
            return index;
        }
        public void Insert(int position,Type element)
        {
            _capacity+=4;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<=_count;i++)
            {
                if(i<position)
                {
                    temp[i]=_array[i];
                }
                else if(i==position)
                {
                    temp[i]=element;
                }
                else
                {
                     temp[i]=_array[i-1];
                }
            }
            _count++;
            _array=temp;
        }
        //To remove 
        public void RemoveAt(int position)
        {
            for(int i=0;i<_count-1;i++)
            {
                if(i>=position)
                {
                    _array[i]=_array[i+1];
                }
            }
            _count--;
        }
        //To reverse
        public void Reverse()
        {
            Type[] temp=new Type[_capacity];
           // int j=0;
            for(int i=_count-1;i>=0;i--)
            {
                temp[i]=_array[i];
               // j++;
            }
            _array=temp;
        }

    }
}
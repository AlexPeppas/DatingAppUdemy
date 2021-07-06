using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.Generics
{
    public class Generics
    {
        public T GenericList<T>(T a, T b) where T : IComparable 
        {
            
            return a.CompareTo(b) > 0 ? a : b;
        }
        public string GenericPerson<T> (T value ) where T : Person
        {
            return value.Name; //person's name
        }
        
    }
    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable()
        { }
        public Nullable(T value)
        {
            _value = value;
        }
        public bool HasValue
        {
            get { return _value != null; }
        }
        public T GetValueOrDefault() 
        {
            if (HasValue)
                return (T)_value;
            return default(T);
        }
    }
}

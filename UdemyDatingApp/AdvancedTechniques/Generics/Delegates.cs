using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.Generics
{
    public class PhotoProcessor
    {
        public delegate void FilterHandler(Photo photo); //delegate with a signature (Photo)
        public delegate int EulerCalc(Photo photo);

        public void PhotoProcessing (Photo photo,FilterHandler filterHandler)
        {
            filterHandler(photo); //uses the passed functions with the corresponding input to execute these
            
        }
        //Action<> is the default generic void delegate in .NET (up to 16 parameters). Func<> is the default generic delegate which returns a value
        public void PhotoProcessing (Photo photo, Action<Photo> filterHandler)
        {
            filterHandler(photo);
        }

        public int PhotoEuler (Photo photo , Func<Photo,int> eulerCalc)
        {
            return eulerCalc(photo);
        }

    }
}

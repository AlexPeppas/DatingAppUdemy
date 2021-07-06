using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.Generics
{
    public class MainClassSimulation
    {
        public static void MainFunctionality()
        {
            var photoProcessor = new PhotoProcessor(); //Delegates class
            PhotoProcessor.FilterHandler filterHandler = AddContrastToPhoto; //points to function
            filterHandler += AddBrightnessToPhoto; //points to multiple functions
            photoProcessor.PhotoProcessing(new Photo { }, filterHandler); //passes the functions as an argument

            //////////////////////////////////////////////
            Action<Photo> filterWithDefault = AddContrastToPhoto; //same work with the previous but using the default void delegate Action
            photoProcessor.PhotoProcessing(new Photo { }, filterWithDefault);

            /////////////////////////////////////////////
            Func<Photo, int> EulerCalc = EulerCalculation; //working with Func Delegate. (Intput a Photo obj and output and int)
            photoProcessor.PhotoEuler(new Photo { }, EulerCalc);
            
            ///////////////////////////////////////////
            const int de = 5;
            Func<int,int,int> num = (de,x )=> de *10*x; //create a delegate which references a function with 2 arguments and 1 int output
            var res = num(de,10);
            
        }

        public static void AddContrastToPhoto(Photo photo)
        {
            Console.WriteLine("Simulate Contrast");
        }
        public static void AddBrightnessToPhoto(Photo photo)
        {
            Console.WriteLine("Simulate Brightness");
        }
        public static int EulerCalculation (Photo photo)
        {
            return photo.UserId;
        }
        ///////////////////////////////////////////
        ///
        //EVENTS
        ///
        public void MainSimulation()
        {
            var eventInst = new Events(); //publisher
            var simMailService = new MailService(); //subscriber
            var simTxtSerivce = new TextService(); //subscriber
            eventInst.VideoEncoder += simMailService.OnVideoEncoder; //contract between these 2 
            eventInst.VideoEncoder += simTxtSerivce.OnVideoEncoder; //contract between these 2 
            eventInst.MainFunctionality(new Photo {Id = 123 });
        }
        
    }
}

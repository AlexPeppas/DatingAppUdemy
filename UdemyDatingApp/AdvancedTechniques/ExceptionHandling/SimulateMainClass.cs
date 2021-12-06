using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDatingApp.AdvancedTechniques.ExceptionHandling
{
    public partial class SimulateMainClass
    {
        public void MainFunctionality()
        {
            StreamReader stream = null;
            try 
            {
                string dum = "sadsa dsdsda asdsad ddd asd ndros asd dasd ";
                var count = dum.IndexOf("alexandros");
                stream = new StreamReader(@"C:\");

                var content = stream.ReadToEnd();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured");
            }
            finally 
            {
                if (stream != null)
                    stream.Dispose();
            }
        }
        public void SecondaryFunctionality() 
        {
            
            try 
            {
                throw new Exception("Lower Layer error occured");
                using(StreamReader stream = new StreamReader(@"C:\Users\apeppas\OneDrive - Deloitte (O365D)\Desktop\Stream.txt"))
                {
                    var content = stream.ReadToEnd();
                    var count = content.IndexOf("Alex");
                };
            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong with the data streaming",ex);
            }
        }
    }
}

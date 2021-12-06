using System;

namespace UdemyDatingApp.AdvancedTechniques.ExceptionHandling
{
    public partial class SimulateMainClass
    {
        public class CustomException : Exception
        {
            public CustomException(string message,Exception innerException)
                : base (message, innerException)
            {
                    
            }
        }
    }
}

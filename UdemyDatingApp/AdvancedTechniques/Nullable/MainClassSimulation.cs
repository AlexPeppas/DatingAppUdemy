using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDatingApp.AdvancedTechniques.Nullable
{
    public class MainClassSimulation
    {
        public void NullableCoercions()
        {
            DateTime? date = null;

            DateTime date2 = date ?? DateTime.Today;
            //same
            DateTime date3 = (date == null) ? DateTime.Today : date.GetValueOrDefault();

            if (date.HasValue)
                Console.WriteLine(date.GetValueOrDefault());
        }

    }
}

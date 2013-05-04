using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hulp
/// </summary>
public class Hulp
{
    public static int dayOfWeek(DateTime adSource)
    {

        // Calender Functionality cloned by used defined logic
        DayOfWeek dWeek = adSource.DayOfWeek;

        switch (dWeek)
        {

            case DayOfWeek.Monday:
                return 1;

            case DayOfWeek.Tuesday:
                return 2;

            case DayOfWeek.Wednesday:
                return 3;

            case DayOfWeek.Thursday:
                return 4;

            case DayOfWeek.Friday:
                return 5;

            case DayOfWeek.Saturday:
                return 6;

            case DayOfWeek.Sunday:
                return 0;

        }

        return 0;

    }
}
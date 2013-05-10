using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Hulp
/// </summary>
public class Hulp
{
    
    //geeft dag terug als int
    public static int dayOfWeek(DateTime adSource)
    {

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

    // geeft een lijst met plaatsdata terug
    public static Dictionary<int, PlaatsData> getBestemmingData()
    {
        PlaatsenAccess acc = new PlaatsenAccess();
        DataTable plaats = acc.getAllPlaatsen();
        Dictionary<int, PlaatsData> plaatsData = new Dictionary<int, PlaatsData>();

        for (int r = 0; r < plaats.Rows.Count; r++)
        {
            PlaatsData pl = new PlaatsData();
            object[] inhoud = plaats.Rows[r].ItemArray;
            pl.ID = (int)inhoud[0];
            pl.naam = (String)inhoud[1];
            //pl.beschrijving = (String)inhoud[2];

            plaatsData.Add(pl.ID, pl);
        }
        return plaatsData;
    }
}
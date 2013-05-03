using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OpvulDataBase
/// </summary>
public static class OpvulDataBase
{

    public static void ritten()
    {
        for (int trein = 0; trein <= 20; trein++)
        {
            for (int dag = 0; dag < 7; dag++)
            {
                for (int uur = 0; uur < 4; uur++)
                {

                    RitBag r = new RitBag();

                    r.weekdag = dag;

                    switch (uur)
                    {
                        case 0: r.tijdstip = new TimeSpan(0, 8, 0, 0); break;
                        case 1: r.tijdstip = new TimeSpan(0, 12, 0, 0); break;
                        case 2: r.tijdstip = new TimeSpan(0, 16, 0, 0); break;
                        case 3: r.tijdstip = new TimeSpan(0, 20, 0, 0); break;
                    }

                    r.treinID = trein;

                    RitAccess acc = new RitAccess();
                    acc.addRit(r);
                }
            }
        }
    }
}
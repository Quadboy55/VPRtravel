using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OpvulDataBase
/// </summary>
public class OpvulDataBase
{
	public OpvulDataBase()
	{
	}

    public static void ritten(int beginId, int eindId)
    {
        for(int dag = 0; dag < 7; dag++)
        {
            for (int uur = 0; uur < 4; uur++)
            {
                RitBag r = new RitBag();

                switch (dag)
                {
                    case 0: r.weekdag = "MAANDAG"; break;
                    case 1: r.weekdag = "DINSDAG"; break;
                    case 2: r.weekdag = "WOENSDAG"; break;
                    case 3: r.weekdag = "DONDERDAG"; break;
                    case 4: r.weekdag = "VRIJDAG"; break;
                    case 5: r.weekdag = "ZATERDAG"; break;
                    case 6: r.weekdag = "ZONDAG"; break;
                }
            }
        }
    }
}
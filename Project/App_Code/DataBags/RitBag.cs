using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RitBag
/// </summary>
public class RitBag
{
    public int id { get; set; }
    public int treinID { get; set; }
    public int weekdag { get; set; }
    public TimeSpan tijdstip { get; set; }
	public RitBag()
	{
		
	}
}
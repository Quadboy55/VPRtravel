using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TicketData
/// </summary>
public class TicketData
{
    public int ID { get; set; }
    public int gebruikerID { get; set; }
    public double totalePrijs { get; set; }
    public DateTime aankomstdatum { get; set; }
    public DateTime vertrekdatum { get; set; }
    public int typeID { get; set; }
    public int treinID { get; set; }

    public TicketData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TreinData
/// </summary>
public class TreinData
{
    public int ID { get; set; }
    public int vertrekID { get; set; }
    public int aankomstID { get; set; }
    public int typeID { get; set; }
    public int capaciteit { get; set; }
    public float prijs { get; set; }


	public TreinData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
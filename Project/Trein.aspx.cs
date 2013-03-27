using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    private TreinenAccess TreinAccess;
    private PlaatsenAccess PlaatsAccess;


    protected void Page_Load(object sender, EventArgs e)
    {
        TreinAccess = new TreinenAccess();
        PlaatsAccess = new PlaatsenAccess();

        int counter = 0;
        DataTable ds = new DataTable();
        DataTable dsVertrek = new DataTable();
        DataTable dsAankomst = new DataTable();

        ds = TreinAccess.getAllTrains();
        lstTreinen.DataValueField = ds.Columns[0].ToString();
        lstTreinen.DataTextField = ds.Columns[1].ToString();
        lstTreinen.DataSource = ds;
        lstTreinen.DataBind();



    }

}
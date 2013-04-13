using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
    private TreinenAccess TreinAccess;
    private PlaatsenAccess PlaatsAccess;
    private Dictionary<int, PlaatsData> plaatsData;

    protected void Page_Load(object sender, EventArgs e)
    {
        TreinAccess = new TreinenAccess();
        PlaatsAccess = new PlaatsenAccess();
        plaatsData = new Dictionary<int, PlaatsData>();
        vulBestemmingData();
        
        
        
        if (!Page.IsPostBack)
        {
           zoek.Visible = false;
           setGrid(TreinAccess.getAllTrains());
           vulDropBestemming();
            
        }
    }


    private void vulBestemmingData()
    {
        DataTable plaats = PlaatsAccess.getAllPlaatsen();

        for( int r = 0; r < plaats.Rows.Count; r++)
        {
            PlaatsData pl = new PlaatsData();
            object[] inhoud = plaats.Rows[r].ItemArray;
            pl.ID = (int)inhoud[0];
            pl.naam = (String)inhoud[1];
            //pl.beschrijving = (String)inhoud[2];

            plaatsData.Add(pl.ID, pl);
        }
    }

    private void vulDropBestemming()
    {
        drpVertrek.Items.Clear();
        drpAankomst.Items.Clear();

        drpVertrek.Items.Add("--Vertrek--");
        drpAankomst.Items.Add("--Aankomst--");

        foreach(KeyValuePair<int, PlaatsData> p in plaatsData)
        {
            drpVertrek.Items.Add(p.Value.naam);
            drpAankomst.Items.Add(p.Value.naam); 
        }
    }
    private void setGridBestemming()
    {
        for( int r = 0; r < GridTrein.Rows.Count; r++)
        {
            for(int i = 1; i<3 ; i++)
            {
                int id = Int32.Parse(GridTrein.Rows[r].Cells[i].Text);
                GridTrein.Rows[r].Cells[i].Text = plaatsData[id].naam;

            }
        }
    }

    private void setGrid(DataTable data) {
        GridTrein.DataSource = data;
        GridTrein.DataBind();
        setGridBestemming();
    }

    protected void btnZoekFunc_Click(object sender, EventArgs e)
    {
        if (btnZoekFunc.Text.Equals("Zoeken naar reis"))
        {
            zoek.Visible = true;
            btnZoekFunc.Text = "verberg";
        }
        else
        {
            zoek.Visible = false;
            btnZoekFunc.Text = "Zoeken naar reis";
            setGrid(TreinAccess.getAllTrains());
        }
    }
    protected void btnZoek_Click(object sender, EventArgs e)
    {
        if (drpVertrek.SelectedIndex == 0 && drpAankomst.SelectedIndex == 0)
        {
                 //waarschuwing iets kiezen
        }
        else
        {
            if (drpVertrek.SelectedIndex == 0)
            {
                setGrid(TreinAccess.getTrainsTo(drpAankomst.SelectedIndex));
            }
            else
            {
                if (drpAankomst.SelectedIndex == 0)
                {
                    setGrid(TreinAccess.getTrainsFrom(drpVertrek.SelectedIndex));
                }
                else
                {
                    setGrid(TreinAccess.getTrainsFromTo(drpVertrek.SelectedIndex, drpAankomst.SelectedIndex));
                }
            }
    
    
        }
    }
}
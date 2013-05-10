using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class TicketAccess
{
    private TicketDAO DAO;

    public TicketAccess()
    {

    }

    public DataTable getAllTickets()
    {
        DAO = new TicketDAO();
        return DAO.getAllTickets().Tables[0];
    }

    public DataTable getTrainById(int tr)
    {
        DAO = new TicketDAO();
        return DAO.getTicketById(tr).Tables[0];
    }

    public DataTable getPersonenPerTicket(int tr)
    {
        DAO = new TicketDAO();
        return DAO.getPersonenPerTicket(tr).Tables[0];
    }

    public void AnnuleerTicket(int TicketID)
    {
        DAO = new TicketDAO();
        DAO.VerwijderPersonen(TicketID);
        DAO.AnnuleerTicket(TicketID);
    }
}
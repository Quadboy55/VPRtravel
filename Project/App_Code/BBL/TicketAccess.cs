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

    public DataTable getTicket(TicketData t)
    {
        DAO = new TicketDAO();
        return DAO.getTicket(t).Tables[0];
    }

    public DataTable getTicketById(int tr)
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

    public int addTicket(TicketData t)
    {
        DAO = new TicketDAO();
        return DAO.addTicket(t);
    }

}
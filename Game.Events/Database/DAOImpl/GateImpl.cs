using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game.Events.Database.DAO;
using Game.Events.Database.DTO;
using Game.Events.Models;
using Utilities.Database;
using Utilities.Log;

namespace Game.Events.Database.DAOImpl
{
    public class GateImpl : IGate
    {
        public List<BigWinPlayers> GetBigWinPlayers()
        {
            try
            {
                DBHelper db = new DBHelper(ConnectionString.SlotMachineReportConnectionString);
                return db.GetListSP<BigWinPlayers>("Report_GetBigWinPlayers");
            }
            catch(Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }

        public List<BigWinPlayers> GeBigWinPlayersByID(int gameId, int topCount)
        {
            try
            {
                var pars = new SqlParameter[2];
                pars[0] = new SqlParameter("@_GameID", gameId);
                pars[1] = new SqlParameter("@_TopCount", topCount);
                DBHelper db = new DBHelper(ConnectionString.SlotMachineReportConnectionString);
                return db.GetListSP<BigWinPlayers>("[dbo].[Report_GetBigWinPlayersByID]", pars);
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
    }
}
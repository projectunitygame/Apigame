using GamePortal.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities.Database;

namespace GamePortal.API.DataAccess
{
    public class AgencyDAO
    {
        public static List<Agency> GetAllAgency()
        {
            DBHelper db = new DBHelper(GateConfig.DbConfig);
            return db.GetList<Agency>($"SELECT * FROM [ag].[Account] WITH (NOLOCK) WHERE IsDelete = 0 AND IsLocked = 0 AND Level = 1 AND Displayable = 1 ORDER BY IndexOrder ASC");
        }
    }
}
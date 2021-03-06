﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SlotGame._20Lines.Game1.Database.DAO;
using SlotGame._20Lines.Game1.Database.DAOImpl;
using Utilities.Session;

namespace SlotGame._20Lines.Game1.Controllers.API
{

    public class TestController : ApiController
    {
        private static ISlotMachineDAO _dao = new SlotMachineDAOImpl();
        [HttpGet]
        [Authorize]
        public int SetTestData(string data)
        {
            var accountName = AccountSession.AccountName;
            return string.IsNullOrEmpty(accountName) ? 0 : _dao.SetTestData(accountName,data);
        }
        [HttpGet]
        [Authorize]
        public string GetTestData()
        {
            var accountName = AccountSession.AccountName;
            return string.IsNullOrEmpty(accountName) ? "" : _dao.GetTestData(accountName);
        }
    }
}

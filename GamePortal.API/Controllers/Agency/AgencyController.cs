using GamePortal.API.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using Utilities.Log;

namespace GamePortal.API.Controllers.Agency
{
    public class AgencyController : ApiController
    {
        [Authorize, HttpOptions, HttpGet]
        public List<Models.Agency> GetAll()
        {
            try
            {
                if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CloseAgencies"]))
                    return new List<Models.Agency>();
                return AgencyDAO.GetAllAgency();
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
            }
            return null;
        }
    }
}

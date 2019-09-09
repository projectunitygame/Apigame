using PTCN.CrossPlatform.Minigame.LuckyDice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTCN.CrossPlatform.Minigame.LuckyDice
{
    /// <summary>
    /// Summary description for UpdateDataBetting
    /// </summary>
    public class UpdateDataBetting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var taiWin = context.Request["taiwin"];
            var gameLoop = GameManager.GetGameLoop(1);
            gameLoop.AdminControlResult = true;
            gameLoop.IsTaiWin = taiWin == "True" ? true : false;
            gameLoop.UpdateResultDice();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
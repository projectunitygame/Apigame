using Newtonsoft.Json;
using PTCN.CrossPlatform.Minigame.LuckyDice.Controllers;
using PTCN.CrossPlatform.Minigame.LuckyDice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTCN.CrossPlatform.Minigame.LuckyDice
{
    /// <summary>
    /// Summary description for DataBetting
    /// </summary>
    public class DataBetting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            LuckyDiceGameLoop luckyDiceGameLoop = GameManager.GetGameLoop(1);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["TotalBetTai"] = luckyDiceGameLoop.TotalBetTai.ToString();
            dic["TotalBetXiu"] = luckyDiceGameLoop.TotalBetXiu.ToString();
            dic["TotalUserBetTai"] = luckyDiceGameLoop.TotalUserBetTai.ToString();
            dic["TotalUserBetXiu"] = luckyDiceGameLoop.TotalUserBetXiu.ToString();
            dic["SessionID"] = luckyDiceGameLoop.SessionID.ToString();
            dic["CurrentState"] = luckyDiceGameLoop.CurrentState.ToString();
            dic["Ellapsed"] = luckyDiceGameLoop.Ellapsed.ToString();
            dic["AdminControl"] = luckyDiceGameLoop.AdminControlResult.ToString();
            dic["TaiWin"] = luckyDiceGameLoop.IsTaiWin.ToString();
            dic["ResultNormal"] = luckyDiceGameLoop.CheckStateMatch().ToString();
            dic["Fund"] = luckyDiceGameLoop.GetFundBot().ToString();
            dic["Dice"] = luckyDiceGameLoop.GetDice().ToString();
            dic["ResultAdminControl"] = luckyDiceGameLoop.GetResultAdminControl().ToString();
            context.Response.Write(JsonConvert.SerializeObject(dic));
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10566
{
    public static class Steps
    {
		public static TC10566 repo = TC10566.Instance; 
    	public static string TC1_10566_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10566_Path"].ToString();
    	
    	public static void ClickOnExecuteExplain()
    	{
    		try 
    		{
    			repo.Application.ExecuteExplainInfo.WaitForItemExists(2000);
    			repo.Application.ExecuteExplain.ClickThis();
    			Reports.ReportLog("ClickOnExecuteExplain", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		} 
    		catch (Exception ex) 
    		{
    			throw new Exception("Failed : ClickOnExecuteExplain : " + ex.Message);
    		}
    	}
        
    }
}

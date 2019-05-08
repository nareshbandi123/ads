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

namespace ADSAutomationPhaseII.TC_10540.TC2
{
    [TestModule("2F742705-DA29-4100-AF4B-CD0836BE84CF", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
    {
        public AmazonRedshift()
        {
            
        }
        
       	void ITestModule.Run()
        {
        	if(Preconditions.Steps.isPreconditionDone)
        		StartProcess();
        }
        
        bool StartProcess()
        {
        	try
        	{ 
       			Steps.ClickOnDBATools();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ClickOnInstanceManager();
        		Steps.SelectADSDb();
        		Steps.ClickOnOk();
        		Steps.SummaryTabValiadation();
        		Steps.QueryTabValiadation();
        		Steps.ColumnsValidation();
        		Steps.Search("10");
        		Steps.SearchQueryResultValidation();
        		Steps.ClickOnQueryHistory();
        		Steps.SelectTypeQuery();
        		Steps.SearchQuery("ads_db");
        		Steps.SearchQueryResultValidation();
	       		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		
        		Steps.ClickOnDBATools();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ClickOnStorageManager();
	      		Steps.SelectADSDb();
        		Steps.ClickOnOk();
        		Steps.ClickOnDatabases();
        		Steps.SelectDB();
        		Steps.SearchDatabase("ads_db");
        		Steps.SearchDatabaseResultValidation();
        		Steps.ClickOnObjects();
        		Steps.ObjectsColumnsValidation();
	      		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		
        		Steps.ClickOnDBATools();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ClickOnSecurityManager();
        		Steps.SelectADSDb();
        		Steps.ClickOnOk();
        		Steps.SelectUser();
        		Steps.ValidateNewWindow();
        		Steps.ClickOnUser();
        		Steps.SearchUserView("aaa");
	       		Steps.ValidateUsersSerachResult();
        		Steps.ClickOnGroups();
        		Steps.SearchGroups("aquafold");
        		Steps.ValidateGroupSearchResult();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		
        		Steps.ClickOnDBATools();
        		Steps.ClickOnAmazonRedshift();
        		Steps.ClickOnSessionManager();
        		Steps.SelectADSDb();
        		Steps.ClickOnOk();
        		Steps.ClickOnSessionsTab();
        		Steps.ValidateKillSession();
        		Steps.SearchProcessID("4333");
        		Steps.ValidateSessionProcessId();
        		Steps.ClickOnSesionStats();
        		Steps.SearchSessionStats("4333");
        		Steps.ValidateSessionStatsSearch();
        		Steps.ClickOnLock();
        		Steps.SearchLock("aquafold");
        		Steps.ValidateLockSearchResult();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        		      		
     		catch(Exception ex)
        	{
     			Preconditions.Steps.CloseTab(Config.TestCaseName); 
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }

    }
}


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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10544.TC2
{
    
    [TestModule("85902CA4-6AEA-449D-B706-48D12232E11E", ModuleType.UserCode, 1)]
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
        		TreeItem server = Preconditions.Steps.SelectedServerTreeItem;
        		Steps.ClickonQueryBuilder();
        		Steps.ClickOnConnectionMenu();
        		Steps.ClickOnAddSchema();
        		Steps.ClickOnPublic();
        		Steps.ClickOnSchemaOK();
        		Steps.ClickOnReconnect();
        		
        		Steps.ActivateApplication();        		
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickOnRightClickRefresh();
        		
        		Steps.ActivateQueryBuilder();
        		Steps.ClickOnRefresh();
        		Steps.ClickOnClose();
        		Steps.ClickonDiscard();
        		Steps.ClickonQueryBuilder();
        		Steps.ClickOnConnectionMenu();
        		Steps.ClickOnEditConnection();
        		Steps.EditLoginName();
        		Steps.ClickOnSave();
        		Steps.ClickOnConnectionMenu();
        		Steps.ClickOnProperties();
        		Steps.ScanTable();
        		Steps.ClickOnCloseConnection();
        		Steps.ClickOnCloseButton();
        		Steps.ClickonDiscard();
        	}
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

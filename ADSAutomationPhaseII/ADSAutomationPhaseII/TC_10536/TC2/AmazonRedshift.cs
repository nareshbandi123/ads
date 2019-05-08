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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;


namespace ADSAutomationPhaseII.TC_10536.TC2
{
    [TestModule("0C9EEE26-90C4-472D-8C99-479122489405", ModuleType.UserCode, 1)]
    public class AmazonRedshift : BaseClass, ITestModule
    {
    	public static TC10536Repo repo = TC10536Repo.Instance;
        
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
        		Steps.ClickOnTools();
				Steps.SelectCompareTools();
				Steps.SelectSchemaCompare();
								
        		Steps.ClickOnLeftChooseServer();
        		Steps.SelectADSDb1();
        		Steps.ClickOkButton();
        		
				Steps.ClickOnRightChooseServer();
				Steps.SelectADSDb();
				Steps.ClickOkButton();
				
				Steps.SetSchema();
				Steps.UnselectSchemaObjects();
				Steps.SelectSchemaTable();
				Steps.UnselectLeftObjects();
				Steps.SelectLeftTable();
				Steps.UnselectRightObjects();
				Steps.SelectRightTable();
				
				Steps.ClickOnCompareButton();
				Steps.ClickOnTable();
				
				Steps.ClickOnSpreadSheetIcon();
				Steps.ClickOnCloseButton();
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
        	}
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        
        	return true;
        }
    }
}
    

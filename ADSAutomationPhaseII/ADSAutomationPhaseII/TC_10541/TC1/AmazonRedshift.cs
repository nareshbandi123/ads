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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10541.TC1
{
   
    [TestModule("892516C1-A95E-4EFA-A0CF-DD93913B19A4", ModuleType.UserCode, 1)]
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
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName ))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.ImportTable();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickonDiscard();
        		Steps.Clickonserver();
        		Steps.ClickonFluidShell();
        		Steps.EnterConnect();
        		Steps.EntertheDisconnect();
        		Steps.EnterConnect();
        		Steps.ChangeDatabase();
        		Steps.EntertheText1();
        		Steps.EntertheText2();
        		Steps.EntertheText3();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(Preconditions.Steps.SelectedServerName ))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Steps.ImportTable1();
        		Steps.Execute();
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Steps.ClickonDiscard();
        		
        	} 
        	catch (Exception ex)
        	{
        		Preconditions.Steps.CloseTab(Config.TestCaseName);
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

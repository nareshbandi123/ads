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

namespace ADSAutomationPhaseII.TC_10546.TC1
{
    [TestModule("2480FAF4-5523-478B-8DD0-6C85C26631FC", ModuleType.UserCode, 1)]
    public class DB2 : BaseClass, ITestModule
    {
        public DB2()
        {
           
        }
 		void ITestModule.Run()
        {
 			if(Preconditions.Steps.isPreconditionDone)
 			{
        	StartProcess();
 			}
        }
        
        bool StartProcess()
        {
        	try
        	{ 
        		Steps.ClickOnTools();
        		Steps.ClickOnCompareTools();
        		Steps.ClickOnSchemaSynchronization();
        		Steps.ClickOnSourceChooseServer();
        		Steps.SelectADSDB("DB2_LUW_172.24.1.8_v11.1");
        		Steps.ClickOnOk();
        		Steps.ClickOnTargetChooseServer();
        		Steps.SelectADSDB("DB2_LUW_172.24.1.145_v10.5");
        		Steps.ClickOnOk();        		
        		Steps.SetSchema();
        		Steps.ClickOnUnselectSchemaObjects();
        		Steps.ScanForTables();
        		Steps.ClickOnUnselectLeftObjects();
        		Steps.SelectLeftObjects();
        		Steps.ClickOnUnselectRightObjects();
        		Steps.SelecRightObjects();
        		Steps.ClickOnCompare();
        		Steps.ClickOnTable();
        		Steps.ClickOnSyncCell();
        		Steps.ClickOnSchemaSynchronize();
        		//Steps.ValidateAllTabs();
        		Steps.ClickOnNextButton();
        		Preconditions.Steps.ClickQARun();
        		Preconditions.Steps.CloseTab();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}

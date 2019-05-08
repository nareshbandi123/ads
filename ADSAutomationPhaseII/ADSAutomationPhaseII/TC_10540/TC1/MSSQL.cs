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

namespace ADSAutomationPhaseII.TC_10540.TC1
{
    [TestModule("5D4F1796-3697-4538-96E0-739AEB3C70A9", ModuleType.UserCode, 1)]
    public class MSSQL : BaseClass, ITestModule
    {
        public MSSQL()
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
        		Steps.ClickOnERModeler();
        		Steps.ClickOnGenerate();
        		Steps.SelectADSDb();
        		Steps.ClickOnOk();
        		Steps.UnSelectObjectTypes();
        		Steps.SelectObjectType();
        		Steps.NextButton();
        		Steps.EntityRelationshipDiagram();
        		Steps.ClickOnClose();
        		Steps.ClickOnDiscard();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
    }
}

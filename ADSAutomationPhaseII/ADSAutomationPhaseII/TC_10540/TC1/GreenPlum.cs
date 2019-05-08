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
    [TestModule("365F6C48-BC4D-406A-8650-9FCAC4D1FF2B", ModuleType.UserCode, 1)]
    public class GreenPlum : BaseClass, ITestModule
    {
        public GreenPlum()
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

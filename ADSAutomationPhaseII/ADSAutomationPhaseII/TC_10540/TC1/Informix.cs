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
    [TestModule("0E3354E5-F3DA-465C-8D13-B4DF2D2F6D86", ModuleType.UserCode, 1)]
    public class Informix : BaseClass, ITestModule
    {
        public Informix()
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

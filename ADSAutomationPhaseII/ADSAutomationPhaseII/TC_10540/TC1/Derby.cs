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
    [TestModule("96E37548-68F9-4C5F-8698-0BD0738CFFCE", ModuleType.UserCode, 1)]
    public class Derby : BaseClass, ITestModule
    {
        public Derby()
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
        		Steps.SelectADSDB();
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

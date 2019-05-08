using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10539.TC1
{
    [TestModule("B78D648E-144E-4E3E-B4DE-4047E2729249", ModuleType.UserCode, 1)]
    public class Amazon : Base.BaseClass, ITestModule
    {
        public Amazon()
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
        		Steps.ClickOnFile();
        		Steps.SelectOptions();
        		
        		Steps.ClickOnSQLEditor();
        		Steps.SelectAutoComplete();
        		Steps.UnCheckAutoComplete();
        		//Steps.ClickOnOKButton();
        		
        		Steps.SelectSyntaxColor();
        		Steps.UnCheckEnabled();
        		//Steps.ClickOnOKButton();
        		
        		Steps.SelectAbbrivation();
        		Steps.ClickOnAddNewIcon();
        		Steps.EnterAbbrivationDetails();
        		//Steps.ClickOnOKButton();
        		
        		Steps.CloseOptionWindow();
        		
        		Steps.ValidateAutoComplete();
        		Steps.ValidateSyntaxColor();
        		Steps.ValidateAbbrivation();
        		
        		Steps.ClickOnFile();
        		Steps.SelectOptions();
        		
        		Steps.ClickOnSQLEditor();
        		Steps.SelectAutoComplete();
        		Steps.CheckAutoComplete();
        		//Steps.ClickOnOKButton();
        		
        		Steps.SelectSyntaxColor();
        		Steps.CheckEnabled();
        		//Steps.ClickOnOKButton();
        		
        		Steps.SelectAbbrivation();
        		Steps.DeleteAbbrevation();
        		//Steps.ClickOnOKButton();
        		
        		Steps.CloseOptionWindow();
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}

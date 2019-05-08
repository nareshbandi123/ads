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

namespace ADSAutomationPhaseII.TC_10544.TC6
{
    [TestModule("9D77C28A-692D-44FA-89C2-AC8D0D249304", ModuleType.UserCode, 1)]
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
				Steps.RightClickonserver();
        		Steps.ClickonQueryBuilder();
        		Steps.DragTablepanetoCentralpane();
        		Steps.ClickQARun();
        		Steps.VerifyTableOptions();
        		Steps.VerifyOtherOptions();
        		Steps.ClickOnClose();
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

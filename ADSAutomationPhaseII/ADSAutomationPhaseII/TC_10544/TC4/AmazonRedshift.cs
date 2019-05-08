
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

namespace ADSAutomationPhaseII.TC_10544.TC4
{
   
    [TestModule("86E1578B-A5F6-401F-A49D-8809E91C7D5A", ModuleType.UserCode, 1)]
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
        		Steps.WorksheetSubQueryMenu();
        		Steps.DragIDColumnToWhereDeck();
        		Steps.ClickQARun();
        		Steps.ClickOnCloseButton();
        		Steps.ClickonDiscard();
        		Steps.ClickonQueryBuilder();
        		Steps.DragTablepanetoCentralpane();
        		Steps.DBUnion();
        		Steps.ClickQARun();
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


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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Base;

namespace ADSAutomationPhaseII.TC_10544.TC8
{
   
    [TestModule("FDC49EB2-5302-4895-9CC0-33714675470A", ModuleType.UserCode, 1)]
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
        		Steps.Clickonfile();
        		Steps.ClickonNew();
        		Steps.ConnectServer();
        		Steps.SelectADSDB();
        		Steps.ClickOnChooseOk();
        		Steps.DragToTable();
        		Steps.ClickQARun();
        		Steps.Clickonfile();
        		Steps.CickonSaveAs();
        		Steps.EntertheQBWPath();
        		Steps.SavetheFile();
        		Steps.ClickOnCloseButton();
        		Steps.ClickOnCloseButton();
        		Steps.ClickonDiscard();
        		Steps.ClickOnQueryBuilder();
        		Steps.ClickOnOpenQueryBuilder();
        		Preconditions.Steps.Sleep();
        		Steps.OpenFile();
        		Steps.ClickOnOpenFileButton();
        		Steps.ClickQARun();
        		Steps.ClickOnCloseQB();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

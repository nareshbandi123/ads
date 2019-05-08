
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
using ADSAutomationPhaseII.Extensions;

namespace ADSAutomationPhaseII.TC_10544.TC1
{
    [TestModule("C9646E05-2D96-447F-9FA0-22336DBD4CC7", ModuleType.UserCode, 1)]
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
        		Steps.Clickonfile();
        		Steps.ClickonSave();
        		Steps.EnterthePath();
        		Steps.SavetheFile();
        		Steps.Clickonfile();
        		Steps.CickonSaveAs();
        		Steps.EnterFilePath();
        		Steps.SavetheFile();
        		Steps.Clickonfile();
        		Steps.CickonSaveSQL();
        		Steps.EntertheSQLPath();
        		Steps.SavetheFile();
        		Steps.Clickonfile();
        		Steps.ClickOptionsButton();
        		Steps.ClickOkay();
        		Steps.ClickOnCloseButton();
        		Steps.ClickonDiscard();
        		Steps.ClickOnQueryBuilder();
        		Steps.ClickOnOpen();
        		System.Threading.Thread.Sleep(2000);
        		Steps.OpenFile();
        		Steps.ClickOnOpenFileButton();
        		Steps.ClickQARun();
        		Steps.ClickOnCloseButton();
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

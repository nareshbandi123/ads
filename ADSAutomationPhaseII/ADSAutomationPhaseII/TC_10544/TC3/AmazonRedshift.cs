
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

namespace ADSAutomationPhaseII.TC_10544.TC3
{
    [TestModule("9EEC0B2D-61BD-401E-A4F9-3888D20B8419", ModuleType.UserCode, 1)]
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
        		Steps.ClickonQuery();
        		Steps.ClickonExecuteEdit();
        		Steps.EditData();
        		Steps.ClickQARun();
        		Steps.ClickonQuery();
        		Steps.ClickOnCopySQL();
        		Steps.ClickonQuery();
        		Steps.ClickOnFormatSQL();
        		Steps.ClickOnFormatSQLCancel();
        		Steps.ClickonQuery();
        		Steps.ClickOnQuoteIdentifier();
        		Steps.ClickonQuery();
        		Steps.ClickOnAutoJoin();
        		Steps.ClickonQuery();
        		Steps.ClickOnSchemaQualified();
        		Steps.ClickonQuery();
        		Steps.ClickOnIgnoreUnused();
        		Steps.AlwaysSQL();
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

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

namespace ADSAutomationPhaseII.TC_10544.TC7
{
    [TestModule("F749E285-E3AB-450B-818F-FFEB28C86B72", ModuleType.UserCode, 1)]
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
        		Steps.DragIDToWhere();
        		Steps.SelectOperator();
        		Steps.ClickOnSaveOperator();
        		Steps.ClickQARun();
        		Steps.DragIDToSelect();
        		Steps.SelectIDCount();
        		Steps.DragNameToGroupBy();
        		Steps.ClickQARun();
        		Steps.DragNameToOrderBy();
        		Steps.DragNameToSelect();
        		Steps.ClickQARun();
        		Steps.DragIDToGroup();
        		Steps.DragIDToHaving();
        		Steps.ClickOnSaveHavingCriteria();
        		Steps.ClickQARun();
        		Steps.DragToClear();
        		Steps.DragTablepanetoCentralpane();
        		Steps.SelectUnion();
        		Steps.DragUnionToCentralPane();
        		Steps.ClickQARun();
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

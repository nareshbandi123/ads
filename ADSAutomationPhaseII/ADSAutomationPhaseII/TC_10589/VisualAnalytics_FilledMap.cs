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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10589
{
    [TestModule("CB17A559-56A0-4B22-BE99-7D3126AA825E", ModuleType.UserCode, 1)]
    public class VisualAnalytics_FilledMap : BaseClass, ITestModule
    {
        public VisualAnalytics_FilledMap()
        {
           
        }
 		void ITestModule.Run()
        {
        	StartProcess();
        }
        
        bool StartProcess()
        {
        	try
        	{
        		Steps.CreateNewWorksheet();
        		Steps.DragCountryToColumn();
        		Steps.DragEnglishSpeakersToRows();
        		Steps.SelectFilledMapVisualization();
        		Steps.EditColor();
        		Steps.EditColorReversed();
        		Steps.ValidateFullChart();
        		Steps.ClickOnCloseViz();
        		Steps.ClickOnDiscard();
        	}
        	catch(Exception e)
        	{
        		Reports.ReportLog(e.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;        	
        }
        
    }
}

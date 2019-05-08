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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.TC_10593;
using ADSAutomationPhaseII.TC_10590;

namespace ADSAutomationPhaseII.TC_10591.TC3
{
   
    [TestModule("5B9E7820-0D05-476E-BA40-02C8A0B6EBF1", ModuleType.UserCode, 1)]
    public class MapCustomization : BaseClass, ITestModule
    {
       
        public MapCustomization()
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
        		TC_10590.Steps.ClickonFileMenu();
        		TC_10590.Steps.ClickonOpen();
        		TC_10590.Steps.SelectNewFile();
        		TC_10590.Steps.ClickonOpenButton();
        		TC_10593.Steps.SelectEntireWindow();
        		TC_10590.Steps.ValidateSymboMapShape();
        		TC_10590.Steps.ClickonShowStateBorders();
        		TC_10590.Steps.ValidateAfterClickonShowBoarders();
        		TC_10590.Steps.SelectCity();
        		TC_10590.Steps.ClickonOverviewSymbolMap();
        		TC_10590.Steps.SelectLatitude();
        		TC_10590.Steps.ClickonCustomizeSymbolMap();
        		TC_10590.Steps.ValidateAfterClickonCustomizeSymbolMap();
        		TC_10590.Steps.ClickonAnalysis();
        		TC_10590.Steps.SelectEditlocations();
        		TC_10590.Steps.CheckAmbiguousLocations();
        		TC_10590.Steps.ClickonAmbiguousLocations();
        		TC_10590.Steps.ValidateAfterClickonAmbiguousLocations();
        		TC_10590.Steps.ClickonAnalysis();
        		TC_10590.Steps.SelectEditlocations();
        		TC_10590.Steps.ResolveAmbiguousLocations();
        		TC_10590.Steps.BuildSymbolMap();
        		TC_10590.Steps.ValidateAfterClickonBuildSymbolMap();
        		TC_10590.Steps.ClickonGeo();
        		TC_10590.Steps.UncheckShowStateBorder(); 
        		TC_10590.Steps.ValidateAfterUncheckShowStateBorder();
        		TC_10590.Steps.CheckShowStateBorder(); 
        		TC_10590.Steps.CloseVAWindow();
        		TC_10590.Steps.DiscardButton();
          		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

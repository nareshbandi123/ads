
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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10590.TC3
{
    
    [TestModule("D59E8517-40D9-4A76-A138-9B8746E4674B", ModuleType.UserCode, 1)]
    public class SymboMapShapeMapCustomization : BaseClass, ITestModule
    {
       
        public SymboMapShapeMapCustomization()
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
        		Steps.ClickonFileMenu();
        		Steps.ClickonOpen();
        		Steps.SelectNewFile();
        		Steps.ClickonOpenButton();
        		TC_10593.Steps.SelectEntireWindow();
        		Steps.ValidateSymboMapShape();
        		Steps.ClickonShowStateBorders();
        		Steps.ValidateAfterClickonShowBoarders();
        		Steps.SelectCity();
        		Steps.ClickonOverviewSymbolMap();
        		Steps.SelectLatitude();
        		Steps.ClickonCustomizeSymbolMap();
        		Steps.ValidateAfterClickonCustomizeSymbolMap();
        		Steps.ClickonAnalysis();
        		Steps.SelectEditlocations();
        		Steps.CheckAmbiguousLocations();
        		Steps.ClickonAmbiguousLocations();
        		Steps.ValidateAfterClickonAmbiguousLocations();
        		Steps.ClickonAnalysis();
        		Steps.SelectEditlocations();
        		Steps.ResolveAmbiguousLocations();
        		Steps.BuildSymbolMap();
        		Steps.ValidateAfterClickonBuildSymbolMap();
        		Steps.ClickonGeo();
        		Steps.UncheckShowStateBorder(); 
        		Steps.ValidateAfterUncheckShowStateBorder();
        		Steps.CheckShowStateBorder(); 
        		Steps.CloseVAWindow();
        		Steps.DiscardButton();
          		
        	} 
        	catch (Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

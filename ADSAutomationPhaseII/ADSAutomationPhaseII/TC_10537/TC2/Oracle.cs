/*
 * Created by Ranorex
 * User: Admin
 * Date: 3/13/2019
 * Time: 6:17 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
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
using ADSAutomationPhaseII.Commons;

namespace ADSAutomationPhaseII.TC_10537.TC2
{
    
    [TestModule("7B5C60EA-04C1-4507-9153-AF68EC21D86D", ModuleType.UserCode, 1)]
    public class Oracle : Base.BaseClass, ITestModule
    {
       
        public Oracle()
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
        		Steps.ClickOnToolsMenu();
        		Steps.ClickOnImport();
        		Steps.SelectServers();
        		Steps.ClickOkButton();
        		Steps.SelectImportFile();
        		Steps.ClickOnNext();
        		Steps.SelectTable();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.ClickOnNext();
        		Steps.CheckImportStatus();
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
        
    }
}

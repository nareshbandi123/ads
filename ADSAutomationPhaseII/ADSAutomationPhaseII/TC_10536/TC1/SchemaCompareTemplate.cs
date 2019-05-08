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
using ADSAutomationPhaseII.TC_10535;

namespace ADSAutomationPhaseII.TC_10536.TC1
{
    [TestModule("E6C9F21E-8116-4AE7-B04D-7621473D1A00", ModuleType.UserCode, 1)]
    public class SchemaCompareTemplate : BaseClass, ITestModule
    {
        public SchemaCompareTemplate()
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
        		TC_10535.Steps.CloseServerTab();
        		TC_10535.Steps.ClickOnProjectTab();
        		TC_10535.Steps.RightClickProjectTab();
        		TC_10535.Steps.SelectNewProject();        		
        		TC_10535.Steps.SelectSchemaCompare();
        		TC_10535.Steps.BrowseFolderLocation();
        		TC_10535.Steps.ClickOk();        		
        		TC_10535.Steps.ValidateSchemaCompareTemplateFromNewProject();
        		TC_10535.Steps.ValidateNewSchemaCompareFile();
        		TC_10535.Steps.CloseTab();
        		TC_10535.Steps.RemoveProject();
        		TC_10535.Steps.CloseProjectTab();
        		TC_10535.Steps.OpenServerTab();
        		TC_10535.Steps.Cleanup(TC_10535.Steps.SCHEMA_COMPARE);
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }
    }
}

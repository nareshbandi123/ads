using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.TC_10538;
using ADSAutomationPhaseII.TC_10547;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10545.TC1
{    
    [TestModule("E3DB8575-3B4C-494D-99BC-66E151A21900", ModuleType.UserCode, 1)]
    public class Cleanup : Base.BaseClass, ITestModule
    {       
        
    	public static TC10538 tc10538Repo = TC10538.Instance;
    	public static string IMPORT_TABLE_NAME = "public.sheet1";
    	
    	public Cleanup()
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
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		Preconditions.Steps.SelectedServerTreeItem = server;
        		Preconditions.Steps.SelectedServerName = server.Text;
        		server.RightClick();
        		
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);
    			else
    				Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		
    			tc10538Repo.UntitledApplication.QATextEditor.Click();
    			
    			string query = string.Format("SELECT * FROM {0}", IMPORT_TABLE_NAME);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.UntitledApplication.QATextEditor.PressKeys(query);
				tc10538Repo.UntitledApplication.QATextEditor.Click();	
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				System.Threading.Thread.Sleep(1000);
				
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
    			System.Threading.Thread.Sleep(1000);
    			query = string.Format("DROP TABLE {0}", IMPORT_TABLE_NAME);
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				tc10538Repo.UntitledApplication.QATextEditor.PressKeys(query);
				tc10538Repo.UntitledApplication.QATextEditor.Click();	
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.ClickQARun();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				TC_10547.Steps.ClickDiscard();
				
        		server.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		server.RightClick();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.DropDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        	}
        	catch(Exception ex)
        	{
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;        	
        }
    }
}

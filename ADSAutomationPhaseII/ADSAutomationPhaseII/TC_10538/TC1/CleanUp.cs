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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538
{
    [TestModule("5011DFB2-EE21-407D-96F7-0F12718F50D4", ModuleType.UserCode, 1)]
    public class CleanUp : BaseClass, ITestModule
    {
        public CleanUp()
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
        		//TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
        		//Preconditions.Steps.SelectedServerTreeItem = server;
        		//Preconditions.Steps.SelectedServerName = server.Text;
        		//Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.SelectedServerTreeItem.RightClick();
        		Preconditions.Steps.ConnectServer();
        		Steps.ClickOnServerProperties();
        		Steps.ClickOnConnectionMonitorTab();
        		Steps.SelectPingIdleConnection();
        		Steps.ClickOnSave();
        		Steps.ClickOnYes();
        		Preconditions.Steps.SelectedServerTreeItem.RightClick();
        		Preconditions.Steps.DisconnectServer();
        		Preconditions.Steps.isPreconditionDone = false;
        	}
        	catch(Exception){}        		
        		
        	return true;
        }
    }
}

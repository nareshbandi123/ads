﻿using System;
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

namespace ADSAutomationPhaseII.TC_10540.TC2
{
    [TestModule("7378E364-E33D-4D5B-875F-FB49BDFD5E27", ModuleType.UserCode, 1)]
    public class Precondition : BaseClass, ITestModule
    {
        public Precondition()
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
        		Preconditions.Steps.CloseTab();
        		TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
	      		Preconditions.Steps.SelectedServerTreeItem = server;
	      		Preconditions.Steps.SelectedServerName = server.Text;
	      		server.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		Preconditions.Steps.CreateDatabase();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.QueryAnalyser();
        		if(Config.SchemaServers.Contains(server.Text))
        			Preconditions.Steps.SelectSchemaDBFromComboBox(Config.ADSDB_CAPS);	
        		else
        			Preconditions.Steps.SelectDBFromComboBox(Config.ADSDB);
        		Preconditions.Steps.CreateTable();
        		Preconditions.Steps.CloseTab(server.Text);
        		Preconditions.Steps.isPreconditionDone = true; 
        	}
        	catch (Exception ex) 
        	{
        		Preconditions.Steps.isPreconditionDone = false;
        		Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
        	}
        	return true;
        }        
    }
}

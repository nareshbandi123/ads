
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

namespace ADSAutomationPhaseII.TC_10541.TC2
{
	
	[TestModule("D88883AA-633B-4FF5-80CA-4B9D92A91BF5", ModuleType.UserCode, 1)]
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
				Steps.ClickonTools();
				Steps.SelectSchemaScriptgenerator();
				Steps.SelectServer();
				Steps.ClickOkButton();
				Steps.UnselectObjectTypes();
				Steps.SelectObjecttypeTable();
				Steps.UnselectObjects();
				Steps.SelectObjectsTable();
				Steps.ClickonNext();
				Steps.CLickonBrwoseButton();
				Steps.ProvidePath();
				Steps.ClickonSelect();
				Steps.ClickonNext();
				Steps.ClickonDeselectButton();
				Steps.ClickonClose();
				Steps.Clickonserver();
				Preconditions.Steps.QueryAnalyser();
				Preconditions.Steps.ClickQAOpenFile();
				Steps.SelectFile();
				Steps.OpenFile();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			return true;
		}
	}
}

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
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10536.TC2
{
	[TestModule("DF6F1B17-11B2-46E1-8DBB-7AC2840412AC", ModuleType.UserCode, 1)]
	public class Vertica : BaseClass, ITestModule
	{
		public Vertica()
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
				Steps.ClickOnTools();
				Steps.SelectCompareTools();
				Steps.SelectSchemaCompare();
				Steps.ClickOnLeftChooseServer();
				Steps.SelectAquafold();
				Steps.ClickOkButton();
				Steps.Vertica_SchemaLeft();
				Steps.ClickOnRightChooseServer();
				Steps.SelectAquafold();
				Steps.ClickOkButton();
				Steps.Vertica_SchemaRight();
				Steps.SetSchema();
				Steps.UnselectSchemaObjects();
				Steps.ScanForTables();
				Steps.UnselectLeftObjects();
				Steps.SelectLeftTable();
				Steps.UnselectRightObjects();
				Steps.SelectRightTable();
				Steps.ClickOnCompareButton();
				Steps.ClickOnTable();
				Steps.ClickOnSpreadSheetIcon();
				Steps.ClickOnCloseButton();
				Preconditions.Steps.CloseTab();
			}
			catch (Exception ex)
			{
				Reports.ReportLog(ex.Message, Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
			
			return true;
		}

	}
}

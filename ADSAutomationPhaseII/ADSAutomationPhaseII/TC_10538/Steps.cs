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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10538
{
	public class Steps
	{
		public static TC10538 repo = TC10538.Instance;
		public static string TC1_10538_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10538_Path"].ToString();
		public const string INSERTQUERY = "insert into ads_table values(1,'xyz', 'Idera', 'x', 'yz')";
		public const string INSERTQUERY_DERBY = "INSERT INTO ads_db.ads_table VALUES (1,'TEN','VOS','Marianne')";
		public const string INSERTQUERY_GREENPLUM = "INSERT INTO ads_table VALUES (1,105, 1,'F', 12,'VOS','Marianne')";
		public const string INSERTQUERY_INFORMIX = "INSERT INTO ads_table VALUES( 1,'foobar','VOS','Marianne')";
		public const string INSERTQUERY_VERTICA = "INSERT INTO ads_db.ads_table VALUES (1, 'male', 'DPR', 'MA', 35,'VOS','Marianne')";
		public const string INSERTQUERY_TERADATA = "INSERT INTO ads_table (ID,DOB,JoinedDate,DepartmentNo,firstname,lastname)VALUES (1,'1980-01-05','2005-03-27',01,'VOS','Marianne')";
		public const string INSERTQUERY_SYSBASEASE = "INSERT INTO ads_table(id, DepartmentName, DepartmentHeadID, firstname, lastname)VALUES (1, 'Eastern Sales', 500,'VOS','Marianne')";
		public const string INSERTQUERY_SQLSERVER = "INSERT INTO ads_table (ID, CustomerName, City, PostalCode, Country, firstname, lastname)VALUES (1, 'Cardinal', 'Stavanger', '4006', 'Norway','VOS','Marianne')";
		public const string INSERTQUERY_POSTGRESQL = "INSERT INTO ads_table (id, url, name, firstname, lastname)VALUES(1, 'http://www.facebook.com','Facebook','VOS','Marianne')";
		public const string INSERTQUERY_ORACLE = "INSERT INTO ads_table(id, supplier_name, city, firstname, lastname)  VALUES  (1, 'Flipkart','Hyd', 'VOS','Marianne')";
		public const string INSERTQUERY_NETEZZA = "INSERT INTO ads_table(id, firstname, lastname, num) VALUES(2, 'john', 'tom', '1')";
		public const string INSERTQUERY_MARIADB = "INSERT INTO `ads_table`(`id`, `product_name`, `firstname`, `lastname`)VALUES(1, 'audi', 'kapoor', 'yash')";
		public const string INSERTQUERY_DB2 = "INSERT INTO ads_table (id, name, jobrole, JOINDATE, salary, firstname, lastname) values (1, 'JIM', 'Manager', CURRENT TIMESTAMP, 10.0,'VOS','Marianne')";
		public const string INSERTQUERY_CASSANDRA = "insert into ads_table(id, lastname, firstname) values(5b6962dd-3f90-4c93-8f61-eabfa4a803e2,'VOS','Marianne')";
		
		public static void ClickOnF1Servers()
		{
			try
			{
				repo.Application.F1ServerInfo.WaitForExists(new Duration(500));
				repo.Application.F1Server.ClickThis();
				Reports.ReportLog("ClickOnF1Servers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnF1Servers : " + ex.Message);
			}
		}
		
		public static void ClickOnServerProperties()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+P"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ClickOnServerProperties", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnServerProperties : " + ex.Message);
			}
		}
		
		public static void ClickOnConnectionMonitorTab()
		{
			try
			{
				repo.EditServerProp.ConnectionMonitorInfo.WaitForItemExists(200000);
				repo.EditServerProp.ConnectionMonitor.ClickThis();
				Reports.ReportLog("ClickOnConnectionMonitorTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnConnectionMonitorTab : " + ex.Message);
			}
		}
		
		public static void SelectPingIdleConnection()
		{
			try
			{
				repo.EditServerProp.PingIdleConnectionInfo.WaitForItemExists(200000);
				if(repo.EditServerProp.PingIdleConnection.Text != "true")
				{
					repo.EditServerProp.PingIdleConnection.ClickThis();
					Reports.ReportLog("SelectPingIdleConnection", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectPingIdleConnection : " + ex.Message);
			}
		}
		
		public static void ClickOnYes()
		{
			try
			{
				if(repo.EditServerProperties.YesButtonInfo.Exists(2000))
				{
					repo.EditServerProperties.SelfInfo.WaitForItemExists(200000);
					repo.EditServerProperties.YesButton.ClickThis();
					Reports.ReportLog("ClickOnYes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnYes : " + ex.Message);
			}
		}
		
		public static void ClickOnSave()
		{
			try
			{
				if(repo.EditServerProp.SaveInfo.Exists(2000))
				{
					repo.EditServerProp.SaveInfo.WaitForItemExists(200000);
					repo.EditServerProp.Save.ClickThis();
					Reports.ReportLog("ClickOnSave", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnSave : " + ex.Message);
			}
		}
		
		public static void ClickOnTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForExists(new Duration(500));
				repo.Application.Tools.ClickThis();
				Reports.ReportLog("ClickOnTools", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnTools : " + ex.Message);
			}
		}
		
		public static void ClickOnConectionMonitor()
		{
			try
			{
				repo.DataStudio.ConnectionMonitorInfo.WaitForItemExists(200000);
				repo.DataStudio.ConnectionMonitor.ClickThis();
				Reports.ReportLog("ClickOnConectionMonitor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnConectionMonitor : " + ex.Message);
			}
		}
		
		public static void ValidatePing()
		{
			if(repo.ConnectionMonitor.PingWindow.Rows.Count > 0)
			{
				Reports.ReportLog("Validation : ValidatePing", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			else
			{
				Reports.ReportLog("Validation : ValidatePing", Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
			}
		}
		
		public static void CloseConnectionMonitor()
		{
			try
			{
				repo.ConnectionMonitor.CloseInfo.WaitForItemExists(200000);
				repo.ConnectionMonitor.Close.ClickThis();
				Reports.ReportLog("CloseConnectionMonitor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseConnectionMonitor : " + ex.Message);
			}
		}
		
		public static void ClickOnAutomate()
		{
			try
			{
				repo.Application.AutomateInfo.WaitForItemExists(200000);
				repo.Application.Automate.ClickThis();
				Reports.ReportLog("ClickOnAutomate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnAutomate : " + ex.Message);
			}
		}
		
		public static void ClickOnInsert()
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+I"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnInsert", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnInsert : " + ex.Message);
			}
		}
		
		public static void ClickOnUpdate()
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+U"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnUpdate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnUpdate : " + ex.Message);
			}
		}
		
		public static void ClickOnSelect()
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+S"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnSelect", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnSelect : " + ex.Message);
			}
		}
		
		public static void ClickOnDelete()
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+D"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnDelete", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnDelete : " + ex.Message);
			}
		}
		
		public static void InsertQuery()
		{
			System.Threading.Thread.Sleep(5000);
			EditInsertQuery(INSERTQUERY);
		}
		
		public static void InsertQuery_Derby()
		{
			EditInsertQuery(INSERTQUERY_DERBY);
		}
		
		public static void InsertQuery_DB2()
		{
			EditInsertQuery(INSERTQUERY_DB2);
		}
		
		public static void InsertQuery_Cassandra()
		{
			EditInsertQuery(INSERTQUERY_CASSANDRA);
		}

		public static void InsertQuery_GreenPlum()
		{
			EditInsertQuery(INSERTQUERY_GREENPLUM);
		}

		public static void InsertQuery_Informix()
		{
			EditInsertQuery(INSERTQUERY_INFORMIX);
		}
		
		public static void InsertQuery_MARIADB()
		{
			EditInsertQuery(INSERTQUERY_MARIADB);
		}

		public static void InsertQuery_Netezza()
		{
			EditInsertQuery(INSERTQUERY_NETEZZA);
		}
		
		public static void InsertQuery_Oracle()
		{
			EditInsertQuery(INSERTQUERY_ORACLE);
		}
		
		public static void InsertQuery_PostgreSQL()
		{
			EditInsertQuery(INSERTQUERY_POSTGRESQL);
		}
		
		public static void InsertQuery_SQLSERVER()
		{
			EditInsertQuery(INSERTQUERY_SQLSERVER);
		}
		
		public static void InsertQuery_SysbaseASE()
		{
			EditInsertQuery(INSERTQUERY_SYSBASEASE);
		}
		
		public static void InsertQuery_Teradata()
		{
			EditInsertQuery(INSERTQUERY_TERADATA);
		}
		
		public static void InsertQuery_Vertica()
		{
			EditInsertQuery(INSERTQUERY_VERTICA);
		}
		
		public static void EditVerticaUpdateQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				repo.UntitledApplication.QATextEditor.PressKeys("UPDATE ads_db." +Config.ADSTABLE+  " SET id = 2 WHERE id = 1");
				repo.UntitledApplication.QATextEditor.Click();
				Preconditions.Steps.Sleep();
				Reports.ReportLog("EditVerticaUpdateQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditVerticaUpdateQuery : " + ex.Message);
			}
		}
		
		public static void EditVerticaSelectQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("SELECT * FROM ads_db." + Config.ADSTABLE + " WHERE id = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditVerticaSelectQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditVerticaSelectQuery : " + ex.Message);
			}
		}
		
		public static void EditVerticaDeleteQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("DELETE FROM ads_db."+Config.ADSTABLE+ " WHERE id = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditVerticaDeleteQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditVerticaDeleteQuery : " + ex.Message);
			}
		}
		
		public static void EditNetezzaUpdateQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				repo.UntitledApplication.QATextEditor.PressKeys("UPDATE " +Config.ADSTABLE+ " SET num = 2 WHERE num = 1");
				repo.UntitledApplication.QATextEditor.Click();
				Preconditions.Steps.Sleep();
				Reports.ReportLog("EditNetezzaUpdateQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditNetezzaUpdateQuery : " + ex.Message);
			}
		}
		
		public static void EditNetezzaSelectQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("SELECT * FROM "+ Config.ADSTABLE + " WHERE num = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditNetezzaSelectQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditNetezzaSelectQuery : " + ex.Message);
			}
		}
		
		public static void EditNetezzaDeleteQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("DELETE FROM "+Config.ADSTABLE+ " WHERE num = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditNetezzaDeleteQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditNetezzaDeleteQuery : " + ex.Message);
			}
		}
		
		public static void EditInsertQuery(string query)
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				//repo.UntitledApplication.QATextEditor.PressKeys("insert into "+ Config.ADSTABLE + " values(1,'xyz', 'Idera', 'x', 'yz')");
				repo.UntitledApplication.QATextEditor.PressKeys(query);
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditInsertQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditInsertQuery : " + ex.Message);
			}
		}
		
		public static void EditCassandraInsertQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("insert into "+ Config.ADSTABLE + "(id, lastname, firstname) values(5b6962dd-3f90-4c93-8f61-eabfa4a803e2,'VOS','Marianne')");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditCassandraInsertQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditCassandraInsertQuery : " + ex.Message);
			}
		}
		
		public static void EditUpdateQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditorInfo.WaitForItemExists(200000);
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(2000);
				repo.UntitledApplication.QATextEditor.PressKeys("UPDATE " +Config.ADSTABLE+ " SET id = 2 WHERE id = 1");
				repo.UntitledApplication.QATextEditor.Click();
				Preconditions.Steps.Sleep();
				Reports.ReportLog("EditUpdateQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditUpdateQuery : " + ex.Message);
			}
		}
		
		public static void EditCassandraUpdateQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				repo.UntitledApplication.QATextEditor.PressKeys("UPDATE " +Config.ADSTABLE+ " SET lastname = 'VOSS' WHERE id = 5b6962dd-3f90-4c93-8f61-eabfa4a803e2");
				repo.UntitledApplication.QATextEditor.Click();
				Preconditions.Steps.Sleep();
				Reports.ReportLog("EditCassandraUpdateQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditCassandraUpdateQuery : " + ex.Message);
			}
		}
		
		public static void EditSelectQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(2000);
				repo.UntitledApplication.QATextEditor.PressKeys("SELECT * FROM " + Config.ADSTABLE + " WHERE id = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditSelectQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditSelectQuery : " + ex.Message);
			}
		}
		
		public static void EditCassandraSelectQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("SELECT * FROM " + Config.ADSTABLE + " WHERE id = 5b6962dd-3f90-4c93-8f61-eabfa4a803e2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditCassandraSelectQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditCassandraSelectQuery : " + ex.Message);
			}
		}
		
		public static void EditDeleteQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(2000);
				repo.UntitledApplication.QATextEditor.PressKeys("DELETE FROM "+Config.ADSTABLE+ " WHERE id = 2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditDeleteQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditDeleteQuery : " + ex.Message);
			}
		}
		
		public static void EditCassandraDeleteQuery()
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.UntitledApplication.QATextEditor.PressKeys("DELETE FROM "+Config.ADSTABLE+ " WHERE id = 5b6962dd-3f90-4c93-8f61-eabfa4a803e2");
				repo.UntitledApplication.QATextEditor.Click();
				Reports.ReportLog("EditCassandraDeleteQuery", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditCassandraDeleteQuery : " + ex.Message);
			}
		}
		
		public static void Execute()
		{
			Preconditions.Steps.ClickQARun();
		}
		
		public static void Discard()
		{
			try
			{
				if(repo.FileModifier.DiscardInfo.Exists(new Duration(2000)))
					repo.FileModifier.Discard.ClickThis();
				
				Reports.ReportLog("Discard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Discard : " + ex.Message);
			}
		}

		public static void MorphToUpperCase()
		{
			try
			{
				ClickOnAutomate();
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+P"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				Reports.ReportLog("MorphToUpperCase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MorphToUpperCase : " + ex.Message);
			}
		}
		
		public static void MorphToLowerCase()
		{
			try
			{
				ClickOnAutomate();
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+L"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				Reports.ReportLog("MorphToLowerCase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MorphToLowerCase : " + ex.Message);
			}
		}
		
		public static void MorphToDelimitedList()
		{
			try
			{
				ClickOnAutomate();
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+O"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				repo.SeparatedList.DelimitedInfo.WaitForItemExists(200000);
				repo.SeparatedList.Delimited.TextBoxText("{none}");
				repo.SeparatedList.OkButtonInfo.WaitForExists(new Duration(1000));
				repo.SeparatedList.OkButton.ClickThis();
				Reports.ReportLog("MorphToDelimitedList", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MorphToDelimitedList : " + ex.Message);
			}
		}
		
		public static void FormatStatement()
		{
			try
			{
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+B"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Preconditions.Steps.Sleep();
				repo.BeautifyOptions.OkButtonInfo.WaitForItemExists(200000);
				repo.BeautifyOptions.OkButton.ClickThis();
				Preconditions.Steps.Sleep();
				Reports.ReportLog("FormatStatement", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : FormatStatement : " + ex.Message);
			}
		}
		
		public static void WaitForQATabExist()
		{
			try
			{
				repo.UntitledApplication.QATextEditorInfo.WaitForItemExists(200000);
				Reports.ReportLog("WaitForQATabExist", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : WaitForQATabExist : " + ex.Message);
			}
		}
	}
}

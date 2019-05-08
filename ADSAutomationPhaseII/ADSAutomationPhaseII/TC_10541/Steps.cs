using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Base;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10541
{
	public static class Steps
	{
		
		public static TC10541Repo repo = TC10541Repo.Instance;
		public static string TC2_10541_Path = System.Configuration.ConfigurationManager.AppSettings["TC2_10541_Path"].ToString();
		public const string CREATETABLE = "create table IF NOT EXISTS ads_table_import (id int, name varchar, project varchar, firstname varchar, lastname varchar)";
		public const string CREATETABLE_CASSANDRA = "CREATE TABLE ads_table_import ( id UUID PRIMARY KEY, lastname text, firstname text)";
		public const string CREATETABLE_DERBY = "CREATE TABLE ads_db.ads_table_import (ID INT PRIMARY KEY, NAME VARCHAR, firstname varchar, lastname varchar)";
		public const string CREATETABLE_GREENPLUM = "CREATE TABLE ads_table_import (id int, rank int, year smallint, gender char(1), count int, firstname varchar, lastname varcharDISTRIBUTED BY (rank, gender, year)";
		public const string CREATETABLE_INFORMIX = "CREATE TABLE ads_table_import (i integer, s varchar(10), firstname varchar, lastname varchar)";
		public const string CREATETABLE_VERTICA = "CREATE TABLE ads_db.ads_table_import (id INTEGER NOT NULL PRIMARY KEY, vendor_name VARCHAR, vendor_address VARCHAR, vendor_city VARCHAR, deal_size INTEGER, firstname varchar, lastname varchar)";
		public const string CREATETABLE_TERADATA = "CREATE SET TABLE ads_table_import(ID INTEGER, DOB DATE FORMAT 'YYYY-MM-DD', JoinedDate DATE FORMAT 'YYYY-MM-DD', DepartmentNo BYTEINT, firstname varchar, lastname varchar) UNIQUE PRIMARY INDEX (ID)";
		public const string CREATETABLE_SYSBASEASE = "CREATE TABLE ads_table_import (id int NOT NULL, DepartmentName varchar NULL, DepartmentHeadID int, firstname varchar, lastname varchar)";
		public const string CREATETABLE_SQLSERVER = "CREATE TABLE ads_table_import (ID int, CustomerName varchar, City varchar, PostalCode varchar, Country varchar, firstname varchar, lastname varchar)";
		public const string CREATETABLE_POSTGRESQL = "CREATE TABLE ads_table_import ( id serial PRIMARY KEY, url VARCHAR NOT NULL, name VARCHAR NOT NULL, description VARCHAR (255), rel VARCHAR (50), firstname varchar, lastname varchar)";
		public const string CREATETABLE_ORACLE = "CREATE TABLE ads_table_import ( id number NOT NULL, supplier_name varchar2 NOT NULL, city varchar2, firstname varchar, lastname varchar)";
		public const string CREATETABLE_NETEZZA = "CREATE TABLE ads_table_import  (id INT NOT NULL, firstname varchar, lastname varchar, CONSTRAINT id PRIMARY KEY(id), num INT)";
		public const string CREATETABLE_MARIADB = "CREATE TABLE ads_table_import(product_id INT, product_name VARCHAR, firstname Varchar, lastname varchar);";
		public const string CREATETABLE_DB2 = "create table ads_table_import (id int, name varcharjobrole varcharjoindate date, salary double, firstname varchar, lastname varchar)";
		public const string CREATETABLE_MYSQL = "CREATE TABLE ads_table_import (name VARCHAR, owner VARCHAR,species VARCHAR, sex CHAR, birth DATE, death DATE, firstname varchar, lastname varchar)";
		
		
		#region "Step1"
		
		public static void Clickonserver()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.ClickThis();
				Reports.ReportLog("Clickonserver", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Clickonserver : " + ex.Message);
			}
		}
		
		public static void ClickonFluidShell()
		{
			try
			{
				Preconditions.Steps.Sleep();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+F"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("ClickonFluidShell", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				Preconditions.Steps.Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFluidShell : " + ex.Message);
			}
		}
		
		public static void EnterConnect()
		{
			try
			{
				ExplicitWait();
				repo.Application.TextingBox.PressKeys("connect");
				ClickEnter();
				Reports.ReportLog("EnterConnect", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterConnect : " + ex.Message);
			}
		}
		
		public static void ChangeDatabase()
		{
			try
			{
				ExplicitWait();
				repo.Application.TextingBox.PressKeys("change database ads_db");
				ClickEnter();
				Reports.ReportLog("ChangeDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeDatabase : " + ex.Message);
			}
		}
		
		public static void ClickEnter()
		{
			try
			{
				ExplicitWait();
				Keyboard.Press("{ENTER}");
				ExplicitWait();
				Reports.ReportLog("ClickEnter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickEnter : " + ex.Message);
			}
		}
		
		public static void EntertheDisconnect()
		{
			try
			{
				//Keyboard.Press("disconnect{Return}");
				repo.Application.TextingBox.PressKeys("disconnect");
				ClickEnter();
				Reports.ReportLog("EntertheDisconnect", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheDisconnect : " + ex.Message);
			}
		}
		
		public static void EntertheText1()
		{
			try
			{
				repo.Application.TextingBox.PressKeys("exec netstat");
				ClickEnter();
				Reports.ReportLog("EntertheText1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText1 : " + ex.Message);
			}
		}
		
		public static void EntertheText2()
		{
			try
			{
				repo.Application.TextingBox.PressKeys("sqlexport ads_table -o myfile.csv");
				ClickEnter();
				Reports.ReportLog("EntertheText2", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText2 : " + ex.Message);
			}
		}
		
		public static void EntertheText3()
		{
			try
			{
				repo.Application.TextingBox.PressKeys("sqlimport ads_table_import myfile.csv");
				ClickEnter();
				Reports.ReportLog("EntertheText3", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText3 : " + ex.Message);
			}
		}
		
		public static void CloseTab()
		{
			try
			{
				if(repo.FileModified.SelfInfo.Exists())
					repo.FileModified.Discard.ClickThis();
				Reports.ReportLog("CloseTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseTab : " + ex.Message);
			}
		}
		public static void ImportTable1()
		{
			try
			{
				repo.Application.QueryBox.PressKeys("select * from ads_table_import");
				Reports.ReportLog("ImportTable1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ImportTable1 : " + ex.Message);
			}
		}
		
		public static void ClickonDiscard()
		{
			try
			{
				if(repo.FileModified.DiscardInfo.Exists(2000))
				{
					repo.FileModified.Discard.ClickThis();
					Reports.ReportLog("ClickonDiscard", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonDiscard : " + ex.Message);
			}
		}
		
		public static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(2000);
		}
		
		public static void ImportTable()
		{
			EditCreateTable(CREATETABLE);
		}
		
		public static void ImportTable_Derby()
		{
			EditCreateTable(CREATETABLE_DERBY);
		}
		
		public static void ImportTable_DB2()
		{
			EditCreateTable(CREATETABLE_DB2);
		}
		
		public static void ImportTable_Cassandra()
		{
			EditCreateTable(CREATETABLE_CASSANDRA);
		}

		public static void ImportTable_GreenPlum()
		{
			EditCreateTable(CREATETABLE_GREENPLUM);
		}

		public static void ImportTable_Informix()
		{
			EditCreateTable(CREATETABLE_INFORMIX);
		}
		
		public static void ImportTable_MARIADB()
		{
			EditCreateTable(CREATETABLE_MARIADB);
		}

		public static void ImportTable_Netezza()
		{
			EditCreateTable(CREATETABLE_NETEZZA);
		}
		
		public static void ImportTable_Oracle()
		{
			EditCreateTable(CREATETABLE_ORACLE);
		}
		
		public static void ImportTable_PostgreSQL()
		{
			EditCreateTable(CREATETABLE_POSTGRESQL);
		}
		
		public static void ImportTable_SQLSERVER()
		{
			EditCreateTable(CREATETABLE_SQLSERVER);
		}
		
		public static void ImportTable_SysbaseASE()
		{
			EditCreateTable(CREATETABLE_SYSBASEASE);
		}
		
		public static void ImportTable_Teradata()
		{
			EditCreateTable(CREATETABLE_TERADATA);
		}
		
		public static void ImportTable_Vertica()
		{
			EditCreateTable(CREATETABLE_VERTICA);
		}
		
		public static void EditCreateTable(string query)
		{
			try
			{
				repo.UntitledApplication.QATextEditor.Click();
				repo.UntitledApplication.QATextEditor.PressKeys(query);
				repo.UntitledApplication.QATextEditor.Click();
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditCreateTable : " + ex.Message);
			}
		}
		
		public static void Execute()
		{
			try
			{
				Preconditions.Steps.ClickQARun();
				Reports.ReportLog("Execute", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute : " + ex.Message);
			}
		}
		
		
		#endregion
		
		
		public static void ClickonTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(50000);
				repo.Application.Tools.ClickThis();
				Reports.ReportLog("ClickonTools", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonTools : " + ex.Message);
			}
		}
		
		public static void SelectSchemaScriptgenerator()
		{
			try
			{
				repo.Datastudio.ScriptGeneratorInfo.WaitForItemExists(10000);
				repo.Datastudio.ScriptGenerator.ClickThis();
				Reports.ReportLog("SelectSchemaScriptgenerator", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaScriptgenerator : " + ex.Message);
			}
		}
		
		public static void SelectServer()
		{
			try
			{
				try{repo.ChooseFromServer.ServerListInfo.WaitForExists(new Duration(10000));}
				catch{SelectServer();}
				
				TreeItem SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName);
				if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
					Preconditions.Steps.SelectedServerTreeItem = server;
					Preconditions.Steps.SelectedServerName = server.Text;
					SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
				SelectedServer.EnsureVisible();
				TreeItem SelectedDB = SelectedServer.GetItem(Config.ADSDB);
				SelectedDB.EnsureVisible();
				SelectedDB.Select();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServer : " + ex.Message);
			}
		}
		
		public static void ClickOkButton()
		{
			try
			{
				repo.LocalServers.OkayButton.ClickThis();
				Reports.ReportLog("ClickOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void SelectDatabase()
		{
			try
			{
				repo.ScriprtGeneratorWindow.DropdownICon.ClickThis();
				Reports.ReportLog("SelectDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDatabase : " + ex.Message);
			}
		}
		
		public static void SelectAdsdb()
		{
			try
			{
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectAdsdb : " + ex.Message);
			}
		}
		
		public static void UnselectObjectTypes()
		{
			try
			{
				repo.ScriprtGeneratorWindow.LeftSide.UnselectObjectType.ClickThis();
				Reports.ReportLog("UnselectObjectTypes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnselectObjectTypes : " + ex.Message);
			}
		}
		
		public static void SelectObjecttypeTable()
		{
			try
			{
				repo.ScriprtGeneratorWindow.SelectObjectTypeTable.ClickThis();
				Reports.ReportLog("SelectObjecttypeTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectObjecttypeTable : " + ex.Message);
			}
		}
		
		public static void UnselectObjects()
		{
			try
			{
				repo.ScriprtGeneratorWindow.RightSide.UnselectObjects.ClickThis();
				Reports.ReportLog("UnselectObjects", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : UnselectObjects : " + ex.Message);
			}
		}
		
		public static void SelectObjectsTable()
		{
			try
			{
				repo.ScriprtGeneratorWindow.SelectObjectsTable.ClickThis();
				Reports.ReportLog("SelectObjectsTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectObjectsTable : " + ex.Message);
			}
		}
		
		public static void ClickonNext()
		{
			try
			{
				repo.ScriprtGeneratorWindow.NextButton.ClickThis();
				Reports.ReportLog("ClickonNext", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonNext : " + ex.Message);
			}
		}
		
		public static void CLickonBrwoseButton()
		{
			try
			{
				repo.ScriprtGeneratorWindow.Browse.ClickThis();
				Reports.ReportLog("CLickonBrwoseButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CLickonBrwoseButton : " + ex.Message);
			}
		}
		
		public static void ProvidePath()
		{
			try
			{
				repo.SelectWindow.PathtextBox.TextBoxText(TC2_10541_Path + "Testing.sql");
				Reports.ReportLog("ProvidePath", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ProvidePath : " + ex.Message);
			}
		}
		
		public static void SelectFile()
		{
			try
			{
				repo.OpenWindow.FileTextPath.TextBoxText(TC2_10541_Path + "Testing.sql");
				Reports.ReportLog("SelectFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFile : " + ex.Message);
			}
		}
		
		public static void OpenFile()
		{
			try
			{
				repo.OpenWindow.Open.ClickThis();
				Reports.ReportLog("OpenFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenFile : " + ex.Message);
			}
		}
		
		public static void ClickonSelect()
		{
			try
			{
				repo.SelectWindow.Select.ClickThis();
				Reports.ReportLog("ClickonSelect", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSelect : " + ex.Message);
			}
		}
		
		public static void ClickonClose()
		{
			try
			{
				repo.ScriprtGeneratorWindow.Status.StatusofWindowInfo.WaitForExists(10000);
				repo.ScriprtGeneratorWindow.CloseButton.ClickThis();
				Reports.ReportLog("ClickonClose", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonClose : " + ex.Message);
			}
		}
		
		public static void ClickonDeselectButton()
		{
			try
			{
				if(repo.CancelWindow.SelfInfo.Exists())
					repo.CancelWindow.DeselectButton.ClickThis();
				Reports.ReportLog("ClickonDeselectButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonDeselectButton : " + ex.Message);
			}
		}
	}
}

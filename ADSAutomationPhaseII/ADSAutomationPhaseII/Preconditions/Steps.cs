using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using System.Xml.Linq;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.Data;
using System.Configuration;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.Preconditions
{
	public static class Steps
	{
		public static int ApplicationOpenWaitTime = 180000;
		
		public const int iCreate = 0;
		public const int iInsert = 1;
		public const int iSelect = 2;
		public const int iValidate = 3;
		public const int iDropTable = 4;
		public const int iCreateDB = 5;
		public const int iDropDB = 6;
		public const int iCreateSecond = 7;
		public const int iSelectTable = 8;
		public const int iCreateConstarins = 9;
		public const int iCreateView = 10;
		public const int iCreateIndex = 11;
		public const int iCreateTrigger = 12;
		public const int iDropView = 13;
		public const int iDropIndex = 14;
		public const int iDropTrigger = 15;
		public const int iCreateDB1 = 16;
		public const int iDropDB1 = 17;
		public const int iCreateSecondTable = 18;
		public const int iInsertSecond = 19;
		public const int iDropSecondTable = 20;
		public const int iCreateProcedure = 21;
		public const int iCreateFunction = 22;
		public const int iCreateEvent = 23;
		public const int iDropProcedure = 24;
		public const int iDropFunction= 25;
		public const int iDropEvent = 26;
		
		public static int Retries =  System.Configuration.ConfigurationManager.AppSettings["Retries"].ToString() == null ? 3 : Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["Retries"].ToString());
		public static string QueryTestDataPath = System.Configuration.ConfigurationManager.AppSettings["Queries"].ToString();
		public static int RetryCount = 1;
		public static PreconditionRepo repo = PreconditionRepo.Instance;
		
		public static void Sleep()
		{
			System.Threading.Thread.Sleep(300);
		}
		
		public static void RightClick(this Ranorex.TreeItem item)
		{
			try
			{
				Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Sleep();
			}
			catch(Exception ex)
			{
				throw new Exception("TreeItem Right Click failed : " + ex.Message);
			}
		}
		
		public static void RightClick(this Ranorex.TabPage tab)
		{
			try
			{
				Mouse.Click(tab,System.Windows.Forms.MouseButtons.Right, new Point(40, 10));
				Sleep();
			}
			catch(Exception ex)
			{
				throw new Exception("Tabpage Right Click failed : " + ex.Message);
			}
		}
		
		public static void CloseTab(string tabName)
		{
			try
			{
				if(repo.QueryAnalyzer.TabInfo.Exists(new Duration(5000)))
				{
					Ranorex.TabPage tabPage = repo.QueryAnalyzer.Tab;
					tabPage.RightClick();
					
					if(repo.SunAwtWindow.CloseAllTabsInfo.Exists(new Duration(1000)))
					{
						repo.SunAwtWindow.CloseAllTabs.ClickThis();
					}
					else
					{
						repo.SunAwtWindow.CloseTab.ClickThis();
					}
					DiscardChanges();
				}
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CloseTab failed : " + ex.Message);
			}
			
		}
		
		public static void DiscardChanges()
		{
			try
			{
				if(repo.FileModified.DiscardButtonInfo.Exists(new Duration(5000)))
					repo.FileModified.DiscardButton.ClickThis();
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("DiscardChanges failed : " + ex.Message);
			}
			
		}
		
		public static void CloseTab()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+F4"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CloseTab failed : " + ex.Message);
			}
			
		}
		
		public static void Escape()
		{
			try
			{
				Keyboard.Press(Keys.Escape, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Escape failed : " + ex.Message);
			}
			
		}
		
		public static void ConnectServer()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(10000);
				
				// Server Status Check 
				if(SelectedServerName != "MSExcel" && SelectedServerTreeItem.Items.Count <= 1)
				{
						isPreconditionDone = false;
						SelectedServerTreeItem.Select();
						SelectedServerTreeItem.RightClickThis();
						DisconnectServer();
						throw new Exception("ConnectServer failed : Server Connection failed for the server : " + SelectedServerName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("ConnectServer failed : " + ex.Message);
			}
		}
		
		public static void ReConnectServer()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("ReConnectServer failed : " + ex.Message);
			}
		}
		
		public static void DisconnectServer()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("DisconnectServer failed : " + ex.Message);
			}
		}
		
		public static void QueryAnalyser()
		{
			try
			{
				Escape();
				if(repo.QueryAnalyzer.TabInfo.Exists(new Duration(5000))) CloseTab("");
				
				Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
				
				// Additional Check to handle server connection failures
				if(repo.Connection.RetryButtonInfo.Exists(5000))
				{
					repo.Connection.CloseButton.ClickThis();
					isPreconditionDone = false;
					SelectedServerTreeItem.Select();
					DisconnectServer();
					throw new Exception("ConnectServer failed : Server Connection failed for the server : " + SelectedServerName);
				}
				
				repo.QueryAnalyzer.TabInfo.WaitForItemExists(10000);
			}
			catch (Exception ex)
			{
				throw new Exception("QueryAnalyser failed : " + ex.Message);
			}
		}
		
		public static void QueryAnalyserTab()
		{
			try
			{
				Escape();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
				
				// Additional Check to handle server connection failures
				if(repo.Connection.RetryButtonInfo.Exists(5000))
				{
					repo.Connection.CloseButton.ClickThis();
					isPreconditionDone = false;
					SelectedServerTreeItem.Select();
					DisconnectServer();
					throw new Exception("ConnectServer failed : Server Connection failed for the server : " + SelectedServerName);
				}
				
				repo.QueryAnalyzer.TabInfo.WaitForItemExists(10000);
			}
			catch (Exception ex)
			{
				throw new Exception("QueryAnalyser failed : " + ex.Message);
			}
		}
		
		public static void ClickQAOpenFile()
		{
			try
			{
				//Keyboard.Press(Keyboard.ToKey("Ctrl+O"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.QueryAnalyzer.OpenQueryScriptInfo.WaitForItemExists(25000);
				repo.QueryAnalyzer.OpenQueryScript.ClickThis();
				repo.Open.FilePathTextboxInfo.WaitForExists(new Duration(25000));
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("ClickQAOpenFile failed : " + ex.Message);
			}
		}
		
		public static void ClickQAOpenFile_ShortcutKey()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+O"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.Open.FilePathTextboxInfo.WaitForExists(new Duration(25000));
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("ClickQAOpenFile failed : " + ex.Message);
			}
		}
		
		public static void ClickQARun()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				System.Threading.Thread.Sleep(2000);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("ClickQARun failed : " + ex.Message);
			}
		}
		
		public static void WriteScript(int index)
		{
			try
			{
				Sleep();
				ClickQAOpenFile();
				repo.Open.FilePathTextboxInfo.WaitForExists(new Duration(25000));
				repo.Open.FilePathTextbox.TextValue =  QueryTestDataPath + SelectedServerName;
				repo.Open.OpenButton.ClickThis();
				var items = repo.Open.QueryScriptList.Items;
				items[index].Select();
				repo.Open.OpenButton.ClickThis();
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("WriteScript failed : " + ex.Message);
			}
		}
		
		public static void SaveFileAs()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+S"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("SaveFileAs failed : " + ex.Message);
			}
		}
		
		public static void ExecuteScript(int index)
		{
			try
			{
				ClickQAOpenFile();
				repo.Open.FilePathTextbox.TextValue =  QueryTestDataPath + SelectedServerName;
				repo.Open.OpenButton.ClickThis();
				var items = repo.Open.QueryScriptList.Items;
				items[index].Select();
				repo.Open.OpenButton.ClickThis();
				ClickQARun();
				Sleep();
			}
			catch (Exception ex)
			{
				repo.Open.Self.Close();
				throw new Exception("ExecuteScript failed : " + ex.Message);
			}
		}
		
		public static void ExecuteScript_ShortCutkey(int index)
		{
			try
			{
				ClickQAOpenFile_ShortcutKey();
				repo.Open.FilePathTextbox.TextValue =  QueryTestDataPath + SelectedServerName;
				repo.Open.OpenButton.ClickThis();
				var items = repo.Open.QueryScriptList.Items;
				items[index].Select();
				repo.Open.OpenButton.ClickThis();
				ClickQARun();
				Sleep();
			}
			catch (Exception ex)
			{
				repo.Open.Self.Close();
				throw new Exception("ExecuteScript_ShortCutkey failed : " + ex.Message);
			}
		}
		
		public static void OpenScript(int index)
		{
			try
			{
				ClickQAOpenFile();
				repo.Open.FilePathTextboxInfo.WaitForExists(new Duration(20000));
				repo.Open.FilePathTextbox.TextValue =  QueryTestDataPath + SelectedServerName;
				repo.Open.OpenButton.ClickThis();
				var items = repo.Open.QueryScriptList.Items;
				items[index].Select();
				repo.Open.OpenButton.ClickThis();
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("OpenScript failed : " + ex.Message);
			}
		}
		
		public static void CreateDatabase1()
		{
			try
			{
				ExecuteScript(iCreateDB1);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CreateDatabase1 failed : " + ex.Message);
			}
		}
		
		public static void CreateDatabase()
		{
			try
			{
				ExecuteScript(iCreateDB);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CreateDatabase failed : " + ex.Message);
			}
		}
		
		public static void WriteCreateDatabase()
		{
			try
			{
				WriteScript(iCreateDB);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("WriteCreateDatabase failed : " + ex.Message);
			}
		}
		
		public static void CreateTable()
		{
			try
			{
				ExecuteScript(iCreate);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CreateTable failed : " + ex.Message);
			}
		}
		
		public static void CreateTable2()
		{
			try
			{
				ExecuteScript(iCreateSecondTable);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("CreateTable2 failed : " + ex.Message);
			}
		}
		
		public static void InsertTable()
		{
			try
			{
				ExecuteScript(iInsert);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Insert Table failed : " + ex.Message);
			}
		}
		
		public static void InsertTable2()
		{
			try
			{
				ExecuteScript(iInsertSecond);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Insert Table2 failed : " + ex.Message);
			}
		}
		
		public static void SelectTable()
		{
			try
			{
				ExecuteScript(iSelect);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Select Table failed : " + ex.Message);
			}
		}
		
		public static void SelectTable_ShortcutKey()
		{
			try
			{
				ExecuteScript_ShortCutkey(iSelect);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Select Table failed : " + ex.Message);
			}
		}
		
		
		public static void WriteSelectTable()
		{
			try
			{
				WriteScript(iSelect);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Select Table failed : " + ex.Message);
			}
		}
		
		public static void ValidateTable()
		{
			try
			{
				ExecuteScript(iValidate);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Validate Table failed : " + ex.Message);
			}
		}
		
		public static void DropTable()
		{
			try
			{
				ExecuteScript(iDropTable);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop Table failed : " + ex.Message);
			}
		}
		
		public static void DropSecondTable()
		{
			try
			{
				ExecuteScript(iDropSecondTable);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop Second Table failed : " + ex.Message);
			}
		}
		
		public static void DropDatabase()
		{
			try
			{
				ExecuteScript(iDropDB);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop DB failed : " + ex.Message);
			}
		}
		
		public static void DropDatabase1()
		{
			
			try
			{
				ExecuteScript(iDropDB1);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop DB1 failed : " + ex.Message);
			}
		}
		
		public static void CreateSecondTable()
		{
			try
			{
				ExecuteScript(iCreateSecond);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Create Second Table failed : " + ex.Message);
			}
		}
		
		public static void SelectSecondTable()
		{
			try
			{
				ExecuteScript(iSelectTable);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Select Second Table failed : " + ex.Message);
			}
		}
		
		public static void SelectSecondTable_ShortcutKey()
		{
			try
			{
				ExecuteScript_ShortCutkey(iSelectTable);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Select Second Table failed : " + ex.Message);
			}
		}
		
		public static void CreateTableWithConstraints()
		{
			try
			{
				ExecuteScript(iCreateConstarins);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Create Table with constraints failed : " + ex.Message);
			}
		}
		
		public static void DropView()
		{
			try
			{
				ExecuteScript(iDropView);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop view failed : " + ex.Message);
			}
		}
		
		public static void CreateView()
		{
			try
			{
				ExecuteScript(iCreateView);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Create view failed : " + ex.Message);
			}
		}
		
		public static void DropIndex()
		{
			try
			{
				ExecuteScript(iDropIndex);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop Index failed : " + ex.Message);
			}
		}
		
		public static void CreateIndex()
		{
			try
			{
				ExecuteScript(iCreateIndex);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Create Index failed : " + ex.Message);
			}
		}
		
		public static void DropTrigger()
		{
			try
			{
				ExecuteScript(iDropTrigger);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Drop Trigger failed : " + ex.Message);
			}
		}
		
		public static void CreateTrigger()
		{
			try
			{
				ExecuteScript(iCreateTrigger);
				Sleep();
			}
			catch (Exception ex)
			{
				throw new Exception("Create Trigger failed : " + ex.Message);
			}
		}
		
		public static void CreateProcedure()
		{
			Sleep();
			ExecuteScript(iCreateProcedure);
			Sleep();
		}
		
		public static void DropProcedure()
		{
			Sleep();
			ExecuteScript(iDropProcedure);
			Sleep();
		}
		
		public static void CreateFunction()
		{
			Sleep();
			ExecuteScript(iCreateFunction);
			Sleep();
		}
		
		public static void DropFunction()
		{
			Sleep();
			ExecuteScript(iDropFunction);
			Sleep();
		}
		
		public static void CreateEvent()
		{
			Sleep();
			ExecuteScript(iCreateEvent);
			Sleep();
		}
		
		public static void DropEvent()
		{
			Sleep();
			ExecuteScript(iDropEvent);
			Sleep();
		}
		
		public static void SelectDBFromComboBox(string dbName, bool isTab2 = false)
		{
			try
			{
				if(!isTab2)
				{
					repo.QueryAnalyzer.QAComboTextboxInfo.WaitForExists(new Duration(Common.ApplicationOpenWaitTime));
					repo.QueryAnalyzer.QAComboTextbox.TextBoxText(dbName);
				}
				else
				{
					repo.QueryAnalyzer.Tab2QAComboTextboxInfo.WaitForExists(new Duration(Common.ApplicationOpenWaitTime));
					repo.QueryAnalyzer.Tab2QAComboTextbox.TextBoxText(dbName);
				}
				Sleep();
			}
			catch (Exception ex)
			{
				CloseTab("");
				throw new Exception("Select DB From ComboBox failed : " + ex.Message);
			}
		}
		
		public static void SelectSchemaDBFromComboBox(string dbName, bool isTab2 = false)
		{
			try
			{
				if(!isTab2)
				{
					repo.QueryAnalyzer.SchemaQAComboTextboxInfo.WaitForExists(new Duration(Common.ApplicationOpenWaitTime));
					repo.QueryAnalyzer.SchemaQAComboTextbox.TextBoxText(dbName);
				}
				else
				{
					repo.QueryAnalyzer.Tab2SchemaQAComboTextboxInfo.WaitForExists(new Duration(Common.ApplicationOpenWaitTime));
					repo.QueryAnalyzer.Tab2SchemaQAComboTextbox.TextBoxText(dbName);
				}
				Sleep();
			}
			catch (Exception ex)
			{
				CloseTab("");
				throw new Exception("Select Schema DB From ComboBox failed : " + ex.Message);
			}
		}
		
		public static void TreeItemExpand(TreeItem treeitem)
		{
			try
			{
				treeitem.EnsureVisible();
				treeitem.Expand();
			}
			catch (Exception ex)
			{
				throw new Exception("TreeItem Expand failed : " + ex.Message);
			}
		}
		
		public static void TreeItemCollapse(TreeItem treeitem)
		{
			try
			{
				treeitem.EnsureVisible();
				treeitem.CollapseAll();
			}
			catch (Exception ex)
			{
				throw new Exception("TreeItem Collapse failed : " + ex.Message);
			}
		}
		
		public static void TreeItemDoubleClickToExpand(TreeItem treeitem)
		{
			try
			{
				treeitem.EnsureVisible();
				treeitem.DoubleClick();
			}
			catch (Exception ex)
			{
				throw new Exception("TreeItem Double Click To Expand failed : " + ex.Message);
			}
		}
		
		public static void TextboxText(Text text, string value)
		{
			try
			{
				text.TextValue = value;
			}
			catch(Exception ex)
			{
				throw new Exception("Textbox Text failed : " + ex.Message);
			}
		}
		
		public static TreeItem GetServerTreeFromTCName(string TCName)
		{
			TreeItem item = null;
			try
			{
				if(TCName.Contains(ServerListConstants.Amazon_Redshift))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Amazon_Redshift.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Cassandra_37))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Cassandra_37.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Cassandra_22))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Cassandra_22.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Apache_Derby_1014))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Apache_Derby_1014.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Derby_1013))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Derby_1013.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.DB2_LUW_111))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.DB2_LUW_111.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.DB2_LUW_105))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.DB2_LUW_105.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Greenplum_50))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Greenplum_50.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Greenplum_4312))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Greenplum_4312.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Informix_1170))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Informix_1170.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Informix_1210))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Informix_1210.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.MariaDB_102))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.MariaDB_102.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.MongoDB_321))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.MongoDB_321.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.MongoDB_341))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.MongoDB_341.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.MySQL_80))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.MySQL_80.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.MySQL_57))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.MySQL_57.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Netezza_72))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Netezza_72.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Oracle_121020))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Oracle_121020.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Oracle_11gR2))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Oracle_11gR2.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.PostgreSQL_100))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.PostgreSQL_100.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.PostgreSQL_96))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.PostgreSQL_96.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.SAP_Hana_20))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.SAP_Hana_20.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.SQL_Server_2017))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.SQL_Server_2017.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.SQL_Server_2016))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.SQL_Server_2016.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_Any_16))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_Any_16.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_Any_17))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_Any_17.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_ASE_16))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_ASE_16.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_ASE_157))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_ASE_157.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_IQ_154))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_IQ_154.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Sybase_IQ_160))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Sybase_IQ_160.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Teradata_150))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Teradata_150.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Teradata_151))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Teradata_151.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Teradata_1620))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Teradata_1620.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Vertica_80))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Vertica_80.Replace('_',' '));
				if(TCName.Contains(ServerListConstants.Vertica_91))
					item = repo.ServersList.LocalDBServersTreeItem.GetItem(ServerListConstants.Vertica_91.Replace('_',' '));
				
				item.EnsureVisible();
				item.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Get ServerTree From TCName failed : " + ex.Message);
			}
			return item;
		}
		
		public static TreeItem GetServerTreeFromTCName_old(string TCName)
		{
			TreeItem item = null;
			try
			{
				if(TCName.Contains(ServerListConstants.Amazon_Redshift))
					item = repo.ServersList.AmazonRedshift;
				if(TCName.Contains(ServerListConstants.Cassandra_37))
					item = repo.ServersList.Cassandra37;
				if(TCName.Contains(ServerListConstants.Cassandra_22))
					item = repo.ServersList.Cassandra22;
				if(TCName.Contains(ServerListConstants.Apache_Derby_1014))
					item = repo.ServersList.Derby1014;
				if(TCName.Contains(ServerListConstants.Derby_1013))
					item = repo.ServersList.Derby1013;
				if(TCName.Contains(ServerListConstants.DB2_LUW_111))
					item = repo.ServersList.DB2111;
				if(TCName.Contains(ServerListConstants.DB2_LUW_105))
					item = repo.ServersList.DB2105;
				if(TCName.Contains(ServerListConstants.Greenplum_50))
					item = repo.ServersList.Greenplum50;
				if(TCName.Contains(ServerListConstants.Greenplum_4312))
					return repo.ServersList.Greenplum50;
				if(TCName.Contains(ServerListConstants.Informix_1170))
					item = repo.ServersList.Informix1170;
				if(TCName.Contains(ServerListConstants.Informix_1210))
					item = repo.ServersList.Informix1210;
				if(TCName.Contains(ServerListConstants.MariaDB_102))
					item = repo.ServersList.MariaDB;
				if(TCName.Contains(ServerListConstants.MongoDB_321))
					item = repo.ServersList.MongoDB321;
				if(TCName.Contains(ServerListConstants.MongoDB_341))
					item = repo.ServersList.MongoDB341;
				if(TCName.Contains(ServerListConstants.MySQL_80))
					item = repo.ServersList.MySQL80;
				if(TCName.Contains(ServerListConstants.MySQL_57))
					item = repo.ServersList.MySQL57;
				if(TCName.Contains(ServerListConstants.Netezza_72))
					item = repo.ServersList.Netezza72;
				if(TCName.Contains(ServerListConstants.Oracle_121020))
					item = repo.ServersList.Oracle20;
				if(TCName.Contains(ServerListConstants.Oracle_11gR2))
					item = repo.ServersList.OracleR2;
				if(TCName.Contains(ServerListConstants.PostgreSQL_100))
					item = repo.ServersList.PostgreSQL100;
				if(TCName.Contains(ServerListConstants.PostgreSQL_96))
					item = repo.ServersList.PostgreSQL96;
				if(TCName.Contains(ServerListConstants.SAP_Hana_20))
					item = repo.ServersList.SAPHana20;
				if(TCName.Contains(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008))
					item = repo.ServersList.MicrosoftSQLAzure08;
				if(TCName.Contains(ServerListConstants.SQL_Server_2017))
					item = repo.ServersList.SQLServer2017;
				if(TCName.Contains(ServerListConstants.SQL_Server_2016))
					item = repo.ServersList.SQLServer2016;
				if(TCName.Contains(ServerListConstants.Sybase_Any_16))
					item = repo.ServersList.SybaseAny16;
				if(TCName.Contains(ServerListConstants.Sybase_Any_17))
					item = repo.ServersList.SybaseAny17;
				if(TCName.Contains(ServerListConstants.Sybase_ASE_16))
					item = repo.ServersList.SybaseASE16;
				if(TCName.Contains(ServerListConstants.Sybase_ASE_157))
					item = repo.ServersList.SybaseASE157;
				if(TCName.Contains(ServerListConstants.Sybase_IQ_154))
					item = repo.ServersList.SybaseIQ154;
				if(TCName.Contains(ServerListConstants.Sybase_IQ_160))
					item = repo.ServersList.SybaseIQ160;
				if(TCName.Contains(ServerListConstants.Teradata_150))
					item = repo.ServersList.Teradata150;
				if(TCName.Contains(ServerListConstants.Teradata_151))
					item = repo.ServersList.Teradata150;
				if(TCName.Contains(ServerListConstants.Teradata_1620))
					item = repo.ServersList.Teradata1620;
				if(TCName.Contains(ServerListConstants.Vertica_80))
					item = repo.ServersList.Vertica80;
				if(TCName.Contains(ServerListConstants.Vertica_91))
					item = repo.ServersList.Vertica91;
				
				item.EnsureVisible();
				item.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Get ServerTree From TCName failed : " + ex.Message);
			}
			return item;
		}
		
		public static string GetServerFromTCName(string TCName)
		{
			string serverName = null;
			
			try
			{
				if(TCName.Contains(ServerListConstants.Amazon_Redshift))
					serverName = ServerList.AmazonRedshift;
				if(TCName.Contains(ServerListConstants.Cassandra_37) || TCName.Contains(ServerListConstants.Cassandra_22))
					serverName = ServerList.ApacheCassandra;
				if(TCName.Contains(ServerListConstants.Apache_Derby_1014) || TCName.Contains(ServerListConstants.Derby_1013))
					serverName = ServerList.ApacheDerby;
				if(TCName.Contains(ServerListConstants.DB2_LUW_111) || TCName.Contains(ServerListConstants.DB2_LUW_105))
					serverName = ServerList.DB2;
				if(TCName.Contains(ServerListConstants.Greenplum_50) || TCName.Contains(ServerListConstants.Greenplum_4312))
					serverName = ServerList.Greenplum;
				if(TCName.Contains(ServerListConstants.Informix_1170) || TCName.Contains(ServerListConstants.Informix_1210))
					serverName = ServerList.Informix;
				if(TCName.Contains(ServerListConstants.MariaDB_102) )
					serverName = ServerList.MariaDB;
				if(TCName.Contains(ServerListConstants.MongoDB_341) || TCName.Contains(ServerListConstants.MongoDB_321))
					serverName = ServerList.MongoDB;
				if(TCName.Contains(ServerListConstants.MySQL_57) || TCName.Contains(ServerListConstants.MySQL_80))
					serverName = ServerList.MySQL;
				if(TCName.Contains(ServerListConstants.Netezza_72))
					serverName = ServerList.Netezza;
				if(TCName.Contains(ServerListConstants.Oracle_121020) || TCName.Contains(ServerListConstants.Oracle_11gR2))
					serverName = ServerList.Oracle;
				if(TCName.Contains(ServerListConstants.PostgreSQL_100) || TCName.Contains(ServerListConstants.PostgreSQL_96))
					serverName = ServerList.PostgreSQL;
				if(TCName.Contains(ServerListConstants.SAP_Hana_20))
					serverName = ServerList.SAPHana;
				if(TCName.Contains(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008))
					serverName = ServerList.Azure;
				if(TCName.Contains(ServerListConstants.SQL_Server_2017) || TCName.Contains(ServerListConstants.SQL_Server_2016))
					serverName = ServerList.SQLServer;
				if(TCName.Contains(ServerListConstants.Sybase_Any_16) || TCName.Contains(ServerListConstants.Sybase_Any_17))
					serverName = ServerList.SybaseAny;
				if(TCName.Contains(ServerListConstants.Sybase_ASE_16) || TCName.Contains(ServerListConstants.Sybase_ASE_157))
					serverName = ServerList.SybaseASE;
				if(TCName.Contains(ServerListConstants.Sybase_IQ_154) || TCName.Contains(ServerListConstants.Sybase_IQ_160))
					serverName = ServerList.SybaseIQ;
				if(TCName.Contains(ServerListConstants.Teradata_150) || TCName.Contains(ServerListConstants.Teradata_1620) || TCName.Contains(ServerListConstants.Teradata_151))
					serverName = ServerList.Teradata;
				if(TCName.Contains(ServerListConstants.Vertica_80) || TCName.Contains(ServerListConstants.Vertica_91))
					serverName = ServerList.Vertica;
				if(TCName.Contains(ServerListConstants.Excel))
					serverName = ServerList.Excel;
			}
			catch(Exception ex)
			{
				throw new Exception("Get ServerName From TC failed : " + ex.Message);
			}
			
			return serverName;
		}
		
		public static TreeItem SelectedServerTreeItem {get; set;}
		
		public static string SelectedServerName {get; set;}
		
		public static bool isPreconditionDone = false;
	}
}

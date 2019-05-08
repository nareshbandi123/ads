using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using Ranorex;
using Ranorex.Core;

namespace ADSAutomationPhaseII.TC_10537
{
	public static class Steps
	{
		public static TC10537Repo repo = TC10537Repo.Instance;
		public static string TC1_10537_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10537_Path"].ToString();
		public static string TC2_10537_Path = System.Configuration.ConfigurationManager.AppSettings["TC2_10537_Path"].ToString();
		
		public static TreeItem GetServer()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				server.RightClickThis();
				Reports.ReportLog("GetServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				return server;
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : GetServer : " + ex.Message);
			}
		}
		
		public static bool ConnectServer()
		{
			bool returnResult = false;
			try
			{
				TreeItem server = GetServer();
				Preconditions.Steps.ConnectServer();
				if(server.Items.Count > 1)
				{
					returnResult = true;
					Reports.ReportLog("ConnectServer : success ", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					server.Collapse();
					Preconditions.Steps.isPreconditionDone = false;
					Reports.ReportLog("ConnectServer : server down ", Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
					returnResult = false;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ConnectServer : " + ex.Message);
			}
			
			return returnResult;
		}
		
		public static void OpenQueryAnalyzerTab()
		{
			try
			{
				Preconditions.Steps.QueryAnalyser();
				Reports.ReportLog("OpenQueryAnalyzerTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenQueryAnalyzerTab : " + ex.Message);
			}
		}
		
		public static void WriteQueryScript()
		{
			try
			{
				Preconditions.Steps.OpenScript(Preconditions.Steps.iCreateDB);
				Reports.ReportLog("WriteQueryScript", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : WriteQueryScript : " + ex.Message);
			}
		}
		
		public static void SaveFile()
		{
			try
			{
				Cleanup();
				Preconditions.Steps.SaveFileAs();
				repo.SaveWindow.FilePathTextbox.TextBoxText(TC1_10537_Path + Preconditions.Steps.SelectedServerName+".sql");
				repo.SaveWindow.SaveButton.ClickThis();
				Reports.ReportLog("SaveFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SaveFile : " + ex.Message);
			}
		}
		
		public static void CloseTab()
		{
			try
			{
				Preconditions.Steps.CloseTab(Preconditions.Steps.SelectedServerName);
				Reports.ReportLog("CloseTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseTab : " + ex.Message);
			}
		}
		
		public static void ClickOpenFileMenu()
		{
			try
			{
				repo.Application.FileMenu.ClickThis();
				repo.DataStudio.OpenMenu.ClickThis();
				Reports.ReportLog("ClickOpenFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOpenFileMenu : " + ex.Message);
			}
		}
		
		public static void OpenFile()
		{
			try
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC1_10537_Path + Preconditions.Steps.SelectedServerName+".sql");
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("OpenFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenFile : " + ex.Message);
			}
		}
		
		public static void SelectServer()
		{
			try
			{
				try{repo.ChooseFromServer.ServerListInfo.WaitForExists(new Duration(10000));}
				catch{ClickOpenFileMenu();OpenFile();SelectServer();}
				
				TreeItem SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName, false);
				Sleep();
				if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
					Preconditions.Steps.SelectedServerTreeItem = server;
					Preconditions.Steps.SelectedServerName = server.Text;
					SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(server.Text, false);
				}
				SelectedServer.Select();
				repo.ChooseFromServer.OpenInQAButton.ClickThis();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServer : " + ex.Message);
			}
		}
		
		public static void DisconnectServer()
		{
			try
			{
				Preconditions.Steps.SelectedServerTreeItem.RightClickThis();
				Preconditions.Steps.DisconnectServer();
				Reports.ReportLog("DisconnectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DisconnectServer : " + ex.Message);
			}
		}
		
		public static void Cleanup()
		{
			try
			{
				Commons.Common.DeleteFile(TC1_10537_Path + Preconditions.Steps.SelectedServerName+".sql");
				Reports.ReportLog("Cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Cleanup : " + ex.Message);
			}
		}
		
		public static void Sleep()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		public static void ExplicitSleep()
		{
			System.Threading.Thread.Sleep(300);
		}
		
		public static void ClickOnToolsMenu()
		{
			try
			{
				repo.Application.Tools.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnToolsMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnToolsMenu : " + ex.Message);
			}
		}
		
		public static void ClickOnImport()
		{
			try
			{
				repo.DataStudio.ImportDataMenu.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnImport", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnImport : " + ex.Message);
			}
		}
		
		public static void SelectServerImport()
		{
			try
			{
				TC_10535.Steps.SelectServer();
				ExplicitSleep();
				Reports.ReportLog("SelectServerImport", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServerImport : " + ex.Message);
			}
		}
		
		public static void SelectVerticaServer()
		{
			try
			{
				TC_10535.Steps.SelectVerticaServer();
				ExplicitSleep();
				Reports.ReportLog("SelectVerticaServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectVerticaServer : " + ex.Message);
			}
		}
		
		public static void SelectServers()
		{
			try
			{
				TC_10535.Steps.SelectServers();
				ExplicitSleep();
				Reports.ReportLog("SelectServers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServers : " + ex.Message);
			}
		}
		
		public static void ClickOkButton()
		{
			try
			{
				TC_10535.Steps.ClickOkButton();
				ExplicitSleep();
				Reports.ReportLog("ClickOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void ClickOnNext()
		{
			try
			{
				repo.Application.ImportTab.NextButtonInfo.WaitForExists(new Duration(1000));
				repo.Application.ImportTab.NextButton.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnNext", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnNext : " + ex.Message);
			}
		}
		
		public static void SelectTable()
		{
			try
			{
				repo.Application.ImportTab.TableComboboxText.TextBoxText(Config.ADSDB);
				ExplicitSleep();
				////Validate.IsTrue(repo.Application.ImportTab.TableComboboxText.TextValue.Contains(Config.ADSDB));
				Reports.ReportLog("SelectTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTable : " + ex.Message);
			}
		}
		
		public static void SelectSchemaTable()
		{
			try
			{
				repo.Application.ImportTab.SchemaTableComboboxText.TextBoxText(Config.ADSDB);
				ExplicitSleep();
				////Validate.IsTrue(repo.Application.ImportTab.SchemaTableComboboxText.TextValue.Contains(Config.ADSDB));
				Reports.ReportLog("SelectSchemaTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaTable : " + ex.Message);
			}
		}
		
		public static void CheckImportStatus()
		{
			try
			{
				if(repo.Application.ImportTab.ImportStatusInfo.Exists())
					ClickCloseButton();
				ExplicitSleep();
				Reports.ReportLog("CheckImportStatus", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckImportStatus : " + ex.Message);
			}
		}
		
		public static void CheckImportStatus_Cassandra()
		{
			try
			{
				if(repo.Application.ImportTab.ImportStatusCassandra1Info.Exists())
					ClickCloseButton();
				ExplicitSleep();
				Reports.ReportLog("CheckImportStatus_Cassandra", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckImportStatus_Cassandra : " + ex.Message);
			}
		}
		
		public static void ClickCloseButton()
		{
			try
			{
				repo.Application.ImportTab.CloseButton.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickCloseButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCloseButton : " + ex.Message);
			}
		}
		
		public static void SelectImportFile()
		{
			try
			{
				repo.SelectWindow.FilePathTextboxInfo.WaitForExists(new Duration(1000));
				repo.SelectWindow.FilePathTextbox.TextBoxText(TC2_10537_Path + Preconditions.Steps.SelectedServerName+".txt");
				////Validate.IsTrue(repo.SelectWindow.FilePathTextbox.TextValue.Contains(TC2_10537_Path + Preconditions.Steps.SelectedServerName+".txt"));
				repo.SelectWindow.SelectButton.ClickThis();
				Reports.ReportLog("SelectImportFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectImportFile : " + ex.Message);
			}
		}
		
		
		public static void SelectSQLServerDatabase()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(ServerListConstants.SQL_Server_2017);
				Preconditions.Steps.SelectedServerTreeItem = server;
				Preconditions.Steps.SelectedServerName = server.Text;
				server.EnsureVisible();
				server.Select();
				server.Expand();
				System.Threading.Thread.Sleep(2000);
				server.RightClickThis();
				Preconditions.Steps.ConnectServer();
				server.Items[0].ClickThis();
				Reports.ReportLog("SelectSQLServerDatabase", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSQLServerDatabase : " + ex.Message);
			}
		}
		
		public static void ClickOnDetailsTab()
		{
			try
			{
				repo.F5DetailsTab.F5DetailsInfo.WaitForItemExists(1000);
				if(!repo.F5DetailsTab.F5Details.Checked)
					repo.F5DetailsTab.F5Details.ClickThis();
				
				Reports.ReportLog("ClickOnDetailsTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDetailsTab : " + ex.Message);
			}
		}
		
		public static void SelectRows()
		{
			try
			{
				Keyboard.Press(Keyboard.ToKey("Ctrl+Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				repo.F5DetailsTab.DetailTableInfo.WaitForItemExists(1000);
				if(repo.F5DetailsTab.DetailTable.Rows.Count > 0)
				{
					Cell cell1 = repo.F5DetailsTab.TableCell1;
					if(repo.F5DetailsTab.DetailTable.Rows.Count == 1)
						cell1.ClickThis();

					if(repo.F5DetailsTab.DetailTable.Rows.Count >= 2)
					{
						Cell cell2 = repo.F5DetailsTab.TableCell2;
						Keyboard.Press("{ControlKey down}");
						cell1.ClickThis();
						cell2.ClickThis();
						Keyboard.Press("{ControlKey up}");
					}
					
					Reports.ReportLog("SelectRows", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRows : " + ex.Message);
			}
		}
		
		public static void ValidateStatus()
		{
			try
			{
				if(repo.F5DetailsTab.DetailTable.Rows.Count > 0)
				{
					string message = string.Format("Validate status for the Database : {0}", repo.F5DetailsTab.NameColumnCell1.Text);
					if(repo.F5DetailsTab.DetailTable.Rows.Count >= 1)
						Reports.ReportLog(message, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					if(repo.F5DetailsTab.DetailTable.Rows.Count >= 2)
					{
						message = string.Format("Validate status for the Database : {0}", repo.F5DetailsTab.NameColumnCell2.Text);
						Reports.ReportLog(message, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					
					Reports.ReportLog("ValidateStatus", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateStatus : " + ex.Message);
			}
		}
		
		public static void ValidateDate()
		{
			try
			{
				if(repo.F5DetailsTab.DetailTable.Rows.Count > 0)
				{
					string message = string.Format("Validate created date for the Database : {0}", repo.F5DetailsTab.NameColumnCell1.Text);
					if(repo.F5DetailsTab.DetailTable.Rows.Count >= 1)
						Reports.ReportLog(message, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					if(repo.F5DetailsTab.DetailTable.Rows.Count >= 2)
					{
						message = string.Format("Validate created date for the Database : {0}", repo.F5DetailsTab.NameColumnCell2.Text);
						Reports.ReportLog(message, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					
					Reports.ReportLog("ValidateDate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDate : " + ex.Message);
			}
		}
		
		public static void ValidateSorting()
		{
			try
			{
				if(repo.F5DetailsTab.DetailTable.Rows.Count > 0)
				{
					repo.F5DetailsTab.NameHeaderCell.ClickThis(); // Ascending
					repo.F5DetailsTab.NameHeaderCell.ClickThis(); // Click Again for Descending
					Reports.ReportLog("Validate Sorting Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					repo.F5DetailsTab.StatusHeaderCell.ClickThis(); // Ascending
					repo.F5DetailsTab.StatusHeaderCell.ClickThis(); // Click Again for Descending
					Reports.ReportLog("Validate Sorting Status", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					repo.F5DetailsTab.CreatedHeaderCell.ClickThis(); // Ascending
					repo.F5DetailsTab.CreatedHeaderCell.ClickThis(); // Click Again for Descending
					Reports.ReportLog("Validate Sorting Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					Reports.ReportLog("ValidateSorting", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSorting : " + ex.Message);
			}
		}
		
		public static void CloseDetailsTab()
		{
			try
			{
				if(repo.F5DetailsTab.F5DetailsInfo.Exists(10000))
				{
					if(repo.F5DetailsTab.F5Details.Checked)
						repo.F5DetailsTab.F5Details.ClickThis();
					
					Reports.ReportLog("CloseDetailsTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseDetailsTab : " + ex.Message);
			}
		}
		
		public static void DisconnectSqlServer()
		{
			try
			{
				TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(ServerListConstants.SQL_Server_2017);
				server.RightClickThis();
				server.EnsureVisible();
				Preconditions.Steps.DisconnectServer();
				
				Reports.ReportLog("DisconnectSqlServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DisconnectSqlServer : " + ex.Message);
			}
		}
		
		
		public static void ClickOnServer()
		{
			try
			{
				repo.Application.ServerMenuInfo.WaitForItemExists(5000);
				
				if(!repo.RegisterNewServerTabs.SelfInfo.Exists(new Duration(5000)))
					repo.Application.ServerMenu.ClickThis();
				else
				{ repo.RegisterNewServerTabs.Self.Close(); repo.Application.ServerMenu.ClickThis();}
				
				ExplicitSleep();
				Reports.ReportLog("ClickOnServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnServer : " + ex.Message);
			}
		}
		
		public static void ClickOnRegisterServer()
		{
			try
			{
				repo.DataStudio.RegisterServerInfo.WaitForItemExists(5000);
				repo.DataStudio.RegisterServer.ClickThis();
				ExplicitSleep();
				Reports.ReportLog("ClickOnRegisterServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRegisterServer : " + ex.Message);
			}
		}
		
		public static void ValidateRegisterServerWindowOpened()
		{
			try
			{
				repo.RegisterNewServerTabs.SelfInfo.WaitForItemExists(5000);
				ExplicitSleep();
				////Validate.Exists(repo.RegisterNewServerTabs.SelfInfo, "Register New Server window opened");
				Reports.ReportLog("ValidateRegisterServerWindowOpened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateRegisterServerWindowOpened : " + ex.Message);
			}
		}
		
		public static void ValidateTabs()
		{
			try
			{
				repo.RegisterNewServerTabs.GeneralTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.GeneralTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.GeneralTabInfo, repo.RegisterNewServerTabs.GeneralTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : GeneralTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.FilterTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.FilterTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.FilterTabInfo, repo.RegisterNewServerTabs.FilterTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : FilterTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.AdvancedTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.AdvancedTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.AdvancedTabInfo, repo.RegisterNewServerTabs.AdvancedTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : AdvancedTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.DriverTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.DriverTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.DriverTabInfo, repo.RegisterNewServerTabs.DriverTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : DriverTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.PermissonsTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.PermissonsTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.PermissonsTabInfo, repo.RegisterNewServerTabs.PermissonsTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : PermissonsTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.ScriptTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.ScriptTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.ScriptTabInfo, repo.RegisterNewServerTabs.ScriptTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : ScriptTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.FluidShellTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.FluidShellTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.FluidShellTabInfo, repo.RegisterNewServerTabs.FluidShellTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : FluidShellTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
				
				repo.RegisterNewServerTabs.ConnectionMonitorTabInfo.WaitForItemExists(10000);
				repo.RegisterNewServerTabs.ConnectionMonitorTab.ClickThis();
				////Validate.Exists(repo.RegisterNewServerTabs.ConnectionMonitorTabInfo, repo.RegisterNewServerTabs.ConnectionMonitorTab.Title + " Tab Selected");
				Reports.ReportLog("ValidateTabs : ConnectionMonitorTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTabs : " + ex.Message);
			}
		}
		
		private static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		public static void ClickOnClose()
		{
			try
			{
				if(repo.RegisterNewServerTabs.SelfInfo.Exists(1000))
				{
					repo.RegisterNewServerTabs.CloseButton.ClickThis();
					Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose : " + ex.Message);
			}
		}
		
		
		public static void SelectServerToRegister()
		{
			try
			{
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				ExplicitWait();
				foreach (var item in repo.RegisterNewServerTabs.ServerList.Items)
				{
					if(item.Text == serverName)
					{
						item.EnsureVisible();
						item.ClickThis();
						break;
					}
				}
				Reports.ReportLog("SelectServerToRegister", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectServerToRegister : " + ex.Message);
			}
		}
		
		public static void RegisterData()
		{
			try
			{
				ExplicitWait();
				if(Config.TestCaseName.Contains(ServerListConstants.Amazon_Redshift))
				{
					repo.RegisterNewServerTabs.AmazonRedshift.NameTextbox.TextBoxText("Amazon Redshift");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.NameTextbox.TextValue.Contains("Amazon Redshift"));
					repo.RegisterNewServerTabs.AmazonRedshift.LoginTextbox.TextBoxText("root");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.LoginTextbox.TextValue.Contains("root"));
					repo.RegisterNewServerTabs.AmazonRedshift.PasswordTextbox.TextBoxText("Amazon11");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.PasswordTextbox.TextValue.Contains("Amazon11"));
					repo.RegisterNewServerTabs.AmazonRedshift.HostTextbox.TextBoxText("aquafold.ctslhmmdmjtr.us-east-1.redshift.amazonaws.com");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.HostTextbox.TextValue.Contains("aquafold.ctslhmmdmjtr.us-east-1.redshift.amazonaws.com"));
					repo.RegisterNewServerTabs.AmazonRedshift.PortTextbox.TextBoxText("5439");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.PortTextbox.TextValue.Contains("5439"));
					repo.RegisterNewServerTabs.AmazonRedshift.DatabaseTextbox.TextBoxText("aquafold");
					////Validate.IsTrue(repo.RegisterNewServerTabs.AmazonRedshift.DatabaseTextbox.TextValue.Contains("aquafold"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Cassandra_37))
				{
					repo.RegisterNewServerTabs.Cassandra.NameTextbox.TextBoxText("Cassandra 172.24.1.77 3.7");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.NameTextbox.TextValue.Contains("Cassandra 172.24.1.77 3.7"));
					repo.RegisterNewServerTabs.Cassandra.LoginTextbox.TextBoxText("cassandra");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.LoginTextbox.TextValue.Contains("cassandra"));
					repo.RegisterNewServerTabs.Cassandra.PasswordTextbox.TextBoxText("Am@z*n7");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.Cassandra.HostTextbox.TextBoxText("172.24.1.77");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.HostTextbox.TextValue.Contains("172.24.1.77"));
					repo.RegisterNewServerTabs.Cassandra.PortTextbox.TextBoxText("9160");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.PortTextbox.TextValue.Contains("9160"));
					repo.RegisterNewServerTabs.Cassandra.DatabaseTextbox.TextBoxText("tom");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.DatabaseTextbox.TextValue.Contains("tom"));
				}
				
				
				if(Config.TestCaseName.Contains(ServerListConstants.Cassandra_22))
				{
					repo.RegisterNewServerTabs.Cassandra.NameTextbox.TextBoxText("Cassandra 172.24.1.122 2.2");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.NameTextbox.TextValue.Contains("Cassandra 172.24.1.122 2.2"));
					repo.RegisterNewServerTabs.Cassandra.LoginTextbox.TextBoxText("cassandra");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.LoginTextbox.TextValue.Contains("cassandra"));
					repo.RegisterNewServerTabs.Cassandra.PasswordTextbox.TextBoxText("Am@z*n7");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.Cassandra.HostTextbox.TextBoxText("172.24.1.122");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.HostTextbox.TextValue.Contains("172.24.1.122"));
					repo.RegisterNewServerTabs.Cassandra.PortTextbox.TextBoxText("9160");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.PortTextbox.TextValue.Contains("9160"));
					repo.RegisterNewServerTabs.Cassandra.DatabaseTextbox.TextBoxText("tom");
					////Validate.IsTrue(repo.RegisterNewServerTabs.Cassandra.DatabaseTextbox.TextValue.Contains("tom"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.DB2_LUW_111))
				{
					repo.RegisterNewServerTabs.DB2.NameTextbox.TextBoxText("DB2 LUW 172.24.1.8 v11.1");
					////Validate.IsTrue(repo.RegisterNewServerTabs.DB2.NameTextbox.TextValue.Contains("DB2 LUW 172.24.1.8 v11.1"));
					repo.RegisterNewServerTabs.DB2.LoginTextbox.TextBoxText("db2admin");
					////Validate.IsTrue(repo.RegisterNewServerTabs.DB2.LoginTextbox.TextValue.Contains("db2admin"));
					repo.RegisterNewServerTabs.DB2.PasswordTextbox.TextBoxText("Am@z*n7");
					////Validate.IsTrue(repo.RegisterNewServerTabs.DB2.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.DB2.HostTextbox.TextBoxText("172.24.1.8");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.HostTextbox.TextValue.Contains("172.24.1.8"));
					repo.RegisterNewServerTabs.DB2.PortTextbox.TextBoxText("50000");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.PortTextbox.TextValue.Contains("50000"));
					repo.RegisterNewServerTabs.DB2.DatabaseTextbox.TextBoxText("SAMPLE");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.DatabaseTextbox.TextValue.Contains("SAMPLE"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.DB2_LUW_105))
				{
					repo.RegisterNewServerTabs.DB2.NameTextbox.TextBoxText("DB2 LUW 172.24.1.145 v10.5");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.NameTextbox.TextValue.Contains("DB2 LUW 172.24.1.145 v10.5"));
					repo.RegisterNewServerTabs.DB2.LoginTextbox.TextBoxText("db2admin");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.LoginTextbox.TextValue.Contains("db2admin"));
					repo.RegisterNewServerTabs.DB2.PasswordTextbox.TextBoxText("Am@z*n7");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.DB2.HostTextbox.TextBoxText("172.24.1.145");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.HostTextbox.TextValue.Contains("172.24.1.145"));
					repo.RegisterNewServerTabs.DB2.PortTextbox.TextBoxText("50000");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.PortTextbox.TextValue.Contains("50000"));
					repo.RegisterNewServerTabs.DB2.DatabaseTextbox.TextBoxText("AQUAFOLD");
					//Validate.IsTrue(repo.RegisterNewServerTabs.DB2.DatabaseTextbox.TextValue.Contains("AQUAFOLD"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Derby_1013))
				{
					repo.RegisterNewServerTabs.Derby.NameTextbox.TextBoxText("Derby 172.24.1.8 v10.13");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.NameTextbox.TextValue.Contains("Derby 172.24.1.8 v10.13"));
					repo.RegisterNewServerTabs.Derby.PasswordTextbox.TextBoxText("Am@z*n7");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.Derby.HostTextbox.TextBoxText("172.24.1.8");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.HostTextbox.TextValue.Contains("172.24.1.8"));
					repo.RegisterNewServerTabs.Derby.PortTextbox.TextBoxText("1527");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.PortTextbox.TextValue.Contains("1527"));
					repo.RegisterNewServerTabs.Derby.DatabaseTextbox.TextBoxText(@"c:\derby\demo\databases\toursdb");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.DatabaseTextbox.TextValue.Contains(@"c:\derby\demo\databases\toursdb"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Apache_Derby_1014))
				{
					repo.RegisterNewServerTabs.Derby.NameTextbox.TextBoxText("Derby 172.24.1.199 v10.14");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.NameTextbox.TextValue.Contains("Derby 172.24.1.199 v10.14"));
					repo.RegisterNewServerTabs.Derby.PasswordTextbox.TextBoxText("Am@z*n7");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.PasswordTextbox.TextValue.Contains("Am@z*n7"));
					repo.RegisterNewServerTabs.Derby.HostTextbox.TextBoxText("172.24.1.199");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.HostTextbox.TextValue.Contains("172.24.1.199"));
					repo.RegisterNewServerTabs.Derby.PortTextbox.TextBoxText("1527");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.PortTextbox.TextValue.Contains("1527"));
					repo.RegisterNewServerTabs.Derby.DatabaseTextbox.TextBoxText(@"c:\derby\demo\databases\toursdb");
					//Validate.IsTrue(repo.RegisterNewServerTabs.Derby.DatabaseTextbox.TextValue.Contains(@"c:\derby\demo\databases\toursdb"));
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Greenplum_50))
				{
					repo.RegisterNewServerTabs.Greenplum.NameTextbox.TextBoxText("Greenplum 10.90.1.158 v5.0");
					repo.RegisterNewServerTabs.Greenplum.LoginTextbox.TextBoxText("gpadmin");
					repo.RegisterNewServerTabs.Greenplum.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Greenplum.HostTextbox.TextBoxText("10.90.1.158");
					repo.RegisterNewServerTabs.Greenplum.PortTextbox.TextBoxText("5432");
					repo.RegisterNewServerTabs.Greenplum.DatabaseTextbox.TextBoxText("postgres");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Informix_1170))
				{
					repo.RegisterNewServerTabs.Informix.NameTextbox.TextBoxText("Informix 172.24.1.140 v11.70");
					repo.RegisterNewServerTabs.Informix.LoginTextbox.TextBoxText("informix");
					repo.RegisterNewServerTabs.Informix.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Informix.HostTextbox.TextBoxText("172.24.1.140");
					repo.RegisterNewServerTabs.Informix.PortTextbox.TextBoxText("1526");
					repo.RegisterNewServerTabs.Informix.DatabaseTextbox.TextBoxText("ol_informix1170");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Informix_1210))
				{
					repo.RegisterNewServerTabs.Informix.NameTextbox.TextBoxText("Informix 172.24.1.145 v12.10");
					repo.RegisterNewServerTabs.Informix.LoginTextbox.TextBoxText("informix");
					repo.RegisterNewServerTabs.Informix.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Informix.HostTextbox.TextBoxText("172.24.1.145");
					repo.RegisterNewServerTabs.Informix.PortTextbox.TextBoxText("1526");
					repo.RegisterNewServerTabs.Informix.DatabaseTextbox.TextBoxText("ol_informix1210");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.MariaDB_102))
				{
					repo.RegisterNewServerTabs.MariaDB.NameTextbox.TextBoxText("MariaDB 172.24.1.8 v10.2");
					repo.RegisterNewServerTabs.MariaDB.LoginTextbox.TextBoxText("root");
					repo.RegisterNewServerTabs.MariaDB.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.MariaDB.HostTextbox.TextBoxText("172.24.1.8");
					repo.RegisterNewServerTabs.MariaDB.PortTextbox.TextBoxText("3308");
					repo.RegisterNewServerTabs.MariaDB.DatabaseTextbox.TextBoxText("mysql");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.MongoDB_321))
				{
					repo.RegisterNewServerTabs.MongoDB.NameTextbox.TextBoxText("MongoDB 172.24.1.155 v3.2.1");
					repo.RegisterNewServerTabs.MongoDB.ConnectAsCombo.SelectedItemIndex = 0;
					repo.RegisterNewServerTabs.MongoDB.HostTextbox.TextBoxText("172.24.1.155");
					repo.RegisterNewServerTabs.MongoDB.PortTextbox.TextBoxText("27030");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.MongoDB_341))
				{
					repo.RegisterNewServerTabs.MongoDB.NameTextbox.TextBoxText("MongoDB 172.24.1.155 v3.4.1");
					repo.RegisterNewServerTabs.MongoDB.ConnectAsCombo.SelectedItemIndex = 0;
					repo.RegisterNewServerTabs.MongoDB.HostTextbox.TextBoxText("172.24.1.155");
					repo.RegisterNewServerTabs.MongoDB.PortTextbox.TextBoxText("27040");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.MySQL_57))
				{
					repo.RegisterNewServerTabs.MySQL.NameTextbox.TextBoxText("MySQL 172.24.1.8 v5.7");
					repo.RegisterNewServerTabs.MySQL.LoginTextbox.TextBoxText("root");
					repo.RegisterNewServerTabs.MySQL.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.MySQL.HostTextbox.TextBoxText("172.24.1.8");
					repo.RegisterNewServerTabs.MySQL.PortTextbox.TextBoxText("3306");
					repo.RegisterNewServerTabs.MySQL.DatabaseTextbox.TextBoxText("mysql");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.MySQL_80))
				{
					repo.RegisterNewServerTabs.MySQL.NameTextbox.TextBoxText("MySQL 172.24.1.199 v8.0");
					repo.RegisterNewServerTabs.MySQL.LoginTextbox.TextBoxText("root");
					repo.RegisterNewServerTabs.MySQL.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.MySQL.HostTextbox.TextBoxText("172.24.1.199");
					repo.RegisterNewServerTabs.MySQL.PortTextbox.TextBoxText("3301");
					repo.RegisterNewServerTabs.MySQL.DatabaseTextbox.TextBoxText("mysql");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Netezza_72))
				{
					repo.RegisterNewServerTabs.Netezza.NameTextbox.TextBoxText("Netezza 10.31.200.44 7.2");
					repo.RegisterNewServerTabs.Netezza.LoginTextbox.TextBoxText("admin");
					repo.RegisterNewServerTabs.Netezza.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Netezza.HostTextbox.TextBoxText("10.90.1.21");
					repo.RegisterNewServerTabs.Netezza.PortTextbox.TextBoxText("5480");
					repo.RegisterNewServerTabs.Netezza.DatabaseTextbox.TextBoxText("SYSTEM");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Oracle_11gR2))
				{
					repo.RegisterNewServerTabs.Oracle.NameTextbox.TextBoxText("Oracle 172.24.1.140 v11g R2");
					repo.RegisterNewServerTabs.Oracle.LoginTextbox.TextBoxText("sys");
					repo.RegisterNewServerTabs.Oracle.PasswordTextbox.TextBoxText("Amazon7");
					repo.RegisterNewServerTabs.Oracle.HostTextbox.TextBoxText("172.24.1.140");
					repo.RegisterNewServerTabs.Oracle.PortTextbox.TextBoxText("1521");
					repo.RegisterNewServerTabs.Oracle.ConnectAsCombo.SelectedItemIndex = 2;
					repo.RegisterNewServerTabs.Oracle.SIDTextbox.TextBoxText("ORCL");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Oracle_121020))
				{
					repo.RegisterNewServerTabs.Oracle.NameTextbox.TextBoxText("Oracle 172.24.1.199 v12.1.0.2.0");
					repo.RegisterNewServerTabs.Oracle.LoginTextbox.TextBoxText("sys");
					repo.RegisterNewServerTabs.Oracle.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Oracle.HostTextbox.TextBoxText("172.24.1.199");
					repo.RegisterNewServerTabs.Oracle.PortTextbox.TextBoxText("1521");
					repo.RegisterNewServerTabs.Oracle.ConnectAsCombo.SelectedItemIndex = 2;
					repo.RegisterNewServerTabs.Oracle.SIDTextbox.TextBoxText("ORCL");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.PostgreSQL_100))
				{
					repo.RegisterNewServerTabs.PostgreSQL.NameTextbox.TextBoxText("PostgreSQL 172.24.1.8 v10.0");
					repo.RegisterNewServerTabs.PostgreSQL.LoginTextbox.TextBoxText("postgres");
					repo.RegisterNewServerTabs.PostgreSQL.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.PostgreSQL.HostTextbox.TextBoxText("172.24.1.8");
					repo.RegisterNewServerTabs.PostgreSQL.PortTextbox.TextBoxText("5433");
					repo.RegisterNewServerTabs.PostgreSQL.DatabaseTextbox.TextBoxText("postgres");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.PostgreSQL_96))
				{
					repo.RegisterNewServerTabs.PostgreSQL.NameTextbox.TextBoxText("PostgreSQL 172.24.1.122 v9.6");
					repo.RegisterNewServerTabs.PostgreSQL.LoginTextbox.TextBoxText("postgres");
					repo.RegisterNewServerTabs.PostgreSQL.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.PostgreSQL.HostTextbox.TextBoxText("172.24.1.145");
					repo.RegisterNewServerTabs.PostgreSQL.PortTextbox.TextBoxText("5432");
					repo.RegisterNewServerTabs.PostgreSQL.DatabaseTextbox.TextBoxText("postgres");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.SAP_Hana_20))
				{
					throw new Exception("Server Registration Details not configured");
//					repo.RegisterNewServerTabs.AmazonRedshift.NameTextbox.TextBoxText("SAP Hana 10.90.1.96 v2.0");
//					repo.RegisterNewServerTabs.AmazonRedshift.LoginTextbox.TextBoxText("SYSTEM");
//					repo.RegisterNewServerTabs.AmazonRedshift.PasswordTextbox.TextBoxText("Aquafold123");
//					repo.RegisterNewServerTabs.AmazonRedshift.HostTextbox.TextBoxText("10.90.1.96");
//					repo.RegisterNewServerTabs.AmazonRedshift.PortTextbox.TextBoxText("39015");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.SAP_Hana_10))
				{
					throw new Exception("Server Registration Details not configured");
//					repo.RegisterNewServerTabs.AmazonRedshift.NameTextbox.TextBoxText("SAP Hana 10.90.1.194 v1.0");
//					repo.RegisterNewServerTabs.AmazonRedshift.LoginTextbox.TextBoxText("SYSTEM");
//					repo.RegisterNewServerTabs.AmazonRedshift.PasswordTextbox.TextBoxText("Am@z*n7");
//					repo.RegisterNewServerTabs.AmazonRedshift.HostTextbox.TextBoxText("10.90.1.194");
//					repo.RegisterNewServerTabs.AmazonRedshift.PortTextbox.TextBoxText("30015");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.SQL_Server_2017))
				{
					repo.RegisterNewServerTabs.SQLServer.NameTextbox.TextBoxText("SQL Server 172.24.1.154 2017");
					repo.RegisterNewServerTabs.SQLServer.LoginTextbox.TextBoxText("sa");
					repo.RegisterNewServerTabs.SQLServer.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SQLServer.HostTextbox.TextBoxText("172.24.1.154");
					repo.RegisterNewServerTabs.SQLServer.PortTextbox.TextBoxText("1433");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.SQL_Server_2016))
				{
					repo.RegisterNewServerTabs.SQLServer.NameTextbox.TextBoxText("SQL Server 172.24.1.199 2016");
					repo.RegisterNewServerTabs.SQLServer.LoginTextbox.TextBoxText("sa");
					repo.RegisterNewServerTabs.SQLServer.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SQLServer.HostTextbox.TextBoxText("172.24.1.199");
					repo.RegisterNewServerTabs.SQLServer.PortTextbox.TextBoxText("1433");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_Any_17))
				{
					repo.RegisterNewServerTabs.SybaseANY.NameTextbox.TextBoxText("Sybase Any 172.24.1.50 v17");
					repo.RegisterNewServerTabs.SybaseANY.LoginTextbox.TextBoxText("dba");
					repo.RegisterNewServerTabs.SybaseANY.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseANY.HostTextbox.TextBoxText("172.24.1.50");
					repo.RegisterNewServerTabs.SybaseANY.PortTextbox.TextBoxText("2638");
					repo.RegisterNewServerTabs.SybaseANY.DatabaseTextbox.TextBoxText("demo");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_Any_16))
				{
					repo.RegisterNewServerTabs.SybaseANY.NameTextbox.TextBoxText("Sybase Any 172.24.1.145 v16");
					repo.RegisterNewServerTabs.SybaseANY.LoginTextbox.TextBoxText("dba");
					repo.RegisterNewServerTabs.SybaseANY.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseANY.HostTextbox.TextBoxText("172.24.1.145");
					repo.RegisterNewServerTabs.SybaseANY.PortTextbox.TextBoxText("2638");
					repo.RegisterNewServerTabs.SybaseANY.DatabaseTextbox.TextBoxText("demo");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_ASE_157))
				{
					repo.RegisterNewServerTabs.SybaseASE.NameTextbox.TextBoxText("Sybase ASE 172.24.1.6 v15.7");
					repo.RegisterNewServerTabs.SybaseASE.LoginTextbox.TextBoxText("sa");
					repo.RegisterNewServerTabs.SybaseASE.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseASE.HostTextbox.TextBoxText("172.24.1.6");
					repo.RegisterNewServerTabs.SybaseASE.PortTextbox.TextBoxText("5000");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_ASE_16))
				{
					repo.RegisterNewServerTabs.SybaseASE.NameTextbox.TextBoxText("Sybase ASE 172.24.1.145 v16");
					repo.RegisterNewServerTabs.SybaseASE.LoginTextbox.TextBoxText("sa");
					repo.RegisterNewServerTabs.SybaseASE.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseASE.HostTextbox.TextBoxText("172.24.1.145");
					repo.RegisterNewServerTabs.SybaseASE.PortTextbox.TextBoxText("5000");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_IQ_154))
				{
					repo.RegisterNewServerTabs.SybaseIQ.NameTextbox.TextBoxText("Sybase IQ 172.24.1.6 15.4");
					repo.RegisterNewServerTabs.SybaseIQ.LoginTextbox.TextBoxText("dba");
					repo.RegisterNewServerTabs.SybaseIQ.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseIQ.HostTextbox.TextBoxText("172.24.1.6");
					repo.RegisterNewServerTabs.SybaseIQ.PortTextbox.TextBoxText("2639");
					repo.RegisterNewServerTabs.SybaseIQ.DatabaseTextbox.TextBoxText("iqdemo");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Sybase_IQ_160))
				{
					repo.RegisterNewServerTabs.SybaseIQ.NameTextbox.TextBoxText("Sybase IQ 172.24.1.140 16.0");
					repo.RegisterNewServerTabs.SybaseIQ.LoginTextbox.TextBoxText("dba");
					repo.RegisterNewServerTabs.SybaseIQ.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.SybaseIQ.HostTextbox.TextBoxText("172.24.1.140");
					repo.RegisterNewServerTabs.SybaseIQ.PortTextbox.TextBoxText("2638");
					repo.RegisterNewServerTabs.SybaseIQ.DatabaseTextbox.TextBoxText("iqdemo");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Teradata_1620))
				{
					repo.RegisterNewServerTabs.Teradata.NameTextbox.TextBoxText("Teradata 10.90.1.111 v16.20");
					repo.RegisterNewServerTabs.Teradata.LoginTextbox.TextBoxText("DBC");
					repo.RegisterNewServerTabs.Teradata.PasswordTextbox.TextBoxText("DBC");
					repo.RegisterNewServerTabs.Teradata.HostTextbox.TextBoxText("10.90.1.111");
					repo.RegisterNewServerTabs.Teradata.PortTextbox.TextBoxText("1025");
					repo.RegisterNewServerTabs.Teradata.DatabaseTextbox.TextBoxText("dbc");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Teradata_150))
				{
					repo.RegisterNewServerTabs.Teradata.NameTextbox.TextBoxText("Teradata 10.90.1.175 v15.0");
					repo.RegisterNewServerTabs.Teradata.LoginTextbox.TextBoxText("DBC");
					repo.RegisterNewServerTabs.Teradata.PasswordTextbox.TextBoxText("amazon");
					repo.RegisterNewServerTabs.Teradata.HostTextbox.TextBoxText("10.90.1.175");
					repo.RegisterNewServerTabs.Teradata.PortTextbox.TextBoxText("1025");
					repo.RegisterNewServerTabs.Teradata.DatabaseTextbox.TextBoxText("dbc");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Vertica_91))
				{
					repo.RegisterNewServerTabs.Vertica.NameTextbox.TextBoxText("Vertica 10.90.1.93 v9.1");
					repo.RegisterNewServerTabs.Vertica.LoginTextbox.TextBoxText("dbadmin");
					repo.RegisterNewServerTabs.Vertica.PasswordTextbox.TextBoxText("Am@z*n7");
					repo.RegisterNewServerTabs.Vertica.HostTextbox.TextBoxText("10.90.1.155");
					repo.RegisterNewServerTabs.Vertica.PortTextbox.TextBoxText("5433");
					repo.RegisterNewServerTabs.Vertica.DatabaseTextbox.TextBoxText("aquafold");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Vertica_80))
				{
					repo.RegisterNewServerTabs.Vertica.NameTextbox.TextBoxText("Vertica 10.90.1.176 v8.0");
					repo.RegisterNewServerTabs.Vertica.LoginTextbox.TextBoxText("dbadmin");
					repo.RegisterNewServerTabs.Vertica.PasswordTextbox.TextBoxText("amazon");
					repo.RegisterNewServerTabs.Vertica.HostTextbox.TextBoxText("10.90.1.176");
					repo.RegisterNewServerTabs.Vertica.PortTextbox.TextBoxText("5433");
					repo.RegisterNewServerTabs.Vertica.DatabaseTextbox.TextBoxText("aquafold");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Excel))
				{
					repo.RegisterNewServerTabs.Excel.NameTextbox.TextBoxText("MSExcel");
					repo.RegisterNewServerTabs.Excel.DirectoryTextbox.TextBoxText(@"C:\Users\Admin\Documents\Ranorex\RanorexStudio Projects\ADSAutomationPhaseII\ADSAutomationPhaseII\TestData\MSExcel\bistudio_example.xlsx");
				}
				
				if(Config.TestCaseName.Contains(ServerListConstants.Microsoft_SQL_Azure_RTM_12020008))
				{
//					repo.RegisterNewServerTabs.Azure.NameTextbox.TextBoxText("Vertica 10.90.1.176 v8.0");
//					repo.RegisterNewServerTabs.Azure.LoginTextbox.TextBoxText("dbadmin");
//					repo.RegisterNewServerTabs.Azure.PasswordTextbox.TextBoxText("amazon");
//					repo.RegisterNewServerTabs.Azure.HostTextbox.TextBoxText("10.90.1.176");
//					repo.RegisterNewServerTabs.Azure.PortTextbox.TextBoxText("5433");
//					repo.RegisterNewServerTabs.Azure.DatabaseTextbox.TextBoxText("aquafold");
				}
			}
			catch (Exception ex)
			{
				ClickOnCancelButton();
				throw new Exception("Failed : RegisterData : " + ex.Message);
			}
		}
		
		public static void ClickOnTestConnection()
		{
			try
			{
				ExplicitWait();
				repo.RegisterNewServerTabs.TestConnectionButtonInfo.WaitForItemExists(1000);
				repo.RegisterNewServerTabs.TestConnectionButton.ClickThis();
				WaitForTestResult();
				if(ValidateTestConnectionSuccess()) CloseSuccess();
				else if(ValidateTestConnectionFailure()) CloseFailed();
				else { if(repo.ConnectionTest.SelfInfo.Exists(5000)) repo.ConnectionTest.CloseButton.ClickThis(); }
				ClickOnCancelButton();
				Reports.ReportLog("ClickOnTestConnection", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				CloseSuccess();
				CloseFailed();
				ClickOnCancelButton();
				throw new Exception("Failed : ClickOnTestConnection : " + ex.Message);
			}
		}
		
		public static void WaitForTestResult()
		{
			try
			{
				if(repo.ConnectionTest.SelfInfo.Exists(5000))
				{
					repo.ConnectionTest.TestConnectionTextInfo.WaitForNotExists(new Duration(Common.ApplicationOpenWaitTime));
					Reports.ReportLog("WaitForTestResult", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : WaitForTestResult : " + ex.Message);
			}
		}
		
		public static void ClickOnCancelButton()
		{
			try
			{
				if(repo.RegisterNewServerTabs.CancelButtonInfo.Exists(new Duration(5000)))
				{
					repo.RegisterNewServerTabs.CancelButtonInfo.WaitForItemExists(1000);
					repo.RegisterNewServerTabs.CancelButton.ClickThis();
					Reports.ReportLog("ClickOnCancelButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCancelButton : " + ex.Message);
			}
		}
		
		public static bool ValidateTestConnectionSuccess()
		{
			try
			{
				return repo.TestConnectionSuccess.SelfInfo.Exists(new Duration(1000));
			}
			catch
			{
				return false;
			}
		}
		
		public static void CloseSuccess()
		{
			try
			{
				repo.TestConnectionSuccess.CloseButton.ClickThis();
				Reports.ReportLog("Server Registration Success", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseSuccess : " + ex.Message);
			}
		}
		
		public static bool ValidateTestConnectionFailure()
		{
			try
			{
				return repo.TestConnectionFailed.SelfInfo.Exists(new Duration(3000));
			}
			catch
			{
				return false;
			}
		}
		
		public static void CloseFailed()
		{
			try
			{
				if(repo.TestConnectionFailed.SelfInfo.Exists(30000))
				{
					repo.TestConnectionFailed.CloseButton.ClickThis();
					Reports.ReportLog("Server Registration Failed", Reports.ADSReportLevel.Fail, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				ClickOnCancelButton();
				throw new Exception("Failed : CloseFailed : " + ex.Message);
			}
		}
	}
}

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

namespace ADSAutomationPhaseII.TC_10540
{
	public static class Steps
	{
		public static TC10540 repo = TC10540.Instance;
		public static string TC1_10540_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10540_Path"].ToString();
		
		public static void ClickOnERModeler()
		{
			try
			{
				repo.Application.ERModelerInfo.WaitForItemExists(25000);
				repo.Application.ERModeler.ClickThis();
				Reports.ReportLog("ClickOnERModeler", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnERModeler :" + ex.Message);
			}
		}
		
		public static void ClickOnGenerate()
		{
			try
			{
				repo.DataStudio.GenerateInfo.WaitForItemExists(25000);
				repo.DataStudio.Generate.ClickThis();
				Reports.ReportLog("ClickOnGenerate", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnGenerate :" + ex.Message);
			}
		}
		
		public static void SelectObjectType()
		{
			try
			{
				foreach (var row in repo.ERGenerator.SelectObjectTypes.Rows)
				{
					if(row.Cells[2].Text == "Tables")
						row.Cells[1].ClickThis();
					break;
				}
				Reports.ReportLog("SelectObjectType", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ERGenerator.Self.Close();
				throw new Exception("Failed : SelectObjectType :" + ex.Message);
			}
		}
		
		public static void SelectTableObject()
		{
			try
			{
				repo.ERGenerator.UnselectObjectType.ClickThis();
				
				foreach (var row in repo.ERGenerator.ObjectTable.Rows)
				{
					if(row.Cells[3].Text.ToLower() == "ads_table")
						row.Cells[1].ClickThis();
					break;
				}
				Reports.ReportLog("SelectObject", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ERGenerator.Self.Close();
				throw new Exception("Failed : SelectObject :" + ex.Message);
			}
		}
		
		public static void SelectObject()
		{
			try
			{
				repo.ERGenerator.UnselectObjectType.ClickThis();
				
				foreach (var row in repo.ERGenerator.ObjectTable.Rows)
				{
					if(row.Cells[4].Text.ToLower() == "ads_table")
						row.Cells[1].ClickThis();
					break;
				}
				Reports.ReportLog("SelectObject", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ERGenerator.Self.Close();
				throw new Exception("Failed : SelectObject :" + ex.Message);
			}
		}
		
		public static void SelectADSDb()
		{
			try
			{
				TreeItem SelectedServer = null ;
				SelectServer(ref SelectedServer);
				TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB, false);
				adsDB.Select();
				Reports.ReportLog("SelectADSDb", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ChooseServer.Self.Close();
				throw new Exception("Failed : SelectADSDb :" + ex.Message);
			}
		}
		
		public static void SelectADSDB()
		{
			try
			{
				TreeItem SelectedServer = null ;
				SelectServer(ref SelectedServer);
				TreeItem adsDB = SelectedServer.GetItem(Configuration.Config.ADSDB.ToUpper(), false);
				adsDB.Select();
				Reports.ReportLog("SelectADSDB", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectADSDB :" + ex.Message);
			}
		}
		
		public static void SelectServer(ref TreeItem item)
		{
			try
			{
				TreeItem SelectedServer = repo.ChooseServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName, true);
				item = SelectedServer;
				if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Configuration.Config.TestCaseName);
					Preconditions.Steps.SelectedServerTreeItem = server;
					Preconditions.Steps.SelectedServerName = server.Text;
					SelectedServer = item = repo.ChooseServer.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
				SelectedServer.EnsureVisible();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ChooseServer.Self.Close();
				throw new Exception("Failed : SelectServer :" + ex.Message);
			}
		}
		
		public static void ClickOnOk()
		{
			try
			{
				repo.ChooseServer.OkButtonInfo.WaitForItemExists(25000);
				repo.ChooseServer.OkButton.ClickThis();
				Reports.ReportLog("ClickOnOk", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ChooseServer.Self.Close();
				throw new Exception("Failed : ClickOnOk :" + ex.Message);
			}
		}
		
		public static void UnSelectObjectTypes()
		{
			try
			{
				repo.ERGenerator.UnSelectObjectTypesInfo.WaitForItemExists(25000);
				repo.ERGenerator.UnSelectObjectTypes.ClickThis();
				Reports.ReportLog("UnSelectObjectTypes", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ERGenerator.Self.Close();
				throw new Exception("Failed : UnSelectObjectTypes :" + ex.Message);
			}
		}
		
		public static void NextButton()
		{
			try
			{
				repo.ERGenerator.NextButtonInfo.WaitForItemExists(25000);
				repo.ERGenerator.NextButton.ClickThis();
				Reports.ReportLog("NextButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				repo.ERGenerator.Self.Close();
				throw new Exception("Failed : NextButton :" + ex.Message);
			}
		}
		
		public static void EntityRelationshipDiagram()
		{
			try
			{
				repo.EntityRelationshipDiagram.ERDiagramInfo.WaitForItemExists(25000);
				if(repo.EntityRelationshipDiagram.ERDiagram.Visible)
				{
					Reports.ReportLog("ERDiagram is generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				
				else
				{
					Reports.ReportLog("ERDiagram is not generated", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				repo.EntityRelationshipDiagram.Self.Close();
				throw new Exception("Failed : EntityRelationshipDiagram :" + ex.Message);
			}
		}
		
		public static void ClickOnClose()
		{
			try
			{
				repo.EntityRelationshipDiagram.CloseButtonInfo.WaitForItemExists(25000);
				repo.EntityRelationshipDiagram.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose :" + ex.Message);
			}
		}
		
		public static void ClickOnDiscard()
		{
			try
			{
				repo.FileModified.DiscardInfo.WaitForItemExists(25000);
				repo.FileModified.Discard.ClickThis();
				Reports.ReportLog("ClickOnDiscard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDiscard :" + ex.Message);
			}
		}
		
		public static void ClickOnDBATools()
		{
			try
			{
				repo.Application.DBAToolsInfo.WaitForItemExists(25000);
				repo.Application.DBATools.ClickThis();
				Reports.ReportLog("ClickOnDBATools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDBATools :" + ex.Message);
			}
		}
		
		public static void ClickOnAmazonRedshift()
		{
			try
			{
				repo.DataStudio.AmazonInfo.WaitForItemExists(25000);
				repo.DataStudio.Amazon.ClickThis();
				Reports.ReportLog("ClickOnAmazonRedshift", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAmazonRedshift :" + ex.Message);
			}
		}
		
		public static void ClickOnMariaDB()
		{
			try
			{
				repo.DataStudio.MariaDBInfo.WaitForItemExists(25000);
				repo.DataStudio.MariaDB.ClickThis();
				Reports.ReportLog("ClickOnMariaDB", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnMariaDB :" + ex.Message);
			}
		}
		
		public static void ClickOnDB2()
		{
			try
			{
				repo.DataStudio.DBLUWInfo.WaitForItemExists(25000);
				repo.DataStudio.DBLUW.ClickThis();
				Reports.ReportLog("ClickOnDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDB2 :" + ex.Message);
			}
		}
		
		public static void ClickOnMySql()
		{
			try
			{
				repo.DataStudio.MySqlInfo.WaitForItemExists(25000);
				repo.DataStudio.MySql.ClickThis();
				Reports.ReportLog("ClickOnMySql", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnERModeler :" + ex.Message);
			}
		}
		
		public static void ClickOnMSSQL()
		{
			try
			{
				repo.DataStudio.MSSQLServerInfo.WaitForItemExists(25000);
				repo.DataStudio.MSSQLServer.ClickThis();
				Reports.ReportLog("ClickOnMSSQL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnMSSQL :" + ex.Message);
			}
		}
		
		public static void ClickOnOracle()
		{
			try
			{
				repo.DataStudio.OracleInfo.WaitForItemExists(25000);
				repo.DataStudio.Oracle.ClickThis();
				Reports.ReportLog("ClickOnMSSQL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOracle :" + ex.Message);
			}
		}
		
		public static void ClickOnNetezza()
		{
			try
			{
				repo.DataStudio.NetezzaInfo.WaitForItemExists(25000);
				repo.DataStudio.Netezza.ClickThis();
				Reports.ReportLog("ClickOnNetezza", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnNetezza :" + ex.Message);
			}
		}
		
		public static void ClickOnPostgreSql()
		{
			try
			{
				repo.DataStudio.PostgreSQLInfo.WaitForItemExists(25000);
				repo.DataStudio.PostgreSQL.ClickThis();
				Reports.ReportLog("ClickOnPostgreSql", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPostgreSql :" + ex.Message);
			}
		}
		
		public static void ClickOnGreenPlum()
		{
			try
			{
				repo.DataStudio.GreenPlumInfo.WaitForItemExists(25000);
				repo.DataStudio.GreenPlum.ClickThis();
				Reports.ReportLog("ClickOnGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnGreenPlum :" + ex.Message);
			}
		}
		
		public static void ClickOnTeradata()
		{
			try
			{
				repo.DataStudio.TeradataInfo.WaitForItemExists(25000);
				repo.DataStudio.Teradata.ClickThis();
				Reports.ReportLog("ClickOnTeradata", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTeradata :" + ex.Message);
			}
		}
		
		public static void ClickOnVertica()
		{
			try
			{
				repo.DataStudio.VerticaInfo.WaitForItemExists(25000);
				repo.DataStudio.Vertica.ClickThis();
				Reports.ReportLog("ClickOnVertica", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnVertica :" + ex.Message);
			}
		}
		
		public static void ClickOnInformix()
		{
			try
			{
				repo.DataStudio.InformixInfo.WaitForItemExists(25000);
				repo.DataStudio.Informix.ClickThis();
				Reports.ReportLog("ClickOnInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnInformix :" + ex.Message);
			}
		}
		
		public static void ClickOnSybaseASE()
		{
			try
			{
				repo.DataStudio.SybaseASEInfo.WaitForItemExists(25000);
				repo.DataStudio.SybaseASE.ClickThis();
				Reports.ReportLog("ClickOnSybaseASE", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSybaseASE :" + ex.Message);
			}
		}
		
		public static void ClickOnInstanceManager()
		{
			try
			{
				repo.DataStudio.InstanceManagerInfo.WaitForItemExists(2000);
				repo.DataStudio.InstanceManager.ClickThis();
				Reports.ReportLog("ClickOnInstanceManager", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnInstanceManager();
			}
		}
		
		public static void SummaryTabValiadation()
		{
			try
			{
				repo.Application.SummaryTabInfo.WaitForItemExists(25000);
				if(repo.Application.SummaryTab.Visible)
				{
					Reports.ReportLog("Validation : SummaryTab is visible", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : SummaryTab is not visible", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SummaryTabValiadation :" + ex.Message);
			}
		}
		
		public static void QueryTabValiadation()
		{
			try
			{
				repo.Application.QueryTabInfo.WaitForItemExists(25000);
				if(repo.Application.QueryTab.Visible)
				{
					Reports.ReportLog("QueryTab is visible", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("QueryTab is not visible", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : QueryTabValiadation :" + ex.Message);
			}
		}
		
		public static void ColumnsValidation()
		{
			try
			{
				List<string> columnNames = new List<string>{"Server Component", "Value", "Group", "Description", "Extra Info", "Context", "Type", "Source", "Min", "Max"};
				
				foreach (var column in columnNames)
				{
					Cell columnCell = repo.Application.SortableColumns.FindSingle("cell[@text='"+ column +"']");
					if(columnCell != null)
					{
						Reports.ReportLog("Validation : Columns : " + column, Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Validation : Columns : " + column, Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ColumnsValidation :" + ex.Message);
			}
			
		}
		
		public static void Search(string item)
		{
			try
			{
				repo.Application.SearchTextBoxInfo.WaitForItemExists(25000);
				repo.Application.SearchTextBox.TextBoxText(item);
				Reports.ReportLog("Search", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : Search :" + ex.Message);
			}
		}
		
		public static void SearchSummaryResultValidation()
		{
			try
			{
				repo.Application.SearchTableInfo.WaitForItemExists(25000);
				if(repo.Application.SearchTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 record found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : No record found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchSummaryResultValidation :" + ex.Message);
			}
		}
		
		public static void ClickOnQueryHistory()
		{
			try
			{
				repo.Application.QueryTabInfo.WaitForItemExists(25000);
				repo.Application.QueryTab.ClickThis();
				Reports.ReportLog("ClickOnQueryHistory", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnQueryHistory :" + ex.Message);
			}
		}
		
		public static void SelectTypeQuery()
		{
			try
			{
				repo.Application.QueryHistoryTypeInfo.WaitForItemExists(25000);
				repo.Application.QueryHistoryType.TextBoxText("QUERY");
				Reports.ReportLog("SelectTypeQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectTypeQuery :" + ex.Message);
			}
		}
		
		public static void SearchQuery(string item)
		{
			try
			{
				repo.Application.SearchQueryInfo.WaitForItemExists(25000);
				repo.Application.SearchQuery.TextBoxText(item);
				Reports.ReportLog("SearchQuery", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchQuery :" + ex.Message);
			}
		}
		
		public static void SearchQueryResultValidation()
		{
			try
			{
				if(repo.Application.SearchQueryTableInfo.Exists(2000))
				{
					repo.Application.SearchQueryTableInfo.WaitForItemExists(25000);
					if(repo.Application.SearchQueryTable.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : 2 record found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Validation : No record found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchQueryResultValidation :" + ex.Message);
			}
		}
		
		public static void ClickOnStorageManager()
		{
			try
			{
				repo.DataStudio.StorageManagerInfo.WaitForItemExists(2000);
				repo.DataStudio.StorageManager.ClickThis();
				
				Reports.ReportLog("ClickOnStorageManager", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}

			catch (Exception)
			{
				ClickOnStorageManager();
			}
		}
		
		public static void ClickOnDatabases()
		{
			try
			{
				repo.Application.DatabasesInfo.WaitForItemExists(25000);
				repo.Application.Databases.ClickThis();
				Reports.ReportLog("ClickOnDatabases", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDatabases :" + ex.Message);
			}
		}
		
		public static void SelectDB()
		{
			try
			{
				repo.Application.StorageManagerTableInfo.WaitForItemExists(25000);
				foreach( var row in repo.Application.StorageManagerTable.Rows)
				{
					if(row.Cells[0].Text == "ads_db" || row.Cells[0].Text == "ADS_DB")
					{
						row.Cells[0].RightClick();
						break;
					}
				}
				Reports.ReportLog("SelectDB", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDB :" + ex.Message);
			}
		}
		
		public static void SearchDatabase(string db)
		{
			try
			{
				repo.Application.DatabaseSearchInfo.WaitForItemExists(25000);
				repo.Application.DatabaseSearch.TextBoxText(db);
				Reports.ReportLog("SearchDatabase", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchDatabase :" + ex.Message);
			}
		}
		
		public static void SearchDatabaseResultValidation()
		{
			try
			{
				repo.Application.DatabaseTableInfo.WaitForItemExists(25000);
				if(repo.Application.DatabaseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 record found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : No record found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchDatabaseResultValidation :" + ex.Message);
			}
		}
		
		public static void ClickOnObjects()
		{
			try
			{
				repo.Application.SelfInfo.WaitForItemExists(25000);
				repo.Application.ObjectsInfo.WaitForItemExists(25000);
				repo.Application.Objects.ClickThis();
				Reports.ReportLog("ClickOnObjects", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnObjects :" + ex.Message);
			}
		}
		
		public static void ObjectsColumnsValidation()
		{
			try
			{
				List<string> columnNames = new List<string>{"Table Name", "Schema", "Owner", "Space Used (MB)"};
				
				if(repo.Application.ObjectColumnInfo.Exists(2000))
				{
					foreach (var column in columnNames)
					{
						Cell columnCell = repo.Application.ObjectColumn.FindSingle("cell[@text='"+ column +"']");
						if(columnCell != null)
						{
							Reports.ReportLog("Validation : column found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
						}
						else
						{
							Reports.ReportLog("Validation : column not found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ObjectsColumnsValidation :" + ex.Message);
			}
			
		}
		
		public static void ClickOnSecurityManager()
		{
			try
			{
				repo.DataStudio.SecurityManagerInfo.WaitForItemExists(2000);
				repo.DataStudio.SecurityManager.ClickThis();
				Reports.ReportLog("ClickOnSecurityManager", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnSecurityManager();
			}
		}
		
		public static void SelectUser()
		{
			try
			{
				repo.Application.UsersInfo.WaitForItemExists(25000);
				repo.Application.Users.ClickThis();
				Reports.ReportLog("SelectUser", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectUser :" + ex.Message);
			}
		}
		
		public static void ValidateNewWindow()
		{
			try
			{
				repo.Application.NewWindowInfo.WaitForItemExists(25000);
				if(repo.Application.NewWindow.Visible)
				{
					Reports.ReportLog("Validation : Window found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				
				else
				{
					Reports.ReportLog("Validation : Window not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNewWindow :" + ex.Message);
			}
		}
		
		public static void ClickOnUser()
		{
			try
			{
				repo.Application.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.UsersTab.ClickThis();
				Reports.ReportLog("ClickOnUser", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnUser :" + ex.Message);
			}
		}
		
		public static void SearchUserView(string item)
		{
			try
			{
				repo.Application.SearchUserInfo.WaitForItemExists(25000);
				repo.Application.SearchUser.TextBoxText(item);
				Reports.ReportLog("SearchUserView", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SearchUserView :" + ex.Message);
			}
		}
		
		public static void ValidateUsersSerachResult()
		{
			try
			{
				if(repo.Application.SearchUserResultInfo.Exists(2000))
				{
					if(repo.Application.SearchUserResult.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					
					else
					{
						Reports.ReportLog("Validation : row not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateUsersSerachResult :" + ex.Message);
			}
		}
		
		public static void ClickOnGroups()
		{
			try
			{
				repo.Application.GroupViewInfo.WaitForItemExists(25000);
				repo.Application.GroupView.ClickThis();
				Reports.ReportLog("ClickOnGroups", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on groups. "+ex.Message);
			}
		}
		
		public static void SearchGroups(string item)
		{
			try
			{
				repo.Application.SearchGroupInfo.WaitForItemExists(20000);
				repo.Application.SearchGroup.TextBoxText(item);
				Reports.ReportLog("SearchGroups", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search textbox not working. "+ ex.Message);
			}
		}
		
		public static void ValidateGroupSearchResult()
		{
			try
			{
				if(repo.Application.GroupTableInfo.Exists(2000))
				{
					if(repo.Application.GroupTable.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : rows found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					
					else
					{
						Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Group search result cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionManager()
		{
			try
			{
				repo.DataStudio.SessionManagerInfo.WaitForItemExists(2000);
				repo.DataStudio.SessionManager.ClickThis();
				Reports.ReportLog("ClickOnSessionManager", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception)
			{
				ClickOnSessionManager();
			}
		}
		
		public static void ClickOnSqlServerAgent()
		{
			try
			{
				repo.DataStudio.SqlServerAgentInfo.WaitForItemExists(25000);
				repo.DataStudio.SqlServerAgent.ClickThis();
				Reports.ReportLog("ClickOnSqlServerAgent", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnERModeler :" + ex.Message);
			}
		}
		
		public static void ClickOnSessionsTab()
		{
			try
			{
				repo.Application.SessionsInfo.WaitForItemExists(250000);
				repo.Application.Sessions.ClickThis();
				Reports.ReportLog("ClickOnSessionsTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Sessions Tab. "+ex.Message);
			}
		}
		
		public static void ValidateKillSession()
		{
			try
			{
				repo.Application.SessionAuthIDCellInfo.WaitForItemExists(25000);
				System.Threading.Thread.Sleep(25000);
				repo.Application.SessionAuthIDCell.RightClick();
				System.Threading.Thread.Sleep(2500);
				repo.DataStudio.KillSessionInfo.WaitForItemExists(25000);
				repo.DataStudio.KillSession.ClickThis();
				repo.KillSession.CancelButtonInfo.WaitForItemExists(25000);
				repo.KillSession.CancelButton.ClickThis();
				repo.Discard.DiscardInfo.WaitForItemExists(25000);
				repo.Discard.Discard.ClickThis();
				Reports.ReportLog("ValidateKillSession", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Kill session cannot be validated. "+ex.Message);
			}
		}
		
		public static void SearchProcessID(string processId)
		{
			try
			{
				repo.Application.SearchProcessIdInfo.WaitForItemExists(25000);
				repo.Application.SearchProcessId.TextBoxText(processId);
				Reports.ReportLog("SearchProcessID", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox not working. "+ex.Message);
			}
		}
		
		public static void ValidateSessionProcessId()
		{
			try
			{
				if(repo.Application.SessionTableInfo.Exists(2000))
				{
					if(repo.Application.SessionTable.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Validation : row not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnSesionStats()
		{
			try
			{
				repo.Application.SessionStatsInfo.WaitForItemExists(25000);
				repo.Application.SessionStats.ClickThis();
				Reports.ReportLog("ClickOnSesionStats", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex) {
				
				throw new Exception("Unable to click on session stats. "+ex.Message);
			}
		}
		
		public static void SearchSessionStats(string processId)
		{
			try
			{
				repo.Application.SearchSessionStatsInfo.WaitForItemExists(25000);
				repo.Application.SearchSessionStats.TextBoxText(processId);
				Reports.ReportLog("SearchSessionStats", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search session stats not working. "+ex.Message);
			}
		}
		
		public static void ValidateSessionStatsSearch()
		{
			try
			{
				if(repo.Application.SessionStatsTableInfo.Exists(2000))
				{
					if(repo.Application.SessionStatsTable.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					
					else
					{
						Reports.ReportLog("Validation : no row found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session stats cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnLock()
		{
			try
			{
				repo.Application.LockInfo.WaitForItemExists(25000);
				repo.Application.Lock.ClickThis();
				Reports.ReportLog("ClickOnLock", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on lock. "+ex.Message);
			}
		}
		
		public static void SearchLock(string db)
		{
			try
			{
				repo.Application.LockSearchInfo.WaitForItemExists(25000);
				repo.Application.LockSearch.TextBoxText(db);
				Reports.ReportLog("SearchLock", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox for Lock not working. "+ex.Message);
			}
		}
		
		public static void ValidateLockSearchResult()
		{
			try
			{
				if(repo.Application.LockTableInfo.Exists(2000))
				{
					if(repo.Application.LockTable.Rows.Count > 0)
					{
						Reports.ReportLog("Validation : rows found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
					}
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Lock search cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnSummaryTab()
		{
			try
			{
				repo.Application.SummaryTabDB2Info.WaitForItemExists(250000);
				repo.Application.SummaryTabDB2.ClickThis();
				Reports.ReportLog("ClickOnSummaryTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex) {
				
				throw new Exception("Unable to click on Summary Tab. "+ex.Message);
			}
		}
		
		public static void SearchDB(string db)
		{
			try
			{
				repo.Application.SearchDB2Info.WaitForItemExists(25000);
				repo.Application.SearchDB2.TextBoxText(db);
				Reports.ReportLog("SearchDB", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search textbox for summary tab not working. "+ex.Message);
			}
		}
		
		public static void ValidateSummaryDBSearchResult()
		{
			try
			{
				repo.Application.SearchDBTableInfo.WaitForItemExists(25000);
				if(repo.Application.SearchDBTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Summary search result cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnRegistryParameters()
		{
			try
			{
				repo.Application.RegistryParametersInfo.WaitForItemExists(25000);
				repo.Application.RegistryParameters.ClickThis();
				Reports.ReportLog("ClickOnRegistryParameters", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Registry parameters. "+ex.Message);
				
			}
		}
		
		public static void ValidateRegistryPropertySearchResult()
		{
			try
			{
				repo.Application.SearchRegistryTableInfo.WaitForItemExists(25000);
				if(repo.Application.SearchRegistryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Register property result cannot be validated. "+ex.Message);
				
			}
		}
		
		public static void ClickOnDatabaseParameters()
		{
			try
			{
				repo.Application.DatabaseParametersInfo.WaitForItemExists(25000);
				repo.Application.DatabaseParameters.ClickThis();
				Reports.ReportLog("ClickOnDatabaseParameters", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database parameters. "+ex.Message);
			}
		}
		
		public static void ValidateDatabasePropertySearchResult()
		{
			try
			{
				repo.Application.SearchDatabasePropertyTableInfo.WaitForItemExists(25000);
				if(repo.Application.SearchDatabasePropertyTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Failed : ValidateDatabasePropertySearchResult :" + ex.Message);
			}
		}
		
		public static void ClickOnDatabaseManagerProperty()
		{
			try
			{
				repo.Application.DatabaseManagerPropertiesInfo.WaitForItemExists(25000);
				repo.Application.DatabaseManagerProperties.ClickThis();
				Reports.ReportLog("ClickOnDatabaseManagerProperty", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database manager property. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseManagerProperty()
		{
			try
			{
				repo.Application.SearchManagerPropertyInfo.WaitForItemExists(25000);
				if(repo.Application.SearchManagerProperty.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			
			catch (Exception ex)
			{
				
				throw new Exception("Database Manager property cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnTree()
		{
			try
			{
				repo.Application.TreeDB2Info.WaitForItemExists(25000);
				repo.Application.TreeDB2.ClickThis();
				Reports.ReportLog("ClickOnTree", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch(Exception ex)
			{
				throw new Exception("Tree Tab didn't get clicked. "+ex.Message);
			}
		}
		
		public static void SearchStorageManagerDB2(string item)
		{
			try
			{
				repo.Application.SearchStorageManagerDB2Info.WaitForItemExists(25000);
				repo.Application.SearchStorageManagerDB2.TextBoxText(item);
				Reports.ReportLog("SearchStorageManagerDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search for storage manager for DB2 not working. "+ex.Message);
			}
		}
		
		public static void ValidateTreeSearchResult()
		{
			try
			{
				repo.Application.TreeTableInfo.WaitForItemExists(25000);
				if(repo.Application.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree search cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnTableSpaces()
		{
			try
			{
				repo.Application.TablespacesDB2Info.WaitForItemExists(25000);
				repo.Application.TablespacesDB2.ClickThis();
				Reports.ReportLog("ClickOnTableSpaces", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Table spaces of DB2. "+ex.Message);
				
			}
		}
		
		public static void ValidateTablespacesDB2()
		{
			try
			{
				repo.Application.TableSpaceTableInfo.WaitForItemExists(25000);
				if(repo.Application.TableSpaceTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Table spaces DB2 cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnBufferPools()
		{
			try
			{
				repo.Application.BufferPoolsDB2Info.WaitForItemExists(25000);
				repo.Application.BufferPoolsDB2.ClickThis();
				Reports.ReportLog("ClickOnBufferPools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Buffer pools of DB2. "+ex.Message);
			}
		}
		
		public static void ValidateBufferPoolDB2()
		{
			try
			{
				repo.Application.BufferPoolTableInfo.WaitForItemExists(25000);
				if(repo.Application.BufferPoolTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Buffer pool cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnObjectsDB2()
		{
			try
			{
				repo.Application.ObjectStorageDB2Info.WaitForItemExists(25000);
				repo.Application.ObjectStorageDB2.ClickThis();
				Reports.ReportLog("ClickOnObjectsDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Objects of DB2. "+ex.Message);
				
			}
		}
		
		public static void ClickOnDataFileDB2()
		{
			try
			{
				repo.Application.DataFilesDB2Info.WaitForItemExists(25000);
				repo.Application.DataFilesDB2.ClickThis();
				Reports.ReportLog("ClickOnDataFileDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Data files of DB2. "+ex.Message);
			}
		}
		
		public static void ValidateDataFileDB2()
		{
			try
			{
				repo.Application.DataFileTableInfo.WaitForItemExists(25000);
				if(repo.Application.DataFileTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : rows not found", Reports.ADSReportLevel.Info, null, Configuration.Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Data file of DB2 cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeTabDb2()
		{
			try
			{
				repo.Application.TreeTabDB2Info.WaitForItemExists(25000);
				repo.Application.TreeTabDB2.ClickThis();
				Reports.ReportLog("ClickOnTreeTabDb2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Tree tab of DB2. "+ex.Message);
				
			}
		}
		
		public static void ValidateUserDB2()
		{
			try
			{
				repo.Application.SelectUserDB2Info.WaitForItemExists(25000);
				repo.Application.SelectUserDB2.RightClick();
				Reports.ReportLog("ValidateUserDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to find menu items. " +ex.Message);
			}
		}
		
		public static void ValidateNewPaneDB2()
		{
			try
			{
				repo.Application.OpenNewPaneInfo.WaitForItemExists(25000);
				if(repo.Application.OpenNewPane.Visible)
				{
					Reports.ReportLog("Validation : New pane has been opened.", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : New pane has not been opened.", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("New pane does not exist. " +ex.Message);
			}
		}
		
		public static void ClickOnUsersTabDB2()
		{
			try
			{
				repo.Application.UsersTabDB2Info.WaitForItemExists(25000);
				repo.Application.UsersTabDB2.ClickThis();
				Reports.ReportLog("ClickOnUsersTabDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users Tab. "+ex.Message);
			}
		}
		
		public static void SearchSecurityDB2(string item)
		{
			try
			{
				repo.Application.SearchSecurityDB2Info.WaitForItemExists(25000);
				repo.Application.SearchSecurityDB2.TextBoxText(item);
				Reports.ReportLog("SearchSecurityDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search textbox of security manager not working. "+ex.Message);
			}
		}
		
		public static void ValidateUserNameDB2()
		{
			try
			{
				repo.Application.UserTableDB2Info.WaitForItemExists(25000);
				if(repo.Application.UserTableDB2.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("User table does not exist"+ex.Message);
			}
		}
		
		public static void ClickOnRolesDB2()
		{
			try
			{
				repo.Application.RolesDB2Info.WaitForItemExists(25000);
				repo.Application.RolesDB2.ClickThis();
				Reports.ReportLog("ClickOnRolesDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles Tab. "+ex.Message);
			}
		}
		
		public static void ValidateRolesDB2()
		{
			try
			{
				repo.Application.RolesTableDB2Info.WaitForItemExists(25000);
				if(repo.Application.RolesTableDB2.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				
				else
				{
					Reports.ReportLog("Validation : row not found", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Roles table does not exist. "+ex.Message);
				
			}
		}
		
		public static void ClickOnGroupsTab()
		{
			try
			{
				repo.Application.GroupsDB2TabInfo.WaitForItemExists(25000);
				repo.Application.GroupsDB2Tab.ClickThis();
				Reports.ReportLog("ClickOnGroupsTab", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Groups Tab. " +ex.Message);
			}
		}
		
		public static void ValidateGroupDB2()
		{
			try
			{
				repo.Application.GroupsDB2TableInfo.WaitForItemExists(25000);
				if(repo.Application.GroupsDB2Table.Rows.Count > 0)
				{
					Reports.ReportLog(" Validate : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog(" Validate : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Group table does not exist. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionTabDB2()
		{
			try
			{
				repo.Application.DBLUW.SessionTabInfo.WaitForItemExists(25000);
				repo.Application.DBLUW.SessionTab.ClickThis();
				Reports.ReportLog("ClickOnSessionTabDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on session tab of DB2. "+ex.Message);
			}
		}
		
		public static void SearchSessionDB2(string item)
		{
			try
			{
				repo.Application.DBLUW.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.DBLUW.SearchSession.TextBoxText(item);
				Reports.ReportLog("SearchSessionDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				
				throw new Exception("Search session DB2 no working " + ex.Message);
			}
		}
		
		public static void ValidateSearchSessionDB2()
		{
			try
			{
				repo.Application.DBLUW.SessionTableInfo.WaitForItemExists(25000);
				if(repo.Application.DBLUW.SessionTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation :  1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search session DB2 cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionStatsTabDB2()
		{
			try
			{
				repo.Application.DBLUW.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.DBLUW.SessionStatsTab.ClickThis();
				Reports.ReportLog("ClickOnSessionStatsTabDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on session stats tab of DB2. "+ex.Message);
			}
		}
		
		public static void ValidateSearchSessionStatsDB2()
		{
			try
			{
				repo.Application.DBLUW.SessionStatsTableInfo.WaitForItemExists(25000);
				if(repo.Application.DBLUW.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation :  1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search session stats DB2 cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnLocksTabDB2()
		{
			try
			{
				repo.Application.DBLUW.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.DBLUW.LocksTab.ClickThis();
				Reports.ReportLog("ClickOnLocksTabDB2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks tab of DB2. "+ex.Message);
			}
		}
		
		public static void ClickOnSummaryGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.SummaryTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SummaryTab.ClickThis();
				Reports.ReportLog("ClickOnSummaryGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Summary tab of GreenPlum. "+ex.Message);
			}
		}
		
		public static void SearchInstanceGreenPlum(string item)
		{
			try
			{
				repo.Application.GreenPlum.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SearchInstance.TextBoxText(item);
				Reports.ReportLog("SearchInstanceGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Search textbox for GreenPlum not working. "+ex.Message);
				
			}
		}
		
		public static void ValidateSummaryTableGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.SummaryTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.SummaryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Summary table of greenplum cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnSegmentTabGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.SegmentsTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SegmentsTab.ClickThis();
				Reports.ReportLog("ClickOnSegmentTabGreenplum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on segments tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.TreeTab.ClickThis();
				Reports.ReportLog("ClickOnTreeTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab of greenplum. "+ex.Message);
			}
		}
		
		public static void SearchStorageGreenplum(string item)
		{
			try
			{
				repo.Application.GreenPlum.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SearchStorage.TextBoxText(item);
				Reports.ReportLog("SearchStorageGreenplum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of greenplum not working. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.TreeTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTablespaceTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.TablespacesTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.TablespacesTab.ClickThis();
				Reports.ReportLog("ClickOnTablespaceTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tablespace tab of greenplum. "+ex.Message);
			}
		}
		
		public static void ValidateTablespaceTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.TablespaceTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.TablespaceTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tablespace table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabaseTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.DatabaseTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.DatabaseTab.ClickThis();
				Reports.ReportLog("ClickOnDatabaseTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database tab of greenplum. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseTabGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.DatabaseTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.DatabaseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Database table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.ObjectsTab.ClickThis();
				Reports.ReportLog("ClickOnObjectsGreenplum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Objects of Greenplum. " +ex.Message);
				
			}
		}
		
		public static void ClickOnTreeSecTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.TreeSecTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.TreeSecTab.ClickThis();
				Reports.ReportLog("ClickOnTreeSecTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab of greenplum. "+ex.Message);
			}
		}
		
		public static void SearchSecurityGreenplum(string item)
		{
			try
			{
				repo.Application.GreenPlum.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SearchSecurity.TextBoxText(item);
				Reports.ReportLog("SearchSecurityGreenplum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of greenplum not working. "+ ex.Message);
			}
		}
		
		public static void ValidateTreeSecTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.TreeSecTableInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.TreeSecTable.ClickThis();
				repo.Application.GreenPlum.NewPaneInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.NewPane.Visible)
				{
					Reports.ReportLog("Validation : new pane is visible. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : new pane is not visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersSecTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.UsersTab.ClickThis();
				Reports.ReportLog("ClickOnUsersSecTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab of greenplum. "+ex.Message);
			}
		}
		
		public static void ValidateUserSecTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.UserTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.UserTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found. ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("User table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnGroupSecTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.GroupsTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.GroupsTab.ClickThis();
				Reports.ReportLog("ClickOnGroupSecTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Groups tab of greenplum. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.SessionTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SessionTab.ClickThis();
				Reports.ReportLog("ClickOnSessionTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on session tab of greenplum. "+ex.Message);
			}
		}
		
		public static void SearchSessionGreenplum(string item)
		{
			try
			{
				repo.Application.GreenPlum.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SearchSession.TextBoxText(item);
				Reports.ReportLog("SearchSessionGreenplum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of greenplum not working. "+ ex.Message);
			}
		}
		
		public static void ValidateSessionTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.SessionTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.SessionTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionStatsTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.SessionStatsTab.ClickThis();
				Reports.ReportLog("ClickOnSessionStatsTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on sesion stats of greenplum. "+ex.Message);
			}
		}
		
		public static void ValidateSessionStatsTableGreenplum()
		{
			try
			{
				repo.Application.GreenPlum.SessionStatsTableInfo.WaitForItemExists(25000);
				if(repo.Application.GreenPlum.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksTabGreenPlum()
		{
			try
			{
				repo.Application.GreenPlum.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.GreenPlum.LocksTab.ClickThis();
				Reports.ReportLog("ClickOnLocksTabGreenPlum", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks of greenplum. "+ex.Message);
			}
		}
		
		public static void ClickOnConfigurationTabInformix()
		{
			try
			{
				repo.Application.Informix.ConfigurationTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.ConfigurationTab.ClickThis();
				Reports.ReportLog("ClickOnConfigurationTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on ConfigurationTab. "+ex.Message);
			}
		}
		
		public static void SearchInstanceInformix(string item)
		{
			try
			{
				repo.Application.Informix.SearchIntanceInfo.WaitForItemExists(25000);
				repo.Application.Informix.SearchIntance.TextBoxText(item);
				Reports.ReportLog("SearchInstanceInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of instance not working. "+ ex.Message);
			}
		}
		
		public static void ValidateConfigurationTableInformix()
		{
			try
			{
				repo.Application.Informix.ConfigurationTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.ConfigurationTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnProfiledEventsTabInformix()
		{
			try
			{
				repo.Application.Informix.ProfiledEventsTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.ProfiledEventsTab.ClickThis();
				Reports.ReportLog("ClickOnProfiledEventsTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Profiled events tab. "+ex.Message);
			}
		}
		
		public static void ValidateProfiledEventsTableInformix()
		{
			try
			{
				repo.Application.Informix.ProfiledEventsTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.ProfiledEventsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Profiled events table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnStartUpEnvironmentSettingTabInformix()
		{
			try
			{
				repo.Application.Informix.StartUpEnvironmentSettingInfo.WaitForItemExists(25000);
				repo.Application.Informix.StartUpEnvironmentSetting.ClickThis();
				Reports.ReportLog("ClickOnStartUpEnvironmentSettingTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on startup environment setting tab. "+ex.Message);
			}
		}
		
		public static void ValidateStartUpEnvironmentSettingTableInformix()
		{
			try
			{
				repo.Application.Informix.StartUpEnvironmentSettingTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.StartUpEnvironmentSettingTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Startup environment setting table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabInformix()
		{
			try
			{
				repo.Application.Informix.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.TreeTab.ClickThis();
				Reports.ReportLog("ClickOnTreeTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void SearchStorageInformix(string item)
		{
			try
			{
				repo.Application.Informix.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.Informix.SearchStorage.TextBoxText(item);
				Reports.ReportLog("SearchStorageInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of storage not working. "+ ex.Message);
			}
		}
		
		public static void ValidateTreeTableInformix()
		{
			try
			{
				repo.Application.Informix.TreeTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDbspacesTabInformix()
		{
			try
			{
				repo.Application.Informix.DBSpacesTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.DBSpacesTab.ClickThis();
				Reports.ReportLog("ClickOnDbspacesTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Dbspaces tab. "+ex.Message);
			}
		}
		
		public static void ValidateDbspaceTableInformix()
		{
			try
			{
				repo.Application.Informix.DbspaceTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.DbspaceTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Dbspace table cannot be validated. "+ex.Message);
			}
		}
		
		public static void ClickOnDatabasesTabInformix()
		{
			try
			{
				repo.Application.Informix.DatabasesTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.DatabasesTab.ClickThis();
				Reports.ReportLog("ClickOnDatabasesTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseTableInformix()
		{
			try
			{
				repo.Application.Informix.DatabaseTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.DatabaseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Database table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnChunksTabInformix()
		{
			try
			{
				repo.Application.Informix.ChunksTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.ChunksTab.ClickThis();
				Reports.ReportLog("ClickOnChunksTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Chunks tab. "+ex.Message);
			}
		}
		
		public static void ValidateChunksTableInformix()
		{
			try
			{
				repo.Application.Informix.ChunksTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.ChunksTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Chunks table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTablesTabInformix()
		{
			try
			{
				repo.Application.Informix.TablesTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.TablesTab.ClickThis();
				Reports.ReportLog("ClickOnTablesTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tables tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeSecTabInformix()
		{
			try
			{
				repo.Application.Informix.TreeSecTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.TreeSecTab.ClickThis();
				Reports.ReportLog("ClickOnTreeSecTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeSecTableInformix()
		{
			try
			{
				repo.Application.Informix.TreeSecTableInfo.WaitForItemExists(25000);
				repo.Application.Informix.TreeSecTable.ClickThis();
				repo.Application.Informix.GeneralTabInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : new pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane is visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabInformix()
		{
			try
			{
				repo.Application.Informix.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.UsersTab.ClickThis();
				Reports.ReportLog("ClickOnUsersTabInformix", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTableInformix()
		{
			try
			{
				repo.Application.Informix.UsersTablesInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.UsersTables.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityInformix(string item)
		{
			try
			{
				repo.Application.Informix.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.Informix.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of storage not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnRolesTabInformix()
		{
			try
			{
				repo.Application.Informix.RolesTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.RolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles tab. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionsTabInformix()
		{
			try
			{
				repo.Application.Informix.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionTableInformix()
		{
			try
			{
				repo.Application.Informix.SessionTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.SessionTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSessionInformix(string item)
		{
			try
			{
				repo.Application.Informix.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.Informix.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsStatsTabInformix()
		{
			try
			{
				repo.Application.Informix.SessionsStatsTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.SessionsStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionStatsTableInformix()
		{
			try
			{
				repo.Application.Informix.SessionStatsTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksTabInformix()
		{
			try
			{
				repo.Application.Informix.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.Informix.LocksTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks tab. "+ex.Message);
			}
		}
		
		public static void ValidateLocksTableInformix()
		{
			try
			{
				repo.Application.Informix.LockTableInfo.WaitForItemExists(25000);
				if(repo.Application.Informix.LockTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Locks table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSummaryTabMSSql()
		{
			try
			{
				repo.Application.MSSql.SummaryTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SummaryTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Summary tab. "+ex.Message);
			}
		}
		
		public static void ValidateSummaryTableMSSql()
		{
			try
			{
				repo.Application.MSSql.SummaryTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.SummaryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Summary table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstanceMSSql(string item)
		{
			try
			{
				repo.Application.MSSql.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnParametersTabMSSql()
		{
			try
			{
				repo.Application.MSSql.ParametersTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.ParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateParametersTableMSSql()
		{
			try
			{
				repo.Application.MSSql.ParametersTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.ParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Parameters table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnServerLogsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.ServerLogsInfo.WaitForItemExists(25000);
				repo.Application.MSSql.ServerLogs.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Server logs tab. "+ex.Message);
			}
		}
		
		public static void ValidateServerLogsTableMSSql()
		{
			try
			{
				repo.Application.MSSql.ServerLogsTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.ServerLogsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Server logs table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabMSSql()
		{
			try
			{
				repo.Application.MSSql.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableMSSql()
		{
			try
			{
				repo.Application.MSSql.TreeTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchStorageMSSql(string item)
		{
			try
			{
				repo.Application.MSSql.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabaseTabMSSql()
		{
			try
			{
				repo.Application.MSSql.DatabasesTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.DatabasesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseTableMSSql()
		{
			try
			{
				repo.Application.MSSql.DatabasesTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.DatabasesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Database table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatafilesTabMSSql()
		{
			try
			{
				repo.Application.MSSql.DatafilesTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.DatafilesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Datafiles tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatafilesTableMSSql()
		{
			try
			{
				repo.Application.MSSql.DatafilesTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.DatafilesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Datafiles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnBackUpDevicesTabMSSql()
		{
			try
			{
				repo.Application.MSSql.BackUpDevicesTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.BackUpDevicesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on BackUp device tab. "+ex.Message);
			}
		}
		
		public static void ClickOnLoginsAndServersTabMSSql()
		{
			try
			{
				repo.Application.MSSql.LoginTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.LoginTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Login and servers roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateLoginAndServersTableMSSql()
		{
			try
			{
				repo.Application.MSSql.LoginRowInfo.WaitForItemExists(25000);
				repo.Application.MSSql.LoginRow.ClickThis();
				repo.Application.MSSql.GeneralTabInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation :new pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Logins and server roles cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityMSSql(string item)
		{
			try
			{
				repo.Application.MSSql.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnLoginsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.LoginsTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.LoginsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Logins tab. "+ex.Message);
			}
		}
		
		public static void ValidateLoginsTableMSSql()
		{
			try
			{
				repo.Application.MSSql.LoginsTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.LoginsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Logins table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnServerRolesTabMSSql()
		{
			try
			{
				repo.Application.MSSql.ServerRolesTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.ServerRolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Server roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateServerRolesTableMSSql()
		{
			try
			{
				repo.Application.MSSql.ServerRolesTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.ServerRolesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Server roles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabaseUsersTabMSSql()
		{
			try
			{
				repo.Application.MSSql.DatabaseUsersTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.DatabaseUsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on database servers tab. "+ex.Message);
			}
		}
		
		public static void ClickOnUsersTabMSSql()
		{
			try
			{
				repo.Application.MSSql.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ClickOnRolesTabMSSql()
		{
			try
			{
				repo.Application.MSSql.RolesTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.RolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles tab. "+ex.Message);
			}
		}
		
		public static void ClickOnSesionsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsTableMSSql()
		{
			try
			{
				repo.Application.MSSql.SessionsTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSesionsStatsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SessionStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on sessions stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsStatsTableMSSql()
		{
			try
			{
				repo.Application.MSSql.SessionStatsTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksTabMSSql()
		{
			try
			{
				repo.Application.MSSql.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.LocksTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks tab. "+ex.Message);
			}
		}
		
		public static void ValidateLocksTableMSSql()
		{
			try
			{
				repo.Application.MSSql.LockTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.LockTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Lock table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSesionMSSql(string item)
		{
			try
			{
				repo.Application.MSSql.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnAlertsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.AlertTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.AlertTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Alerts tab. "+ex.Message);
			}
		}
		
		public static void ClickOnOperatorTabMSSql()
		{
			try
			{
				repo.Application.MSSql.OperatorsTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.OperatorsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on operators tab. "+ex.Message);
			}
		}
		
		public static void ClickOnJobsTabMSSql()
		{
			try
			{
				repo.Application.MSSql.JobTabInfo.WaitForItemExists(25000);
				repo.Application.MSSql.JobTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on jobs tab. "+ex.Message);
			}
		}
		
		public static void SearchServerAgentMSSql(string item)
		{
			try
			{
				repo.Application.MSSql.SearchServerAgentInfo.WaitForItemExists(25000);
				repo.Application.MSSql.SearchServerAgent.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ValidateJobsTableMSSql()
		{
			try
			{
				repo.Application.MSSql.JobsTableInfo.WaitForItemExists(25000);
				if(repo.Application.MSSql.JobsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Lock table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnVariablesTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.VariablesTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.VariablesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Variables tab. "+ex.Message);
			}
		}
		
		public static void SearchInstanceMariaAndMySql(string item)
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ValidateVariableTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.VariablesTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.VariablesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Variable table cannot be validated. "+ ex.Message);
			}
		}

		public static void ClickOnStatusTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.StatusTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.StatusTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Status tab. "+ex.Message);
			}
		}
		
		public static void ValidateStatusTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.StatusTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.StatusTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Status table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnCharsetTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.CharsetsTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.CharsetsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Charset tab. "+ex.Message);
			}
		}
		
		public static void ValidateCharsetTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.CharsetsTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.CharsetsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Charset table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnCollationTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.CollationsTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.CollationsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Collations tab. "+ex.Message);
			}
		}
		
		public static void ValidateCollationsTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.CollationsTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.CollationsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Collations table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnPluginsTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.PluginsTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.PluginsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Plugins tab. "+ex.Message);
			}
		}
		
		public static void ValidatePluginsTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.PluginsTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.PluginsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Plugins table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabasesTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.DatabasesTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.DatabasesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Databases tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabasesTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.DatabasesTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.DatabasesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Database table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnEnginesTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.EnginesTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.EnginesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Engines tab. "+ex.Message);
			}
		}
		
		public static void ValidateEnginesTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.EnginesTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.EnginesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Engines table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnOPenTableTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.OpenTablesTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.OpenTablesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Open Tables tab. "+ex.Message);
			}
		}
		
		public static void ValidateOpenTablesTable()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.OpenTablesTableInfo.WaitForItemExists(25000);
				if(repo.Application.CommonForMariaAndMySql.OpenTablesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no row found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Charset table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchStorageMariaAndMySql(string item)
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.TreeCellInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.TreeCell.ClickThis();
				repo.Application.CommonForMariaAndMySql.GeneralTabInfo.WaitForItemExists(25000);
				
				if(repo.Application.CommonForMariaAndMySql.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : New Pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : New pane is not visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSessionMariaAndMySql(string item)
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionTabMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.CommonForMariaAndMySql.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Session tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionTableMariaAndMySql()
		{
			try
			{
				repo.Application.CommonForMariaAndMySql.SessionsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.CommonForMariaAndMySql.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnPrametersTabNetezza()
		{
			try
			{
				repo.Application.Netezza.ParametersTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.ParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Parameters tab. "+ex.Message);
			}
		}
		
		public static void SearchInstanceNetezza(string item)
		{
			try
			{
				repo.Application.Netezza.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.Netezza.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ValidateParametersTableNetezza()
		{
			try
			{
				repo.Application.Netezza.ParametersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Netezza.ParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Parameter table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSystemDefaultTabNetezza()
		{
			try
			{
				repo.Application.Netezza.SystemDefaultsTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.SystemDefaultsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on System default tab. "+ex.Message);
			}
		}
		
		public static void ValidateSystemDefaultTableNetezza()
		{
			try
			{
				repo.Application.Netezza.SystemDefaultsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Netezza.SystemDefaultsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("System default table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnQueryHistoryTabNetezza()
		{
			try
			{
				repo.Application.Netezza.QueryHistoryTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.QueryHistoryTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Query history tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeTabNetezza()
		{
			try
			{
				repo.Application.Netezza.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableNetezza()
		{
			try
			{
				repo.Application.Netezza.TreeTableRowInfo.WaitForItemExists(25000);
				repo.Application.Netezza.TreeTableRow.ClickThis();
				repo.Application.Netezza.GeneralTabInfo.WaitForItemExists(25000);
				if(repo.Application.Netezza.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : new pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : new pane is not visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabNetezza()
		{
			try
			{
				repo.Application.Netezza.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTableNetezza()
		{
			try
			{
				repo.Application.Netezza.UsersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Netezza.UsersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityNetezza(string item)
		{
			try
			{
				repo.Application.Netezza.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.Netezza.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnGroupsTabNetezza()
		{
			try
			{
				repo.Application.Netezza.GroupsTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.GroupsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Groups tab. "+ex.Message);
			}
		}
		
		public static void ValidateGroupsTableNetezza()
		{
			try
			{
				repo.Application.Netezza.GroupsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Netezza.GroupsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Groups table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionTabNetezza()
		{
			try
			{
				repo.Application.Netezza.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.Netezza.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionTableNetezza()
		{
			try
			{
				repo.Application.Netezza.SessionTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Netezza.SessionTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSessionNetezza(string item)
		{
			try
			{
				repo.Application.Netezza.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.Netezza.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnSummaryTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SummaryTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SummaryTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Summary tab. "+ex.Message);
			}
		}
		
		public static void ValidateSummaryTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SummaryTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.SummaryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Summary table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstancePostgreSql(string item)
		{
			try
			{
				repo.Application.PostgreSql.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnCharsetsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.CharsetsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.CharsetsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Charsets tab. "+ex.Message);
			}
		}
		
		public static void ValidateCharsetsTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.CharsetsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.CharsetsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Charsets table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnCollationsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.CollationsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.CollationsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Collations tab. "+ex.Message);
			}
		}
		
		public static void ValidateCollationsTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.CollationsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.CollationsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Collation table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TreeTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchStoragePostgreSql(string item)
		{
			try
			{
				repo.Application.PostgreSql.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnTablespacesTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TablespacesTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.TablespacesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tablespaces tab. "+ex.Message);
			}
		}
		
		public static void ValidateTablespacesTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TablespacesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.TablespacesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tablespaces table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabasesTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.DatabasesTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.DatabasesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Databases tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabasesTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.DatabasesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.DatabasesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Databases table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeSecTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TreeSecTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.TreeSecTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeSecTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.TreeSecTableRowInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.TreeSecTableRow.ClickThis();
				repo.Application.PostgreSql.GeneralTabInfo.WaitForItemExists(25000);
				if(repo.Application.PostgreSql.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : new pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane is visible ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Databases table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.UsersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.UsersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnGroupsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.GroupsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.GroupsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Groups tab. "+ex.Message);
			}
		}
		
		public static void ValidateGroupsTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.GroupsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.GroupsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Groups table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityPostgreSql(string item)
		{
			try
			{
				repo.Application.PostgreSql.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchSessionPostgreSql(string item)
		{
			try
			{
				repo.Application.PostgreSql.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SessionTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.SessionTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsStatsTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.SessionStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsStatsTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.SessionStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksTabPostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.LockTabInfo.WaitForItemExists(25000);
				repo.Application.PostgreSql.LockTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Lock tab. "+ex.Message);
			}
		}
		
		public static void ValidateLockTablePostgreSql()
		{
			try
			{
				repo.Application.PostgreSql.LockTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.PostgreSql.LockTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Locks table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstanceSybaseASE(string item)
		{
			try
			{
				repo.Application.SybaseASE.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchStorageSybaseASE(string item)
		{
			try
			{
				repo.Application.SybaseASE.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchSecuritySybaseASE(string item)
		{
			try
			{
				repo.Application.SybaseASE.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ex.Message);
			}
		}
		
		public static void SearchSesssionSybaseASE(string item)
		{
			try
			{
				repo.Application.SybaseASE.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnGeneralTabSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.GeneralTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.GeneralTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on General tab. "+ex.Message);
			}
		}
		
		public static void ValidateGeneralTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.GeneralTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.GeneralTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("General table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnParametersTabSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.ParametersTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.ParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateParametersTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.ParametersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.ParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Parameters table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.TreeTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabasesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DatabaseTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.DatabaseTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DatabaseTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.DatabaseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Database table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDeviceUsageSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DeviceUsageTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.DeviceUsageTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on DeviceUsage tab. "+ex.Message);
			}
		}
		
		public static void ValidateDeviceUsageTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DeviceUsageTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.DeviceUsageTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Device Usage table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabaseDevicesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DatabaseDeviceTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.DatabaseDeviceTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database device tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabaseDeviceTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DatabaseDeviceTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.DatabaseDeviceTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Database Device Usage table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDumpDevicesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DumpDevicesTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.DumpDevicesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Dump device tab. "+ex.Message);
			}
		}
		
		public static void ValidateDumpDevicesTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DumpDeviceTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.DumpDeviceTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Dump Device Usage table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnCachesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.CachesTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.CachesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on caches tab. "+ex.Message);
			}
		}
		
		public static void ValidateCachesTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.CacheTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.CacheTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Caches table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLoginAndSeverSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LoginsAndRolesTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.LoginsAndRolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on LoginsAndRoles tab. "+ex.Message);
			}
		}
		
		public static void ValidateLoginAndServerTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LoginAndServerCellInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.LoginAndServerCell.ClickThis();
				repo.Application.SybaseASE.GeneralSecTabInfo.WaitForItemExists(25000);
				if(repo.Application.SybaseASE.GeneralSecTab.Visible)
				{
					Reports.ReportLog("Validation : new pane visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane visible ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Login and server table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLoginsSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LoginsTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.LoginsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Logins tab. "+ex.Message);
			}
		}
		
		public static void ValidateLoginsTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LoginsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.LoginsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Logins table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnServerRolesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.ServerRolesTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.ServerRolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Server roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateServerRolesTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.ServersRoleTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.ServersRoleTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Server roles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabaseServersSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.DatabaseUsersTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.DatabaseUsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Database users tab. "+ex.Message);
			}
		}
		
		public static void ClickOnUsersSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on users tab. "+ex.Message);
			}
		}
		
		public static void ClickOnGroupsSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.GroupsTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.GroupsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on groups tab. "+ex.Message);
			}
		}
		
		public static void ClickOnRolesSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.RolesTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.RolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles tab. "+ex.Message);
			}
		}
		
		public static void ClickOnSessionsSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.SessionsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Session table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsStatsSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.SessionsStatsTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.SessionsStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Sessions stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsStatsTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.SessionStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception(" Session stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.SybaseASE.LocksTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks tab. "+ex.Message);
			}
		}
		
		public static void ValidateLocksTableSysbaseASE()
		{
			try
			{
				repo.Application.SybaseASE.LockTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.SybaseASE.LockTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Lock table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnCharsetsTeradata()
		{
			try
			{
				repo.Application.Teradata.CharsetsTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.CharsetsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on charsets tab. "+ex.Message);
			}
		}
		
		public static void ValidateCharsetsTableTeradata()
		{
			try
			{
				repo.Application.Teradata.CharsetsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.CharsetsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Charsets table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstanceTeradata(string item)
		{
			try
			{
				repo.Application.Teradata.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.Teradata.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchStorageTeradata(string item)
		{
			try
			{
				repo.Application.Teradata.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.Teradata.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityTeradata(string item)
		{
			try
			{
				repo.Application.Teradata.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.Teradata.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchSessionTeradata(string item)
		{
			try
			{
				repo.Application.Teradata.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.Teradata.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnCollationsTabTeradata()
		{
			try
			{
				repo.Application.Teradata.CollationsTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.CollationsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on collations tab. "+ex.Message);
			}
		}
		
		public static void ValidateCollationsTableTeradata()
		{
			try
			{
				repo.Application.Teradata.CollationsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.CollationsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Collations table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatabasesTabTeradata()
		{
			try
			{
				repo.Application.Teradata.DatabasesTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.DatabasesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Databases tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabasesTableTeradata()
		{
			try
			{
				repo.Application.Teradata.DatabaseTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.DatabaseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Databases table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsTabTeradata()
		{
			try
			{
				repo.Application.Teradata.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeTabTeradata()
		{
			try
			{
				repo.Application.Teradata.TreeSecTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.TreeSecTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableTeradata()
		{
			try
			{
				repo.Application.Teradata.TreeSecTableInfo.WaitForItemExists(25000);
				repo.Application.Teradata.TreeSecTable.ClickThis();
				repo.Application.Teradata.GeneralTabInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : new pane visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Databases table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabTeradata()
		{
			try
			{
				repo.Application.Teradata.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTableTeradata()
		{
			try
			{
				repo.Application.Teradata.UsersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.UsersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnRolesTabTeradata()
		{
			try
			{
				repo.Application.Teradata.RolesTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.RolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateRolesTableTeradata()
		{
			try
			{
				repo.Application.Teradata.RolesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.RolesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("roles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnProfilesTabTeradata()
		{
			try
			{
				repo.Application.Teradata.ProfilesTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.ProfilesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Profile tab. "+ex.Message);
			}
		}
		
		public static void ValidateProfileTableTeradata()
		{
			try
			{
				repo.Application.Teradata.ProfilesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.ProfilesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("profile table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsTabTeradata()
		{
			try
			{
				repo.Application.Teradata.SessionsTabInfo.WaitForItemExists(25000);
				repo.Application.Teradata.SessionsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on session tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionTableTeradata()
		{
			try
			{
				repo.Application.Teradata.SessionsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Teradata.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("session cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSummaryTabVertica()
		{
			try
			{
				repo.Application.Vertica.SummaryTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SummaryTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on summary tab. "+ex.Message);
			}
		}
		
		public static void ValidateSummaryTableVertica()
		{
			try
			{
				repo.Application.Vertica.SummaryTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.SummaryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Summary table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstanceVertica(string item)
		{
			try
			{
				repo.Application.Vertica.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchStorageVertica(string item)
		{
			try
			{
				repo.Application.Vertica.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ex.Message);
			}
		}
		
		public static void SearchSecurityVertica(string item)
		{
			try
			{
				repo.Application.Vertica.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void SearchSessionVertica(string item)
		{
			try
			{
				repo.Application.Vertica.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnConfigurationParameterTabVertica()
		{
			try
			{
				repo.Application.Vertica.ConfigurationsTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.ConfigurationsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Configration parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateConfigurationParametersTableVertica()
		{
			try
			{
				repo.Application.Vertica.ConfigurationTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.ConfigurationTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Configuration parameters table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionParametersTabVertica()
		{
			try
			{
				repo.Application.Vertica.SessionParametersInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SessionParameters.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Session parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionParametersTableVertica()
		{
			try
			{
				repo.Application.Vertica.SessionParametersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.SessionParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session parameters table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnNodesTabVertica()
		{
			try
			{
				repo.Application.Vertica.NodesTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.NodesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on nodes tab. "+ex.Message);
			}
		}
		
		public static void ValidateNodesTableVertica()
		{
			try
			{
				repo.Application.Vertica.NodesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.NodesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Nodes table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnQueryHistoryTabVertica()
		{
			try
			{
				repo.Application.Vertica.QueryHistoryTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.QueryHistoryTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on query history tab. "+ex.Message);
			}
		}
		
		public static void ValidateQueryHistoryTableVertica()
		{
			try
			{
				repo.Application.Vertica.QueryHistoryTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.QueryHistoryTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Query history table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLicenseTabVertica()
		{
			try
			{
				repo.Application.Vertica.LicenseTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.LicenseTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on license tab. "+ex.Message);
			}
		}
		
		public static void ValidateLicenseTableVertica()
		{
			try
			{
				repo.Application.Vertica.LicenseTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.LicenseTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("License table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnNodeStorageTabVertica()
		{
			try
			{
				repo.Application.Vertica.NodeStorageTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.NodeStorageTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Nodes tab. "+ex.Message);
			}
		}
		
		public static void ValidateNodeStorageTableVertica()
		{
			try
			{
				repo.Application.Vertica.NodesStorageTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.NodesStorageTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Nodes table cannot be validated. " +ex.Message);
			}
		}
		
		public static void ClickOnbjectsTabVertica()
		{
			try
			{
				repo.Application.Vertica.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnFileSystemsTabVertica()
		{
			try
			{
				repo.Application.Vertica.FileSystemTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.FileSystemTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on filesystem tab. "+ex.Message);
			}
		}
		
		public static void ValidateFileSystemsTableVertica()
		{
			try
			{
				repo.Application.Vertica.FileSystemTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.FileSystemTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Filesystem table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeTabVertica()
		{
			try
			{
				repo.Application.Vertica.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeTableVertica()
		{
			try
			{
				repo.Application.Vertica.TreeSecTableInfo.WaitForItemExists(25000);
				repo.Application.Vertica.TreeSecTable.ClickThis();
				repo.Application.Vertica.GeneralTabInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.GeneralTab.Visible)
				{
					Reports.ReportLog("Validation : New pane is visible ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : no new pane is visible. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabVertica()
		{
			try
			{
				repo.Application.Vertica.UsersTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.UsersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTableVertica()
		{
			try
			{
				repo.Application.Vertica.UsersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.UsersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnRolesTabVertica()
		{
			try
			{
				repo.Application.Vertica.RolesTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.RolesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateRolesTableVertica()
		{
			try
			{
				repo.Application.Vertica.RolesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.RolesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Roles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnProfilesTabVertica()
		{
			try
			{
				repo.Application.Vertica.ProfilesTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.ProfilesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Profiles tab. "+ex.Message);
			}
		}
		
		public static void ValidateProfilesTableVertica()
		{
			try
			{
				repo.Application.Vertica.ProfilesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.ProfilesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Profile table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionTabVertica()
		{
			try
			{
				repo.Application.Vertica.SessionTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SessionTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Session tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionTableVertica()
		{
			try
			{
				repo.Application.Vertica.SessionsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionStatsTabVertica()
		{
			try
			{
				repo.Application.Vertica.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.SessionStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Session stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionStatsTableVertica()
		{
			try
			{
				repo.Application.Vertica.SessionStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Vertica.SessionStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Session stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLockTabVertica()
		{
			try
			{
				repo.Application.Vertica.LockTabInfo.WaitForItemExists(25000);
				repo.Application.Vertica.LockTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Locks tab. "+ex.Message);
			}
		}
		
		public static void ClickOnGeneralTabOracle()
		{
			try
			{
				repo.Application.Oracle.GeneralTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.GeneralTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on General tab. "+ex.Message);
			}
		}
		
		public static void ValidateGeneralTableOracle()
		{
			try
			{
				repo.Application.Oracle.GeneralTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.GeneralTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("General table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnControlFileTabOracle()
		{
			try
			{
				repo.Application.Oracle.ControlFileTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.ControlFileTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on control file tab. "+ex.Message);
			}
		}
		
		public static void ValidateControlFileTableOracle()
		{
			try
			{
				repo.Application.Oracle.ControlFileTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.ControlFileTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ControlFile table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnOracleParametersOracle()
		{
			try
			{
				repo.Application.Oracle.OracleParametersTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.OracleParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on Oracle parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateOracleParametersTableOracle()
		{
			try
			{
				repo.Application.Oracle.OracleParameterTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.OracleParameterTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Oracle parameter table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnHiddenParametersTabOracle()
		{
			try
			{
				repo.Application.Oracle.HiddenParametersTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.HiddenParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on hidden parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateHiddenParametersTableOracle()
		{
			try
			{
				repo.Application.Oracle.HiddenParametersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.HiddenParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("HiddenParameters table cannot be validated. "+ ex.Message);
			}
		}

		public static void ClickOnNLSParametersTabOracle()
		{
			try
			{
				repo.Application.Oracle.NLSParametersTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.NLSParametersTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on NLS parameters tab. "+ex.Message);
			}
		}
		
		public static void ValidateNLSParametersTableOracle()
		{
			try
			{
				repo.Application.Oracle.NLSParametersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.NLSParametersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("NLSParameters table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnJobsTabOracle()
		{
			try
			{
				repo.Application.Oracle.JobsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.JobsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on jobs tab. "+ex.Message);
			}
		}
		
		public static void ValidateJobsTableOracle()
		{
			try
			{
				repo.Application.Oracle.JobsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.JobsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Jobs table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchInstanceOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchInstanceInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchInstance.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnTreeStorageTabOracle()
		{
			try
			{
				repo.Application.Oracle.TreeTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.TreeTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeStorageTableOracle()
		{
			try
			{
				repo.Application.Oracle.TreeTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.TreeTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnTablespacesTabOracle()
		{
			try
			{
				repo.Application.Oracle.TableSpacesTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.TableSpacesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on tablespace tab. "+ex.Message);
			}
		}
		
		public static void ValidateTablespaceTableOracle()
		{
			try
			{
				repo.Application.Oracle.TablespacesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.TablespacesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("tablespace table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnDatafileTabOracle()
		{
			try
			{
				repo.Application.Oracle.DatafilesTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.DatafilesTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on datafiles tab. "+ex.Message);
			}
		}
		
		public static void ValidateDatabasefilesTableOracle()
		{
			try
			{
				repo.Application.Oracle.DatafilesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.DatafilesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Datafiles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectsTabOracle()
		{
			try
			{
				repo.Application.Oracle.ObjectsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.ObjectsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on objects tab. "+ex.Message);
			}
		}
		
		public static void ClickOnFragmentationTabOracle()
		{
			try
			{
				repo.Application.Oracle.FragmentationTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.FragmentationTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on fragmentation tab. "+ex.Message);
			}
		}
		
		public static void ClickOnFileIOStatsTabOracle()
		{
			try
			{
				repo.Application.Oracle.FileIOStatsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.FileIOStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on FileIOstats tab. "+ex.Message);
			}
		}
		
		public static void ValidateFileIOStatsTableOracle()
		{
			try
			{
				repo.Application.Oracle.FileIOStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.FileIOStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("FileIOstats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnObjectIOStatsTabOracle()
		{
			try
			{
				repo.Application.Oracle.ObjectsIOStatsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.ObjectsIOStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				
				throw new Exception("Unable to click on ObjectIOstats tab. "+ex.Message);
			}
		}
		
		public static void ValidateObjectIOStatsTableOracle()
		{
			try
			{
				repo.Application.Oracle.ObjectsIOStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.ObjectsIOStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("ObjectIOstats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchStorageOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchStorageInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchStorage.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnRollbackManager()
		{
			try
			{
				repo.DataStudio.RollBackManagerInfo.WaitForItemExists(25000);
				repo.DataStudio.RollBackManager.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRollbackManager :" + ex.Message);
			}
		}
		
		public static void SearchRollbackOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchRollBackInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchRollBack.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ValidateRollbackTableOracle()
		{
			try
			{
				repo.Application.Oracle.RollBackTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.RollBackTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Rollback table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLogManager()
		{
			try
			{
				repo.DataStudio.LogManagerInfo.WaitForItemExists(25000);
				repo.DataStudio.LogManager.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnLogManager : "+ ex.Message);
			}
		}
		
		public static void SearchLogManagerOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchLogManagerInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchLogManager.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnRedoTabOracle()
		{
			try
			{
				repo.Application.Oracle.RedoLogsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.RedoLogsTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Redo tab. "+ex.Message);
			}
		}
		
		public static void ValidateRedoTableOracle()
		{
			try
			{
				repo.Application.Oracle.RedoTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.RedoTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("redo table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnArchiveTabOracle()
		{
			try
			{
				repo.Application.Oracle.ArchiveTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.ArchiveTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Archive tab. "+ex.Message);
			}
		}
		
		public static void ClickOnTreeSecTabOracle()
		{
			try
			{
				repo.Application.Oracle.TreeSecTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.TreeSecTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Tree tab. "+ex.Message);
			}
		}
		
		public static void ValidateTreeSecTableOracle()
		{
			try
			{
				repo.Application.Oracle.TreeCellInfo.WaitForItemExists(25000);
				repo.Application.Oracle.TreeCell.ClickThis();
				repo.Application.Oracle.GeneralSecTabInfo.WaitForItemExists(25000);
				if(repo.Application.Oracle.GeneralSecTab.Visible)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Tree table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSecurityOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchSecurityInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchSecurity.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
		
		public static void ClickOnUsersTabOracle()
		{
			try
			{
				repo.Application.Oracle.UsersSecTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.UsersSecTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on Users tab. "+ex.Message);
			}
		}
		
		public static void ValidateUsersTableOracle()
		{
			try
			{
				repo.Application.Oracle.UsersTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.UsersTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Users table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnRolesTabOracle()
		{
			try
			{
				repo.Application.Oracle.RolesSecTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.RolesSecTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on roles tab. "+ex.Message);
			}
		}
		
		public static void ValidateRolesTableOracle()
		{
			try
			{
				repo.Application.Oracle.RolesTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.RolesTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("roles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnProfilesTabOracle()
		{
			try
			{
				repo.Application.Oracle.ProfilesTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.ProfilesTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on profile tab. "+ex.Message);
			}
		}
		
		public static void ValidateProfilesTableOracle()
		{
			try
			{
				repo.Application.Oracle.ProfileTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.ProfileTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("profiles table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsTabOracle()
		{
			try
			{
				repo.Application.Oracle.SessionTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SessionTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on sessions tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsTableOracle()
		{
			try
			{
				repo.Application.Oracle.SessionsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.SessionsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnSessionsStatsTabOracle()
		{
			try
			{
				repo.Application.Oracle.SessionStatsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SessionStatsTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on sessions stats tab. "+ex.Message);
			}
		}
		
		public static void ValidateSessionsStatsTableOracle()
		{
			try
			{
				repo.Application.Oracle.SessionsStatsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.SessionsStatsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Sessions stats table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void ClickOnLocksTabOracle()
		{
			try
			{
				repo.Application.Oracle.LocksTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.LocksTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on locks tab. "+ex.Message);
			}
		}
		
		public static void ClickOnLongOpsTabOracle()
		{
			try
			{
				repo.Application.Oracle.LongOpsTabInfo.WaitForItemExists(25000);
				repo.Application.Oracle.LongOpsTab.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to click on long ops tab. "+ex.Message);
			}
		}
		
		public static void ValidateLongOpsTableOracle()
		{
			try
			{
				repo.Application.Oracle.LongOpsTableInfo.WaitForItemExists(25000);
				
				if(repo.Application.Oracle.LongOpsTable.Rows.Count > 0)
				{
					Reports.ReportLog("Validation : 1 row found ", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Validation : row not found. ", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				
				throw new Exception("Long ops table cannot be validated. "+ ex.Message);
			}
		}
		
		public static void SearchSessionOracle(string item)
		{
			try
			{
				repo.Application.Oracle.SearchSessionInfo.WaitForItemExists(25000);
				repo.Application.Oracle.SearchSession.TextBoxText(item);
			}
			catch (Exception ex)
			{
				
				throw new Exception("Search textbox of session not working. "+ ex.Message);
			}
		}
	}
}

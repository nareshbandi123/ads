using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using Ranorex;
using Ranorex.Core;

namespace ADSAutomationPhaseII.TC_10535
{
	public static class Steps
	{
		public static TC10535Repo repo = TC10535Repo.Instance;
		public static string TC1_10535_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10535_Path"].ToString();
		public const string DATABASE_SCHEMA_AND_DATA_EXPORTER = "Database Schema and Data Exporter";
		public const string SCHEMA_COMPARE = "Schema Compare";
		
		#region "10535 & 10536  TC1- Steps"
		
		public static void CloseServerTab()
		{
			try 
			{
				repo.Application.F1MenuInfo.WaitForExists(new Ranorex.Duration(1000));
				if (repo.Application.F1Menu.Checked)
				{	
					repo.Application.F1Menu.ClickThis();
					Reports.ReportLog("Close Server Tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseServerTab : " + ex.Message);
			}			
		}
		
		public static void ClickOnProjectTab()
		{
			try 
			{
				repo.Application.F3MenuInfo.WaitForExists(new Ranorex.Duration(1000));
				if (!repo.Application.F3Menu.Checked) 
					repo.Application.F3Menu.ClickThis();
				Reports.ReportLog("Click on F3 tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				if(repo.Application.TemplateTreeInfo.Exists(1000))
					RemoveProject();
				
				Reports.ReportLog("Remove if the project exists already", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnProjectTab : " + ex.Message);
			}
			
		}
		
		public static void RightClickProjectTab()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.Application.ProjectsTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Right click on projects tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickProjectTab : " + ex.Message);
			}
			
		}
		
		public static void SelectNewProject()
		{
			try 
			{
				repo.DataStudio.NewProjectMenu.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewProject : " + ex.Message);
			}
			
		}
		
		public static void SelectDataSchemaAndDataExporterTemplate()
		{
			try 
			{
				repo.NewProject.DatabaseSchemaAndDataImportListItem.ClickThis();
				Reports.ReportLog("Select DataSchema And DataExporter Template", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectDataSchemaAndDataExporterTemplate : " + ex.Message);
			}
			
		}		
		
		public static void SelectSchemaCompare()
		{
			try 
			{
				repo.NewProject.SchemaCompare.ClickThis();
				Reports.ReportLog("Select SchemaCompare", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSchemaCompare : " + ex.Message);
			}
			
		}
		
		public static void BrowseFolderLocation()
		{
			try 
			{
				repo.NewProject.BrowseButton.ClickThis();
				Reports.ReportLog("browse button click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.SelectFolder.FolderPathTextbox.TextBoxText(TC1_10535_Path);
				Reports.ReportLog("Enter file path", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.SelectFolder.SelectButton.ClickThis();
				Reports.ReportLog("Select button click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : BrowseFolderLocation : " + ex.Message);
			}
			
		}
		
		public static void ClickOk()
		{
			try 
			{
				repo.NewProject.OkButton.ClickThis();
				Reports.ReportLog("New Database Schema template created successfully", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOk : " + ex.Message);
			}
			
		}
		
		public static void ValidateTemplateFromNewProject()
		{
			try 
			{
				repo.Application.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.Application.TemplateTree.Expand();
				Reports.ReportLog("Schema tree is expanded", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.AquaScriptsInfo, "Validate AquaScripts Available");				
				Reports.ReportLog("Schema tree is contains AquaScripts", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.ServersInfo, "Validate Servers Available");				
				Reports.ReportLog("Schema tree is contains Servers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.UserFilesInfo, "Validate UserFiles Available");				
				Reports.ReportLog("Schema tree is contains UserFiles", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTemplateFromNewProject : " + ex.Message);
			}
			
		}
		
		public static void ValidateSchemaCompareTemplateFromNewProject()
		{
			try 
			{
				repo.Application.SchemaCompareTemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.Application.SchemaCompareTemplateTree.Expand();
				Reports.ReportLog("Schema tree is expanded", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.AquaScriptsInfo, "Validate AquaScripts Available");				
				Reports.ReportLog("Schema tree is contains AquaScripts", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.ServersInfo, "Validate Servers Available");				
				Reports.ReportLog("Schema tree is contains Servers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				Ranorex.Validate.Exists(repo.Application.UserFilesInfo, "Validate UserFiles Available");				
				Reports.ReportLog("Schema tree is contains UserFiles", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSchemaCompareTemplateFromNewProject : " + ex.Message);
			}
			
		}
		
		public static void ValidateNewProjectFile()
		{
			try 
			{
				repo.Application.AquaScriptsInfo.WaitForExists(new Duration(1000));
				repo.Application.AquaScripts.Expand();
				Ranorex.Validate.Exists(repo.Application.NewProjectFileInfo, "Validate NewProjectFile Available");
				Reports.ReportLog("AquaScripts' is expanded and contains 'Database Schema and Data Exporter.xjs' file", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNewProjectFile : " + ex.Message);
			}
		}
		
		public static void ValidateNewSchemaCompareFile()
		{
			try 
			{
				repo.Application.AquaScriptsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.Application.AquaScripts.Expand();
				Ranorex.Validate.Exists(repo.Application.SchemaCompareFile, "Validate NewProjectFile Available");
				Reports.ReportLog("AquaScripts' is expanded and contains 'SchemaCompare.xjs' file", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateNewSchemaCompareFile : " + ex.Message);
			}
		}
		
		public static void RemoveProject()
		{
			try 
			{
				TreeItem treeItem = null;
				try {repo.Application.TemplateTreeInfo.WaitForExists(new Duration(1000)); treeItem = repo.Application.TemplateTree;} catch {}
				try {repo.Application.SchemaCompareTemplateTreeInfo.WaitForExists(new Duration(1000)); treeItem = repo.Application.SchemaCompareTemplateTree;} catch {}
				Ranorex.Mouse.Click(treeItem, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Right click schema compare template", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.DataStudio.RemoveMenu.ClickThis();
				Reports.ReportLog("Remove click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				if(repo.RemoveWindow.SelfInfo.Exists(new Duration(1000)))
				{
					repo.RemoveWindow.YesButtonInfo.WaitForExists(new Duration(1000));
					repo.RemoveWindow.YesButton.ClickThis();
					Reports.ReportLog("Confirm remove click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveProject : " + ex.Message);
			}
		}
		
		public static void OpenServerTab()
		{
			try 
			{
				if(!repo.Application.F1Menu.Checked)
					repo.Application.F1Menu.ClickThis();
				Reports.ReportLog("Open Server tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenServerTab : " + ex.Message);
			}
		}
		
		public static void CloseProjectTab()
		{
			try 
			{
				if(repo.Application.F3Menu.Checked)
					repo.Application.F3Menu.ClickThis();
				Reports.ReportLog("Close project tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseProjectTab : " + ex.Message);
			}
		}
		
		public static void CloseTab()
		{
			try 
        	{
        		TabPage tabpage = null;
        		try{ repo.Application.TabInfo.WaitForExists(new Duration(1000) ); tabpage = repo.Application.Tab; }catch{}
        		try{ repo.Application.SchemaTabInfo.WaitForExists(new Duration(1000) ); tabpage = repo.Application.SchemaTab; }catch{}
				Ranorex.Mouse.Click(tabpage, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Right click schema tab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.DataStudio.TabCloseMenu.ClickThis();
				Reports.ReportLog("Close tab click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseProjectTab : " + ex.Message);
        	}
		}
		
		public static void Cleanup(string template)
		{
			try 
			{
				Commons.Common.DeleteFolder(TC1_10535_Path + template);	
				Reports.ReportLog("Delete files and folders to cleanup", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
        	{
        		throw new Exception("Failed : Cleanup : " + ex.Message);
        	}
		}
		
		#endregion
		
		#region "TC2 - Steps"
		
		public enum DatabaseTypes
		{
			Amazon,
			ApacheCassandra,
			ApacheDerby,
			DB2LUW,
			Greenplum,
			Informix,
			MariaDB,
			MongoDB,
			MSSQLServer,
			MySQL,
			Netezza,
			Oracle,
			PostgreSQL,
			SybaseAnywhere,
			SybaseASE,
			SybaseIQ,
			TeradataDatabase,
			Vertica,
			SAPHana,
			MSSQLAzure
		}
		
		public static void CloseERDWindow()
		{
			try 
			{
				if(repo.EntityRelationshipDiagram.SelfInfo.Exists(new Duration(5000)))
				{
					repo.EntityRelationshipDiagram.Self.Close();
					if(repo.FileModified.SelfInfo.Exists(new Duration(5000)))
					{
						repo.FileModified.DiscardButton.ClickThis();
					}
				}
			} 
			catch (Exception) 
			{
				
				throw;
			}	
		}
		
		static void ExplicitWait()
		{
			System.Threading.Thread.Sleep(300);
		}
			
		static void ExplicitLongWait()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		public static void ClickOnERModelerMenu()
		{
			try
			{
				CloseERDWindow();
				repo.Application.Self.Activate();
				repo.Application.ERModelerMenuInfo.WaitForItemExists(10000);
				repo.Application.ERModelerMenu.ClickThis();
				ExplicitWait();
				Reports.ReportLog("ER Model Menu click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnERModelerMenu : " + ex.Message);
			}			
		}
		
		public static void SelectNew()
		{
			try
			{
				
				repo.SunAwtWindow.NewInfo.WaitForItemExists(10000);
				repo.SunAwtWindow.New.ClickThis();
				ExplicitWait();
				Reports.ReportLog("New Entity Relationship Diagram window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectNew : " + ex.Message);
			}
		}
		
		public static void SelectOpen()
		{
			try
			{
				repo.SunAwtWindow.OpenInfo.WaitForItemExists(1000);
				repo.SunAwtWindow.Open.ClickThis();
				ExplicitWait();
				Reports.ReportLog("Open ER Model", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectOpen : " + ex.Message);
			}
		}
		
		public static void SelectDataTypeAndVersion(DatabaseTypes dbTypes, string version = "")
		{
			try
			{
				if(repo.NewERDDatatype.SelfInfo.Exists(new Ranorex.Duration(30000)))
				{	
					ExplicitLongWait();
					switch (dbTypes) 
		        	{
						case DatabaseTypes.Amazon:
							repo.NewERDDatatype.Amazon.ClickThis();				
							repo.NewERDDatatype.AmazonVersion.V1.ClickThis();
							break;
						case DatabaseTypes.ApacheCassandra:
							repo.NewERDDatatype.ApacheCassandra.ClickThis();
							if(version == "37")
								repo.NewERDDatatype.Cassandra.V37.ClickThis();
							else
								repo.NewERDDatatype.Cassandra.V22.ClickThis();
							break;
						case DatabaseTypes.ApacheDerby:
							repo.NewERDDatatype.ApacheDerby.ClickThis();
							if(version == "1014")
								repo.NewERDDatatype.Derby.V1014.ClickThis();
							else
								repo.NewERDDatatype.Derby.V1013.ClickThis();
							break;
						case DatabaseTypes.DB2LUW:
							repo.NewERDDatatype.DB2LUW.ClickThis();
							if(version == "111")
								repo.NewERDDatatype.DB2.V111.ClickThis();
							else
								repo.NewERDDatatype.DB2.V105.ClickThis();
							break;
						case DatabaseTypes.Greenplum :
							repo.NewERDDatatype.Greenplum.ClickThis();
							if(version == "5")
								repo.NewERDDatatype.GreenplumDB.V5.ClickThis();
							else
								repo.NewERDDatatype.GreenplumDB.V4312.ClickThis();
							break;
						case DatabaseTypes.Informix:
							repo.NewERDDatatype.Informix.ClickThis();
							if(version == "117")
								repo.NewERDDatatype.InformixDB.V117.ClickThis();
							else
								repo.NewERDDatatype.InformixDB.V121.ClickThis();
							break;
						case DatabaseTypes.MariaDB:
							repo.NewERDDatatype.MariaDB.ClickThis();
							repo.NewERDDatatype.Maria10XDB.V102.ClickThis();
							break;
						case DatabaseTypes.MongoDB:
							repo.NewERDDatatype.MongoDB.ClickThis();
							if(version == "341")
								repo.NewERDDatatype.MongoXDB.V341.ClickThis();
							else
								repo.NewERDDatatype.MongoXDB.V321.ClickThis();
							break;
						case DatabaseTypes.MSSQLAzure:
							repo.NewERDDatatype.MSSQLAzure.ClickThis();
							repo.NewERDDatatype.MSAzureDB.V12.ClickThis();
							break;						
						case DatabaseTypes.MSSQLServer:
							repo.NewERDDatatype.MSSQLServer.ClickThis();
							if(version == "2017")
								repo.NewERDDatatype.MSSQLDB.V2017.ClickThis();
							else
								repo.NewERDDatatype.MSSQLDB.V2016.ClickThis();
							break;
						case DatabaseTypes.MySQL:
							repo.NewERDDatatype.MySQL.ClickThis();
							if(version == "8")
								repo.NewERDDatatype.MySQLDB.V8.ClickThis();
							else
								repo.NewERDDatatype.MySQLDB.V57.ClickThis();
							break;
						case DatabaseTypes.Netezza:
							repo.NewERDDatatype.Netezza.ClickThis();
							repo.NewERDDatatype.Netteza.V72.ClickThis();
							break;
						case DatabaseTypes.Oracle:
							repo.NewERDDatatype.Oracle.ClickThis();
							if(version == "12")
								repo.NewERDDatatype.OracleDB.V12.ClickThis();
							else
								repo.NewERDDatatype.OracleDB.V11.ClickThis();
							break;
						case DatabaseTypes.PostgreSQL:
							repo.NewERDDatatype.PostgreSQL.ClickThis();
							if(version == "10")
								repo.NewERDDatatype.PostgreSQLDB.V10.ClickThis();
							else
								repo.NewERDDatatype.PostgreSQLDB.V96.ClickThis();
							break;
						case DatabaseTypes.SAPHana:
							repo.NewERDDatatype.SAPHana.ClickThis();
							repo.NewERDDatatype.SAPHanaDB.V2.ClickThis();
							break;
						case DatabaseTypes.SybaseAnywhere:
							repo.NewERDDatatype.SybaseAnywhere.ClickThis();
							if(version == "17")
								repo.NewERDDatatype.SybaseAny.V17.ClickThis();
							else
								repo.NewERDDatatype.SybaseAny.V16.ClickThis();
							break;
						case DatabaseTypes.SybaseASE:
							repo.NewERDDatatype.SybaseASE.ClickThis();
							if(version == "16")
								repo.NewERDDatatype.SybaseASEDB.V16.ClickThis();
							else
								repo.NewERDDatatype.SybaseASEDB.V157.ClickThis();
							break;
						case DatabaseTypes.SybaseIQ:
							repo.NewERDDatatype.SybaseIQ.ClickThis();
							if(version == "16")
								repo.NewERDDatatype.SybaseIQDB.V16.ClickThis();
							else
								repo.NewERDDatatype.SybaseIQDB.V154.ClickThis();
							break;
						case DatabaseTypes.TeradataDatabase:
							repo.NewERDDatatype.TeradataDatabase.ClickThis();
							if(version == "1620")
								repo.NewERDDatatype.Teradata.V1620.ClickThis();
							else
								repo.NewERDDatatype.Teradata.V1510.ClickThis();
							break;
						case DatabaseTypes.Vertica:
							repo.NewERDDatatype.Vertica.ClickThis();
							if(version == "8")
								repo.NewERDDatatype.VerticaDB.V8.ClickThis();
							else
								repo.NewERDDatatype.VerticaDB.V91.ClickThis();						
							break;
						default:        			
	        			break;
					}
				}
				else
				{
					SelectNew();
					SelectDataTypeAndVersion(dbTypes, version);
				}
				Reports.ReportLog("Database Type & Version Selected", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.NewERDDatatype.OkButtonInfo.WaitForExists(100000);
				repo.NewERDDatatype.OkButton.ClickThis();
				repo.EntityRelationshipDiagram.Self.Activate();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : Database Type & Version Selected : " + ex.Message);
			}
		}
		
		public static void ValidateTree(bool Collections, bool Tables, bool views, bool Relationship, bool Notes)
		{
			try
			{
				/*if(repo.EntityRelationshipDiagram.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					if(Tables) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.TablesInfo, "Validate Tables exists in tree");
					if(views) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.ViewsInfo, "Validate Tables views in tree");
					if(Relationship) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.RelationshipsInfo, "Validate Tables Relationship in tree");
					if(Notes) Ranorex.Validate.Exists(repo.EntityRelationshipDiagram.NotesInfo, "Validate Tables notes in tree");
				}
				else
				{
					if(repo.NewERDDatatype.OkButtonInfo.Exists(new Ranorex.Duration(1000)))
					{
						repo.NewERDDatatype.OkButton.ClickThis();
						ValidateTree(Collections, Tables,views, Relationship, Notes);
					}
				}
				Reports.ReportLog("Validate Tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);*/
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ValidateTree : " + ex.Message);
			}
		}
		
		public static void RightClickOnTables()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(30000);
				repo.EntityRelationshipDiagram.TablesInfo.WaitForItemExists(5000);
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Tables, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("Right Click On Tables", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnTables : " + ex.Message);
			}
		}
		
		public static void RightClickOnCollections()
		{
			try 
			{	
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(30000);
				repo.EntityRelationshipDiagram.CollectionsInfo.WaitForItemExists(5000);
				Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collections, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				ExplicitWait();
				Reports.ReportLog("Right Click On Collections", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnCollections : " + ex.Message);
			}
		}
		
		public static void CreateNewTable()
		{
			try 
			{	
				repo.SunAwtWindow.NewTableInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NewTable.ClickThis();
				Reports.ReportLog("Create New Table Click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateNewTable : " + ex.Message);
			}
		}
		
		public static void CreateNewCollection()
		{
			try 
			{	
				repo.SunAwtWindow.NewCollectionInfo.WaitForItemExists(30000);
				repo.SunAwtWindow.NewCollection.ClickThis();
				Reports.ReportLog("Create New Collection Click", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateNewCollection : " + ex.Message);
			}
		}
		
		public static void RightClickOnTable1()
		{
			try 
			{	
				if(repo.EntityRelationshipDiagram.Table1Info.Exists(3000))
				{
					repo.EntityRelationshipDiagram.Table1Info.WaitForItemExists(30000);
					repo.EntityRelationshipDiagram.Table1.ClickThis();
					Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Table1, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
					Reports.ReportLog("Parent Table created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					ExplicitWait();
				}
				else
				{
					RightClickOnTables();
        			CreateNewTable();
        			RightClickOnTable1();
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnTable1 : " + ex.Message);
			}
		}
		
		public static void RightClickOnTable2()
		{
			try 
			{	
				if(repo.EntityRelationshipDiagram.Table2Info.Exists(3000))
				{
					repo.EntityRelationshipDiagram.Table2Info.WaitForItemExists(30000);
					repo.EntityRelationshipDiagram.Table2.ClickThis();
					Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Table2, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
					Reports.ReportLog("Child Table created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					ExplicitWait();
				}
				else
				{
					RightClickOnTables();
        			CreateNewTable();
        			RightClickOnTable2();
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnTable2 : " + ex.Message);
			}
		}
		
		public static void RightClickOnCollection1()
		{
			try 
			{
				if(repo.EntityRelationshipDiagram.Collection1Info.Exists(3000))
				{
					repo.EntityRelationshipDiagram.Collection1Info.WaitForItemExists(30000);				
					repo.EntityRelationshipDiagram.Collection1.ClickThis();
					Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collection1, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
					Reports.ReportLog("Parent Collection created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					System.Threading.Thread.Sleep(500);
				}
				else
				{
					RightClickOnCollections();
					CreateNewCollection();
					RightClickOnCollection1();
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnCollection1 : " + ex.Message);
			}
		}
		
		public static void RightClickOnCollection2()
		{
			try 
			{
				if(repo.EntityRelationshipDiagram.Collection2Info.Exists(3000))
				{
					repo.EntityRelationshipDiagram.Collection2Info.WaitForItemExists(30000);							
					repo.EntityRelationshipDiagram.Collection2.ClickThis();
					Ranorex.Mouse.Click(repo.EntityRelationshipDiagram.Collection2, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
					Reports.ReportLog("Child Collection created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
					ExplicitWait();
				}
				else
				{
					RightClickOnCollections();
					CreateNewCollection();
					RightClickOnCollection2();
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickOnCollection2 : " + ex.Message);
			}
		}
		
		public static void SelectProperties()
		{
			try
			{
				repo.SunAwtWindow.PropertiesInfo.WaitForExists(new Ranorex.Duration(30000));
				repo.SunAwtWindow.Properties.ClickThis();
				Reports.ReportLog("Select Properties", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectProperties : " + ex.Message);
			}
		}
		
		public static void EnterParentTableName()
		{
			try
			{
				if(repo.TableProperties.TableNameTextboxInfo.Exists(new Ranorex.Duration(5000)))
				{
					repo.TableProperties.TableNameTextbox.TextBoxText("ads_ParentTable");
					////Validate.IsTrue(repo.TableProperties.TableNameTextbox.TextValue == "ads_ParentTable");
				}
				else
				{
					RightClickOnTable1();
					SelectProperties();
					EnterParentTableName();
				}
				Reports.ReportLog("Enter ParentTable Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				repo.TableProperties.Self.Close();
				throw new Exception("Failed : EnterParentTableName : " + ex.Message);
			}
		}
		
		public static void EnterParentCollectionName()
		{
			try
			{
				if(repo.CollectionProperties.CollectionNameTextBoxInfo.Exists(new Ranorex.Duration(5000)))
				{
					repo.CollectionProperties.CollectionNameTextBox.TextBoxText("ads_ParentTable");
					//Validate.IsTrue(repo.CollectionProperties.CollectionNameTextBox.TextValue == "ads_ParentTable");
				}
				else
				{
					RightClickOnCollection1();
					SelectProperties();
					EnterParentCollectionName();
				}
				Reports.ReportLog("Enter ParentCollection Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				repo.CollectionProperties.Self.Close();
				throw new Exception("Failed : EnterParentCollectionName : " + ex.Message);
			}
		}
		
		public static void EnterChildTableName()
		{
			try
			{
				if(repo.TableProperties.TableNameTextboxInfo.Exists(new Ranorex.Duration(5000)))
				{
					repo.TableProperties.TableNameTextbox.TextBoxText("ads_ChildTable");
					//Validate.IsTrue(repo.TableProperties.TableNameTextbox.TextValue == "ads_ChildTable");
				}
				else
				{
					RightClickOnTable2();
					SelectProperties();
					EnterChildTableName();
				}
				Reports.ReportLog("Enter ChildTable Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				repo.TableProperties.Self.Close();
				throw new Exception("Failed : EnterChildTableName : " + ex.Message);
			}
		}
		
		public static void EnterChildCollectionName()
		{
			try
			{
				if(repo.CollectionProperties.CollectionNameTextBoxInfo.Exists(new Ranorex.Duration(5000)))
				{
					repo.CollectionProperties.CollectionNameTextBox.TextBoxText("ads_ChildTable");
					//Validate.IsTrue(repo.CollectionProperties.CollectionNameTextBox.TextValue == "ads_ChildTable");
				}
				else
				{
					RightClickOnCollection2();
					SelectProperties();
					EnterChildCollectionName();
				}
				Reports.ReportLog("Enter ChildCollection Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				ExplicitWait();
			}
			catch(Exception ex)
			{
				repo.CollectionProperties.Self.Close();
				throw new Exception("Failed : EnterChildCollectionName : " + ex.Message);
			}
		}
		
		public static void CreateColumns()
		{
			try
			{
				repo.TableProperties.Row1Column1.DoubleClick();
				ExplicitWait();
				repo.TableProperties.Row1Column1.PressKeys("ID");
				/*Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				//Validate.IsTrue(repo.TableProperties.Row1Column1.Text.Contains("ID"));
				
				repo.TableProperties.Row1Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row1Column2.PressKeys("int");
				//Validate.IsTrue(repo.TableProperties.Row1Column2.Text.Contains("int"));
				
				repo.TableProperties.Row1Column4.DoubleClick();
				System.Threading.Thread.Sleep(200);
				if(repo.TableProperties.Row1Column4.Text == "true")
					repo.TableProperties.Row1Column4.Click();
				//Validate.IsTrue(repo.TableProperties.Row1Column4.Text.Contains("true"));
				
				repo.TableProperties.Row2Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row2Column1.PressKeys("Name");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				//Validate.IsTrue(repo.TableProperties.Row2Column1.Text.Contains("Name"));
				
				repo.TableProperties.Row2Column3.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row2Column3.PressKeys("50");
				//Validate.IsTrue(repo.TableProperties.Row2Column3.Text.Contains("50"));
				
				repo.TableProperties.Row3Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row3Column1.PressKeys("DOB");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				//Validate.IsTrue(repo.TableProperties.Row3Column1.Text.Contains("DOB"));
				
				repo.TableProperties.Row3Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row3Column2.PressKeys("Date");
				//Validate.IsTrue(repo.TableProperties.Row3Column2.Text.Contains("Date"));
				
				repo.TableProperties.Row4Column1.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row4Column1.PressKeys("Active");
				//Validate.IsTrue(repo.TableProperties.Row4Column1.Text.Contains("Active"));
				
				repo.TableProperties.Row4Column2.DoubleClick();
				System.Threading.Thread.Sleep(200);
				repo.TableProperties.Row4Column2.PressKeys("bool");
				Reports.ReportLog("Active Column Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);*/
				
				repo.TableProperties.OKButton.ClickThis();
				
				Reports.ReportLog("Columns added to the Table and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				repo.TableProperties.Self.Close();
				throw new Exception("Failed : CreateColumns : " + ex.Message);
			}
		}
		
		public static void CreateCollectionColumns()
		{
			try
			{
				repo.CollectionProperties.Row1Column1.DoubleClick();
				repo.CollectionProperties.Row1Column1.PressKeys("ID");				
				/*Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row1Column2.DoubleClick();
				repo.CollectionProperties.Row1Column2.PressKeys("int");
				
				repo.CollectionProperties.Row1Column4.DoubleClick();
				if(repo.CollectionProperties.Row1Column4.Text == "true")
					repo.CollectionProperties.Row1Column4.Click();

				//Validate.IsTrue(repo.CollectionProperties.Row1Column1.Text.Contains("ID"));
				Reports.ReportLog("ID Column Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				
				repo.CollectionProperties.Row2Column1.DoubleClick();
				repo.CollectionProperties.Row2Column1.PressKeys("Name");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row2Column3.DoubleClick();
				repo.CollectionProperties.Row2Column3.PressKeys("50");
				
				//Validate.IsTrue(repo.CollectionProperties.Row2Column1.Text.Contains("Name"));
				Reports.ReportLog("Name Column Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				
				repo.CollectionProperties.Row3Column1.DoubleClick();
				repo.CollectionProperties.Row3Column1.PressKeys("DOB");
				Ranorex.Keyboard.Press(Ranorex.Keyboard.ToKey("Enter"), Ranorex.Keyboard.DefaultScanCode, Ranorex.Keyboard.DefaultKeyPressTime, 1, true);
				
				repo.CollectionProperties.Row3Column2.DoubleClick();
				repo.CollectionProperties.Row3Column2.PressKeys("Date");
				
				//Validate.IsTrue(repo.CollectionProperties.Row3Column1.Text.Contains("DOB"));
				Reports.ReportLog("DOB Column Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				
				repo.CollectionProperties.Row4Column1.DoubleClick();
				repo.CollectionProperties.Row4Column1.PressKeys("Active");
				
				repo.CollectionProperties.Row4Column2.DoubleClick();
				repo.CollectionProperties.Row4Column2.PressKeys("bool");
				
				//Validate.IsTrue(repo.CollectionProperties.Row4Column1.Text.Contains("Active"));
				Reports.ReportLog("Active Column Created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);*/
				
				repo.CollectionProperties.OKButton.ClickThis();
				
				Reports.ReportLog("Columns added to the Table and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				repo.CollectionProperties.Self.Close();
				throw new Exception("Failed : CreateCollectionColumns : " + ex.Message);
			}
		}
		
		public static void EditColumns()
		{
			try
			{
				ExplicitLongWait();
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Tables.FindSingle("//treeitem[@text='ads_ParentTable']");
				ExplicitLongWait();
				if(ads_ParentTable == null) throw new Exception("Failed : EditColumns : ads_ParentTable does not found");
				ads_ParentTable.EnsureVisible();
				
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				SelectProperties();
				
				if(repo.TableProperties.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.TableProperties.Row1Column1.DoubleClick();
					repo.TableProperties.Row1Column1.PressKeys("EMPID");
					
					//Validate.IsTrue(repo.TableProperties.Row1Column1.Text.Contains("EMPID"));
					
					repo.TableProperties.OKButton.ClickThis();
					
					Reports.ReportLog("Column Mdified from ID to EMPID", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					EditColumns();
				}
				
				Reports.ReportLog("Columns Edited and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				repo.TableProperties.Self.Close();
				throw new Exception("Failed : EditColumns : " + ex.Message);
			}
		}
		
		public static void EditCollectionColumns()
		{
			try
			{
				ExplicitLongWait();
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Collections.FindSingle("//treeitem[@text='ads_ParentTable']");
				ExplicitLongWait();
				if(ads_ParentTable == null) throw new Exception("Failed : EditCollectionColumns : ads_ParentTable does not found");
				ads_ParentTable.EnsureVisible();
				
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				SelectProperties();
				
				if(repo.CollectionProperties.SelfInfo.Exists(new Ranorex.Duration(1000)))
				{
					repo.CollectionProperties.Row1Column1.DoubleClick();
					repo.CollectionProperties.Row1Column1.PressKeys("EMPID");
					
					//Validate.IsTrue(repo.CollectionProperties.Row1Column1.Text.Contains("EMPID"));
					
					repo.CollectionProperties.OKButton.ClickThis();
				}
				else
				{
					EditCollectionColumns();
				}
				
				Reports.ReportLog("Columns Edited and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				repo.CollectionProperties.Self.Close();
				throw new Exception("Failed : EditCollectionColumns : " + ex.Message);
			}			
		}
		
		public static void CreateNewRelationship()
		{
			try 
			{
				ExplicitLongWait();
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Tables.FindSingle("//treeitem[@text='ads_ParentTable']");
				ExplicitLongWait();
				if(ads_ParentTable == null) throw new Exception("Failed : CreateNewRelationship : ads_ParentTable does not found");
				ads_ParentTable.EnsureVisible();
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.SunAwtWindow.NewRelationshipInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.NewRelationship.ClickThis();
				
				Reports.ReportLog("Create New Relationship", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateNewRelationship : " + ex.Message);
			}
		}
		
		public static void CreateNewCollectionRelationship()
		{
			try 
			{
				ExplicitLongWait();
				Ranorex.TreeItem ads_ParentTable = repo.EntityRelationshipDiagram.Collections.FindSingle("//treeitem[@text='ads_ParentTable']");
				ExplicitLongWait();
				if(ads_ParentTable == null) throw new Exception("Failed : CreateNewCollectionRelationship : ads_ParentTable does not found");
				ads_ParentTable.EnsureVisible();
				Ranorex.Mouse.Click(ads_ParentTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.SunAwtWindow.NewRelationshipInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.NewRelationship.ClickThis();
				
				Reports.ReportLog("Create New Collection Relationship", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateNewCollectionRelationship : " + ex.Message);
			}
		}
		
		public static void EnterRelationshipName()
		{
			try
			{
				ExplicitWait();
				repo.RelationshipProperties.RelationshipNameTextboxInfo.WaitForItemExists(10000);
				repo.RelationshipProperties.RelationshipNameTextbox.TextBoxText("ads_Relation");
				ExplicitWait();
				
				//Validate.IsTrue(repo.RelationshipProperties.RelationshipNameTextbox.TextValue.Contains("ads_Relation"));
				Reports.ReportLog("Enter New Relationship Name", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				repo.RelationshipProperties.Self.Close();
				throw new Exception("Failed : EnterRelationshipName : " + ex.Message);
			}
		}
		
		public static void SelectParentTableComboBox()
		{
			try 
			{
				ExplicitWait();
				repo.RelationshipProperties.ParentTableComboboxInfo.WaitForItemExists(10000);
				repo.RelationshipProperties.ParentTableCombobox.Text = "ads_ParentTable";
				ExplicitWait();
				//Validate.IsTrue(repo.RelationshipProperties.ParentTableCombobox.Text.Contains("ads_ParentTable"));
				Reports.ReportLog("Select ParentTable ComboBox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectParentTableComboBox : " + ex.Message);
			}
		}
		
		public static void SelectChildTableComboBox()
		{
			try 
			{
				ExplicitWait();
				repo.RelationshipProperties.ChildTableComboboxInfo.WaitForExists(new Ranorex.Duration(1000));
				
				repo.RelationshipProperties.ChildTableCombobox.Text = "ads_ChildTable";
				ExplicitWait();
				
				//Validate.IsTrue(repo.RelationshipProperties.ChildTableCombobox.Text.Contains("ads_ChildTable"));
				Reports.ReportLog("Select Child Table ComboBox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);	
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectChildTableComboBox : " + ex.Message);
			}
		}
		
		public static void CheckParentTableCheckbox()
		{
			try 
			{
				ExplicitWait();
				repo.RelationshipProperties.ParentTableIDColumnInfo.WaitForItemExists(10000);
				
				repo.RelationshipProperties.ParentTableIDColumn.Rows[0].Cells[0].Click();
				ExplicitWait();
				//Validate.IsTrue(repo.RelationshipProperties.ParentTableIDColumn.Rows[0].Cells[0].Text.Contains("true"));
				Reports.ReportLog("Check ParentTable Checkbox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckParentTableCheckbox : " + ex.Message);
			}
		}
		
		public static void CheckChildTableCheckbox()
		{
			try 
			{
				ExplicitWait();
				repo.RelationshipProperties.ChildTableIDColumnInfo.WaitForExists(new Ranorex.Duration(1000));
				
				repo.RelationshipProperties.ChildTableIDColumn.Rows[0].Cells[0].Click();
				ExplicitWait();
				//Validate.IsTrue(repo.RelationshipProperties.ChildTableIDColumn.Rows[0].Cells[0].Text.Contains("true"));
				Reports.ReportLog("Check ChildTable Checkbox", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckChildTableCheckbox : " + ex.Message);
			}
		}
		
		public static void ClickRelationshipOkButton()
		{
			try 
			{
				ExplicitWait();
				repo.RelationshipProperties.OkButtonInfo.WaitForItemExists(10000);
				repo.RelationshipProperties.OkButton.ClickThis();
				ExplicitWait();
				Reports.ReportLog("Click Relationship Ok Button", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickRelationshipOkButton : " + ex.Message);
			}
		}
		
		public static void SaveERD()
		{
			try 
			{
				repo.EntityRelationshipDiagram.SaveButtonInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				repo.EntityRelationshipDiagram.SaveButton.ClickThis();
				string fileName = string.Format("{0}/{1}", TC1_10535_Path, "TC2_ERD");
				Common.DeleteFile(fileName+".xed");	
				repo.SaveWindow.SaveFilePathInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				repo.SaveWindow.SaveFilePath.TextBoxText(fileName);
				repo.SaveWindow.SaveButton.ClickThis();
				CloseERD();
				Reports.ReportLog("New Entity Relationship created and Saved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SaveERD : " + ex.Message);
			}
		}
		
		public static void CloseERD()
		{
			try 
			{
				repo.EntityRelationshipDiagram.SelfInfo.WaitForExists(new Ranorex.Duration(30000));
				repo.EntityRelationshipDiagram.Self.Close();
				repo.EntityRelationshipDiagram.SelfInfo.WaitForNotExists(new Ranorex.Duration(30000));	
				
				Reports.ReportLog("Close ERD", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseERD : " + ex.Message);
			}
		}
		
		public static void OpenERD()
		{
			try 
			{
				string fileName = string.Format("{0}/{1}", TC1_10535_Path, "TC2_ERD.xed");
				repo.OpenWindow.FilePathTextboxInfo.WaitForExists(30000);
				repo.OpenWindow.FilePathTextbox.TextBoxText(fileName);
				repo.OpenWindow.OpenButton.ClickThis();
				ExplicitLongWait();
				CloseERD();
				ExplicitLongWait();
				Reports.ReportLog("Validate the Saved ERD", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : OpenERD : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC3 - Steps"
		
		public static void ClickOnToolMenu()
		{
			try 
			{
				repo.Menu.Tool.ClickThis();
				Reports.ReportLog("ClickOnToolMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnToolMenu : " + ex.Message);
			}
		}
		
		public static void ClickOnExportMenu()
		{
			try 
			{
				repo.DataStudio.ExportMenuInfo.WaitForItemExists(10000);
				repo.DataStudio.ExportMenu.ClickThis();
				Reports.ReportLog("ClickOnExportMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnExportMenu : " + ex.Message);
			}
		}
		
		public static void SelectServer()
		{
			try 
			{
				try{repo.ChooseFromServer.ServerListInfo.WaitForItemExists(10000);}
				catch{ClickOnToolMenu();ClickOnExportMenu();SelectServer();}
				
				TreeItem SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName);				
				Sleep();
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
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectServer : " + ex.Message);
			}
		}
		
		public static void SelectVerticaServer()
		{
			try 
			{
				try{repo.ChooseFromServer.ServerListInfo.WaitForItemExists(10000);}
				catch{ClickOnToolMenu();ClickOnExportMenu();SelectVerticaServer();}
				
				TreeItem SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName);
				Sleep();
				if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
	        		Preconditions.Steps.SelectedServerTreeItem = server;
	        		Preconditions.Steps.SelectedServerName = server.Text;
	        		SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
				SelectedServer.EnsureVisible();
				TreeItem SelectedDB = SelectedServer.GetItem(Config.AQUAFOLD);
				SelectedDB.EnsureVisible();
				SelectedDB.Select();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectVerticaServer : " + ex.Message);
			}
		}
		
		public static void SelectServers()
		{
			try 
			{
				try{repo.ChooseFromServer.ServerListInfo.WaitForItemExists(10000);}
				catch{ClickOnToolMenu();ClickOnExportMenu();SelectServers();}
				
				TreeItem SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName);
				Sleep();
				if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
	        		Preconditions.Steps.SelectedServerTreeItem = server;
	        		Preconditions.Steps.SelectedServerName = server.Text;
	        		SelectedServer = repo.ChooseFromServer.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
				SelectedServer.EnsureVisible();
				TreeItem SelectedDB = SelectedServer.GetItem(Config.ADSDB_CAPS);
				SelectedDB.EnsureVisible();
				SelectedDB.Select();
				Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectServers : " + ex.Message);
			}
		}
		
		public static void ClickOkButton()
		{
			try 
			{
				repo.ChooseFromServer.OkButtonInfo.WaitForExists(new Duration(1000));
				repo.ChooseFromServer.OkButton.ClickThis();
				Reports.ReportLog("ClickOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void SelectSchema()
		{
			try 
			{
				repo.ExportData.SchemaComboText.TextBoxText(Config.ADSDB);
				Reports.ReportLog("SelectSchema", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectSchema : " + ex.Message);
			}
		}
		
		public static void UnselectObjectTypes()
		{
			try 
			{
				repo.ExportData.GeneralTab.ObjectTypesTab.UnSelectAll.ClickThis();
				Reports.ReportLog("UnselectObjectTypes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : UnselectObjectTypes : " + ex.Message);
			}
		}
		
		public static void SelectTables()
		{
			try 
			{
				repo.ExportData.GeneralTab.ObjectTypesTab.TablesCheckbox.ClickThis();
				Reports.ReportLog("SelectTables", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectTables : " + ex.Message);
			}
		}
		
		public static void UnselectObjectType()
		{
			try 
			{
				repo.ExportData.GeneralTab.ObjectTab.UnSelectAll.ClickThis();
				Reports.ReportLog("UnselectObjectType", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : UnselectObjectType : " + ex.Message);
			}
		}
		
		public static void SelectADSTable()
		{
			try 
			{
				repo.ExportData.GeneralTab.ObjectTab.ADSTableCheckbox.ClickThis();
				Reports.ReportLog("SelectADSTable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectADSTable : " + ex.Message);
			}
		}
		
		public static void ClickNext()
		{
			try 
			{
				if(repo.OverWrite.SelfInfo.Exists(new Duration(600)))
					repo.OverWrite.YesButton.ClickThis();
				
				repo.ExportData.OptionsTab.NextButton.ClickThis();
				Reports.ReportLog("ClickNext", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickNext : " + ex.Message);
			}
		}
		
		public static void SetFilePath()
		{
			try 
			{
				string filePath = string.Format("{0}{1}.txt", TC1_10535_Path, Preconditions.Steps.SelectedServerName);
				Commons.Common.DeleteFile(filePath);
				repo.ExportData.OptionsTab.FilePathTextbox.TextBoxText(filePath);
				Reports.ReportLog("SetFilePath", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SetFilePath : " + ex.Message);
			}
		}
		
		public static void ClickClose()
		{
			try 
			{
				repo.ExportData.Status.ExportStatusTextInfo.WaitForExists(Common.ApplicationOpenWaitTime);
				repo.ExportData.Status.CloseButton.ClickThis();
				Reports.ReportLog("ClickClose", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickClose : " + ex.Message);
			}
		}
		
		public static void Sleep()
		{
			System.Threading.Thread.Sleep(1000);
		}
		
		#endregion
	
	}
}

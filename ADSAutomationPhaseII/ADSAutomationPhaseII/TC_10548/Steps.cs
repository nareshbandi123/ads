using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using Ranorex.Core;
using Ranorex;


namespace ADSAutomationPhaseII.TC_10548
{
    public static class Steps
    {
    	
		public static TC10548Repo repo = TC10548Repo.Instance;
		public static string TC1_10548_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10548_Path"].ToString();
		
  		#region "TC1"
  		
		public static void ClickonServers()
		{ 
			try
			{
				repo.Application.F1Menu.ClickThis();
				Reports.ReportLog("List of Local Database Servers are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonServers : " + ex.Message);
			}
		}
		
		public static void ExpandDatabase()
		{ 
			try
			{
				repo.Application.TreeItemInfo.WaitForExists(new Duration(50000));
				repo.Application.TreeItem.Expand();
				Reports.ReportLog("List of registered Servers are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ExpandDatabase : " + ex.Message);
			}
		}
		
		public static void CollapseDatabase()
		{ 
			try
			{
				repo.Application.TreeItemInfo.WaitForExists(new Duration(50000));
				repo.Application.TreeItem.Collapse();
				Reports.ReportLog("List of Local Database Servers are Hidden", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CollapseDatabase : " + ex.Message);
			}
		} 
        
		#endregion       
        
		#region "TC2"
		
		public static void ClickonSettingIcon()
		{ 
			try
			{
				repo.Application.Settings.SettingIconInfo.WaitForExists(new Duration(50000));
				repo.Application.Settings.SettingIcon.ClickThis();
				Reports.ReportLog("Docked Mode, Pinned Mode, Floating Mode, Split Mode are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSettingIcon : " + ex.Message);
			}
			
		}
		
		public static void MarkonFloatingMode()
		{ 
			try
			{
			    repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
					if(item.Text == "Floating Mode") { item.ClickThis(); break;}
					Reports.ReportLog("Local Database Servers pane can be moved", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonFloatingMode : " + ex.Message);
			}
		}
		
		public static void ClickonSettingIcon1()
		{ 
			try
			{
				repo.Server.SettingIcon1Info.WaitForExists(new Duration(50000));
				repo.Server.SettingIcon1.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSettingIcon1 : " + ex.Message);
			}
		}	
		
		public static void MarkonFloatingMode1()
		{ 
			try
			{
				repo.FloatingMenu.ContextMenu1.EnsureVisible();
				foreach (var item in repo.FloatingMenu.ContextMenu1.Items)
				{
					if(item.Text == "Floating Mode") { item.ClickThis(); break;}
				}		
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonFloatingMode1 : " + ex.Message);
			}
		}	
		
		public static void MarkonDockedMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
				    if(item.Text == "Docked Mode") { item.ClickThis(); break;}
				    Reports.ReportLog("Local Database Servers pane is accessable", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonDockedMode : " + ex.Message);
			}
		}	
		
		public static void ClickonSettingIcon2()
		{ 
			try
			{
				repo.Application.Settings.SettingIconDInfo.WaitForExists(new Duration(50000));
				repo.Application.Settings.SettingIconD.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSettingIcon2 : " + ex.Message);
			}
		}
				
		public static void MarkonDockedMode1()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
				    if(item.Text == "Docked Mode") { item.ClickThis(); break;}
				    Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonDockedMode1 : " + ex.Message);
			}
		}	
		
		public static void MarkonSplitMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
				  if(item.Text == "Split Mode") { item.ClickThis(); break;}
				  Reports.ReportLog("Local Database Servers pane is displayed at the bottom of the left side", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonSplitMode : " + ex.Message);
			}
		}	
		
		public static void MarkonPinnedMode()
		{ 
			try
			{
				repo.ModesMenu.ContextMenu.EnsureVisible();
				foreach (var item in repo.ModesMenu.ContextMenu.Items)
				{
				    if(item.Text == "Pinned Mode") { item.ClickThis(); break;}
				    Reports.ReportLog("Local Database Servers pane is always displayed towards the left side", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MarkonPinnedMode : " + ex.Message);
			}
		} 
		
		public static void ClickonHidingIcon()
        { 
			try
			{
				repo.Application.F1Menu.DoubleClick();
				Reports.ReportLog("Local Database Servers List is hidden", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonHidingIcon : " + ex.Message);
			}
		}
		
		#endregion
			
		#region "TC3"
		
        public static void CloseServerTab()
		{
			try 
			{
				repo.Application.F1MenuInfo.WaitForExists(new Ranorex.Duration(10000));
				if (repo.Application.F1Menu.Checked) 
					repo.Application.F1Menu.ClickThis();
				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseServerTab : " + ex.Message);
			}
		}
		
		public static void ClickOnProjectTab()
		{
			try 
			{
				repo.Application.F3MenuInfo.WaitForExists(new Ranorex.Duration(10000));
				if (!repo.Application.F3Menu.Checked) 
					repo.Application.F3Menu.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnProjectTab : " + ex.Message);	
			}
		}
		
		public static void RightClickProjectTab()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.Application.ProjectsTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
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
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectDataSchemaAndDataExporterTemplate : " + ex.Message);
			}
		}		
		
		public static void BrowseFolderLocation()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);
				repo.NewProject.BrowseButton.ClickThis();
				repo.SelectFolder.FolderPathTextbox.TextBoxText(TC1_10548_Path);				
				repo.SelectFolder.SelectButton.ClickThis();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : BrowseFolderLocation : " + ex.Message);	
			}
		}
		
		public static void ClickOk()
		{
			try 
			{
				repo.NewProject.OkButton.ClickThis();
				Reports.ReportLog(" QA template editor is displayed second line as  'Database Schema and Data Exporter'", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOk : " + ex.Message);	
			}
		}
		
		public static void ValidateTemplateFromNewProject()
		{
			try 
			{
				repo.DataTree.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.DataTree.TemplateTree.Expand();
				Reports.ReportLog("Folder structure AquaScripts, Servers and User Files folders is created", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
							
				Ranorex.Validate.Exists(repo.DataTree.AquaScriptsInfo, "Validate AquaScripts Available");				
								
				Ranorex.Validate.Exists(repo.DataTree.ServersInfo, "Validate Servers Available");				
								
				Ranorex.Validate.Exists(repo.DataTree.UserFilesInfo, "Validate UserFiles Available");	
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ValidateTemplateFromNewProject : " + ex.Message);	
			}
		}
		
		public static void ValidateNewProjectFile()
		{
			try 
			{
				repo.DataTree.AquaScriptsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				repo.DataTree.AquaScripts.Expand();
				Ranorex.Validate.Exists(repo.DataTree.NewProjectfile, "Validate NewProjectFile Available");
				Reports.ReportLog("Database Schema and Data Exporter.xjs' file is displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ValidateNewProjectFile : " + ex.Message);	
			}
		}
		
		public static void CloseTab()
		{
			try 
        	{	
        		repo.DataTree.TabInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DataTree.Tab, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.TabClose.ClickThis();
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Failed : CloseTab : " + ex.Message);	
        	}
		}
		
		public static void RemoveProject()
		{
			try 
			{
				repo.DataTree.TemplateTreeInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DataTree.TemplateTree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.RemoveMenu.ClickThis();
				repo.RemoveWindow.SelfInfo.WaitForExists(10000);
				repo.RemoveWindow.YesButton.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RemoveProject : " + ex.Message);
			}
		}
		
		#endregion
			
		#region "TC4"
		
		public static void ClickonFilesTab()
		{
			try 
			{
				repo.Application.F2Menu.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFilesTab : " + ex.Message);						  
			}
		}
		
		public static void RightClickonFileSystemTab()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.Application.FileSystemtree, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickonFileSystemTab : " + ex.Message);	
			}
		}
		
		public static void SelectNewFolder()
		{
			try 
			{
				repo.DataStudio.NewFolder.ClickThis();
				Reports.ReportLog("New Folder displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectNewFolder : " + ex.Message);		
			}
		}
		
		public static void EnterFolderName()
		{
			try 
			{
				repo.NewFolderMenu.FolderName.TextBoxText("ads Table");
				Validate.IsTrue(repo.NewFolderMenu.FolderName.TextValue.Contains("ads Table"));
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterFolderName : " + ex.Message);			
			}
		}
		
		public static void ClickOkButton()
		{
			try 
			{	
				repo.NewFolderMenu.OkButton.ClickThis();
				Reports.ReportLog("New Folder created under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);	
			}
		}
		
		public static void SelectShowDesktop()
		{
			try 
			{
				repo.DataStudio.ShowDesktop.ClickThis();
				Reports.ReportLog("Dektop is Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectShowDesktop : " + ex.Message);		
			}
		}
		
		public static void SelectMountDirectory()
		{
			try 
			{
				repo.DataStudio.ShowMountDirectory.ClickThis();
				Reports.ReportLog("Directory is Displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectMountDirectory : " + ex.Message);			
			}
		}
		
		public static void ProvidethePath()
		{
			try 
			{
				repo.SelectDirectory.LocalMachinePathInfo.WaitForExists(new Duration(50000));
				repo.SelectDirectory.LocalMachinePath.TextBoxText(TC1_10548_Path);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ProvidethePath : " + ex.Message);			
			}
		}
		
		public static void ClickonSelectButton()
		{
			try 
			{
				repo.SelectDirectory.SelectButtonInfo.WaitForExists(new Duration(50000));
				repo.SelectDirectory.SelectButton.ClickThis();
				Reports.ReportLog("The selected folder is created & displayed under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSelectButton : " + ex.Message);	
			}
		}
		
		
		public static void ExpandDDLDirectory()
		{
			try 
			{
				repo.Application.CDataFileInfo.WaitForExists(new Duration(50000));
				repo.Application.CDataFile.Expand();
				Reports.ReportLog("New Folder created under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ExpandDDLDirectory : " + ex.Message);
			}
		}	
		
		public static void DoubleClickonSQLfile()
		{
			try 
			{
				repo.Application.DB2SQL.DoubleClick();
				Reports.ReportLog("Choose Server or Database window is displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : DoubleClickonSQLfile : " + ex.Message);	
			}
		}		
			
		public static void SelectServer()
		{
			try 
			{
				repo.Database.AmazonRedshift.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectServer : " + ex.Message);	
			}
		}
		
		public static void CLickonOpeninQueryAnalyzer()
		{
			try 
			{
				repo.Database.OpeningQA.ClickThis();
				Reports.ReportLog("Query Analyzer window is displayed with the script", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CLickonOpeninQueryAnalyzer : " + ex.Message);	
			}
		}
		
		public static void CLickonOpeninTextEditorr()
		{
			try 
			{
				repo.Database.OpenTextEditor.ClickThis();
				Reports.ReportLog("Text Editor window is displayed with the script", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CLickonOpeninTextEditor : " + ex.Message);	
			}
		}
		
		public static void CollapsetheFileSystemDirectory()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);
				repo.Application.FileSystemtree.Collapse();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : CollapsetheFileSystemDirectory : " + ex.Message);
			}
		}
		
		public static void ExpandtheFileSystemDirectory()
		{
			try 
			{
				System.Threading.Thread.Sleep(500);				
				repo.Application.FileSystemtree.Expand();
				Reports.ReportLog("Folder structure with list of files are displayed under FileSystem tree", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ExpandtheFileSystemDirectory : " + ex.Message);
			}
		}
		
		public static void RemoveTabs()
		{
			try 
			{
				repo.DB2Windows.WindowsTabsInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.DB2Windows.WindowsTabs, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.CloseAll.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RemoveTabs : " + ex.Message);
			}
		}
		
		public static void UmmountDirectory()
		{
			try 
			{
				repo.Application.CDataFileInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.CDataFile, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.UnMountDirectory.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : UmmountDirectory : " + ex.Message);
			}
		}
		
		public static void ConfirmUnmountWindow()
		{
			try 
			{
				repo.UnmountWindow.YesButton.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ConfirmUnmountWindow : " + ex.Message);
			}
		}
		
		public static void DeleteAdsTable()
		{
			try 
			{
				repo.Application.AdsTableInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.AdsTable, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.DeleteAdsTable.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : DeleteAdsTable : " + ex.Message);	
			}
		}
		
		public static void ConfirmDeleteTable()
		{
			try 
			{
				repo.DeleteConfirm.YesButtonInfo.WaitForExists(new Duration(50000));
				repo.DeleteConfirm.YesButton.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ConfirmDeleteTable : " + ex.Message);	
			}
		}
		public static void HideDesktop()
		{
			try 
			{
				repo.Application.DesktopInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
				Ranorex.Mouse.Click(repo.Application.Desktop, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				repo.DataStudio.HideDesktop.ClickThis();
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : HideDesktop : " + ex.Message);		
			}
		}
		
				
		#endregion
    }
}


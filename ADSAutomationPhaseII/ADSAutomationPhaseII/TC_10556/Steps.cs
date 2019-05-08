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

using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using System.Windows.Forms;


namespace ADSAutomationPhaseII.TC_10556
{
	public static class Steps
	{
	    
		public static TC10556Repo repo = TC10556Repo.Instance;
		public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		public static string TC_10556_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10556"].ToString();
		
		
		public static bool MsExcelExists()
		{ 
			bool isfound = false;
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(1000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items) 
					if(item.Text == "MSExcel"){ isfound = true; break;}	
				Reports.ReportLog("MsExcelExists", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : MsExcelExists : " + ex.Message);
			}
			return isfound;
		}

		public static void RegisterServer()
		{ 
			try
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(2000);
				preRepo.ServersList.LocalDBServersTreeItem.RightClick();
				Keyboard.Press(Keyboard.ToKey("Insert"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Reports.ReportLog("RegisterServer", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : RegisterServer : " + ex.Message);
			}
		}
		
		public static void SelectMSExcel()
		{ 
			try
			{
				repo.RegisterServer.MSExcelInfo.WaitForItemExists(1000);
				repo.RegisterServer.MSExcel.ClickThis();
				Reports.ReportLog("SelectMSExcel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectMSExcel : " + ex.Message);
			}
		}
		
		public static void EnterName()
		{ 
			try
			{
				repo.RegServerExcel.NameTextboxInfo.WaitForItemExists(1000);
				repo.RegServerExcel.NameTextbox.TextBoxText("MSExcel");
				Reports.ReportLog("EnterName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterName : " + ex.Message);
			}
		}
		
		public static void EnterDirectory()
		{ 
			try
			{
				repo.RegServerExcel.DirectoryTextboxInfo.WaitForItemExists(1000);
				repo.RegServerExcel.DirectoryTextbox.TextBoxText(MSEXCEL_PATH + "bistudio_example.xlsx");
				Reports.ReportLog("EnterDirectory", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterDirectory : " + ex.Message);
			}
		}
		
		public static void ClickTestConnection()
		{ 
			try
			{
				repo.RegServerExcel.TestConnectionButtonInfo.WaitForItemExists(2000);
				repo.RegServerExcel.TestConnectionButton.ClickThis();
				Reports.ReportLog("ClickTestConnection", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickTestConnection : " + ex.Message);
			}
		}
		
		public static bool CheckConnectionStatus()
		{ 
			try
			{
				return repo.ConnectionStatus.ConnectionStatusTextInfo.Exists();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CheckConnectionStatus : " + ex.Message);
			}
		}
		
		public static void ClickCloseButton()
		{ 
			try
			{
				repo.ConnectionStatus.CloseButtonInfo.WaitForItemExists(1000);
				repo.ConnectionStatus.CloseButton.ClickThis();
				Reports.ReportLog("ClickCloseButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseButton : " + ex.Message);
			}
		}
		
		public static void ClickSaveButton()
		{ 
			try
			{
				repo.RegServerExcel.SaveButtonInfo.WaitForItemExists(1000);
				repo.RegServerExcel.SaveButton.ClickThis();
				Reports.ReportLog("ClickSaveButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickSaveButton : " + ex.Message);
			}
		}
		
		public static void IsServerRegistered()
		{ 
			try
			{
				if(!MsExcelExists())
				{
					RegisterServer();
					SelectMSExcel();
					EnterName();
					EnterDirectory();
					ClickTestConnection();
					if(CheckConnectionStatus())
					{
						ClickCloseButton();
						ClickSaveButton();
						
					}
					Reports.ReportLog("IsServerRegistered", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : IsServerRegistered : " + ex.Message);
			}			
		}
		
		public static void ConnectServer()
		{
			try 
			{
				preRepo.ServersList.LocalDBServersTreeItemInfo.WaitForItemExists(1000);
				foreach (var item in preRepo.ServersList.LocalDBServersTreeItem.Items) 
				{	
					if(item.Text == "MSExcel")
					{ 
						item.EnsureVisible();
						item.RightClick();
						Preconditions.Steps.SelectedServerTreeItem = item;
						Preconditions.Steps.SelectedServerName = item.Text;
						Preconditions.Steps.ConnectServer();
						Preconditions.Steps.QueryAnalyser();
						break;
					}
				}
			} 
			catch(Exception ex) 
			{
				throw new Exception("Failed : ConnectServer : " + ex.Message);
			}			
		}
		
		public static void ClickQARun()
        {
    		try
    		{
    			repo.QuaryAnalyzerWindow.QueryBoxInfo.WaitForItemExists(1000);
    			repo.QuaryAnalyzerWindow.QueryBox.Click();
    			repo.QuaryAnalyzerWindow.QueryBox.PressKeys("select * from bistudio_example");
        		Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Reports.ReportLog("ClickQARun", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
        	
    		}
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ClickQARun : " + ex.Message);
    		}
        }
		
		public static void ClickNewVA()
        {
    		try
    		{
    			repo.QuaryAnalyzerWindow.NewVAInfo.WaitForItemExists(15000);
    			repo.QuaryAnalyzerWindow.NewVA.ClickThis();
    			repo.VAWindow.Self.Maximize();
    			Reports.ReportLog("ClickNewVA", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		}
    		catch(Exception ex)
    		{
    			throw new Exception("Failed : ClickNewVA : " + ex.Message);
    		}
        }
		
		public static void MoveToColumn()
		{
			try 	
			{
				/*repo.VAWindow.ShipDateInfo.WaitForItemExists(10000);
				
				repo.VAWindow.ShipDate.Click("40;11");
            	Delay.Milliseconds(200);
            	
				repo.VAWindow.ShipDate.MoveTo("39;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VAWindow.ShipDate.MoveTo("47;3");
            	Delay.Milliseconds(200);
            	
            	repo.VAWindow.ColumnContainer.MoveTo("59;11");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);*/
				System.Threading.Thread.Sleep(2000);
				repo.VAWindow.ShipDateInfo.WaitForItemExists(5000);
				repo.VAWindow.ShipDate.DragThisTo(repo.VAWindow.ColumnContainer);
				System.Threading.Thread.Sleep(500);
	            Reports.ReportLog("MoveToColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex) 
			{
				throw new Exception("Failed : MoveToColumn : " + ex.Message);
			}
		}
		
		public static void MoveToRows()
		{
			try 	
			{
				repo.VAWindow.Profits.RightClickThis();
				repo.Form.AddToRowDeck.ClickThis();
				
				System.Threading.Thread.Sleep(2000);
				repo.VAWindow.CardTypeInfo.WaitForItemExists(5000);
				repo.VAWindow.CardType.DragThisTo(repo.VAWindow.RowContainer);
				System.Threading.Thread.Sleep(500);
	            
	            Reports.ReportLog("MoveToRows", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex) 
			{
				throw new Exception("Failed : MoveToRows : " + ex.Message);
			}
		}
		
		public static void RightClickData()
		{
			try 
			{
				repo.VAWindow.ChartContainerInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				System.Threading.Thread.Sleep(5000);
				repo.VAWindow.RenameDataInfo.WaitForItemExists(5000);
				repo.VAWindow.RenameData.EnsureVisible();
				repo.VAWindow.RenameData.Click();
				Ranorex.Mouse.Click(repo.VAWindow.RenameData, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				System.Threading.Thread.Sleep(200);
				Reports.ReportLog("RightClickData", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickData : " + ex.Message);
			}
		}
		
		public static void RenameData()
		{
			try 
			{
				repo.SunAwtWindow.RenameInfo.WaitForItemExists(1000);
				repo.SunAwtWindow.Rename.ClickThis();
				repo.RenameWindow.TextBoxInfo.WaitForItemExists(1000);
				repo.RenameWindow.TextBox.TextBoxText("Sales Data");
				Reports.ReportLog("RenameData", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void ClickOkButton()
		{
			try 
			{
				repo.RenameWindow.ClickRenameInfo.WaitForItemExists(1000);
				repo.RenameWindow.ClickRename.ClickThis();
				Reports.ReportLog("ClickOkButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOkButton : " + ex.Message);
			}
		}
		
		public static void SaveWorkBook()
		{
			try 
			{
				repo.VAWindow.SaveIconInfo.WaitForItemExists(1000);
				repo.VAWindow.SaveIcon.ClickThis();
				Reports.ReportLog("SaveWorkBook", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SaveWorkBook : " + ex.Message);
			}
		}
		
		public static void EnterWorkbookName()
		{
			try 
			{
				repo.SaveFolderWindow.WorkBookNameInfo.WaitForItemExists(1000);
				repo.SaveFolderWindow.WorkBookName.TextBoxText(TC_10556_PATH + "VA-tests.vizw");
				Reports.ReportLog("EnterWorkbookName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterWorkbookName : " + ex.Message);
			}
		}
		
		public static void SaveButton()
		{
			try 
			{	
				repo.SaveFolderWindow.SaveInfo.WaitForItemExists(1000);
				repo.SaveFolderWindow.Save.ClickThis();
				Reports.ReportLog("SaveButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SaveButton : " + ex.Message);
			}
		}
		
		public static void ClickCloseVA()
		{
			try 
			{
				repo.VAWindow.CloseWindowInfo.WaitForItemExists(1000);
				repo.VAWindow.CloseWindow.ClickThis();
				
				if(repo.SaveChanges.SelfInfo.Exists(new Duration(1000)))
					repo.SaveChanges.DiscardButton.ClickThis();
				Reports.ReportLog("ClickCloseVA", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseVA : " + ex.Message);
			}
		}
		
		public static void ClickCloseTab()
		{
			try 
			{
				Preconditions.Steps.CloseTab("");
				if(repo.FileModified.SelfInfo.Exists(new Duration(1000)))
					repo.FileModified.DiscardButton.ClickThis();
				Reports.ReportLog("ClickCloseTab", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCloseTab : " + ex.Message);
			}
		}
		
		public static void Cleanup()
		{
			Commons.Common.DeleteFile(TC_10556_PATH + "VA-tests.vizw");
		}
		
		public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(2000);
				repo.Application.FileMenu.EnsureVisible();
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickonFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);	
			}
		}
		
		public static void ClickonOpen()
		{
			try 
			{
				repo.DataStudio.OpenFileInfo.WaitForItemExists(1000);
				repo.DataStudio.OpenFile.ClickThis();
				Reports.ReportLog("ClickonOpen", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOpen : " + ex.Message);	
			}
		}
		
		public static void SelecttheFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizw");
				Reports.ReportLog("SelecttheFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelecttheFile : " + ex.Message);	
			}
		}
		
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);	
			}
		}
		
		public static void ClickonOpenButton()
		{
			try 
			{
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);	
			}
		}
		
		public static void RightClickonSalesData()
		{
			try 
			{
				repo.DataPaneWindow.SalesdataInfo.WaitForItemExists(10000);
				Ranorex.Mouse.Click(repo.DataPaneWindow.Salesdata, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("RightClickonSalesData", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : RightClickonSalesData : " + ex.Message);	
			}
		}
		
		public static void ClickonExtract()
		{
			try 
			{
				repo.SunAwtWindow.ExtractData.ClickThis();
				Reports.ReportLog("ClickonExtract", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonExtract : " + ex.Message);	
			}
		}
		
		public static void EntertheFileName()
		{
			try 
			{
				repo.ExtractDataWindow.FilePathTextBox.TextBoxText(TC_10556_PATH + "Sales Data.vize");
				Reports.ReportLog("EntertheFileName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheFileName : " + ex.Message);
			}
		}
		
		public static void SaveExtractFile()
		{
			try 
			{
				repo.ExtractDataWindow.SaveInfo.WaitForItemExists(1000);
				repo.ExtractDataWindow.Save.ClickThis();
				//repo.ExtractDataWindow.Ok.ClickThis();
				Reports.ReportLog("SaveExtractFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{	
				throw new Exception("Failed : SaveExtractFile : " + ex.Message);
			}
		}
		
		public static void OverrideYes()
		{
			try 
			{
				if(repo.OverrideWindow.SelfInfo.Exists())
					repo.OverrideWindow.Yes.ClickThis();
				Reports.ReportLog("Override Yes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : Override Yes : " + ex.Message);	
			}						
		}
		
		public static void OverrideNo()
		{
			try 
			{
				if(repo.OverrideWindow.SelfInfo.Exists())
					repo.OverrideWindow.No.ClickThis();
				Reports.ReportLog("Override No", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : Override No : " + ex.Message);	
			}						
		}
		
		public static void ClickonVAFileMenu()
		{
			try 
			{
				repo.DataPaneWindow.FileMenuInfo.WaitForItemExists(new Duration(1000));
				repo.DataPaneWindow.FileMenu.EnsureVisible();
				repo.DataPaneWindow.FileMenu.ClickThis();
				Reports.ReportLog("ClickonVAFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonVAFileMenu : " + ex.Message);
			}			
		}
		
		public static void SelectExportWorkBook()
		{
			try 
			{
				repo.SunAwtWindow.ExportWorkBookInfo.WaitForItemExists(new Duration(5000));
				repo.SunAwtWindow.ExportWorkBook.EnsureVisible();
				repo.SunAwtWindow.ExportWorkBook.ClickThis();
				Reports.ReportLog("SelectExportWorkBook", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectExportWorkBook : " + ex.Message);
			}
		}
				
		public static void ConfirmContinue()
		{
			try 
			{
				if(repo.ExportConfirmWindow.SelfInfo.Exists())
					repo.ExportConfirmWindow.Continue.ClickThis();
				Reports.ReportLog("ConfirmContinue", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ConfirmContinue : " + ex.Message);	
			}						
		}
		
		public static void ProvideFileName()
		{
			try 
			{
				repo.ExportConfirmWindow.FileNameText.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
				Reports.ReportLog("ProvideFileName", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ProvideFileName : " + ex.Message);
			}						
		}
		
		public static void ClickOnSaveButton()
		{
			try 
			{
				repo.ExportConfirmWindow.SaveInfo.WaitForItemExists(1000);
				repo.ExportConfirmWindow.Save.ClickThis();
				Reports.ReportLog("ClickOnSaveButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveButton : " + ex.Message);
			}						
		}
	}
}


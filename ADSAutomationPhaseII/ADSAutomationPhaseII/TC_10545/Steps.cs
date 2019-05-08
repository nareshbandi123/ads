using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10538;
using Ranorex.Core;
using Ranorex;
using System.Collections.Generic;

namespace ADSAutomationPhaseII.TC_10545
{
	public static class Steps
	{
		public static TC10545Repo repo = TC10545Repo.Instance;
		public static string TC_10545_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10545"].ToString();
		public static string SAVED_FILENAME = "TC_10545_TestData.xlsx";
		public static string FILENAME_TO_SAVE = "TC_10545_SAVEFILE.sql";
		public static string IMPORT_TABLE_NAME = "public.sheet1";
		
		public static void ClickOnTools()
		{
			try 
			{
				repo.Application.ToolsInfo.WaitForItemExists(1000);
				repo.Application.Tools.ClickThis();
				System.Threading.Thread.Sleep(200);
				Reports.ReportLog("ClickOnTools", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnTools : " + ex.Message);
			}
		}
		
		public static void ClickOnImport()
		{
			try 
			{
				repo.DataStudio.ImportInfo.WaitForItemExists(1000);
				repo.DataStudio.Import.ClickThis();
				Reports.ReportLog("ClickOnImport", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnImport : " + ex.Message);
			}
		}
		
		public static void ClickOnExport()
		{
			try 
			{
				repo.DataStudio.ExportInfo.WaitForItemExists(1000);
				repo.DataStudio.Export.ClickThis();
				Reports.ReportLog("ClickOnExport", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnExport : " + ex.Message);
			}
		}
		
		public static void SelectServer()
		{
			try 
			{
				repo.ChooseFromServers.SelfInfo.WaitForItemExists(10000);
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				TreeItem ServerItem = repo.ChooseFromServers.LocalServers.GetItem(serverName);
				if(ServerItem != null)
				{
					TreeItem adsdbItem = ServerItem.GetItem(Config.ADSDB, false);
					adsdbItem.ClickThis();
					repo.ChooseFromServers.OkButton.ClickThis();
					Reports.ReportLog("SelectServer", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}				
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectServer : " + ex.Message);
			}
		}
		
		public static void SelectExcelFile()
		{
			try 
			{
				string filePath = string.Format("{0}{1}",TC_10545_PATH, SAVED_FILENAME);
				repo.SelectFile.SelfInfo.WaitForItemExists(5000);
				repo.SelectFile.FilePathTextbox.TextBoxText(filePath);
				repo.SelectFile.SelectButton.ClickThis();
				Reports.ReportLog("SelectExcelFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectExcelFile : " + ex.Message);
			}
		}
		
		public static void ClickOnNext()
		{
			try 
			{
				repo.Application.NextButtonInfo.WaitForItemExists(5000);
				repo.Application.NextButton.ClickThis();
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnNext", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnNext : " + ex.Message);
			}
		}
		
		public static void SelectDestinationDropdown(int index)
		{
			try 
			{
				repo.Application.DestinationComboboxInfo.WaitForItemExists(5000);
				repo.Application.DestinationCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectDestinationDropdown", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectDestinationDropdown : " + ex.Message);
			}
		}
		
		public static void EnterFilePathToSave()
		{
			try 
			{
				repo.Application.FileNameTextboxInfo.WaitForItemExists(5000);
				string filePath = string.Format("{0}{1}", TC_10545_PATH, FILENAME_TO_SAVE);
				Common.DeleteFile(filePath);
				repo.Application.FileNameTextbox.TextBoxText(filePath);
				Reports.ReportLog("EnterSaveFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : EnterSaveFilePath : " + ex.Message);
			}
		}
		
		public static void CheckImportStatus()
		{
			try 
			{
				repo.Application.ImportStatusTextInfo.WaitForItemExists(500000);
				Reports.ReportLog("CheckImportStatus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CheckImportStatus : " + ex.Message);
			}
		}
		
		public static void ClickOnCloseButton()
		{
			try 
			{
				repo.Application.CloseButtonInfo.WaitForItemExists(500000);
				repo.Application.CloseButton.ClickThis();
				Reports.ReportLog("ClickOnCloseButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnCloseButton : " + ex.Message);
			}
		}
		
		public static void ScanForTables()
        {    
            try
            {
            	repo.Application.LeftTableInfo.WaitForItemExists(10000);
            	Table table = repo.Application.LeftTable;
            	repo.Application.UnSelectLeft.ClickThis();
                foreach (var row in table.Rows) 
                {
                    if(row.Cells[2].Text.ToLower() == "tables" && row.Cells[1].Text == "false")
                    {
                    	row.Cells[1].ClickThis();
                        break;
                    }                    
                }
                Reports.ReportLog("ScanForTables", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            } 
            catch (Exception ex)
            {
            	throw new Exception("Failed : ScanForTables :" + ex.Message);
            }
        }
		
		public static void ScanForADSTable()
        {    
            try
            {
            	repo.Application.RightTableInfo.WaitForItemExists(10000);
            	Table table = repo.Application.RightTable;
            	repo.Application.UnSelectRight.ClickThis();
                foreach (var row in table.Rows) 
                {
                    if(row.Cells[3].Text.ToLower() == "ads_table" && row.Cells[1].Text == "false")
                    {
                    	row.Cells[1].ClickThis();
                        break;
                    }                    
                }
                Reports.ReportLog("ScanForADSTable", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
            } 
            catch (Exception ex)
            {
            	throw new Exception("Failed : ScanForTables :" + ex.Message);
            }
        }
       
		public static void CheckUnselected(Table table)
		{
            try
            {
                foreach (var row in table.Rows) 
                {
                    if(row.Cells[1].Text == "true" || row.Cells[1].Text == "True")
                    {
                    	row.Cells[1].ClickThis();
                        break;
                    }
                }
            } 
            catch (Exception ex)
            {
            	throw new Exception("Failed : CheckUnselected :" + ex.Message);
            }
        }
		
		public static void SelectExportDestinationDropdown(int index)
		{
			try 
			{
				repo.Application.ExportDestinationComboboxInfo.WaitForItemExists(5000);
				repo.Application.ExportDestinationCombobox.SelectedItemIndex = index;
				Reports.ReportLog("SelectExportDestinationDropdown", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectExportDestinationDropdown : " + ex.Message);
			}
		}
		
		public static void EnterExportFilePathToSave()
		{
			try 
			{
				repo.Application.ExportFilePathTextboxInfo.WaitForItemExists(5000);
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				string filePath = string.Format("{0}{1}.txt", TC_10545_PATH, serverName);
				Common.DeleteFile(filePath);
				repo.Application.ExportFilePathTextbox.TextBoxText(filePath);
				Reports.ReportLog("EnterExportFilePathToSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : EnterExportFilePathToSave : " + ex.Message);
			}
		}
		
		public static void ClickOnExportNext()
		{
			try 
			{
				repo.Application.ExportNextButtonInfo.WaitForItemExists(5000);
				repo.Application.ExportNextButton.ClickThis();
				System.Threading.Thread.Sleep(1000);
				Reports.ReportLog("ClickOnExportNext", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnExportNext : " + ex.Message);
			}
		}
		
		public static void CheckExportStatus()
		{
			try 
			{
				repo.Application.ExportStatusTextInfo.WaitForItemExists(5000);
				Reports.ReportLog("CheckExportStatus", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CheckExportStatus : " + ex.Message);
			}
		}
		
		public static void ClickOnExportCloseButton()
		{
			try 
			{
				repo.Application.ExportCloseButtonInfo.WaitForItemExists(500000);
				repo.Application.ExportCloseButton.ClickThis();
				Reports.ReportLog("ClickOnExportCloseButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnExportCloseButton : " + ex.Message);
			}
		}
		
		public static void ValidateExportFile()
		{
			try 
			{
				string serverName = Preconditions.Steps.GetServerFromTCName(Config.TestCaseName);
				string filePath = string.Format("{0}{1}.txt", TC_10545_PATH, serverName);
				repo.Application.FileInfo.WaitForItemExists(1000);
				repo.Application.File.ClickThis();
				repo.SunSwtWindow.OpenInfo.WaitForItemExists(1000);
				repo.SunSwtWindow.Open.ClickThis();
				repo.OpenWindow.SelfInfo.WaitForItemExists(5000);
				repo.OpenWindow.FilePathTextbox.TextBoxText(filePath);
				repo.OpenWindow.OpenButton.ClickThis();
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				Reports.ReportLog("ValidateExportFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ValidateExportFile : " + ex.Message);
			}
		}
	}
}

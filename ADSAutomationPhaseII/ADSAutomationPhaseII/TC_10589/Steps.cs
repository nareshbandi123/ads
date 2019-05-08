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
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10589
{
	public class Steps
	{
		public static TC10589 repo = TC10589.Instance;
		public static string TC_10589_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10589_Path"].ToString();
		
		public static void ClickOnFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(20000);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFileMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFileMenu" +ex.Message);
			}			
		}
		
		public static void ClickOnOpenMenu()
		{
			try 
			{
				repo.SunAwtWindow.OpenInfo.WaitForItemExists(20000);
				repo.SunAwtWindow.Open.ClickThis();
				Reports.ReportLog("ClickOnOpenMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenMenu" + ex.Message);
			}			
		}
		
		public static void EnterFilePath()
		{
			try 
			{
				repo.Open.OpenTextInfo.WaitForItemExists(20000);
				repo.Open.OpenText.TextBoxText(TC_10589_PATH + "Sample_Data_Source_Maps.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void ClickOnOpenButton()
		{
			try 
			{
				repo.Open.OpenButtonInfo.WaitForItemExists(2000);
				repo.Open.OpenButton.ClickThis();
				System.Threading.Thread.Sleep(20000);
				Reports.ReportLog("ClickOnOpenButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenButton" +ex.Message);
			}			
		}
		
		public static void ClickOnMaximize()
		{
			try 
			{
				repo.VisualAnalytics.MaximizeInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Maximize.ClickThis();
				Reports.ReportLog("ClickOnMaximize", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnMaximize" +ex.Message);
			}			
		}
		
		public static void CreateNewWorksheet()
		{
			try 
			{
				repo.VisualAnalytics.WorksheetInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Worksheet.ClickThis();
            	
				repo.SunAwtWindow.NewWorksheetInfo.WaitForItemExists(20000);
            	repo.SunAwtWindow.NewWorksheet.ClickThis();
            	
				Reports.ReportLog("CreateNewWorksheet", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewWorksheet" +ex.Message);
			}			
		}
		
		public static void DragCountryToColumn()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.Country.MoveTo("60;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.Country.MoveTo("68;3");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.ColumnPanel.MoveTo("71;8");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	           
				Reports.ReportLog("DragCountryToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCountryToColumn" +ex.Message);
			}			
		}
		
		public static void DragEnglishSpeakersToRows()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.SUMPercentEnglishSpeakers.MoveTo("115;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.SUMPercentEnglishSpeakers.MoveTo("123;2");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.RowPanel.MoveTo("60;10");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
 
				Reports.ReportLog("DragEnglishSpeakersToRows", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragEnglishSpeakersToRows" +ex.Message);
			}			
		}
		
		public static void SelectFilledMapVisualization()
		{
			try 
			{
				repo.VisualAnalytics.VisualizationInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Visualization.ClickThis();
	            
	            repo.VisualAnalytics.FilledMapButtonInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.FilledMapButton.ClickThis();
	            
	            repo.VisualAnalytics.Visualization1Info.WaitForItemExists(20000);
	            repo.VisualAnalytics.Visualization1.ClickThis();
	            
				Reports.ReportLog("SelectFilledMapVisualization", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectFilledMapVisualization" +ex.Message);
			}			
		}
		
		public static void VerifyBreak()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.Break.ClickThis();
 
				Reports.ReportLog("VerifyBreak", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyBreak" +ex.Message);
			}			
		}
		
		public static void VerifyColor()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.BreakInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.Break.ClickThis();
 
				Reports.ReportLog("VerifyColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyColor" +ex.Message);
			}			
		}
		
		public static void EditColor()
		{
			try 
			{
	            repo.VisualAnalytics.WorksheetColor.ClickThis();
	            
	            repo.Datastudio.EditColors.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.ThemeChooserComboBox.ClickThis();
	            
	            repo.SunAwtWindow.Green.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.SteppedColor.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.SpinnerFormattedTextField.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.SpinnerFormattedTextField.PressKeys("{Right}");
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.SpinnerFormattedTextField.PressKeys("{Back}");
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.SpinnerFormattedTextField.PressKeys("4");
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.ButtonOK.Click();
	            
				Reports.ReportLog("EditColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditColor" +ex.Message);
			}			
		}
		
		public static void EditColorReversed()
		{
			try 
			{
				repo.VisualAnalytics.WorksheetColorInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.WorksheetColor.ClickThis();
	            
	            repo.Datastudio.EditColorsInfo.WaitForItemExists(20000);
	            repo.Datastudio.EditColors.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(20000);
	            repo.EditColorsPercentEnglishSpeakers.CPanel.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
	            
	            repo.SunAwtWindow.RedGreenDivergingInfo.WaitForItemExists(200000);
	            repo.SunAwtWindow.RedGreenDiverging.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.ReversedInfo.WaitForItemExists(200000);
	            repo.EditColorsPercentEnglishSpeakers.CPanel.Reversed.ClickThis();
	            
	            repo.EditColorsPercentEnglishSpeakers.CPanel.ButtonOKInfo.WaitForItemExists(200000);
	            repo.EditColorsPercentEnglishSpeakers.CPanel.ButtonOK.ClickThis();
	            
	            repo.VisualAnalytics.ShowLabelsButtonInfo.WaitForItemExists(200000);
	            repo.VisualAnalytics.ShowLabelsButton.ClickThis();
	            
	            repo.VisualAnalytics.ShowLabelsButtonInfo.WaitForItemExists(200000);
	            repo.VisualAnalytics.ShowLabelsButton.ClickThis();
	            
				Reports.ReportLog("EditColorReversed", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditColorReversed" +ex.Message);
			}			
		}
		
		public static void ClickOnCloseViz()
		{
			try 
			{
				repo.VisualAnalytics.CloseButtonInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.CloseButton.ClickThis();
				
				Reports.ReportLog("ClickOnCloseViz", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCloseViz" + ex.Message);
			}			
		}
		
		public static void ClickOnDiscard()
		{
			try 
			{
				repo.SaveChanges.DiscardInfo.WaitForItemExists(20000);
				repo.SaveChanges.Discard.ClickThis();
				repo.SaveChanges.DiscardInfo.WaitForNotExists(20000);
				Reports.ReportLog("ClickOnDiscard", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnDiscard" + ex.Message);
			}			
		}
		
		public static void ValidateFullChart()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.FullChartInfo, repo.VisualAnalytics.FullChartInfo.GetEnglishSpeakers(), Imaging.FindOptions.Default, "Validate Full Chart", false))
				{
					Reports.ReportLog("Validation : FullChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateFullChart :" +ex.Message);
			}
		}
		
		public static void ClickOnMapCustomization()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.MapCustomizationAmbiguousLocationsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.MapCustomizationAmbiguousLocations.DoubleClickThis();
	            
	            repo.VisualAnalytics.ContainerContentPanel.MapCustomizationShowStateBordersInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.MapCustomizationShowStateBorders.DoubleClickThis();
	            
				Reports.ReportLog("ClickOnShowStateBorders", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowStateBorders" + ex.Message);
			}			
		}
		
		public static void ClickOnShowStateBorder()
		{
			try 
			{
				repo.VisualAnalytics.ContainerSheetsPaneInfo.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.VisualAnalytics.ContainerSheetsPane.ClickThis();
	            
	            repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
	            
	            repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.DoubleClickThis();
	            
	            repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
	            repo.SunAwtWindow.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
	            repo.SunAwtWindow.MapCustomizationShowStateBorders.ClickThis();
		            
				Reports.ReportLog("ClickOnShowStateBorders", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnShowStateBorders" + ex.Message);
			}			
		}
		
		public static void SelectCity()
		{
			try 
			{
				repo.VisualAnalytics.GeographyInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.Geography.ClickThis();
	            
				repo.VisualAnalytics.Geography.RightClick();
	            
	            repo.SunAwtWindowInstance0.GeographicRoleInfo.WaitForItemExists(200000);
	            repo.SunAwtWindowInstance0.GeographicRole.ClickThis();
	            
	            repo.SunAwtWindowInstance1.CityInfo.WaitForItemExists(2000);
	            repo.SunAwtWindowInstance1.City.ClickThis();
		            
				Reports.ReportLog("SelectCity", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCity" + ex.Message);
			}			
		}
		
		public static void ShowLabelOptions()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.OptionsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.Options.DoubleClick();
	            
	            repo.Datastudio.ShowStateBordersInfo.WaitForItemExists(20000);
	            repo.Datastudio.ShowStateBorders.ClickThis();
	            
				Reports.ReportLog("ShowLabelOptions", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowLabelOptions" + ex.Message);
			}			
		}
		
		public static void ValidateCheckedShowStateBorders()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.ShowStateBordersDarkInfo, repo.VisualAnalytics.ShowStateBordersDarkInfo.GetShowStateBorder(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateShowStateBorders", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateShowStateBorders :" +ex.Message);
			}			
		}
		
		public static void ValidateUnCheckedShowStateBorders()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.ShowStateBodersLightInfo, repo.VisualAnalytics.ShowStateBodersLightInfo.GetShowStateBorder(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateUnCheckedShowStateBorders", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateUnCheckedShowStateBorders :" +ex.Message);
			}			
		}
		
		public static void ClickOnCustomizeFilledMap()
		{
			try 
			{
				repo.VisualAnalytics.ContainerSheetsPane.ClickThis();
	            
				repo.VisualAnalytics.CustomizeFilledMap.ClickThis();
	            
				Reports.ReportLog("ClickOnCustomizeFilledMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCustomizeFilledMap" + ex.Message);
			}			
		}
		
		public static void AnalysisMapOnEditingLocation()
		{
			try 
			{
				repo.VisualAnalytics.Analysis.ClickThis();
	            
				repo.SunAwtWindowInstance0.MenuItemMap.ClickThis();
	            
				repo.SunAwtWindowInstance1.EditLocations.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("AnalysisMapOnEditingLocation :" +ex.Message);
			}			
		}
		
		public static void ScanLocationsTable()
		{
			try 
			{
				Table locationTable = repo.EditLocations.UnknownLocation;
				repo.EditLocations.UnknownLocationInfo.WaitForItemExists(20000);
				
				if(locationTable.Rows.Count == 10)
				{
					Reports.ReportLog("ScanLocationsTable ",Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ScanLocationsTable :" +ex.Message);
			}			
		}
		
		public static void ClickOnClose()
		{
			try 
			{
				repo.EditLocations.CloseInfo.WaitForItemExists(20000);
				repo.EditLocations.Close.ClickThis();
				
				Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose" + ex.Message);
			}			
		}
		
		public static void ClickOnAmbiguousMap()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.MapCustomizationAmbiguousLocations.Click("116;9");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.MapCustomizationAmbiguousLocations.Click("68;12");
	            Delay.Milliseconds(200);
				
				Reports.ReportLog("ClickOnAmbiguousMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAmbiguousMap" + ex.Message);
			}			
		}
		
		public static void SelectLocation()
		{
			try 
			{
				repo.EditLocations.CPanel.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
	            
				repo.SunAwtWindow.Fixed.ClickThis();
	            
				repo.SunAwtWindow.ComboBoxCountryList.ClickThis();
	            
				repo.SunAwtWindowInstance1.UnitedStates.ClickThis();
	            
				repo.EditLocations.CPanel.Apply.ClickThis();
	            
				repo.EditLocations.CPanel.ButtonOK.ClickThis();
	            
				Reports.ReportLog("SelectLocation", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLocation" + ex.Message);
			}			
		}
		
		public static void ClickOnBuildFilledMap()
		{
			try 
			{
				repo.VisualAnalytics.ContainerSheetsPane1.MapCustomizationShowStateBorders.ClickThis();
	            
	            repo.VisualAnalytics.ContainerSheetsPane1.BuildFilledMapInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerSheetsPane1.BuildFilledMap.ClickThis();
	            
				Reports.ReportLog("ClickOnBuildFilledMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnBuildFilledMap" + ex.Message);
			}			
		}
		
		public static void ClickOnLabelAndColor()
		{
			try 
			{
				repo.VisualAnalytics.LabelInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Label.ClickThis();
	            
	            repo.Datastudio.ShowDataLabelsInfo.WaitForItemExists(20000);
	            repo.Datastudio.ShowDataLabels.ClickThis();
	            
	            repo.VisualAnalytics.ColorInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.Color.ClickThis();
	            
	            repo.Datastudio.BICustomComboBoxInfo.WaitForItemExists(20000);
	            repo.Datastudio.BICustomComboBox.ClickThis();
	            
	            repo.SunAwtWindow.MyContentInfo.WaitForItemExists(20000);
	            repo.SunAwtWindow.MyContent.ClickThis();
	            
	            repo.VisualAnalytics.ContainerSheetsPane1.ContainerCanvasInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerSheetsPane1.ContainerCanvas.ClickThis();
	            
	            
	            repo.VisualAnalytics.ColorInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.Color.ClickThis();
	            
	            repo.Datastudio.BICustomComboBox1Info.WaitForItemExists(20000);
	            repo.Datastudio.BICustomComboBox1.ClickThis();
	            
	            repo.SunAwtWindow.AQColorChooserPanelDollarColorButtonInfo.WaitForItemExists(20000);
	            repo.SunAwtWindow.AQColorChooserPanelDollarColorButton.Click();
	            
	            repo.VisualAnalytics.ContainerSheetsPane1.ContainerCanvasInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerSheetsPane1.ContainerCanvas.ClickThis();
	            
				Reports.ReportLog("ClickOnBuildFilledMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnBuildFilledMap" + ex.Message);
			}			
		}
	}
}

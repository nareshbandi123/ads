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
using ADSAutomationPhaseII.TC_10589;

namespace ADSAutomationPhaseII.TC_10595
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10595 repo = TC10595.Instance;
		public static string TC_10595_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10595_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try 
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10595_PATH + "Sample_Data_Source_Horizon_Chart.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void DragStockDateToColumn()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.StockDate.MoveTo("65;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerContentPanel.StockDate.MoveTo("73;1");
	            
	            repo.VisualAnalytics.ContainerContentPanel.ColumnPanel.MoveTo("87;4");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
				Reports.ReportLog("DragStockDateToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockDateToColumn" + ex.Message);
			}			
		}
		
		public static void DragStockSymbolToColumn()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.StockSymbol.MoveTo("68;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerContentPanel.StockSymbol.MoveTo("76;-1");
	            
	            repo.VisualAnalytics.ContainerContentPanel.ColumnPanel.MoveTo("197;7");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragStockSymbolToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockSymbolToColumn" + ex.Message);
			}			
		}
		
		public static void SelectWeekNumber()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.QUARTERStockDateInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.QUARTERStockDate.RightClick();
				
				repo.SunAwtWindow.WeekNumberWeek12013Info.WaitForItemExists(20000);
	            repo.SunAwtWindow.WeekNumberWeek12013.ClickThis();
	            
				Reports.ReportLog("SelectWeekNumber", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectWeekNumber" + ex.Message);
			}			
		}
		
		public static void DragStockCloseToRows()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerContentPanel.SUMStockClose.MoveTo("78;12");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerContentPanel.SUMStockClose.MoveTo("86;4");
	            
	            repo.VisualAnalytics.ContainerContentPanel.RowPanel.MoveTo("101;9");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragStockCloseToRows", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStockCloseToRows" + ex.Message);
			}			
		}
		
		public static void SelectHorizonMap()
		{
			try 
			{
				TC10589Repo.VisualAnalytics.VisualizationInfo.WaitForItemExists(20000);
				TC10589Repo.VisualAnalytics.Visualization.ClickThis();
				
				repo.VisualAnalytics.HorizonMapInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.HorizonMap.ClickThis();
				
				TC10589Repo.VisualAnalytics.Visualization1Info.WaitForItemExists(20000);
	            TC10589Repo.VisualAnalytics.Visualization1.ClickThis();
	            
				Reports.ReportLog("SelectHorizonMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectHorizonMap" + ex.Message);
			}			
		}
		
		public static void SelectBand2()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.OptionsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.Options.ClickThis();
	            
				repo.Datastudio.RadioButton2BandsInfo.WaitForItemExists(20000);
	            repo.Datastudio.RadioButton2Bands.ClickThis();
	            
				Reports.ReportLog("SelectBand2", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBand2" + ex.Message);
			}			
		}
		
		public static void SelectBand3()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.OptionsInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.ContainerContentPanel.Options.ClickThis();
				
				repo.Datastudio.RadioButton3BandsInfo.WaitForItemExists(200000);
				repo.Datastudio.RadioButton3Bands.ClickThis();
					
				Reports.ReportLog("SelectBand3", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectBand3" + ex.Message);
			}			
		}
		
		public static void EditColors()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.ColorInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerContentPanel.Color.ClickThis();
	            
				repo.EditColor.WindowsComboBoxUIDollarXPComboBoxButtonInfo.WaitForItemExists(200000);
				repo.EditColor.WindowsComboBoxUIDollarXPComboBoxButton.ClickThis();
	            
				repo.SunAwtWindow.RedGreenDivergingInfo.WaitForItemExists(200000);
				repo.SunAwtWindow.RedGreenDiverging.ClickThis();
	            
				repo.EditColor.ButtonOKInfo.WaitForItemExists(200000);
				repo.EditColor.ButtonOK.ClickThis();
					
				Reports.ReportLog("EditColors", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EditColors" + ex.Message);
			}			
		}
	}
}
		
		
		

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

namespace ADSAutomationPhaseII.TC_10601
{
	public class Steps
	{
		public static TC10589 TC10589Repo = TC10589.Instance;
		public static TC10601 repo = TC10601.Instance;
		public static string TC_10601_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10601_Path"].ToString();
		
		public static void EnterFilePath()
		{
			try 
			{
				TC10589Repo.Open.OpenTextInfo.WaitForItemExists(20000);
				TC10589Repo.Open.OpenText.TextBoxText(TC_10601_PATH + "Sample_Data_Source_Maps.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void ClickOnSymbolMap()
		{
			try 
			{
				repo.VisualAnalytics.ContainerMainPanel.SampleDataSourceSymbolMapInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerMainPanel.SampleDataSourceSymbolMap.ClickThis();
				Reports.ReportLog("ClickOnSymbolMap", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSymbolMap" + ex.Message);
			}			
		}
		
		public static void DragOrderDateToColumn()
		{
			try 
			{
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
	            repo.VisualAnalytics.ContainerMainPanel.OrderDate.MoveTo("76;5");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerMainPanel.OrderDate.MoveTo("84;-3");
	            
	            repo.VisualAnalytics.ContainerMainPanel.ColumnsPanel.MoveTo("157;14");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragOrderDateToColumn", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragOrderDateToColumn" + ex.Message);
			}			
		}
		
		public static void ClickOnOrderDate()
		{
			try 
			{
				repo.VisualAnalytics.ContainerMainPanel.QUARTEROrderDate.Click("8;10");
				Reports.ReportLog("ClickOnOrderDate", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOrderDate" + ex.Message);
			}			
		}
		
		public static void DragProfitToRow()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerMainPanel.SUMProfit.MoveTo("56;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerMainPanel.SUMProfit.MoveTo("64;2");
	            
	            repo.VisualAnalytics.ContainerMainPanel.RowPanel.MoveTo("96;20");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragProfitToRow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfitToRow" + ex.Message);
			}			
		}
		
		public static void DragFreightToRow()
		{
			try 
			{
	            repo.VisualAnalytics.ContainerMainPanel.SUMFreight.MoveTo("54;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerMainPanel.SUMFreight.MoveTo("62;1");
	            
	            repo.VisualAnalytics.ContainerMainPanel.RowPanel.MoveTo("194;21");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragFreightToRow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreightToRow" + ex.Message);
			}			
		}
		
		public static void DragProductCategoryToFilter()
		{
			try 
			{
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButtInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.ContainerMainPanel.WindowsScrollBarUIDollarWindowsArrowButt.ClickThis();
	            
	            repo.VisualAnalytics.ContainerMainPanel.ProductCategory.MoveTo("122;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerMainPanel.ProductCategory.MoveTo("130;2");
	            
	            repo.VisualAnalytics.ContainerMainPanel.FilterPanel.MoveTo("57;15");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragProductCategoryToFilter", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategoryToFilter" + ex.Message);
			}			
		}
		
		public static void VisualAnalyticsMenu()
		{
			try 
			{
				repo.VisualAnalytics.TextMessage.RightClick();
				Reports.ReportLog("VisualAnalyticsMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VisualAnalyticsMenu" + ex.Message);
			}			
		}
	}
}

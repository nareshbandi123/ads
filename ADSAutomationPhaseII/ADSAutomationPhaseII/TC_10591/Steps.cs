using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using System.Windows.Forms;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10591
{
    public static class Steps
    {
   	    public static TC10591Repo repo = TC10591Repo.Instance;
        public static string TC_10591_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10591"].ToString(); 
        
        #region "TC1"
        
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10591_PATH + "Sample_Data_Source_Maps.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void DragStatetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.StateInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.State.Click("42;7");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerLeftPanel.State.MoveTo("38;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.State.MoveTo("46;-1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerContentPanel.Panel.MoveTo("61;11");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragStatetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragStatetoColumn : " + ex.Message);
			}
		}
		
		public static void DragProductCategorytoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.ProductCategoryInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerLeftPanel.ProductCategory.Click("56;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.ProductCategory.MoveTo("56;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerLeftPanel.ProductCategory.MoveTo("64;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerContentPanel.Panel.MoveTo("195;12");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragProductCategorytoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProductCategorytoColumn : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.SUMProfitInfo.WaitForItemExists(15000);
				repo.VAWindow.ContainerLeftPanel.SUMProfit.Click("48;7");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.MoveTo("41;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.MoveTo("49;2");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerContentPanel.Panel1.MoveTo("78;11");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragProfittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoRow : " + ex.Message);
			}
		}
		
		public static void ClickonAutomatic()
		{
			try 
			{
				repo.VAWindow.AutomaticInfo.WaitForItemExists(2000);
				repo.VAWindow.Automatic.Click();
				Reports.ReportLog("ClickonAutomatic", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAutomatic : " + ex.Message);
			}
		}
		
		public static void ChangeChartTypetoPie()
		{
			try 
			{
				repo.SunAwtWindow.PieChartInfo.WaitForItemExists(2000);
				repo.SunAwtWindow.PieChart.ClickThis();
				Reports.ReportLog("ChangeChartTypetoPie", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoPie : " + ex.Message);
			}
		}
		
		public static void DragPCtoColorDeck()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.ProductCategory.Click("35;7");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerMainPanel.ProductCategory.MoveTo("44;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VAWindow.ContainerMainPanel.ProductCategory.MoveTo("52;-1");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerMainPanel.Color.MoveTo("30;26");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragPCtoColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragPCtoColorDeck : " + ex.Message);
			}
		}
		
		public static void ClickonAnyPCIteminChart()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.ContainerCanvasInfo.WaitForItemExists(1000);
				repo.VAWindow.ContainerMainPanel.ContainerCanvas.Click("510;296");
				System.Threading.Thread.Sleep(3000);
				Reports.ReportLog("ClickonAnyPCIteminChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnyPCIteminChart : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC2"
		
	
		public static void DragLongitudetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.LongitudeInfo.WaitForItemExists(15000);
				repo.VAWindow.ContainerLeftPanel.Longitude.Click("50;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.Longitude.MoveTo("42;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.Longitude.MoveTo("50;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.Panel.MoveTo("70;8");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragLongitudetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragLongitudetoColumn : " + ex.Message);
			}
		}
		
		public static void DragLatitudetoColumn()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.LatitudeInfo.WaitForItemExists(15000);
				repo.VAWindow.ContainerLeftPanel.Latitude.Click("46;11");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerLeftPanel.Latitude.MoveTo("40;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerLeftPanel.Latitude.MoveTo("48;2");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.Panel.MoveTo("191;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragLatitudetoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragLatitudetoColumn : " + ex.Message);
			}
		}
		
		public static void DragProfittoRow1()
		{
			try 
			{
				repo.VAWindow.ContainerLeftPanel.SUMProfitInfo.WaitForItemExists(15000);
				repo.VAWindow.ContainerLeftPanel.SUMProfit.Click("43;6");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.MoveTo("39;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.ContainerLeftPanel.SUMProfit.MoveTo("47;0");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.Panel1.MoveTo("76;14");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragProfittoRow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoRow1 : " + ex.Message);
			}
		}
		
		#endregion
    }
    
}

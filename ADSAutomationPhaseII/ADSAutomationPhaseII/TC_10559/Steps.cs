
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

namespace ADSAutomationPhaseII.TC_10559
{
    
    public static class Steps
    {
        public static TC10559Repo repo = TC10559Repo.Instance;
       	public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		public static string TC_10556_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10556"].ToString();
		
		public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(2000);
				repo.Application.FileMenu.EnsureVisible();
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickonFileMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu  : " + ex.Message);
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
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpen  : " + ex.Message);
				
			}
    	}
				
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile  : " + ex.Message);
			}
    	}
		
		public static void ClickonOpenButton()
		{
			try 
			{
				repo.OpenWindow.OpenButton.ClickThis();
				Reports.ReportLog("Dislayed with VA-tests.vizx data", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton  : " + ex.Message);
			}
    	}
		
		public static void ValidateVAtestsdataWindow()
    	{
    		try 
    		{
    			if(repo.VisualAnalyticsVATestsVizxAsteri.StartWindowInfo.Exists())
    			{
	    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.StartWindowInfo.GetVizxDataWindow();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.StartWindowInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, tableChart, options, "VA-tests.vizx data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateVAtestsdataWindow  : " + ex.Message);
			}
    	}
		
		public static void ChangeChartTypetoLine()
		{
			try 
			{
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Line.Click();
				Reports.ReportLog("Chart Type changed to Line", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoLine  : " + ex.Message);
			}
    	}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.ChartPropertiesWindow.StandardCombo.Click();
				repo.SunAwtWindow.EntireWindow.Click();
				Reports.ReportLog("SelectEntireWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEntireWindow  : " + ex.Message);
			}
    	}
		
		public static void ValidateLineChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetLineChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			System.Threading.Thread.Sleep(5000);
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options,"", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
			}
    	}  
		
		public static void ClickonLabel()
		{
			try
			{
				repo.ChartPropertiesWindow.Label.Click();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ClickonLabel", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLabel  : " + ex.Message);
			}
    	}		

    	public static void CheckMarkonShowData()
		{
			try
			{
				repo.LabelWindow.ShowData.ClickThis();
				Reports.ReportLog("Values are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckMarkonShowData  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateShowdata()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetShowData();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options,"Showdata chart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowdata  : " + ex.Message);
			}
    	}  
    	
    	public static void DragCurrencyCodetoColor()
		{
			try
			{
				
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CurrencyCode.Click("68;10");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CurrencyCode.MoveTo("62;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CurrencyCode.MoveTo("70;1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VisualAnalyticsVATestsVizxAsteri.Color.MoveTo("20;23");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            System.Threading.Thread.Sleep(500);
	            
	            Reports.ReportLog("DragCurrencyCodetoColor ", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCurrencyCodetoColor  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateCurrencycodeColorChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetCurrencycodeColorChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options, " After drag Currency to color Chart data validate", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCurrencycodeColorChart  : " + ex.Message);
			}
    	}  
    	
    	public static void DragFreighttoRowDeck()
		{
			try
			{
				repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMFreight.Click("54;5");
                Delay.Milliseconds(200);
            
            
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMFreight.MoveTo("44;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMFreight.MoveTo("52;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VisualAnalyticsVATestsVizxAsteri.Panel.MoveTo("278;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("Line graph is changed as per the new addition", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreighttoRowDeck  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateFreightdragtoRowChart()
    	{
    		try 
    		{
    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetFreightDragtoRowChart();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
    			Validate.ContainsImage(info, LineChart, options, "After Freight drag to RowChart data image comparision", false);
    			Reports.ReportLog("Validate Freight drag to RowChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragFreighttoRowDeck  : " + ex.Message);
			}
    	}
    	
    	public static void ClickonAxes()
		{
			try
			{
				repo.ChartPropertiesWindow.Axes.Click();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ClickonAxes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAxes  : " + ex.Message);
			}
    	}
    	
    	public static void ClickonMergedAxes()
		{
			try
			{
				repo.LabelWindow.MergedAxes.Click();
				
                Reports.ReportLog("Line graphs are merged and share a single scale on y-axis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonMergedAxes  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateMergedSharedscaleChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetMergeSharedscaleOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options, " MergeShared scale Option data validate", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMergedSharedscaleChart  : " + ex.Message);
			}
    	}  
    	
    	public static void ClickonMergedSeparate()
		{
			try
			{
				repo.LabelWindow.MergedSeparate.Click();
				Reports.ReportLog("Separate lines are displayed with single y-axis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonMergedSeparate  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateMergedseparateOptionChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetMergedSeparatescaleOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options, " MergeSeparate scale Option data validate", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMergedseparateOptionChart  : " + ex.Message);
			}
    	}  
    	
    	public static void ClickonDualAxes()
		{
			try
			{
				repo.LabelWindow.DualAxes.Click();
				Reports.ReportLog("Line graph with dual y-axis is generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonDualAxes  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateDualAxesOptionChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetDualAxesOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, LineChart, options, " Dual Axes option data validation", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMergedseparateOptionChart  : " + ex.Message);
			}
    	}  
    	
    	public static void SwaptheRowandColumn()
		{
			try
			{
				repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.Click("38;9");
                Delay.Milliseconds(200);
            
            
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.MoveTo("41;12");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.MoveTo("49;4");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.MultiSplitWorksheetDollarMultiGlassPane.MoveTo("202;9");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("Columns and rows are interchanged", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SwaptheRowandColumn  : " + ex.Message);
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
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickCloseVA  : " + ex.Message);
			}
    	}
    }	
    
}

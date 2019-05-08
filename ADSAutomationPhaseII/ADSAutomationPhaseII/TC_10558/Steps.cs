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

namespace ADSAutomationPhaseII.TC_10558
{
   
    public static class Steps
    {
    	
    	public static TC10558Repo repo = TC10558Repo.Instance;
       	public static PreconditionRepo preRepo = PreconditionRepo.Instance;
		public static string MSEXCEL_PATH = System.Configuration.ConfigurationManager.AppSettings["MSEXCEL_PATH"].ToString();
		public static string TC_10556_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10556"].ToString();
       
        public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(1000);
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
		
    	public static void ChangeChartTypetoBar()
		{
			try
			{
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Bar.Click();
				Reports.ReportLog("Chart Type is changed to Bar and displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoBar  : " + ex.Message); 
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
			
        public static void ValidateBarChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetBarChart1();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"BarChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateBarChart  : " + ex.Message);
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
				Reports.ReportLog("Values are displayed on the bars", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckMarkonShowData  : " + ex.Message);
			}
    	}
    	
    	public static void ValidateShowdataChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetShowDataChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"ShowDataChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowdataChart  : " + ex.Message);
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
	            
	            Reports.ReportLog("Colors are assigned and bars are displayed ", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
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
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetCurrencycodeColorChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"After drag Currencycode to Color Chart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCurrencycodeColorChart  : " + ex.Message);
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
    	
    	public static void SelectClustered()
		{
			try
			{
				repo.LabelWindow.Clustered.Click();
				Reports.ReportLog("Bars are displayed individually as per the data", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectClustered  : " + ex.Message);
			}
    	}   
    	
    	public static void ValidateClusteredOptionChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetClusteredOptionChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"Clustered Option Chart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateClusteredOptionChart  : " + ex.Message);
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
	            Reports.ReportLog("Bar graph is changed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreighttoRowDeck  : " + ex.Message);
			}
    	}   
    	
    	public static void ValidateFreightDataChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetFreightDataChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"After drag  Freight to RowDeck Chart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateFreightDataChart  : " + ex.Message);
			}
    	}
    	
    	public static void ClickonMergedAxes()
		{
			try
			{
				repo.LabelWindow.MergedAxes.Click();
				Reports.ReportLog("Bar graphs are merged and share a single scale on y-axis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonMergedAxes  : " + ex.Message);
			}
    	}   
    	
    	public static void ValidateMergedSharedOptionChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetSharedScaleOptionChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"SharedScale OptionChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMergedSharedOptionChart  : " + ex.Message);
			}
    	}
    	
    	public static void ClickonStacked()
		{
			try
			{
				repo.LabelWindow.Stacked.Click();
				Reports.ReportLog("Bar graph is stacked back to one on top of the other", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonStacked  : " + ex.Message);
			}
    	}   
    	
    	public static void ValidateStackedOptionChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			if(repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetStackedOptionChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"Stacked Option Chart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateStackedOptionChart  : " + ex.Message);
			}
    	}
    	
    	public static void ClickonDualAxes()
		{
			try
			{
				repo.LabelWindow.DualAxes.Click();
				Reports.ReportLog("Bar graph with dual y-axis is generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

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
	    			CompressedImage BarChart = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo.GetDualAxesOptionChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, BarChart, options,"DualAxes Option Chart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDualAxesOptionChart  : " + ex.Message);
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

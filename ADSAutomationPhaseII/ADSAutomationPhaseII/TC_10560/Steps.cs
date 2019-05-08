
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

namespace ADSAutomationPhaseII.TC_10560
{
    
    public static class Steps
    {
        public static TC10560Repo repo = TC10560Repo.Instance;
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
				Reports.ReportLog("Displayed with VA-tests.vizx data", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			
    			if(repo.VATest.StartWindowInfo.Exists())
    			{
	    			CompressedImage LineChart = repo.VATest.StartWindowInfo.GetVizxDataWindow();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.StartWindowInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, LineChart, options,"Validate VA tests data Window", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateVAtestsdataWindow  : " + ex.Message);
			}
    	}  
       
		public static void ChangeChartTypetoArea()
		{
			try 
			{
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Area.Click();
				Reports.ReportLog("Chart Type is changed to Area and Area graph displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoArea  : " + ex.Message);
			}
    	}
		
		public static void SelectEntireWindow()
		{
			try
			{
				repo.ChartPropertiesWindow.StandardCombo.Click();
				repo.SunAwtWindow.EntireWindow.Click();
				Reports.ReportLog("Chart Type is changed to Bar and displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				throw new Exception("Click on File Menu Failed :", ex);
			}
    	}
		
		public static void ValidateAreaChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetAreaChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"AreaChart data image comparision", false);
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
				Reports.ReportLog("Values are displayed on the graph", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetShowData();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"Validate show Chartdata image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
			}
    	}  
    	  	
    	public static void DragCurrencyCodetoColor()
		{
			try
			{
				
	            repo.VATest.ContainerContentPanel.CurrencyCode.Click("68;10");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CurrencyCode.MoveTo("62;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CurrencyCode.MoveTo("70;1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.Color.MoveTo("20;23");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            System.Threading.Thread.Sleep(500);
	            
	            Reports.ReportLog("Colors are assigned and Area graph are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetCurrencycodeColorChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"After drag Currency code to Color Chartdata image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
			}
    	}  
    	
    	public static void DragFreighttoRowDeck()
		{
			try
			{
				repo.VATest.ContainerContentPanel.SUMFreight.Click("54;5");
                Delay.Milliseconds(200);
            
            
	            repo.VATest.ContainerContentPanel.SUMFreight.MoveTo("44;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VATest.ContainerContentPanel.SUMFreight.MoveTo("52;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.Panel.MoveTo("278;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("Area graph is changed as per the new addition", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetDragFreightrowChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"After Drag Freight to row Chartdata image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
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
				Reports.ReportLog("Area graphs are merged and share a single scale on y-axis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetMergedScaleOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"MergedScale Option data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
			}
    	}  
    	
    	public static void ClickonMergedSeparate()
		{
			try
			{
				repo.LabelWindow.MergedSeparate.Click();
				Reports.ReportLog("Separate Areas are displayed with single y-axis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetMergedSeparateOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"MergedSeparate Option data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateLineChart  : " + ex.Message);
			}
    	}  
    	
    	public static void ClickonUnstacked()
		{
			try
			{
				repo.LabelWindow.Unstacked.Click();
				Reports.ReportLog("have to change ", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonUnstacked  : " + ex.Message);
			}
    	}	
    	
    	public static void ValidateUnstackedOptionChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetUnstackedOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"Unstacked Option data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateUnstackedOptionChart  : " + ex.Message);
			}
    	}  
    	
    	public static void ClickonDualAxes()
		{
			try
			{
				repo.LabelWindow.DualAxes.Click();
				Reports.ReportLog("Area graph with dual y-axis is generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage AreaChart = repo.VATest.BIChartOverlayPanelInfo.GetDualAxesOption();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, AreaChart, options,"DualAxes Option data image comparision", false);
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
				repo.VATest.ContainerContentPanel.Rows.Click("38;9");
                Delay.Milliseconds(200);
            
            
	            repo.VATest.ContainerContentPanel.Rows.MoveTo("41;12");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.Rows.MoveTo("49;4");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VATest.ContainerContentPanel.MultiSplitWorksheetDollarMultiGlassPane.MoveTo("202;9");
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

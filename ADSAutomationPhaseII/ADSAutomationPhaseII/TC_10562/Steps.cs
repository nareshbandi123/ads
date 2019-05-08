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

namespace ADSAutomationPhaseII.TC_10562
{
        
    public static class Steps 
    {
       
        public static TC10562Repo repo = TC10562Repo.Instance;
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
				Reports.ReportLog("Displayed with VA-tests.vizx ShapeChart", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
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
	    			Validate.ContainsImage(info, LineChart, options,"Validate VAtests ShapeChart Window", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateVAtestsdataWindow  : " + ex.Message);
			}
    	}  
       
		public static void ChangeChartTypetoShape()
		{
			try 
			{
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Shape.ClickThis();
				Reports.ReportLog("Chart Type is changed to Shape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoShape  : " + ex.Message);
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
		
		public static void ValidateShapeChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetShapeChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, ShapeChart, options,"ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShapeChart  : " + ex.Message);
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
    	
    	public static void ValidateShowData()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetShowData();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, ShapeChart, options,"ShowData image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateShowData  : " + ex.Message);
			}
    	}  
				
    	public static void RightClickonShipDate()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.ChartPropertiesWindow.ShipDate, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("RightClickonShipDate", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickonShipDate  : " + ex.Message);
			}
    	}
    	
		public static void RemoveShipdate()
		{
			try 
			{
				repo.SunAwtWindow.Remove.ClickThis();
					
				Reports.ReportLog("YEAR(ShipDate) is removed from columns deck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveShipdate  : " + ex.Message);
			}
    	}
		
		public static void ValidateAfterRemoveShipdate()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetAfterRemoveShipdate();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, ShapeChart, options,"After Remove Shipdate ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterRemoveShipdate  : " + ex.Message);
			}
    	}  
		
		public static void RightClickonCardType()
		{
			try 
			{
				Ranorex.Mouse.Click(repo.ChartPropertiesWindow.CardType, System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
				Reports.ReportLog("RightClickonCardType", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickonCardType  : " + ex.Message);
			}
    	}
		
		public static void RemoveCardType()
		{
			try 
			{
				repo.SunAwtWindow.Remove.ClickThis();
				Reports.ReportLog("Card Type is removed from rows deck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveCardType  : " + ex.Message);
			}
    	}
		
		public static void ValidateAfterRemoveCardType()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetAfterRemoveCardtype();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, ShapeChart, options,"After Remove Cardtype ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterRemoveCardType  : " + ex.Message);
			}
    	}  
		
		public static void DragFreighttoColumn()
		{
			try 
			{
				repo.VATest.ContainerLeftPanel.SUMFreight.Click("49;10");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.SUMFreight.MoveTo("44;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.SUMFreight.MoveTo("52;1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerWorksheetPanel.Panel.MoveTo("47;9");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
            
				Reports.ReportLog("Shape graph is changed as per the new addition", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreighttoColumn  : " + ex.Message);
			}
    	}
		
		public static void ValidateDragFreighttoColumnChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetDragFreighttoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, ShapeChart, options,"After Drag Freight to Column ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragFreighttoColumnChart  : " + ex.Message);
			}
    	}  
		
		public static void DragCurrencytoColor()
		{
			try 
			{
				repo.VATest.ContainerLeftPanel.CurrencyCode.Click("73;9");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.CurrencyCode.MoveTo("59;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.CurrencyCode.MoveTo("67;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerWorksheetPanel.Color.MoveTo("25;28");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
					
				Reports.ReportLog("Colors are assigned and Shape graph are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCurrencytoColor  : " + ex.Message);
			}
    	}
		
		public static void ValidateDragCurrencytoColorChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetDragCurrencytoColor();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, ShapeChart, options,"After Drag Currency code to Color ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragCurrencytoColorChart  : " + ex.Message);
			}
    	}  
		
		public static void DragFreighttoSizeDeck()
		{
			try 
			{
				repo.VATest.ContainerLeftPanel.SUMFreight.Click("53;11");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.SUMFreight.MoveTo("47;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.SUMFreight.MoveTo("55;3");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerWorksheetPanel.Size.MoveTo("28;21");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
				
	            Reports.ReportLog("The size of the ShapeChart in the graph is reset", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreighttoSizeDeck  : " + ex.Message);
			}
    	}
		
		public static void ValidateDragFreighttoSizeChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetDragFreighttoSizedeck();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, ShapeChart, options,"After Drag Freight to Size Deck ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragFreighttoSizeChart  : " + ex.Message);
			}
    	}  
		
		public static void DragProducttoShapeDeck()
		{
			try 
			{
				
				repo.VATest.ContainerLeftPanel.ProductCategory.Click("69;11");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.ProductCategory.MoveTo("53;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerLeftPanel.ProductCategory.MoveTo("61;3");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerWorksheetPanel.Shape.MoveTo("23;24");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
					
				Reports.ReportLog("Shapes are displayed in the minimum size", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProducttoShapeDeck  : " + ex.Message);
			}
    	}
		
		public static void ValidateDragProducttoShapeChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetDragProducttoShapeDeck();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, ShapeChart, options,"After Drag Product to ShapeDeck ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragProducttoShapeChart  : " + ex.Message);
			}
    	}  
		
		public static void SlidermovetoMinimum()
		{
			try 
			{
				repo.VATest.Size.Click("20;21");
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("54;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("62;3");
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.PropertiesPopup.MoveTo("1;90");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
            
				Reports.ReportLog("Shapes are displayed in the minimum size", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SlidermovetoMinimum  : " + ex.Message);
			}
    	}
		
		public static void ValidateSliderMinimumChart()
    	{
    		try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage ShapeChart = repo.VATest.BIChartOverlayPanelInfo.GetSlidermovetoMinimum();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, ShapeChart, options,"After Slider move to Minimum ShapeChart image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSliderMinimumChart  : " + ex.Message);
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

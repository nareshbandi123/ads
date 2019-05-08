
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using System.Windows.Forms;

namespace ADSAutomationPhaseII.TC_10557
{
    public static class Steps
    {
    	public static TC10557Repo repo = TC10557Repo.Instance;
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
				Reports.ReportLog("Click on File Menu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				ClickonFileMenu();
				throw new Exception("Click on File Menu Failed : " + ex);
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
		
    	public static void ChangeChartTypetoTable()
		{
			try
			{
				repo.ChartPropertiesWindow.AutomaticInfo.WaitForItemExists(1000);
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Table.ClickThis();
				Reports.ReportLog("Chart changed to table", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoTable  : " + ex.Message);
			}
		}
    	
    	public static void ValidateTableChart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo.GetTableChart1();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo;
    			Validate.ContainsImage(info, tableChart, options, "Table Chart Image Comparision", false);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateTableChart  : " + ex.Message);
			}
    	}
    	
		public static void DragFreight()
		{
			try 	
			{
			 	repo.VAWindow.FreightInfo.WaitForItemExists(1000);
			 	
			 	repo.VAWindow.Freight.Click("49;9");
		    	Delay.Milliseconds(200);
		    	
				repo.VAWindow.Freight.MoveTo("48;8");
		        Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
		        Delay.Milliseconds(200);
		        
		        repo.VAWindow.Freight.MoveTo("56;0");
		    	Delay.Milliseconds(200);
		    	
		    	repo.VAWindow.ColumnContainer.MoveTo("79;3");
		        Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
		        Delay.Milliseconds(500);
		        
		        Reports.ReportLog("Result should be modified accordingly", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		                   
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragFreight  : " + ex.Message);
			}
			
		}
		
		public static void ValidatetheModifiedResult()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo.GetResultChart();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo;
    			Validate.ContainsImage(info, tableChart, options, "Modified result image comparision", false);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidatetheModifiedResult  : " + ex.Message);
			}
    	}
		
		public static void SwapRowandColumn()
		{
			try 	
			{
				repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.RowsInfo.WaitForItemExists(1000);
		        repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.Click("32;10");
		        Delay.Milliseconds(200);
		        
		        
		        repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.MoveTo("36;16");
		        Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
		        Delay.Milliseconds(200);
		        
		       
		        repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.Rows.MoveTo("44;8");
		        Delay.Milliseconds(200);
		        
		        
		        repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.MultiSplitWorksheetDollarMultiGlassPane.MoveTo("209;11");
		        Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
		        Delay.Milliseconds(200);
		        
		        Reports.ReportLog("Columns and rows are interchanged ", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		        
		         } 
			catch (Exception ex)
			{
				throw new Exception("Failed : SwapRowandColumn  : " + ex.Message);
			}
			
		   }
		
		public static void ValidateCardtypeColorchart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo.GetCardtypeColorChart();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo;
    			Validate.ContainsImage(info, tableChart, options, "CardType chart image comparision", false);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCardtypeColorchart  : " + ex.Message);
			}
    	}
		    
		public static void DragCardtypetoColor()
		{
		try 	
		{
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CardType.Click("58;8");
		    Delay.Milliseconds(200);
		    
		   
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CardType.MoveTo("53;8");
		    Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
		    Delay.Milliseconds(200);
		    
		    
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.CardType.MoveTo("61;0");
		    Delay.Milliseconds(200);
		    
		    
		    repo.VisualAnalyticsVATestsVizxAsteri.Color.MoveTo("29;26");
		    Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
		    Delay.Milliseconds(200);
		    
		    Reports.ReportLog("Color shades are assigned to data in ascending order", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		    
		 } 
		catch (Exception ex)
			{
				throw new Exception("Failed : DragCardtypetoColor  : " + ex.Message);
			}
		
		}
		
		public static void DragSubtotaltoColor()
		{
		try 	
		{
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMSubTotal.Click("50;8");
		    Delay.Milliseconds(200);
		    
		   
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMSubTotal.MoveTo("54;8");
		    Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
		    Delay.Milliseconds(200);
		    
		    
		    repo.VisualAnalyticsVATestsVizxAsteri.ContainerContentPanel.SUMSubTotal.MoveTo("62;0");
		    Delay.Milliseconds(200);
		    
		    
		    repo.VisualAnalyticsVATestsVizxAsteri.Color.MoveTo("26;18");
		    Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
		    Delay.Milliseconds(200);
		    
		    Reports.ReportLog("Color shades are assigned to data in ascending order", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
		
		} 
		catch (Exception ex)
			{
				throw new Exception("Failed : DragSubtotaltoColor  : " + ex.Message);
			}
		
		}
		
		public static void ValidateSubtotaleColorchart()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo.GetSubTotalColorChart();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo;
    			Validate.ContainsImage(info, tableChart, options, "Subtotal chart image comparision", false);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSubtotaleColorchart  : " + ex.Message);
			}
    	}		
		
		public static void ClickOnSettingIcon()
		{
			try
			{
				repo.ChartPropertiesWindow.SettingTabInfo.WaitForItemExists(1000);
				repo.ChartPropertiesWindow.SettingTab.Click();
				Reports.ReportLog("ClickOnSettingIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSettingIcon  : " + ex.Message);
			}
			
		}	
		
		public static void ClickOnHighlight()
		{
			try
			{
				repo.DisplayWindow.HighlightButtonInfo.WaitForItemExists(10000);
				repo.DisplayWindow.HighlightButton.Click();				
				Reports.ReportLog("Entire table is highlighted", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnHighlight  : " + ex.Message);
			}
			
		}
		
		public static void ValidateHighlightTable()
    	{
    		try 
    		{
    			repo.VisualAnalyticsVATestsVizxAsteri.Self.Maximize();
    			CompressedImage tableChart = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo.GetHighlightTable();
    			Imaging.FindOptions options = Imaging.FindOptions.Default;
    			options.Similarity = Configuration.Config.SIMILARITY;
    			RepoItemInfo info = repo.VisualAnalyticsVATestsVizxAsteri.PivotTableOverlayPanelInfo;
    			System.Threading.Thread.Sleep(1000);
    			Validate.ContainsImage(info, tableChart, options, "Validate chart image comparision", false);
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateHighlightTable  : " + ex.Message);
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

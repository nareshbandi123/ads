
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

namespace ADSAutomationPhaseII.TC_10563
{
   
    public static class Steps
    {
        public static TC10563Repo repo = TC10563Repo.Instance;
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
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSliderMinimumChart  : " + ex.Message);
			}
    	}
				
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10556_PATH + "VA-tests.vizx");
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSliderMinimumChart  : " + ex.Message);
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
	    			Validate.ContainsImage(info, LineChart, options,"ValidateVAtestsdataWindow", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateVAtestsdataWindow  : " + ex.Message);
			}
    	}  
       
		public static void ChangeChartTypetoPie()
		{
			try 
			{
				repo.ChartPropertiesWindow.Automatic.Click();
				repo.SunAwtWindow.Pie.ClickThis();
				Reports.ReportLog("Chart Type is changed to Pie", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangeChartTypetoPie  : " + ex.Message);
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
		
		public static void ValidatePieChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetPieChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"PieChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidatePieChart  : " + ex.Message);
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
			catch(Exception ex)
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
			catch(Exception ex)
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
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetShowData();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"ShowData image comparision", false);
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
		
		public static void ValidateAfterRemoveShipdateChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetAfterRemoveShipdate();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"AfterRemoveShipdate data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterRemoveShipdateChart  : " + ex.Message);
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
					
				Reports.ReportLog("RemoveCardType", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : RemoveCardType  : " + ex.Message);
			}
			
		}
		
		public static void ValidateAfterRemoveCardTypeChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetAfterRemoveCardtype();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"AfterRemoveCardtype data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterRemoveCardTypeChart  : " + ex.Message);
			}
    	}  
		
		public static void DragCardtypetoColor()
		{
			try 
			{
				repo.VATest.ContainerContentPanel.CardType.Click("53;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CardType.MoveTo("50;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CardType.MoveTo("58;1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.Color.MoveTo("24;21");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
					
				Reports.ReportLog("Colors are assigned and Pie graph are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCardtypetoColor  : " + ex.Message);
			}
			
		}
		
		public static void ValidateDragCardtypetoCOlorChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetDragCardtypetoColor();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"DragCardtypetoColor data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragCardtypetoCOlorChart  : " + ex.Message);
			}
    	}  
		
		public static void DragCurrencycodetoLabel()
		{
			try 
			{
				repo.VATest.ContainerContentPanel.CurrencyCode.Click("62;7");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CurrencyCode.MoveTo("54;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CurrencyCode.MoveTo("62;-2");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.Label.MoveTo("30;25");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
					
				Reports.ReportLog("Labels are generated and Graph is modified", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCurrencycodetoLabel  : " + ex.Message);
			}
			
		}

		public static void ValidateDragCurrencycodetoLabelChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetCurrencyCodetoLabel();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			System.Threading.Thread.Sleep(5000);
	    			Validate.ContainsImage(info, PieChart, options,"CurrencyCodetoLabel data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragCurrencycodetoLabelChart  : " + ex.Message);
			}
    	}  
		
		public static void SelectMeasuredValues()
		{
			try
			{
				repo.LabelWindow.MeasuredValues.ClickThis();
				Reports.ReportLog("Respective values are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(500);
			}
			catch(Exception ex)
			{
			   throw new Exception("Failed : SelectMeasuredValues  : " + ex.Message);
			}
			
		}	
		
		public static void ValidateSelectMeasuredValueChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetShowMeasuredValues();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"ShowMeasuredValues data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSelectMeasuredValueChart  : " + ex.Message);
			}
    	}  
		
		public static void ClickonOptionsButton()
		{
			try
			{
				repo.ChartPropertiesWindow.OptionsInfo.WaitForItemExists(new Duration(500));
				repo.ChartPropertiesWindow.Options.Click();
				Reports.ReportLog("ClickonOptionsButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonOptionsButton  : " + ex.Message);
			
			}
			
		}	
		
		public static void ClickONButton()
		{
			try
			{
				repo.Datastudio1.ONButton.Click();
				Reports.ReportLog("Pie chart is displayed as a complete circle", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickONButton  : " + ex.Message);
			
			}
			
		}	
		
		public static void ValidateONButtonChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetONButtonChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"ONButtonChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateONButtonChart  : " + ex.Message);
			}
    	}  
		
		public static void DragProfittoColorDeck()
		{
			try 
			{
				repo.VATest.ContainerContentPanel.SUMProfit.Click("48;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.SUMProfit.MoveTo("45;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.SUMProfit.MoveTo("53;0");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.Color.MoveTo("25;21");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
				Reports.ReportLog("Colors are assigned and Pie graph are displayed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProfittoColorDeck  : " + ex.Message);
			}
			
		}
		
		public static void ValidateDragProfittoColorChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetDragProfittoColorDeck();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"DragProfittoColorDeck data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragProfittoColorChart  : " + ex.Message);
			}
    	}  
		
		public static void DragCardTypetoLabel()
		{
			try 
			{        
	            repo.VATest.ContainerContentPanel.CardType.Click("57;9");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CardType.MoveTo("51;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.CardType.MoveTo("59;-1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerContentPanel.Label.MoveTo("31;20");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
				Reports.ReportLog("Labels are generated and Graph is modified", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragCardTypetoLabel  : " + ex.Message);
			}
			
		}
		
		public static void ValidateDragCardTypetoLabelChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetDragCardtypetoLabel();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;
	    			Validate.ContainsImage(info, PieChart, options,"DragCardtypetoLabel data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateDragCardTypetoLabelChart  : " + ex.Message);
			}
    	}  
		
		public static void SetCenterHoleMax()
		{
			try
			{
				repo.VATest.Options.Click("22;19");
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("3;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("11;3");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VATest.ContainerCanvas.MoveTo("107;301");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("A pie chart hollow from inside is generated", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);

				
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SetCenterHoleMax  : " + ex.Message);
			
			}
			
		}	
		
		public static void ValidateMaxHoleChart()
		{
		    try 
    		{
    			repo.VATest.Self.Maximize();
    			if(repo.VATest.BIChartOverlayPanelInfo.Exists())
    			{
	    			CompressedImage PieChart = repo.VATest.BIChartOverlayPanelInfo.GetHoleMaxChart();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			options.Similarity = Configuration.Config.SIMILARITY;
	    			RepoItemInfo info = repo.VATest.BIChartOverlayPanelInfo;	    			
	    			Validate.ContainsImage(info, PieChart, options,"HoleMaxChart data image comparision", false);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateMaxHoleChart  : " + ex.Message);
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

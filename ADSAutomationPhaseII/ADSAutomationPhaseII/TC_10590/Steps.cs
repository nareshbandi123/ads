
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Preconditions;

namespace ADSAutomationPhaseII.TC_10590
{
   
    public static class Steps
    {
   	    public static TC10590Repo repo = TC10590Repo.Instance;
        public static string TC_10590_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10590"].ToString();   	
        
        #region "TC1"
        
		public static void ClickonFileMenu()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(10000);
				repo.Application.FileMenu.EnsureVisible();
				repo.Application.FileMenu.ClickThis();
				
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFileMenu : " + ex.Message);
			}
		}
		
		public static void ClickonOpen()
		{
			try 
			{
				repo.DataStudio.OpenFileInfo.WaitForItemExists(3000);
				repo.DataStudio.OpenFile.ClickThis();
				Reports.ReportLog("ClickonOpen", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpen : " + ex.Message);
			}		
		}
				
		public static void SelectNewFile()
		{
			try 
			{
				repo.OpenWindow.FilePathTextbox.TextBoxText(TC_10590_PATH + "Sample_Data_Source_Maps.vizx");
				Reports.ReportLog("SelectNewFile", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewFile : " + ex.Message);
			}
		}
		
		public static void ClickonOpenButton()
		{
			try 
			{
				repo.OpenWindow.OpenButtonInfo.WaitForItemExists(2000);
				repo.OpenWindow.OpenButton.ClickThis();
				System.Threading.Thread.Sleep(500);
				Reports.ReportLog("ClickonOpenButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOpenButton : " + ex.Message);
			}
		}
		
		public static void ValidateSymboMapShape()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapShape();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateSymboMapShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateSymboMapShape : " + ex.Message);
			}
    	} 
		
		public static void ClickonWorkSheet()
		{
			try 
			{
				repo.VAWindow.WorkSheetInfo.WaitForItemExists(10000);
				repo.VAWindow.Self.Maximize();
				repo.VAWindow.WorkSheet.ClickThis();
				Reports.ReportLog("ClickonWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonWorkSheet : " + ex.Message);
			}
		}
		
		public static void SelectNewWorkSheet()
		{
			try 
			{
				repo.SunAwtWindow.NewWorkSheetInfo.WaitForItemExists(5000);
				repo.SunAwtWindow.NewWorkSheet.ClickThis();
				Reports.ReportLog("SelectNewWorkSheet", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectNewWorkSheet : " + ex.Message);
			}
		}
		
		public static void DragDimensionstoColumns()
		{
			try 
			{
				repo.VAWindow.BIDraggableList1.StateInfo.WaitForItemExists(5000);
				repo.VAWindow.BIDraggableList1.State.Click("43;7");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey down}");
	            Delay.Milliseconds(0);
	            
	           
	            repo.VAWindow.BIDraggableList1.ProductCategory.Click("59;6");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.BIDraggableList1.ProductCategory.Click(System.Windows.Forms.MouseButtons.Right, "59;6");
	            Delay.Milliseconds(200);
	            
	           
	            repo.SunAwtWindow.AddToColumnsDeck.Click("102;12");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey up}");
	            Reports.ReportLog("DragDimensionstoColumns", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDimensionstoColumns : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragStateandPCtoColumn()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragStateandPCtoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDragStateandPCtoColumn", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragStateandPCtoColumn : " + ex.Message);
			}
    	}
		
		public static void DragMeasurestoRows()
		{
			try 
			{
	            repo.VAWindow.SUMProfit.Click("48;11");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "48;10");
	            Delay.Milliseconds(200);
	            
	           
	            repo.SunAwtWindow.AddToRowsDeck.Click("65;13");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragMeasurestoRows", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMeasurestoRows : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragProfittoRow()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragProfittoRow();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDragProfittoRow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragProfittoRow : " + ex.Message);
			}
    	}
		
		public static void ClickonVisualization()
		{
			try 
			{
				repo.VAWindow.VisualizationInfo.WaitForItemExists(1000);
				repo.VAWindow.Visualization.ClickThis();
				Reports.ReportLog("ClickonVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonVisualization : " + ex.Message);
			}
		}
		
		public static void DeselectVisualization()
		{
			try 
			{
				repo.VAWindow.Visualization1.ClickThis();
				Reports.ReportLog("DeselectVisualization", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DeselectVisualization : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonSymbolMapIcon()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapIcon();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonSymbolMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonSymbolMapIcon : " + ex.Message);
			}
    	}
	
		public static void ClickonSymbolMapIcon()
		{
			try 
			{
				repo.VAWindow.SymbolMapInfo.WaitForItemExists(5000);
				repo.VAWindow.SymbolMap.ClickThis();
				Reports.ReportLog("ClickonSymbolMapIcon", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSymbolMapIcon : " + ex.Message);
			}
		}
		
		public static void DragProducttoColorDeck()
		{
			try 
			{
				repo.VAWindow.ProductCategory.Click("55;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ProductCategory.MoveTo("58;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ProductCategory.MoveTo("66;-2");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.Color.MoveTo("16;29");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragProducttoColorDeck", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragProducttoColorDeck : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDragPCtoColor()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragPCtoColor();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDragPCtoColor", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragPCtoColor : " + ex.Message);
			}
    	}
		
		public static void ClickonShape()
		{
			try 
			{
				repo.VAWindow.ShapeInfo.WaitForItemExists(1000);
				repo.VAWindow.Shape.ClickThis();
				Reports.ReportLog("ClickonShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShape : " + ex.Message);
			}
		}
		
		public static void ChangetoTriangleShape()
		{
			try 
			{
				repo.Datastudio1.TriangleShapeInfo.WaitForItemExists(1000);
				repo.Datastudio1.TriangleShape.ClickThis();
				Reports.ReportLog("ChangetoTriangleShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangetoTriangleShape : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangetoTriangeShape()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetChangetoTriangeShape();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterChangetoTriangeShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangetoTriangeShape : " + ex.Message);
			}
    	}
		
		public static void ChangetoCircleShape()
		{
			try 
			{
				repo.Datastudio1.CircleInfo.WaitForItemExists(1000);
				repo.Datastudio1.Circle.ClickThis();
				Reports.ReportLog("ChangetoCircleShape", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ChangetoCircleShape : " + ex.Message);
			}
		}
		
		public static void SizeDecrease()
		{
			try 
			{
	            repo.Datastudio1.JSlider.Click("28;9");
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("28;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("4;12");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("SizeDecrease", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SizeDecrease : " + ex.Message);
			}
		}
		
		public static void ValidateAfterDecreaseSize()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSizeDecrease();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDecreaseSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDecreaseSize : " + ex.Message);
			}
    	}
		
		public static void SizeIncrease()
		{
			try 
			{
	            repo.Datastudio1.JSlider.MoveTo("2;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio1.JSlider.MoveTo("195;12");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("SizeIncrease", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SizeIncrease : " + ex.Message);
			}
		}
		
		public static void ValidateAfterIncreaseSize()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSizeIncrease();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterIncreaseSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterIncreaseSize : " + ex.Message);
			}
    	}
		
		public static void ClickonSize()
		{
			try 
			{
				repo.VAWindow.Size.ClickThis();
				Reports.ReportLog("ClickonSize", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSize : " + ex.Message);
			}
		}
		
		public static void ClickonProductItem()
		{
			try 
			{
				repo.VAWindow.ContainerCanvasInfo.WaitForItemExists(1000);
				repo.VAWindow.ContainerCanvas.Click("510;296");
				System.Threading.Thread.Sleep(3000);
				Reports.ReportLog("ClickonProductItem", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonProductItem : " + ex.Message);
			}
		}
		
		public static void CloseVAWindow()
		{
			try 
			{
				repo.VAWindow.CloseInfo.WaitForItemExists(1000);
				repo.VAWindow.Close.ClickThis();
				Reports.ReportLog("CloseVAWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CloseVAWindow : " + ex.Message);
			}
		}
		
		public static void DiscardButton()
		{
			try 
			{
				repo.SaveChanges.Discard.ClickThis();
				Reports.ReportLog("DiscardButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DiscardButton : " + ex.Message);
			}
		}
		
		 #endregion
		 
		#region "TC2"
		 
		public static void DragDimensionstoColumns1()
		 {
			try 
			{
				repo.VAWindow.BIDraggableList1.Longitude.Click("58;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.BIDraggableList1.BIDraggableList.PressKeys("{LControlKey down}");
	            Delay.Milliseconds(0);
	            
	            
	            repo.VAWindow.BIDraggableList1.Latitude.Click("54;7");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.BIDraggableList1.Latitude.Click(System.Windows.Forms.MouseButtons.Right, "54;7");
	            Delay.Milliseconds(200);
	            
	            
	            repo.SunAwtWindow.AddToColumnsDeck.Click("73;9");
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("DragDimensionstoColumns1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragDimensionstoColumns1 : " + ex.Message);
			}
		 }
		
		public static void ValidateAfterDragDimensionstoColumns1()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragLongitudeandLatitudetoColumn();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDragDimensionstoColumns1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragDimensionstoColumns1 : " + ex.Message);
			}
    	}
		 
		public static void DragMeasurestoRows1()
		 {
			try 
			{
	            repo.VAWindow.SUMProfit.Click("54;6");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.SUMProfit.Click(System.Windows.Forms.MouseButtons.Right, "53;6");
	            Delay.Milliseconds(200);
	            
	            
	            repo.SunAwtWindow.AddToRowsDeck.Click("75;13");
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("DragMeasurestoRows1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragMeasurestoRows1 : " + ex.Message);
			}
		 }
		
		public static void ValidateAfterDragMeasurestoRow1()
		{
    		try 
    		{
    			repo.VAWindow.Self.Maximize();
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetDragProfit1toRow();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterDragMeasurestoRow1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterDragMeasurestoRow1 : " + ex.Message);
			}
    	}
		
		public static void ValidateAfterClickonSymbolMap()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetSymbolMapShape();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonSymbolMap : " + ex.Message);
			}
    	}
		 
		public static void ClickonLongitude()
		 {
			try 
			{
				repo.VAWindow.LongitudeInfo.WaitForItemExists(1000);
				repo.VAWindow.Longitude.Click("100;11");
				Reports.ReportLog("ClickonLongitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLongitude : " + ex.Message);
			}
		}
		 
		public static void ShowFilter()
		{
			try 
			{
				repo.SunAwtWindow.ShowFilterInfo.WaitForItemExists(1000);
				repo.SunAwtWindow.ShowFilter.ClickThis();
				Reports.ReportLog("ShowFilter", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ShowFilter : " + ex.Message);
			}
		}
		
		public static void ValidateAfterChangetoTriangle1()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetChangetoTriangleShape1();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterChangetoTriangle1", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterChangetoTriangle1 : " + ex.Message);
			}
    	}
		 
		public static void LatitudeSilderMoves()
		{
			try 
			{
				repo.VAWindow.RangeSlider1Info.WaitForItemExists(Common.ApplicationOpenWaitTime);
				repo.VAWindow.RangeSlider1.Click("4;11");
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.RangeSlider1.MoveTo("3;12");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.RangeSlider1.MoveTo("114;6");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VAWindow.RangeSlider1Info.WaitForItemExists(Common.ApplicationOpenWaitTime);
	            repo.VAWindow.RangeSlider1.Click("115;9");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.RangeSlider1.MoveTo("115;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.RangeSlider1.MoveTo("10;10");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("LatitudeSilderMoves", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : LatitudeSilderMoves : " + ex.Message);
			}
		}
		
		public static void LongitudeSilderMoves()
		{
			try 
			{
				repo.VAWindow.RangeSliderInfo.WaitForItemExists(10000);
				repo.VAWindow.RangeSlider.MoveTo("4;13");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.VAWindow.RangeSlider.MoveTo("40;10");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.RangeSlider.MoveTo("41;11");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.RangeSlider.MoveTo("5;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Reports.ReportLog("LongitudeSilderMoves", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : LongitudeSilderMoves : " + ex.Message);
			}
		}
		
		public static void ClickonLatitude()
		 {
			try 
			{
				repo.VAWindow.LatitudeInfo.WaitForItemExists(1000);
	            repo.VAWindow.Latitude.Click("97;10");
	            Reports.ReportLog("ClickonLatitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonLatitude : " + ex.Message);
			}
		}
		
		#endregion
		
		#region "TC3"
		
		public static void ClickonShowStateBorders()
		{
			try 
			{
				repo.VAWindow.Self.Maximize();
				repo.VAWindow.ContainerMainPanel.MapCustomizationAmbiguousLocationsInfo.WaitForItemExists(10000);
				repo.VAWindow.ContainerMainPanel.MapCustomizationAmbiguousLocations.Click("118;14");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerMainPanel.MapCustomizationShowStateBorders.Click("83;14");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerMainPanel.MapCustomizationShowStateBorders.Click("83;17");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("ClickonShowStateBorders", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonShowStateBorders : " + ex.Message);
			}
		}
		
		public static void SelectCity()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.GeographyInfo.WaitForItemExists(1000);
				repo.VAWindow.ContainerMainPanel.Geography.Click("49;8");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerMainPanel.Geography.Click(System.Windows.Forms.MouseButtons.Right, "49;8");
	            Delay.Milliseconds(400);
	           
	            repo.AnalysisWindow.GeographicRole.ClickThis();
	           // repo.AnalysisWindow.GeographicRole.Click("84;13");
	           // Delay.Milliseconds(200);
	            
	            repo.DimensionWindow.City.Click("49;14");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("SelectCity", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectCity : " + ex.Message);
			}
		}
		
		public static void ClickonOverviewSymbolMap()
		{
			try 
			{
				repo.VAWindow.ContainerMainPanel.ContainerSheetsPaneInfo.WaitForItemExists(15000);
	            repo.VAWindow.ContainerMainPanel.ContainerSheetsPane.Click("1130;614");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerMainPanel.OverviewSymbolMap.Click("51;11");
	            Delay.Milliseconds(200);	            
	            Reports.ReportLog("ClickonOverviewSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	           
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonOverviewSymbolMap : " + ex.Message);
			}
		}
		
		public static void SelectLatitude()
		{
			try 
			{
	            repo.VAWindow.ContainerMainPanel.SUMLocation.Click("55;10");
	            Delay.Milliseconds(200);
	            
	            
	            repo.VAWindow.ContainerMainPanel.SUMLocation.Click(System.Windows.Forms.MouseButtons.Right, "55;10");
	            Delay.Milliseconds(200);
	            
	            repo.AnalysisWindow.GeographicRole.ClickThis();
	            
	            repo.DimensionWindow.Latitude.Click("55;13");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("SelectLatitude", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	          
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectLatitude : " + ex.Message);
			}
		}
		
		public static void ClickonCustomizeSymbolMap()
		{
			try 
			{
				repo.VAWindow.CustomizeSymbolMapInfo.WaitForItemExists(10000);
				repo.VAWindow.CustomizeSymbolMap.ClickThis();
				Reports.ReportLog("ClickonCustomizeSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonCustomizeSymbolMap : " + ex.Message);
			}
		}
		
		public static void ClickonAnalysis()
		 {
			try 
			{
				repo.VAWindow.AnalysisInfo.WaitForItemExists(2000);
				repo.VAWindow.Analysis.Click("30;12");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("ClickonAnalysis", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAnalysis : " + ex.Message);
			}
		}
		
		public static void SelectEditlocations()
		 {
			try 
			{
				repo.AnalysisWindow.MenuItemMapInfo.WaitForItemExists(1000);
				repo.AnalysisWindow.MenuItemMap.Click("188;8");
	            Delay.Milliseconds(200);
	            
	            repo.DimensionWindow.EditLocations.Click("59;16");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("SelectEditlocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectEditlocations : " + ex.Message);
			}
		}
		
		public static void CheckAmbiguousLocations()
		 {
			try 
			{
				repo.EditLocations.CPanel.ComboBox.Click("8;11");
	            Delay.Milliseconds(200);
	            
	            
	            repo.SunAwtWindow.None.Click("31;10");
	            Delay.Milliseconds(200);
	            
	            repo.EditLocations.CPanel.Apply.Click("34;6");
	            Delay.Milliseconds(200);
	           
	            repo.EditLocations.CPanel.Close.Click("37;10");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("CheckAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void ClickonAmbiguousLocations()
		 {
			try 
			{
				 Mouse.Click(System.Windows.Forms.MouseButtons.Left);
                 Delay.Milliseconds(200);
            
                 repo.VAWindow.MapCustomizationAmbiguousLocationsInfo.WaitForItemExists(10000);
				 repo.VAWindow.MapCustomizationAmbiguousLocations.MoveTo("115;16");
	             Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	             Delay.Milliseconds(200);
	            
	            
	             repo.VAWindow.MapCustomizationAmbiguousLocations.Click("98;18");
	             Delay.Milliseconds(200);
	             Reports.ReportLog("ClickonAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void ResolveAmbiguousLocations()
		 {
			try 
			{
				repo.EditLocations.CPanel.ComboBoxInfo.WaitForItemExists(1000);
				repo.EditLocations.CPanel.ComboBox.Click("5;10");
	            Delay.Milliseconds(200);
	            
	            repo.SunAwtWindow.Fixed.Click("26;8");
	            Delay.Milliseconds(200);
	            
	            repo.EditLocations.ButtonOK.Click("37;11");
	            Delay.Milliseconds(200);	            
	            Reports.ReportLog("ResolveAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ResolveAmbiguousLocations : " + ex.Message);
			}
		}
		
		public static void BuildSymbolMap()
		 {
			try 
			{
	            repo.VAWindow.ContainerMainPanel.BuildSymbolMap.Click("54;18");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("BuildSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : BuildSymbolMap : " + ex.Message);
			}
		}
		
		public static void ClickonGeo()
		 {
			try 
			{
				repo.VAWindow.ContainerMainPanel.TextGeo.Click("21;21");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("ClickonGeo", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonGeo : " + ex.Message);
			}
		}
		
		public static void UncheckShowStateBorder()
		 {
			try 
			{
	            repo.Datastudio1.ShowStateBorder.Click("40;11");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("UncheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
	            
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : UncheckShowStateBorder : " + ex.Message);
			}
		}
		
		public static void CheckShowStateBorder()
		 {
			try 
			{
	            repo.Datastudio1.ShowStateBorder.Click("35;10");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("CheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : CheckShowStateBorder : " + ex.Message);
			}
		}
		
		public static void ValidateAfterClickonShowBoarders()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetShowStateBoarders3();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonShowBoarders", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonShowBoarders : " + ex.Message);
			}
    	} 
		
		public static void ValidateAfterClickonBuildSymbolMap()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetBuildSymbolMap();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonBuildSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonBuildSymbolMap : " + ex.Message);
			}
    	} 
		
		public static void ValidateAfterClickonCustomizeSymbolMap()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetCustomizeSymbolMap();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonCustomizeSymbolMap", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonCustomizeSymbolMap : " + ex.Message);
			}
    	} 
		
		public static void ValidateAfterClickonAmbiguousLocations()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetAmbiguousLocations();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterClickonAmbiguousLocations", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterClickonAmbiguousLocations : " + ex.Message);
			}
    	} 
		
		public static void ValidateAfterUncheckShowStateBorder()
		{
    		try 
    		{
    			if(repo.VAWindow.VisualizationWindowInfo.Exists())
    			{
	    			CompressedImage SymboMapShape = repo.VAWindow.VisualizationWindowInfo.GetWithoutBoarders();
	    			Imaging.FindOptions options = Imaging.FindOptions.Default;
	    			RepoItemInfo info = repo.VAWindow.VisualizationWindowInfo;
	    			bool isvalid = Validate.ContainsImage(info, SymboMapShape, options, "Tree map image data validation", false);
	    			Reports.ReportLog("ValidateAfterUncheckShowStateBorder", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
    			}
    		} 
    		catch (Exception ex)
			{
				throw new Exception("Failed : ValidateAfterUncheckShowStateBorder : " + ex.Message);
			}
    	} 
		
		#endregion
    }
   
}

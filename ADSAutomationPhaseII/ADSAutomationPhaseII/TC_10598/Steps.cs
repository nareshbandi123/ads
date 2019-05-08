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

namespace ADSAutomationPhaseII.TC_10598
{
	public class Steps
	{
		public static TC10589 repoRef = TC10589.Instance;
		public static TC10598 repo = TC10598.Instance;
		public static string TC_10598_PATH = System.Configuration.ConfigurationManager.AppSettings["TC_10598_Path"].ToString();
		
		public static void ClickOnFileMenu()
		{
			try 
			{
				repoRef.Application.FileMenuInfo.WaitForItemExists(20000);
				repoRef.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFileMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFileMenu" +ex.Message);
			}			
		}
		
		public static void ClickOnOpenMenu()
		{
			try 
			{
				repoRef.SunAwtWindow.OpenInfo.WaitForItemExists(20000);
				repoRef.SunAwtWindow.Open.ClickThis();
				Reports.ReportLog("ClickOnOpenMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenMenu" + ex.Message);
			}			
		}
		
		public static void EnterFilePath()
		{
			try 
			{
				repoRef.Open.OpenTextInfo.WaitForItemExists(20000);
				repoRef.Open.OpenText.TextBoxText(TC_10598_PATH + "Sample_Data_Source_Radar_Chart.vizx");
				Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath" + ex.Message);
			}			
		}
		
		public static void ClickOnOpenButton()
		{
			try 
			{
				repoRef.Open.OpenButtonInfo.WaitForItemExists(2000);
				repoRef.Open.OpenButton.ClickThis();
				System.Threading.Thread.Sleep(20000);
				Reports.ReportLog("ClickOnOpenButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenButton" +ex.Message);
			}			
		}
		
		public static void ClickOnMaximize()
		{
			try 
			{
				repoRef.VisualAnalytics.MaximizeInfo.WaitForItemExists(20000);
				repoRef.VisualAnalytics.Maximize.ClickThis();
				Reports.ReportLog("ClickOnMaximize", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnMaximize" +ex.Message);
			}			
		}
		
		public static void CreateNewWorksheet()
		{
			try 
			{
				repoRef.VisualAnalytics.WorksheetInfo.WaitForItemExists(20000);
				repoRef.VisualAnalytics.Worksheet.ClickThis();
            	
				repoRef.SunAwtWindow.NewWorksheetInfo.WaitForItemExists(20000);
            	repoRef.SunAwtWindow.NewWorksheet.ClickThis();
            	
				Reports.ReportLog("CreateNewWorksheet", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : CreateNewWorksheet" +ex.Message);
			}			
		}
		
		public static void DragAtheleteToColumnPane()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.AthleteInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.Athlete.MoveTo("41;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerContentPanel.Athlete.MoveTo("49;1");
	            
	            repo.VisualAnalytics.ContainerContentPanel.ColumnPanelInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.ColumnPanel.MoveTo("124;20");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragAtheleteToColumnPane", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragAtheleteToColumnPane" +ex.Message);
			}			
		}
		
		public static void DragTotalMedalsToRowsPane()
		{
			try 
			{
				repo.VisualAnalytics.ContainerContentPanel.SUMTotalMedalsInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.SUMTotalMedals.MoveTo("59;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.VisualAnalytics.ContainerContentPanel.SUMTotalMedals.MoveTo("67;1");
	            
	            repo.VisualAnalytics.ContainerContentPanel.RowPanelInfo.WaitForItemExists(20000);
	            repo.VisualAnalytics.ContainerContentPanel.RowPanel.MoveTo("91;23");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
				Reports.ReportLog("DragTotalMedalsToRowsPane", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragTotalMedalsToRowsPane" +ex.Message);
			}			
		}
		
		public static void SelectRadarMapVisualization()
		{
			try 
			{
				repoRef.VisualAnalytics.VisualizationInfo.WaitForItemExists(20000);
				repoRef.VisualAnalytics.Visualization.ClickThis();
				
				repo.VisualAnalytics.RadarMapInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.RadarMap.ClickThis();
				
				repoRef.VisualAnalytics.Visualization1Info.WaitForItemExists(20000);
	            repoRef.VisualAnalytics.Visualization1.ClickThis();
	            
				Reports.ReportLog("SelectRadarMapVisualization", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectRadarMapVisualization" +ex.Message);
			}			
		}
		
		public static void ValidateRadarMapChart()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.RadarMapChartInfo, repo.VisualAnalytics.RadarMapChartInfo.GetAtheleteChart(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateRadarMapChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateRadarMapChart :" +ex.Message);
			}			
		}
		
		public static void ClickOnLabel()
		{
			try 
			{
				repo.VisualAnalytics.LabelInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.Label.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ClickOnLabel :" +ex.Message);
			}			
		}
		
		public static void ClickOnOptions()
		{
			try 
			{
				repo.VisualAnalytics.OptionsInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.Options.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ClickOnOptions :" +ex.Message);
			}			
		}
		
		public static void ChooseArea()
		{
			try 
			{
				repo.Datastudio.AreaInfo.WaitForItemExists(200000);
				repo.Datastudio.Area.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ChooseArea :" +ex.Message);
			}			
		}
		
		public static void ValidateAreaChart()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.AreaFillChartInfo, repo.VisualAnalytics.AreaFillChartInfo.GetAreaChart(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateAreaChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateAreaChart :" +ex.Message);
			}			
		}
		
		public static void DragAtheleteToColor()
		{
			try 
			{
	            repo.VisualAnalytics.Athlete.MoveTo("60;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.Athlete.MoveTo("68;1");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.Color.MoveTo("16;20");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
				Reports.ReportLog("DragAtheleteToColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragAtheleteToColor" +ex.Message);
			}			
		}
		
		public static void ChooseCircular()
		{
			try 
			{
				repo.Datastudio.CircularInfo.WaitForItemExists(20000);
				repo.Datastudio.Circular.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ChooseCircular :" +ex.Message);
			}			
		}
		
		public static void SelectShowMeasure()
		{
			try 
			{
				repo.Datastudio.ShowMeasureValuesInfo.WaitForItemExists(20000);
				repo.Datastudio.ShowMeasureValues.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("SelectShowMeasure :" +ex.Message);
			}			
		}
		
		public static void RemoveAthleteFromColor()
		{
			try 
			{
				repo.VisualAnalytics.AthleteInfo.WaitForItemExists(20000);
				repo.VisualAnalytics.Athlete.RightClickThis();
	            
	            repo.SunAwtWindow.RemoveInfo.WaitForItemExists(20000);
	            repo.SunAwtWindow.Remove.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("RemoveAthleteFromColor :" +ex.Message);
			}			
		}
		
		public static void DragGoldMedalsToRows()
		{
			try 
			{
	            repo.VisualAnalytics.SUMGoldMedals.MoveTo("74;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.SUMGoldMedals.MoveTo("82;0");
	            Delay.Milliseconds(200);
	            
	            repo.VisualAnalytics.ContainerContentPanel.RowPanel.MoveTo("219;5");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
				Reports.ReportLog("DragAtheleteToColor", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DragAtheleteToColor" +ex.Message);
			}			
		}
		
		public static void ValidateSplitGraph()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.SplitGraphsInfo, repo.VisualAnalytics.SplitGraphsInfo.GetSplitGraph(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateAreaChart", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateSplitGraph :" +ex.Message);
			}			
		}
		
		public static void SelectMergeGraphs()
		{
			try 
			{
				repo.VisualAnalytics.AxesInfo.WaitForItemExists(200000);
				repo.VisualAnalytics.Axes.ClickThis();
	            
				repo.Datastudio.MergedMeasureInfo.WaitForItemExists(200000);
	            repo.Datastudio.MergedMeasure.ClickThis();
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("SelectMergeGraphs :" +ex.Message);
			}			
		}
		
		public static void ValidateMergedGraph()
		{
			try 
			{
				if(Validate.ContainsImage(repo.VisualAnalytics.MergeGraphsInfo, repo.VisualAnalytics.MergeGraphsInfo.GetMergeGraph(), Imaging.FindOptions.Default, "Validate Show state borders", false))
				{
					Reports.ReportLog("Validation : ValidateMergedGraph", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex) 
			{
				
				throw new Exception("ValidateMergedGraph :" +ex.Message);
			}			
		}
	}
}

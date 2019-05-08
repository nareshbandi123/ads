using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.TC_10538;
using Ranorex;
using Ranorex.Core;

namespace ADSAutomationPhaseII.TC_10539
{
	public class Steps
	{
		public static TC10539Repo repo = TC10539Repo.Instance;
		public static TC10538 repo10538 = TC10538.Instance;
		
		public static void ClickOnFile()
		{
			try 
			{
				repo.Application.FileMenuInfo.WaitForItemExists(20000);
				repo.Application.FileMenu.ClickThis();
				Reports.ReportLog("ClickOnFile", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnFile : " + ex.Message);
			}
		}
		
		public static void SelectOptions()
		{
			try 
			{
				repo.Datastudio.OptionMenuInfo.WaitForItemExists(200000);
				repo.Datastudio.OptionMenu.ClickThis();
				Reports.ReportLog("SelectOptions", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectOptions : " + ex.Message);
			}
		}
		
		public static void ClickOnSQLEditor()
		{
			try 
			{
				repo.Options.SQLEditorTreeitemInfo.WaitForItemExists(5000);
				repo.Options.SQLEditorTreeitem.ClickThis();
				repo.Options.SQLEditorTreeitem.Expand();
				Reports.ReportLog("ClickOnSQLEditor", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : ClickOnSQLEditor : " + ex.Message);
			}
		}
		
		public static void SelectAutoComplete()
		{
			try 
			{
				repo.Options.AutoCompletionInfo.WaitForItemExists(5000);
				repo.Options.AutoCompletion.ClickThis();
				Reports.ReportLog("SelectAutoComplete", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : SelectAutoComplete : " + ex.Message);
			}
		}
		
		public static void UnCheckAutoComplete()
		{
			try 
			{
				repo.Options.AutoCompleteCheckBoxInfo.WaitForItemExists(5000);
				if(repo.Options.AutoCompleteCheckBox.Text.ToLower() == "true")repo.Options.AutoCompleteCheckBox.ClickThis();
				Reports.ReportLog("UnCheckAutoComplete", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : UnCheckAutoComplete : " + ex.Message);
			}
		}
		
		public static void CheckAutoComplete()
		{
			try 
			{
				repo.Options.AutoCompleteCheckBoxInfo.WaitForItemExists(5000);
				if(repo.Options.AutoCompleteCheckBox.Text.ToLower() != "true")repo.Options.AutoCompleteCheckBox.ClickThis();
				Reports.ReportLog("CheckAutoComplete", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CheckAutoComplete : " + ex.Message);
			}
		}
		
		public static void ClickOnOKButton()
		{
			try 
			{
				repo.Options.OkButtonInfo.WaitForItemExists(5000);
				repo.Options.OkButton.ClickThis();
				Reports.ReportLog("ClickOnOKButton", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : ClickOnOKButton : " + ex.Message);
			}
		}
		
		
		public static void SelectSyntaxColor()
		{
			try 
			{
				repo.Options.SyntaxColorInfo.WaitForItemExists(5000);
				repo.Options.SyntaxColor.ClickThis();
				Reports.ReportLog("SelectSyntaxColor", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectSyntaxColor : " + ex.Message);
			}
		}
		
		public static void UnCheckEnabled()
		{
			try 
			{
				repo.Options.SyntaxColorEnabledCheckboxInfo.WaitForItemExists(5000);
				if(repo.Options.SyntaxColorEnabledCheckbox.Text.ToLower() == "true")repo.Options.SyntaxColorEnabledCheckbox.ClickThis();
				Reports.ReportLog("UnCheckEnabled", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : UnCheckEnabled : " + ex.Message);
			}
		}
		
		public static void CheckEnabled()
		{
			try 
			{
				repo.Options.SyntaxColorEnabledCheckboxInfo.WaitForItemExists(5000);
				if(repo.Options.SyntaxColorEnabledCheckbox.Text.ToLower() != "true")repo.Options.SyntaxColorEnabledCheckbox.ClickThis();
				Reports.ReportLog("CheckEnabled", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : CheckEnabled : " + ex.Message);
			}
		}
		
		public static void SelectAbbrivation()
		{
			try 
			{
				repo.Options.AbbrevationInfo.WaitForItemExists(5000);
				repo.Options.Abbrevation.ClickThis();
				Reports.ReportLog("SelectAbbrivation", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch //(Exception ex)  
			{
				//throw new Exception("Failed : SelectAbbrivation : " + ex.Message);
			}
		}
		
		public static void ClickOnAddNewIcon()
		{
			try 
			{
				repo.Options.AddNewAbbrevationIconInfo.WaitForItemExists(5000);
				repo.Options.AddNewAbbrevationIcon.Click();
				Reports.ReportLog("ClickOnAddNewIcon", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch //(Exception ex)  
			{
				//throw new Exception("Failed : ClickOnAddNewIcon : " + ex.Message);
			}
		}
		
		public static void DeleteAbbrevation()
		{
			try 
			{
				repo.Options.RemoveAbbrivationIconInfo.WaitForItemExists(5000);
				repo.Options.RemoveAbbrivationIcon.Click();
				Reports.ReportLog("DeleteAbbrevation", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch //(Exception ex)  
			{
				//throw new Exception("Failed : ClickOnAddNewIcon : " + ex.Message);
			}
		}
		
		public static void EnterAbbrivationDetails()
		{
			try 
			{
				repo.NewAbbrevation.SelfInfo.WaitForItemExists(5000);
				repo.NewAbbrevation.NameTextbox.PressKeys("Test");
				repo.NewAbbrevation.OkButton.ClickThis();
				
				repo.Options.AbbrivationTextboxInfo.WaitForItemExists(5000);
				repo.Options.AbbrivationTextbox.PressKeys("select * from ads_table");
				repo.Options.AbbrivationCombobox.Text = "Enter";
				ClickOnOKButton();
				Reports.ReportLog("EnterAbbrivationDetails", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch //(Exception ex)  
			{
				//throw new Exception("Failed : EnterAbbrivationDetails : " + ex.Message);
			}
		}
		
		public static void CloseOptionWindow()
		{
			try 
			{
				repo.Options.SelfInfo.WaitForItemExists(5000);
				repo.Options.Self.Close();
				if(repo.OptionWindow.SelfInfo.Exists(new Duration(2000))) repo.OptionWindow.YesButton.ClickThis();
				Reports.ReportLog("CloseOptionWindow", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CloseOptionWindow : " + ex.Message);
			}
		}
		
		public static void ValidateAutoComplete()
		{
			try 
			{
				Preconditions.Steps.SelectedServerTreeItem.RightClickThis();
        		Preconditions.Steps.ConnectServer();
        		Preconditions.Steps.QueryAnalyser();
        		
        		repo10538.UntitledApplication.QATextEditor.Click();
				
        		Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo10538.UntitledApplication.QATextEditor.PressKeys("select * from ads_table");
				repo10538.UntitledApplication.QATextEditor.Click();	
				
				Reports.ReportLog("ValidateAutoComplete", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ValidateAutoComplete : " + ex.Message);
			}
		}
		
		public static void ValidateSyntaxColor()
		{
			try 
			{				
        		Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo10538.UntitledApplication.QATextEditor.PressKeys("select * from ads_table");
				repo10538.UntitledApplication.QATextEditor.Click();	
				
				Reports.ReportLog("ValidateSyntaxColor", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : ValidateSyntaxColor : " + ex.Message);
			}
		}
		
		public static void ValidateAbbrivation()
		{
			try 
			{				
        		Keyboard.Press(Keyboard.ToKey("Ctrl+A"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				Keyboard.Press(Keyboard.ToKey("Delete"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
				repo10538.UntitledApplication.QATextEditor.PressKeys("Test");
				repo10538.UntitledApplication.QATextEditor.Click();	
				Keyboard.Press(Keyboard.ToKey("Enter"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
				
				Preconditions.Steps.CloseTab(Config.TestCaseName);
				
				if(repo.DicardWindow.DicardButtonInfo.Exists(new Duration(2000))) repo.DicardWindow.DicardButton.ClickThis();
				
				Reports.ReportLog("ValidateAbbrivation", Reports.ADSReportLevel.Success,null, Config.TestCaseName);
			} 
			catch (Exception ex)  
			{
				throw new Exception("Failed : ValidateAbbrivation : " + ex.Message);
			}
		}
	}
}

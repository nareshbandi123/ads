using System;
using System.Drawing;
using System.Text;
using ADSAutomationPhaseII.Extensions;
using ADSAutomationPhaseII.Commons;
using Ranorex.Core;
using Ranorex;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Configuration;

namespace ADSAutomationPhaseII.TC_10555
{
   
    public static class Steps
	{
		public static TC10555Repo repo = TC10555Repo.Instance;
		public const string ACTIVATION_URL = "https://store.aquafold.com/validate/ac/6fc25fc8f04a1bde7e161c9c22a3ac1f220%0A216e2587c186d0c1ec3afef1881865f4c7f%0A8e9a8c38956393a620f0fd60fce68575af4%0Ad7b1e362de895beca0e28c502449cb981be%0Ab48085e02c83454be2e98485e1f6e5072b9%0A414884ed553825c0c24b2f0da1151b71812%0A809b75d9c3bd196a3b5e8616048d72752a0%0Abb2bb79b0dcdc75714942ab96ea7ec85eb6%0A152461f9d9676024d1c8dac539b1d985b26%0Af24fcae1e56e0a5d13527f525326410ffdb%0A75bf910ffb5cd1e707c2d5e4e13d8ef4325%0A4ffd63d0ba215f3874c58e7d1608d4862a3%0A394a41b4eaa1e9a444ce18bbc05f0cd3d67%0Ab365f1e277745eddaf03957ae6e2266b880%0A0214ad59e8707aec2b6c402b279cb5781de%0A9ffc5c27fc429c6d794dfad09941fc8e088%0A498b72cd5032e678bcca6d9428bea63b31a%0Afd36e84af51640bc65909fe491a1444b1ef%0Ad63bd6a64a0bbc14a2484ba360a681fb901%0A53acca8eb1f5c62cc985c16ccff1e8ec229%0A0287d69ea3d4624bb18d562f5f366e2a4f9%0A41b1ddc30fdcb317f931b6feea96169e83f%0A00b31bd31f8662922a9451922c33324053d%0A4866c036a0855f3fae5641f5e0d";
		
		public static void ClickonHelpMenu()
		{
			try
			{
				repo.Application.HelpInfo.WaitForExists(new Duration(20000));
				repo.Application.Help.ClickThis();
				Reports.ReportLog("ClickonHelpMenu", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonHelpMenu : " + ex.Message);				
			}
		}
		
		public static void ClickonAboutAquaDataStudio()
		{
			try
			{
				repo.DataStudio.AboutADSInfo.WaitForExists(new Duration(50000));
				repo.DataStudio.AboutADS.ClickThis();
				Reports.ReportLog("Opened with following tabs:'About''System''Fonts''JDBS Drivers''Graphics'with all corresponding information", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonAboutAquaDataStudio : " + ex.Message);
			}
			
		}
		
		public static void ClickOnLicense()
		{
			try
			{
			   repo.SunAwtWindow.LicenseInfo.WaitForExists(new Duration(50000));
			   repo.SunAwtWindow.License.ClickThis();
			   Reports.ReportLog("License for Aqua Data Studio' pop-up opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOnLicense : " + ex.Message);
			}
			
		}		
		
		public static void ClickonProxySetting()
		{
			try
			{
				repo.LicenseforADS.ProxySetting.ClickThis();
				Reports.ReportLog("'Proxy Settings' pop-up opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonProxySetting : " + ex.Message);
			}
		}
		
		public static void ChecktheButton()
		{
			try
			{
				repo.ProxyWindow.UncheckedInfo.WaitForExists(new Duration(50000));
				repo.ProxyWindow.Unchecked.ClickThis();
				Reports.ReportLog("ChecktheButton", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);		
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ChecktheButton : " + ex.Message);
			}
		}  
					
		public static void VerifyTextBoxes()
		{
			try
			{
				//Validate.AttributeContains(repo.ProxyWindow.TextBoxInfo, "Enabled", "false");
				if(repo.ProxyWindow.TextBox.Enabled)
					Reports.ReportLog("VerifyTextBoxes", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);		
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyTextBoxes : " + ex.Message);				
			}
		}		
		    	
		public static void ProxyWindowClose()
		{
			try
			{
				repo.ProxyWindow.CloseInfo.WaitForItemExists(100000);
				repo.ProxyWindow.Close.ClickThis();
				Reports.ReportLog("'Proxy Settings popup closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ProxyWindowClose : " + ex.Message);
			}
		}
		
		public static void DeactivateButton()
		{
			try
			{
				repo.LicenseforADS.Deactivate.ClickThis();
				Reports.ReportLog("Deactivationpop-up Opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DeactivateButton : " + ex.Message);
			}
		}
		
		public static void ConfirmDeactivate()
		{
			try
			{
				repo.ConfirmDeactivationWindow.Yes.ClickThis();
				Reports.ReportLog("Confirm Deactivationpop-up Opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConfirmDeactivate : " + ex.Message);
			}
		}
		
		public static void ClickonManualActivate()
		{
			try
			{
				repo.LicenseforADS.ManualActivate.ClickThis();
				Reports.ReportLog("License window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonManualActivate : " + ex.Message);
			}
		}
	
		public static void ClickforManualActivation()
		{
			try
			{
				repo.ManualActivationWindow.Ok.ClickThis();
				Reports.ReportLog("Manual Activation window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickforManualActivation : " + ex.Message);
			}
		}
		
		public static void ClickonManualDeactivation()
		{
			try
			{
				repo.LicenseforADS.ManualDeactivation.ClickThis();
				Reports.ReportLog("Manual Deactivation window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonManualDeactivation : " + ex.Message);
			}
		}
		
		public static void ClickonDeactivation()
		{
			try
			{
				repo.ManualDeactivationWindow.Ok.ClickThis();
				Reports.ReportLog("Manual Deactivation Pop-up opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonDeactivation : " + ex.Message);
			}
		}
		
		public static void ClickonActivate()
		{
			try
			{
				repo.LicenseforADS.Activate.ClickThis();
				Reports.ReportLog("License window opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
				System.Threading.Thread.Sleep(5000);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CLickonActivate : " + ex.Message);
			}
		}
		
		public static void ClickonLicenseAgreement()
		{
			try
			{
				repo.LicenseforADS.LicenceAgreement.ClickThis();
				Reports.ReportLog("License Agreement' text file opened and contains all license agreement", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonLicenseAgreement : " + ex.Message);
			}
		}
		
		public static void CloseLicenseAgreement()
		{
			try
			{
				repo.LicenseAgreementWindow.Close.ClickThis();
				Reports.ReportLog("License Agreement' text file closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseLicenseAgreement : " + ex.Message);
			}
		} 
		
		public static void ClickonJDBCDerivers()
		{
			try
			{
				repo.ADSMenu.JDBCdrivers.Click();
				Reports.ReportLog("JDBS Drivers tab opened and contains Driver Class with all existing drivers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonJDBCDerivers : " + ex.Message);
			}
		}
		
		public static void CloseJDBC()
		{
			try
			{
				repo.JDBCMenu.Close.ClickThis();
				Reports.ReportLog("About Aqua Data Studio' pop-up closed", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseJDBC : " + ex.Message);
			}
		} 
		
		public static void ClickonSupportInformation()
		{
			try
			{
				ClickonHelpMenu();				
				repo.DataStudio.SupportInformation.ClickThis();
				Reports.ReportLog("'New Project' window is opened", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonSupportInformation : " + ex.Message);
			}
		}
		
		public static void CloseSupportInformation()
		{
			try
			{
				repo.SupportInfoMenu.Close.ClickThis();
				Reports.ReportLog("Server Information' pop-up should be displayed and contains all information related to selected server", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CloseSupportInformation : " + ex.Message);
			}
		} 
		
		public static void CloseLicWindow()
		{
			try 
			{
				repo.LicenseforADS.CancelButton.ClickThis();
				Reports.ReportLog("CloseLicWindow", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);		
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CloseLicWindow : " + ex.Message);
			}
		}
		
		public static void ClickonServers()
		{ 
			try
			{
				repo.Application.F1Menu.ClickThis();
				Reports.ReportLog("ClickonServers", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);		
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickonServers : " + ex.Message);
			}			
		}   

		public static void OpenActivationInBrowser()
		{
			try 
			{
				Host.Current.OpenBrowser(ACTIVATION_URL, "IE");
				Reports.ReportLog("OpenActivationInBrowser", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : OpenActivationInBrowser : " + ex.Message);
			}
		}
		
		public static void ClickOnGetActivationCode()
		{
			try 
			{
				repo.StoreAquafoldCom.GetCode.Click();
				Reports.ReportLog("ClickOnGetActivationCode", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnGetActivationCode : " + ex.Message);
			}
		}
		
		public static void SelectAll()
		{
			try 
			{
				repo.StoreAquafoldCom.ActivationCodeTextArea.Click();
				Keyboard.PrepareFocus(repo.StoreAquafoldCom.ActivationCodeTextArea);
            	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            	Reports.ReportLog("SelectAll", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : SelectAll : " + ex.Message);
			}
		}
		
		public static void CopyCode()
		{
			try 
			{
				Keyboard.PrepareFocus(repo.StoreAquafoldCom.ActivationCodeTextArea);
            	Keyboard.Press(System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control, 46, Keyboard.DefaultKeyPressTime, 1, true);
				CloseIE();
			}
			catch (Exception ex) 
			{
				throw new Exception("Failed : CopyCode : " + ex.Message);
			}
		}
		
		public static void PasteCode()
		{
			try 
			{
				repo.Application.Self.Activate();
				repo.ManualActivationWindow.Self.Activate();
				repo.ManualActivationWindow.PasteInfo.WaitForItemExists(10000);
				repo.ManualActivationWindow.Paste.ClickThis();
				Reports.ReportLog("PasteCode", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : PasteCode : " + ex.Message);
			}
		}
		
		public static void Deactivate_PasteCode()
		{
			try 
			{
				repo.ManualDeactivationWindow.PasteInfo.WaitForItemExists(10000);
				repo.ManualDeactivationWindow.Paste.ClickThis();
				Reports.ReportLog("Deactivate_PasteCode", Reports.ADSReportLevel.Success, null, Configuration.Config.TestCaseName);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : Deactivate_PasteCode : " + ex.Message);
			}
		}
		
		public static void CloseIE()
		{
			try 
			{
				//repo.MicrosoftEdge.Close.Click("22;19");
				Keyboard.Press(Keyboard.ToKey("Ctrl+F4"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : CloseIE : " + ex.Message);
			}
		}
		
		public static void OpenADS()
		{
			try 
			{
				//Host.Local.KillApplication(Config.ProcessID);
				System.Threading.Thread.Sleep(5000);
				Host.Local.OpenADSApp();
        		repo.Application.SelfInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
        		Reports.ReportLog("ADS Application Open", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
        	} 
        	catch (Exception ex) 
        	{
        		throw new Exception("Failed : OpenADS : " + ex.Message);
        	}
		}
    }
}
    
      
        	
        	
        	
        	
        	
        	
        	
        	
        	
      
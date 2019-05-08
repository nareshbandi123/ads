
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
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Extensions;


namespace ADSAutomationPhaseII.TC_10555.TC1
{
    
    [TestModule("B7AE4BC4-95E1-4196-8066-823138436853", ModuleType.UserCode, 1)]
    public class ADSHelptemplate : BaseClass, ITestModule
    {
        
        public ADSHelptemplate()
        {
           
        }

  		void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Steps.ClickonHelpMenu();
        		Steps.ClickOnLicense();
        		Steps.ClickonProxySetting();
				Steps.ChecktheButton();
				Steps.VerifyTextBoxes();
        		Steps.ProxyWindowClose();
        		Steps.DeactivateButton();
    		    Steps.ConfirmDeactivate();
    		    Steps.OpenADS();
    		    Steps.ClickonManualActivate();
    		    Steps.OpenActivationInBrowser();
    		    Steps.ClickOnGetActivationCode();
    		    Steps.SelectAll();
    		    Steps.CopyCode();
    		    Steps.PasteCode();
    		    Steps.ClickforManualActivation();
    		    Steps.ClickonHelpMenu();
    		    Steps.ClickOnLicense();
    		    Steps.ClickonManualDeactivation();
    		    Steps.ConfirmDeactivate();
    		    Steps.OpenADS();
    		    Steps.Deactivate_PasteCode();    		    
    		    Steps.ClickonDeactivation();
    		    Steps.OpenADS();
    		    Steps.ClickonActivate();
    		    Steps.ClickonHelpMenu();
    		    Steps.ClickOnLicense();    		    
        		Steps.ClickonLicenseAgreement();
        		Steps.CloseLicenseAgreement();
        		Steps.CloseLicWindow();
        		Steps.ClickonHelpMenu();
        		Steps.ClickonAboutAquaDataStudio();
        		Steps.ClickonJDBCDerivers();
        		Steps.CloseJDBC();
        		Steps.ClickonSupportInformation();
        		Steps.CloseSupportInformation();
        		     	
        	}
        	catch (Exception)
        		
        		
        	{
        	}
        	return true;
        }
    }
}
    
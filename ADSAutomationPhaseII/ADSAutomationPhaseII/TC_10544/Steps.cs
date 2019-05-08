
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
using ADSAutomationPhaseII.Configuration;
using ADSAutomationPhaseII.Commons;
using ADSAutomationPhaseII.Preconditions;
using ADSAutomationPhaseII.Extensions;


namespace ADSAutomationPhaseII.TC_10544
{
    public static class Steps 
    {
        public static TC10544Repo repo = TC10544Repo.Instance;
		public static string TC1_10544_Path = System.Configuration.ConfigurationManager.AppSettings["TC1_10544_Path"].ToString();
		
		#region "TC1"
		
		public static void RightClickonserver()
		{
			
			try 
			{
				TreeItem databasesItem = Preconditions.Steps.SelectedServerTreeItem.GetItem("Databases");
				TreeItem adsdbItem = databasesItem.GetItem(Config.ADSDB);
				TreeItem publicItem = adsdbItem.GetItem("public");
				TreeItem tablesItem = publicItem.GetItem("Tables");
				TreeItem adstableItem = tablesItem.GetItem("public.ads_table");
				adstableItem.RightClick();
				Reports.ReportLog("RightClickonserver", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void ClickonQueryBuilder()
		{
			try 
			{
				Preconditions.Steps.SelectedServerTreeItem.Select();
				Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+Q"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);	
				ExplicitWait();
				Reports.ReportLog("ClickonQueryBuilder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void DragTablePantoCntralpan()
		{
			try 
			{
				repo.QueryBuilderWindow.QBContainerPanel.AdsTableInfo.WaitForItemExists(2000);
				repo.QueryBuilderWindow.QBContainerPanel.AdsTable.Click("35;7");
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderWindow.QBContainerPanel.AdsTable.MoveTo("27;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderWindow.QBContainerPanel.AdsTable.MoveTo("35;-1");
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderWindow.QBContainerPanel.Panel.MoveTo("75;12");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("DragTablePantoCntralpan", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragTablePantoCntralpan : " + ex.Message);
			}
    	}
        
        public static void ClickQARun()
        {
    		try
    		{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+E"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		ExplicitWait();
        		
        		Reports.ReportLog("ClickQARun", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickQARun : " + ex.Message);
			}
    	}
        
		public static void Sleep()
    	{
    		System.Threading.Thread.Sleep(200);
    	}
		
        public static void ClickonSave()
        {
    		try
    		{
    			repo.Datastudio.SaveInfo.WaitForItemExists(200000);
    			repo.Datastudio.Save.ClickThis();
    			Reports.ReportLog("ClickonSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonSave : " + ex.Message);
			}
    	}
        
        public static void ClickOnCloseQB()
        {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery2.CloseButtonInfo.WaitForItemExists(20000);
    			repo.QueryBuilderAmazonRedshiftQuery2.CloseButton.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose : " + ex.Message);
			}
    	}
        
        public static void EnterthePath()
        {
    		try
    		{
    			repo.SaveWindow.FilepathTextInfo.WaitForItemExists(200000);
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "Ads_Table");
    			Reports.ReportLog("EnterthePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EnterthePath : " + ex.Message);
			}
    	}
        
        public static void EnterFilePath()
        {
    		try
    		{
    			repo.SaveWindow.FilepathTextInfo.WaitForItemExists(200000);
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "ADS");
    			Reports.ReportLog("EnterFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath : " + ex.Message);
			}
    	}
        
        public static void EntertheSQLPath()
        {
    		try
    		{
    			repo.SaveWindow.FilepathTextInfo.WaitForItemExists(200000);
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "abc");
    			Reports.ReportLog("EntertheSQLPath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheSQLPath : " + ex.Message);
			}
    	}
        
        public static void EntertheQBWPath()
        {
    		try
    		{
    			repo.SaveWindow.FilepathTextInfo.WaitForItemExists(20000);
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "ADS");
    			Reports.ReportLog("EntertheQBWPath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheQBWPath : " + ex.Message);
			}
    	}
        
        public static void SavetheFile()
        {
    		try
    		{
    			repo.SaveWindow.SaveButtonInfo.WaitForItemExists(200000);
    			repo.SaveWindow.SaveButton.ClickThis();
    			Reports.ReportLog("SavetheFile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : SavetheFile : " + ex.Message);
			}
    	}
        
        public static void CickonSaveAs()
        {
    		try
    		{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Shift+S"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		ExplicitWait();
        		Reports.ReportLog("CickonSaveAs", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : CickonSaveAs : " + ex.Message);
			}
    	}
        
        public static void CickonSaveSQL()
        {
    		try
    		{
        		Keyboard.Press(Keyboard.ToKey("Ctrl+Alt+S"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		ExplicitWait();
        		Reports.ReportLog("CickonSaveSQL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : CickonSaveSQL : " + ex.Message);
			}
    	}
      
        public static void CickonSaveResult()
        {
    		try
    		{
    			Sleep();
        		Keyboard.Press(Keyboard.ToKey("Ctrl+R"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        		Sleep();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void CickonSavetofile()
        {
    		try
    		{
    			repo.SaveResultWindow.SAvetofile.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : CickonSavetofile : " + ex.Message);
			}
    	}
        
        public static void Clickonfile()
        {
    		try
    		{
    			repo.QueryBuilderWindow.FileInfo.WaitForItemExists(200000);
    			repo.QueryBuilderWindow.File.ClickThis();
    			Reports.ReportLog("Clickonfile", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : Clickonfile : " + ex.Message);
			}
    	}
        
		public static void ClickOptionsButton()
		{
			try
			{
				repo.Datastudio.OptionsInfo.WaitForItemExists(200000);
				repo.Datastudio.Options.ClickThis();
				Reports.ReportLog("ClickOptionsButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOptionsButton : " + ex.Message);
			}
		}
        
        public static void ClickOkay()
        {
    		try
    		{
    			repo.OptionsWindow.OkayOptionsButtonInfo.WaitForItemExists(20000);
    			repo.OptionsWindow.OkayOptionsButton.Click();
    			Reports.ReportLog("ClickOkay", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOkay : " + ex.Message);
			}
    	}
        
        public static void ClickOnQueryBuilder()
        {
    		try
    		{
    			repo.AquaDataStudio.QueryBuilderInfo.WaitForItemExists(200000);
    			repo.AquaDataStudio.QueryBuilder.ClickThis();
    			Reports.ReportLog("ClickOnQueryBuilder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnQueryBuilder : " + ex.Message);
			}
    	}
        
        public static void ClickOnOpenQueryBuilder()
        {
    		try
    		{
    			repo.DataStudio1.OpenInfo.WaitForItemExists(20000);
    			repo.DataStudio1.Open.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenQueryBuilder : " + ex.Message);
			}
    	}
        
        public static void OpenFile()
        {
    		try
    		{
    			repo.Open.OpenTextboxInfo.WaitForItemExists(20000);
    			repo.Open.OpenTextbox.TextBoxText(TC1_10544_Path + "ADS.qbw");
    			System.Threading.Thread.Sleep(2000);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : OpenFile : " + ex.Message);
			}
    	}
        
        public static void ClickOnOpenFileButton()
        {
    		try
    		{
    			repo.Open.OpenButtonInfo.WaitForItemExists(20000);
    			repo.Open.OpenButton.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnOpenFileButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpenFileButton : " + ex.Message);
			}
    	}
        
        public static void ClickOnCloseButton()
        {
    		try
    		{
    			repo.QueryBuilderWindow.CloseInfo.WaitForItemExists(200000);
    			repo.QueryBuilderWindow.Close.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnCloseButton", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCloseButton : " + ex.Message);
			}
    	}
        
        public static void ClickOnFilePathClose()
        {
    		try
    		{
    			repo.FileOpenWindow.CloseButtonInfo.WaitForItemExists(2000);
    			repo.FileOpenWindow.CloseButton.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFilePathClose : " + ex.Message);
			}
    	}
        
        public static void ClickonNew()
        {
    		try
    		{
    			repo.Datastudio.New.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : CickonSaveSQL : " + ex.Message);
			}
    	}
        
        public static void ClickOnOpen()
        {
    		try
    		{
    			repo.Datastudio.OpenInfo.WaitForItemExists(200000);
    			repo.Datastudio.Open.ClickThis();
    			Reports.ReportLog("ClickOnOpen", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOpen : " + ex.Message);
			}
    	}
        
        public static void ClickOnFileOpen()
        {
    		try
    		{
    			Keyboard.Press(Keyboard.ToKey("Ctrl+O"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFileOpen : " + ex.Message);
			}
    	}
        
        public static void ConnectServer()
        {
    		try
    		{
    			repo.ConnectServerWindow.Connect.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : CickonSaveSQL : " + ex.Message);
			}
    	}
        
        public static void ClickonServer()
        {
    		try
    		{
    			repo.ChooseServerOrDatabase.AmazonRedshift.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonServer : " + ex.Message);
			}
    	}
        
        public static void DragTablepantoCentralpan1()
        {
    		try
    		{
    			repo.QueryBuilderQuery2.AdsTable.Click("33;5");
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderQuery2.AdsTable.MoveTo("29;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderQuery2.AdsTable.MoveTo("37;1");
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderQuery2.Panel.MoveTo("79;15");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonServer : " + ex.Message);
			}
    	}
        
        public static void ServerSelectButton()
        {
    		try
    		{
    			repo.ChooseServerOrDatabase.ButtonOK.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonServer : " + ex.Message);
			}
    	}
        
        public static void ClickonFilemenu()
        {
    		try
    		{
    			repo.QueryBuilderWindow.File.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void ClickonDiscard()
        {
    		try
    		{
    			if(repo.SaveChangesWindow.DiscardInfo.Exists(new Duration(2000)))
    				repo.SaveChangesWindow.Discard.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void ClickonOpen()
        {
    		try
    		{
    			repo.Datastudio.Open.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void OpenButton()
        {
    		try
    		{
    			repo.FileOpenWindow.Open.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void ClickonClose()
        {
    		try
    		{
    			repo.Datastudio.Close.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void CloseQueryBuilder()
        {
    		try
    		{
    			repo.CloseQB.Close.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void CloseQBTab()
		{
			try 
			{
				repo.CloseQB.CloseInfo.WaitForItemExists(1000);
				repo.CloseQB.Close.ClickThis();
				
				if(repo.SaveChangesWindow.SelfInfo.Exists(new Duration(1000)))
					repo.SaveChangesWindow.Discard.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonFilemenu : " + ex.Message);
			}
    	}
        
        public static void EnterFileName()
        {
    		try
    		{
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "Test_Ads");
    			SavetheFile();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        #endregion
        
        #region "TC3"
       
        public static void DragTablepanetoCentralpane()
		{
			
			try 
			{
				repo.QueryBuilderWindow.AdsTable.Click("35;5");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.AdsTable.MoveTo("32;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderWindow.AdsTable.MoveTo("40;-1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.GraphPane.MoveTo("121;30");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);	
	            Reports.ReportLog("DragTablepanetoCentralpane", Reports.ADSReportLevel.Info, null,Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : DragTablepanetoCentralpane : " + ex.Message);
			}
    	}
        
        public static void Execute()
		{
			
			try 
			{
				repo.QueryBuilderWindow.ExecuteButtonInfo.WaitForItemExists(20000);
				repo.QueryBuilderWindow.ExecuteButton.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : Execute : " + ex.Message);
			}
    	}
        
        public static void ClickonQuery()
		{
			
			try 
			{
				repo.QueryBuilderAmazonRedshiftQuery1.QueryInfo.WaitForItemExists(20000);
				repo.QueryBuilderAmazonRedshiftQuery1.Query.ClickThis();
				Reports.ReportLog("ClickonQuery",Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonQuery : " + ex.Message);
			}
    	}
        
        public static void ClickonExecuteEdit()
		{
			
			try 
			{
				repo.Datastudio.ExecuteEditInfo.WaitForItemExists(20000);
				repo.Datastudio.ExecuteEdit.ClickThis();
				Reports.ReportLog("ClickonExecuteEdit",Reports.ADSReportLevel.Success, null, Config.TestCaseName);
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickonExecuteEdit : " + ex.Message);
			}
    	}
        
        public static void ChangetheText()
		{
			
			try 
			{
				repo.EditingWindow.Edit.PressKeys("4352");
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void CLickonNextTab()
		{
			
			try 
			{
				repo.EditingWindow.ClickonNextTab.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void Checkmark()
		{
			
			try 
			{
				repo.EditingWindow.CheckMark.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void ClickonSaveandRefreshButton()
		{
			
			try 
			{
				repo.EditingWindow.SaveButton.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void CloseEditWindow()
		{
			try 
			{
				repo.Datastudio.CloseInfo.WaitForExists(5000);
				repo.Datastudio.Close.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void CopySQL()
		{
			try 
			{
				repo.Datastudio.CloseInfo.WaitForExists(5000);
				repo.Datastudio.Close.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void FormatSQL()
		{
			try 
			{
				repo.Datastudio.FormatSQL.EnsureVisible();
				repo.Datastudio.FormatSQL.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void CheckMarkonBeforeComma()
		{
			try 
			{
				repo.BeautyOptionWindow.Check.ClickThis();
				Steps.ClickOkay();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void ClickOnOk()
		{
			try 
			{
				repo.BeautyOptionWindow.Okay.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void UnselectIdentifier()
		{
			try 
			{
				repo.Datastudio.Identifier.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void ClickonIgnoreUnusedtables()
		{
			try 
			{
				repo.Datastudio.Ignored.ClickThis();
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        #endregion
        
        #region "TC8"
       public static void ClickOnChooseOk()
         {
    		try
    		{
    			repo.ChooseServerOrDatabase.ButtonOKInfo.WaitForItemExists(20000);
    			repo.ChooseServerOrDatabase.ButtonOK.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnChooseOk : " + ex.Message);
			}
    	 }
        
        public static void DragTable()
        {
    		try
    		{
    			repo.QueryBuilderQuery9.AdsTable.Click("43;7");
	            Delay.Milliseconds(200);
	            
	           
	            repo.QueryBuilderQuery9.AdsTable.MoveTo("27;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderQuery9.AdsTable.MoveTo("35;-2");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderQuery9.GraphPane.MoveTo("113;38");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	}
        
        public static void DragToTable()
        {
        	try 
        	{
	            repo.QueryBuilderAmazonRedshiftQuery2.AdsTable.MoveTo("44;5");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery2.AdsTable.MoveTo("52;-3");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery2.Panel.MoveTo("74;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);	
        	} 
        	catch (Exception ex) 
        	{
        		
        		throw new Exception("DragToTable : " +ex.Message);
        	}
        }
        
        public static void SelectSQLFile()
         {
    		try
    		{
    			repo.SaveWindow.FilepathText.TextBoxText(TC1_10544_Path + "Test_Ads");
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
              
         #endregion
         
         public static void VerifyTableOptions()
         {
    		try
    		{
	            repo.QueryBuilderWindow.AdsTable.Click(System.Windows.Forms.MouseButtons.Right, "65;5");
	            Delay.Milliseconds(200);
	            
	            
	            repo.Datastudio.AddToDiagram.Click("37;10");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("Validation : Add to diagram", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
	            
	            repo.QueryBuilderWindow.AdsTable.Click(System.Windows.Forms.MouseButtons.Right, "59;6");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio.AddToFavorite.Click("54;13");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("Validation : Add to favorite", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
	            
	            repo.QueryBuilderWindow.AdsTable.Click(System.Windows.Forms.MouseButtons.Right, "63;4");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio.AddToSelectDeck.Click("55;12");
	            Delay.Milliseconds(200);
	            Reports.ReportLog("Validation : VerifyTableOptions", Reports.ADSReportLevel.Info, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : VerifyTableOptions : " + ex.Message);
			}
    	 }
         
        public static void VerifyOtherOptions()
         {
    		try
    		{
	            repo.QueryBuilderAmazonRedshiftQuery1.Worksheet.MoveTo("33;14");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Worksheet.Click(System.Windows.Forms.MouseButtons.Right, "33;14");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Worksheet.MoveTo("33;14");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Worksheet.Click("48;15");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio4.MenuItemNew.Click("64;8");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio5.DerivedTable.Click("24;10");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTableInfo.WaitForItemExists(200000);
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTable.RightClickThis();
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio4.AddToDiagram.Click("34;13");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTableInfo.WaitForItemExists(200000);
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTable.RightClickThis();
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio4.ClearTablesBeforeAdding.Click("42;12");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTable.RightClickThis();
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio4.Properties.Click("47;13");
	            Delay.Milliseconds(200);
	            
	            repo.FavoritePropertiesAdsTable.Save.Click("45;15");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.AdsTable.RightClickThis();
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio4.Remove.Click("61;11");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.JideButton.Click("16;14");
	            Delay.Milliseconds(200);
	            
	            Keyboard.Press("ads");
	            Delay.Milliseconds(0);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.JideButton.Click("16;14");
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : VerifyTableOptions : " + ex.Message);
			}
    	 }
         
         public static void ClickOnConnectionMenu()
         {
    		try
    		{
    			repo.QueryBuilderWindow.ConnectionMenuInfo.WaitForItemExists(20000);
    			repo.QueryBuilderWindow.ConnectionMenu.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnConnectionMenu", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnConnectionMenu : " + ex.Message);
			}
    	 }
         
         public static void ClickOnAddSchema()
         {
    		try
    		{
    			repo.Datastudio.AddSchemaInfo.WaitForItemExists(20000);
    			repo.Datastudio.AddSchema.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnAddSchema", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAddSchema : " + ex.Message);
			}
    	 }
         
         public static void ClickOnCopySQL()
         {
    		try
    		{
    			repo.Datastudio.CopyToSQLInfo.WaitForItemExists(2000);
    			repo.Datastudio.CopyToSQL.ClickThis();
    			Reports.ReportLog("ClickOnCopySQL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCopySQL : " + ex.Message);
			}
    	 }
         
         public static void ClickOnFormatSQL()
         {
    		try
    		{
    			repo.Datastudio.FormatSQLInfo.WaitForItemExists(2000);
    			repo.Datastudio.FormatSQL.ClickThis();
    			Reports.ReportLog("ClickOnFormatSQL", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormatSQL : " + ex.Message);
			}
    	 }
         
         public static void ClickOnQuoteIdentifier()
         {
    		try
    		{
    			repo.Datastudio.QuoteIdentifierInfo.WaitForItemExists(2000);
    			repo.Datastudio.QuoteIdentifier.ClickThis();
    			Reports.ReportLog("ClickOnQuoteIdentifier", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnQuoteIdentifier : " + ex.Message);
			}
    	 }
         
         public static void ClickOnAutoJoin()
         {
    		try
    		{
    			repo.Datastudio.AutoJoinForeignKeyInfo.WaitForItemExists(20000);
    			repo.Datastudio.AutoJoinForeignKey.ClickThis();
    			Reports.ReportLog("ClickOnAutoJoin", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAutoJoin : " + ex.Message);
			}
    	 }
         
         public static void ClickOnSchemaQualified()
         {
    		try
    		{
    			repo.Datastudio.SchemaQualifiedTablesInfo.WaitForItemExists(20000);
    			repo.Datastudio.SchemaQualifiedTables.ClickThis();
    			Reports.ReportLog("ClickOnSchemaQualified", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSchemaQualified : " + ex.Message);
			}
    	 }
         
         public static void ClickOnIgnoreUnused()
         {
    		try
    		{
    			repo.Datastudio.IgnoreUnusedTableInfo.WaitForItemExists(2000);
    			repo.Datastudio.IgnoreUnusedTable.ClickThis();
    			Reports.ReportLog("ClickOnIgnoreUnused", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnIgnoreUnused : " + ex.Message);
			}
    	 }
         
         public static void ClickOnFormatSQLCancel()
         {
    		try
    		{
    			repo.BeautyOptionWindow.CancelInfo.WaitForItemExists(20000);
    			repo.BeautyOptionWindow.Cancel.ClickThis();
    			Reports.ReportLog("ClickOnFormatSQLCancel", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnFormatSQLCancel : " + ex.Message);
			}
    	 }
         
         public static void AlwaysSQL()
         {
    		try
    		{
            repo.QueryBuilderAmazonRedshiftQuery1.AdsJLabel.Click("12;13");
            Delay.Milliseconds(200);
            
            repo.Datastudio.AlwaysIncludeInSQL.Click("170;7");
            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : AlwaysSQL : " + ex.Message);
			}
    	 }
         
         public static void EnterQueryFilePath()
         {
			try
    		{
				repo.FileOpenWindow.FileNameTextInfo.WaitForItemExists(2000);
    			repo.FileOpenWindow.FileNameText.TextBoxText(TC1_10544_Path + "ADS");
    			Reports.ReportLog("EnterQueryFilePath", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EnterFilePath : " + ex.Message);
			}
    	 }
         
		 public static void ClickOnPublic()
         {
    		try
    		{
    			repo.AddSchema.PublicInfo.WaitForItemExists(20000);
    			repo.AddSchema.Public.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnPublic", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnPublic : " + ex.Message);
			}
    	 }
		 
		 public static void DragIDToWhere()
         {
    		try
    		{
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("19;9");
            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("27;1");
            Delay.Milliseconds(200);
            
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.Panel.MoveTo("126;21");
            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);

    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragIDToWhere : " + ex.Message);
			}
    	 }
		 
		 public static void DragIDToSelect()
         {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery1.CellIdInfo.WaitForItemExists(2000000);
	            repo.QueryBuilderAmazonRedshiftQuery1.CellId.MoveTo("6;12");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.CellId.MoveTo("14;4");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Panel.MoveTo("133;3");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragIDToSelect", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
	    	}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragIDToWhere : " + ex.Message);
			}
    	 }
		 
		 public static void SelectOperator()
         {
    		try
    		{
            Keyboard.Press("{4 up}");
            Delay.Milliseconds(0);
            
            repo.EditWhereCriteriaAdsDbPublicAdsTa.ValueArea.Click("145;21");
            Delay.Milliseconds(200);
            
            repo.EditWhereCriteriaAdsDbPublicAdsTa.ValueArea.PressKeys("4563");
            Delay.Milliseconds(0);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : SelectOperator : " + ex.Message);
			}
    	 }
		 
		 public static void SelectIDCount()
         {
    		try
    		{
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.TextId1.Click(System.Windows.Forms.MouseButtons.Right, "62;3");
            Delay.Milliseconds(200);
            
            repo.Datastudio3.Functions.Click("75;10");
            Delay.Milliseconds(200);
            
            repo.Datastudio2.COUNT.Click("27;14");
            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : SelectIDCount : " + ex.Message);
			}
    	 }
		 
		 public static void DragNameToGroupBy()
         {
    		try
    		{
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("37;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("45;-2");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.GroupPanel.MoveTo("75;17");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);

    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragNameToGroupBy : " + ex.Message);
			}
    	 }
		 
		 public static void DragNameToOrderBy()
         {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery1.NameInfo.WaitForItemExists(2000000);
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("24;8");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("32;0");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.OrderByPanel.MoveTo("97;15");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            Reports.ReportLog("DragNameToOrderBy", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragNameToOrderBy : " + ex.Message);
			}
    	 }
		 
		 public static void DragNameToSelect()
         {
    		try
    		{
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("26;14");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.Name.MoveTo("34;6");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.Panel2.MoveTo("191;6");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(2000);

    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragNameToSelect : " + ex.Message);
			}
    	 }
		 
		 public static void DragIDToGroup()
         {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellIdInfo.WaitForItemExists(2000000);
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("28;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("36;1");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.GroupPanel.MoveTo("65;5");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragIDToGroup : " + ex.Message);
			}
    	 }
		 
		 public static void DragIDToHaving()
         {
    		try
    		{
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("6;12");
            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.CellId.MoveTo("14;4");
            Delay.Milliseconds(200);
            
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.HavingPanel.MoveTo("75;15");
            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Keyboard.Press("4564");
            Delay.Milliseconds(2000);	
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragIDToHaving : " + ex.Message);
			}
    	 }
		 
		 public static void DragToClear()
         {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery1.JPanelInfo.WaitForItemExists(200000);
    			repo.QueryBuilderAmazonRedshiftQuery1.JPanel.Click("10;8");
            	Delay.Milliseconds(200);
            	Reports.ReportLog("DragToClear", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragToClear : " + ex.Message);
			}
    	 }
		 	 
         public static void SelectUnion()
         {
    		try
    		{
    			repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.UnionJLabel.ClickThis();
            	Delay.Milliseconds(200);
            
            	repo.Datastudio.CreateUnion.ClickThis();
            	Delay.Milliseconds(200);
            	Reports.ReportLog("SelectUnion", Reports.ADSReportLevel.Success, null, Config.TestCaseName);

    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : SelectUnion : " + ex.Message);
			}
    	 }
         
         public static void EditData()
         {
    		try
    		{
	            repo.AmazonRedshiftEditingAdsDbPublic.Triveni.Click("30;4");
	            Delay.Milliseconds(200);
	            
	            Keyboard.Press("{Back}");
	            
	            Keyboard.Press("A{LShiftKey down}{Back}{LShiftKey up}XYZ");
	            
	            repo.AmazonRedshiftEditingAdsDbPublic.SaveChangesRefreshButtonInfo.WaitForItemExists(20000);
	            repo.AmazonRedshiftEditingAdsDbPublic.SaveChangesRefreshButton.ClickThis();
	            Delay.Milliseconds(20000);
	            
	            repo.AmazonRedshiftEditingAdsDbPublic.Close.Click("16;13");
	            Delay.Milliseconds(200);
	            
	            Reports.ReportLog("EditData", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EditData : " + ex.Message);
			}
    	 }
         
         public static void DragUnionToCentralPane()
         {
    		try
    		{
            repo.QueryBuilderWindow.AdsTable.MoveTo("62;8");
            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            repo.QueryBuilderWindow.AdsTable.MoveTo("70;0");
            Delay.Milliseconds(200);
            
            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.UnionGraphPane1.MoveTo("89;68");
            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);

    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : SelectUnion : " + ex.Message);
			}
    	 }
         
          public static void DBUnion()
         {
    		try
    		{
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.UnionJLabel.Click("7;9");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio.CreateUnion.Click("115;12");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("63;3");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("71;-5");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.UnionGraphPane.MoveTo("65;58");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("53;5");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("61;-3");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.UnionGraphPane.MoveTo("37;64");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DBUnion : " + ex.Message);
			}
    	 }
         
         public static void WorksheetSubQueryMenu()
         {
    		try
    		{
	            repo.QueryBuilderAmazonRedshiftQuery1.Worksheet.Click("42;15");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio3.MenuItemNew.MoveTo("56;17");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio3.MenuItemNew.MoveTo("72;13");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio2.SubqueryInSelectDeck.Click("29;12");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("64;9");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.AdsTable.MoveTo("72;1");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.SubQueryGraphPane.MoveTo("361;87");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.SubQueryName.MoveTo("21;2");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.SubQueryName.MoveTo("29;-6");
	            Delay.Milliseconds(200);
	            
	            repo.QueryBuilderAmazonRedshiftQuery1.QBContainerPanel.SubQueryPanel.MoveTo("65;4");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.CPanel.WindowsComboBoxUIDollarXPComboBoxButton.Click("8;4");
	            Delay.Milliseconds(200);
	            
	            repo.Datastudio3.LIKE.Click("162;1");
	            Delay.Milliseconds(200);
	            
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.CPanel.ValueArea.Click("162;25");
	            Delay.Milliseconds(200);
	            
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.CPanel.ValueArea.PressKeys("Tom");
	            Delay.Milliseconds(0);
	            
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.CPanel.SaveInfo.WaitForItemExists(20000);
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.CPanel.Save.ClickThis();
	            
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : WorksheetSubQueryMenu : " + ex.Message);
			}
    	 }
         
         public static void DragIDColumnToWhereDeck()
         {
    		try
    		{
    			repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.TreeInfo.WaitForItemExists(200000);
    			repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.Tree.Click("8;26");
            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.IdInt4.MoveTo("31;6");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.IdInt4.MoveTo("39;-2");
	            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.WherePanel.MoveTo("51;44");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            
	            Keyboard.Press("4563");
	            
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.SaveInfo.WaitForItemExists(20000);
	            repo.EditWhereCriteriaAdsDbPublicAdsTa.Save.ClickThis();
    			
    			Reports.ReportLog("DragIDColumnToWhereDeck", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : DragIDColumnToWhereDeck : " + ex.Message);
			}
    	 }

		 public static void ClickOnSaveOperator()
         {
    		try
    		{
    			repo.EditWhereCriteriaAdsDbPublicAdsTa.SaveInfo.WaitForItemExists(200000);
    			repo.EditWhereCriteriaAdsDbPublicAdsTa.Save.ClickThis();
    			Reports.ReportLog("ClickOnSaveOperator", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveOperator : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnSaveHavingCriteria()
         {
    		try
    		{
    			repo.EditHavingCriteria.SaveInfo.WaitForItemExists(200000);
    			repo.EditHavingCriteria.Save.ClickThis();
    			Reports.ReportLog("ClickOnSaveHavingCriteria", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSaveHavingCriteria : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnSchemaOK()
         {
    		try
    		{
    			repo.AddSchema.OkButtonInfo.WaitForItemExists(20000);
    			repo.AddSchema.OkButton.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnSchemaOK", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSchemaOK : " + ex.Message);
			}
    	 }
		 
		 public static void ActivateApplication()
         {
    		try
    		{
    			repo.QueryBuilderWindow.Self.Minimize();
    			repo.AquaDataStudio.Self.Focus();
    			repo.AquaDataStudio.Self.Activate();
    			repo.AquaDataStudio.SelfInfo.WaitForItemExists(20000);
    			Reports.ReportLog("ActivateApplication", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ActivateApplication : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnRefresh()
         {
    		try
    		{
    			repo.QueryBuilderWindow.RefreshInfo.WaitForItemExists(20000);
    			repo.QueryBuilderWindow.Refresh.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnRefresh", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRefresh : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnRightClickRefresh()
         {
    		try
    		{
    			Keyboard.Press(Keyboard.ToKey("F5"), Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
    			ExplicitWait();
    			Reports.ReportLog("ClickOnRightClickRefresh", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRightClickRefresh : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnReconnect()
         {
    		try
    		{
    			repo.QueryBuilderWindow.ReconnectInfo.WaitForItemExists(20000);
    			repo.QueryBuilderWindow.Reconnect.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnReconnect", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnReconnect : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnClose()
         {
    		try
    		{
    			repo.QueryBuilderWindow.CloseButtonInfo.WaitForItemExists(20000);
    			repo.QueryBuilderWindow.CloseButton.ClickThis();
    			Reports.ReportLog("ClickOnClose", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnClose : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnEditConnection()
         {
    		try
    		{
    			repo.Datastudio.EditConnectionInfo.WaitForItemExists(20000);
    			repo.Datastudio.EditConnection.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnEditConnection", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnEditConnection : " + ex.Message);
			}
    	 }
		 
		 public static void EditLoginName()
         {
    		try
    		{
    			repo.EditServerProperties.RootTextboxInfo.WaitForItemExists(20000);
    			repo.EditServerProperties.RootTextbox.TextBoxText("root");
    			ExplicitWait();
    			Reports.ReportLog("EditLoginName", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EditLonginName : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnSave()
         {
    		try
    		{
    			repo.EditServerProperties.SaveInfo.WaitForItemExists(20000);
    			repo.EditServerProperties.Save.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnSave", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnSave : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnCloseConnection()
         {
    		try
    		{
    			repo.ConnectionProperties.CloseInfo.WaitForItemExists(20000);
    			repo.ConnectionProperties.Close.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnCloseConnection", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCloseConnection : " + ex.Message);
			}
    	 }
		 
		 public static void ClickOnProperties()
         {
    		try
    		{
    			repo.Datastudio.PropertiesInfo.WaitForItemExists(20000);
    			repo.Datastudio.Properties.ClickThis();
    			ExplicitWait();
    			Reports.ReportLog("ClickOnProperties", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnProperties : " + ex.Message);
			}
    	 }
		 
		 public static void ScanTable()
         {
    		try
    		{
    			repo.ConnectionProperties.ConnectionTableInfo.WaitForItemExists(20000);
    			Table connectionTable = repo.ConnectionProperties.ConnectionTable;
    			foreach(var row in connectionTable.Rows)
    			{
    				if(row.Cells[0].Text == "Username" && row.Cells[1].Text == "root")
    				{
    					Reports.ReportLog("Validation : Properties updated", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    				}    				
    			}
    			ExplicitWait();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ScanTable : " + ex.Message);
			}
    	 }
		 
		 public static void ActivateQueryBuilder()
         {
    		try
    		{	
    			repo.QueryBuilderWindow.Self.Focus();
    			repo.QueryBuilderWindow.Self.Maximize();
    			repo.QueryBuilderWindow.Self.Activate();
    			repo.QueryBuilderWindow.SelfInfo.WaitForItemExists(20000);
    			Reports.ReportLog("ActivateQueryBuilder", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : ActivateQueryBuilder : " + ex.Message);
			}
    	 }
         
         public static void ClickonWindow()
         {
    		try
    		{
    			repo.QueryBuilderWindow.WindowInfo.WaitForItemExists(200000);
    			repo.QueryBuilderWindow.Window.ClickThis();
    			Reports.ReportLog("ClickonWindow", Reports.ADSReportLevel.Success, null, Config.TestCaseName);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickonWorkSheet()
         {
    		try
    		{
    			repo.QueryBuilderWindow.Worksheet.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickNewItem()
         {
    		try
    		{
    			repo.MenuBarWindow.MenuItemNew.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
       
         public static void SelectWorkSheetdesk()
         {
    		try
    		{
    			repo.WorksheetWindow.SubqueryInSelectDeck.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void DragIdtoWherePanel()
         {
    		try
    		{
    			repo.QueryBuilderWindow.QBContainerPanel.CellId.Click("21;6");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.QBContainerPanel.CellId.MoveTo("59;10");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.QBContainerPanel.CellId.MoveTo("67;2");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.QBContainerPanel.WherePanel.MoveTo("86;3");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickonSubqueryoption()
         {
    		try
    		{
    			repo.EditWhereCriteriaWindow.Subquery.Click();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void SaveEditDesk()
         {
    		try
    		{
    			repo.EditWhereCriteriaWindow.Save.ClickThis();
    		
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
                  
         public static void DragColumntoWhereDeck()
         {
    		try
    		{
    			repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.IdInt4.Click("36;4");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.IdInt4.MoveTo("8;7");
	            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.IdInt4.MoveTo("16;-1");
	            Delay.Milliseconds(200);
	            
	            
	            repo.QueryBuilderWindow.DataPaneAndSheetSplitPane.JDropHint.MoveTo("68;0");
	            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
	            Delay.Milliseconds(200);
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickonUnion()
         {
    		try
    		{
    			repo.EditWhereCriteriaWindow.Union.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ExplicitWait()
    	 {
    		System.Threading.Thread.Sleep(2000);
    	 }
         
         public static void ClickonDerivedClass()
         {
    		try
    		{
    			repo.EditWhereCriteriaWindow.DerivedClass.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickonQuickTableadd()
         {
    		try
    		{
    			repo.Datastudio.QuickTable.ClickThis();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void SelectoneTable()
         {
    		try
    		{
    			repo.Datastudio.EnterName.TextBoxText("ads_table");
    			ClickEnter();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	 }
         
         public static void ClickEnter()
    	{
    		try 
    		{
    			ExplicitWait();
    			Keyboard.Press("{ENTER}");
    			ExplicitWait();
    		}
    		catch (Exception ex)
			{
				throw new Exception("Failed : EntertheText : " + ex.Message);
			}
    	} 
         
        public static void SelectADSDB()
		  {
		     try 
		     {
		     	TreeItem SelectedServer = null ;
		     	SelectServer(ref SelectedServer);
		     	TreeItem adsDB = SelectedServer.GetItem(Config.ADSDB, false);
		        adsDB.Select();
		     } 
		     catch (Exception)
		     {
		     		
		     }
		   }

		public static void SelectServer(ref TreeItem item)
     	{
     		try 
     		{
     			TreeItem SelectedServer = repo.ChooseServerOrDatabase.ServerList.Items[0].Items[0].GetItem(Preconditions.Steps.SelectedServerName, true);
     			item = SelectedServer;
     			if(SelectedServer == null)
				{
					TreeItem server = Preconditions.Steps.GetServerTreeFromTCName(Config.TestCaseName);
	        		Preconditions.Steps.SelectedServerTreeItem = server;
	        		Preconditions.Steps.SelectedServerName = server.Text;
	        		SelectedServer = item = repo.ChooseServerOrDatabase.ServerList.Items[0].Items[0].GetItem(server.Text);
				}
     		} 
     		catch (Exception)
     		{
     			
     		}
     	}
     }
    
}


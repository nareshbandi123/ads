using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ADSAutomationPhaseII.Configuration;
using Ranorex;
using Ranorex.Controls;
using Ranorex.Core;

namespace ADSAutomationPhaseII.Extensions
{
	public static class Extension
	{
		public static void ClickThis(this Ranorex.Cell item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Cell Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.ComboBox item)
		{			
			try
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("ComboBox Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.RadioButton item)
		{			
			try
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("RadioButton Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.Table item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Table Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.Button item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Button Click Failed : " + ex.Message);
			}			
		}
		
		public static void ClickThis(this Ranorex.MenuItem item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("MenuItem Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.TreeItem item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("TreeItem Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.CheckBox item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Checkbox Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.ListItem item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("ListItem Click Failed : " + ex.Message);
			}
		}
		
		public static void TextBoxText(this Ranorex.Text item, string value)
		{
			try 
			{
				item.TextValue = value;
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Textbox text Failed to set : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.Text item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Text Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.TabPage item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("TabPage Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.Row item)
		{
			try 
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Row Click Failed : " + ex.Message);
			}
		}
		
		public static void ClickThis(this Ranorex.Container item)
		{
			try
			{
				item.Click();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Container Click Failed : " + ex.Message);
			}
		}
		
		public static void DoubleClickThis(this Ranorex.TabPage item)
		{
			try
			{
				item.DoubleClick();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Tabpage Click Failed : " + ex.Message);
			}
		}
		
		public static void DoubleClickThis(this Ranorex.Button item)
		{
			try
			{
				item.DoubleClick();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Button Click Failed : " + ex.Message);
			}
		}
		
		public static void DoubleClickThis(this Ranorex.Cell item)
		{
			try
			{
				item.DoubleClick();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("Button Click Failed : " + ex.Message);
			}
		}
		
		public static void RightClickThis(this Ranorex.ListItem item)
		{
			try
			{
				item.RightClick();
				Sleep();	
			} 
			catch (Exception ex) 
			{
				throw new Exception("ListItem Click Failed : " + ex.Message);
			}
		}
		
		public static void RightClick(this Ranorex.ListItem item)
		{
			try 
			{
				Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception ex) 
			{
				throw new Exception("ListItem Right Click Failed : " + ex.Message);
			}
		}
		
		public static void RightClick(this Ranorex.Cell item)
		{
			try 
			{
				Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception ex) 
			{
				throw new Exception("Cell Right Click Failed : " + ex.Message);
			}
		}
		
		public static void RightClick(this Ranorex.Container item)
		{
			try 
			{
				Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception ex) 
			{
				throw new Exception("Container Right Click Failed : " + ex.Message);
			}
		}
		
		public static void RightClick(this Ranorex.Text item)
		{
			try 
			{
				Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			} 
			catch (Exception ex) 
			{
				throw new Exception("Text Right Click Failed : " + ex.Message);
			}
		}
		
		public static void OpenADSApp(this Ranorex.Host host)
		{
			try 
			{
				Config.ProcessID = host.RunApplication(Config.AppPath, "", "", true);
			} 
			catch (Exception ex) 
			{	
				throw new Exception("Open ADS App Failed : " + ex.Message);
			}
		}
		
		public static void CloseADSApp(this Ranorex.Host host)
		{
			try 
			{
				host.CloseApplication(Config.ProcessID);
			} 
			catch (Exception ex) 
			{
				host.ForceCloseADSApp();
				throw new Exception("Close ADS App Failed : " + ex.Message);
			}			
		}
		
		public static void ForceCloseADSApp(this Ranorex.Host host)
		{
			try 
			{
				host.KillApplication(Config.ProcessID);
			} 
			catch (Exception ex) 
			{
				throw new Exception("Close ADS App Failed : " + ex.Message);
			}			
		}
		
		public static void WaitForItemExists(this Ranorex.Core.Repository.RepoItemInfo info, int waitDuration)
		{
			try 
			{
				info.WaitForExists(new Duration(waitDuration));
			} 
			catch(Exception ex)
			{
				throw new Exception("Wait For Item Exists Failed : " + ex.Message);
			}
		}
		
		public static void GetItem(this Ranorex.List list, int index)
        {
        	try 
        	{
	        	list.Items[index].Select();
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("List Get Item Failed : " + ex.Message);
        	}
        }
        
        public static Ranorex.MenuItem GetMenunItem(this Ranorex.ContextMenu treeitem, string dbkey)
        {
        	Ranorex.MenuItem item = null;
        	try 
        	{
	        	foreach (var itemtree in treeitem.Items)
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
						item = itemtree;
						System.Threading.Thread.Sleep(500);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("ContextMenu Get Menun Item Failed : " + ex.Message);
        	}
        	return item;
        }

		public static TreeItem GetItem(this Ranorex.Tree tree, string dbkey, bool isExpand = true)
        {
        	TreeItem item = null;
        	try 
        	{
	        	foreach (var itemtree in tree.Items) 
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
	        			itemtree.Collapse();
	        			if(isExpand)
	        			{
		        			itemtree.Expand();
		        			itemtree.EnsureVisible();
	        			}
						item = itemtree;
						System.Threading.Thread.Sleep(1000);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("Tree Get Item Failed : " + ex.Message);
        	}
        	return item;
        }
		
		public static TreeItem GetItem(this Ranorex.TreeItem treeitem, string dbkey, bool isExpand = true)
        {
        	TreeItem item = null;
        	try 
        	{
	        	foreach (var itemtree in treeitem.Items)
	        	{
	        		if(itemtree.Text.Trim() == dbkey)
	    			{
	        			if(isExpand)
	        			{
	        				itemtree.EnsureVisible();
		        			itemtree.Expand();
	        			}
						item = itemtree;
						System.Threading.Thread.Sleep(1000);
	    				break;
	    			}
	        	}
        	} 
        	catch (Exception ex)
        	{
        		throw new Exception("TreeItem Get Item Failed : " + ex.Message);
        	}
        	return item;
        }
		
		public static void RightClickThis(this Ranorex.TreeItem item)
		{
			try
        	{        		
	        	Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
	        	System.Threading.Thread.Sleep(200);
        	}
        	catch(Exception ex)
        	{
        		throw new Exception("TreeItem Right Click Failed : " + ex.Message);
        	}
		}
		
		public static void Sleep()
		{
			try 
			{
				System.Threading.Thread.Sleep(200);
			} 
			catch (Exception) 
			{
			
			}
		}
		
		public static void DragThisTo(this Adapter dragElement, Adapter destinationElement, string corrdinates = "")
        {
            try
            {
            	dragElement.EnsureVisible();
            	Sleep();
                dragElement.MoveTo();
                Sleep();
                destinationElement.EnsureVisible();
                Sleep();
                destinationElement.Focus();
                Sleep();
                Mouse.ButtonDown(MouseButtons.Left);
                Sleep();
                if(!string.IsNullOrEmpty(corrdinates))
                	destinationElement.MoveTo(corrdinates);
                else
                	destinationElement.MoveTo();
                Sleep();
                Mouse.ButtonUp(MouseButtons.Left);
                Sleep();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed : DragDrop : " + ex.Message);
            }
        } 
	}
}

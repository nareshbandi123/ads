﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace ADSAutomationPhaseII.TC_10601
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TC10601 element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("27ef2f5e-0d2c-4114-a9ab-60791e26fd67")]
    public partial class TC10601 : RepoGenBaseFolder
    {
        static TC10601 instance = new TC10601();
        TC10601Folders.VisualAnalyticsAppFolder _visualanalytics;

        /// <summary>
        /// Gets the singleton class instance representing the TC10601 element repository.
        /// </summary>
        [RepositoryFolder("27ef2f5e-0d2c-4114-a9ab-60791e26fd67")]
        public static TC10601 Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TC10601() 
            : base("TC10601", "/", null, 0, false, "27ef2f5e-0d2c-4114-a9ab-60791e26fd67", ".\\RepositoryImages\\TC1060127ef2f5e.rximgres")
        {
            _visualanalytics = new TC10601Folders.VisualAnalyticsAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("27ef2f5e-0d2c-4114-a9ab-60791e26fd67")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The VisualAnalytics folder.
        /// </summary>
        [RepositoryFolder("2fa84dd5-6c44-4441-a1af-474420f29730")]
        public virtual TC10601Folders.VisualAnalyticsAppFolder VisualAnalytics
        {
            get { return _visualanalytics; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class TC10601Folders
    {
        /// <summary>
        /// The VisualAnalyticsAppFolder folder.
        /// </summary>
        [RepositoryFolder("2fa84dd5-6c44-4441-a1af-474420f29730")]
        public partial class VisualAnalyticsAppFolder : RepoGenBaseFolder
        {
            TC10601Folders.ContainerMainPanelFolder _containermainpanel;
            RepoItemInfo _textmessageInfo;

            /// <summary>
            /// Creates a new VisualAnalytics  folder.
            /// </summary>
            public VisualAnalyticsAppFolder(RepoGenBaseFolder parentFolder) :
                    base("VisualAnalytics", "/form[@title~'^Visual\\ Analytics\\ -\\ \\[Sampl']", parentFolder, 30000, null, false, "2fa84dd5-6c44-4441-a1af-474420f29730", "")
            {
                _containermainpanel = new TC10601Folders.ContainerMainPanelFolder(this);
                _textmessageInfo = new RepoItemInfo(this, "TextMessage", ".//container[@name='_statusBar']//text[@name='_message']", 30000, null, "c7aaf4a4-24f5-4a99-be6f-f9dfe31cb206");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("2fa84dd5-6c44-4441-a1af-474420f29730")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("2fa84dd5-6c44-4441-a1af-474420f29730")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The TextMessage item.
            /// </summary>
            [RepositoryItem("c7aaf4a4-24f5-4a99-be6f-f9dfe31cb206")]
            public virtual Ranorex.Text TextMessage
            {
                get
                {
                    return _textmessageInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The TextMessage item info.
            /// </summary>
            [RepositoryItemInfo("c7aaf4a4-24f5-4a99-be6f-f9dfe31cb206")]
            public virtual RepoItemInfo TextMessageInfo
            {
                get
                {
                    return _textmessageInfo;
                }
            }

            /// <summary>
            /// The ContainerMainPanel folder.
            /// </summary>
            [RepositoryFolder("54e17b03-8175-4534-989c-1f86cdde6983")]
            public virtual TC10601Folders.ContainerMainPanelFolder ContainerMainPanel
            {
                get { return _containermainpanel; }
            }
        }

        /// <summary>
        /// The ContainerMainPanelFolder folder.
        /// </summary>
        [RepositoryFolder("54e17b03-8175-4534-989c-1f86cdde6983")]
        public partial class ContainerMainPanelFolder : RepoGenBaseFolder
        {
            RepoItemInfo _sampledatasourcesymbolmapInfo;
            RepoItemInfo _orderdateInfo;
            RepoItemInfo _windowsscrollbaruidollarwindowsarrowbuttInfo;
            RepoItemInfo _columnspanelInfo;
            RepoItemInfo _quarterorderdateInfo;
            RepoItemInfo _rowpanelInfo;
            RepoItemInfo _sumprofitInfo;
            RepoItemInfo _sumfreightInfo;
            RepoItemInfo _filterpanelInfo;
            RepoItemInfo _productcategoryInfo;

            /// <summary>
            /// Creates a new ContainerMainPanel  folder.
            /// </summary>
            public ContainerMainPanelFolder(RepoGenBaseFolder parentFolder) :
                    base("ContainerMainPanel", "container[@name='_mainPanel']", parentFolder, 30000, null, false, "54e17b03-8175-4534-989c-1f86cdde6983", "")
            {
                _sampledatasourcesymbolmapInfo = new RepoItemInfo(this, "SampleDataSourceSymbolMap", ".//container[@name='_leftPanel']//container[@type='BIDataSourceDataPane']/container[@name='dataSourceScroll']/?/?/list[@name='listComponent']/listitem[@text~'^Sample\\ Data\\ Source\\ Symbol']", 30000, null, "d6d13803-6613-4db1-bbd0-1476a00b2d11");
                _orderdateInfo = new RepoItemInfo(this, "OrderDate", ".//container[@name='_contentPanel']/?/?/container[@name='_leftPanel']//container[@type='BIDimensionDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='OrderDate']", 30000, null, "8ff235d9-3343-4aeb-9dcb-20ecdd98a4f7");
                _windowsscrollbaruidollarwindowsarrowbuttInfo = new RepoItemInfo(this, "WindowsScrollBarUIDollarWindowsArrowButt", ".//container[@name='_contentPanel']/?/?/container[@name='_leftPanel']//container[@type='BIDimensionDataPane']//scrollbar[@name='verticalScrollBar']/button[1]", 30000, null, "979cd9d2-4d65-43bf-afdc-c352b24d53ff");
                _columnspanelInfo = new RepoItemInfo(this, "ColumnsPanel", ".//container[@name='_contentPanel']/container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 11']/container[@name='_worksheetPanel']//container[@name='cols']//container[@name='panel']", 30000, null, "41406ee8-45d1-4252-9e08-a375e2101aeb");
                _quarterorderdateInfo = new RepoItemInfo(this, "QUARTEROrderDate", ".//container[@name='_contentPanel']/container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 11']/container[@name='_worksheetPanel']//container[@name='cols']//text[@caption='QUARTER(OrderDate)']", 30000, null, "030bf4ad-d5b7-4dc7-b664-37ffbaa00f66");
                _rowpanelInfo = new RepoItemInfo(this, "RowPanel", ".//container[@name='_contentPanel']/container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 11']/container[@name='_worksheetPanel']//container[@name='rows']//container[@name='panel']", 30000, null, "2f582b40-79e5-4af2-8121-0651af7b03b7");
                _sumprofitInfo = new RepoItemInfo(this, "SUMProfit", ".//container[@name='_contentPanel']/?/?/container[@name='_leftPanel']//container[@type='BIMeasureDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='SUM(Profit)']", 30000, null, "e1e2120b-3433-478c-85b5-12c4014f3ecb");
                _sumfreightInfo = new RepoItemInfo(this, "SUMFreight", ".//container[@name='_contentPanel']/?/?/container[@name='_leftPanel']//container[@type='BIMeasureDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='SUM(Freight)']", 30000, null, "a3630f18-4e8b-4a7b-95fd-b3b368768f52");
                _filterpanelInfo = new RepoItemInfo(this, "FilterPanel", ".//container[@name='_contentPanel']/container[@name='_splitPane']/container[@name='_sheetsPane']/container[@name='Worksheet 11']/container[@name='_worksheetPanel']//container[@name='filter']//container[@name='panel']", 30000, null, "d69c1a3e-bbbf-4211-8b25-3b0019097b7b");
                _productcategoryInfo = new RepoItemInfo(this, "ProductCategory", ".//container[@name='_contentPanel']/?/?/container[@name='_leftPanel']//container[@type='BIDimensionDataPane']//container[@name='viewport']/list[@type='BIDraggableList']/listitem[@text='Product Category']", 30000, null, "de4f7111-4de5-44e9-985b-bf6cf91bcd51");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("54e17b03-8175-4534-989c-1f86cdde6983")]
            public virtual Ranorex.Container Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("54e17b03-8175-4534-989c-1f86cdde6983")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The SampleDataSourceSymbolMap item.
            /// </summary>
            [RepositoryItem("d6d13803-6613-4db1-bbd0-1476a00b2d11")]
            public virtual Ranorex.ListItem SampleDataSourceSymbolMap
            {
                get
                {
                    return _sampledatasourcesymbolmapInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The SampleDataSourceSymbolMap item info.
            /// </summary>
            [RepositoryItemInfo("d6d13803-6613-4db1-bbd0-1476a00b2d11")]
            public virtual RepoItemInfo SampleDataSourceSymbolMapInfo
            {
                get
                {
                    return _sampledatasourcesymbolmapInfo;
                }
            }

            /// <summary>
            /// The OrderDate item.
            /// </summary>
            [RepositoryItem("8ff235d9-3343-4aeb-9dcb-20ecdd98a4f7")]
            public virtual Ranorex.ListItem OrderDate
            {
                get
                {
                    return _orderdateInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The OrderDate item info.
            /// </summary>
            [RepositoryItemInfo("8ff235d9-3343-4aeb-9dcb-20ecdd98a4f7")]
            public virtual RepoItemInfo OrderDateInfo
            {
                get
                {
                    return _orderdateInfo;
                }
            }

            /// <summary>
            /// The WindowsScrollBarUIDollarWindowsArrowButt item.
            /// </summary>
            [RepositoryItem("979cd9d2-4d65-43bf-afdc-c352b24d53ff")]
            public virtual Ranorex.Button WindowsScrollBarUIDollarWindowsArrowButt
            {
                get
                {
                    return _windowsscrollbaruidollarwindowsarrowbuttInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The WindowsScrollBarUIDollarWindowsArrowButt item info.
            /// </summary>
            [RepositoryItemInfo("979cd9d2-4d65-43bf-afdc-c352b24d53ff")]
            public virtual RepoItemInfo WindowsScrollBarUIDollarWindowsArrowButtInfo
            {
                get
                {
                    return _windowsscrollbaruidollarwindowsarrowbuttInfo;
                }
            }

            /// <summary>
            /// The ColumnsPanel item.
            /// </summary>
            [RepositoryItem("41406ee8-45d1-4252-9e08-a375e2101aeb")]
            public virtual Ranorex.Container ColumnsPanel
            {
                get
                {
                    return _columnspanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The ColumnsPanel item info.
            /// </summary>
            [RepositoryItemInfo("41406ee8-45d1-4252-9e08-a375e2101aeb")]
            public virtual RepoItemInfo ColumnsPanelInfo
            {
                get
                {
                    return _columnspanelInfo;
                }
            }

            /// <summary>
            /// The QUARTEROrderDate item.
            /// </summary>
            [RepositoryItem("030bf4ad-d5b7-4dc7-b664-37ffbaa00f66")]
            public virtual Ranorex.Text QUARTEROrderDate
            {
                get
                {
                    return _quarterorderdateInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The QUARTEROrderDate item info.
            /// </summary>
            [RepositoryItemInfo("030bf4ad-d5b7-4dc7-b664-37ffbaa00f66")]
            public virtual RepoItemInfo QUARTEROrderDateInfo
            {
                get
                {
                    return _quarterorderdateInfo;
                }
            }

            /// <summary>
            /// The RowPanel item.
            /// </summary>
            [RepositoryItem("2f582b40-79e5-4af2-8121-0651af7b03b7")]
            public virtual Ranorex.Container RowPanel
            {
                get
                {
                    return _rowpanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The RowPanel item info.
            /// </summary>
            [RepositoryItemInfo("2f582b40-79e5-4af2-8121-0651af7b03b7")]
            public virtual RepoItemInfo RowPanelInfo
            {
                get
                {
                    return _rowpanelInfo;
                }
            }

            /// <summary>
            /// The SUMProfit item.
            /// </summary>
            [RepositoryItem("e1e2120b-3433-478c-85b5-12c4014f3ecb")]
            public virtual Ranorex.ListItem SUMProfit
            {
                get
                {
                    return _sumprofitInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The SUMProfit item info.
            /// </summary>
            [RepositoryItemInfo("e1e2120b-3433-478c-85b5-12c4014f3ecb")]
            public virtual RepoItemInfo SUMProfitInfo
            {
                get
                {
                    return _sumprofitInfo;
                }
            }

            /// <summary>
            /// The SUMFreight item.
            /// </summary>
            [RepositoryItem("a3630f18-4e8b-4a7b-95fd-b3b368768f52")]
            public virtual Ranorex.ListItem SUMFreight
            {
                get
                {
                    return _sumfreightInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The SUMFreight item info.
            /// </summary>
            [RepositoryItemInfo("a3630f18-4e8b-4a7b-95fd-b3b368768f52")]
            public virtual RepoItemInfo SUMFreightInfo
            {
                get
                {
                    return _sumfreightInfo;
                }
            }

            /// <summary>
            /// The FilterPanel item.
            /// </summary>
            [RepositoryItem("d69c1a3e-bbbf-4211-8b25-3b0019097b7b")]
            public virtual Ranorex.Container FilterPanel
            {
                get
                {
                    return _filterpanelInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The FilterPanel item info.
            /// </summary>
            [RepositoryItemInfo("d69c1a3e-bbbf-4211-8b25-3b0019097b7b")]
            public virtual RepoItemInfo FilterPanelInfo
            {
                get
                {
                    return _filterpanelInfo;
                }
            }

            /// <summary>
            /// The ProductCategory item.
            /// </summary>
            [RepositoryItem("de4f7111-4de5-44e9-985b-bf6cf91bcd51")]
            public virtual Ranorex.ListItem ProductCategory
            {
                get
                {
                    return _productcategoryInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The ProductCategory item info.
            /// </summary>
            [RepositoryItemInfo("de4f7111-4de5-44e9-985b-bf6cf91bcd51")]
            public virtual RepoItemInfo ProductCategoryInfo
            {
                get
                {
                    return _productcategoryInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
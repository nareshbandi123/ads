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

namespace ADSAutomationPhaseII.TC_10549
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TC10549 element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("42421d86-bf32-40ac-94a1-a0adef058856")]
    public partial class TC10549 : RepoGenBaseFolder
    {
        static TC10549 instance = new TC10549();
        TC10549Folders.ApplicationAppFolder _application;
        TC10549Folders.DataStudioAppFolder _datastudio;
        TC10549Folders.ChooseServerAppFolder _chooseserver;
        TC10549Folders.ObjectSearchWindowAppFolder _objectsearchwindow;

        /// <summary>
        /// Gets the singleton class instance representing the TC10549 element repository.
        /// </summary>
        [RepositoryFolder("42421d86-bf32-40ac-94a1-a0adef058856")]
        public static TC10549 Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TC10549() 
            : base("TC10549", "/", null, 0, false, "42421d86-bf32-40ac-94a1-a0adef058856", ".\\RepositoryImages\\TC1054942421d86.rximgres")
        {
            _application = new TC10549Folders.ApplicationAppFolder(this);
            _datastudio = new TC10549Folders.DataStudioAppFolder(this);
            _chooseserver = new TC10549Folders.ChooseServerAppFolder(this);
            _objectsearchwindow = new TC10549Folders.ObjectSearchWindowAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("42421d86-bf32-40ac-94a1-a0adef058856")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The Application folder.
        /// </summary>
        [RepositoryFolder("fe4cc6c8-43f2-4d44-9d58-3cc9da97bbad")]
        public virtual TC10549Folders.ApplicationAppFolder Application
        {
            get { return _application; }
        }

        /// <summary>
        /// The DataStudio folder.
        /// </summary>
        [RepositoryFolder("ca79fddc-29a3-49de-94c8-f54238d1e7ba")]
        public virtual TC10549Folders.DataStudioAppFolder DataStudio
        {
            get { return _datastudio; }
        }

        /// <summary>
        /// The ChooseServer folder.
        /// </summary>
        [RepositoryFolder("a5c5c828-30e2-4264-aa05-7f3821817f1d")]
        public virtual TC10549Folders.ChooseServerAppFolder ChooseServer
        {
            get { return _chooseserver; }
        }

        /// <summary>
        /// The ObjectSearchWindow folder.
        /// </summary>
        [RepositoryFolder("c4bb506f-ec69-4e16-8bda-bedde83a647e")]
        public virtual TC10549Folders.ObjectSearchWindowAppFolder ObjectSearchWindow
        {
            get { return _objectsearchwindow; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class TC10549Folders
    {
        /// <summary>
        /// The ApplicationAppFolder folder.
        /// </summary>
        [RepositoryFolder("fe4cc6c8-43f2-4d44-9d58-3cc9da97bbad")]
        public partial class ApplicationAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _toolsInfo;

            /// <summary>
            /// Creates a new Application  folder.
            /// </summary>
            public ApplicationAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Application", "/form[@title~'^Aqua Data Studio']", parentFolder, 30000, null, true, "fe4cc6c8-43f2-4d44-9d58-3cc9da97bbad", "")
            {
                _toolsInfo = new RepoItemInfo(this, "Tools", ".//menuitem[@text='Tools']", 30000, null, "c6ecc789-9b20-44f7-9502-3182883ccd6b");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("fe4cc6c8-43f2-4d44-9d58-3cc9da97bbad")]
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
            [RepositoryItemInfo("fe4cc6c8-43f2-4d44-9d58-3cc9da97bbad")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Tools item.
            /// </summary>
            [RepositoryItem("c6ecc789-9b20-44f7-9502-3182883ccd6b")]
            public virtual Ranorex.MenuItem Tools
            {
                get
                {
                    return _toolsInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The Tools item info.
            /// </summary>
            [RepositoryItemInfo("c6ecc789-9b20-44f7-9502-3182883ccd6b")]
            public virtual RepoItemInfo ToolsInfo
            {
                get
                {
                    return _toolsInfo;
                }
            }
        }

        /// <summary>
        /// The DataStudioAppFolder folder.
        /// </summary>
        [RepositoryFolder("ca79fddc-29a3-49de-94c8-f54238d1e7ba")]
        public partial class DataStudioAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _objectsearchInfo;

            /// <summary>
            /// Creates a new DataStudio  folder.
            /// </summary>
            public DataStudioAppFolder(RepoGenBaseFolder parentFolder) :
                    base("DataStudio", "/form[@processname='datastudio']", parentFolder, 30000, null, true, "ca79fddc-29a3-49de-94c8-f54238d1e7ba", "")
            {
                _objectsearchInfo = new RepoItemInfo(this, "ObjectSearch", ".//menuitem[@text='Object Search']", 30000, null, "dd526bf8-f7d0-4428-bbad-bccf8e736bd2");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("ca79fddc-29a3-49de-94c8-f54238d1e7ba")]
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
            [RepositoryItemInfo("ca79fddc-29a3-49de-94c8-f54238d1e7ba")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ObjectSearch item.
            /// </summary>
            [RepositoryItem("dd526bf8-f7d0-4428-bbad-bccf8e736bd2")]
            public virtual Ranorex.MenuItem ObjectSearch
            {
                get
                {
                    return _objectsearchInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The ObjectSearch item info.
            /// </summary>
            [RepositoryItemInfo("dd526bf8-f7d0-4428-bbad-bccf8e736bd2")]
            public virtual RepoItemInfo ObjectSearchInfo
            {
                get
                {
                    return _objectsearchInfo;
                }
            }
        }

        /// <summary>
        /// The ChooseServerAppFolder folder.
        /// </summary>
        [RepositoryFolder("a5c5c828-30e2-4264-aa05-7f3821817f1d")]
        public partial class ChooseServerAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _okbuttonInfo;
            RepoItemInfo _serverlistInfo;

            /// <summary>
            /// Creates a new ChooseServer  folder.
            /// </summary>
            public ChooseServerAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ChooseServer", "/form[@title='Choose Server or Database']", parentFolder, 30000, null, true, "a5c5c828-30e2-4264-aa05-7f3821817f1d", "")
            {
                _okbuttonInfo = new RepoItemInfo(this, "OkButton", ".//button[@text='OK']", 30000, null, "f30e4adc-688f-4102-8e28-6030ed331257");
                _serverlistInfo = new RepoItemInfo(this, "ServerList", ".//container[@type='JScrollPane']/container[@name='viewport']/tree[@name='tree']", 30000, null, "b0aaaa8d-2594-42e4-98b3-4fad8a76d087");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("a5c5c828-30e2-4264-aa05-7f3821817f1d")]
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
            [RepositoryItemInfo("a5c5c828-30e2-4264-aa05-7f3821817f1d")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The OkButton item.
            /// </summary>
            [RepositoryItem("f30e4adc-688f-4102-8e28-6030ed331257")]
            public virtual Ranorex.Button OkButton
            {
                get
                {
                    return _okbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The OkButton item info.
            /// </summary>
            [RepositoryItemInfo("f30e4adc-688f-4102-8e28-6030ed331257")]
            public virtual RepoItemInfo OkButtonInfo
            {
                get
                {
                    return _okbuttonInfo;
                }
            }

            /// <summary>
            /// The ServerList item.
            /// </summary>
            [RepositoryItem("b0aaaa8d-2594-42e4-98b3-4fad8a76d087")]
            public virtual Ranorex.Tree ServerList
            {
                get
                {
                    return _serverlistInfo.CreateAdapter<Ranorex.Tree>(true);
                }
            }

            /// <summary>
            /// The ServerList item info.
            /// </summary>
            [RepositoryItemInfo("b0aaaa8d-2594-42e4-98b3-4fad8a76d087")]
            public virtual RepoItemInfo ServerListInfo
            {
                get
                {
                    return _serverlistInfo;
                }
            }
        }

        /// <summary>
        /// The ObjectSearchWindowAppFolder folder.
        /// </summary>
        [RepositoryFolder("c4bb506f-ec69-4e16-8bda-bedde83a647e")]
        public partial class ObjectSearchWindowAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _unselectdatabaseInfo;
            RepoItemInfo _unselectschemaInfo;
            RepoItemInfo _unselectobjectInfo;
            RepoItemInfo _selectdatabaseInfo;
            RepoItemInfo _selectschemaInfo;
            RepoItemInfo _selectobjecttypeInfo;
            RepoItemInfo _columnnameInfo;
            RepoItemInfo _viewsourceInfo;
            RepoItemInfo _searchtextInfo;
            RepoItemInfo _searchbuttonInfo;
            RepoItemInfo _objectsearchresulttableInfo;
            RepoItemInfo _appendbuttonInfo;
            RepoItemInfo _objectnameInfo;
            RepoItemInfo _quickfilterInfo;
            RepoItemInfo _closeInfo;
            RepoItemInfo _unselectviewsInfo;

            /// <summary>
            /// Creates a new ObjectSearchWindow  folder.
            /// </summary>
            public ObjectSearchWindowAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ObjectSearchWindow", "/form[@title~'^Object\\ Search\\ \\[']", parentFolder, 30000, null, true, "c4bb506f-ec69-4e16-8bda-bedde83a647e", "")
            {
                _unselectdatabaseInfo = new RepoItemInfo(this, "UnselectDatabase", ".//container[@name='databaseSelector']/?/?/button[@name='deselectButton']", 30000, null, "7c410d91-1e5b-463f-89a9-dda65c7f099a");
                _unselectschemaInfo = new RepoItemInfo(this, "UnselectSchema", ".//container[@name='schemaSelector']/?/?/button[@name='deselectButton']", 30000, null, "8b95495d-55a1-41d7-904f-f51b42041e60");
                _unselectobjectInfo = new RepoItemInfo(this, "UnselectObject", ".//container[@name='typeSelector']/?/?/button[@name='deselectButton']", 30000, null, "4b5464d2-f82c-4cae-bce5-301c7b4559cf");
                _selectdatabaseInfo = new RepoItemInfo(this, "SelectDatabase", ".//container[@name='databaseSelector']//table[@name='table']/row[@index='0']/cell[1]", 30000, null, "d2f84380-13f0-46e9-98de-1067c6b430ad");
                _selectschemaInfo = new RepoItemInfo(this, "SelectSchema", ".//container[@name='schemaSelector']//table[@name='table']/row[@index='0']/cell[@text='public']", 30000, null, "25f63419-5edd-4da1-aebe-ea269500abbe");
                _selectobjecttypeInfo = new RepoItemInfo(this, "SelectObjectType", ".//container[@name='typeSelector']//table[@name='table']", 30000, null, "5d341ec1-b393-4dfd-927d-6409c1353af0");
                _columnnameInfo = new RepoItemInfo(this, "ColumnName", ".//container[@type='EasyPanel']/container[4]//checkbox[@name='_chkColumnNames']", 30000, null, "8eda8560-2017-4844-8421-92549b4c3ec6");
                _viewsourceInfo = new RepoItemInfo(this, "ViewSource", ".//container[@type='EasyPanel']/container[4]//checkbox[@name='_chkViewSource']", 30000, null, "54f85399-b188-4794-8da8-b49703eee61a");
                _searchtextInfo = new RepoItemInfo(this, "SearchText", ".//container[@type='EasyPanel']/container[4]/?/?/text[@name='_txtSearch']", 30000, null, "781c8c66-3332-4ddf-9522-cfdd01cf35a3");
                _searchbuttonInfo = new RepoItemInfo(this, "SearchButton", ".//container[@type='EasyPanel']/container[4]/?/?/button[@name='_btnSearch']", 30000, null, "699ccc26-f869-4124-9607-c35cca8029cf");
                _objectsearchresulttableInfo = new RepoItemInfo(this, "ObjectSearchResultTable", ".//container[@name='_tableScrollPane']/container[5]/table[@type='BaseTableScrollPaneTable']", 30000, null, "442e5cb3-6954-4f45-9b2e-c68c95fc013b");
                _appendbuttonInfo = new RepoItemInfo(this, "AppendButton", ".//container[@type='EasyPanel']/container[4]/?/?/button[@name='_btnSearchAppend']", 30000, null, "833efa31-f670-4d43-8755-76c04f9fe46a");
                _objectnameInfo = new RepoItemInfo(this, "ObjectName", ".//container[@type='EasyPanel']/container[5]/container[@name='_tableScrollPane']/container[6]/?/?/cell[@text='Object Name/Source']", 30000, null, "5d4ef353-baf7-40fe-9614-014ee869aa1c");
                _quickfilterInfo = new RepoItemInfo(this, "QuickFilter", ".//container[@type='EasyPanel']/container[5]//container[@caption='']/container[@type='DefaultOverlayable']/text[@name='_actualComponent']", 30000, null, "067c09ee-b65b-4833-a15e-63f1c1322c84");
                _closeInfo = new RepoItemInfo(this, "Close", ".//button[@text='Close']", 30000, null, "7faca6cc-9bce-4edd-9222-b36ed533843d");
                _unselectviewsInfo = new RepoItemInfo(this, "UnSelectViews", ".//container[@name='typeSelector']/container[@name='scroll']/container[5]/table[@name='table']/?/?/cell[@columnindex='1' and @rowindex='1']", 30000, null, "c1c99576-5b63-4245-9d2c-b8693a442e13");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("c4bb506f-ec69-4e16-8bda-bedde83a647e")]
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
            [RepositoryItemInfo("c4bb506f-ec69-4e16-8bda-bedde83a647e")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The UnselectDatabase item.
            /// </summary>
            [RepositoryItem("7c410d91-1e5b-463f-89a9-dda65c7f099a")]
            public virtual Ranorex.Button UnselectDatabase
            {
                get
                {
                    return _unselectdatabaseInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectDatabase item info.
            /// </summary>
            [RepositoryItemInfo("7c410d91-1e5b-463f-89a9-dda65c7f099a")]
            public virtual RepoItemInfo UnselectDatabaseInfo
            {
                get
                {
                    return _unselectdatabaseInfo;
                }
            }

            /// <summary>
            /// The UnselectSchema item.
            /// </summary>
            [RepositoryItem("8b95495d-55a1-41d7-904f-f51b42041e60")]
            public virtual Ranorex.Button UnselectSchema
            {
                get
                {
                    return _unselectschemaInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectSchema item info.
            /// </summary>
            [RepositoryItemInfo("8b95495d-55a1-41d7-904f-f51b42041e60")]
            public virtual RepoItemInfo UnselectSchemaInfo
            {
                get
                {
                    return _unselectschemaInfo;
                }
            }

            /// <summary>
            /// The UnselectObject item.
            /// </summary>
            [RepositoryItem("4b5464d2-f82c-4cae-bce5-301c7b4559cf")]
            public virtual Ranorex.Button UnselectObject
            {
                get
                {
                    return _unselectobjectInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The UnselectObject item info.
            /// </summary>
            [RepositoryItemInfo("4b5464d2-f82c-4cae-bce5-301c7b4559cf")]
            public virtual RepoItemInfo UnselectObjectInfo
            {
                get
                {
                    return _unselectobjectInfo;
                }
            }

            /// <summary>
            /// The SelectDatabase item.
            /// </summary>
            [RepositoryItem("d2f84380-13f0-46e9-98de-1067c6b430ad")]
            public virtual Ranorex.Cell SelectDatabase
            {
                get
                {
                    return _selectdatabaseInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The SelectDatabase item info.
            /// </summary>
            [RepositoryItemInfo("d2f84380-13f0-46e9-98de-1067c6b430ad")]
            public virtual RepoItemInfo SelectDatabaseInfo
            {
                get
                {
                    return _selectdatabaseInfo;
                }
            }

            /// <summary>
            /// The SelectSchema item.
            /// </summary>
            [RepositoryItem("25f63419-5edd-4da1-aebe-ea269500abbe")]
            public virtual Ranorex.Cell SelectSchema
            {
                get
                {
                    return _selectschemaInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The SelectSchema item info.
            /// </summary>
            [RepositoryItemInfo("25f63419-5edd-4da1-aebe-ea269500abbe")]
            public virtual RepoItemInfo SelectSchemaInfo
            {
                get
                {
                    return _selectschemaInfo;
                }
            }

            /// <summary>
            /// The SelectObjectType item.
            /// </summary>
            [RepositoryItem("5d341ec1-b393-4dfd-927d-6409c1353af0")]
            public virtual Ranorex.Table SelectObjectType
            {
                get
                {
                    return _selectobjecttypeInfo.CreateAdapter<Ranorex.Table>(true);
                }
            }

            /// <summary>
            /// The SelectObjectType item info.
            /// </summary>
            [RepositoryItemInfo("5d341ec1-b393-4dfd-927d-6409c1353af0")]
            public virtual RepoItemInfo SelectObjectTypeInfo
            {
                get
                {
                    return _selectobjecttypeInfo;
                }
            }

            /// <summary>
            /// The ColumnName item.
            /// </summary>
            [RepositoryItem("8eda8560-2017-4844-8421-92549b4c3ec6")]
            public virtual Ranorex.CheckBox ColumnName
            {
                get
                {
                    return _columnnameInfo.CreateAdapter<Ranorex.CheckBox>(true);
                }
            }

            /// <summary>
            /// The ColumnName item info.
            /// </summary>
            [RepositoryItemInfo("8eda8560-2017-4844-8421-92549b4c3ec6")]
            public virtual RepoItemInfo ColumnNameInfo
            {
                get
                {
                    return _columnnameInfo;
                }
            }

            /// <summary>
            /// The ViewSource item.
            /// </summary>
            [RepositoryItem("54f85399-b188-4794-8da8-b49703eee61a")]
            public virtual Ranorex.CheckBox ViewSource
            {
                get
                {
                    return _viewsourceInfo.CreateAdapter<Ranorex.CheckBox>(true);
                }
            }

            /// <summary>
            /// The ViewSource item info.
            /// </summary>
            [RepositoryItemInfo("54f85399-b188-4794-8da8-b49703eee61a")]
            public virtual RepoItemInfo ViewSourceInfo
            {
                get
                {
                    return _viewsourceInfo;
                }
            }

            /// <summary>
            /// The SearchText item.
            /// </summary>
            [RepositoryItem("781c8c66-3332-4ddf-9522-cfdd01cf35a3")]
            public virtual Ranorex.Text SearchText
            {
                get
                {
                    return _searchtextInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The SearchText item info.
            /// </summary>
            [RepositoryItemInfo("781c8c66-3332-4ddf-9522-cfdd01cf35a3")]
            public virtual RepoItemInfo SearchTextInfo
            {
                get
                {
                    return _searchtextInfo;
                }
            }

            /// <summary>
            /// The SearchButton item.
            /// </summary>
            [RepositoryItem("699ccc26-f869-4124-9607-c35cca8029cf")]
            public virtual Ranorex.Button SearchButton
            {
                get
                {
                    return _searchbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The SearchButton item info.
            /// </summary>
            [RepositoryItemInfo("699ccc26-f869-4124-9607-c35cca8029cf")]
            public virtual RepoItemInfo SearchButtonInfo
            {
                get
                {
                    return _searchbuttonInfo;
                }
            }

            /// <summary>
            /// The ObjectSearchResultTable item.
            /// </summary>
            [RepositoryItem("442e5cb3-6954-4f45-9b2e-c68c95fc013b")]
            public virtual Ranorex.Table ObjectSearchResultTable
            {
                get
                {
                    return _objectsearchresulttableInfo.CreateAdapter<Ranorex.Table>(true);
                }
            }

            /// <summary>
            /// The ObjectSearchResultTable item info.
            /// </summary>
            [RepositoryItemInfo("442e5cb3-6954-4f45-9b2e-c68c95fc013b")]
            public virtual RepoItemInfo ObjectSearchResultTableInfo
            {
                get
                {
                    return _objectsearchresulttableInfo;
                }
            }

            /// <summary>
            /// The AppendButton item.
            /// </summary>
            [RepositoryItem("833efa31-f670-4d43-8755-76c04f9fe46a")]
            public virtual Ranorex.Button AppendButton
            {
                get
                {
                    return _appendbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The AppendButton item info.
            /// </summary>
            [RepositoryItemInfo("833efa31-f670-4d43-8755-76c04f9fe46a")]
            public virtual RepoItemInfo AppendButtonInfo
            {
                get
                {
                    return _appendbuttonInfo;
                }
            }

            /// <summary>
            /// The ObjectName item.
            /// </summary>
            [RepositoryItem("5d4ef353-baf7-40fe-9614-014ee869aa1c")]
            public virtual Ranorex.Cell ObjectName
            {
                get
                {
                    return _objectnameInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The ObjectName item info.
            /// </summary>
            [RepositoryItemInfo("5d4ef353-baf7-40fe-9614-014ee869aa1c")]
            public virtual RepoItemInfo ObjectNameInfo
            {
                get
                {
                    return _objectnameInfo;
                }
            }

            /// <summary>
            /// The QuickFilter item.
            /// </summary>
            [RepositoryItem("067c09ee-b65b-4833-a15e-63f1c1322c84")]
            public virtual Ranorex.Text QuickFilter
            {
                get
                {
                    return _quickfilterInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The QuickFilter item info.
            /// </summary>
            [RepositoryItemInfo("067c09ee-b65b-4833-a15e-63f1c1322c84")]
            public virtual RepoItemInfo QuickFilterInfo
            {
                get
                {
                    return _quickfilterInfo;
                }
            }

            /// <summary>
            /// The Close item.
            /// </summary>
            [RepositoryItem("7faca6cc-9bce-4edd-9222-b36ed533843d")]
            public virtual Ranorex.Button Close
            {
                get
                {
                    return _closeInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Close item info.
            /// </summary>
            [RepositoryItemInfo("7faca6cc-9bce-4edd-9222-b36ed533843d")]
            public virtual RepoItemInfo CloseInfo
            {
                get
                {
                    return _closeInfo;
                }
            }

            /// <summary>
            /// The UnSelectViews item.
            /// </summary>
            [RepositoryItem("c1c99576-5b63-4245-9d2c-b8693a442e13")]
            public virtual Ranorex.Cell UnSelectViews
            {
                get
                {
                    return _unselectviewsInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The UnSelectViews item info.
            /// </summary>
            [RepositoryItemInfo("c1c99576-5b63-4245-9d2c-b8693a442e13")]
            public virtual RepoItemInfo UnSelectViewsInfo
            {
                get
                {
                    return _unselectviewsInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
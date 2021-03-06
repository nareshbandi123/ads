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

namespace ADSAutomationPhaseII.TC_10539
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the TC10539Repo element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    [RepositoryFolder("7417e892-3e29-4ada-941d-63b901f1afd8")]
    public partial class TC10539Repo : RepoGenBaseFolder
    {
        static TC10539Repo instance = new TC10539Repo();
        TC10539RepoFolders.ApplicationAppFolder _application;
        TC10539RepoFolders.DatastudioAppFolder _datastudio;
        TC10539RepoFolders.OptionsAppFolder _options;
        TC10539RepoFolders.NewAbbrevationAppFolder _newabbrevation;
        TC10539RepoFolders.DicardWindowAppFolder _dicardwindow;
        TC10539RepoFolders.OptionWindowAppFolder _optionwindow;

        /// <summary>
        /// Gets the singleton class instance representing the TC10539Repo element repository.
        /// </summary>
        [RepositoryFolder("7417e892-3e29-4ada-941d-63b901f1afd8")]
        public static TC10539Repo Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public TC10539Repo() 
            : base("TC10539Repo", "/", null, 0, false, "7417e892-3e29-4ada-941d-63b901f1afd8", ".\\RepositoryImages\\TC10539Repo7417e892.rximgres")
        {
            _application = new TC10539RepoFolders.ApplicationAppFolder(this);
            _datastudio = new TC10539RepoFolders.DatastudioAppFolder(this);
            _options = new TC10539RepoFolders.OptionsAppFolder(this);
            _newabbrevation = new TC10539RepoFolders.NewAbbrevationAppFolder(this);
            _dicardwindow = new TC10539RepoFolders.DicardWindowAppFolder(this);
            _optionwindow = new TC10539RepoFolders.OptionWindowAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("7417e892-3e29-4ada-941d-63b901f1afd8")]
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
        [RepositoryFolder("8c59d054-d4b4-4f60-9616-32fc7f3174f4")]
        public virtual TC10539RepoFolders.ApplicationAppFolder Application
        {
            get { return _application; }
        }

        /// <summary>
        /// The Datastudio folder.
        /// </summary>
        [RepositoryFolder("5a631166-ca74-4619-bd9d-4ec59f6026cf")]
        public virtual TC10539RepoFolders.DatastudioAppFolder Datastudio
        {
            get { return _datastudio; }
        }

        /// <summary>
        /// The Options folder.
        /// </summary>
        [RepositoryFolder("d5281a95-f84a-4bc4-af19-acb9043dd82f")]
        public virtual TC10539RepoFolders.OptionsAppFolder Options
        {
            get { return _options; }
        }

        /// <summary>
        /// The NewAbbrevation folder.
        /// </summary>
        [RepositoryFolder("afa6c0ea-aa7f-4ce7-b1b5-db553db6bf25")]
        public virtual TC10539RepoFolders.NewAbbrevationAppFolder NewAbbrevation
        {
            get { return _newabbrevation; }
        }

        /// <summary>
        /// The DicardWindow folder.
        /// </summary>
        [RepositoryFolder("da89790f-cdb6-421d-9f7b-7dabd1632a4b")]
        public virtual TC10539RepoFolders.DicardWindowAppFolder DicardWindow
        {
            get { return _dicardwindow; }
        }

        /// <summary>
        /// The OptionWindow folder.
        /// </summary>
        [RepositoryFolder("247ee057-e741-4bbe-bd43-230c17d98b30")]
        public virtual TC10539RepoFolders.OptionWindowAppFolder OptionWindow
        {
            get { return _optionwindow; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "8.2")]
    public partial class TC10539RepoFolders
    {
        /// <summary>
        /// The ApplicationAppFolder folder.
        /// </summary>
        [RepositoryFolder("8c59d054-d4b4-4f60-9616-32fc7f3174f4")]
        public partial class ApplicationAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _filemenuInfo;
            RepoItemInfo _querymenuInfo;

            /// <summary>
            /// Creates a new Application  folder.
            /// </summary>
            public ApplicationAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Application", "/form[@title='Aqua Data Studio']", parentFolder, 30000, null, true, "8c59d054-d4b4-4f60-9616-32fc7f3174f4", "")
            {
                _filemenuInfo = new RepoItemInfo(this, "FileMenu", ".//menuitem[@text='File']", 30000, null, "c1531b99-7e5f-4286-bb2e-c70825ef546f");
                _querymenuInfo = new RepoItemInfo(this, "QueryMenu", ".//menuitem[@text='Query']", 30000, null, "ff2044f9-0e1d-4f41-a909-24b86883de6e");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("8c59d054-d4b4-4f60-9616-32fc7f3174f4")]
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
            [RepositoryItemInfo("8c59d054-d4b4-4f60-9616-32fc7f3174f4")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The FileMenu item.
            /// </summary>
            [RepositoryItem("c1531b99-7e5f-4286-bb2e-c70825ef546f")]
            public virtual Ranorex.MenuItem FileMenu
            {
                get
                {
                    return _filemenuInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The FileMenu item info.
            /// </summary>
            [RepositoryItemInfo("c1531b99-7e5f-4286-bb2e-c70825ef546f")]
            public virtual RepoItemInfo FileMenuInfo
            {
                get
                {
                    return _filemenuInfo;
                }
            }

            /// <summary>
            /// The QueryMenu item.
            /// </summary>
            [RepositoryItem("ff2044f9-0e1d-4f41-a909-24b86883de6e")]
            public virtual Ranorex.MenuItem QueryMenu
            {
                get
                {
                    return _querymenuInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The QueryMenu item info.
            /// </summary>
            [RepositoryItemInfo("ff2044f9-0e1d-4f41-a909-24b86883de6e")]
            public virtual RepoItemInfo QueryMenuInfo
            {
                get
                {
                    return _querymenuInfo;
                }
            }
        }

        /// <summary>
        /// The DatastudioAppFolder folder.
        /// </summary>
        [RepositoryFolder("5a631166-ca74-4619-bd9d-4ec59f6026cf")]
        public partial class DatastudioAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _optionmenuInfo;
            RepoItemInfo _describeInfo;

            /// <summary>
            /// Creates a new Datastudio  folder.
            /// </summary>
            public DatastudioAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Datastudio", "/form[@processname='datastudio']", parentFolder, 30000, null, true, "5a631166-ca74-4619-bd9d-4ec59f6026cf", "")
            {
                _optionmenuInfo = new RepoItemInfo(this, "OptionMenu", ".//menuitem[@text='Options']", 30000, null, "d71109be-c1a6-451e-9676-ef2f32420359");
                _describeInfo = new RepoItemInfo(this, "Describe", ".//menuitem[@text='Describe']", 30000, null, "6957c92e-93e3-48df-a0ba-0f7c54c1af02");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("5a631166-ca74-4619-bd9d-4ec59f6026cf")]
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
            [RepositoryItemInfo("5a631166-ca74-4619-bd9d-4ec59f6026cf")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The OptionMenu item.
            /// </summary>
            [RepositoryItem("d71109be-c1a6-451e-9676-ef2f32420359")]
            public virtual Ranorex.MenuItem OptionMenu
            {
                get
                {
                    return _optionmenuInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The OptionMenu item info.
            /// </summary>
            [RepositoryItemInfo("d71109be-c1a6-451e-9676-ef2f32420359")]
            public virtual RepoItemInfo OptionMenuInfo
            {
                get
                {
                    return _optionmenuInfo;
                }
            }

            /// <summary>
            /// The Describe item.
            /// </summary>
            [RepositoryItem("6957c92e-93e3-48df-a0ba-0f7c54c1af02")]
            public virtual Ranorex.MenuItem Describe
            {
                get
                {
                    return _describeInfo.CreateAdapter<Ranorex.MenuItem>(true);
                }
            }

            /// <summary>
            /// The Describe item info.
            /// </summary>
            [RepositoryItemInfo("6957c92e-93e3-48df-a0ba-0f7c54c1af02")]
            public virtual RepoItemInfo DescribeInfo
            {
                get
                {
                    return _describeInfo;
                }
            }
        }

        /// <summary>
        /// The OptionsAppFolder folder.
        /// </summary>
        [RepositoryFolder("d5281a95-f84a-4bc4-af19-acb9043dd82f")]
        public partial class OptionsAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _sqleditortreeitemInfo;
            RepoItemInfo _autocompletionInfo;
            RepoItemInfo _syntaxcolorInfo;
            RepoItemInfo _abbrevationInfo;
            RepoItemInfo _autocompletecheckboxInfo;
            RepoItemInfo _okbuttonInfo;
            RepoItemInfo _syntaxcolorenabledcheckboxInfo;
            RepoItemInfo _addnewabbrevationiconInfo;
            RepoItemInfo _abbrivationtextboxInfo;
            RepoItemInfo _abbrivationcomboboxInfo;
            RepoItemInfo _removeabbrivationiconInfo;

            /// <summary>
            /// Creates a new Options  folder.
            /// </summary>
            public OptionsAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Options", "/form[@title='Options']", parentFolder, 30000, null, true, "d5281a95-f84a-4bc4-af19-acb9043dd82f", "")
            {
                _sqleditortreeitemInfo = new RepoItemInfo(this, "SQLEditorTreeitem", ".//container[1]/?/?/container[@name='mySplitter']//container[@type='SettingsTreeView$2']/tree[@name='myTree']/treeitem/treeitem[4]", 30000, null, "14d764f1-a2de-4c5c-8171-1d0dc4fb1298");
                _autocompletionInfo = new RepoItemInfo(this, "AutoCompletion", ".//container[1]/?/?/container[@name='mySplitter']//container[@type='SettingsTreeView$2']/tree[@name='myTree']/treeitem/treeitem[4]/treeitem[1]", 30000, null, "abfa04c4-d6b4-416f-b7e2-89794b95fded");
                _syntaxcolorInfo = new RepoItemInfo(this, "SyntaxColor", ".//container[1]/?/?/container[@name='mySplitter']//container[@type='SettingsTreeView$2']/tree[@name='myTree']/treeitem/treeitem[4]/treeitem[2]", 30000, null, "b806d041-e334-4cc3-9e80-3da4f6ec9aa2");
                _abbrevationInfo = new RepoItemInfo(this, "Abbrevation", ".//container[1]/?/?/container[@name='mySplitter']//container[@type='SettingsTreeView$2']/tree[@name='myTree']/treeitem/treeitem[4]/treeitem[3]", 30000, null, "b1cfad33-d77b-4da3-b11a-89040e5c19cd");
                _autocompletecheckboxInfo = new RepoItemInfo(this, "AutoCompleteCheckBox", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']/element/container[2]/container[@type='AQPropertyPane']/container[@type='JideSplitPane']/container[1]/?/?/container[@type='JBScrollPane']/container[1]/table[@name='table']/row[@index='1']/cell[@columnindex='1']", 30000, null, "53193c2c-fa38-4a94-adae-1b6af90a0fec");
                _okbuttonInfo = new RepoItemInfo(this, "OkButton", ".//container[2]/container[@type='JPanel']//button[@text='OK']", 30000, null, "9156661a-dd7f-4986-8427-a4cbfff9ad47");
                _syntaxcolorenabledcheckboxInfo = new RepoItemInfo(this, "SyntaxColorEnabledCheckbox", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']/element/container[3]//container[@name='propertyTable']/container[@type='JBScrollPane']/container[1]/table[@name='table']/row[@index='1']/cell[@columnindex='1']", 30000, null, "c48e2987-cf48-40d5-9b88-67b8c888d558");
                _addnewabbrevationiconInfo = new RepoItemInfo(this, "AddNewAbbrevationIcon", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']/element/container[5]/?/?/container[@type='CSplitPane']/container[1]/container[@name='abbreviationTablePanel']//container[@name='myToolbar']/element[1]", 30000, null, "b333a6b4-fbec-492a-a993-c590d9c9dedb");
                _abbrivationtextboxInfo = new RepoItemInfo(this, "AbbrivationTextbox", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']/element/container[1]/?/?/container[@type='CSplitPane']/container[3]/?/?/container[@accessiblename='Expanded Text']//container[@type='LoadingDecorator$MyLayeredPane']/container[@type='JPanel']/?/?/container[@type='EditorImpl$MyScrollPane']/container[6]/element[@type='EditorComponentImpl']", 30000, null, "67e4f9f1-6a8f-4ddc-851b-8f88877ab0ee");
                _abbrivationcomboboxInfo = new RepoItemInfo(this, "AbbrivationCombobox", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']/element/container[1]/?/?/container[@type='CSplitPane']/container[3]/?/?/combobox[@name='expandOnCombo']", 30000, null, "666e5116-f1e2-4125-b1a2-a77485516715");
                _removeabbrivationiconInfo = new RepoItemInfo(this, "RemoveAbbrivationIcon", ".//container[1]/?/?/container[@name='mySplitter']/container[3]/?/?/container[@name='myContent']//container[@type='CSplitPane']/container[1]/container[@name='abbreviationTablePanel']/?/?/container[@type='CommonActionsPanel']/container/element[2]", 30000, null, "38df895f-1c3a-4390-94ab-667e3656b1b6");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("d5281a95-f84a-4bc4-af19-acb9043dd82f")]
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
            [RepositoryItemInfo("d5281a95-f84a-4bc4-af19-acb9043dd82f")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The SQLEditorTreeitem item.
            /// </summary>
            [RepositoryItem("14d764f1-a2de-4c5c-8171-1d0dc4fb1298")]
            public virtual Ranorex.TreeItem SQLEditorTreeitem
            {
                get
                {
                    return _sqleditortreeitemInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The SQLEditorTreeitem item info.
            /// </summary>
            [RepositoryItemInfo("14d764f1-a2de-4c5c-8171-1d0dc4fb1298")]
            public virtual RepoItemInfo SQLEditorTreeitemInfo
            {
                get
                {
                    return _sqleditortreeitemInfo;
                }
            }

            /// <summary>
            /// The AutoCompletion item.
            /// </summary>
            [RepositoryItem("abfa04c4-d6b4-416f-b7e2-89794b95fded")]
            public virtual Ranorex.TreeItem AutoCompletion
            {
                get
                {
                    return _autocompletionInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The AutoCompletion item info.
            /// </summary>
            [RepositoryItemInfo("abfa04c4-d6b4-416f-b7e2-89794b95fded")]
            public virtual RepoItemInfo AutoCompletionInfo
            {
                get
                {
                    return _autocompletionInfo;
                }
            }

            /// <summary>
            /// The SyntaxColor item.
            /// </summary>
            [RepositoryItem("b806d041-e334-4cc3-9e80-3da4f6ec9aa2")]
            public virtual Ranorex.TreeItem SyntaxColor
            {
                get
                {
                    return _syntaxcolorInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The SyntaxColor item info.
            /// </summary>
            [RepositoryItemInfo("b806d041-e334-4cc3-9e80-3da4f6ec9aa2")]
            public virtual RepoItemInfo SyntaxColorInfo
            {
                get
                {
                    return _syntaxcolorInfo;
                }
            }

            /// <summary>
            /// The Abbrevation item.
            /// </summary>
            [RepositoryItem("b1cfad33-d77b-4da3-b11a-89040e5c19cd")]
            public virtual Ranorex.TreeItem Abbrevation
            {
                get
                {
                    return _abbrevationInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Abbrevation item info.
            /// </summary>
            [RepositoryItemInfo("b1cfad33-d77b-4da3-b11a-89040e5c19cd")]
            public virtual RepoItemInfo AbbrevationInfo
            {
                get
                {
                    return _abbrevationInfo;
                }
            }

            /// <summary>
            /// The AutoCompleteCheckBox item.
            /// </summary>
            [RepositoryItem("53193c2c-fa38-4a94-adae-1b6af90a0fec")]
            public virtual Ranorex.Cell AutoCompleteCheckBox
            {
                get
                {
                    return _autocompletecheckboxInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The AutoCompleteCheckBox item info.
            /// </summary>
            [RepositoryItemInfo("53193c2c-fa38-4a94-adae-1b6af90a0fec")]
            public virtual RepoItemInfo AutoCompleteCheckBoxInfo
            {
                get
                {
                    return _autocompletecheckboxInfo;
                }
            }

            /// <summary>
            /// The OkButton item.
            /// </summary>
            [RepositoryItem("9156661a-dd7f-4986-8427-a4cbfff9ad47")]
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
            [RepositoryItemInfo("9156661a-dd7f-4986-8427-a4cbfff9ad47")]
            public virtual RepoItemInfo OkButtonInfo
            {
                get
                {
                    return _okbuttonInfo;
                }
            }

            /// <summary>
            /// The SyntaxColorEnabledCheckbox item.
            /// </summary>
            [RepositoryItem("c48e2987-cf48-40d5-9b88-67b8c888d558")]
            public virtual Ranorex.Cell SyntaxColorEnabledCheckbox
            {
                get
                {
                    return _syntaxcolorenabledcheckboxInfo.CreateAdapter<Ranorex.Cell>(true);
                }
            }

            /// <summary>
            /// The SyntaxColorEnabledCheckbox item info.
            /// </summary>
            [RepositoryItemInfo("c48e2987-cf48-40d5-9b88-67b8c888d558")]
            public virtual RepoItemInfo SyntaxColorEnabledCheckboxInfo
            {
                get
                {
                    return _syntaxcolorenabledcheckboxInfo;
                }
            }

            /// <summary>
            /// The AddNewAbbrevationIcon item.
            /// </summary>
            [RepositoryItem("b333a6b4-fbec-492a-a993-c590d9c9dedb")]
            public virtual Ranorex.Unknown AddNewAbbrevationIcon
            {
                get
                {
                    return _addnewabbrevationiconInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The AddNewAbbrevationIcon item info.
            /// </summary>
            [RepositoryItemInfo("b333a6b4-fbec-492a-a993-c590d9c9dedb")]
            public virtual RepoItemInfo AddNewAbbrevationIconInfo
            {
                get
                {
                    return _addnewabbrevationiconInfo;
                }
            }

            /// <summary>
            /// The AbbrivationTextbox item.
            /// </summary>
            [RepositoryItem("67e4f9f1-6a8f-4ddc-851b-8f88877ab0ee")]
            public virtual Ranorex.Unknown AbbrivationTextbox
            {
                get
                {
                    return _abbrivationtextboxInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The AbbrivationTextbox item info.
            /// </summary>
            [RepositoryItemInfo("67e4f9f1-6a8f-4ddc-851b-8f88877ab0ee")]
            public virtual RepoItemInfo AbbrivationTextboxInfo
            {
                get
                {
                    return _abbrivationtextboxInfo;
                }
            }

            /// <summary>
            /// The AbbrivationCombobox item.
            /// </summary>
            [RepositoryItem("666e5116-f1e2-4125-b1a2-a77485516715")]
            public virtual Ranorex.ComboBox AbbrivationCombobox
            {
                get
                {
                    return _abbrivationcomboboxInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The AbbrivationCombobox item info.
            /// </summary>
            [RepositoryItemInfo("666e5116-f1e2-4125-b1a2-a77485516715")]
            public virtual RepoItemInfo AbbrivationComboboxInfo
            {
                get
                {
                    return _abbrivationcomboboxInfo;
                }
            }

            /// <summary>
            /// The RemoveAbbrivationIcon item.
            /// </summary>
            [RepositoryItem("38df895f-1c3a-4390-94ab-667e3656b1b6")]
            public virtual Ranorex.Unknown RemoveAbbrivationIcon
            {
                get
                {
                    return _removeabbrivationiconInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The RemoveAbbrivationIcon item info.
            /// </summary>
            [RepositoryItemInfo("38df895f-1c3a-4390-94ab-667e3656b1b6")]
            public virtual RepoItemInfo RemoveAbbrivationIconInfo
            {
                get
                {
                    return _removeabbrivationiconInfo;
                }
            }
        }

        /// <summary>
        /// The NewAbbrevationAppFolder folder.
        /// </summary>
        [RepositoryFolder("afa6c0ea-aa7f-4ce7-b1b5-db553db6bf25")]
        public partial class NewAbbrevationAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _nametextboxInfo;
            RepoItemInfo _okbuttonInfo;

            /// <summary>
            /// Creates a new NewAbbrevation  folder.
            /// </summary>
            public NewAbbrevationAppFolder(RepoGenBaseFolder parentFolder) :
                    base("NewAbbrevation", "/form[@title='New Abbreviation']", parentFolder, 30000, null, true, "afa6c0ea-aa7f-4ce7-b1b5-db553db6bf25", "")
            {
                _nametextboxInfo = new RepoItemInfo(this, "NameTextbox", ".//container[1]/?/?/text[@type='JBTextField']", 30000, null, "35b49ae3-089e-438e-b090-f1477bebd879");
                _okbuttonInfo = new RepoItemInfo(this, "OkButton", ".//container[2]/container[@type='JPanel']//button[@text='OK']", 30000, null, "cf51c208-3d7c-4ab8-9114-da80c64ec9fb");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("afa6c0ea-aa7f-4ce7-b1b5-db553db6bf25")]
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
            [RepositoryItemInfo("afa6c0ea-aa7f-4ce7-b1b5-db553db6bf25")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The NameTextbox item.
            /// </summary>
            [RepositoryItem("35b49ae3-089e-438e-b090-f1477bebd879")]
            public virtual Ranorex.Text NameTextbox
            {
                get
                {
                    return _nametextboxInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The NameTextbox item info.
            /// </summary>
            [RepositoryItemInfo("35b49ae3-089e-438e-b090-f1477bebd879")]
            public virtual RepoItemInfo NameTextboxInfo
            {
                get
                {
                    return _nametextboxInfo;
                }
            }

            /// <summary>
            /// The OkButton item.
            /// </summary>
            [RepositoryItem("cf51c208-3d7c-4ab8-9114-da80c64ec9fb")]
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
            [RepositoryItemInfo("cf51c208-3d7c-4ab8-9114-da80c64ec9fb")]
            public virtual RepoItemInfo OkButtonInfo
            {
                get
                {
                    return _okbuttonInfo;
                }
            }
        }

        /// <summary>
        /// The DicardWindowAppFolder folder.
        /// </summary>
        [RepositoryFolder("da89790f-cdb6-421d-9f7b-7dabd1632a4b")]
        public partial class DicardWindowAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _dicardbuttonInfo;

            /// <summary>
            /// Creates a new DicardWindow  folder.
            /// </summary>
            public DicardWindowAppFolder(RepoGenBaseFolder parentFolder) :
                    base("DicardWindow", "/form[@title='File Modified']", parentFolder, 30000, null, true, "da89790f-cdb6-421d-9f7b-7dabd1632a4b", "")
            {
                _dicardbuttonInfo = new RepoItemInfo(this, "DicardButton", ".//container[@name='OptionPane.buttonArea']/button[@text='Discard']", 30000, null, "326a16c5-9eb6-4472-80db-cc64ace05f21");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("da89790f-cdb6-421d-9f7b-7dabd1632a4b")]
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
            [RepositoryItemInfo("da89790f-cdb6-421d-9f7b-7dabd1632a4b")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The DicardButton item.
            /// </summary>
            [RepositoryItem("326a16c5-9eb6-4472-80db-cc64ace05f21")]
            public virtual Ranorex.Button DicardButton
            {
                get
                {
                    return _dicardbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The DicardButton item info.
            /// </summary>
            [RepositoryItemInfo("326a16c5-9eb6-4472-80db-cc64ace05f21")]
            public virtual RepoItemInfo DicardButtonInfo
            {
                get
                {
                    return _dicardbuttonInfo;
                }
            }
        }

        /// <summary>
        /// The OptionWindowAppFolder folder.
        /// </summary>
        [RepositoryFolder("247ee057-e741-4bbe-bd43-230c17d98b30")]
        public partial class OptionWindowAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _yesbuttonInfo;

            /// <summary>
            /// Creates a new OptionWindow  folder.
            /// </summary>
            public OptionWindowAppFolder(RepoGenBaseFolder parentFolder) :
                    base("OptionWindow", "/form[@processname='datastudio' and @class='SunAwtDialog' and @accessiblename='Options' and @type='DialogWrapperPeerImpl$MyDialog' and @fulltype='com.intellij.openapi.ui.impl.DialogWrapperPeerImpl$MyDialog' and @instance='1']", parentFolder, 30000, null, true, "247ee057-e741-4bbe-bd43-230c17d98b30", "")
            {
                _yesbuttonInfo = new RepoItemInfo(this, "YesButton", ".//container[2]/container[@type='JPanel']/container[@type='JPanel']/container[@type='JPanel']/button[@text='Yes']", 30000, null, "63877bf6-8d1a-4d2a-b5af-ea3331b67ca2");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("247ee057-e741-4bbe-bd43-230c17d98b30")]
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
            [RepositoryItemInfo("247ee057-e741-4bbe-bd43-230c17d98b30")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The YesButton item.
            /// </summary>
            [RepositoryItem("63877bf6-8d1a-4d2a-b5af-ea3331b67ca2")]
            public virtual Ranorex.Button YesButton
            {
                get
                {
                    return _yesbuttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The YesButton item info.
            /// </summary>
            [RepositoryItemInfo("63877bf6-8d1a-4d2a-b5af-ea3331b67ca2")]
            public virtual RepoItemInfo YesButtonInfo
            {
                get
                {
                    return _yesbuttonInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
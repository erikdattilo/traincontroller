//-----------------------------------------------------------------------------
// wx.NET/Samples - ListCtrl.cs
//
// A wx.NET version of the wxWidgets "listctrl" sample.
//
// Written by Alexander Olk (xenomorph2@onlinehome.de)
// (C) 2004 Alexander Olk
// Virtual lists and several bugfixes 2007 Harald Meyer auf'm Hofe
// Licensed under the wxWidgets license, see LICENSE.txt for details.
//
// $Id: ListCtrl.cs,v 1.9 2008/12/27 13:02:39 harald_meyer Exp $
//-----------------------------------------------------------------------------

using System;
using System.Drawing;

/** This exemplifies the list control.
 * New since 0.7.2: Virtual lists (great for large amounts of data).
 * \image html listctrlsmall.png "The list control in report mode."
 */
namespace wx.SampleListCtrl
{
    public enum Cmd
    {
        LIST_ABOUT,
        LIST_QUIT,

        LIST_LIST_VIEW,
        LIST_ICON_VIEW,
        LIST_ICON_TEXT_VIEW,
        LIST_SMALL_ICON_VIEW,
        LIST_SMALL_ICON_TEXT_VIEW,
        LIST_REPORT_VIEW,
        LIST_VIRTUAL_VIEW,

        LIST_DESELECT_ALL,
        LIST_SELECT_ALL,
        LIST_DELETE_ALL,
        LIST_DELETE,
        LIST_ADD,
        LIST_EDIT,
        LIST_SORT,
        LIST_SET_FG_COL,
        LIST_SET_BG_COL,
        LIST_TOGGLE_MULTI_SEL,
        LIST_TOGGLE_FIRST,
        LIST_SHOW_COL_INFO,
        LIST_SHOW_SEL_INFO,
        LIST_FOCUS_LAST,
        LIST_FREEZE,
        LIST_THAW,
        LIST_TOGGLE_LINES,

        LIST_CTRL = 1000
    };

    //---------------------------------------------------------------------

    public class MyFrame : Frame
    {
        public ImageList m_imageListNormal;
        public ImageList m_imageListSmall;

        public TextCtrl m_logWindow;
        public MyListCtrl m_listCtrl;
        public Panel m_panel;

        public static int NUM_ITEMS = 30;

        public static int NUM_ICONS = 9;

        //---------------------------------------------------------------------

        public MyFrame(string title, Point pos, Size size)
            : base(title, pos, size)
        {
            // Set the window icon and status bar

            Icon = new wx.Icon("../Samples/ListCtrl/mondrian.png");

            // Make an image list containing large icons
            m_imageListNormal = new ImageList(32, 32, true);
            m_imageListSmall = new ImageList(16, 16, true);

            Image image = new Image("../Samples/ListCtrl/bitmaps/toolbrai.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/toolchar.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/tooldata.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/toolnote.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/tooltodo.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/toolchec.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/toolgame.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/tooltime.xpm");
            m_imageListNormal.Add(new Bitmap(image));
            image = new Image("../Samples/ListCtrl/bitmaps/toolword.xpm");
            m_imageListNormal.Add(new Bitmap(image));

            image = new Image("../Samples/ListCtrl/bitmaps/small1.xpm");
            m_imageListSmall.Add(new Bitmap(image));

            // Make a menubar
            Menu menuFile = new Menu();
            menuFile.Append((int)Cmd.LIST_ABOUT, _("&About"));
            menuFile.AppendSeparator();
            menuFile.Append((int)Cmd.LIST_QUIT, _("E&xit\tAlt-X"));

            Menu menuView = new Menu();
            menuView.Append((int)Cmd.LIST_LIST_VIEW, _("&List view\tF1"));
            menuView.Append((int)Cmd.LIST_REPORT_VIEW, _("&Report view\tF2"));
            menuView.Append((int)Cmd.LIST_ICON_VIEW, _("&Icon view\tF3"));
            menuView.Append((int)Cmd.LIST_ICON_TEXT_VIEW, _("Icon view with &text\tF4"));
            menuView.Append((int)Cmd.LIST_SMALL_ICON_VIEW, _("&Small icon view\tF5"));
            menuView.Append((int)Cmd.LIST_SMALL_ICON_TEXT_VIEW, _("Small icon &view with text\tF6"));
            menuView.Append((int)Cmd.LIST_VIRTUAL_VIEW, _("Virtual view\tF7"));

            Menu menuList = new Menu();
            menuList.Append((int)Cmd.LIST_FOCUS_LAST, _("&Make last item current\tCtrl-L"));
            menuList.Append((int)Cmd.LIST_TOGGLE_FIRST, _("To&ggle first item\tCtrl-G"));
            menuList.Append((int)Cmd.LIST_DESELECT_ALL, _("&Deselect All\tCtrl-D"));
            menuList.Append((int)Cmd.LIST_SELECT_ALL, _("S&elect All\tCtrl-A"));
            menuList.AppendSeparator();
            menuList.Append((int)Cmd.LIST_SHOW_COL_INFO, _("Show &column info\tCtrl-C"));
            menuList.Append((int)Cmd.LIST_SHOW_SEL_INFO, _("Show &selected items\tCtrl-S"));
            menuList.AppendSeparator();
            menuList.Append((int)Cmd.LIST_SORT, _("&Sort\tCtrl-S"));
            menuList.AppendSeparator();
            menuList.Append((int)Cmd.LIST_ADD, _("&Append an item\tCtrl-P"));
            menuList.Append((int)Cmd.LIST_EDIT, _("&Edit the item\tCtrl-E"));
            menuList.Append((int)Cmd.LIST_DELETE, _("&Delete first item\tCtrl-X"));
            menuList.Append((int)Cmd.LIST_DELETE_ALL, _("Delete &all items"));
            menuList.AppendSeparator();
            menuList.Append((int)Cmd.LIST_FREEZE, _("Free&ze\tCtrl-Z"));
            menuList.Append((int)Cmd.LIST_THAW, _("Tha&w\tCtrl-W"));
            menuList.AppendSeparator();
            menuList.AppendCheckItem((int)Cmd.LIST_TOGGLE_LINES, _("Toggle &lines\tCtrl-I"));
            menuList.AppendCheckItem((int)Cmd.LIST_TOGGLE_MULTI_SEL, _("&Multiple selection\tCtrl-M"), _("Toggle multiple selection"));

            Menu menuCol = new Menu();
            menuCol.Append((int)Cmd.LIST_SET_FG_COL, _("&Foreground colour..."));
            menuCol.Append((int)Cmd.LIST_SET_BG_COL, _("&Background colour..."));

            MenuBar menubar = new MenuBar();
            menubar.Append(menuFile, _("&File"));
            menubar.Append(menuView, _("&View"));
            menubar.Append(menuList, _("&List"));
            menubar.Append(menuCol, _("&Colour"));

            MenuBar = menubar;

            m_panel = new Panel(this, wxID_ANY);
            m_logWindow = new TextCtrl(m_panel, wxID_ANY, "",
                    wxDefaultPosition, wxDefaultSize,
                    wx.WindowStyles.TE_MULTILINE|wx.WindowStyles.BORDER_SUNKEN);

            Log.SetActiveTarget(m_logWindow);

            RecreateList(wx.WindowStyles.LC_REPORT | wx.WindowStyles.LC_SINGLE_SEL);

            CreateStatusBar(3);

            EVT_SIZE(new EventListener(OnSize));

            EVT_MENU((int)Cmd.LIST_QUIT, new EventListener(OnQuit));
            EVT_MENU((int)Cmd.LIST_ABOUT, new EventListener(OnAbout));
            EVT_MENU((int)Cmd.LIST_LIST_VIEW, new EventListener(OnListView));
            EVT_MENU((int)Cmd.LIST_REPORT_VIEW, new EventListener(OnReportView));
            EVT_MENU((int)Cmd.LIST_ICON_VIEW, new EventListener(OnIconView));
            EVT_MENU((int)Cmd.LIST_ICON_TEXT_VIEW, new EventListener(OnIconTextView));
            EVT_MENU((int)Cmd.LIST_SMALL_ICON_VIEW, new EventListener(OnSmallIconView));
            EVT_MENU((int)Cmd.LIST_SMALL_ICON_TEXT_VIEW, new EventListener(OnSmallIconTextView));
            EVT_MENU((int)Cmd.LIST_VIRTUAL_VIEW, new EventListener(OnVirtualView));

            EVT_MENU((int)Cmd.LIST_FOCUS_LAST, new EventListener(OnFocusLast));
            EVT_MENU((int)Cmd.LIST_TOGGLE_FIRST, new EventListener(OnToggleFirstSel));
            EVT_MENU((int)Cmd.LIST_DESELECT_ALL, new EventListener(OnDeselectAll));
            EVT_MENU((int)Cmd.LIST_SELECT_ALL, new EventListener(OnSelectAll));
            EVT_MENU((int)Cmd.LIST_DELETE, new EventListener(OnDelete));
            EVT_MENU((int)Cmd.LIST_ADD, new EventListener(OnAdd));
            EVT_MENU((int)Cmd.LIST_EDIT, new EventListener(OnEdit));
            EVT_MENU((int)Cmd.LIST_DELETE_ALL, new EventListener(OnDeleteAll));
            EVT_MENU((int)Cmd.LIST_SORT, new EventListener(OnSort));
            EVT_MENU((int)Cmd.LIST_SET_FG_COL, new EventListener(OnSetFgColour));
            EVT_MENU((int)Cmd.LIST_SET_BG_COL, new EventListener(OnSetBgColour));
            EVT_MENU((int)Cmd.LIST_TOGGLE_MULTI_SEL, new EventListener(OnToggleMultiSel));
            EVT_MENU((int)Cmd.LIST_SHOW_COL_INFO, new EventListener(OnShowColInfo));
            EVT_MENU((int)Cmd.LIST_SHOW_SEL_INFO, new EventListener(OnShowSelInfo));
            EVT_MENU((int)Cmd.LIST_FREEZE, new EventListener(OnFreeze));
            EVT_MENU((int)Cmd.LIST_THAW, new EventListener(OnThaw));
            EVT_MENU((int)Cmd.LIST_TOGGLE_LINES, new EventListener(OnToggleLines));

            EVT_UPDATE_UI((int)Cmd.LIST_SHOW_COL_INFO, new EventListener(OnUpdateShowColInfo));
            EVT_UPDATE_UI((int)Cmd.LIST_TOGGLE_MULTI_SEL, new EventListener(OnUpdateToggleMultiSel));

            Closing += new EventListener(OnClosing);
        }

        //---------------------------------------------------------------------	

        public void OnClosing(object sender, Event e)
        {
            Log.IsEnabled=false;
            e.Skip();
        }

        //---------------------------------------------------------------------	

        public void OnAbout(object sender, Event e)
        {
            MessageDialog.MessageBox("List test sample\nJulian Smart (c) 1997\nPorted to wx.NET by Alexander Olk\nVirtual lists by Harald Meyer auf'm Hofe", "About",
                wx.WindowStyles.DIALOG_OK | wx.WindowStyles.ICON_INFORMATION);
        }

        //---------------------------------------------------------------------	

        public void OnQuit(object sender, Event e)
        {
            Close();
        }

        //---------------------------------------------------------------------	

        public void OnSize(object sender, Event e)
        {
            DoSize();

            e.Skip();
        }

        //---------------------------------------------------------------------	

        public void DoSize()
        {
            if (m_logWindow == null) return;

            Size size = ClientSize;
            int y = (2 * size.Height) / 3;
            m_listCtrl.SetSize(0, 0, size.Width, y);
            m_logWindow.SetSize(0, y + 1, size.Width, size.Height - y);
        }

        //---------------------------------------------------------------------	

        public void OnFreeze(object sender, Event e)
        {
            Log.LogMessage(_("Freezing the control"));
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));

            m_listCtrl.Freeze();
        }

        //---------------------------------------------------------------------	

        public void OnThaw(object sender, Event e)
        {
            Log.LogMessage(_("Thawing the control"));
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));

            m_listCtrl.Thaw();
        }

        //---------------------------------------------------------------------	

        public void OnToggleLines(object sender, Event e)
        {
            CommandEvent ce = e as CommandEvent;

            m_listCtrl.SetSingleStyle(wx.WindowStyles.LC_HRULES | wx.WindowStyles.LC_VRULES, ce.IsChecked);
        }

        //---------------------------------------------------------------------	

        public void OnFocusLast(object sender, Event e)
        {
            long index = m_listCtrl.ItemCount - 1;
            if (index == -1)
            {
                return;
            }

            m_listCtrl.SetItemState((int)index, ListItemState.FOCUSED, ListItemState.FOCUSED);
            m_listCtrl.EnsureVisible((int)index);
        }

        //---------------------------------------------------------------------	

        public void OnToggleFirstSel(object sender, Event e)
        {
            m_listCtrl.SetItemState(0, (~m_listCtrl.GetItemState(0, ListItemState.SELECTED)) & ListItemState.SELECTED, ListItemState.SELECTED);
        }

        //---------------------------------------------------------------------	

        public void OnDeselectAll(object sender, Event e)
        {
            if (!CheckNonVirtual())
                return;

            int n = m_listCtrl.ItemCount;
            for (int i = 0; i < n; i++)
                m_listCtrl.SetItemState(i, 0, ListItemState.SELECTED);
        }

        //---------------------------------------------------------------------	

        public void OnSelectAll(object sender, Event e)
        {
            if (!CheckNonVirtual())
                return;

            int n = m_listCtrl.ItemCount;
            for (int i = 0; i < n; i++)
                m_listCtrl.SetItemState(i, ListItemState.SELECTED, ListItemState.SELECTED);

            if (m_listCtrl.HasFlag(WindowStyles.LC_SINGLE_SEL))
            {
                Log.LogWarning("Dialog is in single selection mode. I will select one item after another. Toggle selection mode.");
            }
        }

        //---------------------------------------------------------------------	

        public bool CheckNonVirtual()
        {
            if (!m_listCtrl.HasFlag(wx.WindowStyles.LC_VIRTUAL))
                return true;

            Log.LogWarning("Can't do this in virtual view, sorry.");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));

            return false;
        }

        //---------------------------------------------------------------------	

        public void RecreateList(wx.WindowStyles flags)
        {
            RecreateList(flags, true);
        }

        public void RecreateList(wx.WindowStyles flags, bool withText)
        {
            /* HMaH: This here replaces statement "delete m_listCtrl" in the original.
             * You have to call this in C# because deletion will be deferred by garbage
             * collection and the old control will still be active after recreation.
             * You should not dispose the old control because there might be some open
             * events generated by this control.
             */
            if (m_listCtrl != null)
                m_listCtrl.Destroy();

            m_listCtrl = new MyListCtrl(m_panel, (int)Cmd.LIST_CTRL,
                    wxDefaultPosition, wxDefaultSize,
                    flags |
                    wx.WindowStyles.BORDER_SUNKEN |  wx.WindowStyles.LC_EDIT_LABELS );

            switch (flags & wx.WindowStyles.LC_MASK_TYPE)
            {
                case wx.WindowStyles.LC_LIST:
                    InitWithListItems();
                    break;

                case wx.WindowStyles.LC_ICON:
                    InitWithIconItems(withText);
                    break;

                case wx.WindowStyles.LC_SMALL_ICON:
                    InitWithIconItems(withText, true);
                    break;

                case wx.WindowStyles.LC_REPORT:
                    if ((flags & wx.WindowStyles.LC_VIRTUAL) > 0)
                        InitWithVirtualItems();
                    else
                        InitWithReportItems();
                    break;

                default:
                    Console.WriteLine("unknown listctrl mode");
                    break;
            }

            DoSize();

            m_logWindow.Clear();
        }

        //---------------------------------------------------------------------	

        public void OnListView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_LIST);
        }

        //---------------------------------------------------------------------	

        public void InitWithListItems()
        {
            for (int i = 0; i < NUM_ITEMS; i++)
            {
                m_listCtrl.InsertItem(i, "Item " + i);
            }
        }

        //---------------------------------------------------------------------	

        public void OnReportView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_REPORT);
        }

        //---------------------------------------------------------------------	

        public void InitWithReportItems()
        {
            m_listCtrl.SetImageList(m_imageListSmall, wxImageList.wxIMAGE_LIST_SMALL);

            ListItem itemCol = new ListItem();
            itemCol.Text = "Column 1";
            itemCol.Image = -1;
            m_listCtrl.InsertColumn(0, itemCol);

            itemCol.Text = "Column 2";
            itemCol.Align = wx.ListColumnFormat.CENTRE;
            m_listCtrl.InsertColumn(1, itemCol);

            itemCol.Text = "Column 3";
            itemCol.Align = wx.ListColumnFormat.RIGHT;
            m_listCtrl.InsertColumn(2, itemCol);

            m_listCtrl.Hide();

            for (int i = 0; i < NUM_ITEMS; i++)
            {
                m_listCtrl.InsertItemInReportView(i);
            }

            m_logWindow.WriteText(NUM_ITEMS + " items inserted");
            m_listCtrl.Show();

            ListItem item = new ListItem();
            item.Id = 0;
            item.TextColour = Colour.wxRED;
            m_listCtrl.SetItem(item);

            item.Id = 2;
            item.TextColour = Colour.wxGREEN;
            m_listCtrl.SetItem(item);
            item.Id = 4;
            item.TextColour = Colour.wxLIGHT_GREY;
            item.Font = Font.wxITALIC_FONT;
            item.BackgroundColour = Colour.wxRED;
            m_listCtrl.SetItem(item);

            m_listCtrl.TextColour = Colour.wxBLUE;
            m_listCtrl.BackgroundColour = Colour.wxLIGHT_GREY;

            m_listCtrl.SetColumnWidth(0, wx.ListCtrl.SymbolicColumnWidth.AUTOSIZE);
            m_listCtrl.SetColumnWidth(1, wx.ListCtrl.SymbolicColumnWidth.AUTOSIZE);
            m_listCtrl.SetColumnWidth(2, wx.ListCtrl.SymbolicColumnWidth.AUTOSIZE);
        }

        //---------------------------------------------------------------------	

        public void InitWithIconItems(bool withText)
        {
            InitWithIconItems(withText, false);
        }

        public void InitWithIconItems(bool withText, bool sameIcon)
        {
            m_listCtrl.SetImageList(m_imageListNormal, wxImageList.wxIMAGE_LIST_NORMAL);
            m_listCtrl.SetImageList(m_imageListSmall, wxImageList.wxIMAGE_LIST_SMALL);

            for (int i = 0; i < NUM_ICONS; i++)
            {
                int image = sameIcon ? 0 : i;

                if (withText)
                {
                    m_listCtrl.InsertItem(i, "Label " + i, image);
                }
                else
                {
                    m_listCtrl.InsertItem(i, image);
                }
            }
        }

        //---------------------------------------------------------------------	

        public void OnIconView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_ICON, false);
        }

        //---------------------------------------------------------------------	

        public void OnIconTextView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_ICON);
        }

        //---------------------------------------------------------------------	

        public void OnSmallIconView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_SMALL_ICON, false);
        }

        //---------------------------------------------------------------------	

        public void OnSmallIconTextView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_SMALL_ICON);
        }

        //---------------------------------------------------------------------	

        public void OnVirtualView(object sender, Event e)
        {
            RecreateList(wx.WindowStyles.LC_REPORT | wx.WindowStyles.LC_VIRTUAL);
        }

        //---------------------------------------------------------------------	

        public void InitWithVirtualItems()
        {
            m_listCtrl.SetImageList(m_imageListSmall, wxImageList.wxIMAGE_LIST_SMALL);

            m_listCtrl.InsertColumn(0, _("First Column"));
            m_listCtrl.InsertColumn(1, _("Second Column"));
            m_listCtrl.InsertColumn(2, _("Third Column"));
            m_listCtrl.SetColumnWidth(0, 150);
            m_listCtrl.SetColumnWidth(1, 150);
            m_listCtrl.SetColumnWidth(2, 150);

            m_listCtrl.ItemCount = 1000000;
        }

        //---------------------------------------------------------------------	

        public int MyCompareFunction(ClientData itemData1, ClientData itemData2, int sortData)
        {
            // inverse the order
            int item1 = (int)((SystemObjectClientData)itemData1).Data;
            int item2 = (int)((SystemObjectClientData)itemData2).Data;

            int result = 0;
            string itemText1 = this.m_listCtrl.GetItemText(item1);
            string itemText2 = this.m_listCtrl.GetItemText(item2);
            if (result == 0)
                result = itemText1.CompareTo(itemText2);
            this.m_logWindow.WriteText(string.Format("Compare {0}:<{4}> and {1}:<{5}> returns {2} on sort data {3}.\n", item1, item2, result, sortData, itemText1, itemText2));
            return -result;
        }

        //---------------------------------------------------------------------	

        public void OnSort(object sender, Event e)
        {
            m_listCtrl.SortItems(new ListCtrl.wxListCtrlCompare(MyCompareFunction), 0);

            m_logWindow.WriteText("Sorting " + m_listCtrl.ItemCount + " items");
        }

        //---------------------------------------------------------------------	

        public void OnShowSelInfo(object sender, Event e)
        {
            int selCount = m_listCtrl.SelectedItemCount;
            Log.LogMessage(selCount + " items selected:");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));

            int shownCount = 0;

            int item = m_listCtrl.GetNextItem(-1, ListCtrl.NEXT.ALL,
                        ListItemState.SELECTED);
            while (item != -1)
            {
                Log.LogMessage("\t" + item + "d (" + m_listCtrl.GetItemText(item) + ")");

                if (++shownCount > 10)
                {
                    Log.LogMessage(_("\t... more selected items snipped..."));
                    break;
                }

                item = m_listCtrl.GetNextItem(item, ListCtrl.NEXT.ALL,
                    ListItemState.SELECTED);
            }
        }

        //---------------------------------------------------------------------	

        public void OnShowColInfo(object sender, Event e)
        {
            int count = m_listCtrl.ColumnCount;
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
            Log.LogMessage(count + " columns:");
            for (int c = 0; c < count; c++)
            {
                Log.LogMessage("\tcolumn " + c + " has width " + m_listCtrl.GetColumnWidth(c));
            }
        }

        //---------------------------------------------------------------------	

        public void OnUpdateShowColInfo(object sender, Event e)
        {
            UpdateUIEvent ue = e as UpdateUIEvent;

            ue.Enabled = (m_listCtrl.StyleFlags & wx.WindowStyles.LC_REPORT) != 0;
        }

        //---------------------------------------------------------------------	

        public void OnToggleMultiSel(object sender, Event e)
        {
            WindowStyles flags = m_listCtrl.StyleFlags;
            if ((flags & wx.WindowStyles.LC_SINGLE_SEL) > 0)
                flags &= ~wx.WindowStyles.LC_SINGLE_SEL;
            else
                flags |= wx.WindowStyles.LC_SINGLE_SEL;

            m_logWindow.WriteText("Current selection mode: " +
                (((flags & wx.WindowStyles.LC_SINGLE_SEL) > 0) ? "sing" : "multip") + "le\n");

            RecreateList(flags);
        }

        //---------------------------------------------------------------------	

        public void OnUpdateToggleMultiSel(object sender, Event e)
        {
            UpdateUIEvent ue = e as UpdateUIEvent;

            ue.Check = (m_listCtrl.StyleFlags & wx.WindowStyles.LC_SINGLE_SEL) == 0;
        }

        //---------------------------------------------------------------------	

        public void OnSetFgColour(object sender, Event e)
        {
            m_listCtrl.ForegroundColour = ColourDialog.GetColourFromUser(this);
            m_listCtrl.Refresh();
        }

        //---------------------------------------------------------------------	

        public void OnSetBgColour(object sender, Event e)
        {
            m_listCtrl.BackgroundColour = ColourDialog.GetColourFromUser(this);
            m_listCtrl.Refresh();
        }

        //---------------------------------------------------------------------	

        public void OnAdd(object sender, Event e)
        {
            m_listCtrl.InsertItem(m_listCtrl.ItemCount, _("Appended item"));
        }

        //---------------------------------------------------------------------	

        public void OnEdit(object sender, Event e)
        {
            int itemCur = m_listCtrl.GetNextItem(-1, ListCtrl.NEXT.ALL,
                        ListItemState.FOCUSED);

            if (itemCur != -1)
            {
                m_listCtrl.EditLabel(itemCur);
            }
            else
            {
                m_logWindow.WriteText(_("No item to edit"));
            }
        }

        //---------------------------------------------------------------------	

        public void OnDelete(object sender, Event e)
        {
            if (m_listCtrl.ItemCount > 0)
            {
                m_listCtrl.DeleteItem(0);
            }
            else
            {
                m_logWindow.WriteText(_("Nothing to delete"));
            }
        }

        //---------------------------------------------------------------------	

        public void OnDeleteAll(object sender, Event e)
        {

            m_listCtrl.DeleteAllItems();

            m_logWindow.WriteText("Deleted " + m_listCtrl.ItemCount + " items\n");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }
    }

    //---------------------------------------------------------------------	

    public class MyListCtrl : ListCtrl
    {
        //---------------------------------------------------------------------

        public MyListCtrl(Window parent, int id, Point pos, Size size, WindowStyles style)
            : base(parent, id, pos, size, style)
        {
            EVT_LIST_BEGIN_DRAG((int)Cmd.LIST_CTRL, new EventListener(OnBeginDrag));
            EVT_LIST_BEGIN_RDRAG((int)Cmd.LIST_CTRL, new EventListener(OnBeginRDrag));
            EVT_LIST_BEGIN_LABEL_EDIT((int)Cmd.LIST_CTRL, new EventListener(OnBeginLabelEdit));
            EVT_LIST_END_LABEL_EDIT((int)Cmd.LIST_CTRL, new EventListener(OnEndLabelEdit));
            EVT_LIST_DELETE_ITEM((int)Cmd.LIST_CTRL, new EventListener(OnDeleteItem));
            EVT_LIST_DELETE_ALL_ITEMS((int)Cmd.LIST_CTRL, new EventListener(OnDeleteAllItems));
            EVT_LIST_ITEM_SELECTED((int)Cmd.LIST_CTRL, new EventListener(OnSelected));
            EVT_LIST_ITEM_DESELECTED((int)Cmd.LIST_CTRL, new EventListener(OnDeselected));
            EVT_LIST_KEY_DOWN((int)Cmd.LIST_CTRL, new EventListener(OnListKeyDown));
            EVT_LIST_ITEM_ACTIVATED((int)Cmd.LIST_CTRL, new EventListener(OnActivated));
            EVT_LIST_ITEM_FOCUSED((int)Cmd.LIST_CTRL, new EventListener(OnFocused));

            EVT_LIST_COL_CLICK((int)Cmd.LIST_CTRL, new EventListener(OnColClick));
            EVT_LIST_COL_RIGHT_CLICK((int)Cmd.LIST_CTRL, new EventListener(OnColRightClick));
            EVT_LIST_COL_BEGIN_DRAG((int)Cmd.LIST_CTRL, new EventListener(OnColBeginDrag));
            EVT_LIST_COL_DRAGGING((int)Cmd.LIST_CTRL, new EventListener(OnColDragging));
            EVT_LIST_COL_END_DRAG((int)Cmd.LIST_CTRL, new EventListener(OnColEndDrag));

            EVT_LIST_CACHE_HINT((int)Cmd.LIST_CTRL, new EventListener(OnCacheHint));

            EVT_CHAR(new EventListener(OnChar));
        }

        //---------------------------------------------------------------------	

        public void OnCacheHint(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            Log.LogMessage("OnCacheHint: cache items " + le.CacheFrom + ".." + le.CacheTo);
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void SetColumnImage(int col, int image)
        {
            ListItem item = new ListItem();
            item.Mask = ListItemMask.IMAGE;
            item.Image = image;
            SetColumn(col, item);
        }

        //---------------------------------------------------------------------	

        public void OnColClick(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            int col = le.Column;
            SetColumnImage(col, 0);

            Log.LogMessage("OnColumnClick at " + col + ".");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnColRightClick(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            int col = le.Column;
            if (col != -1)
            {
                SetColumnImage(col, -1);
            }

            Menu menu = new Menu("Test");
            menu.Append((int)Cmd.LIST_ABOUT, _("&About"));
            PopupMenu(menu, le.Point);

            Log.LogMessage("OnColumnRightClick at " + le.Column + ".");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void LogColEvent(object sender, Event e, string name)
        {
            ListEvent le = e as ListEvent;

            int col = le.Column;

            string msg = name + ": column ";
            msg += col + "(width = ";
            msg += le.Item.Width + " or ";
            msg += GetColumnWidth(col) + ".";

            Log.LogMessage(msg);
        }

        //---------------------------------------------------------------------	

        public void OnColBeginDrag(object sender, Event e)
        {
            LogColEvent(sender, e, "OnColBeginDrag");

            ListEvent le = e as ListEvent;

            if (le.Column == 0)
            {
                Log.LogMessage("Resizing this column shouldn't work.");

                le.Veto();
            }
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnColDragging(object sender, Event e)
        {
            LogColEvent(sender, e, "OnColDragging");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnColEndDrag(object sender, Event e)
        {
            LogColEvent(sender, e, "OnColEndDrag");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnBeginDrag(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            Point pt = le.Point;

            int flags = 0;
            Log.LogMessage("OnBeginDrag at (" + pt.X + ", " + pt.Y + "), item " + HitTest(pt, flags) + ".");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnBeginRDrag(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            Log.LogMessage("OnBeginRDrag at " + le.Point.X + "," + le.Point.Y + ".");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnBeginLabelEdit(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            Log.LogMessage("OnBeginLabelEdit: " + le.Item.Text);
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnEndLabelEdit(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            Log.LogMessage("OnEndLabelEdit: " +
                (le.EditCancelled ? "[cancelled]" : le.Item.Text));
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnDeleteItem(object sender, Event e)
        {
            LogEvent(sender, e, "OnDeleteItem");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnDeleteAllItems(object sender, Event e)
        {
            LogEvent(sender, e, "OnDeleteAllItems");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnSelected(object sender, Event e)
        {
            LogEvent(sender, e, "OnSelected");

            ListEvent le = e as ListEvent;

            if ((StyleFlags & wx.WindowStyles.LC_REPORT) > 0)
            {
                ListItem info = new ListItem();
                info.Id = le.Index;
                info.Column = 1;
                info.Mask = ListItemMask.TEXT;
                if (GetItem(info))
                {
                    Log.LogMessage("Value of the 2nd field of the selected item: " +
                        info.Text);
                }
                else
                {
                    Console.WriteLine("wxListCtrl::GetItem() failed");
                }
                info.Dispose();
            }
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnDeselected(object sender, Event e)
        {
            LogEvent(sender, e, "OnDeselected");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnActivated(object sender, Event e)
        {
            LogEvent(sender, e, "OnActivated");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));
        }

        //---------------------------------------------------------------------	

        public void OnFocused(object sender, Event e)
        {
            LogEvent(sender, e, "OnFocused");
            Log.LogMessage(string.Format(_("Number of allocated and stored objects: {0}, {1}."), wx.Object.InstancesCount, wx.Object.SavedInstancesCount));

            e.Skip();
        }

        //---------------------------------------------------------------------	

        public void OnListKeyDown(object sender, Event e)
        {
            ListEvent le = e as ListEvent;

            switch (le.KeyCode)
            {
                case 'c': // colorize
                case 'C':
                    {
                        ListItem info = new ListItem();
                        info.Id = le.Index;
                        GetItem(info);

                        ListItemAttr attr = info.Attributes;
                        if (attr == null || !attr.HasTextColour)
                        {
                            info.TextColour = Colour.wxCYAN;

                            SetItem(info);

                            RefreshItem(info.Id);
                        }
                        info.Dispose();
                    }
                    break;

                case 'n': // next
                case 'N':
                    {
                        int item = GetNextItem(-1,
                            ListCtrl.NEXT.ALL, ListItemState.FOCUSED);
                        if (item++ == ItemCount - 1)
                        {
                            item = 0;
                        }

                        Log.LogMessage("Focusing item " + item);

                        SetItemState(item, ListItemState.FOCUSED, ListItemState.FOCUSED);
                        EnsureVisible(item);
                    }
                    break;

                case (int)KeyCode.WXK_DELETE:
                    {
                        int item = GetNextItem(-1,
                            ListCtrl.NEXT.ALL, ListItemState.SELECTED);
                        while (item != -1)
                        {
                            DeleteItem(item);

                            Log.LogMessage("Item " + item + " deleted");

                            // -1 because the indices were shifted by DeleteItem()
                            item = GetNextItem(item - 1,
                                ListCtrl.NEXT.ALL, ListItemState.SELECTED);
                        }
                    }
                    break;

                case (int)KeyCode.WXK_INSERT:
                    if ((StyleFlags & wx.WindowStyles.LC_REPORT) > 0)
                    {
                        if ((StyleFlags & wx.WindowStyles.LC_VIRTUAL) > 0)
                        {
                            ItemCount = ItemCount + 1;
                        }
                        else // !virtual
                        {
                            InsertItemInReportView(le.Index);
                        }
                    }
                    //else: fall through
                    break; //???

                default:
                    LogEvent(sender, e, "OnListKeyDown");

                    le.Skip();
                    break;
            }
        }

        //---------------------------------------------------------------------	

        public void OnChar(object sender, Event e)
        {
            KeyEvent ke = e as KeyEvent;

            Log.LogMessage("Got char event.");

            switch (ke.KeyCode)
            {
                case 'n':
                case 'N':
                case 'c':
                case 'C':
                    // these are the keys we process ourselves
                    break;

                default:
                    e.Skip();
                    break;
            }
        }

        //---------------------------------------------------------------------	

        public void LogEvent(object sender, Event e, string eventName)
        {
            ListEvent le = e as ListEvent;

            Log.LogMessage("Item " + le.Index + ": " + eventName + " (item text = " + le.Text +
                 ", data = " + le.Data + ")");
        }

        //---------------------------------------------------------------------	

        public override string OnGetItemText(int item, int column)
        {
            string s = "Column " + column + " of item " + item;
            return s;
        }

        //---------------------------------------------------------------------	

        public override int OnGetItemImage(int item)
        {
            return 0;
        }

        public override int OnGetItemColumnImage(int item, int col)
        {
            return col;
        }

        ListItemAttr _itemAttrMod10 = null;
        ListItemAttr _itemAttrMod2 = null;
        
        public override ListItemAttr OnGetItemAttr(int item)
        {
            if (item % 10 == 0)
            {
                if (this._itemAttrMod10 == null)
                {
                    this._itemAttrMod10 = new ListItemAttr(ColourDatabase.TheColourDatabase.Find("WHITE"), ColourDatabase.TheColourDatabase.Find("DARK GREY"), this.Font);
                }
                return this._itemAttrMod10;
            }
            else if (item % 2 == 0)
            {
                if (this._itemAttrMod2 == null)
                {
                    this._itemAttrMod2 = new ListItemAttr(ColourDatabase.TheColourDatabase.Find("BLACK"), ColourDatabase.TheColourDatabase.Find("LIGHT GREY"), this.Font);
                }
                return this._itemAttrMod2;
            }
            return null;
        }
        
        //---------------------------------------------------------------------	

        public void InsertItemInReportView(int i)
        {
            string buf = "This is item " + i;
            int tmp = InsertItem(i, buf, 0);
            SetItemData(tmp, i);

            buf = "Col 1, item " + i;
            SetItem(i, 1, buf);

            buf = "Item " + i + " in column 2";
            SetItem(i, 2, buf);
        }
    }

    //---------------------------------------------------------------------	

    public class ListCtrlApp : wx.App
    {
        public override bool OnInit()
        {
            MyFrame frame = new MyFrame("ListCtrl Test", new Point(50, 50), new Size(450, 340));
            frame.Show(true);

            return true;
        }

        //---------------------------------------------------------------------

        [STAThread]
        static void Main()
        {
            ListCtrlApp app = new ListCtrlApp();
            app.Run();
        }
    }
}

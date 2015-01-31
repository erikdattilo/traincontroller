// /*	OptionsDialog.cpp - Created by Giampiero Caprino
// 
// This file is part of Train Director 3
// 
// Train Director is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; using exclusively version 2.
// It is expressly forbidden the use of higher versions of the GNU
// General Public License.
// 
// Train Director is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Train Director; see the file COPYING.  If not, write to
// the Free Software Foundation, 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.
// */
// 
// #include <wx/wxprec.h>
// #include <wx/sizer.h>
// #include <wx/button.h>
// #include <wx/radiobox.h>
// #include <wx/statline.h>
// #include <wx/notebook.h>
// #include <wx/colordlg.h>
// 
// #include "Traindir3.h"
// #include "OptionsDialog.h"
// #include "MotivePower.h"
// 
// 
// extern  IntOption   http_server_port;
// extern  BoolOption  http_server_enabled;
// extern  StringOption user_name;
// 
// BEGIN_EVENT_TABLE(OptionsDialog, wxDialog)
// 	EVT_BUTTON(ID_CHOICE, OptionsDialog::OnColorChoice)
// END_EVENT_TABLE()
// 
// 
// static	struct opt {
//     const wxChar	*name;
//     int		*optp;
// } opts[NUM_OPTIONS + 1] = {
//     { wxT("Short train info"), &terse_status },
//     { wxT("Alert sound on"), &beep_on_alert },
//     { wxT("Alert on train entering layout"), &beep_on_enter },
//     { wxT("View speed limits"), &show_speeds },
//     { wxT("Automatically link signals"), &auto_link },
//     { wxT("Link signals to left track"), &link_to_left },
//     { wxT("Show grid"), &show_grid },
//     { wxT("View long blocks"), &show_blocks },
//     { wxT("Show seconds on clock"), &show_seconds },
//     { wxT("Traditional signals"), &signal_traditional },
//     { wxT("Strong performance checking"), &hard_counters },
//     { wxT("Show linked objects in editor"), &show_links },
//     { wxT("Show scripted objects in editor"), &show_scripts },
//     { wxT("Show trains icons"), &show_icons },
//     { wxT("Show trains tooltip"), &show_tooltip },
//     { wxT("Enable random delays"), &random_delays },
//     { wxT("Wait while playing sounds"), &play_synchronously },
//     { wxT("Swap head and tail icons"), &swap_head_tail },
//     { wxT("Show train names instead of icons"), &draw_train_names },
//     { wxT("Don't show train names colors"), &no_train_names_colors },
// //    { wxT("Check real-time train status"), &use_real_time },
//     0
// };
// 
// OptionsDialog::OptionsDialog(wxWindow *parent)
// : wxDialog(parent, 0, L("Preferences"), wxDefaultPosition, wxDefaultSize,
// 	   wxDEFAULT_DIALOG_STYLE, L("Preferences"))
// {
// 	int		i;
// 	wxArrayString   strings;
// 
//         wxPanel         *page1 = new wxPanel(this, wxID_ANY);
// 	wxBoxSizer	*column3 = new wxBoxSizer(wxVERTICAL);
//     
// 	    wxStaticText    *header = new wxStaticText(page1, 0, 
// 	        L("Check the desired options:"));
// 	    column3->Add(header, 0, wxALL, 10);
// 
//             wxBoxSizer	*column = new wxBoxSizer( wxVERTICAL );
// 	    wxBoxSizer	*column2 = new wxBoxSizer( wxVERTICAL );
// 	    for(i = 0; opts[i].name; ++i) {
// 
// 	        m_boxes[i] = new wxCheckBox( page1, ID_CHECKBOX,
// 		    LV(opts[i].name), wxDefaultPosition, wxDefaultSize);
// 
// 	        if(i > 9) {
// 		    column2->Add(m_boxes[i], 0, wxLEFT, 10);
// 		    column2->AddSpacer(6);
// 	        } else {
// 		    column->Add(m_boxes[i], 0, wxLEFT, 10);
// 		    column->AddSpacer(6);
// 	        }
// 	    }
//     
// 	    wxBoxSizer	*row = new wxBoxSizer( wxHORIZONTAL );
// 	    row->Add(column, 1, wxGROW|wxRIGHT, 5);
// 	    row->Add(column2, 1, wxGROW|wxRIGHT, 5);
// 	    column3->Add(row, 0, wxALL, 10);
// 
//         page1->SetSizer(column3);
// 
//         wxPanel *page2 = CreatePage2();
//         wxNotebook      *noteBook = new wxNotebook(this, wxID_ANY);
// 
//         wxPanel *page3 = CreatePage3();
// 
//         wxPanel *page4 = CreatePage4();     // Remote servers
// 
//         noteBook->AddPage(page1, L("Options"), true, 0);
//         noteBook->AddPage(page2, L("Environment"), false, 1);
//         noteBook->AddPage(page3, L("Skin"), false, 2);
//         noteBook->AddPage(page4, L("Server"), false, 3);
// 
//         wxBoxSizer	*column4 = new wxBoxSizer( wxVERTICAL );
//         column4->Add(noteBook);
// 
// 	column4->Add(CreateButtonSizer(wxOK | wxCANCEL), 0, wxGROW | wxALL, 10);
// 
// 	SetSizer(column4);
// 	column4->Fit(this);
// 	column4->SetSizeHints(this);
// }
// 
// OptionsDialog::~OptionsDialog()
// {
// }
// 
// wxBoxSizer *OptionsDialog::AddFileRow(wxPanel *page, Option& option, FileRow& out)
// {
//         wxBoxSizer      *row = new wxBoxSizer(wxHORIZONTAL);
//         wxStaticText    *label = new wxStaticText(page, wxID_ANY, localize(option._descr.c_str()));
//             //row->Add(label);
// 	    row->Add(label, 55, wxALIGN_LEFT | wxLEFT | wxRIGHT | wxTOP, 4);
//         out._path = new wxTextCtrl(page, wxID_ANY);
//             out._path->SetValue(option._sValue);
//             //row->Add(out._path);
//             row->Add(out._path, 75, wxRIGHT | wxGROW | wxTOP, 4);
//         out._button = new wxButton(page, wxID_ANY, wxT("..."));
//             //row->Add(out._button);
//             row->Add(out._button, 20, wxRIGHT | wxTOP, 4);
//         out._option = &option;
//         return row;
// }
// 
// extern  FileOption  alert_sound;
// extern  FileOption  entry_sound;
// extern  FileOption  searchPath;
// 
// wxPanel *OptionsDialog::CreatePage2()
// {
//         wxPanel    *page2 = new wxPanel(this, wxID_ANY);
// 
//         wxBoxSizer *column = new wxBoxSizer(wxVERTICAL);
//         wxBoxSizer *row;
//     
//             row = AddFileRow(page2, alert_sound, _alert);
//                 column->Add(row);
//             row = AddFileRow(page2, entry_sound, _enter);
//                 column->Add(row);
//             row = AddFileRow(page2, searchPath, _search);
//                 column->Add(row);
// 
//         page2->SetSizer(column);
//         return page2;
// }
// 
// 
// static	void	AddSkinRow(wxPanel *parent, wxBoxSizer *column, const Char *txt, SkinElementColor& rgb, int rgbV)
// {
// 	Char	buff[32];
// 	wxSize	sz(40, 20);
// 	wxStaticText *separator = new wxStaticText(parent, 0, wxT("   "));
// 
// 	wxBoxSizer	*row = new wxBoxSizer( wxHORIZONTAL );
// 	rgb.m_label = new wxStaticText(parent, 0, LV(txt));
// 	rgb.m_rgbSelector = new wxButton(parent, ID_CHOICE, L("Color..."), wxDefaultPosition, wxDefaultSize);
// 	sz.SetHeight(rgb.m_rgbSelector->GetSize().GetHeight());
// 	rgb.m_r = new wxTextCtrl(parent, 0, wxEmptyString, wxDefaultPosition, sz);
// 	rgb.m_g = new wxTextCtrl(parent, 0, wxEmptyString, wxDefaultPosition, sz);
// 	rgb.m_b = new wxTextCtrl(parent, 0, wxEmptyString, wxDefaultPosition, sz);
// 
// 	wxSprintf(buff, wxT("%d"), (rgbV >> 16) & 0xFF);
// 	rgb.m_r->SetValue(buff);
// 	wxSprintf(buff, wxT("%d"), (rgbV >> 8) & 0xFF);
// 	rgb.m_g->SetValue(buff);
// 	wxSprintf(buff, wxT("%d"), rgbV & 0xFF);
// 	rgb.m_b->SetValue(buff);
// 
// 	row->Add(rgb.m_label, 35, wxALIGN_LEFT | wxRIGHT | wxTOP, 4);
// 	row->Add(rgb.m_r, 20, wxALIGN_RIGHT | wxTOP, 4);
// 	row->Add(rgb.m_g, 20, wxALIGN_RIGHT | wxTOP, 4);
// 	row->Add(rgb.m_b, 20, wxALIGN_RIGHT | wxTOP, 4);
// 	row->Add(separator, 2, wxTOP, 4);
// 	row->Add(rgb.m_rgbSelector, 20, wxALIGN_RIGHT | wxTOP, 4);
// 
// 	column->Add(row, 1, wxGROW | wxLEFT | wxRIGHT, 10);
// }
// 
// static	int RetrieveValue(SkinElementColor& el)
// {
// 	int rv, gv, bv;
// 	wxString	str;
// 
// 	str = el.m_r->GetValue();
// 	rv = wxStrtoul(str.c_str(), 0, 0);
// 	str = el.m_g->GetValue();
// 	gv = wxStrtoul(str.c_str(), 0, 0);
// 	str = el.m_b->GetValue();
// 	bv = wxStrtoul(str.c_str(), 0, 0);
// 	return (rv << 16) | (gv << 8) | bv;
// }
// 
// 
// wxPanel *OptionsDialog::CreatePage3()
// {
//         wxPanel         *page = new wxPanel(this, wxID_ANY);
// 
// 	wxBoxSizer	*column = new wxBoxSizer( wxVERTICAL );
// 
//         TDSkin *m_skin = curSkin;
// 
// 	AddSkinRow(page, column, L("Background"), m_background, m_skin->background);
// 	AddSkinRow(page, column, L("Free Track"), m_freeTrack, m_skin->free_track);
// 	AddSkinRow(page, column, L("Reserved Track"), m_reservedTrack, m_skin->reserved_track);
// 	AddSkinRow(page, column, L("Reserved for Shunting"), m_reservedShunting, m_skin->reserved_shunting);
// 	AddSkinRow(page, column, L("Occupied"), m_occupiedTrack, m_skin->occupied_track);
// 	AddSkinRow(page, column, L("Reserved for Working"), m_workingTrack, m_skin->working_track);
// 	AddSkinRow(page, column, L("Switch Outline"), m_outline, m_skin->outline);
// 	AddSkinRow(page, column, L("Text"), m_text, m_skin->text);
// 
// 	page->SetSizer(column);
//         return page;
// }
// 
// wxPanel *OptionsDialog::CreatePage4()
// {
//         wxPanel         *page = new wxPanel(this, wxID_ANY);
// 
// 	wxBoxSizer	*column = new wxBoxSizer( wxVERTICAL );
// 
// 	    wxBoxSizer	*row = new wxBoxSizer( wxHORIZONTAL );
// 
//             _httpServerEnabled = new wxCheckBox( page, ID_CHECKBOX,
//                 L("Enable HTTP server"), wxDefaultPosition, wxDefaultSize);
// 
//             row->Add(_httpServerEnabled, 1, wxGROW | wxLEFT | wxRIGHT, 10);
// 
// 	column->Add(row, 1, wxGROW | wxLEFT | wxRIGHT, 10);
// 
// 	    row = new wxBoxSizer( wxHORIZONTAL );
// 
// 	    wxStaticText *label = new wxStaticText(page, 0, L("HTTP Server Port"));
// 	    _httpPort = new wxTextCtrl(page, 0, wxEmptyString, wxDefaultPosition);
// 
//             row->Add(label, 40);
//             row->Add(_httpPort, 60);
// 
// 	column->Add(row, 1, wxGROW | wxLEFT | wxRIGHT, 10);
// 
// 	    row = new wxBoxSizer( wxHORIZONTAL );
// 
// 	    label = new wxStaticText(page, 0, L("User name"));
//             _userName = new wxTextCtrl(page, 0, wxEmptyString, wxDefaultPosition);
// 
//             row->Add(label, 40);
//             row->Add(_userName, 60);
// 
// 	column->Add(row, 1, wxGROW | wxLEFT | wxRIGHT, 10);
// 
// 	page->SetSizer(column);
//         return page;
// }
// 
// void	OptionsDialog::OnColorChoice(wxCommandEvent& event)
// {
// 	wxObject* obj = event.GetEventObject();
// 	SkinElementColor *el = 0;
// 	if(obj == m_background.m_rgbSelector) {
// 	    el = &m_background;
// 	} else if(obj == m_freeTrack.m_rgbSelector) {
// 	    el = &m_freeTrack;
// 	} else if(obj == m_reservedTrack.m_rgbSelector) {
// 	    el = &m_reservedTrack;
// 	} else if(obj == m_reservedShunting.m_rgbSelector) {
// 	    el = &m_reservedShunting;
// 	} else if(obj == m_occupiedTrack.m_rgbSelector) {
// 	    el = &m_occupiedTrack;
// 	} else if(obj == m_workingTrack.m_rgbSelector) {
// 	    el = &m_workingTrack;
// 	} else if(obj == m_outline.m_rgbSelector) {
// 	    el = &m_outline;
// 	} else if(obj == m_text.m_rgbSelector) {
// 	    el = &m_text;
// 	} else
// 	    return;
// 
// 	int rv, gv, bv;
// 	wxString	str;
// 	str = el->m_r->GetValue();
// 	rv = wxStrtoul(str.c_str(), 0, 0);
// 	str = el->m_g->GetValue();
// 	gv = wxStrtoul(str.c_str(), 0, 0);
// 	str = el->m_b->GetValue();
// 	bv = wxStrtoul(str.c_str(), 0, 0);
// 	wxColor elCol(rv, gv, bv);
// 	wxColourData data;
// 	data.SetChooseFull(true);
// 	data.SetColour(elCol);
// 	/*
// 	for (int i = 0; i < 16; i++)
// 	{
// 	    wxColour colour(i*16, i*16, i*16);
// 	    data.SetCustomColour(i, colour);
// 	}
// 	*/
// 
// 	wxColourDialog dialog(this, &data);
// 	if (dialog.ShowModal() == wxID_OK)
// 	{
// 	    wxColourData retData = dialog.GetColourData();
// 	    wxColour col = retData.GetColour();
// 	    int v = col.Red();
// 	    str.Printf(wxT("%d"), v);
// 	    el->m_r->SetValue(str);
// 
// 	    v = col.Green();
// 	    str.Printf(wxT("%d"), v);
// 	    el->m_g->SetValue(str);
// 
// 	    v = col.Blue();
// 	    str.Printf(wxT("%d"), v);
// 	    el->m_b->SetValue(str);
// 
// 	    //wxBrush brush(col, wxSOLID);
// 	    //myWindow->SetBackground(brush);
// 	}
// }
// 
// int	OptionsDialog::ShowModal()
// {
// 	int	    i;
// 	int	    res;
// 
// 	for(i = 0; opts[i].name; ++i) {
// 	    m_boxes[i]->SetValue(*opts[i].optp != 0);
// 	}
//         _alert._path->SetValue(alert_sound._sValue);
//         _enter._path->SetValue(entry_sound._sValue);
//         _search._path->SetValue(searchPath._sValue);
// 
//         _httpServerEnabled->SetValue(http_server_enabled._iValue != 0);
//         _httpPort->SetValue(http_server_port._sValue);
//         _userName->SetValue(user_name._sValue);
// 
// 	Centre();
// 	bool oldIgnore = traindir->m_ignoreTimer;
// 	traindir->m_ignoreTimer = true;
// 	res = wxDialog::ShowModal();
// 	traindir->m_ignoreTimer = oldIgnore;
// 	if(res == wxID_OK) {
// 	    for(i = 0; opts[i].name; ++i) {
// 		*opts[i].optp = m_boxes[i]->GetValue() ? 1 : 0;
// 	    }
//             alert_sound.Set(_alert._path->GetValue());
//             entry_sound.Set(_enter._path->GetValue());
//             searchPath.Set(_search._path->GetValue());
// 
//             TDSkin *m_skin = curSkin;
// 	    m_skin->background = RetrieveValue(this->m_background);
// 	    m_skin->free_track = RetrieveValue(this->m_freeTrack);
// 	    m_skin->occupied_track = RetrieveValue(this->m_occupiedTrack);
// 	    m_skin->outline = RetrieveValue(this->m_outline);
// 	    m_skin->reserved_shunting = RetrieveValue(this->m_reservedShunting);
// 	    m_skin->reserved_track = RetrieveValue(this->m_reservedTrack);
// 	    m_skin->working_track = RetrieveValue(this->m_workingTrack);
// 	    m_skin->text = RetrieveValue(this->m_text);
// 
//             http_server_enabled.Set(_httpServerEnabled->GetValue());
//             http_server_port.Set(_httpPort->GetValue());
//             user_name.Set(_userName->GetValue());
// 	}
// 	return res;
// }
// 
// 
// 
// //
// //
// //
// 
// SelectPowerDialog::SelectPowerDialog(wxWindow *parent)
// : wxDialog(parent, 0, wxT("Select Motive Power"), wxDefaultPosition, wxDefaultSize,
// 	   wxDEFAULT_DIALOG_STYLE, L(" Motive Power "))
// {
// 	wxArrayString   strings;
// 	wxBoxSizer	    *column = new wxBoxSizer( wxVERTICAL );
// 	wxBoxSizer	    *row = new wxBoxSizer( wxHORIZONTAL );
// 
// 	wxStaticText	    *header = new wxStaticText( this, 0, L("Motive &Power"));
//         m_power = new wxComboBox(this, 0, wxEmptyString, wxDefaultPosition, wxDefaultSize);
// 
// 	row->Add(header, 35, wxALIGN_LEFT | wxRIGHT, 4);
// 	row->Add(m_power, 65, wxGROW | wxALIGN_RIGHT | wxLEFT, 6);
// 
// 	column->Add(row, 1, wxGROW | wxTOP | wxRIGHT | wxLEFT, 10);
// 
// 	row = new wxBoxSizer(wxHORIZONTAL);
// 
// ///        header = new wxStaticText(this, 0, L("Track &Gauge: "));
// ///	m_gauge = new wxTextCtrl(this, 0, wxEmptyString, wxDefaultPosition, wxDefaultSize);
// 
// 	row->Add(header, 35, wxALIGN_LEFT | wxRIGHT, 4);
// ///	row->Add(m_gauge, 65, wxGROW | wxALIGN_RIGHT | wxLEFT, 6);
// 
// 	column->Add(row, 1, wxGROW | wxTOP | wxRIGHT | wxLEFT, 10);
// //	wxStaticLine *line = new wxStaticLine( this );
// 
// //	column->Add(line);
// 
// 	column->Add(CreateButtonSizer(wxOK | wxCANCEL), 0, wxGROW | wxALL, 10);
// 
// 	SetSizer(column);
// 	column->Fit(this);
// 	column->SetSizeHints(this);
// }
// 
// SelectPowerDialog::~SelectPowerDialog()
// {
// }
// 
// int	SelectPowerDialog::ShowModal()
// {
//         Char    buff[64];
// 
// ///        wxSnprintf(buff, sizeof(buff)/sizeof(buff[0]), wxT("%d"), editor_gauge._iValue);
// ///        m_gauge->SetValue(buff);
//         m_power->Clear();
// 
//         for (int i = 0; i < gMotivePowerCache.Length(); ++i) {
//             const Char *p = gMotivePowerCache[i];
//             m_power->AppendString(p);
//         }
//         if (gEditorMotivePower)
//             m_power->SetValue(gEditorMotivePower);
// 
// 	Center();
// 	bool oldIgnore = traindir->m_ignoreTimer;
// 	traindir->m_ignoreTimer = true;
// 	m_power->SetFocus();
// 	int res = wxDialog::ShowModal();
// 	traindir->m_ignoreTimer = oldIgnore;
//         if(res != wxID_OK)
// 	    return wxID_CANCEL;
// 
//         power_select(m_power->GetValue().c_str());
// ///        editor_gauge.Set(m_gauge->GetValue().c_str());
// 	return wxID_OK;
// }
// 
// 

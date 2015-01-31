using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDirNET {
  class MainFrame_CPP {
  }
}

#if false

// ----------------------------------------------------------------------------
// MainFrame
// ----------------------------------------------------------------------------

const wxChar	*fileName(const wxChar *p)
{
	const wxChar	*p1 = p + wxStrlen(p);

	while(p1 > p) {
	    if(*p1 == ':' || *p1 == '\\' || *p1 == '/')
		return p1 + 1;
	    --p1;
	}
	return p1;
}

//
//
//

void	repaint_labels(bool force)
{
	int	i;

	for(i = 0; i < 8; ++i)
	    if(//labelList[i].handle &&
		force ||
		wxStrcmp(labelList[i].text, labelList[i].oldtext)) {
		if(i == 7)
		    traindir->m_frame->m_statusText->SetLabel(labelList[i].text);
		else if(i == 2)
		    traindir->m_frame->m_alertText->SetLabel(labelList[i].text);
		else if(i == 0) {
		    wxString	buff = labelList[i].text;
		    size_t	p;

		    p = buff.find(wxT('('));
		    if(p == wxString::npos)
			p = buff.find(wxT('x'));
		    if(p != wxString::npos) {
			wxString buff;
			buff.Printf (wxT("x %d"), time_mult);
			traindir->m_frame->m_speed->SetValue(buff);
			traindir->m_frame->m_speedArrows->SetValue(cur_time_mult);
		    }
		    traindir->m_frame->m_clock->SetLabel(buff.substr (0, p));
		} else if(i < NSTATUSBOXES)
		    traindir->m_frame->SetStatusText(labelList[i].text, i);
		wxStrncpy(labelList[i].oldtext, labelList[i].text,
			sizeof(labelList[i].oldtext) / sizeof(wxChar));
		labelList[i].oldtext[sizeof(labelList[i].oldtext) / sizeof(wxChar)- 1] = 0;
	    }
	wxString    title;
	
	if(traindir->m_frame->m_showToolbar) {
	    title << program_name;
	    title << wxT(" - ");
	    title << fileName(current_project);
	    if(layout_modified)
		title << wxT(" *");
	    title << wxT(" - ");
	    title << labelList[0].text;
	    title << wxT(" - ");
	    title << total_points_msg;
	} else {
	    title << labelList[0].text;
	    title << wxT(" - ");
	    title << total_points_msg;
	    title << wxT(" - ");
	    title << labelList[7].text;
	}
	traindir->m_frame->SetTitle(title);
}


void	select_tool(int i)
{
	current_tool = i;
	tools_grid->Clear();
	traindir->m_frame->m_toolsView->Refresh();
}

void	show_table(void)	// originally to show start/stop,fast/slow buttons and labels
{
}

void	hide_table(void)	// originally to hide start/stop,fast/slow buttons and labels
{
}

void	show_tooltable(void)	// show editing tools
{
	traindir->m_frame->ShowTools(true);
}

void	hide_tooltable(void)	// hide editing tools
{
	traindir->m_frame->ShowTools(false);
}

void	FillItineraryTable();

void	show_itinerary(void)	// show itinerary table
{
	traindir->m_frame->ShowItinerary(true);
	FillItineraryTable();
}

void	hide_itinerary(void)	// hide itinerary table
{
	traindir->m_frame->ShowItinerary(false);
}

int	create_tgraph(void)
{
	traindir->m_frame->ShowGraph();
	return 0;
}

int	ask_number(const wxChar *title, const wxChar *question)
{
	wxTextEntryDialog diag(traindir->m_frame, LV(question), LV(title));

	if(diag.ShowModal() != wxID_OK)
	    return -1;
	wxString result = diag.GetValue();
	return wxAtoi(result.c_str());
}

void    alert_dialog(const Char *msg)
{
        wxString message(msg);
        wxMessageBox(message, wxT("Info"));
}
#endif
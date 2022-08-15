using CCMS.NEOPE.Application.ViewModels.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Application.Interfaces;

public interface ICalendarService
{
    ICollection<ViewCalendarModel> List();
}


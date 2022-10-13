using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IBoardService
{
    decimal GetProgress(ulong? projectid = null);
    decimal GetConformity(ulong? projectid = null);
    decimal GetAdherence(ulong? projectid = null);

    decimal GetQo(ulong? projectId = null);
    decimal GetApos(ulong? projectId = null);

    object[] GetProgressPerProjectChart(ulong? projectId = null);

    object[] GetPendenciesPerStepsChart(ulong? projectId=null);
    object[] GetPendenciesPerCategoryChart(ulong? projectId=null);
    object[] GetProgressChart(ulong? projectId=null);

}

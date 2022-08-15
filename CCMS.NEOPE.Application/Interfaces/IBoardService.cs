using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IBoardService
{
    decimal GetProgress();
    decimal GetConformity();
    decimal GetAdherence();
    decimal GetProgressPerProject(ulong projectId);
    decimal GetConformityPerProject(ulong projectId);
    decimal GetAdherencePerProject(ulong projectId);

}

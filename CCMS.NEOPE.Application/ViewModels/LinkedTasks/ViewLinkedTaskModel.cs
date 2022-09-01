using System.ComponentModel.DataAnnotations;
using CCMS.NEOPE.Domain.Enums;

namespace CCMS.NEOPE.Application.ViewModels.LinkedTasks;

public class ViewLinkedTaskModel
{
    public ulong? Id { get; set; }
    
    public ulong? ObjectTaskId { get; set; }
    
    public ulong? SubjectTaskId { get; set; }
    
    public LinkType Type { get; set; }
    public string TypeText { get; set; } = string.Empty;
    public string TaskText { get; set; } = string.Empty;

}
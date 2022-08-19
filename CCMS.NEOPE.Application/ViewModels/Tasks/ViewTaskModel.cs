namespace CCMS.NEOPE.Application.ViewModels.Tasks;

public class ViewTaskModel
{
    public ulong Id { get; set; }
    public string Title { get; set; }
    public string ProjectName { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public string StartDate { get; set; }
    public string DueDate { get; set; }
    public string TaskType { get; set; }
    public string Category { get; set; }
}
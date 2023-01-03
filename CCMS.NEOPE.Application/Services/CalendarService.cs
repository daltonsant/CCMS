using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Calendar;
using CCMS.NEOPE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Status = CCMS.NEOPE.Domain.Enums.Status;


namespace CCMS.NEOPE.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public CalendarService(ITaskRepository taskRepository, IMapper mapper, IAssetRepository assetRepository)
        {
            _taskRepository = taskRepository;
            _assetRepository = assetRepository;
            _mapper = mapper;
        }
        
        public ICollection<ViewCalendarModel> List()
        {
            var scheduledTasks = _taskRepository.Entities
                .Where(x => x.Status != Status.Done && (x.StartDate.HasValue || x.DueDate.HasValue));
            List<ViewCalendarModel> calendar = new List<ViewCalendarModel>();

            var assetStatus = _assetRepository.Entities.Include(x => x.Project)
                .Include(x => x.Status).Where(x => x.Status.Status != Status.Done);

            foreach (var task in scheduledTasks)
            {
                var taskEvent = _mapper.Map<ViewCalendarModel>(task);
                
                if(task.StartDate.HasValue && !task.DueDate.HasValue)
                {
                    taskEvent.start = task.StartDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = DateTime.Today.AddDays(31).ToString("yyyy-MM-dd");
                }

                if(!task.StartDate.HasValue && task.DueDate.HasValue)
                {
                    taskEvent.start = task.DueDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = task.DueDate.Value.AddDays(1).ToString("yyyy-MM-dd");
                }

                if (task.StartDate.HasValue && task.DueDate.HasValue)
                {
                    taskEvent.start = task.StartDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = task.DueDate.Value.AddDays(1).ToString("yyyy-MM-dd");
                }

                if(task.DueDate.HasValue && task.DueDate.Value == DateTime.Today)
                {
                    taskEvent.className = "event-attention";
                }

                if (task.DueDate.HasValue && task.DueDate.Value < DateTime.Today)
                {
                    taskEvent.className = "event-late";
                }

                taskEvent.url = "/Tasks/Edit/" + taskEvent.id;

                calendar.Add(taskEvent);
            }

            foreach(var asset in assetStatus)
            {
                var task = asset.Status;

                var taskEvent = new ViewCalendarModel()
                {
                     id = "assetId_"+asset.Id,
                     title = asset.Project.Code +"-"+ asset.Code,
                };

                if(task.StartDate.HasValue && !task.DueDate.HasValue)
                {
                    taskEvent.start = task.StartDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = DateTime.Today.AddDays(31).ToString("yyyy-MM-dd");
                }

                if(!task.StartDate.HasValue && task.DueDate.HasValue)
                {
                    taskEvent.start = task.DueDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = task.DueDate.Value.AddDays(1).ToString("yyyy-MM-dd");
                }

                if (task.StartDate.HasValue && task.DueDate.HasValue)
                {
                    taskEvent.start = task.StartDate.Value.ToString("yyyy-MM-dd");
                    taskEvent.end = task.DueDate.Value.AddDays(1).ToString("yyyy-MM-dd");
                }

                if(task.DueDate.HasValue && task.DueDate.Value == DateTime.Today)
                {
                    taskEvent.className = "event-attention";
                }

                if (task.DueDate.HasValue && task.DueDate.Value < DateTime.Today)
                {
                    taskEvent.className = "event-late";
                }

                taskEvent.url = "/Assets/Activity/" + asset.Id;

                calendar.Add(taskEvent);
            }
            

            return calendar;
        }
    }
}

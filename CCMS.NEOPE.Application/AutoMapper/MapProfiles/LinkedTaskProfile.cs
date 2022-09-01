using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.LinkedTasks;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class LinkedTaskProfile : Profile
{
    public LinkedTaskProfile()
    {
        CreateMap<ViewLinkedTaskModel,ViewLinkedTaskModel>();
    }
}
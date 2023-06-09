﻿using AutoMapper;
using HRLeaveSystem.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveSystem.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRLeaveSystem.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveSystem.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRLeaveSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Application.MappingProfiles
{
    public class LeaveTypeProfile: Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}

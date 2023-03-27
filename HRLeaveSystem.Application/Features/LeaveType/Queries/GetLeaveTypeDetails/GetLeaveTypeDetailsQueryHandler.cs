using AutoMapper;
using HRLeaveSystem.Application.Contracts.Persistence;
using HRLeaveSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = repository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.id);

            if (leaveTypeDetails == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveType), request.id);
            }

            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);

            return data;
        }
    }
}

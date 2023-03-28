using AutoMapper;
using HRLeaveSystem.Application.Contracts.Persistence;
using HRLeaveSystem.Application.Exceptions;
using HRLeaveSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = repository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }

            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            return leaveTypeToCreate.Id;
        }
    }
}

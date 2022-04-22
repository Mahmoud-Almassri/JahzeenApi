using AutoMapper;
using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using JahzeenApi.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Repository.UnitOfWork;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Services
{
    public class EmployeeAttachmentsService : IEmployeeAttachmentsService
    {
        private readonly LoggedInUserService _loggedInUserService;
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;

        public EmployeeAttachmentsService(IRepositoryUnitOfWork repositoryUnitOfWork, LoggedInUserService loggedInUserService, IMapper mapper)
        {
            _mapper = mapper;
            loggedInUserService = loggedInUserService;
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        public EmployeeAttachments Add(EmployeeAttachments entity)
        {
            return _repositoryUnitOfWork.EmployeeAttachments.Value.Add(entity);
        }

        public IEnumerable<EmployeeAttachments> AddRange(IEnumerable<EmployeeAttachments> entities)
        {
            return _repositoryUnitOfWork.EmployeeAttachments.Value.AddRange(entities);
        }

        public EmployeeAttachments Get(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeAttachments> GetAll()
        {
            return _repositoryUnitOfWork.EmployeeAttachments.Value.GetAll();
        }

        public EmployeeAttachmentDTO GetAttachemntByLoggedInUser()
        {
            int userId = _loggedInUserService.GetUserId();
            EmployeeAttachments Attachments = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);
            EmployeeAttachmentDTO employeeAttachmentDTO = _mapper.Map<EmployeeAttachmentDTO>(Attachments);
            return employeeAttachmentDTO;
        }
        public EmployeeAttachmentDTO GetAttachemntById(int userId)
        {
            EmployeeAttachments Attachments = _repositoryUnitOfWork.EmployeeAttachments.Value.FirstOrDefault(x => x.ApplicationUserId == userId);
            EmployeeAttachmentDTO employeeAttachmentDTO = _mapper.Map<EmployeeAttachmentDTO>(Attachments);
            return employeeAttachmentDTO;
        }

        public EmployeeAttachments Remove(EmployeeAttachments entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeAttachments> RemoveRange(IEnumerable<EmployeeAttachments> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeAttachments> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public EmployeeAttachments Update(EmployeeAttachments entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeAttachments> UpdateRange(IEnumerable<EmployeeAttachments> entities)
        {
            throw new NotImplementedException();
        }
    }
}

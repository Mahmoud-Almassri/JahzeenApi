using JahzeenApi.Domain.DTO;
using JahzeenApi.Domain.Models;
using Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JahzeenApi.Service.Interfaces
{
    public interface IEmployeeAttachmentsService : IService<EmployeeAttachments>
    {
        public EmployeeAttachmentDTO GetAttachemntByLoggedInUser();
        public EmployeeAttachmentDTO GetAttachemntById(int userId);

    }
}

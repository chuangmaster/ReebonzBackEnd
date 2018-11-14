using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Interfaces.Service;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reebonz.Service
{
    /// <summary>
    /// class RefundService
    /// </summary>
    public class RefundService : IRefundService
    {
        IRefundRepository _RefundRepository;
        public RefundService(IRefundRepository refundRepository)
        {
            _RefundRepository = refundRepository;
        }
        public int Add(RefundAddParameterDTO parameter)
        {
            _RefundRepository.Get();
            return 1;
        }

        public List<RefundDTO> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}

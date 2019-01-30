using AutoMapper;
using Reebonz.Dapper.Repository.Interfaces;
using Reebonz.Dapper.Repository.Parameters;
using Reebonz.Service.DTO;
using Reebonz.Service.DTO.Parameters;
using Reebonz.Service.Interfaces;
using Reebonz.Service.MapperProfile;
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
        IMapper _Mapper;
        IRefundRepository _RefundRepository;

        public RefundService(IRefundRepository refundRepository)
        {
            _RefundRepository = refundRepository;
            _Mapper = RefundMapperProfile.Config;
        }

        public int Add(RefundAddParameterDTO parameter)
        {
            var Result = _RefundRepository.Add(_Mapper.Map<RefundAddRptParameter>(parameter));
            return 1;
        }

        public List<RefundDTO> Get()
        {
            return _Mapper.Map<List<RefundDTO>>(_RefundRepository.Get());
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}

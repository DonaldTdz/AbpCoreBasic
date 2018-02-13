using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpBasic.DB2.ACTS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpBasic.ACTS.Dto
{
    [AutoMap(typeof(ACT))]
    public class ACTDto : EntityDto<short>
    {
        public short ACTNO { get; set; }

        public string ACTKWD { get; set; }

        public string ACTDESC { get; set; }
    }
}

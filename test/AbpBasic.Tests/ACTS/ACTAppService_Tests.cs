using AbpBasic.ACTS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AbpBasic.Tests.ACTS
{
    public class ACTAppService_Tests : AbpBasicTestBase
    {
        private readonly IACTAppService _userAppService;

        public ACTAppService_Tests()
        {
            _userAppService = Resolve<IACTAppService>();
        }

        [Fact]
        public void GetACTListByLikeDesc()
        {
            // Act
            var actList = _userAppService.GetACTListByLikeDesc("CO");

            // Assert
            if (actList.Count == 0)
            {

            }
        }
    }
}

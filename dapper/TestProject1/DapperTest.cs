using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;

namespace TestProject1
{
    public class DapperTest
    {
        [Fact]
        public void GetAll_Returns_Correct_Number_Of_InnerJoin()
        {
            // Arrange
            var count = 2;
            var fakeService = A.Fake<IJService>();
            var fakeResult = A.CollectionOfDummy<InnerJoin>(count).AsEnumerable();
            A.CallTo(() => fakeService.GetInnerJoinDataAsync()).Returns(fakeResult);
            var controller = new IJController(fakeService);

            // Act
            var actionResult = controller.GetInnerJoinData();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnIJ = result.Value as IEnumerable<InnerJoin>;
            Assert.Equal(count, returnIJ.Count());
        }
    }
}
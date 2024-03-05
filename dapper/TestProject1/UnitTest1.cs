namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int num1 = 3;
            int num2 = 5;

            // Act
            int result = num1 + num2;

            // Assert
            Assert.Equal(8, result);
        }
    }
}
namespace Rene.Utils.Core.UnitTest.Extensions.Exceptions
{
    using FluentAssertions;
    using System;
    using Xunit;

    public class ExceptionExtensionsTest
    {
        [Fact]
        public void GetFullMessage_Should_Be_Exception_Message_When_No_InnerException()
        {
            // Arrange
            var input = new Exception("Test Exception");

            // Act
            var result = input.GetFullMessage();

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .BeEquivalentTo(input.Message)
                ;
        }

        [Fact]
        public void GetFullMessage_Should_Be_ExceptionPlusInner_Message_When_One_InnerException()
        {
            // Arrange
            var innerException = new Exception("Inner Exception");
            var input = new Exception("Test Exception", innerException);

            // Act
            var result = input.GetFullMessage();

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .BeEquivalentTo($"{input.Message} ---> {innerException.Message}")
                ;
        }

        [Fact]
        public void GetFullMessage_Should_Be_ExceptionPlusAllInner_Message_When_Many_InnerException()
        {
            // Arrange
            var innerException2 = new Exception("Inner Exception 2");
            var innerException1 = new Exception("Inner Exception 1", innerException2);
            var input = new Exception("Test Exception", innerException1);

            // Act
            var result = input.GetFullMessage();

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .BeEquivalentTo($"{input.Message} ---> {innerException1.Message} ---> {innerException2.Message}")
                ;
        }

        [Fact]
        public void GetFullMessage_ShouldBe_Empty_When_Exception_IsNull()
        {
            // Arrange
            Exception input = null;
            
            // Act
            var result = input.GetFullMessage();

            // Assert
            result
                .Should()
                .BeNullOrEmpty()
                ;
        }
    }
}

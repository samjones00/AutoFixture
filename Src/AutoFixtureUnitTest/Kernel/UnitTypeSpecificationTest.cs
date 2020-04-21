using System;
using AutoFixture.Kernel;
using TestTypeFoundation;
using Xunit;

namespace AutoFixtureUnitTest.Kernel
{
    public class UnitTypeSpecificationTest
    {
        [Fact]
        public void SutIsRequestSpecification()
        {
            // Arrange
            // Act
            var sut = new UnitTypeSpecification();

            // Assert
            Assert.IsAssignableFrom<IRequestSpecification>(sut);
        }

        [Fact]
        public void IsSatisfiedByWithNullShouldThrowArgumentNullException()
        {
            // Arrange
            var sut = new UnitTypeSpecification();

            // Act & assert
            Assert.Throws<ArgumentNullException>(() => sut.IsSatisfiedBy(null));
        }

        [Theory]
        [InlineData("string")]
        [InlineData(4)]
        [InlineData(4.9D)]
        [InlineData(true)]
        public void IsSatisfiedByWithSomethingOtherThanTypeShouldReturnFalse(object request)
        {
            // Arrange
            var sut = new UnitTypeSpecification();

            // Act
            var result = sut.IsSatisfiedBy(request);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(typeof(MutableValueType))]
        [InlineData(typeof(MutableValueTypeWithoutConstructor))]
        [InlineData(typeof(MutableValueTypeWithField))]
        [InlineData(typeof(MutableValueTypeWithFieldWithoutConstructor))]
        public void IsSatisfiedByWithMutableValueTypeWithMembersShouldReturnFalse(object request)
        {
            // Arrange
            var sut = new UnitTypeSpecification();

            // Act
            var result = sut.IsSatisfiedBy(request);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(typeof(ImmutableValueTypeWithProperty))]
        [InlineData(typeof(ImmutableValueTypeWithField))]
        public void IsSatisfiedByWithImmutableValueTypeWithMembersShouldReturnFalse(object request)
        {
            // Arrange
            var sut = new UnitTypeSpecification();

            // Act
            var result = sut.IsSatisfiedBy(request);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsSatisfiedByWithUnitTypeShouldReturnTrue()
        {
            // Arrange
            var sut = new UnitTypeSpecification();

            // Act
            var result = sut.IsSatisfiedBy(typeof(UnitType));

            // Assert
            Assert.True(result);
        }
    }
}

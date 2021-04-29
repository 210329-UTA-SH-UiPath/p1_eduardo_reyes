using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_StoreName()
        {
            // arrange
            var sut = new Store();

            // act
            var actual = sut.StoreLocation;

            // assert
            Assert.Null(actual);
        }

        public void Test_StoreId()
        {
            // arrange
            var sut = new Store();

            // act
            var actual = sut.StoreID;

            // assert
            Assert.Null(actual);
        }
    }
}
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class PizzaTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Test_PizzaCustomPizza()
        {
            // arrange
            var sut = new CustomPizza();

            // act
            var actual = sut.Crust;

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void Test_PizzaTopping()
        {
            var sut = new Toppings();

            var actual = sut.Id;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaSize()
        {
            var sut = new Size();

            var actual = sut.Price;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaOrder()
        {
            var sut = new MOrder();

            var actual = sut.Cost;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaOrderId()
        {
            var sut = new MOrder();

            var actual = sut.OrderID;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaList()
        {
            var sut = new MOrder();

            var actual = sut.ListOfPizzas;

            Assert.Empty(actual);
        }

        [Fact]
        public void Test_PizzaCustomer()
        {
            var sut = new MOrder();

            var actual = sut.Customer.username;

            Assert.Null(actual);
        }

        [Fact]
        public void Test_CustomPizzaSize()
        {
            var sut = new CustomPizza();

            var actual = sut.Size;

            Assert.NotEmpty(actual);
        }

        [Fact]
        public void Test_PizzaName()
        {
            var sut = new CustomPizza();

            var actual = sut.Name;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaToppings()
        {
            var sut = new CustomPizza();

            var actual = sut.Toppings;

            Assert.Empty(actual);
        }

        [Fact]
        public void Test_PizzaOrderTotal()
        {
            var sut = new CustomPizza();

            var actual = sut.TotalOrderedPizzas;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaCrustId()
        {
            var sut = new Crust();

            var actual = sut.Id;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaCrustName()
        {
            var sut = new Crust();

            var actual = sut.Name;

            Assert.NotEmpty(actual.ToString());
        }

        [Fact]
        public void Test_PizzaOrderToppingsList()
        {
            var sut = new MOrder();

            var actual = sut.ListOfToppings;

            Assert.Empty(actual);
        }


    }
}
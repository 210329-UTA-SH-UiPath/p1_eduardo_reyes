using System;
using System.Collections.Generic;
using PizzaBox.Data.Entity;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Data
{
    public class Mapper : IMapper
    {
        public PizzaBox.Domain.Models.MOrder Map(Entity.Order order)
        {

            return new PizzaBox.Domain.Models.MOrder
            {
                
                CustomerId = order.CustomerId,
                StoreId = (int)order.StoreId,


                OrderID = order.OrderId,

                Cost = order.Cost,

                time = (DateTime) order.OrderDate
            };


        }




        public PizzaBox.Domain.Models.CustomPizza Map(Entity.Pizza pizza)
        {

            return new PizzaBox.Domain.Models.CustomPizza
            {

                PizzaPrice = pizza.PizzaPrice,
                OrderId = (int)pizza.OrderId,
                CrustId = pizza.CrustId,
                SizeId = pizza.PizzaSizeId,
                PizzaId = pizza.PizzaId
                

            };
        }

        public PizzaBox.Domain.Models.Store Map(Entity.Store store)
        {
            return new PizzaBox.Domain.Models.Store
            {
                StoreID = store.StoreId,
                StoreLocation = store.StoreLocation,

            };


        }

        public PizzaBox.Domain.Models.MCrust Map(Entity.Crust crust)
        {
            return new PizzaBox.Domain.Models.MCrust
            {
                Name = crust.CrustName,
                Price = crust.CrustPrice,
                Id = crust.CrustId
            };
        }

        public PizzaBox.Domain.Models.Size Map(Entity.PizzaSize size)
        {
            return new PizzaBox.Domain.Models.Size
            {
                Name = size.PizzaSizeName,
                Price = size.PizzaSizePrice,
                Id = size.PizzaSizeId
            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.PizzaTopping topping)
        {
            return new PizzaBox.Domain.Models.Toppings
            {
                PizzaID = topping.PizzaToppingId,
                Id = topping.Topping.ToppingId,
                Name = topping.Topping.ToppingName,
                Price = topping.Topping.ToppingPrice

            };
        }

        public PizzaBox.Domain.Models.Toppings Map(Entity.Topping topping)
        {
            return new PizzaBox.Domain.Models.Toppings
            {
                Id = topping.ToppingId,
                Name = topping.ToppingName,
                Price = topping.ToppingPrice
            };
        }

        public PizzaBox.Domain.Models.MCustomer Map(Entity.Customer customer)
        {
            return new PizzaBox.Domain.Models.MCustomer
            {
                username = customer.Username,
                password = customer.Password,
                FirstName = customer.CustomerFirstName,
                LastName = customer.CustomerLastName,
                PhoneNumber = customer.CustomerPhone,
                Address = customer.CustomerAddress,
                CardNumber = customer.CustomerCardNumber,
                CardExpDate = customer.CustomerCardDate,
                CardCode = customer.CustomerCardCvv,
                CustomerID = customer.CustomerId
            };
        }

        public PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.Specialty pizza)
        {
            return new Domain.Models.CustomPizza
            {
                Name = pizza.PizzaName,
                PizzaPrice = pizza.PizzaPrice,
                SpecialtyId = pizza.SpecialtyId
            };
        }

        public PizzaBox.Data.Entity.Customer Map(Domain.Models.MCustomer customer)
        {
            return new PizzaBox.Data.Entity.Customer
            {
                Username = customer.username,
                Password = customer.password,
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerPhone = customer.PhoneNumber,
                CustomerAddress = customer.Address,
                CustomerCardNumber = customer.CardNumber,
                CustomerCardDate = customer.CardExpDate,
                CustomerCardCvv = customer.CardCode,
                CustomerId = customer.CustomerID
            };
        }

        public PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.MOrder order)
        {
            return new PizzaBox.Data.Entity.Order
            {
                OrderId = order.OrderID,
                CustomerId = order.CustomerId,
                StoreId = (byte) order.StoreId,
                Cost = order.Cost,
                OrderDate = System.DateTime.Now,

            };
        }

        public PizzaBox.Data.Entity.Pizza Map(PizzaBox.Domain.Models.CustomPizza pizza)
        {
            return new PizzaBox.Data.Entity.Pizza
            {
                PizzaId = pizza.PizzaId,
                OrderId = pizza.OrderId,
                CrustId = pizza.CrustId,
                PizzaSizeId = pizza.SizeId,
                PizzaPrice = pizza.PizzaPrice


            };
        }

        public PizzaBox.Data.Entity.PizzaTopping Map(PizzaBox.Domain.Models.Toppings toppings)
        {
            return new PizzaBox.Data.Entity.PizzaTopping
            {
                PizzaToppingId = toppings.PizzaToppingID,
                PizzaId = toppings.PizzaID,
                ToppingId = (byte)toppings.Id

            };
        }

        public PizzaBox.Data.Entity.Topping MapTop(PizzaBox.Domain.Models.Toppings toppings)
        {
            return new PizzaBox.Data.Entity.Topping
            {
                ToppingId = (byte)toppings.PizzaToppingID,
                ToppingName = toppings.Name,
                ToppingPrice = toppings.Price
            };
        }


    }
}
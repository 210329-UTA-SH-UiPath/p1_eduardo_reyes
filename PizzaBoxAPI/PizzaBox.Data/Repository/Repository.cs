

using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Linq;
using System.Linq.Expressions;
using System;
using PizzaBox.Data.Entity;

namespace PizzaBox.Data
{
    public class Repository : IRepository
    {

        private readonly Entity.PizzaBoxInformationContext context;

        IMapper mapper = new Mapper();

        public Repository(Entity.PizzaBoxInformationContext context)
        {
            this.context = context;
        }



        public void AddPizza(CustomPizza pizza)
        {


            context.Add(mapper.Map(pizza));


            context.SaveChanges();

        }

        public CustomPizza GetPizzaByIndex(int Id)
        {
            var pizza = context.Specialties.Where(x => x.SpecialtyId == Id).FirstOrDefault();

            return mapper.Map(pizza);
        }

        public List<CustomPizza> GetPizzasOrders()
        {
            var pizzas = context.Pizzas;
            return pizzas.Select(mapper.Map).ToList();
        }

        public List<CustomPizza> GetPizzaOrdersById(int Id)
        {
            return context.Pizzas.Where(x => x.OrderId == Id).Select(mapper.Map).ToList();
        }

        public CustomPizza GetPizzaOrderById(int Id)
        {
            var pizza = context.Pizzas.Where(x => x.PizzaId == Id).FirstOrDefault();
            return mapper.Map(pizza);
        }

        public void DeletePizza(int Id)
        {
            var pizza = context.Pizzas.Where(x => x.PizzaId == Id).FirstOrDefault();
            context.Remove(mapper.Map(pizza));
            context.SaveChanges();
        }

        public void UpdatePizza(CustomPizza pizza)
        {
            var updatePizza = context.Crusts.Where(x => x.CrustId == pizza.PizzaId).FirstOrDefault();
            if (updatePizza != null)
            {
                updatePizza.CrustId = (byte)pizza.PizzaId;
                updatePizza.CrustName = pizza.Name;
                updatePizza.CrustPrice = pizza.PizzaPrice;

                context.Update(updatePizza);
                context.SaveChanges();

            }
        }

        public List<MCustomer> GetCustomers()
        {
            var customers = context.Customers;
            Console.WriteLine(customers);
            return customers.Select(mapper.Map).ToList();
        }

        public MCustomer GetCustomerById(int Id)
        {
            var customer = context.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            return mapper.Map(customer);
        }

        public void AddCustomer(MCustomer customer)
        {
            context.Add(mapper.Map(customer));
            context.SaveChanges();
        }

        public void DeleteCustomer(int Id)
        {
            var customer = context.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            context.Remove(mapper.Map(customer));
            context.SaveChanges();
        }

        public void UpdateCustomer(MCustomer customer)
        {
            var updateCustomer = context.Customers.Where(x => x.Username == customer.username).FirstOrDefault();
            if(updateCustomer != null)
            {
                updateCustomer.CustomerId = customer.CustomerID;
                updateCustomer.CustomerFirstName = customer.FirstName;
                updateCustomer.CustomerLastName = customer.LastName;
                updateCustomer.CustomerPhone = customer.PhoneNumber;
                updateCustomer.CustomerAddress = customer.Address;
                updateCustomer.CustomerCardCvv = customer.CardCode;
                updateCustomer.CustomerCardDate = customer.CardExpDate;
                updateCustomer.CustomerCardNumber = customer.CardNumber;
                updateCustomer.Password = customer.password;

                context.Update(updateCustomer);
                context.SaveChanges();

            }
        }

        public void AddOrder(MOrder order)
        {
            context.Add(mapper.Map(order));
            //AddToppings(order);
            context.SaveChanges();
        }

        public List<MOrder> GetAllOrders()
        {
            var orders = context.Orders;
            var map = orders.Select(mapper.Map).ToList();
            return map;
        }

        public MOrder GetOrderById(int id)
        {
            var order = context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            return mapper.Map(order);
        }

        public int GetOrderCount()
        {
            int count = context.Orders.Count();
            return count;
        }

        public void UpdateOrder(MOrder order)
        {
            var updateOrder = context.Orders.Where(x => x.OrderId == order.OrderID).FirstOrDefault();
            if (updateOrder != null)
            {
                updateOrder.OrderId = order.OrderID;
                updateOrder.StoreId = (byte)order.StoreId;
                updateOrder.OrderDate = order.time;
                updateOrder.CustomerId = order.CustomerId;
                updateOrder.Cost = order.Cost;
                context.Update(updateOrder);
                context.SaveChanges();


            }


        }

        public void DeleteOrder(int Id)
        {
            var order = context.Orders.Where(x => x.OrderId == Id).FirstOrDefault();
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public List<MCustomer> GetUserAndPass()
        {
            var info = context.Customers;
            return info.Select(mapper.Map).ToList();
        }

        public List<PizzaBox.Domain.Models.Store> GetStores()
        {
            var stores = context.Stores;
            return stores.Select(mapper.Map).ToList();
        }

        public PizzaBox.Domain.Models.Store GetStoreByIndex(int Id)
        {
            var store = context.Stores.Where(x => x.StoreId == Id).FirstOrDefault();

            return mapper.Map(store);
        }

        public void AddCrust(MCrust crust)
        {
            context.Add(crust);
            context.SaveChanges();
        }

        public List<MCrust> GetPizzaCrusts()
        {
            var crusts = context.Crusts;
            return crusts.Select(mapper.Map).ToList();
        }

        public MCrust GetCrustByIndex(int Id)
        {
            var crust = context.Crusts.Where(x => x.CrustId == Id).FirstOrDefault();
            return mapper.Map(crust);
        }

        public void UpdateCrust(MCrust crust)
        {
            var updateCrust = context.Crusts.Where(x => x.CrustId == crust.Id).FirstOrDefault();
            if (updateCrust != null)
            {
                updateCrust.CrustId = (byte)crust.Id;
                updateCrust.CrustName = crust.Name;
                updateCrust.CrustPrice = crust.Price;

                context.Update(updateCrust);
                context.SaveChanges();


            }


        }

        public void DeleteCrust(int Id)
        {
            var crust = context.Crusts.Where(x => x.CrustId == Id).FirstOrDefault();
            if (crust != null)
            {
                context.Crusts.Remove(crust);
                context.SaveChanges();
            }
        }

        public void AddSize(Size size)
        {
            context.Add(size);
            context.SaveChanges();
        }

        public List<Size> GetSizes()
        {
            var sizes = context.PizzaSizes;
            return sizes.Select(mapper.Map).ToList();
        }

        public Size GetSizeByIndex(int Id)
        {
            var size = context.PizzaSizes.Where(x => x.PizzaSizeId == Id).FirstOrDefault();
            return mapper.Map(size);
        }

        public void UpdateSize(Size size)
        {
            var updateSize = context.PizzaSizes.Where(x => x.PizzaSizeId == size.Id).FirstOrDefault();
            if (updateSize != null)
            {
                updateSize.PizzaSizePrice = size.Price;
                updateSize.PizzaSizeName = size.Name;
                updateSize.PizzaSizeId = (byte)size.Id;

                context.Update(updateSize);
                context.SaveChanges();


            }
        }

        public void DeleteSize(int Id)
        {
            var size = context.PizzaSizes.Where(x => x.PizzaSizeId == Id).FirstOrDefault();
            if(size != null)
            {
                context.PizzaSizes.Remove(size);
                context.SaveChanges();
            }
        }

        public void AddToppings(Toppings toppings)
        {
            context.Add(mapper.Map(toppings));
            context.SaveChanges();
        }

        public void AddTopList(Toppings toppings)
        {
            context.Add(mapper.MapTop(toppings));
            context.SaveChanges();
        }

        public List<Toppings> GetToppings()
        {
            var toppings = context.Toppings;
            return toppings.Select(mapper.Map).ToList();
        }

        public List<Toppings> GetPizzaToppings()
        {
            var toppings = context.PizzaToppings;
            return toppings.Select(mapper.Map).ToList();
        }

        public List<Toppings> GetPizzaToppingsById(int PizzaId)
        { 
            return context.PizzaToppings.Where(x => x.PizzaId == PizzaId).Select(mapper.Map).ToList();
        }

        public Toppings GetPizzaToppingById(int toppingId)
        {
            return context.PizzaToppings.Where(x => x.PizzaToppingId == toppingId).Select(mapper.Map).FirstOrDefault();
        }

        public void UpdatePizzaTopping(Toppings toppings)
        {
            var updatePizzaTopping = context.PizzaToppings.Where(x => x.PizzaToppingId == toppings.Id).FirstOrDefault();
            if (updatePizzaTopping != null)
            {
                updatePizzaTopping.PizzaToppingId = toppings.PizzaToppingID;;
                updatePizzaTopping.PizzaId = toppings.PizzaID;
                updatePizzaTopping.ToppingId = (byte)toppings.Id;

                context.Update(updatePizzaTopping);
                context.SaveChanges();


            }
        }

        public Toppings GetToppingByIndex(int Id)
        {
            var topping = context.Toppings.Where(x => x.ToppingId == Id).FirstOrDefault();
            return mapper.Map(topping);
        }

        public void UpdateTopping(Toppings toppings)
        {
            var updateTopping = context.Toppings.Where(x => x.ToppingId == toppings.Id).FirstOrDefault();
            if (updateTopping != null)
            {
                updateTopping.ToppingPrice = toppings.Price;
                updateTopping.ToppingName = toppings.Name;
                updateTopping.ToppingId = (byte)toppings.Id;

                context.Update(updateTopping);
                context.SaveChanges();


            }
        }

        public void DeletePizzaToppingById(int toppingId)
        {
            var topping = context.PizzaToppings.Where(x => x.PizzaToppingId == toppingId).FirstOrDefault();
            if (topping != null)
            {
                context.PizzaToppings.Remove(topping);
                context.SaveChanges();
            }
        }

        public void DeleteToppingById(int toppingId)
        {
            var topping = context.Toppings.Where(x => x.ToppingId == toppingId).FirstOrDefault();
            if (topping != null)
            {
                context.Toppings.Remove(topping);
                context.SaveChanges();
            }
        }


        public int GetPizzaToppingCount()
        {
            int count = context.PizzaToppings.Count();
            return count;
        }

        public int GetPizzaCount()
        {
            int count = context.Pizzas.Count();
            return count;
        }

        

       

        
    }

}
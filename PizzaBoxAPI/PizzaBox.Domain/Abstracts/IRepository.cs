using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
    public interface IRepository
    {
        

        void AddPizza(CustomPizza pizza);
        CustomPizza GetPizzaByIndex(int Id);

        void UpdatePizza(CustomPizza pizza);

        void DeletePizza(int Id);

        List<MCustomer> GetUserAndPass();

        List<MCustomer> GetCustomers();

        public List<MOrder> GetAllOrders();

        void AddCustomer(MCustomer customer);
        void AddOrder(MOrder order);

        void AddToppings(Toppings toppings);

        List<Store> GetStores();

        Store GetStoreByIndex(int Id);

        List<MCrust> GetPizzaCrusts();

        MCrust GetCrustByIndex(int Id);

        List<Size> GetSizes();

        Size GetSizeByIndex(int Id);

        List<Toppings> GetToppings();

        Toppings GetToppingByIndex(int Id);

        int GetOrderCount();

        int GetPizzaCount();

        int GetPizzaToppingCount();
        public List<CustomPizza> GetPizzasOrders();

        public MCustomer GetCustomerById(int Id);
        MOrder GetOrderById(int id);

        void UpdateOrder(MOrder order);

        void DeleteOrder(int Id);

        void UpdateCrust(MCrust crust);

        void DeleteCrust(int Id);

        void DeleteCustomer(int Id);

        void AddCrust(MCrust crust);

        void UpdateCustomer(MCustomer customer);

        void AddSize(Size size);

        void AddTopList(Toppings toppings);

        List<Toppings> GetPizzaToppings();

        List<Toppings> GetPizzaToppingsById(int PizzaId);

        void UpdatePizzaTopping(Toppings toppings);

        Toppings GetPizzaToppingById(int toppingId);

        void DeletePizzaToppingById(int toppingId);

        void DeleteToppingById(int toppingId);

        void UpdateTopping(Toppings toppings);

        void UpdateSize(Size size);

        void DeleteSize(int Id);

        List<CustomPizza> GetPizzaOrdersById(int Id);

        CustomPizza GetPizzaOrderById(int Id);



        //bool AddOrderToDb(MOrder order);


    }
}
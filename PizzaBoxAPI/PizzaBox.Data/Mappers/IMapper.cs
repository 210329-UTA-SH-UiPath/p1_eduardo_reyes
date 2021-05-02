

using System;

namespace PizzaBox.Data
{

    public interface IMapper
    {
        PizzaBox.Domain.Models.MOrder Map(Entity.Order pizza);

        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.Pizza pizza);

        PizzaBox.Domain.Models.MCustomer Map(PizzaBox.Data.Entity.Customer info);

        PizzaBox.Domain.Models.Store Map(PizzaBox.Data.Entity.Store store);

        PizzaBox.Domain.Models.MCrust Map(PizzaBox.Data.Entity.Crust crust);

        PizzaBox.Domain.Models.Size Map(PizzaBox.Data.Entity.PizzaSize size);

        PizzaBox.Domain.Models.Toppings Map(PizzaBox.Data.Entity.PizzaTopping topping);

        PizzaBox.Domain.Models.CustomPizza Map(PizzaBox.Data.Entity.Specialty pizza);

        PizzaBox.Domain.Models.Toppings Map(Entity.Topping topping);

        PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.MOrder order);

        PizzaBox.Data.Entity.Customer Map(PizzaBox.Domain.Models.MCustomer customer);

        PizzaBox.Data.Entity.Pizza Map(PizzaBox.Domain.Models.CustomPizza pizza);

        PizzaBox.Data.Entity.PizzaTopping Map(PizzaBox.Domain.Models.Toppings toppings);

        PizzaBox.Data.Entity.Topping MapTop(PizzaBox.Domain.Models.Toppings toppings);

        //PizzaBox.Data.Entity.Order Map(PizzaBox.Domain.Models.CustomPizza pizza);



    }

}
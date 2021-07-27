using MyProject.EfStuff.Model;

namespace MyProject.Service
{
    public interface IMenuService
    {
        DishInOrder CreateDishInOrder(Dish dish, Size size);
    }
}
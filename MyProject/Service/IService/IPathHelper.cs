namespace MyProject.Service
{
    public interface IPathHelper
    {
        string GetPathToCarouselFolder();
        string GetPathToAvatarFolder();
        string GetPathToAvatarByUser(long id);
        string GetAvatarUrlByUser(long id);
        string GetPathToFoodFolder();
        string GetPathToFoodByDishId(long id);
        string GetDishUrlByDish(long id);
    }
}
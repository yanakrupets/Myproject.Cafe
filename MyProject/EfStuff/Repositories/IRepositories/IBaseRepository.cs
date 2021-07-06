using MyProject.EfStuff.Model;

namespace MyProject.EfStuff.Repositories
{
    public interface IBaseRepository<ModelType> where ModelType : BaseModel
    {
        public ModelType Get(long id);
        public void Save(ModelType model);
    }
}
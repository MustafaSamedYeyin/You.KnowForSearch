
namespace TabSpace
{
    public interface ITabService
    {
        Task<Tab> Add(Tab entity);
        Task<bool> Delete(int id);
        Task<Tab> Update(Tab entity);
        Task<Tab> GetById(int id);
        Task<IEnumerable<TabDto>> GetAll();
    }
}

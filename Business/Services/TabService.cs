namespace TabSpace
{
    public class TabService : ITabService
    {
        public ITabRepository _tab { get; set; }
        public TabService(ITabRepository tab)
        {
            _tab = tab;
        }

        public async Task<Tab> Add(Tab entity)
        {
            return await _tab.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _tab.Delete(id);
        }

        public async Task<Tab> Update(Tab entity)
        {
            return await _tab.Update(entity);
        }

        public async Task<Tab> GetById(int id)
        {
            return await _tab.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TabDto>> GetAll()
        {
            var result = await _tab.GetAllAsync();
            return result.Where(i=> i.IsActive == true).OrderBy(i=> i.Sort).Select(i => new TabDto()
            {
                Id = i.Id,
                Name = i.Name
            }).ToList();
        }
    }
}
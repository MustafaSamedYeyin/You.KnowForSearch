using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabSpace;

namespace Data.Repositories.Context.ModelConfiguration
{

    public class MainTabsConfiguration : IEntityTypeConfiguration<Tab>
    {
        public void Configure(EntityTypeBuilder<Tab> builder)
        {
            builder.HasKey(x => x.Id);

            var data = Enum.GetValues(typeof(MainTabs))
                   .OfType<MainTabs>().Select((x, next) => new Tab()
                   {
                       Id = next + 1,
                       CreateTime = DateTime.MinValue,
                       Name = x.ToString(),
                       IsFocus = false,
                       Sort = (int)x,
                       UpdateTime = DateTime.MinValue
                   })
                   .ToList();

            builder.HasData(data);
        }
    }
}

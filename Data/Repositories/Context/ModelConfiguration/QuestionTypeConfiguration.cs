using QuestionSpace;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Context.ModelConfiguration
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.HasData(Enum.GetValues(typeof(QuestionTypeEnum))
                   .OfType<QuestionTypeEnum>().Select((x, next) => new QuestionType()
                   {
                       Id = next + 1,
                       CreateTime = DateTime.MinValue,
                       Type = x,
                       UpdateTime = DateTime.MinValue,
                       IsActive = true
                   })
                   .ToList());
        }
    }
}

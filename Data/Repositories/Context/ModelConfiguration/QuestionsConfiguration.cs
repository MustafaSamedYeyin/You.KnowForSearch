using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionSpace;

namespace Data.Repositories.Context.ModelConfiguration
{
    public class QuestionsConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            var id = 1;
            var sort = 1;
            var questions = new Question[]
            {
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Google {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Why MySolution Not Working For This {0}, {1} {2} ?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How To Troublos hout {0}, {1} {2} ?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " What is {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " DeepSeek {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Who crated {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " History Of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Examples of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Why Exist {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Decide when to use {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " OnlineCommunities {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Why need {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " When To Use {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " When Not To Use {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How to learn {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How Its Working {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How To Try {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Critise {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Implement {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Explain With 150 Chars {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Explain 450 Chars {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " List Keywords To Learn {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " List Keywords To Learn With Practice {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Differentiate with {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Examples And How To Improve Them {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Beginner Guide {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Example In Action {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Common Mistakes {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Where Can I Find Mentors {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Disadvantages Of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Advantages Of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Problem Of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " List Trusted Site {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Trade Of {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Youtube Search {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How Is Used In RealLife {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Common Use Cases {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Best Youtube Channel {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Example That Already And How To Improve Them {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " How To Explain For Business Man As Programmer {0}, {1}?"} ,
                new  Question() { Id = id++,Sort = sort++,QuestionFormat = " Example For Dummies {0}, {1}?"}
            };

            builder.HasData(questions); ;
        }
    }
}

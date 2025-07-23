using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace ElasticSearchSpace
{
    public class ElasticsearchDto<T> where T : class
    {
        public ElasticsearchDto()
        {
            
        }
        public ElasticsearchDto(T data)
        {
            Data = data;
            var splited = typeof(T).ToString().Split('.').Length;
            Index = typeof(T).ToString().Split('.')[splited-1].ToLower();
            CreateTime = DateTime.Now;
        }

        public Guid Keyword { get; set; }  = Guid.NewGuid();
        public string Index { get; set; }
        public DateTime CreateTime { get; set; } 
        public DateTime UpdateTime { get; set; }
        public ElasticEnums Tab { get; set; }
        public T Data { get; set; }
    }
}

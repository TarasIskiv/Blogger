using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
namespace Domain.Entities
{
    public class Post : AuditableEntity
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Content { get; set; }

        public Post()
        {
             
        }

        public Post(int id, string tittle, string content)
        {
            Id = id;
            Tittle = tittle;
            Content = content;
        }
    }
}

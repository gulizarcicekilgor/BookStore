using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int GenreId { get; set; }
         public Genre Genre { get; set; }  //book ve genre arasındaki ilişki foreign key
         public int AuthorId { get; set; }
         public Author Author { get; set; }  //book ve author arasındaki ilişki foreign key
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
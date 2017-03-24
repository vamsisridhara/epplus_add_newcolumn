using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KoCart.Models
{
  public class Book
  {
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public string Synopsis { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public virtual Author Author { get; set; }
  }

  public class Author
  {
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Biography { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}
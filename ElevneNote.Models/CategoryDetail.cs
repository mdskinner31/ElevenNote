using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevneNote.Models
{
   public class CategoryDetail
    {
       // [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // public int NoteId { get; set; }

        // public string Title { get; set; }

        //  public string Content { get; set; }

        //  public DateTimeOffset CreatedUtc { get; set; }

        // private string category;

        //public string GetCategory()
        //{
        //    return category;
        //}

        //public void SetCategory(string value)
        //{
        //    category = value;
        //}
    }
}

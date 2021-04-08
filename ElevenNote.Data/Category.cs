using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
   public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //private string category;

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

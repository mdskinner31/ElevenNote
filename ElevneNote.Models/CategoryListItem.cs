﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevneNote.Models
{
    public class CategoryListItem
    {
        //public int NoteId { get; set; }
        //public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       // [Display(Name = "Created")]
       // public DateTimeOffset CreatedUtc { get; set; }
    }
}

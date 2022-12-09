﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Models
{
    public class BookCategory : Entity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

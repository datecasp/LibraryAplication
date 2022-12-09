using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Models
{
    public class BookUser : Entity
    {
        /***************************************
         * 
         * This class represents a manually defined entity for 
         * N to M relation betwen Users and Books.
         * A user can have multiple books, and a book can have 
         * multiple users (actual user and old users)
         * Actual users are marked with ActualUser boolean flag
         * as true and old users are marked as false
         * 
         **************************************/
     
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        //Flag for actual user identification
        public bool ActualUser { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateClosed { get; set; }

        public int CustomerId { get; set; }
        public int TtypeId { get; set; }
        public int PriorityId { get; set; }

        public Customer Customer { get; set; }
        public Priority Priority { get; set; }
        public Ttype Ttype { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

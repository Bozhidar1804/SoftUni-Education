using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; } = null!;
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        public Guid UserId { get; set; }
        public virtual ApplicationUser User {  get; set; } = null!;
    }
}

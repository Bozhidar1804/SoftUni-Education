namespace CinemaApp.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!; // Could also be null

        public string? ImageUrl { get; set; }

        // Navigatio property for many-to-many relationship with Cinema
        public virtual ICollection<CinemaMovie> MovieCinemas { get; set; } = new HashSet<CinemaMovie>();

        public virtual ICollection<ApplicationUserMovie> MovieApplicationUsers { get; set; } = new HashSet<ApplicationUserMovie>();

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}

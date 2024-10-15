using GameZone.Data;

namespace GameZone.Models
{
    public class GameEditViewModel
    {
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ReleasedOn { get; set; }
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}

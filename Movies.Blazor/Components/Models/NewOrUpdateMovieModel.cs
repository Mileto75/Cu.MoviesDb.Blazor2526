namespace Movies.Blazor.Components.Models
{
    public class NewOrUpdateMovieModel
    {
        public int Id  { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int CompanyId { get; set; }
    }
}

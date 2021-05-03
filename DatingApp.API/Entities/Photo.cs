using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        
        // public photo storage
        public string PhotoId { get; set; }

        // fully defined relationship & once done, update migrations
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}
using System;
using System.Collections.Generic;

namespace DatingApp.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Intro { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // EF relationships : 1 to many  - 1 user to many photos
        // use cascade delete so when a user is deleted, the photos along with the user is deleted
        // fully define relationship between AppUser & Photo
        // we define AppUser in Photo entity
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
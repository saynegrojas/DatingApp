using System;
using System.Collections.Generic;
// using DatingApp.API.Extensions;

namespace DatingApp.API.Entities
{
    public class AppUser
    {
        // prop - create auto implemented property - have getters and setters to get value and set value of this prop inside class

        // return value int call it Id
        public int Id { get; set; }

        // return string name Name
        public string Name { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        // Using Extension Method to extend DateTime
        public DateTime DateOfBirth { get; set; }

        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
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
        public ICollection<Photo> Photos { get; set; }


        // Extension Method
        // get age by extending DateTime to calculate the age of the user
        // public int GetAge() {
        //     return DateOfBirth.CalculateAge();
        // }
    }
}
// need to tell entity framework about this entity 'AppUser' so that it can scaffold our db and create a table for this class
// create a DATA CONTEXT class
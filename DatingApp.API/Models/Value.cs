namespace DatingApp.API.Models
{
    public class Value
    {
        // create two properties 
        // prop - create auto implemented property - have getters and setters to get value and set value of this prop inside class

        // return value int call it Id
        public int Id { get; set; }

        // return string name Name
        public string Name { get; set; }
    }
}
// need to tell entity framework about this entity 'Value' so that it can scaffold our db and create a table for this class
// create a DATA CONTEXT class
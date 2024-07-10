namespace SampleWebAPi.Models.Entities
{
    public class Employee
    {
        //here inside the models>enitites folder i will be writing a class which will act as an object which will help us in interacting with the database
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailAddress {  get; set; }

        public string PhoneNumber {  get; set; }

        public decimal Salary {  get; set; }
    }
}

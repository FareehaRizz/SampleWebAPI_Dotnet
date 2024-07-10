namespace SampleWebAPi.Models
{
    public class UpdateEmployeeDTO
    {
        //not dealignwith the id here because the entity framework handles it
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }

    }
}

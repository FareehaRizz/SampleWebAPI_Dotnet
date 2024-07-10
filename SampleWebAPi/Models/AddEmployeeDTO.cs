namespace SampleWebAPi.Models
{
    public class AddEmployeeDTO
    {
        //has only the necessary amout of info from entity
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }
    }
}

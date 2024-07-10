using Microsoft.AspNetCore.Mvc;
using SampleWebAPi.Data;
using SampleWebAPi.Models.Entities;
using SampleWebAPi.Models;


namespace SampleWebAPi.Controllers
{
    //making a contrller which will handle all the CRUD operations and im using HTTP methods for that
    //making an API for performng CRUD operations by using HTTP methods
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        //making a constructor for this class
        //making a private field for the db context so that i can use it in different parts of my application
        private readonly ApplicationDBContext dbContext;
        public EmployeeController(ApplicationDBContext dBContext)
        {
            this.dbContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var AllEmployees = dbContext.Employees.ToList();
            return Ok(AllEmployees);

        }
        //making a get method to fetch a particular employee from the database
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeByID(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        //in order to use the post verb to add a new user in the databse from the user i will be using DTOs , which will carry my desured amount of data between the methods of my api
        //DTOs are different from entities because they are what we use to show a certain amount of info from DB but entites are real images of the db
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {

            //first its important to convert the dtos into entities, here i will not be dealing with the id because its already dealt with by the entity framework core
            var EmployeeEntity = new Employee()
            {
                Name = addEmployeeDTO.Name,
                EmailAddress = addEmployeeDTO.EmailAddress,
                PhoneNumber = addEmployeeDTO.PhoneNumber,
                Salary = addEmployeeDTO.Salary

            };
            //here it s important to use the saveChanges method, because in this way only new employee will be added to my table
            dbContext.Employees.Add(EmployeeEntity);
            dbContext.SaveChanges();

            return Ok(EmployeeEntity);
        }
        //using http post for performing update operation
        [HttpPut]
        [Route("{id}")]
        //here its important to use the updateemployeedto for selecting certain columns from the databse entity
        public IActionResult UpdateEmployee(int id,UpdateEmployeeDTO updateEmployee)
        {
            var employee= dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployee.Name;
            employee.EmailAddress = updateEmployee.EmailAddress;
            employee.PhoneNumber = updateEmployee.PhoneNumber;
            employee.Salary = updateEmployee.Salary;

            dbContext.SaveChanges();
            return Ok(employee);

        }
        //now performing the Delete operation from CRUD by defining the http delete method
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee=dbContext.Employees.Find(id);
            if (employee == null) { 
            return NotFound();
            }
            dbContext.Employees.Remove(employee);
            return Ok();

        }
        

    }
}

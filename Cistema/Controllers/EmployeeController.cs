using Cistema.Models;
using Cistema.Models.DTO;
using Cistema.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var obj = await _employeeRepository.GetAll();
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var obj = await _employeeRepository.GetById(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add([FromBody] EmployeeCreateDTO employeeDto)
        {
            
            if (employeeDto == null)
                return BadRequest();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var employee = new Employee()
            {
                FullName = employeeDto.FullName,
                CPF = employeeDto.CPF,
                RG = employeeDto.RG,
                DateOfBirth = employeeDto.DateOfBirth,
                Gender = employeeDto.Gender,
                MaritalStatus = employeeDto.MaritalStatus,
                Nationality = employeeDto.Nationality,
                BirthPlace = employeeDto.BirthPlace,
                Admission = employeeDto.Admission,
                Contract = employeeDto.Contract,
                Salary = employeeDto.Salary,
                CTPS = employeeDto.CTPS,
                PIS = employeeDto.PIS,
                Active = true,
                Creator = "Sistema"
            };
            
            var obj = await _employeeRepository.Add(employee);

            return Ok(obj);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmployeeUpdateDTO employeeDto)
        {
            var employee = await _employeeRepository.GetEntityById(id);
            if (employee == null)
                return NotFound();

            employee.FullName = employeeDto.FullName;
            employee.RG = employeeDto.RG;
            employee.Gender = employeeDto.Gender;
            employee.MaritalStatus = employeeDto.MaritalStatus;
            employee.Nationality = employeeDto.Nationality;
            employee.BirthPlace = employeeDto.BirthPlace;
            employee.CTPS = employeeDto.CTPS;
            employee.PIS = employeeDto.PIS;

            if (employeeDto.Contract != null)
            {
                employee.Admission = employeeDto.Admission.Value;
                employee.Salary = employeeDto.Salary.Value;
                employee.CTPS = employeeDto.CTPS;
                employee.PIS = employeeDto.PIS;
                employee.Active = employeeDto.Active.Value;
            }

            employee.LastUpdate = DateTime.UtcNow;

            await _employeeRepository.Update(employee);

            return Ok(employee);
        }
    }
}
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using static Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public EmployeesController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        //[HttpGet]
        //public IActionResult GetEmployeesForCompany(Guid companyId)
        //{
        //    var employees = _serviceManager.EmployeeService.GetEmployees(companyId, trackChanges: false);
        //    return Ok(employees);
        //}
        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            var employees = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);
            return Ok(employees);
        }

        //[HttpGet("{id:guid}", Name ="GetEmployeeForCompany")]
        //public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        //{
        //    var employee = _serviceManager.EmployeeService.GetEmployee(companyId, id,
        //    trackChanges: false);
        //    return Ok(employee);
        //}
        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee =await _serviceManager.EmployeeService.GetEmployeeAsync(companyId, id,
            trackChanges: false);
            return Ok(employee);
        }
        //[HttpPost]
        //public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        //{
        //    if (employee is null)
        //        return BadRequest("EmployeeForCreationDto object is null");

        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);

        //    var employeeToReturn = _serviceManager.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges:false);

        //    return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var employeeToReturn = await _serviceManager.EmployeeService.CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }
        //[HttpDelete("{id:guid}")]
        //public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
        //{
        //    _serviceManager.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges:false);
        //    return NoContent();
        //}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _serviceManager.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, trackChanges: false);
            return NoContent();
        }
        //[HttpPut("{id:guid}")]
        //public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        //{
        //    if (employee is null)
        //        return BadRequest("EmployeeForUpdateDto object is null");
        //    if(!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
        //    _serviceManager.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges:false, empTrackChanges:true);
        //    return NoContent();
        //}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
           await _serviceManager.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);
            return NoContent();
        }
        //[HttpPatch("{id:guid}")]
        //public IActionResult PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        //{
        //    if (patchDoc is null)
        //        return BadRequest("patchDoc object send from client is null.");
        //    var result = _serviceManager.EmployeeService.GetEmployeeForPatch(companyId, id, compTrackChanges: false, empTrackChanges: true);
        //    patchDoc.ApplyTo(result.employeeToPatch);
        //    TryValidateModel(result.employeeToPatch);
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
        //    _serviceManager.EmployeeService.SaveChangesForPatch(result.employeeToPatch, result.employeeEntity);
        //    return NoContent();
        //}
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object send from client is null.");
            var result = await _serviceManager.EmployeeService.GetEmployeeForPatchAsync(companyId, id, compTrackChanges: false, empTrackChanges: true);
            patchDoc.ApplyTo(result.employeeToPatch);
            TryValidateModel(result.employeeToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _serviceManager.EmployeeService.SaveChangesForPatch(result.employeeToPatch, result.employeeEntity);
            return NoContent();
        }
    }
}

using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployees.Presentation.ModelBinders;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]

    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service;

        //[HttpGet]
        //public IActionResult GetCompanies()
        //{
        //    var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
        //    return Ok(companies);
        //}

        /// <summary>
        /// Gets the list of all companies
        /// </summary>
        /// <returns>The companies list</returns>

        [HttpGet(Name = "GetCompanies")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await
            _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }


        //[HttpGet("{id:guid}", Name="CompanyById")]
        //public IActionResult GetCompany(Guid id)
        //{
        //    var company = _service.CompanyService.GetCompany(companyId: id, trackChanges:false);
        //    return Ok(company);
        //}

        [HttpGet("{id:guid}", Name = "CompanyById")]
        //[ResponseCache(Duration = 60)]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }


        //[HttpPost]
        //public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        //{
        //    if (company is null)
        //        return BadRequest("CompanyForCreationDto object is null");
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
        //    var createdCompany = _service.CompanyService.CreateCompany(company);
        //    return CreatedAtRoute("CompanyById", new {id=createdCompany.Id}, createdCompany);
        //}

        /// <summary>
        /// Creates a newly created company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>A newly created company</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]

        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            //if (company is null)
            //    return BadRequest("CompanyForCreationDto object is null");
            //if (!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);
            var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id },
            createdCompany);
        }

        //[HttpGet("collection/({ids})", Name = "CompanyCollection")]
        //public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids) 
        //{
        //    var companies = _service.CompanyService.GetByIds(ids, trackChanges: false);
        //    return Ok(companies);
        //}
        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges:
            false);
            return Ok(companies);
        }


        //[HttpPost("collection")]
        //public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        //{
        //    var result = _service.CompanyService.CreateCompanyCollection(companyCollection);
        //    return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        //}
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result = await
            _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids },
            result.companies);
        }

        //[HttpDelete("{id:guid}")]
        //public IActionResult DeleteCompany(Guid id)
        //{
        //    _service.CompanyService.DeleteCompany(id, trackChanges: false);
        //    return NoContent();
        //}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
            return NoContent();
        }

        //[HttpPut("{id:guid}")]
        //public IActionResult UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        //{
        //    if (company is null)
        //        return BadRequest("CompanyForUpdateDto Object is null");
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
        //    _service.CompanyService.UpdateCompany(id, company, trackChanges: true);
        //    return NoContent();
        //}
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto Object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            _service.CompanyService.UpdateCompany(id, company, trackChanges: true);
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }

    }
}

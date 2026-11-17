
using JobTracker.Api.DTOs;
using JobTracker.Application.Interfaces;
using JobTracker.Application.Services;
using JobTracker.Application.UseCases.Companies;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly CreateCompany _createCompany;
    private readonly RandomCompanyGenerator _generator;
    private readonly GetCompanyById _getCompanyById;
    private readonly GetAllCompanies _getAllCompanies;
    private readonly UpdateCompany _updateCompany;

    public CompaniesController(
        CreateCompany createCompany,
        RandomCompanyGenerator generator,
        GetCompanyById getCompanyById,
        GetAllCompanies getAllCompanies,
        UpdateCompany updateCompany)
    {
        _createCompany = createCompany;
        _generator = generator;
        _getCompanyById = getCompanyById;
        _getAllCompanies = getAllCompanies;
        _updateCompany = updateCompany;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCompanyRequest request)
    {
        var id = await _createCompany.ExecuteAsync(
            request.Name,
            request.Website);

        return StatusCode(201, new { id });
    }

    [HttpPost("random")]
    public async Task<IActionResult> CreateRandom()
    {
        var (name, website) = _generator.Generate();

        var id = await _createCompany.ExecuteAsync(
            name,
            website);

        return StatusCode(201, new { id, name, website });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companies = await _getAllCompanies.ExecuteAsync();

        return Ok(companies);
    }


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var company = await _getCompanyById.ExecuteAsync(id);

        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCompanyRequest request)
    {
        var updated = await _updateCompany.ExecuteAsync(
            id,
            request.Name,
            request.Website
        );

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

}

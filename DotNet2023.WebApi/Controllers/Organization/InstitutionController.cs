﻿using AutoMapper;
using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.DtoModels.Organization;
using DotNet2023.WebApi.Interfaces.Organization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Organization;

[Route("api/[controller]")]
[ApiController]
public class InstitutionController : Controller
{
    private readonly IHigherEducationInstitution _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<HigherEducationInstitution> _logger;

    public InstitutionController(IHigherEducationInstitution repository,
        IMapper mapper, ILogger<HigherEducationInstitution> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all Institutions
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet]
    public IEnumerable<HigherEducationInstitutionDto> GetInstitutions() =>
        _mapper
            .Map<List<HigherEducationInstitutionDto>>
            (_repository.GetInstitutions());
    /// <summary>
    /// Async Get all Institutions
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet("GetInstitutionsAsync")]
    public async Task<IEnumerable<HigherEducationInstitutionDto>> GetInstitutionsAsync() =>
        _mapper
            .Map<List<HigherEducationInstitutionDto>>
            (await _repository.GetInstitutionsAsync());


    /// <summary>
    /// Get Institution by id
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet("GetInstitution")]
    public HigherEducationInstitutionDto GetInstitution(string idInstitution) =>
        _mapper
            .Map<HigherEducationInstitutionDto>
            (_repository.GetInstitution(idInstitution));

    /// <summary>
    /// Async Get Institution by id
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet("GetInstitutionAsync")]
    public async Task<HigherEducationInstitutionDto>? GetInstitutionAsync(
        string idInstitution) =>
        _mapper.Map<HigherEducationInstitutionDto>(await _repository
            .GetInstitutionAsync(idInstitution));

    /// <summary>
    /// Create a new institution
    /// </summary>
    /// <param name="institution">new institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateInstructon")]
    public IActionResult CreateInstitution(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        var institutionMap = _mapper
            .Map<HigherEducationInstitution>(institution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateInstructon(institutionMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }
    /// <summary>
    /// Async Create a new institution
    /// </summary>
    /// <param name="institution">new institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateInstructonAsync")]
    public async Task<IActionResult> CreateInstitutionAsync(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        var institutionMap = _mapper
            .Map<HigherEducationInstitution>(institution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateInstructonAsync(institutionMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }


    /// <summary>
    /// Delete by id Institution
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteInstructon")]
    public IActionResult DeleteInstitution(string idInstitution)
    {
        if (!_repository.InstitutionExists(idInstitution))
            return NotFound();

        var institutionToDelete = _repository
            .GetInstitution(idInstitution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || institutionToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteInstructon(institutionToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Async Delete by id Institution
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteInstructonAsync")]
    public async Task<IActionResult> DeleteInstitutionAsync(string idInstitution)
    {
        if (!await _repository.InstitutionExistsAsync(idInstitution))
            return NotFound();

        var institutionToDelete = _repository
            .GetInstitution(idInstitution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || institutionToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteInstructonAsync(institutionToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="institution">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateInstitution")]
    public IActionResult UpdateInstitution(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        if (!_repository.InstitutionExists(institution.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<HigherEducationInstitution>(institution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateInstructon(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
    /// <summary>
    /// Async Update model
    /// </summary>
    /// <param name="institution">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateInstitutionAsync")]
    public async Task<IActionResult> UpdateInstitutionAsync(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        if (!await _repository.InstitutionExistsAsync(institution.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<HigherEducationInstitution>(institution);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.UpdateInstructonAsync(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
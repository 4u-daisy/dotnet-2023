﻿using DotNet2023.Domain.Organization;
using System.ComponentModel.DataAnnotations;

namespace DotNet2023.Domain.InstituteDocumentation;

/// <summary>
/// An intermediate class for implementing the "many-to-many" connection. 
///     Institutes and specialties.
/// <param name="Key">Key</param>
/// <param name="IdSpeciality">Id Speciality</param>
/// <param name="Speciality">Speciality</param>
/// <param name="IdHigherEducationInstitution">Id Higher Education Institution</param>
/// <param name="HigherEducationInstitution">Higher Education Institution</param>
/// </summary>
public class InstituteSpeciality
{
    public InstituteSpeciality()
    {
        Key = new Guid().ToString();
    }
    public InstituteSpeciality(string idSpeciality, string idInstitute)
    {
        Key = new string($"{idSpeciality}-{idInstitute}");
        IdSpeciality = idSpeciality;
        IdHigherEducationInstitution = idInstitute;
    }

    [Key]
    [Required]
    public string Key { get; set; } = new Guid().ToString();

    public string? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

    public string? IdHigherEducationInstitution { get; set; }
    public HigherEducationInstitution? HigherEducationInstitution { get; set; }
}

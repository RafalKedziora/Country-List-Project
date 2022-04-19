global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using FluentValidation;
global using Swashbuckle.AspNetCore.Annotations;
global using CountryListProjectAPI;
global using CountryListProjectAPI.Validators;

global using CountryListProjectAPI.Service;
global using CountryListProjectAPI.Repository;
global using CountryListProjectAPI.Entities;
global using CountryListProjectAPI.Data;

#region Dtos
global using CountryListProjectAPI.Dto.Country;
global using CountryListProjectAPI.Dto.GraphRoute;
#endregion
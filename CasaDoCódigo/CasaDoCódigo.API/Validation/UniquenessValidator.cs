using CasaDoCódigo.API.Models;
using CasaDoCodigo.Domain;
using CasaDoCodigo.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCódigo.API.Validation;

public class Uniqueness : ValidationAttribute
{
    private Type DomainType { get; set; }

    public Uniqueness(Type domainType)
    {
        DomainType = domainType;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var valueString = value == null ? null : value.ToString();

        if (string.IsNullOrWhiteSpace(valueString)) { return ValidationResult.Success; }

        using (IServiceScope scope = validationContext.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<CdcDBContext>();
            if (dbContext == null) {  return ValidationResult.Success; }

            var entity = dbContext.Model.GetEntityTypes().FirstOrDefault(x => x.ClrType == DomainType);
            if(entity is null) { return new ValidationResult("Entity type not found"); }

            string tableName = entity.GetTableName();

            var columnValue = new SqlParameter("columnValue", valueString);

            //para simplificar, tableName e validationContext.MemberName não tem risco de ataque de SQL Injection
            var foundRows = dbContext.Database.SqlQueryRaw<Guid>($"SELECT Id FROM {tableName} WHERE {validationContext.MemberName} = @columnValue", columnValue).ToList();
            
            if(foundRows is not null && foundRows.Count > 0) 
            {
                return new ValidationResult($"{valueString} is already being used");
            }
        }

        return ValidationResult.Success;
    }
}

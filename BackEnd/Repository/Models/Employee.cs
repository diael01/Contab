using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Employee
{
    public HierarchyId EmpNode { get; set; } = null!;

    public string? EmpNodeText { get; set; }

    public short? EmpLevel { get; set; }

    public HierarchyId ManagerNode { get; set; } = null!;

    public string? ManagerNodeText { get; set; }

    public HierarchyId EmployeeFunctionNode { get; set; } = null!;

    public string? EmployeeFunctionNodeText { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? CivilStatus { get; set; }

    public DateTime? HiringDate { get; set; }

    public DateTime? FirstHiringDate { get; set; }

    public string CountyCode { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public string? IdCardSerieNo { get; set; }

    public string? IdCardCnp { get; set; }

    public string? Bank1Code { get; set; }

    public string? Bank1Iban { get; set; }

    public int? LunchTickets { get; set; }

    public bool? AvansOrLiquidaton { get; set; }

    public int? YearSeniority { get; set; }

    public int? MonthSeniority { get; set; }

    public bool? Insured { get; set; }

    public string? Insurance { get; set; }

    public DateTime? LastIdCardCreationDate { get; set; }

    public string? Studies { get; set; }

    public string? Bank2Code { get; set; }

    public string? Bank2Iban { get; set; }

    public bool? Retired { get; set; }

    public string? RetirementSeniority { get; set; }

    public int? RetirementSupplement { get; set; }

    public int? RetirementExclusionReason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}

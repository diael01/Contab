using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Employee
{
    public int Id { get; set; }

    public HierarchyId EmpNode { get; set; } = null!;

    public int EmpRecordChangeDay { get; set; }

    public string Name { get; set; } = null!;

    public string IdCardSerieNo { get; set; } = null!;

    public string IdCardCnp { get; set; } = null!;

    public DateTime LastIdCardCreationDate { get; set; }

    public decimal MainSalary { get; set; }

    public DateTime HiringDate { get; set; }

    public HierarchyId ManagerNode { get; set; } = null!;

    public string EmpShift { get; set; } = null!;

    public string CountyCode { get; set; } = null!;

    public short WorkGroup { get; set; }

    public short HoursToWork { get; set; }

    public short TypeWorkContract { get; set; }

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public HierarchyId EmpDeptNode { get; set; } = null!;

    public HierarchyId EmpActivityNode { get; set; } = null!;

    public HierarchyId EmpWorkTypeNode { get; set; } = null!;

    public HierarchyId EmpFunctionNode { get; set; } = null!;

    public bool Retired { get; set; }

    public string? EmpNodeAsText { get; set; }

    public string? EmpNodeAsName { get; set; }

    public short? EmpLevel { get; set; }

    public string? Phone { get; set; }

    public string? Surname { get; set; }

    public short? Category { get; set; }

    public string? EmpGradation { get; set; }

    public string? CivilStatus { get; set; }

    public decimal? MgmtSalaryIncrease { get; set; }

    public string? EndWorkCode { get; set; }

    public DateTime? EndWorkDate { get; set; }

    public decimal? WorkExperienceSalaryIncrease { get; set; }

    public DateTime? FirstJobHiringDate { get; set; }

    public string? Location { get; set; }

    public string? Bank1Code { get; set; }

    public string? Bank1Iban { get; set; }

    public short? LunchTickets { get; set; }

    public bool? AvansOrLiquidaton { get; set; }

    public short? YearSeniority { get; set; }

    public short? MonthSeniority { get; set; }

    public bool? Insured { get; set; }

    public string? Insurance { get; set; }

    public string? Studies { get; set; }

    public string? Bank2Code { get; set; }

    public string? Bank2Iban { get; set; }

    public string? RetirementSeniority { get; set; }

    public short? RetirementSupplement { get; set; }

    public short? RetirementExclusionReason { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}

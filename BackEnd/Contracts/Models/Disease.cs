using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contracts.Models;

public partial class Disease
{
    public int Id { get; set; }

    public HierarchyId EmpNode { get; set; } = null!;

    public DateTime? EmpRecordChangeDate { get; set; }

    public int? CodeDisease { get; set; }

    public DateTime? StartDateofMedicalHoliday { get; set; }

    public int? NoDiseaseDayCalend { get; set; }

    public int? NoDiseaseDayWork { get; set; }

    public int? NoDiseaseDayWorkPaidByEmployer { get; set; }

    public int? NoDiseaseDayWorkPaidByGovt { get; set; }

    public decimal? NetSalaryOnTheLast12Months { get; set; }

    public decimal? NetSalaryPerDayOnTheLast12Months { get; set; }

    public int? NoWorkDaysPerLast12Months { get; set; }

    public int? NoCalendDaysPerLast12Months { get; set; }

    public DateTime? StartDateOfTheDisease { get; set; }

    public DateTime? EndDateOfTheDisease { get; set; }

    public bool? DiseaseIsInitialOrContinued { get; set; }

    public string? MedCertificateCode { get; set; }

    public string? MedCertificateSerie { get; set; }

    public string? MedCertificateNo { get; set; }

    public string? MedCertificateCodeContinue { get; set; }

    public string? MedCertificateSerieContinued { get; set; }

    public string? MedCertificateNumberContinued { get; set; }

    public string? UrgencyCode { get; set; }

    public string? ContagiousCode { get; set; }

    public decimal? ChildCnp { get; set; }

    public string? DoctorLicenseNumber { get; set; }

    public DateTime? DateMedicalCertificate { get; set; }

    public int? LocationCode { get; set; }

    public int? DiagnosticCode { get; set; }

    public decimal? OtherPersonInCareCnp { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;
}

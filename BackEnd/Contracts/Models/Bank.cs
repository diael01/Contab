using System;
using System.Collections.Generic;

namespace Contracts.Models;

public partial class Bank
{
    public int Id { get; set; }

    public string? BankCode { get; set; }

    public string? Iban { get; set; }

    public string? Adress { get; set; }

    public bool? Branch { get; set; }
}

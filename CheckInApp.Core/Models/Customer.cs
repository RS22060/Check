namespace CheckInApp.Core.Models;

public class Customer
{
    public Guid CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public bool IsActive { get; set; }
}
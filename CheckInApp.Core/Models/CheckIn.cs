namespace CheckInApp.Core.Models;

public class CheckIn
{
    public Guid CheckInId { get; set; }

    public Guid CustomerId { get; set; }
    
    public virtual required Customer Customer { get; set; }

    public DateTime Date { get; set; }
}
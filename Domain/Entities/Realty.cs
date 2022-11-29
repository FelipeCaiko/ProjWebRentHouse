namespace Domain.Entities;

public sealed class Realty
{
    public int Id { get; set; }
    public Locator Locator { get; set; }
    public Address Address { get; set; }
    public string Description { get; set; }
}
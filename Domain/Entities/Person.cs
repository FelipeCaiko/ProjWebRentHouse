using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Telephone { get; set; }
}
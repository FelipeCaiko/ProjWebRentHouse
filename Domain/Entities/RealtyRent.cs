using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class RealtyRent
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public Realty Realty { get; set; }
    public string Description { get; set; }
    [NotMapped]
    public virtual List<SelectListItem> Clients { get; set; }
    [NotMapped]
    public virtual List<SelectListItem> Realties { get; set; }
}
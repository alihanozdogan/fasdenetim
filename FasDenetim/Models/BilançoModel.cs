using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FasDenetim.Models;

public class BilançoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Bilanço { get; set; }
    public string OncekiYıl { get; set; }
    public string CariYıl { get; set; }
    public string HesaplanmışVeri { get; set; }
}
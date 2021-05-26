using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class Client : Entity
    {
        [Required(ErrorMessage = "Le nom du client est requis.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le logo du client est requis.")]
        public string Logo { get; set; }
    }
}

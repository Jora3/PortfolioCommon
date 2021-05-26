using System.ComponentModel.DataAnnotations;

namespace PortfolioCommon.Data.Entities
{
    public class User : Entity
    {
        [Required(ErrorMessage = "L'identifiant de connexion est requis.")]
        [MinLength(4)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [MinLength(8)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PathPhoto { get; set; }
        public bool Active { get; set; }
    }
}

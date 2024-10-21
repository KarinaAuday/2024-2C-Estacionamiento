using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using _2024_2C_EstacionamientoORT.Helpers;

namespace _2024_2C_EstacionamientoORT.Models
{
    public class Rol : IdentityRole<int>
    {

        //Constructores
        public Rol() : base()
        {

        }

        public Rol(string name) : base(name)
        {

        }
        //puedo sacar ahora el Id pues ya va a heredar de identityRol
        // public int Id { get; set; }

        [Display(Name = Alias.RolName)]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }
    }
}

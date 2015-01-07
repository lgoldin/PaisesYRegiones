namespace Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PaisModel
    {
        public string Codigo { get; set; }

        [Display(Name = "Capital")]
        [Required(ErrorMessage = "La capital es obligatoria")]
        [StringLength(50, ErrorMessage = "La capital tiene que tener como maximo 50 caracteres")]
        public string Capital { get; set; }

        [Display(Name = "Prefijo Tel.")]
        [Required(ErrorMessage = "El prefijo tel. es obligatorio")]
        [StringLength(50, ErrorMessage = "El prefijo tel. tiene que tener como maximo 50 caracteres")]
        public string PrefijoTel { get; set; }

        [Display(Name = "Presidente")]
        [Required(ErrorMessage = "El presidente es obligatorio")]
        [StringLength(50, ErrorMessage = "El presidente tiene que tener como maximo 50 caracteres")]
        public string Presidente { get; set; }

        [Display(Name = "Himno")]
        [Required(ErrorMessage = "El himno es obligatorio")]
        [StringLength(100, ErrorMessage = "El himno tiene que tener como maximo 100 caracteres")]
        public string Himno { get; set; }

        [Display(Name = "Poblacion")]
        [RegularExpression(@"^[0-9]+([,][0-9]{1,2})*$", ErrorMessage = "El formato de la poblacion es incorrecto")]
        public double? Poblacion { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "La provincia es obligatoria")]
        [StringLength(50, ErrorMessage = "La provincia tiene que tener como maximo 50 caracteres")]
        public string Provincia { get; set; }

        [Display(Name = "Texto")]
        [Required(ErrorMessage = "El texto es obligatoria")]
        [StringLength(100, ErrorMessage = "El texto tiene que tener como maximo 100 caracteres")]
        public string Texto { get; set; }
    }
}
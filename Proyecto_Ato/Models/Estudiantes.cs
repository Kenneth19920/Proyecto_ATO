namespace Proyecto_Ato.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Estudiantes
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiantes()
        {

            this.Grupo = new HashSet<Grupo>();

        }

        [Key]
        public int IdEstudiante { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Nombre debe tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Primer Apellido es obligatorio.")]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Primer Apellido debe tener entre 2 y 50 caracteres.")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El campo Segundo Apellido debe tener entre 2 y 50 caracteres.")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo C�dula es obligatorio.")]
        [Display(Name = "C�dula")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "La C�dula debe tener 9 caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaNacimiento { get; set; }

        [Range(1, 150, ErrorMessage = "La Edad debe estar entre 1 y 150.")]
        public int Edad { get; set; }

        [Display(Name = "G�nero")]
        public string Genero { get; set; }

        [Display(Name = "Altura")]
        [DisplayFormat(DataFormatString = "{0:F2} Cm")]
        public decimal Altura { get; set; }

        [Display(Name = "Peso")]
        [DisplayFormat(DataFormatString = "{0} Kg")]
        public decimal Peso { get; set; }

        [Display(Name = "Direcci�n")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "La direcci�n debe ser Menor a 150 Caracteres.")]
        public string Direccion { get; set; }

        [RegularExpression(@"^\d{8,12}$", ErrorMessage = "El n�mero de Tel�fono debe tener 8 o 12 d�gitos.")]
        [Display(Name = "Tel�fono")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El Correo no es una direcci�n de correo electr�nico v�lida.")]
        [Display(Name = "Correo electr�nico")]
        public string Correo { get; set; }

        [Display(Name = "Historial M�dico")]
        public string HistorialMedico { get; set; }

    


    public virtual AspNetUsers AspNetUsers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Grupo> Grupo { get; set; }

}

}

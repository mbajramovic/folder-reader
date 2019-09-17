using System;
using System.ComponentModel.DataAnnotations;

namespace FolderReader.Models
{
    public class FolderNumber
    {
        [Required(ErrorMessage = "Morate unijeti broj foldera.")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage="Broj foldera mora imati 6 cifara.")]
        public string FolderName { get; set; }
    }
}
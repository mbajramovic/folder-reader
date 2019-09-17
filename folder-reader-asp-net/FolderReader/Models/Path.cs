using System;
using System.ComponentModel.DataAnnotations;

namespace FolderReader.Models
{
    public class Path
    {
        [Required(ErrorMessage = "Morate unijeti putanju.")]
        public string PathName { get; set; }

        public Path()
        {
            
        }
        public Path(String pathName)
        {
            PathName = pathName;
        }
    }
}
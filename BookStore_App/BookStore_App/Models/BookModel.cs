using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Models
{
    public class BookModel
    {
        /*-----------------------------this properties are used in addnewbook.cshtml in the form using asp-for etc---------------*/
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a valid Title")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Enter a valid Author")]
        public String Author { get; set; }

        [Required(ErrorMessage = "Enter a valid Book category")]
        public String Categories { get; set; }

        [Required(ErrorMessage = "Enter total book pages")]
        [Display(Name ="Total Pages")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Enter book language")]
        public int LanguageId { get; set; }

        
        public String languageName { get; set; }

        [StringLength(100, MinimumLength = 30)]
        public String Description { get; set; }

        //generating a automatic datetime field in the view

       /* [DataType(DataType.DateTime)] 
        [Required(ErrorMessage ="Please field date and time")]
        [Display(Name ="Enter Date time")]
        public string myField {get;set;}*/

        

    }
}

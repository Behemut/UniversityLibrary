using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class BorrowDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Estado")]
        public string CurrentStatus { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Fecha de prestamo")]
        public DateTime LoanDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}"), Display(Name = "Fecha de retorno")]
        public DateTime ReturnDate { get; set; }
        //Get Date of Today for a  DateTime field DateTime.Now.Date 
    }
}

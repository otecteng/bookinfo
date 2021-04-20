using System;
using System.ComponentModel.DataAnnotations;
namespace review.Models
{
    public class Review
    {
        public int Id {get;set;}
        public String BookName {get; set;}
        public String Content {get;set;}
        [DataType(DataType.Date)]
        public DateTime ReviewDate {get;set;}
    }
}

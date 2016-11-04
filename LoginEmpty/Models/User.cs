using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace LoginEmpty.Models
{
    public class User
    {
        
        [Key]
        [Required(ErrorMessage ="please input your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please input your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Sex { get; set; }
        
        //[Range(typeof(decimal),"0.0","100")]
        public DateTime Time { get; set; }
    }
}
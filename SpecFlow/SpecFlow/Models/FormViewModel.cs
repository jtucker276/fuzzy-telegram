using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpecFlow.Models
{
    public class FormViewModel
    {
        public int ID { get; set; }

        public bool Editable { get; set; } = false;

        [Required, StringLength(10, ErrorMessage = "Name must not be greater than 10 characters")]
        public string Name { get; set; }

        [Required, StringLength(20, ErrorMessage = "Description must not be greater than 20 characters")]
        public string Description { get; set; }

        [Required]
        public FormSelection EnumSelection { get; set; }
    }

    public enum FormSelection
    {
        FirstSelection,
        SecondSelection,
        ThirdSelection
    }
}
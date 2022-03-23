using System;
using System.ComponentModel.DataAnnotations;

namespace InMemoryDbAspNet6WebAPI;
public class Employee
{
    public int Id { get; set; }

    [Required]
    public string FName { get; set; }

    [Required]
    public string LName { get; set; }

    [EmailAddress(ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateOfHire { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateOfBirth { get; set; }

    public string Position { get; set; }

    public string Department { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zipcode { get; set; }
}

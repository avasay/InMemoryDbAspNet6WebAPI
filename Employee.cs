
using System.ComponentModel.DataAnnotations;

namespace InMemoryDbAspNet6WebAPI;
public class Employee
{
    public int Id { get; set; }

    [Required]
    public string fName { get; set; }

    [Required]
    public string lName { get; set; }

    public int age { get; set; }

    public string address { get; set; }

    public string city { get; set; }

    public string state { get; set; }

    public string zipcode { get; set; }
}

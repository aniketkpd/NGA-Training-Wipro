using System;
using System.Collections.Generic;

namespace CRUD_via_Scaffold_DbFirst.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Address { get; set; }
}

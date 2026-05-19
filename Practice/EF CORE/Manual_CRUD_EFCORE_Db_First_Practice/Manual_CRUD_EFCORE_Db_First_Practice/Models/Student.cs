using System;
using System.Collections.Generic;

namespace Manual_CRUD_EFCORE_Db_First_Practice.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Branch { get; set; }

    public int Rollno { get; set; }

    public string? Email { get; set; }
}

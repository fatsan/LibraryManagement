using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI;

public record Author(
    int Id,
    string Name,
    string Surname
    );
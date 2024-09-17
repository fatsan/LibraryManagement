using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI;

public record Book(
    int Id,
    string Title,
    string Description,
    int PageSize,
    string PublishDate,
    string ISBN
    );
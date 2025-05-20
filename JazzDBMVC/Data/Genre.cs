using System;
using System.Collections.Generic;

namespace JazzDBMVC.Data;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public string? GenreBlurb { get; set; }
}

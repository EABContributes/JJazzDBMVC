using System;
using System.ComponentModel.DataAnnotations;

namespace JazzDBMVC.Models
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; } = null!;

        [Display(Name = "Album Image URL")]
        public string AlbumImageUrl { get; set; } = null!;

        [Display(Name = "Label Name")]
        public string? LabelName { get; set; }

        public string? Copyrights { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(280)]
        public string? AlbumBlurb { get; set; }

        [Display(Name = "Album URL")]
        [DataType(DataType.Url)]
        public string? AlbumUrl { get; set; }
    }
}
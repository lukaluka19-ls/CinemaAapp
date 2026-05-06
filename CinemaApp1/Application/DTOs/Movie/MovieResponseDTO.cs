using CinemaApp1.Application.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp1.Application.DTOs.Movie
{
    public class MovieResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public int Duration { get; set; }
        public string? PosterPath { get; set; }
        public double AverageRating { get; set; }
        public GenreResponseDTO? Genre { get; set; }
    }
}

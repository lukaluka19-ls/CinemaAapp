using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp1.Application.DTOs.Common
{
    public class PagedResponseDTO<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; } = [];
    }
}
//OVO KORISTIMO ZA SVE PAGIRANE LISTE
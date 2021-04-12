using System.Collections.Generic;

namespace MF.Application.Movies.dtos
{
    public class SearchDto
    {
        public ICollection<MovieLite> Search { get; set; }
    }
}

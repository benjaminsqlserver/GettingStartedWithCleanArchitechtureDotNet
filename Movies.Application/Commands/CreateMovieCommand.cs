using MediatR;
using Movies.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands
{
    public class CreateMovieCommand:IRequest<MovieResponse>
    {
        public string MovieName { get; set; }
        public string DirectorName { get; set; }

        public string ReleaseYear { get; set; }
    }
}

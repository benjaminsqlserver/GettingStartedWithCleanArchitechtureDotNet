using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMoviesByDirectorNameQuery:IRequest<IEnumerable<MovieResponse>>
    {
        public string DirectorName { get; set; }


        public GetMoviesByDirectorNameQuery(string directorName)
        {
            DirectorName=directorName;
        }
    }
}

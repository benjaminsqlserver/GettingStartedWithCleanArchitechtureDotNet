using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Handlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
                _movieRepository=movieRepository;
        }
        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie movieEntity = MovieMapper.Mapper.Map<Movie>(request);
            if(movieEntity is null)
            {
                throw new ApplicationException("There Is An Issue With Mapping...");
            }

            var newMovie=await _movieRepository.AddAsync(movieEntity);
            MovieResponse movieResponse = MovieMapper.Mapper.Map<MovieResponse>(newMovie);
            return movieResponse;
        }
    }
}

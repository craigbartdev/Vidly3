using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly3.Models;
using Vidly3.Dtos;

namespace Vidly3.App_Start
{
    //Profile comes from Automapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //takes a source and a target
            //maps by property names. GET requests
            Mapper.CreateMap<Customer, CustomerDto>();
            //add ignore so no Id error on api PUT request
            //Ignore Id for PUT if there is an Id
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            //for reference in CustomerDto
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //mapping for get requests in api
            Mapper.CreateMap<Movie, MovieDto>();
            //mapping for POST and PUT. make Ignore Id for PUT
            //also ignore DateAdded
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.DateAdded, opt => opt.Ignore());
            //for reference in MovieDto
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}
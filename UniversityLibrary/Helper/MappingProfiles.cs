using AutoMapper;
using UniversityLibrary.Dto;
using UniversityLibrary.Models;

namespace UniversityLibrary.Helper
{
    public class MappingProfiles : Profile 
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();    
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Borrow, BorrowDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();



        }
    }
}

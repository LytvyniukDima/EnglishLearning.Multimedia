﻿using AutoMapper;

namespace EnglishLearning.Multimedia.Application.Infrastructure
{
    public class ApplicationMapper
    {
        private readonly IMapper _mapper;
        
        public ApplicationMapper()
        {
            _mapper = new MapperConfiguration(x => x
                    .AddProfile(new ApplicationMapperProfile()))
                .CreateMapper();
        }

        public IMapper Mapper => _mapper;
    }
}
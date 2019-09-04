using AutoMapper;

namespace EnglishLearning.Multimedia.Web.Infrastructure
{
    public class WebMapper
    {
        private IMapper _mapper;
        
        public WebMapper()
        {
            _mapper = new MapperConfiguration(x => 
                    x.AddProfile(new WebMapperProfile()))
                .CreateMapper(); 
        }

        public IMapper Mapper => _mapper;
    }
}
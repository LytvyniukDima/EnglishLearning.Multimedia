using AutoMapper;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Web.ViewModels;
using EnglishLearning.Multimedia.Web.ViewModels.Create;
using EnglishLearning.Multimedia.Web.ViewModels.Filters;
using EnglishLearning.Multimedia.Web.ViewModels.Info;
using EnglishLearning.Utilities.Linq.Extensions;

namespace EnglishLearning.Multimedia.Web.Infrastructure
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            EnglishAudioMapperConfiguration();
            EnglishVideoMapperConfiguration();
            EnglishTextMapperConfiguration();
            
            CreateMap<EnglishLevelFilterModel, EnglishLevelFilterViewModel>();
            CreateMap<EnglishLevelFilterViewModel, EnglishLevelFilterModel>();
        }

        private void EnglishAudioMapperConfiguration()
        {
            CreateMap<AudioPlayerTypeFilterModel, AudioPlayerTypeFilterViewModel>()
                .ForMember(
                    x => x.FilterOptions,
                    opt => opt.MapFrom(x => x.FilterOptions.ConvertToStringKeyDictionary()));

            CreateMap<AudioTypeFilterModel, AudioTypeFilterViewModel>();
            CreateMap<AudioTypeFilterViewModel, AudioTypeFilterModel>();
            
            CreateMap<EnglishAudioModel, EnglishAudioViewModel>();
            CreateMap<EnglishAudioViewModel, EnglishAudioModel>();
            CreateMap<EnglishAudioModel, EnglishAudioInfoViewModel>();
            
            CreateMap<EnglishAudioFullFilterModel, EnglishAudioFullFilterViewModel>();
            CreateMap<EnglishAudioFullFilterViewModel, EnglishAudioFullFilterModel>();
            
            CreateMap<EnglishAudioInfoModel, EnglishAudioInfoViewModel>();
            CreateMap<EnglishAudioInfoViewModel, EnglishAudioInfoModel>();

            CreateMap<EnglishAudioCreateViewModel, EnglishAudioModel>();
        }

        private void EnglishTextMapperConfiguration()
        {            
            CreateMap<TextTypeFilterModel, TextTypeFilterViewModel>()
                .ForMember(
                    x => x.FilterOptions,
                    opt => opt.MapFrom(x => x.FilterOptions.ConvertToStringKeyDictionary()));

            CreateMap<EnglishTextModel, EnglishTextViewModel>();
            CreateMap<EnglishTextViewModel, EnglishTextModel>();
            CreateMap<EnglishTextModel, EnglishTextInfoViewModel>();
            
            CreateMap<EnglishTextFullFilterModel, EnglishTextFullFilterViewModel>();
            CreateMap<EnglishTextFullFilterViewModel, EnglishTextFullFilterModel>();
            
            CreateMap<EnglishTextInfoModel, EnglishTextInfoViewModel>();
            CreateMap<EnglishTextInfoViewModel, EnglishTextInfoModel>();

            CreateMap<EnglishTextCreateViewModel, EnglishTextModel>();
        }

        private void EnglishVideoMapperConfiguration()
        {
            CreateMap<VideoTypeFilterModel, VideoTypeFilterViewModel>();

            CreateMap<EnglishVideoModel, EnglishVideoViewModel>();
            CreateMap<EnglishVideoViewModel, EnglishVideoModel>();
            CreateMap<EnglishVideoModel, EnglishVideoInfoViewModel>();
            
            CreateMap<EnglishVideoFullFilterModel, EnglishVideoFullFilterViewModel>();
            CreateMap<EnglishVideoFullFilterViewModel, EnglishVideoFullFilterModel>();
            
            CreateMap<EnglishVideoInfoModel, EnglishVideoInfoViewModel>();
            CreateMap<EnglishVideoInfoViewModel, EnglishVideoInfoModel>();

            CreateMap<EnglishVideoCreateViewModel, EnglishVideoModel>();
        }
    }
}
using AutoMapper;
using EnglishLearning.Multimedia.Application.Models;
using EnglishLearning.Multimedia.Application.Models.CreateModels;
using EnglishLearning.Multimedia.Application.Models.Filters;
using EnglishLearning.Multimedia.Application.Models.InfoModels;
using EnglishLearning.Multimedia.Persistence.Entities;
using EnglishLearning.Multimedia.Persistence.Entities.Audio;
using EnglishLearning.Multimedia.Persistence.Entities.Text;
using EnglishLearning.Multimedia.Persistence.Entities.Video;

namespace EnglishLearning.Multimedia.Application.Infrastructure
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            EnglishAudioMapperConfiguration();
            EnglishVideoMapperConfiguration();
            EnglishTextMapperConfiguration();

            CreateMap<EnglishLevelFilter, EnglishLevelFilterModel>();
            CreateMap<EnglishLevelFilterModel, EnglishLevelFilter>();
        }

        private void EnglishAudioMapperConfiguration()
        {
            CreateMap<AudioPlayerTypeFilter, AudioPlayerTypeFilterModel>();
            CreateMap<AudioPlayerTypeFilterModel, AudioPlayerTypeFilter>();
            
            CreateMap<AudioTypeFilter, AudioTypeFilterModel>();
            CreateMap<AudioTypeFilterModel, AudioTypeFilter>();
            
            CreateMap<EnglishAudio, EnglishAudioModel>();
            CreateMap<EnglishAudioModel, EnglishAudio>();
            CreateMap<EnglishAudio, EnglishAudioInfoModel>();
            
            CreateMap<EnglishAudioFullFilter, EnglishAudioFullFilterModel>();
            CreateMap<EnglishAudioFullFilterModel, EnglishAudioFullFilter>();
            
            CreateMap<EnglishAudioInfo, EnglishAudioInfoModel>();
            CreateMap<EnglishAudioInfoModel, EnglishAudioInfo>();

            CreateMap<EnglishAudioCreateModel, EnglishAudio>();
        }

        private void EnglishTextMapperConfiguration()
        {            
            CreateMap<TextTypeFilter, TextTypeFilterModel>();
            CreateMap<TextTypeFilterModel, TextTypeFilter>();
            
            CreateMap<EnglishText, EnglishTextModel>();
            CreateMap<EnglishTextModel, EnglishText>();
            CreateMap<EnglishText, EnglishTextInfoModel>();
            
            CreateMap<EnglishTextFullFilter, EnglishTextFullFilterModel>();
            CreateMap<EnglishTextFullFilterModel, EnglishTextFullFilter>();
            
            CreateMap<EnglishTextInfo, EnglishTextInfoModel>();
            CreateMap<EnglishTextInfoModel, EnglishTextInfo>();

            CreateMap<EnglishTextCreateModel, EnglishText>();
        }

        private void EnglishVideoMapperConfiguration()
        {
            CreateMap<VideoTypeFilter, VideoTypeFilterModel>();
            CreateMap<VideoTypeFilterModel, VideoTypeFilter>();
            
            CreateMap<EnglishVideo, EnglishVideoModel>();
            CreateMap<EnglishVideoModel, EnglishVideo>();
            CreateMap<EnglishVideo, EnglishVideoInfoModel>();
            
            CreateMap<EnglishVideoFullFilter, EnglishVideoFullFilterModel>();
            CreateMap<EnglishVideoFullFilterModel, EnglishVideoFullFilter>();
            
            CreateMap<EnglishVideoInfo, EnglishVideoInfoModel>();
            CreateMap<EnglishVideoInfoModel, EnglishVideoInfo>();

            CreateMap<EnglishVideoCreateModel, EnglishVideo>();
        }
    }
}
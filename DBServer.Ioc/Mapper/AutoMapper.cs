using AutoMapper;
using DbServer.Api.DTO;
using DbServer.Domain.Entities;

namespace DBServer.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() : this("MapProfile")
        {
        }

        protected MapProfile(string profileName) : base(profileName)
        {
            this.MapearDTOsParaEntidades();
            this.MapearEntidadesParaDTOs();
        }

        private void MapearEntidadesParaDTOs()
        {
            //Post
            CreateMap<Post, PostDTO>();

            //CheckingAccount
            CreateMap<CheckingAccount, CheckingAccountDTO>();

        }

        private void MapearDTOsParaEntidades()
        {

            //Post DTO
            CreateMap<PostDTO, Post>();

            //CheckingAccount DTO
            CreateMap<CheckingAccountDTO, CheckingAccount>();
        }
    }
}

using AutoMapper;
using AutoMapperSandbox.Models;
using System.Xml.Linq;

namespace AutoMapperSandbox.Api.AutoMapper
{
    public class AutoMapperAPIProfile : Profile
    {
        public AutoMapperAPIProfile()
        {
            AllowNullCollections = true;

            CreateMap<PassengerInput, PassengerOutput>();
            CreateMap<PassengerOutput, PassengerInput>();

            CreateMap<FruitInput, FruitOutput>()
                .ForMember(dest => dest.PricePerWeight, act => act.MapFrom(src => src.Price / src.Weight))
                .ForMember(dest => dest.Properties, act => act.MapFrom(src => new FruitComplexObject()
                {
                    Calories = int.Parse(src.cal),
                    Color = src.col,
                    ExpiryDate = DateTime.Parse(src.date)
                })
                )
                .ForMember(dest => dest.FieldToIgnore, act => act.Ignore());

            CreateMap<IEnumerable<FruitInput>, FruitListOutput>()
                .ForMember(dest => dest.FruitList, act => act.MapFrom(src => src));

            CreateMap<FruitInput, BananaOutput>()
                .IncludeBase<FruitInput, FruitOutput>()
                .AfterMap((src, dest) =>
                {
                    dest.RealName = "Banana";
                    dest.Name = "Banana";
                    dest.Properties.Color = "Yellow";
                });

            CreateMap<ContextObjectInput, ContextObjectOutput>()
                .ForMember(dest => dest.FutureDate, opt => opt.MapFrom((src, dst, _, context) =>
                {
                    int extraDays = (int)context.Items["ExtraDays"];
                    DateTime dateTime = src.InitialDate.AddDays(extraDays);
                    return dateTime;
                })
                );
        }
    }
}

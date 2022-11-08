using AutoMapper;
using AutoMapperSandbox.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AutoMapperSandbox.Api.AutoMapper
{
    public class AutoMapperAPIProfile : Profile
    {
        public AutoMapperAPIProfile()
        {
            AllowNullCollections = true;

            CreateMap<PassengerInput, PassengerOutput>();
            CreateMap<FruitInput, FruitOutput>()
                .ForMember(dest => dest.PricePerWeight, act => act.MapFrom(src => src.Price / src.Weight))
                .ForMember(dest => dest.Properties, act => act.MapFrom(src => new FruitComplexObject()
                {
                    Calories = int.Parse(src.cal),
                    Color = src.col,
                    ExpiryDate = DateTime.Parse(src.date)
                })
                );

            //.ForMember(dest => dest.Actions,
            //    opt => opt.MapFrom((src, dst, _, context) =>
            //    {

            //        if (src.Document.DocumentType == DocumentType.Passport)
            //        {
            //            src.Document.Id = src.Document.Passport.Id;
            //        }
            //        else if (src.Document.DocumentType == DocumentType.NationalId)
            //        {
            //            src.Document.Id = src.Document.NationalId.Id;
            //        }

            //        return new GuestDocumentDetailsActions
            //        {
            //            Patch = UrlBuilder.BuildResourcePatchUrl(src.Document.Id.GetValueOrDefault().ToString(), (HttpRequest)context.Options.Items["HttpRequest"]),
            //            Delete = UrlBuilder.BuildResourceDeleteUrl(src.Document.Id.GetValueOrDefault().ToString(), (HttpRequest)context.Options.Items["HttpRequest"])
            //        };
            //    }))
            //  .ForMember(dest => dest.GuestDetails, act => act.MapFrom(src => src.Document.GuestDetails))
            //  .ForMember(dest => dest.Passport, act => act.MapFrom(src => src.Document.Passport))
            //  .ForMember(dest => dest.NationalId, act => act.MapFrom(src => src.Document.NationalId))
            //  .ForMember(dest => dest.ReturnDate, act => act.Ignore())
            //  .ForMember(dest => dest.AccommodationCountry, act => act.Ignore())
            //  ;

            //CreateMap<Infrastructure.DataEntities.GuestDocuments.GuestDetails, Models.GuestDocuments.GuestDetails>()
            //    .ForMember(dest => dest.DateOfBirth, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.DateOfBirth)));

            //CreateMap<Infrastructure.DataEntities.GuestDocuments.Passport, Models.GuestDocuments.Passport>()
            //   .ForMember(dest => dest.ExpiryDate, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.ExpiryDate)))
            //   .ForMember(dest => dest.IssueDate, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.IssueDate)))
            //   .ForMember(dest => dest.LastModified, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.LastModified)));

            //CreateMap<Infrastructure.DataEntities.GuestDocuments.NationalId, Models.GuestDocuments.NationalId>()
            //   .ForMember(dest => dest.IssueDate, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.IssueDate)))
            //   .ForMember(dest => dest.ExpiryDate, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.ExpiryDate)))
            //   .ForMember(dest => dest.LastModified, act => act.MapFrom(src => DateTimeConverter.ConvertToDateString(src.LastModified)));

            //CreateMap<Infrastructure.DataEntities.GuestDocuments.GuestDocumentDetails, Models.GuestDocuments.MaskedGuestDocumentDetails>()
            //.IncludeBase<Infrastructure.DataEntities.GuestDocuments.GuestDocumentDetails, Models.GuestDocuments.GuestDocumentDetailsContext>()
            //.AfterMap((src, dest) =>
            //{
            //    if (src.Document.DocumentType == DocumentType.NationalId)
            //    {
            //        dest.NationalId.DocumentNumber = DataMasker.Mask(src.Document.NationalId.DocumentNumber);
            //    }
            //    else if (src.Document.DocumentType == DocumentType.Passport)
            //    {
            //        dest.Passport.DocumentNumber = DataMasker.Mask(src.Document.Passport.DocumentNumber);
            //    }
            //});

            //// API => API
            //CreateMap<IEnumerable<PassengerInformation.Api.Models.GuestDocuments.GuestDocumentDetails>, Models.GuestDocuments.GuestDocuments>()
            //.ForMember(dest => dest.Documents,
            //    opt => opt.MapFrom((src, dst, _, context) =>
            //    {
            //        return src;
            //    }))
            //.ForMember(dest => dest.Actions,
            //opt => opt.MapFrom((src, dst, _, context) =>
            //{
            //    return new GuestDocumentsActions() { Post = UrlBuilder.BuildResourceAddUrl((HttpRequest)context.Options.Items["HttpRequest"]) };

            //}));

        }
    }
}

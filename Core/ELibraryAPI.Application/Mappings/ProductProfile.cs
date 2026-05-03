using AutoMapper;
using ELibraryAPI.Application.Features.Commands.Product.CreateProduct;
using ELibraryAPI.Application.Features.Commands.Product.UpdateProduct;
using ELibraryAPI.Application.Features.Queries.Product.GetAllProduct;
using ELibraryAPI.Application.Features.Queries.Product.GetByIdProduct;
using ELibraryAPI.Domain.Entities.Concrete;

namespace ELibraryAPI.Application.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommandRequest, Product>()
            .ForMember(dest => dest.ProductAuthors, opt => opt.Ignore())
            .ForMember(dest => dest.ProductGenres, opt => opt.Ignore())
            .ForMember(dest => dest.ProductTags, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore());

        CreateMap<Product, CreateProductCommandResponse>();

        CreateMap<UpdateProductCommandRequest, Product>()
            .ForMember(dest => dest.ProductAuthors, opt => opt.Ignore())
            .ForMember(dest => dest.ProductGenres, opt => opt.Ignore())
            .ForMember(dest => dest.ProductTags, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore());

        CreateMap<Product, UpdateProductCommandResponse>();

        CreateMap<Product, ProductListDto>()
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.Name : ""))
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language != null ? src.Language.Name : ""))
            .ForMember(dest => dest.CoverTypeName, opt => opt.MapFrom(src => src.CoverType != null ? src.CoverType.Name : ""))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory != null && src.SubCategory.Category != null ? src.SubCategory.Category.Name : ""))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.ProductAuthors.Select(pa => pa.Author != null ? pa.Author.FullName : "").Where(x => x != "")))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ProductGenres.Select(pg => pg.Genre != null ? pg.Genre.Name : "").Where(x => x != "")))
            .ForMember(dest => dest.ReviewCount, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.Where(i => i.IsMain).Select(i => i.ImageUrl).FirstOrDefault() ?? ""));

        CreateMap<Product, ProductDetailDto>()
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher != null ? src.Publisher.Name : ""))
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Language != null ? src.Language.Name : ""))
            .ForMember(dest => dest.CoverTypeName, opt => opt.MapFrom(src => src.CoverType != null ? src.CoverType.Name : ""))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory != null && src.SubCategory.Category != null ? src.SubCategory.Category.Name : ""))
            .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory != null ? src.SubCategory.Name : ""))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.ProductAuthors.Select(pa => pa.Author != null ? pa.Author.FullName : "").Where(x => x != "")))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ProductGenres.Select(pg => pg.Genre != null ? pg.Genre.Name : "").Where(x => x != "")))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags.Select(pt => pt.Tag != null ? pt.Tag.Name : "").Where(x => x != "")))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
            .ForMember(dest => dest.ReviewCount, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0));
            
        CreateMap<Review, ReviewItemDto>()
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : ""));

        CreateMap<ProductImage, ProductImageDto>();
    }
}

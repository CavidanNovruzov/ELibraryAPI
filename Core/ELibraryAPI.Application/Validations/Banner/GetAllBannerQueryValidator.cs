using ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.Banner
{
    public sealed class GetAllBannerQueryValidator : AbstractValidator<GetAllBannerQueryRequest>
    {
        public GetAllBannerQueryValidator()
        {

        }
    }
}

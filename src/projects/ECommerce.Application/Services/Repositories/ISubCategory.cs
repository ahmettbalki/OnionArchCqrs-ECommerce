﻿using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
namespace ECommerce.Application.Services.Repositories;
public interface ISubCategory : IAsyncRepository<SubCategory, int>
{
}
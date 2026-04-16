using ELibraryAPI.Application.Abstractions.Repositories.Entities;
using ELibraryAPI.Domain.Entities.Concrete;
using ELibraryAPI.Domain.Entities.Concrete.Auth;
using ELibraryAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Persistance.Concrete.Repositories.Entities;

public class AuthorWriteRepository(ELibraryDbContext context) : WriteRepository<Author>(context), IAuthorWriteRepository { } 

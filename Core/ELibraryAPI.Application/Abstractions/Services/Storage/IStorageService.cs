using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Abstractions.Services.Storage
{
    public interface IStorageService
    {
        Task<string> UploadAsync(string base64Data, string fileName, string path);

        void Delete(string path, string fileName);

        bool HasFile(string path, string fileName);
    }
}

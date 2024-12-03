using Goreu.Firma.Dto.Requests;
using Goreu.Firma.Dto.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goreu.Firma.Services.Interfaces
{
    public interface IFileDownloadService
    {
        Task<FileDownloadResponse> DownloadDocumentAsync(FileDownloadRequest request);
    }
}

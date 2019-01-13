using AutoMapper.QueryableExtensions;
using ParallelTypeSystem.Common;
using ParallelTypeSystem.Data.Repositories;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Models.DTOs;
using System.Linq;
using System;

namespace ParallelTypeSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IGenericRepository<File> fileRepository;

        public DocumentService(IGenericRepository<File> fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public void AddFile(File file)
        {
            this.fileRepository.Add(file);
        }
    }
}

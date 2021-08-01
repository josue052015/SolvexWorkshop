using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Core.Settings;
using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
   public class DocumentServiceTests
    {
        private readonly IDocumentService _documentService;
        public readonly Document _document1 = new Document
        {
            FileName = "Documento 1",
            OriginalName = "Documento 1",
            ContentType = "Adobe Acrobat Document (.pdf)"
        };
        public DocumentServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");
            var context = new WorkShopContext(optionsBuilder.Options);
            context.AddRange(_document1);
            context.SaveChanges();

            IDocumentRepository repository = new DocumentRepository(context);

            #endregion

            #region Validator

            var validator = new DocumentValidator();

            #endregion

           

            _documentService = new DocumentService(repository, mapper, validator);
        }
        [Fact]
        public async Task ShouldSaveDocumentAsync()
        {
            //Arrange
            var requestDto = new DocumentDto
            {
                FileName = "Prueba",
                OriginalName = "Prueba",
                ContentType = "Adobe Acrobat Document (.pdf)"
            };

            //Act
            var result = await _documentService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }
        [Fact]
        public async Task ShouldGetDocumentGeAllAsync()
        {
            //Act
            var result = await _documentService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ShouldDeleteDocumentAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _documentService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }
        [Fact]
        public async Task ShouldUpdateDocumentAsync()
        {
            //Arrange
            var id = 1;

            var requestDto = new DocumentDto
            {
                Id = 1,
                FileName = "Prueba2",
                OriginalName = "Prueba2",
                ContentType = "Adobe Acrobat Document (.pdf)"
            };

            var result = await _documentService.UpdateAsync(id, requestDto);

            //Assert

            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.Id, result.Entity.Id);

        }
    }
}

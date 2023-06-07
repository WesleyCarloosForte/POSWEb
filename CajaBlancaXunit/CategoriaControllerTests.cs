using AutoMapper;
using Backend.Controllers;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedProject.DTOs;
using SharedProject.Interface;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace CajaBlancaXunit
{
    public class CategoriaControllerTests
    {
        private readonly CategoriaController _controller;
        private readonly Mock<ICategoriaRepository> _categoriaRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public CategoriaControllerTests()
        {
            _categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            _mapperMock = new Mock<IMapper>();
            _controller = new CategoriaController(_categoriaRepositoryMock.Object, _mapperMock.Object);
        }


        [Fact]
        public void GetById_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            int categoriaId = 1;

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.GetById(categoriaId);

            // Assert
            Assert.IsType<StatusCodeResult>(result.Result);
            var statusCodeResult = (StatusCodeResult)result.Result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void Create_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            var categoriaCreateDTO = new CategoriaCreateDTO();
            _mapperMock.Setup(mapper => mapper.Map<Categoria>(categoriaCreateDTO)).Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Create(categoriaCreateDTO);

            // Assert
            Assert.IsType<StatusCodeResult>(result.Result);
            var statusCodeResult = (StatusCodeResult)result.Result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void Update_ReturnsBadRequest_WhenCategoriaIdMismatch()
        {
            // Arrange
            int categoriaId = 1;
            var categoriaUpdateDTO = new CategoriaCreateDTO { Id = 2 };
            var categoria = new Categoria { Id = categoriaId };

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.Update(categoriaId, categoriaUpdateDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsInternalServerError_WhenExceptionThrown()
        {
            // Arrange
            int categoriaId = 1;
            var categoria = new Categoria { Id = categoriaId };

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);
            _categoriaRepositoryMock.Setup(repo => repo.Delete(categoria)).Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Delete(categoriaId);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Arrange
            var categorias = new List<Categoria>();
            var categoriaDTOs = new List<CategoriaViewDTO>();

            _categoriaRepositoryMock.Setup(repo => repo.GetAll()).Returns(categorias);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CategoriaViewDTO>>(categorias)).Returns(categoriaDTOs);

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAll_ReturnsBadRequest_WhenExceptionThrown()
        {
            // Arrange
            _categoriaRepositoryMock.Setup(repo => repo.GetAll()).Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_ReturnsOkResult_WhenCategoriaExists()
        {
            // Arrange
            int categoriaId = 1;
            var categoria = new Categoria { Id = categoriaId };
            var categoriaDTO = new CategoriaViewDTO { Id = categoriaId };

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);
            _mapperMock.Setup(mapper => mapper.Map<CategoriaViewDTO>(categoria)).Returns(categoriaDTO);

            // Act
            var result = _controller.GetById(categoriaId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenCategoriaDoesNotExist()
        {
            // Arrange
            int categoriaId = 1;
            Categoria categoria = null;

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.GetById(categoriaId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void Create_ReturnsCreatedAtAction()
        {
            // Arrange
            var categoriaCreateDTO = new CategoriaCreateDTO();
            var categoria = new Categoria { Id = 1 };
            var categoriaViewDTO = new CategoriaViewDTO { Id = 1 };

            _mapperMock.Setup(mapper => mapper.Map<Categoria>(categoriaCreateDTO)).Returns(categoria);
            _mapperMock.Setup(mapper => mapper.Map<CategoriaViewDTO>(categoria)).Returns(categoriaViewDTO);

            // Act
            var result = _controller.Create(categoriaCreateDTO);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void Create_ReturnsBadRequest_WhenExceptionThrown()
        {
            // Arrange
            var categoriaCreateDTO = new CategoriaCreateDTO();
            _mapperMock.Setup(mapper => mapper.Map<Categoria>(categoriaCreateDTO)).Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Create(categoriaCreateDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void Update_ReturnsNoContent_WhenCategoriaExists()
        {
            // Arrange
            int categoriaId = 1;
            var categoriaUpdateDTO = new CategoriaCreateDTO { Id = categoriaId };
            var categoria = new Categoria { Id = categoriaId };

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.Update(categoriaId, categoriaUpdateDTO);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Update_ReturnsBadRequest_WhenCategoriaDoesNotExist()
        {
            // Arrange
            int categoriaId = 1;
            Categoria categoria = null;

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.Update(categoriaId, new CategoriaCreateDTO());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNoContent_WhenCategoriaExists()
        {
            // Arrange
            int categoriaId = 1;
            var categoria = new Categoria { Id = categoriaId };

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.Delete(categoriaId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenCategoriaDoesNotExist()
        {
            // Arrange
            int categoriaId = 1;
            Categoria categoria = null;

            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoriaId)).Returns(categoria);

            // Act
            var result = _controller.Delete(categoriaId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Agregar más pruebas para los demás métodos del controlador

        // ...
    }
}

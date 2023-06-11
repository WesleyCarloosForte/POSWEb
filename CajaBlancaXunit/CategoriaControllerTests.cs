using Xunit;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Backend.Controllers;
using Backend.Repositories;
using SharedProject.Models;
using SharedProject.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedProject.Interface;

namespace Backend.Tests
{
    public class CategoriaControllerTests
    {
        private readonly CategoriaController _controller;
        private readonly Mock<ICategoriaRepository> _categoriaRepositoryMock;
        private readonly IMapper _mapper;

        public CategoriaControllerTests()
        {
            _categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();

            _controller = new CategoriaController(_categoriaRepositoryMock.Object, _mapper);
        }
        [Fact]
        public void GetAll_DebeRetornarOkResultConListaDeCategorias()
        {
            // Arrange
            var categorias = new List<Categoria> { new Categoria { Id = 1, Descripcion = "Categoría 1" }, new Categoria { Id = 2, Descripcion = "Categoría 2" } };
            _categoriaRepositoryMock.Setup(repo => repo.GetAll()).Returns(categorias);

            // Act
            var result = _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var categoriasResult = Assert.IsAssignableFrom<IEnumerable<CategoriaViewDTO>>(okResult.Value);
            Assert.Equal(2, categoriasResult.Count());
        }
        /*
        [Fact]
        public void GetAll_ConFiltro_DebeRetornarOkResultConListaDeCategoriasFiltradas()
        {
            // Arrange
            var filtro = "Categoría";
            var categorias = new List<Categoria> { new Categoria { Id = 1, Descripcion = "Categoría 1" } };
            _categoriaRepositoryMock.Setup(repo => repo.FilterGet(filtro)).Returns(categorias.Select(c => _mapper.Map<CategoriaViewDTO>(c)).ToList());

            // Act
            var result = _controller.GetAll(filtro);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var categoriasResult = Assert.IsAssignableFrom<IEnumerable<CategoriaViewDTO>>(okResult.Value);
            Assert.Single(categoriasResult);
        }
        */
        [Fact]
        public void GetById_IdExistente_DebeRetornarOkResultConCategoria()
        {
            // Arrange
            var categoria = new Categoria { Id = 1, Descripcion = "Categoría 1" };
            _categoriaRepositoryMock.Setup(repo => repo.GetById(categoria.Id)).Returns(categoria);

            // Act
            var result = _controller.GetById(categoria.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var categoriaResult = Assert.IsAssignableFrom<CategoriaViewDTO>(okResult.Value);
            Assert.Equal(categoria.Id, categoriaResult.Id);
            Assert.Equal(categoria.Descripcion, categoriaResult.Descripcion);
        }

        [Fact]
        public void Update_IdNoCoincideConCategoria_DebeRetornarBadRequest()
        {
            // Arrange
            var categoriaCreateDto = new CategoriaCreateDTO { Id = 1, Descripcion = "Nueva Categoría" };

            // Act
            var result = _controller.Update(2, categoriaCreateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }


        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Categoria, CategoriaViewDTO>();
            }
        }
    }
}

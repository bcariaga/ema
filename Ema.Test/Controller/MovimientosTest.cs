﻿using Ema.Controllers;
using Ema.Data;
using Ema.Service;
using Ema.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ema.Test.Controller
{
    public class MovimientosControllerTest
    {
        internal IMovimientoService mockService;
        internal MovimientosController controller;

        public MovimientosControllerTest()
        {
            mockService = new MockMovimientoService();

            controller = new MovimientosController(mockService);

        }

        internal void AddData()
        {
            mockService.Add(new Data.Movimiento()
            {
                Id = 1,
                Descripcion = "test",
                Estado = Data.Estado.Activo,
                Fecha = DateTime.Now,
                Importe = 100,
                Regularidad = Data.Regularidad.Unico,
                TipoMovimento = Data.TipoMovimento.Entrada
            });

            mockService.Add(new Data.Movimiento()
            {
                Id = 2,
                Descripcion = "Mock data",
                Estado = Data.Estado.Activo,
                Fecha = DateTime.Now,
                Importe = 122,
                Regularidad = Data.Regularidad.Recursivo,
                TipoMovimento = Data.TipoMovimento.Entrada
            });

            mockService.Add(new Data.Movimiento()
            {
                Id = 3,
                Descripcion = "Mock Movi",
                Estado = Data.Estado.Vencido,
                Fecha = DateTime.Now,
                Importe = 100,
                Regularidad = Data.Regularidad.Unico,
                TipoMovimento = Data.TipoMovimento.Gasto
            });
        }

        internal Movimiento GetMovimiento()
        {
            return new Movimiento()
            {
                Id = 5,
                Descripcion = "Mock Movimiento",
                Estado = Data.Estado.Vencido,
                Fecha = DateTime.Now,
                Importe = 100,
                Regularidad = Data.Regularidad.Unico,
                TipoMovimento = Data.TipoMovimento.Gasto
            };
        }


        [Fact]
        public async void GetIndexView()
        {
            AddData();

            var indexResult = await controller.Index();

            var viewResult = indexResult as ViewResult;

            Assert.NotNull(viewResult);

            Assert.Equal("Index", viewResult.ViewName);

            Assert.Equal(typeof(List<Movimiento>), viewResult.Model.GetType());
        }

        [Fact]
        public void GetCreateView()
        {
            var createResult = controller.Create();

            var viewResult = createResult as ViewResult;

            Assert.NotNull(viewResult);

            Assert.Equal("Create", viewResult.ViewName);

            Assert.Equal(typeof(Movimiento), viewResult.Model.GetType());
        }

        [Fact]
        public async void TestCreateMovimiento()
        {
            var mockEntity = GetMovimiento();

            await controller.Create(mockEntity);
            
            //check if entity exist
            Assert.Equal(mockEntity, mockService.FindById(mockEntity.Id));
        }
    }
}

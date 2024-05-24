﻿using Microsoft.AspNetCore.Mvc;
using MvcApiCubosAWS.Models;
using MvcApiCubosAWS.Services;

namespace MvcApiCubosAWS.Controllers
{
    public class CubosController : Controller
    {
        private ServiceApiCubos service;

        public CubosController(ServiceApiCubos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.service.GetCubosAsync();
            return View(cubos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo)
        {
            await this.service.CreateCuboAsync(cubo.Nombre, cubo.Marca,cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Cubo cubo = await this.service.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cubo cubo)
        {
            await this.service.UpdateCuboAsync(cubo.IdCubo,cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.service.FindCuboAsync(id);

            return View(cubo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteCuboAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Filtrar()
        {
            List<string> marcas = await this.service.GetMarcasAsync();
            ViewData["MARCAS"] = marcas;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filtrar(string marca)
        {
            List<string> marcas = await this.service.GetMarcasAsync();
            ViewData["MARCAS"] = marcas;

            List<Cubo> cubos = await this.service.GetCubosMarcaAsync(marca);

            return View(cubos);
        }

    }
}

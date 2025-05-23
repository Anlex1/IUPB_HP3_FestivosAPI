﻿using FestivosAPI.Core.Repositorio;
using FestivosAPI.Core.Servicios;
using FestivosAPI.Dominio.Entidades;

namespace FestivosAPI.Aplicacion
{
    public class TipoServicio: ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Tipo> ObtenerPorId(int Id)
        {
            return await repositorio.ObtenerPorId(Id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
        public async Task<IEnumerable<Tipo>> Buscar(string Dato)
        {
            return await repositorio.Buscar(Dato);
        }

        public async Task<Tipo> Agregar(Tipo Tipo)
        {
            return await repositorio.Agregar(Tipo);
        }

        public async Task<Tipo> Modificar(Tipo Tipo)
        {
            return await repositorio.Modificar(Tipo);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

    }
}

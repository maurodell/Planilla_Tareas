﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribucionTareas
{
    class Colaborador
    {
        List<Tarea> _listaTareas;
        public Colaborador()
        {
            _listaTareas = new List<Tarea>();
        }
        public string Legajo { get; set; }
        public string Nombre { get; set; }

        public Colaborador(string pLegajo, string pNombre) : this()
        {
            this.Legajo = pLegajo;
            this.Nombre = pNombre;
        }
        public void AgregarTarea(Tarea pTarea)
        {
            _listaTareas.Add(new Tarea(pTarea.Categoría, pTarea.Cliente, pTarea.Descripcion, pTarea.Fecha));
        }
        public List<Tarea> RetornarListaTareas()
        {
            List<Tarea> _auxLista = new List<Tarea>();
            try
            {
                foreach (Tarea tareas in _listaTareas)
                {
                    _auxLista.Add(new Tarea(tareas.Categoría, tareas.Cliente, tareas.Descripcion, tareas.Fecha,
                                    tareas.Get_Colaborador()!=null?new Colaborador(tareas.Get_Colaborador().Legajo, tareas.Get_Colaborador().Nombre):null));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _auxLista;
        }
        public void BorrarTarea(Tarea pTarea)
        {
            try
            {
                if (pTarea!=null)
                {
                    pTarea.Set_Colaborador(null);
                    _listaTareas.Remove(pTarea);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ModificarTarea(Tarea pTarea)
        {
            try
            {
                Tarea _listTarea = new Tarea();
                _listTarea.Categoría = pTarea.Categoría;
                _listTarea.Cliente = pTarea.Cliente;
                _listTarea.Descripcion = pTarea.Descripcion;
                _listTarea.Fecha = pTarea.Fecha;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        ~Colaborador()
        {
            _listaTareas = null;
        }
    }
}
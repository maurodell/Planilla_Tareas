using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribucionTareas
{
    class Colaborador : IDisposable
    {
        bool _flag = false;
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
            try
            {
                _listaTareas.Add(new Tarea(pTarea.Codigo, pTarea.Categoría, pTarea.Cliente, pTarea.Descripcion, pTarea.Fecha, pTarea.Get_Colaborador()));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<Tarea> RetornarListaTareas()
        {
            List<Tarea> _auxLista = new List<Tarea>();
            try
            {
                foreach (Tarea tareas in _listaTareas)
                {
                    _auxLista.Add(new Tarea(tareas.Codigo, tareas.Categoría, tareas.Cliente, tareas.Descripcion, tareas.Fecha,
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
                Tarea _auxTarea = _listaTareas.Find(x=>x.Codigo == pTarea.Codigo);
                if (_auxTarea != null)
                {
                    _auxTarea.Set_Colaborador(null);
                    _listaTareas.Remove(_auxTarea);
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
                Tarea _listTarea = _listaTareas.Find(x=>x.Codigo == pTarea.Codigo);
                _listTarea.Categoría = pTarea.Categoría;
                _listTarea.Cliente = pTarea.Cliente;
                _listTarea.Descripcion = pTarea.Descripcion;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (!_flag)
            {
                _listaTareas = null;
                _flag = true;
            }
        }

        ~Colaborador()
        {
            if (!_flag)
            {
                _listaTareas = null;
            }
            
        }
    }
}

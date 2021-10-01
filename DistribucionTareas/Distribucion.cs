using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribucionTareas
{
    class Distribucion
    {
        List<Colaborador> _lc;
        List<Tarea> _lt;

        public Distribucion()
        {
            _lc = new List<Colaborador>();
            _lt = new List<Tarea>();
        }
        public List<Colaborador> RetornarListaColaboradores()
        {
            List<Colaborador> _auxC;
            try
            {
                _auxC = new List<Colaborador>();
                foreach (Colaborador _c in _lc)
                {
                    _auxC.Add(new Colaborador(_c.Legajo, _c.Nombre));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _auxC;
        }
        public void BorrarColaborador(Colaborador pColaborador)
        {
            try
            {
                if (pColaborador != null)
                {
                    _lc.Remove(pColaborador);
                }
                else
                {
                    throw new Exception("No hay Colaborador para borrar!");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void AgregarColaborador(Colaborador pColaborador)
        {
            try
            {
                if (pColaborador != null)
                {
                    _lc.Add(new Colaborador(pColaborador.Legajo, pColaborador.Nombre));
                }
                else
                {
                    throw new Exception("La persona que intenta agregar es null");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Tarea> RetornarListaTareas()
        {
            try
            {
                return _lt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void AgregarTarear(Tarea pTarea)
        {
            try
            {
                if (pTarea!=null)
                {
                    _lt.Add(new Tarea(pTarea.Categoría, pTarea.Cliente, pTarea.Descripcion, pTarea.Fecha));
                }
                else
                {
                    throw new Exception("El auto que se agrega es null");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BorrarTarea(Tarea pTarea)
        {
            try
            {
                if (pTarea != null)
                {
                    _lt.Remove(pTarea);
                }
                else
                {
                    throw new Exception("La tarea esta nula");
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
                if (pTarea != null)
                {
                    Tarea _auxTarea = _lt.Find(x => x.Cliente == pTarea.Cliente);
                    if (_auxTarea!=null)
                    {
                        _auxTarea.Categoría = pTarea.Categoría;
                        _auxTarea.Cliente = pTarea.Cliente;
                        _auxTarea.Descripcion = pTarea.Descripcion;
                        _auxTarea.Fecha = pTarea.Fecha;
                    }
                    else
                    {
                        throw new Exception("La lista esta vacía");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

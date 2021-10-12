using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    Colaborador _aux = _lc.Find(x=>x.Legajo == pColaborador.Legajo);
                    if (_aux!=null && _aux.RetornarListaTareas().Count==0)
                    {
                        _lc.Remove(_aux);
                    }
                    else
                    {
                        throw new Exception("Lista vacía");
                    }
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

                MessageBox.Show(ex.Message);
            }
        }
        public void ModificarColaborador(Colaborador pColaborador)
        {
            try
            {
                if (pColaborador!=null)
                {
                    Colaborador _auxColaborador = _lc.Find(x=>x.Legajo==pColaborador.Legajo);
                    if (_auxColaborador!=null)
                    {
                        _auxColaborador.Legajo = pColaborador.Legajo;
                        _auxColaborador.Nombre = pColaborador.Nombre;
                    }
                    if (_auxColaborador.RetornarListaTareas().Count>0)
                    {
                        foreach (Tarea item in _lt)
                        {
                            Tarea _auxTarea = _lt.Find(x=>x.Codigo==item.Codigo);
                            if (_auxTarea!=null)
                            {
                                Colaborador _colaborador = item.Get_Colaborador();
                                _auxTarea.Cliente = item.Cliente;
                                _auxTarea.Categoría = item.Categoría;
                                _auxTarea.Descripcion = item.Descripcion;
                                _auxTarea.Fecha = item.Fecha;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Colaborador no encontrado");
                    }
                }
                else
                {
                    throw new Exception("Lista vacía");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public List<Tarea> RetornarListaTareas()
        {
            List<Tarea> _auxT = new List<Tarea>();
            try
            {
                foreach (Tarea _t in _lt)
                {
                    _auxT.Add(new Tarea(_t.Codigo, _t.Categoría, _t.Cliente, _t.Descripcion, _t.Fecha,
                        _t.Get_Colaborador()!=null?new Colaborador(_t.Get_Colaborador().Legajo, _t.Get_Colaborador().Nombre):null));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _auxT;
        }
        public void AgregarTarear(Tarea pTarea)
        {
            try
            {
                if (pTarea!=null)
                {
                    _lt.Add(new Tarea(pTarea.Codigo, pTarea.Categoría, pTarea.Cliente, pTarea.Descripcion, pTarea.Fecha));
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
                if (pTarea!=null)
                {
                    Tarea _auxTarea = _lt.Find(x=>x.Codigo == pTarea.Codigo);
                    if (_auxTarea != null && _auxTarea.Get_Colaborador() == null)
                    {
                        _lt.Remove(_auxTarea);
                    }
                    else
                    {
                        throw new Exception("La tarea esta nula");
                    }
                }
                else
                {
                    throw new Exception("Tareas vacías");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
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

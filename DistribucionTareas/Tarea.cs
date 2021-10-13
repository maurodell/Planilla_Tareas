using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribucionTareas
{
    class Tarea
    {
        Colaborador _colaborador;
        public Tarea()
        {
            _colaborador = null;
        }
        public Tarea(Colaborador pColaborador)
        {
            _colaborador = pColaborador;
        }
        public Tarea(int pCodigo, string pCategorias, string pCliente, string pDescripcion, DateTime pFecha) : this()
        {
            this.Codigo = pCodigo;
            this.Categoría = pCategorias;
            this.Cliente = pCliente;
            this.Descripcion = pDescripcion;
            this.Fecha = pFecha;
        }
        public Tarea(int pCodigo, string pCategorias, string pCliente, string pDescripcion, DateTime pFecha, Colaborador pColaborador) : this(pColaborador)
        {
            this.Codigo = pCodigo;
            this.Categoría = pCategorias;
            this.Cliente = pCliente;
            this.Descripcion = pDescripcion;
            this.Fecha = pFecha;
        }
        public int Codigo { get; set; }
        public string Categoría { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Colaborador Get_Colaborador()
        {
            return _colaborador;
        }
        public void Set_Colaborador(Colaborador pColaborador)
        {
            _colaborador = pColaborador == null ? null : new Colaborador(pColaborador.Legajo, pColaborador.Nombre);
        }
    }
}

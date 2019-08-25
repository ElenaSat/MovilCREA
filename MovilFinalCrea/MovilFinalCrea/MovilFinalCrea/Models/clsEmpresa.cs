using System;
using System.Collections.Generic;
using System.Text;

namespace MovilFinalCrea.Models
{
    public class clsEmpresa
    {
        public int PK_Emp_Id { get; set; }
        public string Emp_Nombre { get; set; }
        public byte[] Emp_Logo { get; set; }
        public string Emp_Telefonos { get; set; }
        public string Emp_Descripcion { get; set; }
        public string Emp_PalabrasClaves { get; set; }
        public string Emp_Latitud { get; set; }
        public string Emp_Longitud { get; set; }
        public string Emp_Direccion { get; set; }
        public clsCategoriaEmpresa Categoria_Empresa { get; set; }
        public clsUsers Users { get; set; }
    }
}

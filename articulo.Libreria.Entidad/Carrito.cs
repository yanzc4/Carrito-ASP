using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace articulo.Libreria.Entidad
{
  public    class Carrito
    {
      
      // propiedades
    public string codigo { get; set; }
    public string nombre { get; set; }
    public int cantidad { get; set; }
    public double precio { get; set; }
    // propiedad de solo lectura
    public double importe
    {
        get { return cantidad * precio; }
    }
 
    }
}

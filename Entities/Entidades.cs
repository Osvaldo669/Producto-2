using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;

namespace Entities
{
    public class Mouse
    {
        public int Id_mouse { get; set; }
        public int f_marcamouse { get; set; }
        public string conector { get; set; }

    }

    public class Monitor
    {
        public int id_monitor { get; set; }
        public int f_marcamonitor { get; set; }
        public string conectores { get; set; }
        public string tamano { get; set; }
    }

    public class Teclado {
        public int id_teclado { get; set; }
        public int f_marcat { get; set; }
        public string conector { get; set; }
    }

    public class Gabinete
    {
        public int id_gabinete { get; set; }
        public string Modelo { get; set; }
        public int F_Marca { get; set; }
        public string TipoForma { get; set; }
    }

    public class DiscoDuro
    {
        public int id_discoDuro { get; set; }
        public string TipoDisco { get; set; }
        public string conector { get; set; }
        public string Capacidad { get; set; }
        public int F_MarcaDisco { get; set; }
        public string Extra { get; set; }
    }

    public class Marca
    {
        public int id_marca { get; set; }
        public string marca { get; set; }
        public int f_Id_Componente { get; set; }
        public string Extra { get; set; }

    }

    public class Componente
    {
        public int Id_componente { get; set; }
        public string componente { get; set; }
        public string Extra { get; set; }
    }

    public class ModeloCPU
    {
        public int id_modeloCPU { get; set; }
        public string Modelo { get; set; }
        public int F_marca { get; set; }
    }

    public class TipoCpu
    {
        public int id_ipoCPU { get; set; }
        public string Tipo { get; set; }
        public string Familia { get; set; }
        public string Velocidad { get; set; }
        public string Extra { get; set; }
        public int f_id_modcpu { get; set; }
    }

    public class TipoRam
    {
        public int id_tipoRam { get; set; }
        public string Tipo { get; set; }
        public string Extra { get; set; }
    }

    public class Ram
    {
        public int id_ram { get; set; }
        public int Capacidad { get; set; }
        public string Velocidad { get; set; }
        public int F_tipoR { get; set; }
    }

    public class cantDisc
    {
        public int id_cantDisc { get; set; }
        public string num_inv { get; set; }
        public int id_Disco { get; set; }
    }

    public class Laboratorio
    {
        public string nombre_laboratorio { get; set; }
    }
    public class Ubicacion
    {
        public string num_inv { get; set; }
        public string nombre_laboratorio { get; set; }
    }

    public class Actualizacion
    {
        public int id_Act { get; set; }
        public string num_inv { get; set; }
        public string num_serie { get; set; }
        public string descripcion { get; set; }
        public string fecha { get; set; }
    }

    public class CPU_Generico
    {
        public int id_CPU { get; set; }
        public int f_cpuTipo { get; set; }
        public int f_MarcaCpu { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int f_tipoRam { get; set; }
        public int f_id_Gabinete { get; set; }
        public string imagen_cpuGenerico { get; set; }
    }

    public class ComputadoraFinal
    {
        public string num_inv { get; set; }
        public string num_scpu { get; set; }
        public int f_id_cpuG { get; set; }
        public string num_teclado { get; set; }
        public string f_id_teclado { get; set; }
        public string num_smonitor { get; set; }
        public int f_id_monitor { get; set; }
        public string num_smouse { get; set; }
        public int f_id_mouse { get; set; }
        public string estado { get; set; }
        public string imagen1 { get; set; }
        public string imagen2 { get; set; }
        public string imagen3 { get; set; }
    }

}

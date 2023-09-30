using Aplicacion.Excepciones;
using Aplicacion.Interfaces.Aplicacion;
using Aplicación.Interfaces.Infraestructura;
using Dominio;

namespace Aplicacion.Casos_de_usos
{
    public  class AgregarFunciones : IAgregarFunciones
    {
        private readonly IAgregar _Agregar;
        public AgregarFunciones(IAgregar Agregar)
        {
            _Agregar = Agregar;
        }

        void IAgregarFunciones.RegistrarFuncion(int ID_Pelicula,int ID_Sala,DateTime Fecha,TimeSpan Horario)
        {
            _Agregar.AlmacenarFuncion(new Funciones
            {
                PeliculaId = ID_Pelicula,
                SalaId = ID_Sala,
                Fecha = Fecha,
                Horario = Horario, //Fijate si te deja como TimeSpan de una
            });
        }



        /*void IAgregarFunciones.RegistrarFuncion(IVerficacionID verificador_Id, IVerificacionTemporal verificador_Temp)
        {
            var iterador = true;
            Console.WriteLine("Por favor escoja la funcion a añadir de acuerdo a los siguientes parametros: \nID de Pelicula \n");
            foreach (var Peli in  _consultas.ListarPeliculas())
            {
                Console.WriteLine("ID: " + Peli.Peliculasid + "         - Titulo de la Pelicula: " + Peli.Titulo);
            };
            var IDPeli = verificador_Id.Verificacion(iterador, "pelicula");
            Console.Clear();
            Console.WriteLine("ID de la sala \n");
            foreach (var sala in _consultas.ListarSalas())
            {
                Console.WriteLine("ID:" + sala.SalaId + "    - Nombre de la sala: " + sala.Nombre + "            - Capacidad: " + sala.Capacidad);
            };
            int IDSala = verificador_Id.Verificacion(iterador, "sala");
            Console.Clear();
            iterador = true;
            Console.WriteLine("Fecha \nFormato: dd/mm o dia en forma numerica y mes en texto (EJ: 12 de Septiembre) \n");
            var dia = verificador_Temp.Verificacion(iterador).Date;
            Console.Clear();
            Console.WriteLine("Hora \nFormato: hh:mm o hora am/pm según se requiera \n");
            var hora = verificador_Temp.Verificacion(iterador).TimeOfDay;
            Console.Clear();
            var Funcion = new Funciones
            {
                PeliculaId = IDPeli,
                SalaId = IDSala,
                Fecha = dia,
                Horario = hora,
            };
            _Agregar.AlmacenarFuncion(Funcion);
        }*/
    }
}

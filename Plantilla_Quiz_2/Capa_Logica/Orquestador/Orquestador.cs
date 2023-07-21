using Capa_Acceso_Datos.Txt;
using Capa_Logica.Ayudante;
using Capa_Modelo.Estudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica.Orquestador
{
    public class Orquestador
    {
        //Desarrolle aquí su código, recuerde que el mismo debe ser legible
        public void Ejercicio_Quiz_2() {
            Thread tr = new Thread(Proceso_arc1);
            Thread tr2 = new Thread(Proceso_arc2);
            tr.Start();
            tr2.Start();    
        }

        public void Proceso_arc1()
        {
            Estudiante estudiante1 = Deserialize_Estudiante(Lea_EstudianteJSON_arc1());    
            Console.WriteLine(estudiante1.nombre);

            for(int i = estudiante1.edad ; i >= 0 ; i--)
            {
                Console.WriteLine("Iteracion de de Estudiante 1: " + i);
                Thread.Sleep(2000);
            }
        }

        public void Proceso_arc2()
        {
            Estudiante estudiante2 = Deserialize_Estudiante(Lea_EstudianteJSON_arc2());
            Console.WriteLine(estudiante2.nombre);

            for (int i = estudiante2.edad ; i >= 0 ; i--)
            {
                Console.WriteLine("Iteracion de Estudiante 2: " + i);
                Thread.Sleep(2000);
            }
        }


        /// <summary>
        /// Acontinuacion se visualizan los metodos involucrados
        /// con la visualiacion del archivo y deserializacion del JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Estudiante Deserialize_Estudiante(string json)
        {
            Ayudante_JSON ayudante = new Ayudante_JSON();

            Estudiante nuevoEstudiante = ayudante.Deserialize_Modelo<Estudiante>(json);

            return nuevoEstudiante;
        }

        public string Lea_EstudianteJSON_arc1()
        {
            Lectura_Txt lectura = new Lectura_Txt();
            string contenido = lectura.Lee_Archivo("C:\\Users\\laboratorio\\Documents\\archivo1.json");
            return contenido;
        }
        public string Lea_EstudianteJSON_arc2()
        {
            Lectura_Txt lectura = new Lectura_Txt();
            string contenido = lectura.Lee_Archivo("C:\\Users\\laboratorio\\Documents\\archivo2.json");
            return contenido;
        }

    }
}

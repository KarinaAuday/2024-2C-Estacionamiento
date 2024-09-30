using _2024_2C_EstacionamientoORT.Models;

namespace _2024_2C_EstacionamientoORT.Data
{
    public class RepoPersonas
    {
        private List<Persona> _personas;

        public RepoPersonas()
        {
            _personas = new List<Persona>();
            Persona persona = new Persona() { Nombre = "Luis", Apellido = "Spinetta", Dni = "22334455", Email = "LSpinetta@gmail.com"  };
            Persona persona2 = new Persona() { Nombre = "Chaly", Apellido = "Garcia", Dni = "22374455", Email = "Cgarcia@gmail.com" };
            Persona persona3 = new Persona() { Nombre = "Gustavo", Apellido = "Cerati", Dni = "12374455", Email = "Cerati@gmail.com" };
            Persona persona4 = new Persona() { Nombre = "Astor", Apellido = "Piazolla", Dni = "22884455", Email = "¨Piazolla@gmail.com" };
            Persona persona5 = new Persona() { Nombre = "Miguel", Apellido = "Mateos", Dni = "26374455", Email = "¨Mateos@gmail.com" };
            _personas.Add(persona);
            _personas.Add(persona2);
            _personas.Add(persona3);
            _personas.Add(persona4);
            _personas.Add(persona5);
        }

        public List<Persona> Personas
        {

            get { return _personas; }
            set { _personas = value; }

        }
    }
}

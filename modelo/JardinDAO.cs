using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jardines.modelo
{
    public class JardinDAO
    {
        ORMDataContext BD = new ORMDataContext("Data Source=BOGAPRCSFFSD111;Initial Catalog=bdprueba;Integrated Security=True");
        public void registrar(Jardin jardin)
        {
            
            BD.Jardin.InsertOnSubmit(jardin);
            BD.SubmitChanges();//Guardar los cambios


        }

        public Object consultarTodos()
        {

            return from J in BD.Jardin
                   select J;
        }

        public void eliminar(int idJardin)
        {
            Jardin jardinEliminar= consultarJardinId(idJardin);
            BD.Jardin.DeleteOnSubmit(jardinEliminar);
            BD.SubmitChanges();
        }

        public void editar(Jardin jardin)
        {
            Jardin jardinEditar= consultarJardinId(jardin.idJardin);

            jardinEditar.nombre = jardin.nombre;
            jardinEditar.direccion = jardin.direccion;
            jardinEditar.estado=jardin.estado;
            BD.SubmitChanges();
        }

        public Jardin consultarJardinId(int idJardin)
        {
            return (from J in BD.Jardin
                    where J.idJardin == idJardin
                    select J).FirstOrDefault();
        }

        public bool validarNombre(string nombre)
        {
            Jardin nombreJardin = (from J in BD.Jardin
                          where J.nombre == nombre
                          select J).FirstOrDefault();
            if (nombreJardin != null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


    }
}
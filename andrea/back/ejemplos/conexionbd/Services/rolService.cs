using conexionbd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionbd.Services
{
    public class rolService
    {
        ReciplastkContext bd = new ReciplastkContext();
        public void createRole()
        {
            Console.WriteLine("write the role you want to enter");
            var rol = new Rol();
            rol.Name = Console.ReadLine();
            var existsRol = exists(rol.Name);
            if (existsRol == null)
            {
                bd.Add(rol);
                bd.SaveChanges();
                Console.WriteLine("rol created sucessful");
            }
            else
            {
                Console.WriteLine("the role already exists");
                createRole();
            }
        }

        public void editRole()
        {
            Console.WriteLine("write the role you want to edit");
            var rol = new Rol();
            rol.Name = Console.ReadLine();
            var existsRol = exists(rol.Name);
            if (existsRol != null)
            {
                existsRol.Name = rol.Name;
                bd.SaveChanges();
                Console.WriteLine("rol edited sucessful");
            }
            else
            {
                Console.WriteLine("the role not exists");
                editRole();
            }
        }

        public void deleteRole()
        {
            Console.WriteLine("write the role you want to delete");
            var rol = new Rol();
            rol.Name = Console.ReadLine();
            var existsRol = exists(rol.Name);
            if (existsRol != null)
            {
                bd.Remove(existsRol);
                bd.SaveChanges();
                Console.WriteLine("rol deleted sucessful");
            }
            else
            {
                Console.WriteLine("the role not exists");
                editRole();
            }
        }

        public void leerRol()
        {
           var rol =  bd.Rols.ToList();
            foreach (var item in rol)
            {
                Console.WriteLine(item.Name);
            }
        }

        public Rol exists(string name)
        {
            var exists = bd.Rols.Where(x=> x.Name == name).FirstOrDefault();
            return exists;
        }
    }
}

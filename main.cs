using System;
using System.Collections.Generic;
using System.Linq;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}

class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleados();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    MostrarMenuReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo del programa.");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    public void AgregarEmpleado()
    {
        Console.WriteLine("Ingrese los datos del empleado:");
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Salario: ");
        double salario = double.Parse(Console.ReadLine());

        empleados.Add(new Empleado(cedula, nombre, direccion, telefono, salario));
        Console.WriteLine("Empleado agregado con éxito.");
    }

    public void ConsultarEmpleados()
    {
        Console.Write("Ingrese la cédula del empleado a consultar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = empleados.Find(e => e.Cedula == cedula);

        if (empleado != null)
        {
            Console.WriteLine("Empleado encontrado:");
            Console.WriteLine($"Cédula: {empleado.Cedula}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Dirección: {empleado.Direccion}");
            Console.WriteLine($"Teléfono: {empleado.Telefono}");
            Console.WriteLine($"Salario: {empleado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void ModificarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = empleados.Find(e => e.Cedula == cedula);

        if (empleado != null)
        {
            Console.WriteLine("Ingrese los nuevos datos del empleado:");
            Console.Write("Nombre: ");
            empleado.Nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Salario: ");
            empleado.Salario = double.Parse(Console.ReadLine());
            Console.WriteLine("Empleado modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void BorrarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = empleados.Find(e => e.Cedula == cedula);

        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado con éxito.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void InicializarArreglos()
    {
        empleados.Clear();
        Console.WriteLine("Arreglos inicializados.");
    }

    public void MostrarMenuReportes()
    {
        while (true)
        {
            Console.WriteLine("Menú de Reportes");
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ConsultarEmpleados();
                    break;
                case 2:
                    ListarEmpleadosPorNombre();
                    break;
                case 3:
                    CalcularPromedioSalarios();
                    break;
                case 4:
                    CalcularSalarioExtremo();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    public void ListarEmpleadosPorNombre()
    {
        var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
        Console.WriteLine("Lista de empleados ordenados por nombre:");
        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
        }
    }

    public void CalcularPromedioSalarios()
    {
        double promedio = empleados.Average(e => e.Salario);
        Console.WriteLine($"El promedio de los salarios es: {promedio}");
    }

    public void CalcularSalarioExtremo()
    {
        double salarioMaximo = empleados.Max(e => e.Salario);
        double salarioMinimo = empleados.Min(e => e.Salario);
        Console.WriteLine($"Salario más alto: {salarioMaximo}");
        Console.WriteLine($"Salario más bajo: {salarioMinimo}");
    }
}

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.MostrarMenu();     
}
  }


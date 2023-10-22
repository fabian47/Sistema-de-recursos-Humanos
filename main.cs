using System;
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
    private Empleado[] empleados = new Empleado[100]; // Tamaño fijo del arreglo
    private int cantidadEmpleados = 0;

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
        if (cantidadEmpleados < empleados.Length)
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

            empleados[cantidadEmpleados] = new Empleado(cedula, nombre, direccion, telefono, salario);
            cantidadEmpleados++;
            Console.WriteLine("Empleado agregado con éxito.");
        }
        else
        {
            Console.WriteLine("No se pueden agregar más empleados. El arreglo está lleno.");
        }
    }

    public void ConsultarEmpleados()
    {
        Console.Write("Ingrese la cédula del empleado a consultar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = null;

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            if (empleados[i].Cedula == cedula)
            {
                empleado = empleados[i];
                break;
            }
        }

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
        Empleado empleado = null;

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            if (empleados[i].Cedula == cedula)
            {
                empleado = empleados[i];
                break;
            }
        }

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
        int indiceBorrar = -1;

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            if (empleados[i].Cedula == cedula)
            {
                indiceBorrar = i;
                break;
            }
        }

        if (indiceBorrar != -1)
        {
            for (int i = indiceBorrar; i < cantidadEmpleados - 1; i++)
            {
                empleados[i] = empleados[i + 1];
            }
            cantidadEmpleados--;
            Console.WriteLine("Empleado borrado con éxito.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void InicializarArreglos()
    {
        empleados = new Empleado[100];
        cantidadEmpleados = 0;
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
        // Ordenar los empleados por nombre utilizando un algoritmo de ordenamiento, como el método de la burbuja.
        for (int i = 0; i < cantidadEmpleados - 1; i++)
        {
            for (int j = i + 1; j < cantidadEmpleados; j++)
            {
                if (string.Compare(empleados[i].Nombre, empleados[j].Nombre) > 0)
                {
                    // Intercambiar empleados si están fuera de orden
                    Empleado temp = empleados[i];
                    empleados[i] = empleados[j];
                    empleados[j] = temp;
                }
            }
        }

        Console.WriteLine("Lista de empleados ordenados por nombre:");
        for (int i = 0; i < cantidadEmpleados; i++)
        {
            Console.WriteLine($"Nombre: {empleados[i].Nombre}, Cédula: {empleados[i].Cedula}");
        }
    }

    public void CalcularPromedioSalarios()
    {
        if (cantidadEmpleados == 0)
        {
            Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            return;
        }

        double sumaSalarios = 0;
        for (int i = 0; i < cantidadEmpleados; i++)
        {
            sumaSalarios += empleados[i].Salario;
        }

        double promedio = sumaSalarios / cantidadEmpleados;
        Console.WriteLine($"El promedio de los salarios es: {promedio}");
    }

    public void CalcularSalarioExtremo()
    {
        if (cantidadEmpleados == 0)
        {
            Console.WriteLine("No hay empleados para calcular el salario más alto y más bajo.");
            return;
        }

        double salarioMaximo = empleados[0].Salario;
        double salarioMinimo = empleados[0].Salario;

        for (int i = 1; i < cantidadEmpleados; i++)
        {
            if (empleados[i].Salario > salarioMaximo)
            {
                salarioMaximo = empleados[i].Salario;
            }
            if (empleados[i].Salario < salarioMinimo)
            {
                salarioMinimo = empleados[i].Salario;
            }
        }

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

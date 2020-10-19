using System;
using System.IO;

namespace Tarea_4
{
    
    class Program
    {
        static void Main(string[] args)
        {
            menu miMenu = new menu();
            miMenu.MenuFiguras();
        }
    }

    public class menu
    {
        

        public enum Opciones
        {
            TRIANGULO = 1, CUADRADO, CIRCULO
        }
        public int Opcion ;
        public void MenuFiguras()
        {
            Console.WriteLine("Elija la figura que desea calcular su area: \n 1- Triangulo\n 2- Cuadrado\n 3- Circulo");
            
            Opcion = Convert.ToInt32(Console.ReadLine());
            

            switch (Opcion)
            {
                case (int) Opciones.TRIANGULO:
                    {
                        Triangulo miTriangulo = new Triangulo();
                        miTriangulo.SetBase();
                        miTriangulo.SetAltura();
                        miTriangulo.CalcularArea();
                    }
                        break;
                case (int)Opciones.CIRCULO:
                    {
                        Circulo miCirculo = new Circulo();
                        miCirculo.SetRadio();
                        miCirculo.CalcularArea();
                    }
                    break;
                case (int)Opciones.CUADRADO:
                    {
                        Cuadrado miCuadrado = new Cuadrado();
                        miCuadrado.SetLado();
                        miCuadrado.CalcularArea();
                    }
                    break;
            }
        }

    }
    public class Figura
    {
        private double Area { get; set; }


        public virtual double CalcularArea()
        {
            Area = Convert.ToDouble(Console.ReadLine());
            return Area;
        }

    }
    public class Triangulo : Figura, Iguardar
    {
        public double Area;
        public double Base;
        public double Altura;

        public void Guardar()
        {

            Console.WriteLine($"Desea guardar su resultado ?\n 1- Si\n 2- No");
            int guardado = Convert.ToInt32(Console.ReadLine());
            switch (guardado)
            {
                case 1:
                    {
                        TextWriter archivo;
                        archivo = new StreamWriter("archivo.txt");
                        var DatoArea = Area;
                        var DatoBase = Base;
                        var DatoAltura = Altura;

                        archivo.WriteLine(DatoArea);
                        archivo.WriteLine(DatoBase);
                        archivo.WriteLine(DatoAltura);

                        Console.WriteLine("Los datos se guardaron correctamente");
                        Console.ReadKey();
                        Console.Clear();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();

                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"Pase buen resto del dia");
                        Console.ReadKey();
                        Console.Clear();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();
                    }
                    break;
            }
        }

        public void SetBase()
        {
            Console.WriteLine("Valor de la base");
            Base = Convert.ToDouble(Console.ReadLine());
        }
        public void SetAltura()
        {
            Console.WriteLine("Valor altura");
            Altura = Convert.ToDouble(Console.ReadLine());
        }
        public override double CalcularArea()
        {
            Area = Base * Altura;
            Console.WriteLine($"El area del triangulo es: {Area}");
            Guardar();
            return Area;
        }

    }
    public class Cuadrado : Figura, Iguardar
    {
        public double Area;
        public double Lado;

        public void SetLado()
        {
            Console.WriteLine("Inserte la medida de un lado");
            Lado = Convert.ToDouble(Console.ReadLine());
        }

        public override double CalcularArea()
        {
            Area = Lado * Lado;
            Console.WriteLine($"El area del cuadrado es: {Area}");
            Guardar();
            return Area;
        }
        public void Guardar()
        {

            Console.WriteLine($"Desea guardar su resultado ?\n 1- Si\n 2- No");
            int guardado = Convert.ToInt32(Console.ReadLine());
            switch (guardado)
            {
                case 1:
                    {
                        TextWriter archivo;
                        archivo = new StreamWriter("archivo.txt");
                        var DatoLado = Lado;
                        archivo.WriteLine(Lado);
                        archivo.WriteLine(Area);
                        Console.WriteLine("Los datos se guardaron satisfactoriamente.");
                        Console.ReadKey();
                        Console.Clear();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"Pase buen resto del dia");
                        Console.ReadKey();
                        Console.Clear();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();
                    }
                    break;
            }
        }
    }
    public class Circulo : Figura, Iguardar
    {
        public double Radio;
        const double Pi = 3.14;
        public double Area;

        public void Guardar()
        {

            Console.WriteLine($"Desea guardar su resultado ?\n 1- Si\n 2- No");
            int guardado = Convert.ToInt32(Console.ReadLine());
            switch (guardado)
            {
                case 1:
                    {
                        TextWriter archivo;
                        archivo = new StreamWriter("archivo.txt");
                        archivo.WriteLine(Radio);
                        archivo.WriteLine(Area);
                        Console.WriteLine("Los datos se guardaron satisfactoriamente");
                        Console.ReadKey();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();

                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"Pase buen resto del dia");
                        Console.ReadKey();
                        Console.Clear();
                        menu menuvolver = new menu();
                        menuvolver.MenuFiguras();
                    }
                    break;
            }
        }

        public void SetRadio()
        {
            Console.WriteLine("Inserte el radio del circulo: ");
            Radio = Convert.ToDouble(Console.ReadLine());
        }

        public override double CalcularArea()
        {
            Area = 2 * Pi * Radio;
            Console.WriteLine($"El area del circulo es: {Area}");
            Guardar();
            return Area;
        }
    }
    interface Iguardar
    {
        public void Guardar();
    }

}

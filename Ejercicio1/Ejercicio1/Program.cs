using System;

namespace Ejercicio1
{

    class Program
    {
        
        static void Main(string[] args)
        {
            //interfaz
            var saludoMensaje = new EnviarSaludo();
            InvocarSaludo(saludoMensaje,"PRUEBA");

            //parametros de tipo
            var parametros = new ParameterType<int, string>();
            parametros.PropertyOne = 1;
            parametros.PropertyTwo = "PropertyTwo";
            Console.WriteLine(parametros.PropertyOne +" "+ parametros.PropertyTwo);

            //clase base
            rayoMcQueen2 E = new rayoMcQueen2();
            E.sayProperty();

            //enum
            var numerosEnum1 = numeros.num1;
            var numerosEnum2 = numeros.num2;

            //valor nullable
            int? NullableInt = 1;

            Console.Read();
        }

        public static void InvocarSaludo(ISaludo mensaje, string contenidoSaludo)
        {
            mensaje.MensajeSaludo(contenidoSaludo);
        }

    }
    class EnviarSaludo: ISaludo
    {
        public void MensajeSaludo(string saludo)
        {
            Console.WriteLine("Saludos");
        }
    }
    interface ISaludo
    {
        void MensajeSaludo(string contenidoSaludo);
    }

    /******************PARAMETROS DE TIPO******************************/
    public class ParameterType<one,two>
    {
        public one PropertyOne { get; set; }
        public two PropertyTwo { get; set; }
    }

    /*********************CLASES BASE*******************************/
    public class rayoMcQueen
    {
       
        public string color = "rojo";

        public virtual void sayProperty()
        {
            Console.WriteLine("Color: {0}", color);
            
        }
    }
    class rayoMcQueen2 : rayoMcQueen
    {
        public string frase = "qchao";
        public override void sayProperty()
        {
            
            base.sayProperty();
            Console.WriteLine("Frase: {0}", frase);
        }
    }
    /***************ENUM***********************/
    [Flags]
    public enum numeros
    {
        num1 = 1,
        num2 = 2

    }
    

}

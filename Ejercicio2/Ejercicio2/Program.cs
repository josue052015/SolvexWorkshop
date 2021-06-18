using System;
using System.Collections.Generic;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            /**********PROPIEDADES**********/

            var Carros = new List<string>();
            Carros.Capacity = 100;
            Carros.Add("Mercedez");
            int Counter = Carros.Count;
            Console.WriteLine("La cuenta de la lista es: " + Counter);

            /*******PARAMETRO DE REFERENCIA*******/
            string Value = "Soy un valor de referencia";
            referenceMethod(ref Value);
            Console.WriteLine(Value);

            //resultado del outparameter
            ShowSuma();

            // array parameter
            int[] numberList = { 5, 6, 7, 8, 9 };
            arrayParameters(numberList);

            Console.Read();

        }
        /**************ARRAY PARAMETER CON FOR y metodo protected*****************/
        protected static void arrayParameters(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " - ");
            }

        }

        static void referenceMethod(ref string refParameter)
        {
            refParameter = refParameter + " " + "ha sido referenciado";
        }

        /******OUTPUT PARAMETERS***************/

       public static void suma(int num1,int num2, out int result)
        {
           
            result = num1 + num2;
        }

       public static void ShowSuma()
        {
            suma(1,6, out int res);
            Console.WriteLine("El resultado de la suma es: " + res);
        }

       

    }

    /*********************Abstract method*****************/

    public abstract class music
    {
        public abstract string play(string Lyric);
    }

    public class Regaetton : music
    {
        string _lyric;
        public Regaetton(string lyric) => _lyric = lyric;
        public override string play(string lyric)
        {
            return "Sabes que somos de calle";
        }
    }
    /****************FIELD****************/
    public class colores
    {
        public string color1;
        public string color2;

        private colores(string primerColor, string segundoColor)
        {
            color1 = primerColor;
            color2 = segundoColor;
        }

        /***********METODO SIMPLE****************/
        public int MetodoSimple() => 1;

        
    }

    public class buclesYcondiciones
    {
       
       public static void WHILE()
        {
            int Num = 0;
            int Final = 5;
            while(Num <= Final)
            {
                Console.WriteLine("sigo estando en el while");
            }
        }

        public static void IF()
        {
            int number1 = 20;
            int Number2 = 15;

            if(number1 < Number2)
            {
                Console.WriteLine("soy menor");
            }else if (number1 == Number2)
            {
                Console.WriteLine("soy igual");
            }
            else
            {
                Console.WriteLine("soy mayor");
            }
        }
        
    }

    /****************VIRTUAL Y OVERRIDED METHOD********************/
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
    
    /***************************Method overloading**************************/
    public class overload
    {
        static void Value() => Console.WriteLine("Exito");
        static void Value(int x) => Console.WriteLine("Value(int)");
        public static void Use()
        {
            Value();
            Value(76);
        }
    }
   

}

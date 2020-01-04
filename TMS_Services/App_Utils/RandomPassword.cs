using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TMS_Services.App_Utils
{
    public class RandomPassword
    {
        public RandomPassword() { }
        // Generate a random number between two numbers    
        public static int randomNumber(int min, int max)
            => new Random().Next(min, max);

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        // generar caracteres randomicamente (de acuerdo a una bandera)
        // o alternar con los rangos de la codificacion ASCII
        public static string randomString(int size, bool mixCharacters)
        {
            StringBuilder builder = new StringBuilder();
            int[] initRanges = { 97, 65 }; // minusculas y mayusculas
            int initRangeSelected = initRanges[0];
            int letterCount = 26;
            Random random = new Random(); // generar aleatorios
            for (int i = 0; i < size; i++)
            {
                if (mixCharacters)
                {
                    initRangeSelected = initRanges[random.Next(0, 2)];
                }
                builder.Append(Convert.ToChar((int)(Math.Floor(letterCount * random.NextDouble() + initRangeSelected))));
            }
            return builder.ToString();
        }

        // Generate a random password of a given length (optional)  -> 10 Caracteres Por defectp
        public static string randomPassword(int size = 0, bool acceptToUpper = false)
        => new StringBuilder()
                .Append(randomString(4, acceptToUpper))
                .Append(randomNumber(1000, 9999)) // 4 digitos
                .Append(randomString(2, acceptToUpper))
                .ToString();

    }
}
using System.Collections.Generic;

namespace DrelloProject.Models
{
    public static class ColorList
    {
        public static List<string> Colors = new List<string>() 
        { 
            "#E1B16A",
            "#78A5A3",
            "#CE5A57",
            "#444C5C",
            "#003B46",
            "#07575B",
            "#66A5AD",
            "#128277",
            "#52958B",
            "#6EB5C0",
            "#006C84",
            "#AEBD38",
            "#598234",
            "#68829E",
            "#F9DC24",
            "#EE693F",
            "#AA4B41",
            "#763626",
            "#F34A4A",
        };

        public static string GetRandomColor() 
        { 

            Random rand = new Random();
            int index = rand.Next(Colors.Count);
            string randomElement = Colors[index];

            return randomElement;
        }
    }
}

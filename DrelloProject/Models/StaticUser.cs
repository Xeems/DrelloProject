using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public static class StaticUser
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string ShortUserName { get; set; }
        public static Color UserColor { get; set; }
        public static string jwtToken { get; set; }

    }
}

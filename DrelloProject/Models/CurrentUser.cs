using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public static class CurrentUser
    {
        public static int id {get; set;}
        public static string name { get; set; }
        public static string login { get; set; }
        public static string password{ get; set; }
    }
}

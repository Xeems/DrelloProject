using System.ComponentModel.DataAnnotations.Schema;

namespace DrelloProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ShortName { get; set; }
        public string Login { get; set; }
        public string UserHEXColor { get; set; }
        public string Password { get; set; }

        private string GetShortName(string userName) 
        {
            string shortName = null;
            
            for (int i = 0; i < userName.Length; i++)
            {
                if (Char.IsUpper(userName[i]))
                {
                    shortName += userName[i];
                }
                if(shortName.Length == 2 )
                    return shortName; 
            }
            return shortName;
        }
    }
}

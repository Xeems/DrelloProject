using System.ComponentModel.DataAnnotations.Schema;

namespace DrelloProject.Models
{
    public class User
    {
        public int Id { get; set; }
 
        private string userName;
        public string UserName 
        {
            get { return userName; }
            set
            {
                userName = value;
                if (userName != null) 
                    GetShortName(userName);
            }
        }
        public string ShortName { get; set; }
        public string Login { get; set; }
        public string UserHEXColor { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public void GetShortName(string Name) 
        {
            string shortName = "";
            
            for (int i = 0; i < Name.Length; i++)
            {
                if (Char.IsUpper(Name[i]))
                {
                    shortName += Name[i];
                }
                if(shortName.Length == 2 )
                    ShortName = shortName;
            }
            if(shortName.Length == 0)
                ShortName = new string(UserName.Take(2).ToArray());

        }
    }
}

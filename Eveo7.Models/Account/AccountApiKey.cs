using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Eveo7.Models.Account
{
    public class AccountApiKey
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int KeyId { get; set; }
        public string VCode { get; set; }

        public List<AccountCharacter> Characters { get; set; }

        public AccountApiKey()
        {
            Characters = new List<AccountCharacter>();
        }
    }
}

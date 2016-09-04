using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eveo7.Models.Account
{
    public class AccountCharacter
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int AccountId { get; set; }
        public int AccountKeyId { get; set; }
        public string CharacterName { get; set; }
        public bool IsAdded { get; set; }
    }
}

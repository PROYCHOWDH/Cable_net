using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = default!;
        public DateTime ExpiryDate { get; set; }
        public string UserName { get; set; } = default!;
        public bool IsRevoked { get; set; }
    }
}

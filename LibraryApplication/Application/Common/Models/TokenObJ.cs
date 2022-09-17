using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class TokenObJ
    {
        public string Token { set; get; }
        public string RefreshTokenKey { set; get; }
        public Guid Id { set; get; }

        public long TokenExpirationTime { set; get; }
    }
}

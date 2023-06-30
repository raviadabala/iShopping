using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Dto.Account
{
    public record UserReadDto
    {
        public string UserName { get; set; } = default!;
        public string KnownAs { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}

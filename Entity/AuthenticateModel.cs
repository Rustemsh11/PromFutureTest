using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public record AuthenticateModel
    {
        public string? Url { get; init; }
        public string? Login { get; init;}
        public string? Password { get; init; }
    }
}

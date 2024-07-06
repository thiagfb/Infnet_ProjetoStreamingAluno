using Streaming.Domain.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Admin.Aggregates
{
    public class UsuarioAdmin
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public Perfil Perfil { get; set; }

        public void CriptografarSenha()
        {
            this.Password = this.Password.EncryptPassword();
        }
    }
}

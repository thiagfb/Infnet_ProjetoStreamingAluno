using Streaming.Application.Transacao.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Conta.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Telefone { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }

        public Guid PlanoId { get; set; }

        [Required]
        //public CartaoDto Cartao { get; set; }
        public String Cartao { get; set; }
    }
}

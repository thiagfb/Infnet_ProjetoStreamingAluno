using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Transacao.Dto
{
    public class BandeiraDto
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }
    }
}

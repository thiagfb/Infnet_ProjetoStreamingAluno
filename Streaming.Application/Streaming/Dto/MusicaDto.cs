using Streaming.Domain.Streaming.Aggregates;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Application.Streaming.Dto
{
    public class MusicaDto
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Título é obrigatório")] 
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Gênero obrigatório")]
        public Guid GeneroId { get; set; }

        [Required(ErrorMessage = "Compositor é obrigatório")]
        public Guid Compositorid { get; set; }

        [Required(ErrorMessage = "Letra é obrigatória")]
        public String Letra { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime? DataComposicao { get; set; }

        public Genero Genero { get; set; } = new Genero();

        public Compositor Compositor { get; set; } = new Compositor();
    }
}

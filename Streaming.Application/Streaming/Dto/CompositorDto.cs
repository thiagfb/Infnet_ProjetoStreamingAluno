﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Streaming.Dto
{
    public class CompositorDto
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }
    }
}

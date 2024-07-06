﻿using AutoMapper;
using Streaming.Application.Admin.Dto;
using Streaming.Domain.Admin.Aggregates;
using Streaming.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Admin
{
    public class UsuarioAdminService
    {
        private UsuarioAdminRepository Repository { get; set; }
        private IMapper mapper { get; set; }
        public UsuarioAdminService(UsuarioAdminRepository repository, IMapper mapper)
        {
            Repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<UsuarioAdminDto> ObterTodos()
        {
            var result = this.Repository.GetAll();
            return this.mapper.Map<IEnumerable<UsuarioAdminDto>>(result);
        }

        public void Salvar(UsuarioAdminDto dto)
        {
            var usuario = this.mapper.Map<UsuarioAdmin>(dto);
            usuario.CriptografarSenha();
            this.Repository.Save(usuario);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Alura.ByteBank.Dominio.Entidades;

namespace Alura.ByteBank.Dominio.Interfaces.Repositorios
{
  public interface IUsuarioRepositorio : IDisposable
  {
    public List<UsuarioApp> ObterTodos();
    public UsuarioApp ObterPorId(int id);
    public bool Adicionar(UsuarioApp usuario);
    public bool Atualizar(int id, UsuarioApp usuario);
    public bool Excluir(int id);
  }
}

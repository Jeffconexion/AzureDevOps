using System;
using Alura.ByteBank.Infraestrutura.Testes.DTO;

namespace Alura.ByteBank.Infraestrutura.Testes
{
  public interface IPixRepositorio
  {
    public PixDTO consultaPix(Guid pix);
  }
}

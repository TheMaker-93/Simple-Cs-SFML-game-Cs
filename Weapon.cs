using System;
using SFML.Graphics;
namespace TcGame
{

  // hacha <-- weapon <-- item      Orden de herencias
  // aqui aplicaremos metodos compartidos para todas las armas
  public abstract class Weapon : Item
  {
    public Weapon ()
    {
      
    }
  }
}

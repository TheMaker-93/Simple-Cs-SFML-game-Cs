using System;
using SFML.Graphics;
using SFML.Window;
namespace TcGame
{
  public class Bomb :Item
  {
    public Bomb ()
    {

      // le asignamos una textura
      Texture = new Texture ("Data/Textures/Bomb.png");

      // colocamos su origen en el centro 
      Origin = new Vector2f (GetLocalBounds ().Width / 2, GetLocalBounds ().Height / 2);
    }
  }
}

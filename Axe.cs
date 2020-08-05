using System;
using SFML.Graphics;
using SFML.Window;
namespace TcGame
{
  public class Axe : Weapon
  {
    public Axe ()
    {
      Texture = new Texture ("Data/Textures/Axe.png");

      // colocamos su origen en el centro 
      Origin = new Vector2f (GetLocalBounds ().Width / 2, GetLocalBounds ().Height / 2);
    }
  }
}

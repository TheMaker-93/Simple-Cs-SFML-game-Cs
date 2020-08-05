using System;
using SFML.Graphics;
using SFML.Window;
namespace TcGame
{
  public class Sword : Weapon
  {
    public Sword ()
    {
      Texture = new Texture ("Data/Textures/Sword.png");

      // colocamos su origen en el centro 
      Origin = new Vector2f (GetLocalBounds ().Width / 2, GetLocalBounds ().Height / 2);
    }
  }
}

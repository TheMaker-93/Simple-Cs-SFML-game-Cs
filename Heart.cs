using System;
using SFML.Graphics;
using SFML.Window;
namespace TcGame
{
  public class Heart :Item
  {
    public Heart ()
    {
      Texture = new Texture ("Data/Textures/Heart.png");

      // colocamos su origen en el centro 
      Origin = new Vector2f (GetLocalBounds ().Width / 2, GetLocalBounds ().Height / 2);
    }
  }
}

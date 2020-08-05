using System;
using SFML.Graphics;
using SFML.Window;
namespace TcGame
{
  public class Coin : Item
  {

    public Coin ()
    {

      Texture = new Texture ("Data/Textures/Coin.png");

      // colocamos su origen en el centro 
      Origin = new Vector2f (GetLocalBounds ().Width / 2, GetLocalBounds ().Height / 2);
    }


  }
}

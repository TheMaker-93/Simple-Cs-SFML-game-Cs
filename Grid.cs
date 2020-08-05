using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System;
namespace TcGame
{
  public class Grid : Drawable
  {
    /** Utility object for draw lines*/
    private LineDrawer lines;

    /** Columns of the grid*/
    private const int numColumns = 4;

    /** Rows of the grid*/
    private const int numRows = 3;

    /** List with all the items, it can contains null items*/
    private List<Item> items;

    private Texture backgroundTexture;
    private Sprite backgroundSprite;

    // mouse
    public Vector2i mousePos;



    /** Returns the with of a slot*/
    public float SlotWidth
    {
      get { return P1Game.ScreenSize.X / (float)numColumns; }
    }

    /** Return the height of a slot*/
    public float SlotHeight
    {
      get { return P1Game.ScreenSize.Y / (float)numRows; }
    }

    /** The max number of items that the grid can contains*/
    public int MaxItems
    {
      get { return numColumns * numRows; }
    }

    /** Initializes the grid*/
    public void Init()
    {
      backgroundTexture = new Texture("Data/Textures/Background.jpg");
      backgroundSprite = new Sprite(backgroundTexture);

      items = new List<Item>();

      FillGridLines();


    }

    /** Deinitializes the grid*/
    public void DeInit()
    {
      lines.DeInit();
    }

    /** Key callback for capture key input*/
    public void HandleKeyPressed(object sender, KeyEventArgs e)
    {
      if (e.Code == Keyboard.Key.Num8)
      {
        if (HasNullSlot())
        {
          AddItemAtIndex(NewRandomItem(), GetFirstNullSlot());
        }
        else
        {
          AddItemAtEnd(NewRandomItem());
        }
      }
      else if (e.Code == Keyboard.Key.Num7)
      {
        RemoveLastItem();
      }
      else if (e.Code == Keyboard.Key.Num6)
      {
        NullAllCoins();
      }
      else if (e.Code == Keyboard.Key.Num5)
      {
        ReverseItems();
      }
      else if (e.Code == Keyboard.Key.Num4)
      {
        RemoveNullSlots();
      }
      else if (e.Code == Keyboard.Key.Num3)
      {
        RemoveAllItems();
      }
      else if (e.Code == Keyboard.Key.Num2)
      {
        NullAllWeapons();
      }
      else if (e.Code == Keyboard.Key.Num1)
      {
        OrderItems();
      }
    }


    public void MousePresed (object sender, MouseButtonEventArgs m)
    {
     
      for (int i = 0; i < items.Count; i++) {
        // 

        if (m.Button == Mouse.Button.Right) {
          if (items [i] != null) {
            if (items [i].GetGlobalBounds ().Contains (mousePos.X, mousePos.Y)) {
              Console.WriteLine (items [i]);


              // si el objeto es una bomba ademas de desparecer ella
              if (items [i].GetType () == typeof (Bomb)) {

                // encima
                if (!(i / 4 >= 2 || items [i] == null)) items [i + 4] = null;
                // debajo
                if (!(i / 4 <= 0 || items [i] == null)) items [i - 4] = null;
                // izuierdda
                if (!(i % 4 == 0 || items [i] == null)) items [i - 1] = null;
                // derecha
                if (!(i % 4 >= 3 || items [i] == null)) items [i + 1] = null;


                // desparecera el 
                items [i] = null;

              } else { // cualqueir otra cosa se borra ella sola
                items [i] = null;
              }

            }
          }
        }


         
      }

      Console.WriteLine ("Mouse Pressed at coords: " + mousePos);
    }


    /** Initializes the lineDrawer with the lines of the grid*/
    private void FillGridLines()
    {
      lines = new LineDrawer(numColumns + numRows + 2);
      lines.Init();

      for (int i = 0; i <= numColumns; ++i)
      {
        lines.AddLine(new Vector2f(i * SlotWidth, 0.0f), new Vector2f(i * SlotWidth, P1Game.ScreenSize.Y), new Color(0, 0, 0, 150), 2.0f);
      }

      for (int i = 0; i <= numRows; ++i)
      {
        lines.AddLine(new Vector2f(0.0f, i * SlotHeight), new Vector2f(P1Game.ScreenSize.X, i * SlotHeight), new Color(0, 0, 0, 150), 2.0f);
      }
    }

    public void Update(float dt)
    {
      // mousePos = new Vector2f (rw.InternalGetMousePosition().X,rw.InternalGetMousePosition().Y); 


      // rw.DispatchEvents ();


      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write (mousePos);
      Console.ResetColor ();

      // Update the item position based on his grid row and column
      for (int i = 0; i < items.Count; ++i)
      {
        int row = i / numColumns;
        int column = i % numColumns;

        Vector2f position = new Vector2f(SlotWidth / 2.0f + SlotWidth * column, SlotHeight / 2.0f + SlotHeight * row);
        Item item = items[i];
        if (item != null)
        {
          item.Position = position;
        }
      }
    }

    public void Draw(RenderTarget rt, RenderStates rs)
    {
      rt.Draw(backgroundSprite, rs);
      rt.Draw(lines, rs);

      foreach (Item item in items)
      {
        if (item != null)
        {
          rt.Draw(item, rs);
        }
      }
    }

    /** Creates and returns a new random object of type Bomb, Heart, Sword, Axe or Coin*/
    private Item NewRandomItem()
    {
      //TO DO: Exercise 2
      Random alea = new Random();
      int value = alea.Next (0, 5);
      Item it = null;

      switch (value) {
        case 0: it = new Bomb ();   break;
        case 1: it = new Heart ();  break;
        case 2: it = new Sword ();  break;
        case 3: it = new Axe ();    break;
        case 4: it = new Coin();    break;
        default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine ("Ya has roto algo, mira la creacion de elementos aleatoria");
        Console.ResetColor ();
        break;
      }

      Console.WriteLine (it.GetType());

      return it;
    }

    /** Removes the last item of the items list*/
    private void RemoveLastItem()
    {
      //TO DO: Exercise 3

      if (items.Count > 0) {
        items.RemoveAt (items.Count - 1);
      } else {
        
      }

    }

    /** Removes all coins of the grid, but his slots must remain empty*/
    private void NullAllCoins ()
    {
      //TO DO: Exercise 4

      // para borrar todas las monedas preguntando por su tipo
      // items.RemoveAll(x => x.GetType().ToString() == "TcGame.Coin");

      for (int i = 0; i < items.Count; ++i) {
        if (items [i] != null) {
          if (items[i].GetType() == typeof(Coin)) {
            items [i] = null;
          }
        }
      }
    }

    /** Remove the holes in the grid*/
    private void RemoveNullSlots()
    {
      //TO DO: Exercise 7
      for (int i = 0; i < items.Count; i++) {
        if (items [i] == null) {
          items.RemoveAt (i);
        }
      }


    }

    /** Remove all items in the grid*/
    private void RemoveAllItems()
    {
      //TO DO: Exercise 7
      items.RemoveAll (x => x != null);
    }

    /** Removes all weapons of the grid, but his slots must remain empty*/
    private void NullAllWeapons()
    {
      //TO DO: Exercise 8
      // primero borramos todas las armas preguntando por su tipo
      // items.RemoveAll(x => x.GetType().ToString () == "TcGame.Axe");
      // items.RemoveAll(x => x.GetType().ToString () == "TcGame.Sword");

      // iteramos por todas las posiciones de la lista
      for (int i = 0; i < items.Count; i++) {
        if (items [i] != null) {
          if (items [i].GetType () == typeof (Axe)) {               // si el elemento es de tipo hacha lo hacemos nulo
            items [i] = null;         
          } else if (items [i].GetType () == typeof (Sword)) {      // lo mismo pasa con el elemento tipo espada
            items [i] = null;
          }
        }
      }

    }

    /** Return true if there is a hole in the grid*/
    private bool HasNullSlot()
    {
      //TO DO: Exercise 4
      for (int i = 0; i < items.Count; ++i) {
        if (items [i] == null) {
          Console.WriteLine ("return TRUE null slot" + i);
          return true;

        }
      }

      Console.WriteLine ("return FALSE null slot");
      return false;
    }

    /** Returns the index of the first hole in the grid*/
    private int GetFirstNullSlot()
    {
      //TO DO: Exercise 4

      for (int i = 0; i < items.Count; i++) {
        if (items [i] == null) {
          items.RemoveAt (i);
          return i;
        }
      }


      return 0;
    }

    /** Adds Item to the grid at the given index*/
    private void AddItemAtIndex(Item item, int index)
    {
      //TO DO: Exercise 5
      items.Insert (index, item);
    }

    /** Adds the item to the end of the items list*/
    /*
     Implementa el método AddItemAtEnd que debe añadir el elemento pasado 
     como parámetro al final de la lista de items. 
     En este momento debes de ser capaz de añadir Items pulsando la tecla 1.
     */
    private void AddItemAtEnd(Item item)
    {
      items.Add (item);
    }

    /** Sort the grid:
     *    1º Hearts
     *    2º Weapons
     *    3º Bombs
     *    4º Coins
     */
    private void OrderItems()
    {
      //TO DO: Exercise 8

      byte lastScanedPosition;

      byte hearts = 0;
      byte axes = 0;
      byte swords = 0;
      byte bombs = 0;
      byte coins = 0;

      List<int> swordIndexs = new List<int> ();
      List<int> heartsIndexs = new List<int> ();
      List<int> axeIndexs = new List<int>();
      List<int> bombIndexs = new List<int> ();
      List<int> coinIndexs = new List<int> ();
      

      // iteramos por to do el array para saber cuantos hay de cada y guardaremos sus indices
      for (lastScanedPosition = 0; lastScanedPosition < items.Count; lastScanedPosition++) {
        // contamos cuantos elementos hay de cada uno
        if (items [lastScanedPosition].GetType () == typeof (Heart)) {
          hearts++;
          heartsIndexs.Add (lastScanedPosition);
        } else if (items [lastScanedPosition].GetType () == typeof (Sword)) {
          swords++;
          swordIndexs.Add (lastScanedPosition);
        } else if (items [lastScanedPosition].GetType () == typeof (Axe)) {
          axes++;
          axeIndexs.Add (lastScanedPosition);
        } else if (items [lastScanedPosition].GetType () == typeof (Bomb)) {
          bombs++;
          bombIndexs.Add (lastScanedPosition);
        } else if (items [lastScanedPosition].GetType () == typeof (Coin)) {
          coins++;
          coinIndexs.Add (lastScanedPosition);
        }
      }

      items.Clear ();

      /*
      // colocamos los objetos en orden manualmente
      for (int cursor = 0; cursor < items.Count; cursor++) {
        // hearts
        if (items [cursor].GetType () == typeof (Heart)) {
          items.RemoveAt (cursor);                        // lo borramos de la poscion en la que este
          items.Insert (position, new Heart ());          // lo colocamos en la misma
          position++;                                     // añadimos 1 al dial de escritura para que ete determine donde escribir la proxima vez
        }

      }
      */

      // si sabemos cuantos hay de cada tan solo toca ponerlos en orden
      for (int i = 1; i <= hearts; i++) {
        items.Add (new Heart());
      }
      for (int i = 1; i <= swords; i++) {
        items.Add (new Sword ());
      }
      for (int i = 1; i <= axes; i++) {
        items.Add (new Axe ());
      }
      for (int i = 1; i <= bombs; i++) {
        items.Add (new Bomb ());
      }
      for (int i = 1; i <= coins; i++) {
        items.Add (new Coin ());
      }

    }

    /** Reverse all the items of the grid*/
    private void ReverseItems()
    {
      //TO DO: Exercise 6
      items.Reverse ();
    }


  }
}

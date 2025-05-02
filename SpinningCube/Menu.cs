using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public abstract class Menu
    {
        public int CurrentSelectedIndex { get; set; }
        public string? Name { get; set; }
        public int[] StartPosition { get; set; }
        public int Margin {  get; set; }
        public List<MenuElement> MenuElements { get; set; } = [];
        public ConsoleColor ElementTextColor { get; set;}
        public ConsoleColor ElementBackgroundColor { get; set; }
        public ConsoleColor BorderSelectionColor { get; set; }
        public ConsoleColor BorderActiveColor { get; set; }
        public ConsoleColor BorderInactiveColor { get; set; }
        public MenuTileSet TileSet { get; set; }
        public int widestElement { get; set; }
        public int highestElement { get; set; }
        public List<int> ElementsWidth { get; set; } = [];


        public Menu(string name, int[] startpoint, int margin, ConsoleColor elementTextColor, ConsoleColor elementBackgroundColor, ConsoleColor borderSelectionColor, ConsoleColor borderActiveColor, ConsoleColor borderInactiveColor = ConsoleColor.DarkGray)
        {
            Name = name;
            Margin = margin;
            StartPosition = startpoint;
            ElementTextColor = elementTextColor;
            ElementBackgroundColor = elementBackgroundColor;
            BorderSelectionColor = borderSelectionColor;
            BorderActiveColor = borderActiveColor;
            BorderInactiveColor = borderInactiveColor;
        }

        public void EraseMenu()
        {
            int xPos = StartPosition[0];
            int yPos = StartPosition[1];

            for (int i = 0; i < MenuElements[0].Height * MenuElements.Count + Margin * MenuElements.Count - 1; i++)
            {
                HelpSystems.PrintString(xPos, yPos, new string(' ', MenuElements[0].Width));
                yPos++;
            }
        }

        public abstract int[] CalculateElementPosition(int index);

        private int GetElementWithLongestText()
        {
            foreach (MenuElement element in MenuElements)
            {
                ElementsWidth.Add(element.Text.Length);
            }
            return ElementsWidth.Max();
        }

        public void DrawElement(int index, bool isActive)
        {
            int[] position = CalculateElementPosition(index);
            ConsoleColor borderColor;
            ConsoleColor elementBackgroundColor;
            if (index == CurrentSelectedIndex)
            {
                borderColor = BorderSelectionColor;
                elementBackgroundColor = BorderSelectionColor;
            } 
            else if (isActive)
            {
                borderColor = BorderActiveColor;
                elementBackgroundColor = ElementBackgroundColor;
            }
            else
            {
                borderColor = BorderInactiveColor;
                elementBackgroundColor = BorderInactiveColor;
            }

            widestElement = GetElementWithLongestText();
            MenuElements[index].Width = widestElement + MenuElements[index].PaddingX * 2 + 2;
            MenuElements[index].Height = 1 + MenuElements[index].PaddingY * 2 + 2;
            MenuElements[index].Draw(position[0], position[1], borderColor, ElementTextColor, elementBackgroundColor);
        }

        public virtual void Navigate(bool increment)
        {
            int previousIndex = CurrentSelectedIndex;
            if (increment)
                CurrentSelectedIndex = (CurrentSelectedIndex + 1) % MenuElements.Count;
            else
                CurrentSelectedIndex = (CurrentSelectedIndex == 0 ? MenuElements.Count : CurrentSelectedIndex) - 1;
            DrawElement(CurrentSelectedIndex, true);
            DrawElement(previousIndex, true);
        }

        public virtual void DrawMenu()
        {
            for (int i = 0; i < MenuElements.Count; i++)
            {
                DrawElement(i, true);
            }
        }
    }

    public class MenuElement
    {
        public string Text {  get; set; }
        public MyEnums.Positions TextPosition { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public int Width {  get; set; }
        public int Height {  get; set; }
        public int PaddingX { get; set; }
        public int PaddingY { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public MenuTileSet TileSet { get; set; }
        public int[] Position {  get; set; }
        public Action _action { get; set; }

        public MenuElement(
            string text,
            MenuTileSet menuTileSet,
            int paddingX,
            int paddingY,
            Action action,
            MyEnums.Positions textPosition = MyEnums.Positions.Centered,
            ConsoleColor textColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            ConsoleColor borderColor = ConsoleColor.White,
            bool isSelected = false, 
            bool isActive = true)
        { 
            Text = text;
            TileSet = menuTileSet;
            TextPosition = textPosition;
            TextColor = textColor;
            BackgroundColor = backgroundColor;
            BorderColor = borderColor;
            IsSelected = isSelected;
            IsActive = isActive;
            PaddingX = paddingX;
            PaddingY = paddingY;
            _action = action;
        }

        private void DrawTopBorder(int xPos, int yPos, ConsoleColor borderColor)
        {
            for (int i = 0; i < Width; i++)
            {
                if (i == 0)
                {
                    HelpSystems.PrintString(xPos, yPos, TileSet.CornerSignTopLeft.ToString(), borderColor);
                    xPos += 1;
                    continue;
                }
                if ( i == Width - 1)
                {
                    HelpSystems.PrintString(xPos, yPos, TileSet.CornerSignTopRight.ToString(), borderColor);
                    xPos += 1;
                    continue;
                }

                HelpSystems.PrintString(xPos, yPos, TileSet.TopBottomSign.ToString(), borderColor);
                xPos += 1;
            }
        }

        private void DrawBottomBorder(int xPos, int yPos, ConsoleColor borderColor)
        {
            for (int i = 0; i < Width; i++)
            {
                if (i == 0)
                {
                    HelpSystems.PrintString(xPos, yPos, TileSet.CornerSignBottomLeft.ToString(), borderColor);
                    xPos += 1;
                    continue;
                }
                if (i == Width - 1)
                {
                    HelpSystems.PrintString(xPos, yPos, TileSet.CornerSignBottomRight.ToString(), borderColor);
                    xPos += 1;
                    continue;
                }

                HelpSystems.PrintString(xPos, yPos, TileSet.TopBottomSign.ToString(), borderColor);
                xPos += 1;
            }
        }

        private void DrawLeftRightBorder(int xPos, int yPos, ConsoleColor borderColor, ConsoleColor backgroundColor)
        {
            for (int i = 0; i < Height - 2; i++)
            {
                HelpSystems.PrintString(xPos, yPos, TileSet.RightLeftSign.ToString(), borderColor);
                xPos += 1;
                HelpSystems.PrintString(xPos, yPos, new string(' ', Width - 2), backgroundColor, backgroundColor);
                xPos += Width - 2;
                HelpSystems.PrintString(xPos, yPos, TileSet.RightLeftSign.ToString(), borderColor);
                yPos += 1;
                xPos -= Width - 1;
            }
        }

        private void DrawText(int xPos, int yPos, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            switch (TextPosition)
            {
                case MyEnums.Positions.Top:
                    HelpSystems.PrintString(xPos + ((Width - Text.Length) / 2), yPos + 1, Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.Bottom:
                    HelpSystems.PrintString(xPos + ((Width - Text.Length) / 2), yPos + Height - 2, Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.Left:
                    HelpSystems.PrintString(xPos + 1, yPos + ((Height - 1) / 2), Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.Right:
                    HelpSystems.PrintString(xPos + Width - Text.Length - 1, yPos + ((Height - 1) / 2), Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.Centered:
                    HelpSystems.PrintString(xPos + ((Width - Text.Length) / 2), yPos + ((Height - 1) / 2), Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.TopLeft:
                    HelpSystems.PrintString(xPos + 1, yPos + 1, Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.TopRight:
                    HelpSystems.PrintString(xPos + 1 + PaddingX * 2, yPos + 1, Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.BottomLeft:
                    HelpSystems.PrintString(xPos + 1, yPos + PaddingY * 2 + 1, Text, textColor, backgroundColor);
                    break;
                case MyEnums.Positions.BottomRight:
                    HelpSystems.PrintString(xPos + 1 + PaddingX * 2, yPos + PaddingY * 2 + 1, Text, textColor, backgroundColor);
                    break;

                default:
                    throw new NotImplementedException();
            }

            yPos++;
        }

        public void Draw(int xPosition, int yPosition, ConsoleColor borderColor, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            DrawTopBorder(xPosition, yPosition, borderColor);
            yPosition += 1;
            DrawLeftRightBorder(xPosition, yPosition, borderColor, backgroundColor);
            yPosition += Height - 2;
            DrawBottomBorder(xPosition, yPosition, borderColor);
            yPosition -= Height - 1;
            DrawText(xPosition, yPosition, textColor, backgroundColor);
        }
    }

    public class HorizontalMenu : Menu
    {
        public HorizontalMenu(
            string name, 
            int[] startpoint, 
            int margin, 
            ConsoleColor elementTextColor,
            ConsoleColor elementBackgroundColor,
            ConsoleColor borderSelectionColor, 
            ConsoleColor borderActiveColor, 
            ConsoleColor borderInactiveColor = ConsoleColor.DarkGray
        ) : base(
            name, 
            startpoint, 
            margin, 
            elementTextColor, 
            elementBackgroundColor, 
            borderSelectionColor, 
            borderActiveColor, 
            borderInactiveColor) 
        { }

        public override int[] CalculateElementPosition(int index)
        {
            int xPos = StartPosition[0] + MenuElements.Take(index).Sum(m => m.Width + Margin);
            int yPos = StartPosition[1];
            return [xPos, yPos];
        }
    }

    public class VerticalMenu : Menu
    {
        public VerticalMenu(
            string name,
            int[] startpoint,
            int margin,
            ConsoleColor elementTextColor,
            ConsoleColor elementBackgroundColor,
            ConsoleColor borderSelectionColor,
            ConsoleColor borderActiveColor,
            ConsoleColor borderInactiveColor = ConsoleColor.DarkGray
        ) : base(
            name,
            startpoint,
            margin,
            elementTextColor,
            elementBackgroundColor,
            borderSelectionColor,
            borderActiveColor,
            borderInactiveColor)
        { }

        public override int[] CalculateElementPosition(int index)
        {
            int xPos = StartPosition[0];
            int yPos = StartPosition[1] + MenuElements.Take(index).Sum(m => m.Height + Margin);
            return [xPos, yPos];
        }
    }

    public class MenuTileSet
    {
        public char TopBottomSign { get; set; }
        public char RightLeftSign { get; set; }
        public char CornerSignTopLeft { get; set; }
        public char CornerSignTopRight { get; set; }
        public char CornerSignBottomLeft { get; set; }
        public char CornerSignBottomRight { get; set; }

        public MenuTileSet(char topBottomSign, char rightLeftSign, char cornerSignTopLeft, char cornerSignTopRight, char cornerSignBottomLeft, char cornerSignBottomRight)
        {
            TopBottomSign = topBottomSign;
            RightLeftSign = rightLeftSign;
            CornerSignTopLeft = cornerSignTopLeft;
            CornerSignTopRight = cornerSignTopRight;
            CornerSignBottomLeft = cornerSignBottomLeft;
            CornerSignBottomRight = cornerSignBottomRight;
        }

        public static MenuTileSet GetStandardMenuTileSet()
        {
            return new MenuTileSet('-', '|', 'O', 'O', 'O', 'O');
        }
    }



    /// Menu Arten:
    ///     
    ///     - Horizontal Menu
    ///     - Vertical Menu
    ///     - Dropdown Menu
    ///     - Hamburger Menu (Drei Striche Icon)
    ///     - Sidebar Menu
    ///     - Combinded Menu
    ///     - Sticky Header
    ///     

    /// Padding: Abstand zwischen Border und Text
    /// Margin: Abstand zwischen Border und Border
}

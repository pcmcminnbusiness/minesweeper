using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.IO;

namespace MineSweeperRefined
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        GameBoard daGameBoard = new GameBoard();
        bool gameStarted = false;
        Grid grid = new Grid();

        public MainWindow()
        {
            
        }

        private void daTestClick(object sender, RoutedEventArgs e)
        {
            this.Content = daGameBoard.getGrid();
        }
    }

    class GameBoard
    {
        Button[,] daButtonArray = new Button[16, 30];
        int xLocation = 200;
        int yLocation = 100;
        Grid grid = new Grid(); // when the start button is pressed set the window to the grid of the class. "this.Content = daGameBoard.grid"
        bool gameStarted = false;

        List<List<int>> daGameBoard = new List<List<int>>
        {
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        public GameBoard()
        {
            
            grid.Width = 2000;
            grid.Height = 1200;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;

            ColumnDefinition colDef0 = new ColumnDefinition();

            colDef0.Width = new GridLength(600, GridUnitType.Pixel);

            grid.ColumnDefinitions.Add(colDef0);
            for (int i = 0; i < 30; i++)
            {
                ColumnDefinition colDef1 = new ColumnDefinition();
                colDef1.Width = new GridLength(25, GridUnitType.Pixel);
                grid.ColumnDefinitions.Add(colDef1);
            }

            RowDefinition rowDef0 = new RowDefinition();

            rowDef0.Height = new GridLength(400, GridUnitType.Pixel);

            grid.RowDefinitions.Add(rowDef0);
            for (int i = 0; i < 16; i++)
            {
                RowDefinition rowDef1 = new RowDefinition();
                rowDef1.Height = new GridLength(25, GridUnitType.Pixel);
                grid.RowDefinitions.Add(rowDef1);
            }

            //this.Content = grid;
            int columnSelection = 0;
            int rowSelection = 0;
            for (int i = 0; i < 16; i++)
            {
                rowSelection = i + 1;
                xLocation = 200;
                string daRowTag = "";
                if (i < 10)
                {
                    daRowTag = "0";
                }

                daRowTag = daRowTag + i.ToString();

                for (int j = 0; j < 30; j++)
                {
                    columnSelection = j + 1;
                    string daColumnTag = "";
                    if (j < 10)
                    {
                        daColumnTag = "0";
                    }
                    daColumnTag = daColumnTag + j.ToString();


                    daButtonArray[i, j] = new Button();
                    daButtonArray[i, j].Width = 25;
                    daButtonArray[i, j].Height = 25;
                    daButtonArray[i, j].FontSize = 12;
                    daButtonArray[i, j].FontWeight = FontWeights.Bold;
                    daButtonArray[i, j].Tag = daRowTag + daColumnTag;
                    daButtonArray[i, j].Click += revealButton;
                    daButtonArray[i, j].MouseRightButtonUp += flagButton;
                    daButtonArray[i, j].Content = "";
                    daButtonArray[i, j].Background = new SolidColorBrush(Colors.LightGray);

                    Grid.SetColumn(daButtonArray[i, j], columnSelection);
                    Grid.SetRow(daButtonArray[i, j], rowSelection);
                    grid.Children.Add(daButtonArray[i, j]);
                    xLocation = xLocation + 60;
                }
                yLocation = yLocation + 60;
            }
        }

        public void generateBoard()
        {
            int daRandomHeight;
            int daRandomWidth;
            bool onTop = true; // boolean variable to pass into a function to see which coordinates should be checked if there are bombs
            bool onLeft = true;
            bool onRight = false;
            bool onBottom = false;
            Random random = new Random();

            for (int i = 0; i < 99; i++)
            {
                daRandomHeight = random.Next(0, 16);
                daRandomWidth = random.Next(0, 30);
                if (daGameBoard[daRandomHeight][daRandomWidth] == -1) // if a bomb already exists in that spot it initializes a retry
                {
                    i--;
                }
                else
                {
                    daGameBoard[daRandomHeight][daRandomWidth] = -1; // sets the part of the board as a bomb
                }
            }

            for (int i = 0; i < 16; i++)
            {
                switch (i)
                {
                    case 0:
                        onTop = true;
                        break;
                    case 15:
                        onBottom = true;
                        break;
                    default:
                        onTop = false;
                        onBottom = false;
                        break;
                }
                for (int j = 0; j < 30; j++)
                {
                    switch (j)
                    {
                        case 0:
                            onLeft = true;
                            break;
                        case 29:
                            onRight = true;
                            break;
                        default:
                            onLeft = false;
                            onRight = false;
                            break;
                    }
                    if (daGameBoard[i][j] != -1)
                    {
                        daGameBoard[i][j] = findNumber(onTop, onBottom, onLeft, onRight, i, j);
                    }
                }
            }
        }

        public void generateBoard(int row, int column) // row and column will be where the user first clicked the board and the click is reserved so they do not click a bomb
        {
            int daRandomHeight;
            int daRandomWidth;
            bool onTop = true; // boolean variable to pass into a function to see which coordinates should be checked if there are bombs
            bool onLeft = true;
            bool onRight = false;
            bool onBottom = false;
            Random random = new Random();

            for (int i = 0; i < 99; i++) // creates all 99 bombs
            {
                daRandomHeight = random.Next(0, 16);
                daRandomWidth = random.Next(0, 30);
                if (daGameBoard[daRandomHeight][daRandomWidth] == -1 ||
                    (daRandomHeight == row && daRandomWidth == column) ||
                    (daRandomHeight == (row - 1) && daRandomWidth == column) ||
                    (daRandomHeight == row && daRandomWidth == (column - 1)) ||
                    (daRandomHeight == (row - 1) && daRandomWidth == (column - 1) ||
                    (daRandomHeight == (row + 1) && daRandomWidth == column) ||
                    (daRandomHeight == row && daRandomWidth == (column + 1)) ||
                    (daRandomHeight == (row + 1) && daRandomWidth == (column - 1)) ||
                    (daRandomHeight == (row - 1) && daRandomWidth == (column + 1)) ||
                    (daRandomHeight == (row + 1) && daRandomWidth == (column + 1))))// if a bomb already exists in that spot it initializes a retry or if it tries to make a bomb in a space around the start
                {
                    i--;
                }
                else
                {
                    daGameBoard[daRandomHeight][daRandomWidth] = -1; // sets the part of the board as a bomb
                }
            }

            for (int i = 0; i < 16; i++)
            {
                switch (i)
                {
                    case 0:
                        onTop = true;
                        break;
                    case 15:
                        onBottom = true;
                        break;
                    default:
                        onTop = false;
                        onBottom = false;
                        break;
                }
                for (int j = 0; j < 30; j++)
                {
                    switch (j)
                    {
                        case 0:
                            onLeft = true;
                            onRight = false;
                            break;
                        case 29:
                            onRight = true;
                            break;
                        default:
                            onLeft = false;
                            onRight = false;
                            break;
                    }
                    if (daGameBoard[i][j] != -1)
                    {
                        daGameBoard[i][j] = findNumber(onTop, onBottom, onLeft, onRight, i, j);
                    }
                }
            }
        }


        private int findNumber(bool topStatus, bool bottomStatus, bool leftStatus, bool rightStatus, int height, int width)
        {
            int count = 0;
            if (!topStatus)
            {
                if (daGameBoard[height - 1][width] == -1)
                {
                    count++;
                }
            }
            if (!bottomStatus)
            {
                if (daGameBoard[height + 1][width] == -1)
                {
                    count++;
                }
            }
            if (!leftStatus)
            {
                if (daGameBoard[height][width - 1] == -1)
                {
                    count++;
                }
            }
            if (!rightStatus)
            {
                if (daGameBoard[height][width + 1] == -1)
                {
                    count++;
                }
            }
            if (!topStatus && !leftStatus)
            {
                if (daGameBoard[height - 1][width - 1] == -1)
                {
                    count++;
                }
            }
            if (!topStatus && !rightStatus)
            {
                if (daGameBoard[height - 1][width + 1] == -1)
                {
                    count++;
                }
            }
            if (!bottomStatus && !leftStatus)
            {
                if (daGameBoard[height + 1][width - 1] == -1)
                {
                    count++;
                }
            }
            if (!bottomStatus && !rightStatus)
            {
                if (daGameBoard[height + 1][width + 1] == -1)
                {
                    count++;
                }
            }

            return count;
        }

        public int getValue(int row, int column)
        {
            return daGameBoard[row][column];
        }

        private void revealButton(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string btnNum = btn.Tag.ToString();
            int row = int.Parse(btnNum.Substring(0, 2));
            int column = int.Parse(btnNum.Substring(2, 2));
            btn.Content = 1;
            if (!gameStarted)
            {
                generateBoard(row, column);
                gameStarted = true;
            }

            switch (daGameBoard[row][column])
            {
                case -1:
                    btn.Foreground = new SolidColorBrush(Colors.Black);
                    gameOver();
                    break;
                case 1:
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    break;
                case 2:
                    btn.Foreground = new SolidColorBrush(Colors.Green);
                    break;
                case 3:
                    btn.Foreground = new SolidColorBrush(Colors.Red);
                    break;
                case 4:
                    btn.Foreground = new SolidColorBrush(Colors.Purple);
                    break;
                case 5:
                    btn.Foreground = new SolidColorBrush(Colors.LightBlue);
                    break;
                case 6:
                    btn.Foreground = new SolidColorBrush(Colors.Maroon);
                    break;
                default:
                    btn.Foreground = new SolidColorBrush(Colors.White);
                    break;

            }
            btn.Background = new SolidColorBrush(Colors.White);
            btn.FontWeight = FontWeights.Bold;
            btn.Content = daGameBoard[row][column];

            if (daGameBoard[row][column] == 0 && daButtonArray[row, column].Background != new SolidColorBrush(Colors.White))
            {
                revealAround(btn);
            }

        }

        private void revealAround(Button daButton)
        {
            string temp = daButton.Tag.ToString();
            int row = int.Parse(temp.Substring(0, 2));
            int column = int.Parse(temp.Substring(2, 2));
            Button btn = new Button();

            if (row > 0)
            {
                if (daButtonArray[row - 1, column].Content == "")
                {
                    btn = daButtonArray[row - 1, column];
                    revealButtonAuto(btn);
                }
                if (column > 0)
                {
                    if (daButtonArray[row - 1, column - 1].Content == "")
                    {
                        btn = daButtonArray[row - 1, column - 1];
                        revealButtonAuto(btn);
                    }
                }
                if (column < 29)
                {
                    if (daButtonArray[row - 1, column + 1].Content == "")
                    {
                        btn = daButtonArray[row - 1, column + 1];
                        revealButtonAuto(btn);
                    }
                }
            }
            if (row < 15)
            {
                if (daButtonArray[row + 1, column].Content == "")
                {
                    btn = daButtonArray[row + 1, column];
                    revealButtonAuto(btn);
                }
                if (column > 0)
                {
                    if (daButtonArray[row + 1, column - 1].Content == "")
                    {
                        btn = daButtonArray[row + 1, column - 1];
                        revealButtonAuto(btn);
                    }
                }
                if (column < 29)
                {
                    if (daButtonArray[row + 1, column + 1].Content == "")
                    {
                        btn = daButtonArray[row + 1, column + 1];
                        revealButtonAuto(btn);
                    }
                }
            }
            if (column > 0)
            {
                if (daButtonArray[row, column - 1].Content == "")
                {
                    btn = daButtonArray[row, column - 1];
                    revealButtonAuto(btn);
                }
            }
            if (column < 29)
            {
                if (daButtonArray[row, column + 1].Content == "")
                {
                    btn = daButtonArray[row, column + 1];
                    revealButtonAuto(btn);
                }
            }


        }

        public Grid getGrid()
        {
            return grid;
        }

        private void revealButtonAuto(Button btn)
        {
            string btnNum = btn.Tag.ToString();
            int row = int.Parse(btnNum.Substring(0, 2));
            int column = int.Parse(btnNum.Substring(2, 2));

            switch (daGameBoard[row][column])
            {
                case -1:
                    btn.Foreground = new SolidColorBrush(Colors.Black); 
                    break;
                case 1:
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    break;
                case 2:
                    btn.Foreground = new SolidColorBrush(Colors.Green);
                    break;
                case 3:
                    btn.Foreground = new SolidColorBrush(Colors.Red);
                    break;
                case 4:
                    btn.Foreground = new SolidColorBrush(Colors.Purple);
                    break;
                case 5:
                    btn.Foreground = new SolidColorBrush(Colors.LightBlue);
                    break;
                case 6:
                    btn.Foreground = new SolidColorBrush(Colors.Maroon);
                    break;
                default:
                    btn.Foreground = new SolidColorBrush(Colors.White);
                    break;

            }
            btn.Background = new SolidColorBrush(Colors.White);
            btn.FontWeight = FontWeights.Bold;
            btn.Content = daGameBoard[row][column];

            if (daGameBoard[row][column] == 0 && daButtonArray[row, column].Background != new SolidColorBrush(Colors.White)) //daButtonArray[row, column].Content != "")
            {
                revealAround(btn);
            }

        }

        private void flagButton(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            SolidColorBrush lightGrayBrush = new SolidColorBrush(Colors.LightGray);
            SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);

            /*btn.Content = 
            Image daImage = Image*/
            /*BitmapImage daBitMap = new BitmapImage("C:\Users\Parker McMinn\Documents\Projects\MineSweeperRefined\MineSweeperRefined\flag.jpg");
            Image daImage = daBitMap;
            ImageSource daImageSource = new ImageSource(@"C:\Users\Parker McMinn\Documents\Projects\MineSweeperRefined\MineSweeperRefined\flag.jpg");*/
            
           
        }

        private void gameOver()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int a = 0; a < 30; a++)
                {
                    daButtonArray[i, a].Click -= revealButton;
                    if (daGameBoard[i][a] == -1)
                    {
                        daButtonArray[i, a].Foreground = new SolidColorBrush(Colors.Red);
                        daButtonArray[i, a].Content = "X";
                    }
                }
            }
        }
    }
}

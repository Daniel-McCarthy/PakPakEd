using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PakPakEd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer mouseDrawTimer = new System.Windows.Threading.DispatcherTimer();

        byte[] levelPieces = new byte[28*28];
        byte width = 28;

        /*
        byte wall = 0;
        byte path = 1;
        byte collectible = 2;
        byte enemy = 3;
        byte enemyUp = 4;
        byte enemyDown = 5;
        byte enemyLeft = 6;
        byte enemyRight = 7;
        byte player = 8;
        byte directionalUp = 9;
        byte directionalDown = 10;
        byte directionalLeft = 11;
        byte directionalRight = 12;
        */

        byte objectTypeSelection = 3; //The id value for the level piece type selected
        byte directionSelection = 2; //The id value for the level piece direction selected

        public MainWindow()
        {
            InitializeComponent();

            
            //Sets up timer, which allows drawing to continue while mouse down
            mouseDrawTimer.Tick += new System.EventHandler(mouseDownTimer_Tick);
            mouseDrawTimer.Interval = new System.TimeSpan(0, 0, 0, 0, 25);
        }

        //Edits array containing the level pieces on the grid
        //Currently this is not used, but exists to allow for expanding behavior such as error checking.
        public void editLevelPiece(byte x, byte y, byte newPieceID)
        {
            if(x < 28 && y < 28 && newPieceID <= 12)
            {
                int arrayPos = x + (y * width);
                levelPieces[arrayPos] = newPieceID;
            }
        }

        //Draws a level piece onto the canvas at a specific coordinate
        public void drawPieceToCanvas(byte x, byte y, byte newPieceID)
        {
            int scale = 4; //The level is supposed to be 84x84 pixels. 28 3x3 pixel level pieces in each direction. 84x84 is too small to work with, so the canvas is scaled up.

            if (x < 28 && y < 28)
            {

                switch (newPieceID)
                {
                    case 0: //Wall
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));//Blue
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            break;
                        }
                    case 1: //Path
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));//Black
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            break;
                        }
                    case 2: //Collectible
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));//Green
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            break;
                        }
                    case 3: //Enemy
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//Red
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            break;
                        }
                    case 4: //Enemy Up
                        {
                            //Enemy Box
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//Red
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);


                            //Direction Up Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));//Orange
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (1 * scale));
                            Canvas.SetTop(rect2, (y * 3) * scale);
                            levelCanvas.Children.Add(rect2);


                            break;
                        }
                    case 5: //Enemy Down
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//Red
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);


                            //Direction Down Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));//Orange
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (1 * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (2 * scale));
                            levelCanvas.Children.Add(rect2);


                            break;
                        }
                    case 6: //Enemy Left
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//Red
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Direction Left Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));//Orange
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (1 * scale));
                            levelCanvas.Children.Add(rect2);

                            break;
                        }
                    case 7: //Enemy Right
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));//Red
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Direction Right Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));//Orange
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (2 * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (1 * scale));
                            levelCanvas.Children.Add(rect2);

                            break;
                        }
                    case 8: //Player
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 128, (byte)timerSlider.Value));//Orange
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Additional logic for orange shades

                            break;
                        }
                    case 9: //Directional Up
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 150, 255));//Light Blue
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);


                            //Direction Up Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 150, 255));//Purple Blue
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (1 * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale));
                            levelCanvas.Children.Add(rect2);


                            break;
                        }
                    case 10: //Directional Down
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 150, 255));//Light Blue
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Direction Down Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 150, 255));//Purple Blue
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (1 * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (2 * scale));
                            levelCanvas.Children.Add(rect2);

                            break;
                        }
                    case 11: //Directional Left
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 150, 255));//Light Blue
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Direction Left Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 150, 255));//Purple Blue
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (1 * scale));
                            levelCanvas.Children.Add(rect2);

                            break;
                        }
                    case 12: //Directional Right
                        {
                            System.Windows.Shapes.Rectangle rect;
                            rect = new System.Windows.Shapes.Rectangle();
                            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 150, 255));//Light Blue
                            rect.Width = 3 * scale;
                            rect.Height = 3 * scale;
                            Canvas.SetLeft(rect, (x * 3) * scale);
                            Canvas.SetTop(rect, (y * 3) * scale);
                            levelCanvas.Children.Add(rect);

                            //Direction Right Box
                            System.Windows.Shapes.Rectangle rect2;
                            rect2 = new System.Windows.Shapes.Rectangle();
                            rect2.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 150, 255));//Purple Blue
                            rect2.Width = 1 * scale;
                            rect2.Height = 1 * scale;
                            Canvas.SetLeft(rect2, ((x * 3) * scale) + (2 * scale));
                            Canvas.SetTop(rect2, ((y * 3) * scale) + (1 * scale));
                            levelCanvas.Children.Add(rect2);

                            break;
                        }
                }
            }
        }

        //Starts drawing pieces to canvas on click
        private void levelCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseDrawTimer.Start();
        }

        //Places selected level piece onto level where mouse is
        private void mouseDownTimer_Tick(object sender, System.EventArgs e)
        {

            Point p = Mouse.GetPosition(levelCanvas);
            int x = (int)p.X;
            int y = (int)p.Y;

            int scale = 4;

            int levelPieceXPos = x / (3 * scale);
            int levelPieceYPos = y / (3 * scale);


            byte levelPiece = objectTypeSelection;

            if(levelPiece == 3) //If enemy object is selected
            {
                if (directionSelection == 0) //if up is selected, set to up enemy
                {
                    levelPiece = 4;
                }

                if(directionSelection == 1) //if down is selected, set to down enemy
                {
                    levelPiece = 5;
                }

                if(directionSelection == 3) //if left is selected, set to left enemy
                {
                    levelPiece = 6;
                }

                if(directionSelection == 4) //if right is selected, set to right enemy
                {
                    levelPiece = 7;
                }

                //if center is selected, it will default to 3.
            }

            if (levelPiece == 9) //If object directional pad is selected
            {
                if(directionSelection == 1) //If direction is down, set to down directional pad
                {
                    levelPiece = 10; 
                }

                if(directionSelection == 3) //If direction is left, set to left directional pad
                {
                    levelPiece = 11;
                }

                if(directionSelection == 4) //If direction is right, set to right directional pad
                {
                    levelPiece = 12;
                }

                //If direction is up it stays 9, if it is central direction it stays 9 because there is no center pad
            }

            drawPieceToCanvas((byte)levelPieceXPos, (byte)levelPieceYPos, levelPiece);
            editLevelPiece((byte)levelPieceXPos, (byte)levelPieceYPos, levelPiece);

        }

        //This changes the text label that shows what type of level piece you have selected to place
        private void updateSelectionDisplay()
        {
            string display = "";

            switch (objectTypeSelection)
            {

                case 0:
                    {
                        display += "Wall";
                        break;
                    }
                case 1:
                    {
                        display += "Path";
                        break;
                    }
                case 2:
                    {
                        display += "Collectible";
                        break;
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    {
                        display += "Enemy";
                        break;
                    }
                case 8:
                    {
                        display += "Player";
                        break;
                    }
                case 9:
                case 10:
                case 11:
                case 12:
                    {
                        display += "Directional Pad";
                        break;
                    }
            }

            if ((objectTypeSelection >= 3 && objectTypeSelection < 8) || objectTypeSelection >= 9)
            {
                switch (directionSelection)
                {
                    case 0:
                        {
                            display += ", Up";
                            break;
                        }
                    case 1:
                        {
                            display += ", Down";
                            break;
                        }
                    case 3:
                        {
                            display += ", Left";
                            break;
                        }
                    case 4:
                        {
                            display += ", Right";
                            break;
                        }
                }
            }

            selectionLabel.Content = display;
        }

        //Disables direction for selected level piece (so that wandering enemies can be placed)
        private void No_Direction_Click(object sender, RoutedEventArgs e)
        {
            directionSelection = 2;
            updateSelectionDisplay();

        }

        //Sets direction for level pieces up
        private void Up_Arrow_Click(object sender, RoutedEventArgs e)
        {
            directionSelection = 0;
            updateSelectionDisplay();
        }

        //Sets direction for level pieces down
        private void Down_Arrow_Click(object sender, RoutedEventArgs e)
        {
            directionSelection = 1;
            updateSelectionDisplay();
        }

        //Sets direction for level pieces left
        private void Left_Arrow_Click(object sender, RoutedEventArgs e)
        {
            directionSelection = 3;
            updateSelectionDisplay();
        }

        //Sets direction for level pieces right
        private void Right_Arrow_Click(object sender, RoutedEventArgs e)
        {
            directionSelection = 4;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Enemy
        private void EnemyButton_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 3;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Path
        private void PathButton_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 1;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Wall
        private void WallButton_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 0;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Directional Pad
        private void DirectionalPadButton_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 9;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Player
        private void PlayerButton_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 8;
            updateSelectionDisplay();
        }

        //Sets selected level piece to type: Collectible
        private void Collectible_Button_Click(object sender, RoutedEventArgs e)
        {
            objectTypeSelection = 2;
            updateSelectionDisplay();
        }

        //Opens Dialogue to save level to .png file
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            int scale = 4;


            Rect canvasRect = VisualTreeHelper.GetDescendantBounds(levelCanvas);
            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)canvasRect.Width, (int)canvasRect.Height, 96d, 96d, PixelFormats.Pbgra32);

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(levelCanvas);
                dc.DrawRectangle(vb, null, new Rect(new Point(), canvasRect.Size));
            }

            renderTarget.Render(dv);



            System.Drawing.Bitmap convertedBitmap;
            System.IO.MemoryStream bitmapStream = new System.IO.MemoryStream();

            BitmapEncoder bitmapEncoder = new BmpBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)renderTarget));
            bitmapEncoder.Save(bitmapStream);
            convertedBitmap = new System.Drawing.Bitmap(bitmapStream);

            bitmapStream.Close();

            System.Drawing.Bitmap downscaledBitmap = new System.Drawing.Bitmap(convertedBitmap, new System.Drawing.Size(convertedBitmap.Width / scale, convertedBitmap.Height / scale));

            using (System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog())
            {
                saveFile.Filter = "png files (*.png)|*.png";

                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    downscaledBitmap.Save(saveFile.FileName);
                }
            }
        }

        //Opens dialogue to open level from .png file
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog())
            {
                openFile.Filter = "png files (*.png)|*.png";
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.Bitmap rawImage = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(openFile.FileName));

                    int width = rawImage.Width;
                    int height = rawImage.Height;
                    int pixelCount = ((width) * (height)) / 3;

                    System.Drawing.Color wall = System.Drawing.Color.FromArgb(0, 0, 255);
                    System.Drawing.Color path = System.Drawing.Color.FromArgb(0, 0, 0);
                    System.Drawing.Color enemy = System.Drawing.Color.FromArgb(255, 0, 0);
                    System.Drawing.Color player = System.Drawing.Color.FromArgb(255, 128, 45);
                    System.Drawing.Color directionalPad = System.Drawing.Color.FromArgb(0, 150, 255);
                    System.Drawing.Color collectible = System.Drawing.Color.FromArgb(0, 255, 0);

                    System.Drawing.Color directionalOrange = System.Drawing.Color.FromArgb(255, 128, 0);
                    System.Drawing.Color directionalPurple = System.Drawing.Color.FromArgb(128, 150, 255);


                    if (width == 84 && height == 84)
                    {
                        for(int i = 0; i < pixelCount; i+= 3)
                        {
                            int currentPixelXPos = i % width;
                            int currentPixelYPos = (i / width) * 3;

                            System.Drawing.Color currentPixel = rawImage.GetPixel(currentPixelXPos, currentPixelYPos);

                            if(Equals(currentPixel, wall))
                            {
                                editLevelPiece((byte)(currentPixelXPos/3), (byte)(currentPixelYPos / 3), 0);
                                drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 0);
                            }

                            if (Equals(currentPixel, path))
                            {
                                editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 1);
                                drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 1);
                            }

                            if (Equals(currentPixel, collectible))
                            {
                                editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 2);
                                drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 2);
                            }

                            if (Equals(currentPixel, enemy))
                            {
                                bool directionalUp = Equals(directionalOrange, rawImage.GetPixel(currentPixelXPos + 1, currentPixelYPos));
                                bool directionalDown = Equals(directionalOrange, rawImage.GetPixel(currentPixelXPos + 1, currentPixelYPos + 2));
                                bool directionalLeft = Equals(directionalOrange, rawImage.GetPixel(currentPixelXPos, currentPixelYPos + 1));
                                bool directionalRight = Equals(directionalOrange, rawImage.GetPixel(currentPixelXPos + 2, currentPixelYPos + 1));

                                if(!(directionalUp || directionalLeft || directionalRight || directionalDown))
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 3);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 3);
                                }
                                else if(directionalUp)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 4);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 4);
                                }
                                else if(directionalDown)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 5);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 5);
                                }
                                else if(directionalLeft)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 6);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 6);
                                }
                                else if(directionalRight)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 7);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 7);
                                }

                            }

                            //Player spawner
                            if (currentPixel.R == 255 && currentPixel.G == 128)
                            {
                                editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 8);
                                drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 8);

                                //Set the slider to the player color loaded in
                                timerSlider.Value = currentPixel.B;
                            }

                            if (Equals(currentPixel, directionalPad))
                            {
                                bool directionalUp = Equals(directionalPurple, rawImage.GetPixel(currentPixelXPos + 1, currentPixelYPos));
                                bool directionalDown = Equals(directionalPurple, rawImage.GetPixel(currentPixelXPos + 1, currentPixelYPos + 2));
                                bool directionalLeft = Equals(directionalPurple, rawImage.GetPixel(currentPixelXPos, currentPixelYPos + 1));
                                bool directionalRight = Equals(directionalPurple, rawImage.GetPixel(currentPixelXPos + 2, currentPixelYPos + 1));

                                if (directionalUp)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 9);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 9);
                                }
                                else if (directionalDown)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 10);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 10);
                                }
                                else if (directionalLeft)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 11);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 11);
                                }
                                else if (directionalRight)
                                {
                                    editLevelPiece((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 12);
                                    drawPieceToCanvas((byte)(currentPixelXPos / 3), (byte)(currentPixelYPos / 3), 12);
                                }
                            }

                        }
                        

                    }
                    else
                    {
                        MessageBox.Show("Incorrect Image Resolution: Image must be 84x84 pixels.");
                    }

                }
                else
                {
                    MessageBox.Show("Failed to open file");
                }
            }
        }

        //Sets label to show timer slider value on change
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timerValueLabel.Content = ((byte)e.NewValue).ToString();

            //Redraw player spawn points
            for (int i = 0; i < levelPieces.Length; i++)
            {
                if(levelPieces[i] == 8)
                {
                    int xPos = i % 28;
                    int yPos = i / 28;

                    drawPieceToCanvas((byte)(xPos), (byte)(yPos), 8);
                }
            }
        }

        //Upon loading the label: Set slider value to 45. (Setting the value to 45 by default causes the on-change function to call while label is null.)
        private void timerValueLabel_Loaded(object sender, RoutedEventArgs e)
        {
            timerSlider.Value = 45;
        }

        //Lets Mouse Down Draw Event know to stop.
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDrawTimer.Stop();
          
        }
    }
}

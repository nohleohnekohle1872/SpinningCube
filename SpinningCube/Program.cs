namespace SpinningCube
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            double x = 0;
            double y = 0;
            double z = 0;
            int xP = 0;
            int yP = 0;
            int zP = 0;
            bool next = true;

            Console.ReadKey();

            //Point middlePointOfCylinder1 = new(100, 70, 0);
            //Cylinder cylinder1 = new(middlePointOfCylinder1, 15, 10);
            //cylinder1.Draw(ConsoleColor.DarkCyan);

            //while (true)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKey key = Console.ReadKey(true).Key;

            //        if (key == ConsoleKey.Spacebar)
            //            next = false;

            //        if (key == ConsoleKey.Enter)
            //            next = true;

            //        switch (key)
            //        {
            //            case ConsoleKey.UpArrow:
            //                x++;
            //                break;

            //            case ConsoleKey.DownArrow:
            //                x--;
            //                break;

            //            case ConsoleKey.LeftArrow:
            //                y--;
            //                break;

            //            case ConsoleKey.RightArrow:
            //                y++;
            //                break;

            //            case ConsoleKey.A:
            //                z++;
            //                break;

            //            case ConsoleKey.B:
            //                z--;
            //                break;
            //        }
            //    }

            //    if (next)
            //    {
            //        cylinder1.Remove();
            //        cylinder1.Rotate(x, y, z);
            //        cylinder1.Draw(ConsoleColor.DarkRed);
            //    }
            //}


            Point middlePointOfSq1 = new(170, 120, 0);
            Point p = new(240 + xP, 120 + yP, 0 + zP);
            Square sq1 = new(31, middlePointOfSq1);
            sq1.Draw(ConsoleColor.DarkGreen);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Spacebar)
                        next = false;

                    if (key == ConsoleKey.Enter)
                        next = true;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            x++;
                            break;

                        case ConsoleKey.DownArrow:
                            x--;
                            break;

                        case ConsoleKey.LeftArrow:
                            y--;
                            break;

                        case ConsoleKey.RightArrow:
                            y++;
                            break;

                        case ConsoleKey.A:
                            z++;
                            break;

                        case ConsoleKey.B:
                            z--;
                            break;

                        case ConsoleKey.F5:
                            xP++;
                            break;

                        case ConsoleKey.F6:
                            xP--;
                            break;

                        case ConsoleKey.F7:
                            yP++;
                            break;

                        case ConsoleKey.F8:
                            yP--;
                            break;
                    }
                }

                if (next)
                {


                    sq1.Remove();
                    sq1.Rotate(x, y, z, middlePointOfSq1);
                    p = new(240 + xP, 120 + yP, 0 + zP);
                    //p.Draw(ConsoleColor.DarkRed, "**");
                }
            }



            Console.ReadKey();



            //Point middlePointOfC1 = new(150, 130, 0);
            //Point rotationAxisPointOfC1 = new(300, 200, 0);
            //Circle c1 = new(middlePointOfC1, 10);
            //c1.Draw(ConsoleColor.Cyan);


            //while (true)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        ConsoleKey key = Console.ReadKey(true).Key;

            //        if (key == ConsoleKey.Spacebar)
            //            next = false;

            //        if (key == ConsoleKey.Enter)
            //            next = true;

            //        switch (key)
            //        {
            //            case ConsoleKey.UpArrow:
            //                x++;
            //                break;

            //            case ConsoleKey.DownArrow:
            //                x--;
            //                break;

            //            case ConsoleKey.LeftArrow:
            //                y--;
            //                break;

            //            case ConsoleKey.RightArrow:
            //                y++;
            //                break;

            //            case ConsoleKey.A:
            //                z++;
            //                break;

            //            case ConsoleKey.B:
            //                z--;
            //                break;
            //        }
            //    }

            //    if (next)
            //    {
            //        c1.Remove();
            //        c1.Rotate(x, y, z, rotationAxisPointOfC1);
            //        //c1.Draw(ConsoleColor.DarkRed);
            //    }
            //}



            Point middlePointOfSph1 = new(200, 100, 0);
            Sphere sph1 = new(middlePointOfSph1, 10);
            sph1.Draw(ConsoleColor.Cyan);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Spacebar)
                        next = false;

                    if (key == ConsoleKey.Enter)
                        next = true;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            x++;
                            break;

                        case ConsoleKey.DownArrow:
                            x--;
                            break;

                        case ConsoleKey.LeftArrow:
                            y--;
                            break;

                        case ConsoleKey.RightArrow:
                            y++;
                            break;

                        case ConsoleKey.A:
                            z++;
                            break;

                        case ConsoleKey.B:
                            z--;
                            break;
                    }
                }

                if (next)
                {
                    sph1.Remove();
                    sph1.Rotate(x, y, z);
                    sph1.Draw(ConsoleColor.DarkGreen);
                }
            }
        }

        public static double TransformRadiantToDegree(double radiant)
        {
            return radiant * 180 / Math.PI;
        }

        public static double TransformDegreeToRadiant(double degree)
        {
            return degree * Math.PI / 180;
        }
    }

    
}

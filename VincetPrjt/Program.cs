using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Raylib_cs;
using System.Numerics;


//chance för +hp rectangle
Raylib.InitWindow(800, 600, "hejsan");
Raylib.SetTargetFPS(60);
Random rand = new Random();
int chance = rand.Next(1, 10);


//random x för enemyRect
Random generator = new Random();
int enemySpeed = 2;
int pSpeed = 12;


int liv = 3;
int score = 0;
string scene;
scene = "start";

Rectangle rRect = new Rectangle(275, 260, 250, 100);
Rectangle pRect = new Rectangle(350, 450, 100, 30);
Rectangle HudRect = new Rectangle(0, 500, 800, 100);
Rectangle enemyRec = new Rectangle(350, 0, 50, 50);
Rectangle hpRec = new Rectangle(350, 0, 50, 50);


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "start")
    {

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(rRect, Color.WHITE);
        Raylib.DrawText("Press space to start", 290, 300, 20, Color.BLACK);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }


    if (scene == "game")
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // RENDERING
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawRectangleRec(HudRect, Color.BLACK);
        Raylib.DrawRectangleRec(pRect, Color.DARKGREEN);

        Raylib.DrawText($"points {score}", 50, 520, 40, Color.WHITE);
        Raylib.DrawText($"Health {liv}", 250, 520, 40, Color.WHITE);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // GAME LOGIC
        //------------------------------------------------------------------------------------------------------------------------

        if (chance > 1)
        {
            Raylib.DrawRectangleRec(enemyRec, Color.RED);
            //--------------------------------------------------------------------
            //LOGIC FÖR enemyREC
            //--------------------------------------------------------------------

            if (Raylib.CheckCollisionRecs(pRect, enemyRec))
            {
                enemyRec.Y = 0;
                score++;
                enemyRec.X = generator.Next(0, 750); //min & max x värde som rectangeln kan spawna på
                enemySpeed += 1;
                chance = rand.Next(1, 10);
            }





            if (Raylib.CheckCollisionRecs(HudRect, enemyRec))
            {
                enemyRec.Y = 0;
                liv--;
                enemySpeed += 1;
                chance = rand.Next(1, 10);
            }
            if (score > 8)
            {
                enemySpeed = 10; //spelet slutar snabbas up efter 6 poäng
            }


            if (liv > 0)
            {
                enemyRec.Y += enemySpeed;
            }
        }
        //--------------------------------------------------------------------
        //LOGIC FÖR hpREC
        //--------------------------------------------------------------------
        else if (chance <= 1)
        {
            Raylib.DrawRectangleRec(hpRec, Color.GREEN);


            if (Raylib.CheckCollisionRecs(pRect, hpRec))
            {
                hpRec.Y = 0;
                hpRec.X = generator.Next(0, 750);
                liv++;
                chance = rand.Next(1, 10);
            }
            if (liv > 0)
            {
                hpRec.Y += 5;
            }

            if (Raylib.CheckCollisionRecs(HudRect, hpRec))
            {
                hpRec.Y = 0;
                liv-=2;
                chance = rand.Next(1, 10);
            }
        }
        //--------------------------------------------------------------------
        //LOGIC FÖR playerREC
        //--------------------------------------------------------------------
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            pRect.X += pSpeed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            pRect.X -= pSpeed;
        }

        if (pRect.X < 0) //om spelaren går mot väggen så åker dem inte utanför.
        {
            pRect.X += pSpeed;
        }
        else if (pRect.X > 700)
        {
            pRect.X -= pSpeed;
        }

        //--------------------------------------------------------------------
        //Game Over Logic
        //--------------------------------------------------------------------
        if (liv <= 0)
        {
            scene = "gameOver";
        }


    }

    if (scene == "gameOver")
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText("GAME OVER", 170, 250, 80, Color.BLACK);
        Raylib.DrawText("Press Enter to try again", 285, 350, 20, Color.BLACK);
        Raylib.DrawText("press Escape to exit game", 280, 380, 20, Color.BLACK);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            score = 0;
            liv = 3;
            scene = "game";
            enemySpeed = 2;
        }

    }




    Raylib.EndDrawing();
}
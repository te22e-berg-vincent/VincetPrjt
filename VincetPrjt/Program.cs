﻿using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "hejsan");
Raylib.SetTargetFPS(60);

Random generator = new Random();
int enemySpeed =2;

int liv = 5;
int score = 0;
string scene;
scene = "start";

Rectangle rRect = new Rectangle(275, 260, 250, 100);
Rectangle pRect = new Rectangle(350, 450, 100, 30);
Rectangle HudRect = new Rectangle(0, 500, 800, 100);
Rectangle enemyRec = new Rectangle(350, 0, 50, 50);


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
        Raylib.DrawRectangleRec(enemyRec, Color.RED);
        Raylib.DrawText($"points {score}",50,520,40,Color.WHITE);
        Raylib.DrawText($"Health {liv}", 250, 520,40,Color.WHITE);
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // GAME LOGIC
        //------------------------------------------------------------------------------------------------------------------------
        if(Raylib.CheckCollisionRecs(pRect,enemyRec))
        {
            enemyRec.Y = 0;
            score ++;
            enemyRec.X = generator.Next(50,750);
            enemySpeed +=1;
        }

                if(Raylib.CheckCollisionRecs(HudRect,enemyRec))
        {
            enemyRec.Y = 0;
            liv--;
            enemySpeed +=1;
        }
        if (score > 6)
        {
            enemySpeed =8;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            pRect.X += 10;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            pRect.X -= 10;
        }

        if (liv > 0)
        {
            enemyRec.Y += enemySpeed;
        }

    }






    Raylib.EndDrawing();
}
using Raylib_cs;

Raylib.InitWindow(800, 600, "hejsan");
Raylib.SetTargetFPS(60);

string scene;
scene = "start";



while (!Raylib.WindowShouldClose())
{//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 // RENDERING
 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();

    if (scene == "start")
    {

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangle(275, 260, 250, 100, Color.WHITE);
        Raylib.DrawText("Press space to start", 290, 300, 20, Color.BLACK);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }
    if (scene == "game")
    {
        Raylib.ClearBackground(Color.WHITE);
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    // GAME LOGIC
    //------------------------------------------------------------------------------------------------------------------------


/*
    while (scene == "start")
    {

    }

    while (scene == "game")
    {

    }
*/


    Raylib.EndDrawing();
}
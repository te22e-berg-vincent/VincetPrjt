using Raylib_cs;

Raylib.InitWindow(800, 600, "hejsan");
Raylib.SetTargetFPS(60);

string scene;
scene = "start";

Rectangle rrect = new Rectangle(275, 260, 250, 100);
//Rectangle Prect = new Rectangle()
Rectangle HudRect = new Rectangle (0,500,800,100);


while (!Raylib.WindowShouldClose())
{//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 // RENDERING
 //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();

    if (scene == "start")
    {

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(rrect, Color.WHITE);
        Raylib.DrawText("Press space to start", 290, 300, 20, Color.BLACK);
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }
    
        if (scene == "game")
        {
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawRectangleRec(HudRect,Color.BLACK);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // GAME LOGIC
        //------------------------------------------------------------------------------------------------------------------------






    Raylib.EndDrawing();
}
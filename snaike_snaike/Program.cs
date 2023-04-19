// See https://aka.ms/new-console-template for more information
// ReSharper disable InconsistentNaming

using Raylib_cs;
using snaike_snaike;

var skjerm = new Skjerm(new Tuple<int, int>(800, 600));
var spiller = new Spiller(20, skjerm);
var mat = new Mat(spiller, skjerm);
var spill_motor = new Spill_motor(spiller, skjerm, mat);

Raylib.SetTargetFPS(60);
Raylib.BeginDrawing();
Raylib.ClearBackground(Color.WHITE);
Raylib.EndDrawing();

spill_motor.intro();
while (!Raylib.WindowShouldClose())
{   
    // Alt den skal gjøre i starten
    Raylib.SetTargetFPS(spill_motor.hastighet);
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);
    
    //Hoved programmet
    mat.spawn();
    //Sjekker om en piltast har blitt trykket, og går den vegen
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP) && spiller.retning != "ned")
    {
        spiller.retning = "opp";
        spiller.x_posisjon_endring = 0;
        spiller.y_posisjon_endring = -1 * spiller.størrelse;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && spiller.retning != "opp")
    {
        spiller.retning = "ned";
        spiller.x_posisjon_endring = 0;
        spiller.y_posisjon_endring = 1 * spiller.størrelse;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && spiller.retning != "venstre")
    {
        spiller.retning = "høyre";
        spiller.x_posisjon_endring = 1 * spiller.størrelse;
        spiller.y_posisjon_endring = 0;
    }
    else if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && spiller.retning != "høyre")
    {
        spiller.retning = "venstre";
        spiller.x_posisjon_endring = -1 * spiller.størrelse;
        spiller.y_posisjon_endring = 0;
    }
    
    
    //alt som skal gjøres til slutt
    spill_motor.oppdater(); 
    Raylib.EndDrawing();
}
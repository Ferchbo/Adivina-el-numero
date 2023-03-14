string? jugador;
Random aleatorio = new Random();
int intentos = 0;
int PuntosMA = 0;

Console.WriteLine("Adivina el numero");

    IniJuego();

void IniJuego()
{
    

    Console.WriteLine("Hola bienvenido al juego");

    Console.WriteLine("Cual es tu nombre");
    int numeroAleatorio = aleatorio.Next(1, 10);
    jugador = Console.ReadLine();

    QuiereJugar(numeroAleatorio);

 }

void QuiereJugar(int numeroAleatorio, bool juegoNuevo = false)
{
    if(!juegoNuevo)
    Console.WriteLine($"Hola {jugador}, Estas listo? (Ingrese SI o NO)");
    else
        Console.WriteLine($"{jugador}, Estas listo para un juego nuevo? (Ingrese SI o NO)");

    var quiereJugar = Console.ReadLine();

    switch (quiereJugar?.ToLower().Trim())
    {
        case "si":
            Console.WriteLine("Has elegido que si");
            Jugar(numeroAleatorio);
            break;
        case "no":
            Console.WriteLine("Has elegido que no");
            NoJugar();
            break;
        default:
            Console.WriteLine("Esta no es una opcion valida");
            QuiereJugar(numeroAleatorio);
            break;

    }
}

void Jugar(int numeroAleatorio)
{
    try
    {
        Console.WriteLine("Seleccione un numero entre el 1 y el 10");
        var selecnum = Console.ReadLine();

        if (selecnum == null)
            throw new Exception("debe seleccionar un numero");
        if (int.Parse(selecnum) < 1 || int.Parse(selecnum) > 10)
            throw new Exception("debe seleccionar un numero entre 1 y 10");
        if (int.Parse(selecnum) == numeroAleatorio)
        {
            hasAdivinado();
        }
        else if (int.Parse(selecnum) < numeroAleatorio)
        {
            Console.WriteLine("el numero es mas alto, intentalo de nuevo");
            intentos++;
            Jugar(numeroAleatorio);
        }
        else if (int.Parse(selecnum) > numeroAleatorio)
        {
            Console.WriteLine("el numero es menor, intentalo de nuevo");
            intentos++;
            Jugar(numeroAleatorio);
        }


    }
    catch(Exception e) 
    {
        Console.WriteLine($"Aca hay un error, {e.Message}");
        Jugar(numeroAleatorio);
    }
}

void NoJugar()
{
    Console.WriteLine("No te preocupes que tengas buenas noches!");
}

void hasAdivinado()
{
    Console.WriteLine("Felicitaciones, has adivinado!!!");
    intentos++;
    if (PuntosMA == 0 || intentos < PuntosMA)
        PuntosMA = intentos;

    Console.WriteLine($"te ha tomado {intentos} intentos adivinar el numero");
    MostrarPMA();
    intentos = 0;
    int numeroAleatorio = aleatorio.Next(1, 10);
    QuiereJugar(numeroAleatorio, true);
}

void MostrarPMA()
{
    if (PuntosMA == 0)
        Console.WriteLine("No hay puntaje mas alto, este es el primero.");
    else
        Console.WriteLine($"El puntaje mas alto es {PuntosMA} intentos");
}
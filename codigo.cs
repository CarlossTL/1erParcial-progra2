using System;

public abstract class Jugador
{
    public char Simbolo { get; protected set; }
    public abstract void JugarTurno(char[,] tablero);
}

public class Jugador1 : Jugador
{
    public Jugador1(char simbolo)
    {
        Simbolo = simbolo;
    }

    public override void JugarTurno(char[,] tablero)
    {
        int x, y;
        do
        {
            Console.Write("Fila (0-2): "); x = int.Parse(Console.ReadLine());
            Console.Write("Columna (0-2): "); y = int.Parse(Console.ReadLine());
        } while (x < 0 || x > 2 || y < 0 || y > 2 || tablero[x, y] != '-');

        tablero[x, y] = Simbolo;
    }
}

public class Contrincante : Jugador
{
    private Random aleatorio = new Random();

    public Contrincante(char simbolo)
    {
        Simbolo = simbolo;
    }

    public override void JugarTurno(char[,] tablero)
    {
        int x, y;
        do
        {
            x = aleatorio.Next(3);
            y = aleatorio.Next(3);
        } while (tablero[x, y] != '-');

        tablero[x, y] = Simbolo;
    }
}

public class TresEnRaya
{
    private char[,] tablero = new char[3, 3];
    private Jugador jugador, contrincante;

    public void Jugar()
    {
        InicializarTablero();
        ElegirSimbolo();

        while (true)
        {
            MostrarTablero();
            jugador.JugarTurno(tablero);
            if (VerificarGanador(jugador.Simbolo) || TableroLleno()) break;

            contrincante.JugarTurno(tablero);
            if (VerificarGanador(contrincante.Simbolo) || TableroLleno()) break;
        }
    }

    private void InicializarTablero()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                tablero[i, j] = '-';
    }

using System.Diagnostics;

namespace RoboMovel;

public class Robo
{
    private int X;
    private int Y;
    private Direcao Face;
    private int LimiteX;
    private int LimiteY;

    public Direcao GetFace() { return Face; }
    public int GetX() { return X; }
    public int GetY() { return Y; }
    public int GetLimiteX() { return LimiteX; }
    public int GetLimiteY() { return LimiteY; }
    
    
    public void Controlar(string instrucoes)
    {
        instrucoes = instrucoes.ToUpper();
        
        foreach (var s in instrucoes)
        {
            if (s is 'E' or 'D') 
                Girar(s);
            else if (s is 'M')
            {
                Mover();
            }
            LocalizarRobo();
            Console.ReadKey();
        }
    }

    private void Mover()
    {
        switch (Face)
        {
            case Direcao.N :
                if (Y < LimiteY) {Y += 1;}
                break;
            case Direcao.S :
                if (Y > 0) {Y -= 1;}
                break;
            case Direcao.L :
                if (X < LimiteX) {X += 1;}
                break;
            case Direcao.O :
                if(X > 0) {X -= 1;}
                break;
        }
        
    }
    
    
    private void Girar(char s)
    {
        switch (s)
        {
            case 'D' when Face != Direcao.O:
                Face += 1;
                break;
            case 'D':
                Face = Direcao.N;
                break;
            case 'E' when Face != Direcao.N:
                Face -= 1;
                break;
            case 'E':
                Face = Direcao.O;
                break;
        }
    }
    
    private void PosicionarRobo(string cordenadas)
    {
        string[] s = cordenadas.Split(" ");
        
        X = Convert.ToInt32(s[0]);
        Y = Convert.ToInt32(s[1]);
        
        s[2] = s[2].ToUpper();
        
        Enum.TryParse<Direcao>(s[2], out Face);
        
    }

    public void CriarLimites(int x , int y)
    {
       LimiteX = x;
       LimiteY = y;
    }

    public void LocalizarRobo()
    {
        Console.WriteLine($"{X} {Y} {Face}");
    }
    
    public void ColetarCordenadas()
    {
        Console.Clear();
        Console.WriteLine("Digite a posição do robo (X Y D)");

        try
        {
            PosicionarRobo(Console.ReadLine());
        }
        catch
        {
            ColetarCordenadas();
        }
    }
    
}
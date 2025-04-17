
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
    
    
    public void Controlar(string instrucoes)
    {
        string[] ordem = instrucoes.Split();
        
        foreach (var s in ordem)
        {
            if (s is "E" or "D") 
                Girar(s);
            else if (s is "M")
            {
                Mover();
            }
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
                if (Y > 0) {Y -= 1;} {Y -= 1;}
                break;
            case Direcao.L :
                if (X < LimiteX) {X += 1;}
                break;
            case Direcao.O :
                if(X > 0) {X -= 1;}
                break;
        }
        
    }
    
    
    private void Girar(string s)
    {
        if (Face != Direcao.O && s is "D") { Face += 1; }
        else { Face = Direcao.N; }

        if (Face != Direcao.N && s is "E") { Face -= 1; }
        else { Face = Direcao.O; }
    }
    
    public void PosicionarRobo(string cordenadas)
    {
        string[] s = cordenadas.Split(" ");

        X = Convert.ToInt32(s[0]);
        Y = Convert.ToInt32(s[1]);
        
        Enum.TryParse<Direcao>(s[2], out Face);
        
    }

    public void CriarLimites(string tamanho)
    {
        string[] s = tamanho.Split(" ");
        LimiteX = Convert.ToInt32(s[0]);
        LimiteY = Convert.ToInt32(s[1]);
    }

    public void LocalizarRobo()
    {
        Console.WriteLine($"{X} {Y} {Face}");
    }
}
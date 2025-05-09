﻿namespace RoboMovel;

public class Grade()
{
    private Robo?[,] Grid;

    public Robo?[,] GetGrid()
    {
        return Grid;
    }

    private void Criar(string ij)
    {
        string[] s = ij.Split(' ');
        
        Grid = new Robo?[Convert.ToInt32(s[0])+1, Convert.ToInt32(s[1])+1];
    }
    
    public void ColetarLimites()
    {
        Console.Clear();
        Console.WriteLine("Digite o valor dos limites da grande (X Y)");

        try
        {
            Criar(Console.ReadLine());
        }
        catch
        {
            ColetarLimites();
        }
    }

    public void AddRobo(Robo robo)
    {
        Grid[robo.GetY(),robo.GetX()] = robo;
    }

    public void MostrarGrade()
    {
        int tamanho = Grid.GetLength(0);
        
        
        Console.WriteLine(new string('-', Grid.GetLength(0)*2)+"-");
        for (int i = tamanho-1; i >= 0; i--)
        {
            for (int j = 0 ; j < tamanho ; j++)
            {
                Console.Write(Grid[i,j] == null ? " " : $"{Grid[i,j].GetFace()}");
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', Grid.GetLength(0)*2)+"-");
        }
    }
    
}
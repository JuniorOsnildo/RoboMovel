using RoboMovel;

Grade grade = new Grade();
Robo robo1 = new Robo();
Robo robo2 = new Robo();

grade.ColetarLimites();

int x = grade.GetGrid().GetLength(0);
int y = grade.GetGrid().GetLength(1);

robo1.CriarLimites(x, y);
robo2.CriarLimites(x, y);

robo1.ColetarCordenadas();
Console.Clear();
Console.WriteLine("Digite a Movimentação do robo");
robo1.Controlar(Console.ReadLine());

robo2.ColetarCordenadas();
Console.Clear();
Console.WriteLine("Digite a Movimentação do robo");
robo2.Controlar(Console.ReadLine());

Console.Write("R1: ");
robo1.LocalizarRobo();
Console.Write("R2: ");
robo2.LocalizarRobo();

Console.WriteLine();
grade.AddRobo(robo1);
grade.AddRobo(robo2);
grade.MostrarGrade();
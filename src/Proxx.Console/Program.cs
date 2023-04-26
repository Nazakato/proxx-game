using Proxx.Core.BoardGeneration;
using Proxx.Core.Square;

Console.WriteLine("Game 1 showcase: Game over.");

var proxxContext = new ProxxContext(10, 10, 10, new UniformHolesDistributionStrategy(1000));
Console.WriteLine(proxxContext);

var moves = new[]
{
    Position.Create(8, 0),
    Position.Create(1, 3),
    Position.Create(8, 8),
    Position.Create(0, 8),
};

foreach (var pos in moves)
{
    proxxContext.OpenBoardAt(pos);
    Console.WriteLine(proxxContext);
}

Console.WriteLine("\n\n\n\n");
Console.WriteLine("Game 2 showcase: Win game.");

proxxContext = new ProxxContext(10, 10, 10, new UniformHolesDistributionStrategy(1000));
Console.WriteLine(proxxContext);

moves = new[]
{
    Position.Create(8, 0),
    Position.Create(1, 3),
    Position.Create(8, 8),
    Position.Create(0, 7),
    Position.Create(0, 9),
    Position.Create(6, 5),
    Position.Create(5, 5),
    Position.Create(3, 5),
    Position.Create(2, 5),
    Position.Create(2, 4),
    Position.Create(0, 5),
    Position.Create(0, 6),
    Position.Create(1, 4),
    Position.Create(0, 4),
    Position.Create(0, 3),
    Position.Create(0, 1),
};

foreach (var pos in moves)
{
    proxxContext.OpenBoardAt(pos);
    Console.WriteLine(proxxContext);
}
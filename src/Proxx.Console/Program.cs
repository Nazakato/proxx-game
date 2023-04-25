using Proxx.Core.BoardGeneration;
using Proxx.Core.Square;

var proxxContext = new ProxxContext(10, 10, 10, new UniformHolesDistributionStrategy(1000));

Console.WriteLine(proxxContext.Board);
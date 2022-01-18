using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownhillSimplex
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double[], double> Rosenbrock = variables => Math.Pow(1 - variables[0], 2) + 100 * Math.Pow(variables[1] - Math.Pow(variables[0], 2), 2);
            double[] initialGuess = new double[] { -3, -2 };
            bool[] editableVariables = new bool[] { true, true };

            DownhillSimplex downhillSimplex = new DownhillSimplex(Rosenbrock, initialGuess, editableVariables);

            downhillSimplex.boundaries = new (double min, double max)[] { (-10, 10), (-10, 10) };
            downhillSimplex.alpha = 1;
            downhillSimplex.gamma = 2;
            downhillSimplex.beta = 0.5;
            downhillSimplex.sigma = 0.5;

            downhillSimplex.relativeDeltaParameterTolerance = 1e-10;
            downhillSimplex.absoluteDeltaParameterTolerance = 0;
            downhillSimplex.maxAmountOfIterations = 1000;

            downhillSimplex.Fit(true);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CalculationEngineTest calculationEngineTest = new CalculationEngineTest();
            calculationEngineTest.CalculateDepreciationTest();
            calculationEngineTest.CalculateProjectionTest();
        }
    }
}

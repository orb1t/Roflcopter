﻿using NUnit.Framework;

namespace Roflcopter.Sample.UnitTesting.ParameterizedTestMissingArgumentRemoveParameterQuickFixTest
{
    public class TestCaseWithParameterWithMissingArgument
    {
        [TestCase{caret}("Arg")]
        public void TestCase(string paramA, string paramB)
        {
        }
    }
}

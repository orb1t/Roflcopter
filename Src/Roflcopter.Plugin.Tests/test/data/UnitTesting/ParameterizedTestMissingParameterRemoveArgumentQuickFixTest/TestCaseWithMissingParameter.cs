﻿using NUnit.Framework;

namespace Roflcopter.Sample.UnitTesting.ParameterizedTestMissingParameterRemoveArgumentQuickFixTest
{
    public class TestCaseWithMissingParameter
    {
        [TestCase("ArgA", "ArgB"{caret}, "ArgC")]
        public void Test(string param)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;

// ReSharper disable NUnit.IncorrectArgumentType (added in R# 2018.3)

namespace Roflcopter.Sample.UnitTesting.ParameterizedTestHighlightingTests
{
    [TestFixture]
    public class TestBuilderInterfaceSample
    {
        [Test]
        [CustomTestBuilder]
        // ReSharper disable once NUnit.MethodWithParametersAndTestAttribute (it's just wrong here)
        public void TestWithCustomTestBuilder(string paramA, string paramB)
        {
        }

        public class CustomTestBuilderAttribute : Attribute, ITestBuilder
        {
            public IEnumerable<TestMethod> BuildFrom(IMethodInfo method, Test suite)
            {
                var builder = new NUnitTestCaseBuilder();
                yield return builder.BuildTestMethod(method, suite, new TestCaseParameters(new object[] { "ArgA", "ArgB" }));
            }
        }

        //

        [Test]
        [TestCase("Arg")]
        public void WarningSample(int param)
        {
        }
    }
}

﻿using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Roflcopter.Sample.UnitTesting.ParameterizedTestHighlightingTests
{
    [TestFixture]
    public class ParameterDataSourceAttributeSamples
    {
        [Test]
        public void TestCustomDataAttribute([CustomData] string param)
        {
        }

        public class CustomDataAttribute : DataAttribute, IParameterDataSource
        {
            public IEnumerable GetData(IParameterInfo parameter) => new[] { "Arg1", "Arg2" };
        }

        //

        [Test]
        public void WarningSample([Values("Arg")] int param)
        {
        }
    }
}

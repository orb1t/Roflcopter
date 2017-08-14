﻿using System;
using JetBrains.Annotations;

// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable UnusedMember.Local

namespace Roflcopter.Sample.AssertionMessages.InvalidAssertionMessageHighlightingTests
{
    public class AssertionMessageContractAnnotationSamples
    {
        private const string ConstString = "ConstString != null";
        private readonly string _nonLiteralString = "NonLiteralString != null";

        // Note: These messages are generated by 'CSharpAssertionMessageItemProvider'.

        void AssertIsTrueNotNull(SomeClass c)
        {
            AssertIsTrue(c != null, "c != null");
            Console.WriteLine(c != null);
        }

        void AssertIsTrueNotNull_Invalid(SomeClass c) => AssertIsTrue(c != null, "x != null");

        void AssertIsTrueNotNullPropertyAccess(SomeClass c) => AssertIsTrue(c.Prop != null, "c.Prop != null");
        void AssertIsTrueNotNullPropertyAccess_Invalid(SomeClass c) => AssertIsTrue(c.Prop != null, "x.Prop != null");

        //

        void AssertIsTrueWithoutNullEqualityMessage(SomeClass c) => AssertIsTrue(c != null, "some message");
        void AssertIsTrueWithoutSpaces(SomeClass c) => AssertIsTrue(c.Prop != null, "c.Prop!=null");
        void AssertIsTrueWithAdditionalSpaces(SomeClass c) => AssertIsTrue(c.Prop != null, "  c  .  Prop  !=  null");
        void AssertIsTrueWithAdditionalSpaces_Invalid(SomeClass c) => AssertIsTrue(c.Prop != null, "  x  .  Prop  !=  null");

        //

        void AssertIsTrueWithoutMessageArgument(SomeClass c) => AssertIsTrue(c != null);
        void AssertIsTrueWithConstArgument(SomeClass c) => AssertIsTrue(c != null, ConstString);
        void AssertIsTrueWithNonLiteralArgument(SomeClass c) => AssertIsTrue(c != null, _nonLiteralString);

        void AssertIsTrueWithStringConcatArgument(SomeClass c) => AssertIsTrue(c != null, "a" + "b");

        //

        void AssertIsTrueWithoutContractAnnotationAttribute(string s)
        {
            AssertWithoutContractAnnotationAttribute(s != null, "irrelevant != null");
            Console.WriteLine(s != null);
        }

        void AssertWithNonMatchingContractAnnotation(string s) =>
            AssertWithNonMatchingContractAnnotation(s != null, "irrelevant != null");

        void AssertIsTrueWithNonHaltingConditionResult(string s) =>
            AssertIsTrueWithNonHaltingConditionResult(s != null, "irrelevant != null");

        void AssertIsTrueWithMultipleFdtRows(string s1, string s2, string s3)
        {
            AssertIsTrueWithMultipleFdtRows(s1 != null, "x1 != null", s2 != null, "irrelevant != null", s3 != null, "x3 != null");
            Console.WriteLine(s1 != null);
            Console.WriteLine(s2 != null);
            Console.WriteLine(s3 != null);
        }

        void AssertIsTrueWithMultipleFdtRowInputs()
        {
            // Note that multiple input-conditions in one row are logical conjunctions.
            AssertIsTrueWithMultipleFdtRowInputs(false, "irrelevant != null", false, "irrelevant != null");
            Console.WriteLine("unreachable because both conditions are fulfilled");
        }

        //

        void AssertNotNull(string s) => AssertNotNull(s, "s != null");
        void AssertNotNull_Invalid(string s) => AssertNotNull(s, "x != null");

        void AssertNotNullWithoutNullEqualityMessage(string s) => AssertNotNull(s, "some message");
        void AssertNotNullWithoutMessageArgument(string s) => AssertNotNull(s);

        //

        // Prove that the highlighting works for 'IS_TRUE' and 'IS_FALSE' + the condition "direction" *does* matter:

        void AssertIsTrue_Equals(string s) => AssertIsTrue(s == null, "s == null");
        void AssertIsTrue_Equals_Invalid(string s) => AssertIsTrue(s == null, "s != null");
        void AssertIsTrue_NotEquals(string s) => AssertIsTrue(s != null, "s != null");
        void AssertIsTrue_NotEquals_Invalid(string s) => AssertIsTrue(s != null, "s == null");
        void AssertIsFalse_Equals(string s) => AssertIsFalse(s == null, "s == null");
        void AssertIsFalse_Equals_Invalid(string s) => AssertIsFalse(s == null, "s != null");
        void AssertIsFalse_NotEquals(string s) => AssertIsFalse(s != null, "s != null");
        void AssertIsFalse_NotEquals_Invalid(string s) => AssertIsFalse(s != null, "s == null");

        //

        // Prove that the highlighting works for 'IS_NULL' and 'IS_NOT_NULL' + the condition "direction" *does not* matter:

        void AssertNotNull_Equals(string s) => AssertNotNull(s, "s == null");
        void AssertNotNull_Equals_Invalid(string s) => AssertNotNull(s, "x == null");
        void AssertNotNull_NotEquals(string s) => AssertNotNull(s, "s != null");
        void AssertNotNull_NotEquals_Invalid(string s) => AssertNotNull(s, "x != null");
        void AssertNull_Equals(string s) => AssertNull(s, "s == null");
        void AssertNull_Equals_Invalid(string s) => AssertNull(s, "x == null");
        void AssertNull_NotEquals(string s) => AssertNull(s, "s != null");
        void AssertNull_NotEquals_Invalid(string s) => AssertNull(s, "x != null");

        //

        [ContractAnnotation("condition:false => stop")]
        public static void AssertIsTrue(bool condition, string message = null)
        {
        }

        public static void AssertWithoutContractAnnotationAttribute(bool condition, string message)
        {
        }

        [ContractAnnotation("condition2:false => stop")]
        public static void AssertWithNonMatchingContractAnnotation(bool condition, string message, bool condition2 = false)
        {
        }

        [ContractAnnotation("condition:false => false")]
        public static bool AssertIsTrueWithNonHaltingConditionResult(bool condition, string message) => condition;

        [ContractAnnotation("condition1:false => stop; condition3:false => stop")]
        public static void AssertIsTrueWithMultipleFdtRows(bool condition1, string m1, bool condition2, string m2, bool condition3, string m3)
        {
        }

        [ContractAnnotation("condition1:false, condition2:false => stop")]
        public static void AssertIsTrueWithMultipleFdtRowInputs(bool condition1, string m1, bool condition2, string m2)
        {
        }

        [ContractAnnotation("condition:true => stop")]
        public static void AssertIsFalse(bool condition, string message)
        {
        }

        [ContractAnnotation("value:null => stop")]
        public static void AssertNotNull(object value, string message = null)
        {
        }

        [ContractAnnotation("value:notnull => stop")]
        public static void AssertNull(object value, string message)
        {
        }

        public class SomeClass
        {
            public string Prop { get; set; }
            public bool Bool { get; set; }
        }
    }
}

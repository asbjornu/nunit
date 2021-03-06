// ***********************************************************************
// Copyright (c) 2007 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using NUnit.Framework.Constraints;

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class NotConstraintTests : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new NotConstraint( new EqualConstraint(null) );
            expectedDescription = "not equal to null";
            stringRepresentation = "<not <equal null>>";
        }

        static object[] SuccessData = new object[] { 42, "Hello" };
            
        static object[] FailureData = new object [] { new object[] { null, "null" } };

        [Test]
        public void NotHonorsIgnoreCaseUsingConstructors()
        {
            var ex = Assert.Throws<AssertionException>(() => Assert.That("abc", new NotConstraint(new EqualConstraint("ABC").IgnoreCase)));
            Assert.That(ex.Message, Does.Contain("ignoring case"));
        }

        [Test]
        public void NotHonorsIgnoreCaseUsingPrefixNotation()
        {
            var ex = Assert.Throws<AssertionException>(() => Assert.That( "abc", Is.Not.EqualTo( "ABC" ).IgnoreCase ));
            Assert.That(ex.Message, Does.Contain("ignoring case"));
        }

        [Test]
        public void NotHonorsTolerance()
        {
            var ex = Assert.Throws<AssertionException>(() => Assert.That( 4.99d, Is.Not.EqualTo( 5.0d ).Within( .05d ) ));
            Assert.That(ex.Message, Does.Contain("+/-"));
        }

        [Test]
        public void CanUseNotOperator()
        {
            Assert.That(42, !new EqualConstraint(99));
        }
    }
}
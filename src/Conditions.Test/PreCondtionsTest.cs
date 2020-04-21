using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Mwd.Conditions;

namespace Conditions.Test
{
    public class PreCondtionsTest
    {
        [Fact]
        public void RequiresNotNull_ObjIsNull_ThrowException()
        {
            string obj = null;

            Assert.ThrowsAny<PreConditionFailedException>(
                () => obj.RequiresNotNull("obj shall not be null"));
        }

        [Fact]
        public void RequiresAll_OneElementIsFalse_ThrowException()
        {
            bool[] arr = new bool[] { true, false, true };

            Assert.ThrowsAny<PreConditionFailedException>(
                () => arr.RequiresAll(b => b != false, "Not all elements true"));
        }

        [Fact]
        public void RequiresAny_OneElementsAreFalse_ThrowException()
        {
            bool[] arr = new bool[] { false, false, false };

            Assert.ThrowsAny<PreConditionFailedException>(
                () => arr.RequiresAny(b => b , "Not only one element is true"));
        }
    }
}

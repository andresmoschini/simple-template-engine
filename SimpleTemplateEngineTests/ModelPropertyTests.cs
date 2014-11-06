using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTemplateEngine;
using SimpleTemplateEngine.Parser;
using System.Collections.Generic;

namespace SimpleTemplateEngineTests
{
    [TestClass]
    public class ModelPropertyTests
    {
        [TestMethod]
        public void ItShouldReturnEmptyForNullObject()
        {
            var value = ModelProperty.FromObject(null, "StringProperty");
            Assert.AreEqual(ModelProperty.Empty, value);
        }

        [TestMethod]
        public void ItShouldReturnEmptyForInexistentProperties()
        {
            var o = new
            {
                StringProperty = "StringValue",
                EmptyStringProperty = "",
                BooleanPropertyTrue = true,
            };

            var value = ModelProperty.FromObject(o, "Inexistent");
            Assert.AreEqual(ModelProperty.Empty, value);
        }
    
        [TestMethod]
        public void TestCasting()
        {
            var o = new
            {
                StringProperty = "StringValue",
                EmptyStringProperty = "",
                BooleanPropertyTrue = true,
                BooleanPropertyFalse = false,
                EmptyListProperty = new object[] { },
                NullListProperty = (List<string>)null,
                StringListProperty = new[] { "item1", "item2" },
                SingleItemStringListProperty = new[] { "item1" },
                ObjectListProperty = new[] { new { name = "value1" }, new { name = "value2" } }
            };

            var stringProperty = ModelProperty.FromObject(o, "StringProperty");
            Assert.IsTrue(stringProperty.BooleanValue);
            Assert.AreEqual("StringValue", stringProperty.StringValue);
            Assert.AreEqual(0, stringProperty.ListValue.Length);

            var emptyStringProperty = ModelProperty.FromObject(o, "EmptyStringProperty");
            Assert.IsFalse(emptyStringProperty.BooleanValue);
            Assert.AreEqual("", emptyStringProperty.StringValue);
            Assert.AreEqual(0, emptyStringProperty.ListValue.Length);

            var booleanPropertyTrue = ModelProperty.FromObject(o, "BooleanPropertyTrue");
            Assert.IsTrue(booleanPropertyTrue.BooleanValue);
            Assert.AreEqual("True", booleanPropertyTrue.StringValue);
            Assert.AreEqual(0, booleanPropertyTrue.ListValue.Length);

            var booleanPropertyFalse = ModelProperty.FromObject(o, "BooleanPropertyFalse");
            Assert.IsFalse(booleanPropertyFalse.BooleanValue);
            Assert.AreEqual("False", booleanPropertyFalse.StringValue);
            Assert.AreEqual(0, booleanPropertyFalse.ListValue.Length);

            var emptyListProperty = ModelProperty.FromObject(o, "EmptyListProperty");
            Assert.IsFalse(emptyListProperty.BooleanValue);
            Assert.AreEqual("[Empty]", emptyListProperty.StringValue);
            Assert.AreEqual(0, emptyListProperty.ListValue.Length);

            var nullListProperty = ModelProperty.FromObject(o, "NullListProperty");
            Assert.IsFalse(nullListProperty.BooleanValue);
            Assert.AreEqual("[Empty]", nullListProperty.StringValue);
            Assert.AreEqual(0, nullListProperty.ListValue.Length);

            var stringListProperty = ModelProperty.FromObject(o, "StringListProperty");
            Assert.IsTrue(stringListProperty.BooleanValue);
            Assert.AreEqual("[2 items]", stringListProperty.StringValue);
            Assert.AreEqual(2, stringListProperty.ListValue.Length);

            var singleItemStringListProperty = ModelProperty.FromObject(o, "SingleItemStringListProperty");
            Assert.IsTrue(singleItemStringListProperty.BooleanValue);
            Assert.AreEqual("[1 item]", singleItemStringListProperty.StringValue);
            Assert.AreEqual(1, singleItemStringListProperty.ListValue.Length);

            var objectListProperty = ModelProperty.FromObject(o, "ObjectListProperty");
            Assert.IsTrue(objectListProperty.BooleanValue);
            Assert.AreEqual("[2 items]", objectListProperty.StringValue);
            Assert.AreEqual(2, objectListProperty.ListValue.Length);
        }
    }
}

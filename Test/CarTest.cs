using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nostrum.railwaycar;

namespace Test
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestValidNumber()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");
            Assert.AreEqual(true, hopper.IsNumberCorrect, "Car number not valid");
        }

        [TestMethod]
        public void TestCarAxless()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");
            Assert.AreEqual(4, hopper.Axless, "Car axless calculation error");
        }

        [TestMethod]
        public void TestCarNumber_53240180()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");

            Assert.AreEqual("53240180", hopper.Number, "Car number 53240180 parse error");
            Assert.AreEqual(true, hopper.IsNumberCorrect, "Car number 53240180 parse error");

            Assert.AreEqual(5, hopper.d1, "Car number 53240180 digit 1 parse error");
            Assert.AreEqual(3, hopper.d2, "Car number 53240180 digit 2 parse error");
            Assert.AreEqual(2, hopper.d3, "Car number 53240180 digit 3 parse error");
            Assert.AreEqual(4, hopper.d4, "Car number 53240180 digit 4 parse error");
            Assert.AreEqual(0, hopper.d5, "Car number 53240180 digit 5 parse error");
            Assert.AreEqual(1, hopper.d6, "Car number 53240180 digit 6 parse error");
            Assert.AreEqual(8, hopper.d7, "Car number 53240180 digit 7 parse error");
            Assert.AreEqual(0, hopper.d8, "Car number 53240180 digit 8 parse error");

            Assert.AreEqual("Прочие", hopper.CarType, "Car number 53240180 car type parse error");
            Assert.AreEqual("для перевозки минеральных удобрений", hopper.AdditionalCharacteristic, "Car number 53240180 car additional characteristic parse error");
            Assert.AreEqual(21.3m, hopper.TareWeight, "Car number 53240180 car tare weight parse error");
            Assert.AreEqual(14720, hopper.Length, "Car number 53240180 car length parse error");
            Assert.AreEqual(true, hopper.HasBrakePad, "Car number 53240180 car brake pad parse error");
            Assert.AreEqual(true, hopper.IsPrivate, "Car number 53240180 car private state parse error");
            Assert.AreEqual("5931", hopper.TypeNumber, "Car number 53240180 car type number parse error");
            Assert.AreEqual(4, hopper.Axless, "Car number 53240180 axless parse error");

            //№ вагона: 53240180
            //Род вагона: Прочие
            //Основная характеристика: 4 - осный хоппер
            //Число осей: 4
            //Дополнительная характеристика: для перевозки минеральных удобрений
            //Масса тары, т: 21,30
            //Длина вагона, мм: 14720
            //№ типа вагона: 5931
            //Собственный
            //С тормозной площадкой
            //Номер указан правильно
        }

    }
}

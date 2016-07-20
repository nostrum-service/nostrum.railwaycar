using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nostrum.railwaycar;

namespace Test
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestEnumParser()
        {
            Assert.AreEqual(CarTypeEnum.tank, RailwayCarData.GetCarType("Цистерна"), "Car type parse error");
            Assert.AreEqual(CarTypeEnum.gondola, RailwayCarData.GetCarType("Полувагон"), "Car type parse error");
            Assert.AreEqual(CarTypeEnum.boxcar, RailwayCarData.GetCarType("Крытый"), "Car type parse error");
            Assert.AreEqual(CarTypeEnum.isothermal, RailwayCarData.GetCarType("Изотермический"), "Car type parse error");
            Assert.AreEqual(CarTypeEnum.platform, RailwayCarData.GetCarType("Платформа"), "Car type parse error");
            Assert.AreEqual(CarTypeEnum.other, RailwayCarData.GetCarType("Прочие"), "Car type parse error");
        }

        [TestMethod]
        public void TestValidNumber()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");
            Assert.AreEqual(true, hopper.IsNumberValid, "Car number not valid");
        }

        [TestMethod]
        public void TestCarAxles_53240180()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");
            Assert.AreEqual(4, hopper.Axles, "Car axless calculation error");
        }

        [TestMethod]
        public void TestCarAxles_90299637()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("90299637");
            Assert.AreEqual(4, hopper.Axles, "Car axless calculation error");
        }
        
        
        [TestMethod]
        public void TestCarNumber_53240180()
        {
            RailwayCarInfo hopper = RailwayCarInfo.ParseCarNumber("53240180");

            Assert.AreEqual("53240180", hopper.Number, "Car number 53240180 parse error");
            Assert.AreEqual(true, hopper.IsNumberValid, "Car number 53240180 parse error");

            Assert.AreEqual(5, hopper.d1, "Car number 53240180 digit 1 parse error");
            Assert.AreEqual(3, hopper.d2, "Car number 53240180 digit 2 parse error");
            Assert.AreEqual(2, hopper.d3, "Car number 53240180 digit 3 parse error");
            Assert.AreEqual(4, hopper.d4, "Car number 53240180 digit 4 parse error");
            Assert.AreEqual(0, hopper.d5, "Car number 53240180 digit 5 parse error");
            Assert.AreEqual(1, hopper.d6, "Car number 53240180 digit 6 parse error");
            Assert.AreEqual(8, hopper.d7, "Car number 53240180 digit 7 parse error");
            Assert.AreEqual(0, hopper.d8, "Car number 53240180 digit 8 parse error");

            Assert.AreEqual(CarTypeEnum.other, hopper.CarType, "Car number 53240180 car type parse error");
            Assert.AreEqual("прочие", hopper.CarTypeName, "Car number 53240180 car type parse error");

            Assert.AreEqual("для перевозки минеральных удобрений", hopper.AdditionalCharacteristic, "Car number 53240180 car additional characteristic parse error");
            Assert.AreEqual(21.3m, hopper.TareWeight, "Car number 53240180 car tare weight parse error");
            Assert.AreEqual(14720, hopper.Length, "Car number 53240180 car length parse error");
            Assert.AreEqual(true, hopper.HasBrakePad, "Car number 53240180 car brake pad parse error");
            Assert.AreEqual(true, hopper.IsPrivate, "Car number 53240180 car private state parse error");
            Assert.AreEqual("5931", hopper.TypeNumber, "Car number 53240180 car type number parse error");
            Assert.AreEqual(4, hopper.Axles, "Car number 53240180 axless parse error");

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

        [TestMethod]
        public void TestCarNumber_72543291()
        {
            RailwayCarInfo car = RailwayCarInfo.ParseCarNumber("72543291");

            Assert.AreEqual("72543291", car.Number, "Car number 72543291 parse error");
            Assert.AreEqual(true, car.IsNumberValid, "Car number 72543291 parse error");

            Assert.AreEqual(7, car.d1, "Car number 72543291 digit 1 parse error");
            Assert.AreEqual(2, car.d2, "Car number 72543291 digit 2 parse error");
            Assert.AreEqual(5, car.d3, "Car number 72543291 digit 3 parse error");
            Assert.AreEqual(4, car.d4, "Car number 72543291 digit 4 parse error");
            Assert.AreEqual(3, car.d5, "Car number 72543291 digit 5 parse error");
            Assert.AreEqual(2, car.d6, "Car number 72543291 digit 6 parse error");
            Assert.AreEqual(9, car.d7, "Car number 72543291 digit 7 parse error");
            Assert.AreEqual(1, car.d8, "Car number 72543291 digit 8 parse error");

            Assert.AreEqual(CarTypeEnum.tank, car.CarType, "Car number 72543291 car type parse error");
            Assert.AreEqual("цистерна", car.CarTypeName, "Car number 72543291 car type parse error");

            Assert.AreEqual("характеристики не содержит", car.AdditionalCharacteristic, "Car number 72543291 car additional characteristic parse error");
            Assert.AreEqual(24.5m, car.TareWeight, "Car number 72543291 car tare weight parse error");
            Assert.AreEqual(12220, car.Length, "Car number 72543291 car length parse error");
            Assert.AreEqual(true, car.HasBrakePad, "Car number 72543291 car brake pad parse error");
            Assert.AreEqual(false, car.IsPrivate, "Car number 72543291 car private state parse error");
            Assert.AreEqual("721", car.TypeNumber, "Car number 72543291 car type number parse error");
            Assert.AreEqual(4, car.Axles, "Car number 72543291 axless parse error");

            //№ вагона: 72543291
            //Род вагона: цистерна
            //Основная характеристика: 4-осная, объем котла 50-63 куб.м, для нефти и темных нефтепродуктов
            //Число осей: 4
            //Дополнительная характеристика: характеристики не содержит
            //Масса тары, т: 24,50
            //Длина вагона, мм: 12220
            //№ типа вагона: 721
            //Парк МПС
            //С тормозной площадкой
            //Номер указан правильно

        }
    }
}

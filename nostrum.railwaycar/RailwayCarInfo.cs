using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace nostrum.railwaycar
{
    [Description("Род вагона")]
    public enum CarTypeEnum
    {
        [Description("прочие")]
        other,

        [Description("цистерна")]
        tank,

        [Description("крытый")]
        boxcar,

        [Description("платформа")]
        platform,

        [Description("полувагон")]
        gondola,

        [Description("изотермический")]
        isothermal
    }

    [XmlType("RailwayCarData")]
    public class RailwayCarData
    {
        [XmlAttribute("IsPrivate")]
        public bool IsPrivate { get; set; }

        [XmlAttribute("HasBrakePad")]
        public bool HasBrakePad { get; set; }

        [XmlIgnore]
        public int? Axless { get; set; }

        [XmlIgnore]
        public int? Length { get; set; }

        [XmlAttribute("Length")]
        public string LengthAsText
        {
            get { return (Length.HasValue) ? Length.ToString() : null; }
            set { Length = !string.IsNullOrEmpty(value) ? int.Parse(value) : default(int?); }
        }

        [XmlIgnore]
        public decimal? TareWeight { get; set; }

        [XmlAttribute("TareWeight")]
        public string TareWeightAsText
        {
            get { return (TareWeight.HasValue) ? TareWeight.ToString() : null; }
            set { TareWeight = !string.IsNullOrEmpty(value) ? decimal.Parse(value, NumberStyles.Any, CultureInfo.InvariantCulture) : default(decimal?); }
        }

        [XmlAttribute("TypeNumber")]
        public string TypeNumber { get; set; }

        [XmlAttribute("CarType")]
        public string CarType { get; set; }

        [XmlAttribute("MainCharacteristic")]
        public string MainCharacteristic { get; set; }

        [XmlAttribute("AdditionalCharacteristic")]
        public string AdditionalCharacteristic { get; set; }

        [XmlAttribute("d1")]
        public int d1 { get; set; }

        [XmlAttribute("d2_min")]
        public int d2_min { get; set; }

        [XmlAttribute("d2_max")]
        public int d2_max { get; set; }

        [XmlAttribute("d3_min")]
        public int d3_min { get; set; }

        [XmlAttribute("d3_max")]
        public int d3_max { get; set; }

        [XmlAttribute("d4_min")]
        public int d4_min { get; set; }

        [XmlAttribute("d4_max")]
        public int d4_max { get; set; }

        [XmlAttribute("d5_min")]
        public int d5_min { get; set; }

        [XmlAttribute("d5_max")]
        public int d5_max { get; set; }

        [XmlAttribute("d6_min")]
        public int d6_min { get; set; }

        [XmlAttribute("d6_max")]
        public int d6_max { get; set; }

        [XmlAttribute("d7_min")]
        public int d7_min { get; set; }

        [XmlAttribute("d7_max")]
        public int d7_max { get; set; }


    }

    [XmlRoot("RailwayCarTypes")]
    public class RailwayCarDataCollection
    {
        [XmlElement("RailwayCarData")]
        public RailwayCarData[] CarTypes { get; set; }
    }
    public class RailwayCarInfo
    {
        public static RailwayCarDataCollection source;

        static RailwayCarInfo()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RailwayCarDataCollection));
            source = (RailwayCarDataCollection)serializer.Deserialize(new StringReader(global::nostrum.railwaycar.Properties.Resources.car_types));
        }

        public static RailwayCarInfo ParseCarNumber(string number)
        {
            number = Regex.Replace(number, @"\s{1,}", "");
            RailwayCarInfo result = new RailwayCarInfo
            {
                Number = number,
                IsNumberCorrect = CheckNumber(number),
                Axless = GetAxles(number)
            };

            result.d1 = null;
            result.d2 = null;
            result.d3 = null;
            result.d4 = null;
            result.d5 = null;
            result.d6 = null;
            result.d7 = null;
            result.d8 = null;

            int tmp;
            if (number.Length > 0)
                result.d1 = int.TryParse(number.Substring(0, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 1)
                result.d2 = int.TryParse(number.Substring(1, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 2)
                result.d3 = int.TryParse(number.Substring(2, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 3)
                result.d4 = int.TryParse(number.Substring(3, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 4)
                result.d5 = int.TryParse(number.Substring(4, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 5)
                result.d6 = int.TryParse(number.Substring(5, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 6)
                result.d7 = int.TryParse(number.Substring(6, 1), out tmp) ? (int?)tmp : null;

            if (number.Length > 7)
                result.d8 = int.TryParse(number.Substring(7, 1), out tmp) ? (int?)tmp : null;

            if (result.IsNumberCorrect)
            {
                RailwayCarData data = source.CarTypes.FirstOrDefault(x => x.d1 == (int)result.d1
                    && x.d2_min <= (int)result.d2 && x.d2_max >= (int)result.d2
                    && x.d3_min <= (int)result.d3 && x.d3_max >= (int)result.d3
                    && x.d4_min <= (int)result.d4 && x.d4_max >= (int)result.d4
                    && x.d5_min <= (int)result.d5 && x.d5_max >= (int)result.d5
                    && x.d6_min <= (int)result.d6 && x.d6_max >= (int)result.d6
                    && x.d7_min <= (int)result.d7 && x.d7_max >= (int)result.d7);

                if (data != null)
                {
                    result.CarType = data.CarType;
                    result.MainCharacteristic = data.MainCharacteristic;
                    result.AdditionalCharacteristic = data.AdditionalCharacteristic;
                    //result.Axless = data.Axless;
                    result.HasBrakePad = data.HasBrakePad;
                    result.IsPrivate = data.IsPrivate;
                    result.Length = data.Length;
                    result.TareWeight = data.TareWeight;
                    result.TypeNumber = data.TypeNumber;
                }
            }

            return result;
        }

        public static bool CheckNumber(String number)
        {
            number = Regex.Replace(number, @"\s{1,}", "");

            try
            {
                int code = 0;
                if (number.Length == 8)
                {
                    int[] kx7 = new int[] { 2, 1, 2, 1, 2, 1, 2 };
                    for (int idx = 0; idx < kx7.Count(); idx++)
                    {
                        int tmpResult = kx7[idx] * Int32.Parse("" + number[idx]);
                        code += tmpResult > 9 ? (tmpResult / 10 + tmpResult % 10) : tmpResult;
                    }

                    code = ((int)Math.Ceiling((decimal)code / 10) * 10 - code);
                    return Int32.Parse("" + number[7]) == code;
                }
            }
            catch
            {
            }

            return false;
        }

        public static int? GetAxles(String number)
        {
            int? axles = null;

            try
            {
                number = Regex.Replace(number, @"\s{1,}", "");
                String code = number.Substring(1, 1);

                if (code == "0" || code == "1")
                    axles = 2;
                else if (code == "2" || code == "3" || code == "4" || code == "5" || code == "6" || code == "7")
                    axles = 4;
                else if (code == "8")
                    axles = 6;
                else if (code == "9")
                    axles = null;
            }
            catch
            {
                axles = null;
            }

            return axles;
        }

        public string Number { get; set; }
        public bool IsNumberCorrect { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? HasBrakePad { get; set; }
        public int? Axless { get; set; }
        public int? Length { get; set; }
        public decimal? TareWeight { get; set; }
        public string TypeNumber { get; set; }

        public string CarType { get; set; }
        public string MainCharacteristic { get; set; }
        public string AdditionalCharacteristic { get; set; }

        public int? d1 { get; set; }
        public int? d2 { get; set; }
        public int? d3 { get; set; }
        public int? d4 { get; set; }
        public int? d5 { get; set; }
        public int? d6 { get; set; }
        public int? d7 { get; set; }
        public int? d8 { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("№ вагона: " + Number);
            sb.AppendLine("Род вагона: " + CarType);
            sb.AppendLine("Основная характеристика: " + MainCharacteristic);
            sb.AppendLine("Число осей: " + Axless);
            sb.AppendLine("Дополнительная характеристика: " + AdditionalCharacteristic);
            sb.AppendLine(string.Format("Масса тары, т: {0:n2}", TareWeight));
            sb.AppendLine(string.Format("Длина вагона, мм: {0:n0}", Length));
            sb.AppendLine("№ типа вагона: " + TypeNumber);
            if (IsPrivate.HasValue ? (bool)IsPrivate : false)
            {
                sb.AppendLine("Собственный");
            }

            if (HasBrakePad.HasValue)
            {
                if ((bool)HasBrakePad)
                    sb.AppendLine("С тормозной площадкой");
                else
                    sb.AppendLine("Без тормозной площадки");
            }

            if (IsNumberCorrect)
                sb.AppendLine("Номер указан правильно");
            else
                sb.AppendLine("Номер указан неправильно");

            return sb.ToString();
        }
    }

}

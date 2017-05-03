using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CSV;
using Newtonsoft.Json;

namespace IO_Testing
{
    class Product
    {
        public string Name { get; internal set; }
        public DateTime Expiry { get; internal set; }
        public string[] Sizes { get; internal set; }
    }

    class OilAdjustment
    {
        public double Rate { get; internal set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path  = Path.Combine(Environment.CurrentDirectory, @"Data\OilAdjustment.csv");
            string path2 = Path.Combine(Environment.CurrentDirectory, @"Data\test.csv");
            string path3 = Path.Combine(Environment.CurrentDirectory, @"Data\empty.csv");

            string oil_testfile = Path.Combine(Environment.CurrentDirectory, @"Data\oil_testfile.json");

            OilAdjustment oilAdjustment = new OilAdjustment();
            oilAdjustment.Rate = 25.1;

            string json = JsonConvert.SerializeObject(oilAdjustment);

            System.IO.File.WriteAllText(oil_testfile, json);


            Console.Read();
        }

        private static void ProductTest()
        {
            string JSON_testfile = Path.Combine(Environment.CurrentDirectory, @"Data\JSON_testfile.json");



            Product product = new Product();
            product.Name = "Babble";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };

            string json = JsonConvert.SerializeObject(product);

            System.IO.File.WriteAllText(JSON_testfile, json);

            Console.WriteLine(json);



            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);

            deserializedProduct.Name = "Apple";

            string json_final = JsonConvert.SerializeObject(deserializedProduct);

            Console.WriteLine(json_final);
        }
    }
}

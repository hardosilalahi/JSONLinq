using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace tutorlinq
{
    public class order{
        public string Order_id{get; set;}
        public DateTime Created_at{get; set;}
        public customer Customer{get; set;}
        public List<items> Items{get; set;}
    }
    public class customer{
        public int Id{get; set;}
        public string Name{get; set;}

    }
    public class items{
        public int Id{get; set;}
        public string Name{get; set;}
        public int Qty{get; set;}
        public int Price{get; set;}
    }


    public class readJsonTwo{
        protected static string filePath = @"/Users/user/tutorlinq/jsonFiles/data2.json";
        protected static string json = File.ReadAllText(filePath);
        protected static List<order> jObject = JsonConvert.DeserializeObject<List<order>>(json);

    }

    public class solutionsTwo : readJsonTwo{
        public static IEnumerable<string> purchaseFeb(){
            return jObject
            .Where(n => n.Created_at.ToLocalTime().Month == 02)
            .Select(n => n.Order_id);
        }
        public static int AriBeli(){
            return jObject
            .Where(n => n.Customer.Name.ToLower() == "ari")
            .Sum(n => n.Items.Sum(j => j.Price * j.Qty));
        }
        public static int RirinBeli(){
            return jObject
            .Where(n => n.Customer.Name.ToLower() == "ririn")
            .Sum(n => n.Items.Sum(j => j.Price * j.Qty));
        }
        public static int AnnisBeli(){
            return jObject
            .Where(n => n.Customer.Name.ToLower() == "annis")
            .Sum(n => n.Items.Sum(j => j.Price * j.Qty));
        }
        public static IEnumerable<string> GrandLow(){
            return jObject
            .GroupBy(
                n => n.Customer.Name,
                n => n.Items.Sum(j => j.Price * j.Qty),
                (pembeli, total) => new{
                    Pembeli = pembeli,
                    Total = total.Sum()
                }
            )
            .Where(n => n.Total < 300000)
            .Select(n => n.Pembeli);
        }
    }
    
    public class GrandPrice{
        static string filePath = @"/Users/user/JsonChallenge/jsonFiles/data2.json";
        
        public string GrandLow(){
            var json = File.ReadAllText(filePath);
            var jObject = JsonConvert.DeserializeObject<List<order>>(json);

            List<string> iritPeople = new List<string>();
            List<string> nameList = new List<string>();

            foreach (var i in jObject){nameList.Add(i.Customer.Name);}

            var buyerList = nameList.Distinct();

            string[] Buyer = buyerList.ToArray();

            int buyerCount = buyerList.Count();
            int jumlah = 0;

            for (int i = 0; i < buyerCount; i++){
                foreach (var j in jObject){
                    if (j.Customer.Name == Buyer[i]){
                        foreach (var k in j.Items){
                            jumlah += ((k.Price) * (k.Qty));
                        }
                    }
                }

                if (jumlah < 300000){
                    iritPeople.Add(Buyer[i]);
                    jumlah = 0;
                }
                else{
                    jumlah = 0;
                }
            }

            return String.Join(',', iritPeople);
        }
    }
}

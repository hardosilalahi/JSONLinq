using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace tutorlinq
{
    public class inventaris{
        public int Inventory_id{get; set;}
        public string Name{get; set;}
        public string Type{get; set;}
        public List<string> Tags{get; set;}
        public int Purchased_at{get; set;}
        public penempatan Placement{get; set;}
    }

    public class penempatan{
        public int Room_id{get; set;}
        public string Name{get; set;}
    }

    public class readJsonThree{
        protected static string filePath = @"/Users/user/tutorlinq/jsonFiles/data3.json";
        protected static string json = File.ReadAllText(filePath);
        protected static List<inventaris> jObject = JsonConvert.DeserializeObject<List<inventaris>>(json);

    }

    public class solutionsThree : readJsonThree{
        public static void itemMeetingRoom(){
            string savePath = @"/Users/user/tutorlinq/jsonFiles/items.json";
            var result = jObject.Where(n => n.Placement.Name.ToLower() == "meeting room");
            var savedFile = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, savedFile);
        }
        public static void electronicDevices(){
            string savePath = @"/Users/user/tutorlinq/jsonFiles/electronic.json";
            var result = jObject.Where(n => n.Type.ToLower() == "electronic");
            var savedFile = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, savedFile);
        }
        public static void Furnitures(){
            string savePath = @"/Users/user/tutorlinq/jsonFiles/furnitures.json";
            var result = jObject.Where(n => n.Type.ToLower() == "furniture");
            var savedFile = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, savedFile);
        }
        public static void PurchasedAt(){
            string savePath = @"/Users/user/tutorlinq/jsonFiles/purchased-at-2020-01-16.json";
            var result = jObject
            .Where(n => n.Purchased_at.ToString().Contains("15791"));
            var savedFile = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, savedFile);
        }
        public static void ItemBrown(){
            string savePath = @"/Users/user/tutorlinq/jsonFiles/all-browns.json";
            var result = jObject.Where(n => n.Tags.Contains("brown"));
            var savedFile = JsonConvert.SerializeObject(result);
            File.WriteAllText(savePath, savedFile);
        }
    }
}
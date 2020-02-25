using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace tutorlinq
{
    public class user{
        public string Id{get; set;}
        public string Username{get; set;}
        public profile Profile{get; set;}
        public List<articles> Articles{get; set;}
    }
    public class profile{
        public string Full_name{get; set;}
        public DateTime Birthday{get; set;}
        public List<string> Phones{get; set;}
    }
    public class articles{
        public int Id{get; set;}
        public string Title{get; set;}
        public DateTime Published_at{get; set;}
    }

    public class readJsonOne{
        protected static string filePath = @"/Users/user/tutorlinq/jsonFiles/data1.json";
        protected static string json = File.ReadAllText(filePath);
        protected static List<user> jObject = JsonConvert.DeserializeObject<List<user>>(json);

    }

    public class solutionsOne : readJsonOne{
        public static IEnumerable<string> noPhoneNumber(){
            return jObject
            .Where(n => !n.Profile.Phones.Any())
            .Select(n => n.Profile.Full_name);
        }
        public static IEnumerable<string> HaveArticles(){
            return jObject
            .Where(n => n.Articles.Any())
            .Select(n => n.Profile.Full_name);
        }
        public static IEnumerable<string> HaveAnnis(){
            return jObject
            .Where(n => n.Profile.Full_name.ToLower().Contains("annis"))
            .Select(n => n.Profile.Full_name);
        }
        public static IEnumerable<string> Articles2020(){
            return jObject
            .Where(n => n.Articles.Any(j => j.Published_at.ToLocalTime().Year == 2020))
            .Select(n => n.Profile.Full_name);
        }
        public static IEnumerable<string> User1986(){
            return jObject
            .Where(n => n.Profile.Birthday.ToLocalTime().Year == 1986)
            .Select(n => n.Profile.Full_name);
        }
        public static IEnumerable<string> ContainsTips(){
            return jObject
            .SelectMany(n => n.Articles
                .Where(j => j.Title.ToLower().Contains("tips"))
            .Select(k => k.Title));
        }
        public static IEnumerable<string> AugustArticle(){
            return jObject
            .SelectMany(n => n.Articles
                .Where(j => j.Published_at.ToLocalTime().Year <= 2019 &&
                j.Published_at.ToLocalTime().Month < 08)
            .Select(k => k.Title));
        }
    }
}
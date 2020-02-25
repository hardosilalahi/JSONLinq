using System;
using System.IO;
using System.Linq;

namespace tutorlinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //num one
            var noPhone = solutionsOne.noPhoneNumber();
            var haveArticles = solutionsOne.HaveArticles();
            var haveAnnis = solutionsOne.HaveAnnis();
            var articles2020 = solutionsOne.Articles2020();
            var user1986 = solutionsOne.User1986();
            var tips = solutionsOne.ContainsTips();
            var august2019 = solutionsOne.AugustArticle();
            
            //num two
            var beliFeb = solutionsTwo.purchaseFeb();
            var ariBeli = solutionsTwo.AriBeli();
            var ririnBeli = solutionsTwo.RirinBeli();
            var annisBeli = solutionsTwo.AnnisBeli();
            var grandPrice = solutionsTwo.GrandLow();

            //num three
            // solutionsThree.PurchasedAt();
            // solutionsThree.electronicDevices();
            // solutionsThree.itemMeetingRoom();
            // solutionsThree.ItemBrown();
            // solutionsThree.Furnitures();

            Console.WriteLine(articles2020);
        }
    }
}

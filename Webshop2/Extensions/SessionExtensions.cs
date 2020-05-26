using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2
{
    public static class SessionExtensions
    {
        public static void SetUserName(this ISession session, string username) //ISession ir iebūvēta klase, ko mēs paplašinām, pievienojot username
        {
            session.SetString("username", username); //zem norādītās atslēgas uzstādām vērtību
        }
        public static string GetUserName(this ISession session)
        {
            return session.GetString("username"); //tikai lasa vērtību
        }
        public static void SetUserId(this ISession session, int userId) //ISession ir iebūvēta klase, ko mēs paplašinām, pievienojot uerId
        {
            session.SetInt32("userId", userId); //zem norādītās atslēgas uzstādām vērtību
        }
        public static int GetUserId(this ISession session)
        {
            return session.GetInt32("userId").Value; //tikai lasa vērtību
        }
        public static void SetIsAdmin(this ISession session, bool isAdmin)
        {
            session.SetInt32("isAdmin", isAdmin ? 1 : 0); //ja ir admins 1 = true, citādi 0
        }
        public static bool GetIsAdmin(this ISession session)
        {
            // return session.GetInt32("isAdmin") == 1 ? true : false;
            // vēl var tā:
            return session.GetInt32("isAdmin") == 1;
        }
    }
}

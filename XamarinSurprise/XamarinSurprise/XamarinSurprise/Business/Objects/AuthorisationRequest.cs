using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinSurprise.Objects
{
    class AuthorisationRequest
    {
        #region Fields
        public int Id;
        public String Description;
        public String KassaOperatorName;
        public String Location;
        public double TotalAmount;
        public String ShopName;
        public String Date;
        public String Time;
        public String Status;
        public String KassaId;
        public String Progressed;
        public int AvailableUsers;
        #endregion

        #region Constructor
        public AuthorisationRequest(int id, String description, String kassaOperatorName, String location, double totalAmount, String shopName, String date, String time, String status, String kassaId, String progressed, int availableUsers)
        {
            Id = id;
            Description = description;
            KassaOperatorName = kassaOperatorName;
            Location = location;
            TotalAmount = totalAmount;
            ShopName = shopName;
            Date = date;
            Time = time;
            Status = status;
            KassaId = kassaId;
            Progressed = progressed;
            AvailableUsers = availableUsers;
        }
        #endregion

        #region Propertys
        public int getId()
        {
            return Id;
        }

        public void setId(int id)
        {
            Id = id;
        }

        public String getDescription()
        {
            return Description;
        }

        public void setDescription(String description)
        {
            Description = description;
        }

        public String getKassaOperatorName()
        {
            return KassaOperatorName;
        }

        public void setKassaOperatorName(String kassaOperatorName)
        {
            KassaOperatorName = kassaOperatorName;
        }

        public String getLocation()
        {
            return Location;
        }

        public void setLocation(String location)
        {
            Location = location;
        }

        public double getTotalAmount()
        {
            return TotalAmount;
        }

        public void setTotalAmount(double totalAmount)
        {
            TotalAmount = totalAmount;
        }

        public String getShopName()
        {
            return ShopName;
        }

        public void setShopName(String shopName)
        {
            ShopName = shopName;
        }

        public String getDate()
        {
            return Date;
        }

        public void setDate(String date)
        {
            Date = date;
        }

        public String getTime()
        {
            return Time;
        }

        public void setTime(String time)
        {
            Time = time;
        }

        public String getStatus()
        {
            return Status;
        }

        public void setStatus(String status)
        {
            Status = status;
        }

        public String getKassaId()
        {
            return KassaId;
        }

        public void setKassaId(String kassaId)
        {
            KassaId = kassaId;
        }

        public String getProgressed()
        {
            return Progressed;
        }

        public void setProgressed(String progressed)
        {
            Progressed = progressed;
        }

        public int getAvailableUsers()
        {
            return AvailableUsers;
        }

        public void setAvailableUsers(int availableUsers)
        {
            AvailableUsers = availableUsers;
        }
        #endregion

        #region Methods
        public void Allow()
        {
            this.Status = "allow";
        }

        public void Deny()
        {
            this.Status = "deny";
        }

        public void Watch()
        {
            this.Status = "Watch";
        }

        public void Skip()
        {
            this.AvailableUsers = AvailableUsers - 1;
        }

        public string toString()
        {
            return "Kassa: " + KassaId + "\n Kassa van: "+KassaOperatorName+"\n Beschrijving: "+Description+ "\n Locatie: " +Location+"\n Huidig Bedrag: " +TotalAmount + "\n Winkel: "+ ShopName + "\n Datum: " + Date + "\n Tijd: " + Time;
        }
        #endregion

    }
}
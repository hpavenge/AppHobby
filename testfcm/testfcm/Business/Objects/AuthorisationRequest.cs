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

namespace testfcm.Business.Objects
{
    public class AuthorisationRequest
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
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public String GetDescription()
        {
            return Description;
        }

        public void SetDescription(String description)
        {
            Description = description;
        }

        public String GetKassaOperatorName()
        {
            return KassaOperatorName;
        }

        public void SetKassaOperatorName(String kassaOperatorName)
        {
            KassaOperatorName = kassaOperatorName;
        }

        public String GetLocation()
        {
            return Location;
        }

        public void SetLocation(String location)
        {
            Location = location;
        }

        public double GetTotalAmount()
        {
            return TotalAmount;
        }

        public void SetTotalAmount(double totalAmount)
        {
            TotalAmount = totalAmount;
        }

        public String GetShopName()
        {
            return ShopName;
        }

        public void SetShopName(String shopName)
        {
            ShopName = shopName;
        }

        public String GetDate()
        {
            return Date;
        }

        public void SetDate(String date)
        {
            Date = date;
        }

        public String GetTime()
        {
            return Time;
        }

        public void SetTime(String time)
        {
            Time = time;
        }

        public String GetStatus()
        {
            return Status;
        }

        public void SetStatus(String status)
        {
            Status = status;
        }

        public String GetKassaId()
        {
            return KassaId;
        }

        public void SetKassaId(String kassaId)
        {
            KassaId = kassaId;
        }

        public String GetProgressed()
        {
            return Progressed;
        }

        public void SetProgressed(String progressed)
        {
            Progressed = progressed;
        }

        public int GetAvailableUsers()
        {
            return AvailableUsers;
        }

        public void SetAvailableUsers(int availableUsers)
        {
            AvailableUsers = availableUsers;
        }
        #endregion

        #region Methods

        public void Authorize(String status, String progressed)
        {
            this.Status = status;
            this.Progressed = progressed;
        }

        public void Skip()
        {
            this.AvailableUsers = AvailableUsers - 1;
        }

        public string toString()
        {
            return "Kassa: " + KassaId + "\n Kassa van: " + KassaOperatorName + "\n Beschrijving: " + Description + "\n Locatie: " + Location + "\n Huidig Bedrag: " + TotalAmount + "\n Winkel: " + ShopName + "\n Datum: " + Date + "\n Tijd: " + Time;
        }
        #endregion

    }
}
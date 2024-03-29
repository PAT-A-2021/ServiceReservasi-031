﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string pemesanan(string IDReservasi, string NamaCustomer, string NoTelepon, int JumlahPemesanan, string IDLokasi); // Method proses input data
        [OperationContract]
        string editPemesanan(string IDReservasi, string NamaCustomer, string No_telepon);
        [OperationContract]
        string deletePemesanan(string IDReservasi);
        [OperationContract]
        List<CekLokasi> ReviewLokasi();// Menampilkan data yang ada di database (select all) dengan menampilkan isi dari yang ada contract
        [OperationContract]
        List<DetailLokasi> DetailLokasi();// Menampilkan detail lokasi
        [OperationContract]
        List<Pemesanan> Pemesanan();

        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();
    }

    [DataContract]
    public class CekLokasi // Daftar lokasi
    {
        [DataMember]
        public string IDLokasi { get; set; }// Variabel dari public class
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string DeskripsiSingkat { get; set; }
    }

    [DataContract]
    public class DetailLokasi // Menampilkan detail lokasi
    {
        [DataMember]
        public string IDLokasi { get; set; } // Variabel dari public class
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string DeskripsiFull { get; set; }
        [DataMember]
        public int Kuota { get; set; }
    }

    [DataContract]
    public class Pemesanan // Create
    {
        [DataMember]
        public string IDReservasi { get; set; }
        [DataMember]
        public string NamaCustomer { get; set; } // Method
        [DataMember]
        public string NoTelepon { get; set; }
        [DataMember]
        public int JumlahPemesanan { get; set; }
        [DataMember]
        public string Lokasi { get; set; }
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }
}

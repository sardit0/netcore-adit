# Deskripsi :
Inventaris Barang (Inventory) dengan menggunakan bahasa pemograman yaitu C# (.NetCore) dan untuk Database nya menggunakan DBeaver, jadi untuk website Inventaris Barang itu adalah sebuah platform berbasis web yang digunakan untuk mengelola data barang dalam suatu sekolah atau perusahaan. Website ini biasanya berfungsi untuk mencatat, dan melacak status barang-barang seperti stok, barang masuk, barang keluar, barang pinjaman, dan barang yang dikembalikan. Dan untuk Role nya hanya memiliki 1 yaitu Admin saja, untuk Tabel nya ada 5 yaitu diantaranya ada Data Pusat, Barang Masuk, Barang Keluar, Peminjaman, dan Pengembalian.

# Database :
1. Data Pusat adalah pusat data dari semua barang dan memiliki hubungan one-to-many dengan tabel Barang Masuk, Barang Keluar, dan Peminjaman.
2. Peminjaman memiliki hubungan one-to-many dengan Pengembalian karena satu peminjaman bisa memiliki beberapa pengembalian.


# ERD Sistem Informasi Inventaris Barang : 
![dbdiagram](https://github.com/user-attachments/assets/531e6705-33c0-44ed-86ac-20c738a6a6ff)

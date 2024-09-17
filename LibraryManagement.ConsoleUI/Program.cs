﻿//(Record) Book --> Id, Title, Description, PageSize, PublishDate, ISB code, stok
//(record) Author --> Id, Name, Surname
//(Class) Category --> Id, Name bu alanlar benzersiz olmalı


//categoty eklerdeken id veya name alanları 
//author eklerken ID (name surname)

// kitaplar lisetesi oluşturunuz
//yazarlar  "               "
//kategroiler  """  "   "   

//YAZARLARI EKRANA BASTIRAN KODU YAZINIZ
//KİTAPLARI EKRANA BASTIRAN KODU YAZINIZ
//KATEGORİLERİ EKRANA BASTIRAN KODU YAZINIZ

//KİTAPLARI SAYFA SAYISINA GÖRE FİLTRELEYEN KODU YAZINIZ
//KÜÜTPHANEDEKİ TÜM KİTAPLARI SAYDA SAYISI TOPLAMINI HESAPLAYAN KODU YAZINIZ
// KİTAP BAŞLIĞINA GÖRE FİLTRELEME İŞLEMİ YAPINIZ
// KİTAP ISBN NUMARASINA GÖRE İLGİLİ KİTABI GETİRİNİZ.

// KİTAPLARI LİSTESİNE YENİ BİR KİTAP EKLEYİP, EKLENDİKTE SONRA LİSTEYİ EKRAN ÇIKTISI OLARAK VERİNİZ.(VERİLERİ KULLANICIDAN ALINIZ)

//**** KİTAP EKLERKEN ID Sİ VEYA ISBN NUMARASI DAHA ÖNCEKİ EKLENEN KİTAPLARDA İSE
//BENZERSİZ BİR KİTAP GİRMENİZ GEREKMETEDİR YAZISI ÇIKSIN

// KULLANICI BİR ID GİRDİĞİ ZAMANO İD YE GÖRE KİTABI SİLEN VE YENİ LİSTEYİ EKRANA BASTIRAN KODU YAZINIZ.

//KULLANICIDAN İLK BAŞTA ID DEĞERİ ALDIKTAN SONR EĞER O ID AİT BİR KİTAP YOKSA "İLGİLİ ID AİT BİR KİTAP BULUNAMADI"
// + GÜNCELLENECEK OLAN DEĞERLER KULLANICIDAN ALINACAKTIR

//kullanıcıdan bir kitap almasını isteyen kodu yazınız
//eğer o kitap stokta varsın kitap alındı yazısı çıksın
// 1 tane varsa o kitap alınsın ve listeden silinsin (hoca gerçekten silinsn istiyor)

//   PRİME ÖRNEKLER
// BookDetail adında bir record oluşturup şu değerler listenecek
// Kitap Id, Kitap başlığı, kitap Açıklaması, Kitap Sayfa Sayısı, ISBN, Yazar Adı, Kategori Adı
// kullanıcıdan PageIndex ve PageSize değerlerini alarak sayfalama desteği getiriniz.


using LibraryManagement.ConsoleUI;
using System.Threading.Channels;



List<Book> books = new List<Book>()
{
    new Book(1,"Germinal","Kömür Madeni",341,"2012 Mayıs","9781234567897"),
    new Book(2,"Suç ve Ceza","Raskolnikov un hayatı",315,"2010 Haziran","9781234567891"),
    new Book(3,"Kumarbaz","Bir Öğretmenin hayatı",210,"2009 Ocak","9781234567892"),
    new Book(4, "Araba Sevdası","Arabayla alakası olmayan Kitap",180,"1999 Ocak","9781234567838"),
    new Book(5,"Ateşten Gömlek","Kurtulu savaşını anlatan kitap",120,"2001 Eylül","9781234567834"),
    new Book(6,"Kaşağı","Okunmaması gereken bir kitap",95,"1993 Ocak","9781234567845"),
    new Book(7,"28 Şampiyonluk","Hayal ürünüdür",350,"1907 Ocak ","9781234567807"),
    new Book(8,"16 Yıl Şampiyonluk","Hayal ürünüdür.",255,"10 Eylül","9781234567800"),
    new Book(9,"Ali Arı","Uyanık Ceo nun hikayesi",551,"20 Haziran","9781234567800")
};


List<Author> authors = new List<Author>()
{
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4, "Halide Edib","Adıvar"),
    new Author(5,"Ömer","Seyfettin"),
    new Author(6,"Ali","Koç"),
    new Author(7,"Vız vız","Ali")
};


List<Category> categories = new List<Category>()
{
    new Category(1,"Dünya Klasikleri"),
    new Category(2,"Türk Klasikleri"),
    new Category(3,"Bilim Kurgu")
};

//GetAllBooksByPageSizeFilter();

//GetAllBooks();
//GetAllAuthors();
//GetAllCategories();
//PageSizeTotalCalculator();

//GetAllBooksByTitleContains();

//GetBookByISBN();

//AddBook();

//AddCategory();
AddAuthor();

Author GetAuthorInputs()
{
    Console.WriteLine("Lütfen yazar ismi giriniz:");
    string name = Console.ReadLine();

    Console.WriteLine("lütfen yazarın soy ismini giriniz:");
    string surname = Console.ReadLine();

    Console.WriteLine("Lütfen yazarın Id sini giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Author author = new Author(id, name, surname);
    return author;
}
bool AddAuthorValidator (Author author)
{
    bool isUnique = true;

    foreach (Author item in authors)
    {
        if(item.Name == author.Name && item.Surname == author.Surname)
        {
            isUnique = false;
            break;
        }
    }
    return isUnique;
}
Category GetCategoryInputs()
{
    Console.WriteLine("Lütfen kategori başlığı giriniz: ");
    string name = Console.ReadLine();

    Console.WriteLine("Lütfen kategori id sini giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Category category = new Category(id, name);
    return category;
}

bool AddCategoryValidator (Category category)
{
    bool isUnique = true;

    foreach (Category item in categories)
    {
        if (item.Id == category.Id || item.Name == category.Name)
        {
            isUnique = false;
            break;
        }
    }

    return isUnique;
}


Book GetBookInputs2()
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    string description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    int pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    string publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    string isbn = Console.ReadLine();

    Book book = new Book(id, title, description, pageSize, publishDate, isbn);
    return book;
}

bool AddBookValidator(Book book)
{
    bool isUnique = true;

    foreach (Book item in books)
    {
        if (item.Id == book.Id || item.ISBN == book.ISBN)
        {
            isUnique = false;
            break;
        }
    }

    return isUnique;
}

void GetBookInputs(out int id,
     out string title,
     out string description,
     out int pageSize,
     out string publishDate,
     out string isbn)
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    isbn = Console.ReadLine();
}

void AddAuthor()
{
    Author author = GetAuthorInputs();
    bool isUnique = AddAuthorValidator(author);

    if (!isUnique)
    {
        Console.WriteLine("Girmiş olduğunuz kategori benzersiz değil.");
        return;
    }
    authors.Add(author);
    GetAllAuthors();
}
void AddCategory()
{
    Category category = GetCategoryInputs();

    bool isUnique = AddCategoryValidator(category);

    if (!isUnique)
    {
        Console.WriteLine("Girmiş olduğunuz kategori benzersiz değil.");
        return;
    }
    categories.Add(category);
    GetAllCategories();
}
void AddBook()
{
    Book book = GetBookInputs2();

    bool isUnique = AddBookValidator(book);

    if (!isUnique)
    {
        Console.WriteLine("Girmiş olduğunuz kitap Benzersiz değil.");
        return;
    }
    books.Add(book);
    GetAllBooks();
}

void GetBookByISBN()
{
    Console.WriteLine("Lütfen ISBN numarasını giriniz: ");
    string isbn = Console.ReadLine();

    foreach (Book book in books)
    {
        if (book.ISBN == isbn)
        {
            Console.WriteLine(book);
        }
    }
}
void GetAllBooksByTitleContains()
{
    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string text = Console.ReadLine();

    foreach (Book book in books)
    {
        if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine(book);
        }
    }
}

void PageSizeTotalCalculator()
{
    int total = 0;
    //for (int i =0;i<books.Count;i++)
    //{
    //    total = books[i].PageSize + total;
    //}

    foreach (var item in books)
    {
        total = total + item.PageSize;
    }


    Console.WriteLine(total);
}

void GetAllBooks()
{
    PrintAyirac("Kitapları Listele:");

    foreach (Book book in books)
    {
        Console.WriteLine(book);
    }
}

void GetAllCategories()
{
    PrintAyirac("Kategorileri Listele");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }
}

void GetAllAuthors()
{
    PrintAyirac("Yazarları Listele: ");

    foreach (Author author in authors)
    {
        Console.WriteLine(author);
    }
}

void PrintAyirac(string metin)
{
    Console.WriteLine(metin);
    Console.WriteLine("----------------------------------------");
}


void GetAllBooksByPageSizeFilter()
{
    PrintAyirac("Sayfa Sayısına göre filtreleme");

    Console.WriteLine("Lütfen minimum değeri giriniz: ");
    int min = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen maximum değeri giriniz: ");
    int max = Convert.ToInt32(Console.ReadLine());

    foreach (Book book in books)
    {
        if (book.PageSize <= max && book.PageSize >= min)
        {
            Console.WriteLine(book);
        }
    }

}
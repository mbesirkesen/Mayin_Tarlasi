# Mayın Tarlası Oyunu

C# Windows Forms ile geliştirilmiş klasik mayın tarlası oyunu.

## Özellikler

- 20x20 grid tabanlı oyun alanı
- 60 mayın içeren zorlu oyun deneyimi
- Sol tıklama ile kare açma
- Sağ tıklama ile mayın işaretleme
- Etrafındaki mayın sayısını gösteren sayılar
- Otomatik boş alan açma özelliği
- Oyun baştan başlatma özelliği

## Oyun Kuralları

1. Sol tıklama ile bir kareyi açın
2. Eğer mayına basarsanız oyun biter
3. Etrafındaki mayın sayısı kare içinde gösterilir
4. Sağ tıklama ile mayın işaretleyebilirsiniz (! işareti)
5. Tüm mayınsız kareleri açtığınızda oyunu kazanırsınız

## Gereksinimler

- .NET Framework 4.6.1 veya üzeri
- Visual Studio 2017 veya üzeri (geliştirme için)

## Kurulum

1. Projeyi klonlayın:
```bash
git clone https://github.com/kullaniciadi/Mayin_Tarlasi.git
```

2. Visual Studio'da `Mayin_Tarlasi.sln` dosyasını açın

3. Projeyi derleyin ve çalıştırın

## Kullanım

- Oyunu başlatmak için projeyi çalıştırın
- "restart" butonuna tıklayarak oyunu yeniden başlatabilirsiniz
- Sol tıklama ile kareleri açın
- Sağ tıklama ile mayınları işaretleyin

## Proje Yapısı

```
Mayin_Tarlasi/
├── Mayin_Tarlasi/
│   ├── Form1.cs              # Ana form ve oyun mantığı
│   ├── Form1.Designer.cs     # Form tasarımı
│   ├── Program.cs            # Program giriş noktası
│   ├── Mayin_Tarlasi.csproj  # Proje dosyası
│   └── Properties/           # Proje özellikleri
└── Mayin_Tarlasi.sln        # Solution dosyası
```

## Sınıflar

- **Form1**: Ana form ve oyun arayüzü
- **Mayin**: Mayın nesnesi ve konum bilgisi
- **MayinTarlasi**: Oyun alanı ve mayın yönetimi

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## Geliştirici

Proje C# Windows Forms kullanılarak geliştirilmiştir.


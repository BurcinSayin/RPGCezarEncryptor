using System;
using CezarLib;
using NUnit.Framework;

namespace CezarLibTests
{
    [TestFixture]
    public class CezarEncryptorTests
    {

        [Test]
        public void EncryptLine_Predifined_ReturnPredefined()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("1");

            var res = toTest.EncryptLine("ABCDZ");
            
            Assert.AreEqual("BCÇEA",res);
        }
        
        [Test]
        public void EncryptLine_EmptyText_ReturnNotEnrypted()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("1");

            var res = toTest.EncryptLine("     ");
            
            Assert.AreEqual("     ",res);
        }
        
        
        [Test]
        public void EncryptLineTest_UpperLowerText_EncryptionShouldMatch()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resUpper = toTest.EncryptLine("SELAM DURDU KİMİ ZAMAN YILDIZLARA");
            
            var resLower = toTest.EncryptLine("selam durdu kimi zaman yıldızlara");
            
            Console.WriteLine(resUpper);
            
            Console.WriteLine(resLower);
            
            Assert.AreEqual(resLower,resUpper);
        }
        
        
        [Test]
        public void EncryptLineTest_Embed1()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("SELAM DURDU KIMI ZAMAN YILDIZLARA");
            
            var resEmb = toTest.EmbedText(resEnc,"Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
        
        [Test]
        public void EncryptLineTest_Embed2()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("Şarkılar söyledi bazen bulutlarla");
            
            var resEmb = toTest.EmbedText(resEnc,"Ben daha küçük ama vasıflı bir çocukken 1382 senesinde  Moğol Yuan Hanedanlığı egemenliğindeki Yunnan, Ming Hanedanlığı tarafından işgal edildi. Tutsak alınıp, o dönemdeki diğer şaşkın çocuk tutsaklara yapıldığı gibi, özel bir işlemden geçerek hadım edildim ve İmparatorluğun hizmetindekilerden birisi oldum. Nanjing Taiçue'de (Merkezi İmparatorluk Koleji) bakıldım ve eğitim gördüm ve prens Zhu Di'nin hizmetinde görevlendirildim. Zhu Di'nin 1402 senesinde Yonglo İmparatoru olmasıyla sonuçlanan zalim İmparator Jianwen'e karşı yapılan ağır zaiyatlar verdiğimiz ünlü Yonglo ayaklanmasında önemli bir başarılar elde ettim. Bu dönemdeki askeri başarılarımdan ötürü Zhu Di tarafından Zheng He ismini aldım. Başarılarım ve cesaretim uzun zaman içerisinde olsa da beni amiralliğe kadar yükseltti.");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
        
        [Test]
        public void EncryptLineTest_Embed3()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");
            
            var resEmb = toTest.EmbedText(resEnc,"Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
        
        [Test]
        public void EncryptLineTest_Embed4()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");
            
            var resEmb = toTest.EmbedText(resEnc,"Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
        
        [Test]
        public void EncryptLineTest_Embed5()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");
            
            var resEmb = toTest.EmbedText(resEnc,"Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
        
        [Test]
        public void EncryptLineTest_Embed6()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor("42");

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");
            
            var resEmb = toTest.EmbedText(resEnc,"Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");
            
            Console.WriteLine(resEnc);
            
            Console.WriteLine(resEmb);
            
            Assert.Fail();
        }
    }
}
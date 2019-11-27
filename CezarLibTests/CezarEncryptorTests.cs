using System;
using System.Globalization;
using CezarLib;
using NUnit.Framework;

namespace CezarLibTests
{
    [TestFixture]
    public class CezarEncryptorTests
    {
        private string alphabet = "A,B,C,Ç,D,E,F,G,Ğ,H,I,İ,J,K,L,M,N,O,Ö,P,R,S,Ş,T,U,Ü,V,Y,Z";

        [Test]
        public void EncryptLine_NumberKey_ReturnPredefined()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("1",KeywordType.Number);

            var res = toTest.EncryptLine("ABCDZ");

            Assert.AreEqual("BCÇEA", res);
        }
        
        [Test]
        public void EncryptLine_WordKey_ReturnPredefined()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("A",KeywordType.Word);

            var res = toTest.EncryptLine("ABCDZ");

            Assert.AreEqual("BCÇEA", res);
        }

        [Test]
        public void EncryptLine_EmptyText_ReturnNotEnrypted()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("1",KeywordType.Number);

            var res = toTest.EncryptLine("!     ");

            Assert.AreEqual("!     ", res);
        }


        [Test]
        public void DecryptLine_NumberKey_ReturnPredefined()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("1",KeywordType.Number);

            var res = toTest.DecryptLine("BCÇEA");

            Assert.AreEqual("ABCDZ", res);
        }
        
        [Test]
        public void DecryptLine_WordKey_ReturnPredefined()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("A",KeywordType.Word);

            var res = toTest.DecryptLine("BCÇEA");

            Assert.AreEqual("ABCDZ", res);
        }

        [Test]
        public void DecryptLine_EmptyText_ReturnNotEnrypted()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("1",KeywordType.Number);

            var res = toTest.DecryptLine("!     ");

            Assert.AreEqual("!     ", res);
        }

        
        [Test]
        public void EncryptLineTest_UpperLowerText_EncryptionShouldMatch()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetKeyWord("1",KeywordType.Number);

            var resUpper = toTest.EncryptLine("SELAM DURDU KİMİ ZAMAN YILDIZLARA");

            var resLower = toTest.EncryptLine("selam durdu kimi zaman yıldızlara");

            Console.WriteLine(resUpper);

            Console.WriteLine(resLower);

            Assert.AreEqual(resLower, resUpper);
        }

        [Test]
        public void GetAlphabetTest_Default_ShouldBeTurkish()
        {
            CezarEncryptor toTest = new CezarEncryptor();
            var res = toTest.GetAlphabet();

            Assert.AreEqual(alphabet, res);
        }

        [Test]
        public void SetAlphabet_EmptyList_ShouldDoNothing()
        {
            CezarEncryptor toTest = new CezarEncryptor();
            string prevAlphabet = toTest.GetAlphabet();

            toTest.SetAlphabet("", new CultureInfo("tr-TR", false));
            string postAlphabet = toTest.GetAlphabet();
            
            Assert.AreEqual(prevAlphabet,postAlphabet);
        }
        
        [Test]
        public void SetAlphabet_SmallList_CountShouldMatch()
        {
            CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetAlphabet("A,B,C",new CultureInfo("tr-tr",false));
            
            Assert.AreEqual(3,toTest.charMapList.Count);
        }
        
        [Test]
        public void SetAlphabet_ListWithDuplicates_ShouldIgnoreDuplicates()
        {
            CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetAlphabet("A,B,C,A,D",new CultureInfo("tr-tr",false));
            
            Assert.AreEqual(4,toTest.charMapList.Count);
        }
        
        [Test]
        public void SetAlphabet_ListWithWords_ShouldIgnoreWords()
        {
            CezarEncryptor toTest = new CezarEncryptor();
            toTest.SetAlphabet("A,B,C,Ali,D",new CultureInfo("tr-tr",false));
            
            Assert.AreEqual(4,toTest.charMapList.Count);
        }
        
        

        #region Integration Tests

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed1()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();
            

            var resEnc = toTest.EncryptLine("SELAM DURDU KIMI ZAMAN YILDIZLARA");

            var resEmb = toTest.EmbedText(resEnc,
                "Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed2()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();

            var resEnc = toTest.EncryptLine("Şarkılar söyledi bazen bulutlarla");

            var resEmb = toTest.EmbedText(resEnc,
                "Ben daha küçük ama vasıflı bir çocukken 1382 senesinde  Moğol Yuan Hanedanlığı egemenliğindeki Yunnan, Ming Hanedanlığı tarafından işgal edildi. Tutsak alınıp, o dönemdeki diğer şaşkın çocuk tutsaklara yapıldığı gibi, özel bir işlemden geçerek hadım edildim ve İmparatorluğun hizmetindekilerden birisi oldum. Nanjing Taiçue'de (Merkezi İmparatorluk Koleji) bakıldım ve eğitim gördüm ve prens Zhu Di'nin hizmetinde görevlendirildim. Zhu Di'nin 1402 senesinde Yonglo İmparatoru olmasıyla sonuçlanan zalim İmparator Jianwen'e karşı yapılan ağır zaiyatlar verdiğimiz ünlü Yonglo ayaklanmasında önemli bir başarılar elde ettim. Bu dönemdeki askeri başarılarımdan ötürü Zhu Di tarafından Zheng He ismini aldım. Başarılarım ve cesaretim uzun zaman içerisinde olsa da beni amiralliğe kadar yükseltti.");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed3()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");

            var resEmb = toTest.EmbedText(resEnc,
                "Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed4()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");

            var resEmb = toTest.EmbedText(resEnc,
                "Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed5()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");

            var resEmb = toTest.EmbedText(resEnc,
                "Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        [Test]
        [Ignore("Integration")]
        public void EncryptLineTest_Embed6()
        {
            CezarLib.CezarEncryptor toTest = new CezarEncryptor();

            var resEnc = toTest.EncryptLine("Selam durdu kimi zaman yıldızlara");

            var resEmb = toTest.EmbedText(resEnc,
                "Modern Yunnan Eyaletinde 1371'de sıcak bir günde doğdum. Doğduğum gün verilen ismim Ma Sanbao (馬 三保) idi. Ailem İslamı özden benimsemiş cümle alemin saydığı Semur sınıfındandı. Yunnan'ın pek sevilen sağlığı ile ünlü valisi, bu günlerde adından fazlaca bahsedilen Özbekistan sınırları içinde olan Buhara'dan kadim bilge Seyyid Eclel Şems el-Din Ömer'in altıncı kuşaktan pek sevdiği torunuyum.Soyismim olan \"Ma\" Şems el-Din'in beşinci oğlu Masuh'dan gelmekte olduğu söylenir. Babam Mir Tekin özellikle de dedem Keramettin Mekke'ye hac yapmaya gitmişti; onların bu uzak yerlere yaptığı seyahatlerine dair anlatım ve jestleri beni oldukça etkilemiştir. Belkide bu sebepten dolayı denizleri dolaşan bir donanma amirali olmuşumdur");

            Console.WriteLine(resEnc);

            Console.WriteLine(resEmb);

            Assert.Fail();
        }

        #endregion
    }
}
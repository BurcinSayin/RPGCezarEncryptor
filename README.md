Hazine avları için geçmiş bir tarihde yazmış olduğum şifreleme programı.  Öğrenme amaçlı .Net Core ile yazdığım için dosya boyutu oldukça büyük oldu.
Şu anda sürü ile eksigi var ve sadece türkçe karakter desteği var. İşe Cezar sifresi yapacam diye başlamış olmama rağmen şu anda daha çok Vigenère Şifresi gibi çalışıyor. En son halini burdan indirebilirsiniz.

Kullanımı:

Encrypt Sekmesi:  
Keyword: Kelime veya rakam olarak şifrede öteleme miktarını belirleren anahtar kelime. Numerik ise sayısal olarak oteleme miktarı. Kelime ise harfinin değeri kaar öteleme uygular.

Decrypt Sekmesi:  
Encryptin tam tersi :)

Character Mappings:  
Kullanmak istediğiniz alfabe çeşidini buraya büyük harf olarak virgül ile ayırarak giriyorsunuz. Şu anda Türkçe alfabe mevcut

Nasıl Çalısıyor? :  
hedef Yazı : Kule Sakinleri  
anahtar(numeric) : 42  
Alfabe eşlemesi : A= 1, B= 2, C= 3, Ç= 4, D= 5, E= 6, F= 7, G= 8, Ğ= 9, H= 10, I= 11, İ= 12, J= 13, K= 14, L= 15, M= 16, N= 17, O= 18, Ö= 19, P= 20, R= 21, S= 22, Ş= 23, T= 24, U= 25, Ü= 26, V= 27, Y= 28, Z= 29

Şifrelerken  
Kule Sakinleri  
4242 424242424

K + 4 = 18 = O  
U + 2 = 27 = V  
L + 4 = 19 = Ö  
E + 2 = 8 = G  
S + 4 = 26 = Ü  
A + 2 = 3 = C  
K + 4 = 18 = O  
İ + 2 = 14 = K  
N + 4 = 21 = R  
L + 2 = 17 = N  
E + 4 = 10 = H  
R + 2 = 23 = Ş  
İ + 4 = 16 = M  

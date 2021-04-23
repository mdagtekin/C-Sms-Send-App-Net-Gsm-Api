# NetGsmSmsApi
 Netgsm Üzerinden Sms Gönderme İşlemini Kolayca Yapabilen ve 1:n , n:n Gönderimlerinizi Yapabileceğiniz C# Kütüphanesi Umarım İşinize Yarayabilir Kullanımı Çok Kolay Bir Şekilde gerçekleştirebilirsiniz.
## Instructions for Use 
	1-NetGsmUserName -> Net Gsm Login Username Default Phone Number e.g:8500000000 or 2120000000
	2-Pasword -> Net Gsm Api User Register and Pasword (Not Account Password) Api Password Only
	3-Messages `SentMe.Messages` New Class and Enter Message and Phone Number and `List<SentMe.Messages> messages = new List<SentMe.Messages>();` Add.
	4-`netGsm.MessageSetting("NetGsmUserName", "NetGsmApiUserPassword",messages,"Sms Header Text");` Send Me Messages Return String.

### Example
```C#

SentMe netGsm = new SentMe();
List<SentMe.Messages> messages = new List<SentMe.Messages>();
messages.Add(new SentMe.Messages { Message = MessageText, PhoneNumber = SentNumber });
string res =  netGsm.MessageSetting("NetGsmUserName", "NetGsmApiUserPassword",messages,"Sms Header Text");

``` 

[Return Success Code List Details](https://github.com/mehmetdagtekin/NetGsmSmsApi#return-success-code-list).


[Return Error Code List Details](https://github.com/mehmetdagtekin/NetGsmSmsApi#return-error-code-list).

	

### Thanks You Friend
I really want to thank you for your help [@mnurcakiroglu]( https://github.com/mnurcakiroglu) :heart:

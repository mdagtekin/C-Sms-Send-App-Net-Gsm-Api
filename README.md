# C# Sms Send App - Net Gsm Api
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
##### Return Success Code List
Code | Meaning
:------------: | :-------------:
`00 347022009`|It indicates that your SMS has been sent to our system successfully. 00: It means that there is no error regarding the date format of your message. 123xxxxxx: ID information of the sent SMS, You can query the transmission report of your message with your bulkid.
`01 347022009`|It indicates that your SMS sent has been successfully delivered to our system. 01: Indicates that there is an error regarding the starting date of your message, it has been changed and processed with the system date. 123xxxxxx: ID information of the sent SMS, You can query the transmission report of your message with your bulkid.
`02 347022009`|It indicates that your SMS sent has been successfully delivered to our system. 02: Indicates that there is an error regarding the expiration date of your message, it has been changed and processed with the system date. 123xxxxxx: ID information of the sent SMS, You can query the transmission report of your message with your bulkid.
`00 5Fxxxxxx-2xxx-4xxE-8xxx-8A5xxxxxxxxxxxx`|It indicates that your SMS has been sent to our system successfully. This task (bulkid) can be queried, 5Fxxxxxx-2xxx-4xxE-8xxx-8A5xxxxxxxxxxxx can be given as bulkID information in the reporting service. The reason you get this output means that the SMS you send consecutively for 5 minutes will be multiplexed by our system and sent within 1 minute.

##### Return Error Code List
Error code | Meaning
:------------: | :-------------:
`20`|It indicates that it could not be sent due to the problem in the text of the message or it exceeded the standard maximum message character number.
`30`|Indicates an invalid username, password or your user does not have API access permission. Also, if you have IP restricted on your API access and are sending other than the IP restricted, you will get an error code of 30. Your API access permission or IP limitation from the web interface; You can check it from the settings> API operations menu in the upper right corner.
`40`|It means that your message header (sender name) is not defined in the system. You can check your sender names by querying them with the API.
`50`|IYS controlled submissions cannot be made with your subscriber account.
`51`|It indicates that there is no IMS Brand information defined for your subscription.
`70`|Incorrect inquiry. One of the parameters you send indicates that it is incorrect or one of the required fields is missing.
`80`|limit overrun.
`85`|Duplicate Transmission limit overrun. More than 20 tasks cannot be created in 1 minute on the same number.

I really want to thank you for your help [@mnurcakiroglu]( https://github.com/mnurcakiroglu) :heart:

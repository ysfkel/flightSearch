define([], function () {

    function Conversation(service) {
        this.data = {};
        this.service = service;
        this.data.type = 'Message';

        this.data.language = 'en-US';
        this.data.text;
        this.data.conversationId = '8a684db8';
        this.data.id = 'e8dc794dd5d848fb945c0edf10016413';
        this.data.From = {
            "name": "YourAppId",
            "channelId": "emulator",
            "address": "YourAppId",
            "Id": "2c1c7fa3",
            "isBot": true
        };
        this.data.To = {
            "name": "User1",
            "channelId": "yusufkel",
            "address": "User1",
            "isBot": false,
            "Id": "YourAppId"
        }
        this.data.participants = [
          {
              "name": "User1",
              "channelId": "yusufkel",
              "address": "User1",
              "Id": "2c1c7fa3",
              "isBot": false
          },
            {
                "name": "YourAppId",
                "channelId": "emulator",
                "address": "YourAppId",
                "Id": "YourAppId",
                "isBot": true
            }
        ];
        this.data.totalParticipants = 2;
        this.data.mentions = [];
        this.data.channelMessageId = '50523bd4402f41f9b34c33bfc66f5e94';//generateId();
        this.data.channelConversationId = 'Conv1';
        this.data.hashtags = []
        this.data.botPerUserInConversationData = {};
    }


    Conversation.prototype.send = function () {
   
        var uri = 'http://dubaiflights.azurewebsites.net/api/messages';//http://localhost:3978/api/messages';
        return this.service({
            url: uri,
            method: 'POST',
            data: this.data
        }).then((res) => {
            this.data.botPerUserInConversationData = res.data.botPerUserInConversationData;
            return res;
        })



    }

    return Conversation;


})


function generateId() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
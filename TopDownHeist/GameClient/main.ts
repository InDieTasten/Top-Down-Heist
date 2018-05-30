import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";

(function () {

    const connection = new HubConnectionBuilder()
        .withUrl("/chatHub")
        .configureLogging(LogLevel.Debug)
        .build();

    connection.start().catch(err => console.error(err.ToString()));

    connection.on("ReceiveMessage", (user, message : string) => {
        const encodedMsg = user + " says " + message;
        const li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    });

    document.getElementById("sendButton").addEventListener("click", event => {
        const user = (<HTMLInputElement>document.getElementById("userInput")).value;
        const message = (<HTMLInputElement>document.getElementById("messageInput")).value;
        connection.invoke("SendMessage", user, message).catch(err => console.error(err.ToString()));
        event.preventDefault();
    });
})();

import { HubConnectionBuilder, LogLevel, HubConnection, JsonHubProtocol } from '@aspnet/signalr';

export class NetworkDispatcher {

    private connection: HubConnection;

    constructor() {
        this.connection = new HubConnectionBuilder()
            .withUrl("/heistHub")
            .configureLogging(LogLevel.Debug)
            .withHubProtocol(new JsonHubProtocol())
            .build();

        // register server-sent events
        this.connection.on("ping", this.onPing);
    }

    connect(): void {
        this.connection.start();
    }

    private onPing = (message: string): void => {
        this.connection.send("Pong", message);
    }

}

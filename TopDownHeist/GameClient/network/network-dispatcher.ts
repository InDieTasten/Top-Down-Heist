import { HubConnectionBuilder, LogLevel, HubConnection } from '@aspnet/signalr';

export class NetworkDispatcher {

    private connection: HubConnection;

    constructor() {
        this.connection = new HubConnectionBuilder()
            .withUrl("/heistHub")
            .configureLogging(LogLevel.Debug)
            .build();

        // register server-sent events
        this.connection.on("ping", this.onPing);
        this.connection.on("gameUpdate", this.onGameUpdate)
    }

    async connect(): Promise<void> {
        return await this.connection.start();
    }

    async disconnnect(): Promise<void> {
        var promise = await this.connection.stop();
        console.log("Disconnected from heistHub");

        return promise;
    }

    private onGameUpdate = (message: any): void => {
        console.log("Game Update received", message);
    }

    private onPing = (message: string): void => {
        this.connection.send("Pong", message);
    }

}

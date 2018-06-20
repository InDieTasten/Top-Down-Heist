import { IVectorInput } from "../abstraction/vector-input";
import { Vector2 } from "../../helpers/vector";

export class MouseMoveInput implements IVectorInput {

    private position: Vector2;

    constructor() {

        this.position = new Vector2(0, 0);

        window.document.addEventListener("mousemove", this.mouseMoveEventHandler, true);
    }

    private mouseMoveEventHandler = (event: MouseEvent): void => {

        const pageWidth = Math.max(
            document.documentElement["clientWidth"],
            document.body["scrollWidth"],
            document.documentElement["scrollWidth"],
            document.body["offsetWidth"],
            document.documentElement["offsetWidth"]
        );
        const pageHeight = Math.max(
            document.documentElement["clientHeight"],
            document.body["scrollHeight"],
            document.documentElement["scrollHeight"],
            document.body["offsetHeight"],
            document.documentElement["offsetHeight"]
        );

        this.position.x = 2 * event.pageX / pageWidth - 1;
        this.position.y = 2 * event.pageY / pageHeight - 1;
    }

    getVector(): Vector2 {
        return this.position;
    }
}

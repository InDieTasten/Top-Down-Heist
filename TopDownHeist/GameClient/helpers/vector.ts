
export class Vector2 {

    x: number;
    y: number;

    constructor(x: number, y: number) {
        this.x = x;
        this.y = y;
    }

    subtract(other: Vector2): Vector2 {
        return new Vector2(
            this.x - other.x,
            this.y - other.y
        );
    }

    add(other: Vector2): Vector2 {
        return new Vector2(
            this.x + other.x,
            this.y + other.y
        );
    }

    multiply(other: Vector2): Vector2 {
        return new Vector2(
            this.x * other.x,
            this.y * other.y
        );
    }
}

export class Vector3 {

    x: number;
    y: number;
    z: number;

}

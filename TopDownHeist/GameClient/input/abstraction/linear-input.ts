
export interface IAbsoluteLinearInput {
    /*
     * Returns the linear input in a range of 0 to 1
     */
    getValue(): number;
}

export interface ILinearInput {
    /*
     * Returns the linear input in a range of -1 to 1
     */
    getValue(): number;
}

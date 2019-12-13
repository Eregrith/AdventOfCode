interface IntcodeContext {
    instructionPointer: number;
    data: BigInteger[];
    inputQueue: BigInteger[];
    outputQueue: BigInteger[];
    mode: string;
    isFinished: boolean;
    relativeBase: BigInteger;
    isWaitingForInput: boolean;
}
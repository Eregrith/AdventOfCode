interface IntcodeContext {
    instructionPointer: BigInteger;
    data: BigInteger[];
    inputQueue: BigInteger[];
    outputQueue: BigInteger[];
    mode: string;
    isFinished: boolean;
    relativeBase: BigInteger
}
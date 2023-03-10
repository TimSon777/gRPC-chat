// @generated by protobuf-ts 2.8.2
// @generated from protobuf file "chat.proto" (package "proto", syntax proto3)
// tslint:disable
import { Empty } from "./google/protobuf/empty";
import { ServiceType } from "@protobuf-ts/runtime-rpc";
import type { BinaryWriteOptions } from "@protobuf-ts/runtime";
import type { IBinaryWriter } from "@protobuf-ts/runtime";
import { WireType } from "@protobuf-ts/runtime";
import type { BinaryReadOptions } from "@protobuf-ts/runtime";
import type { IBinaryReader } from "@protobuf-ts/runtime";
import { UnknownFieldHandler } from "@protobuf-ts/runtime";
import type { PartialMessage } from "@protobuf-ts/runtime";
import { reflectionMergePartial } from "@protobuf-ts/runtime";
import { MESSAGE_TYPE } from "@protobuf-ts/runtime";
import { MessageType } from "@protobuf-ts/runtime";
/**
 * @generated from protobuf message proto.ConnectResponse
 */
export interface ConnectResponse {
    /**
     * @generated from protobuf field: bool connected = 1;
     */
    connected: boolean;
}
/**
 * @generated from protobuf message proto.SendMessageRequest
 */
export interface SendMessageRequest {
    /**
     * @generated from protobuf field: string text = 1;
     */
    text: string;
}
/**
 * @generated from protobuf message proto.ReceiveMessageResponse
 */
export interface ReceiveMessageResponse {
    /**
     * @generated from protobuf field: string text = 1;
     */
    text: string;
    /**
     * @generated from protobuf field: string from = 2;
     */
    from: string;
}
// @generated message type with reflection information, may provide speed optimized methods
class ConnectResponse$Type extends MessageType<ConnectResponse> {
    constructor() {
        super("proto.ConnectResponse", [
            { no: 1, name: "connected", kind: "scalar", T: 8 /*ScalarType.BOOL*/ }
        ]);
    }
    create(value?: PartialMessage<ConnectResponse>): ConnectResponse {
        const message = { connected: false };
        globalThis.Object.defineProperty(message, MESSAGE_TYPE, { enumerable: false, value: this });
        if (value !== undefined)
            reflectionMergePartial<ConnectResponse>(this, message, value);
        return message;
    }
    internalBinaryRead(reader: IBinaryReader, length: number, options: BinaryReadOptions, target?: ConnectResponse): ConnectResponse {
        let message = target ?? this.create(), end = reader.pos + length;
        while (reader.pos < end) {
            let [fieldNo, wireType] = reader.tag();
            switch (fieldNo) {
                case /* bool connected */ 1:
                    message.connected = reader.bool();
                    break;
                default:
                    let u = options.readUnknownField;
                    if (u === "throw")
                        throw new globalThis.Error(`Unknown field ${fieldNo} (wire type ${wireType}) for ${this.typeName}`);
                    let d = reader.skip(wireType);
                    if (u !== false)
                        (u === true ? UnknownFieldHandler.onRead : u)(this.typeName, message, fieldNo, wireType, d);
            }
        }
        return message;
    }
    internalBinaryWrite(message: ConnectResponse, writer: IBinaryWriter, options: BinaryWriteOptions): IBinaryWriter {
        /* bool connected = 1; */
        if (message.connected !== false)
            writer.tag(1, WireType.Varint).bool(message.connected);
        let u = options.writeUnknownFields;
        if (u !== false)
            (u == true ? UnknownFieldHandler.onWrite : u)(this.typeName, message, writer);
        return writer;
    }
}
/**
 * @generated MessageType for protobuf message proto.ConnectResponse
 */
export const ConnectResponse = new ConnectResponse$Type();
// @generated message type with reflection information, may provide speed optimized methods
class SendMessageRequest$Type extends MessageType<SendMessageRequest> {
    constructor() {
        super("proto.SendMessageRequest", [
            { no: 1, name: "text", kind: "scalar", T: 9 /*ScalarType.STRING*/ }
        ]);
    }
    create(value?: PartialMessage<SendMessageRequest>): SendMessageRequest {
        const message = { text: "" };
        globalThis.Object.defineProperty(message, MESSAGE_TYPE, { enumerable: false, value: this });
        if (value !== undefined)
            reflectionMergePartial<SendMessageRequest>(this, message, value);
        return message;
    }
    internalBinaryRead(reader: IBinaryReader, length: number, options: BinaryReadOptions, target?: SendMessageRequest): SendMessageRequest {
        let message = target ?? this.create(), end = reader.pos + length;
        while (reader.pos < end) {
            let [fieldNo, wireType] = reader.tag();
            switch (fieldNo) {
                case /* string text */ 1:
                    message.text = reader.string();
                    break;
                default:
                    let u = options.readUnknownField;
                    if (u === "throw")
                        throw new globalThis.Error(`Unknown field ${fieldNo} (wire type ${wireType}) for ${this.typeName}`);
                    let d = reader.skip(wireType);
                    if (u !== false)
                        (u === true ? UnknownFieldHandler.onRead : u)(this.typeName, message, fieldNo, wireType, d);
            }
        }
        return message;
    }
    internalBinaryWrite(message: SendMessageRequest, writer: IBinaryWriter, options: BinaryWriteOptions): IBinaryWriter {
        /* string text = 1; */
        if (message.text !== "")
            writer.tag(1, WireType.LengthDelimited).string(message.text);
        let u = options.writeUnknownFields;
        if (u !== false)
            (u == true ? UnknownFieldHandler.onWrite : u)(this.typeName, message, writer);
        return writer;
    }
}
/**
 * @generated MessageType for protobuf message proto.SendMessageRequest
 */
export const SendMessageRequest = new SendMessageRequest$Type();
// @generated message type with reflection information, may provide speed optimized methods
class ReceiveMessageResponse$Type extends MessageType<ReceiveMessageResponse> {
    constructor() {
        super("proto.ReceiveMessageResponse", [
            { no: 1, name: "text", kind: "scalar", T: 9 /*ScalarType.STRING*/ },
            { no: 2, name: "from", kind: "scalar", T: 9 /*ScalarType.STRING*/ }
        ]);
    }
    create(value?: PartialMessage<ReceiveMessageResponse>): ReceiveMessageResponse {
        const message = { text: "", from: "" };
        globalThis.Object.defineProperty(message, MESSAGE_TYPE, { enumerable: false, value: this });
        if (value !== undefined)
            reflectionMergePartial<ReceiveMessageResponse>(this, message, value);
        return message;
    }
    internalBinaryRead(reader: IBinaryReader, length: number, options: BinaryReadOptions, target?: ReceiveMessageResponse): ReceiveMessageResponse {
        let message = target ?? this.create(), end = reader.pos + length;
        while (reader.pos < end) {
            let [fieldNo, wireType] = reader.tag();
            switch (fieldNo) {
                case /* string text */ 1:
                    message.text = reader.string();
                    break;
                case /* string from */ 2:
                    message.from = reader.string();
                    break;
                default:
                    let u = options.readUnknownField;
                    if (u === "throw")
                        throw new globalThis.Error(`Unknown field ${fieldNo} (wire type ${wireType}) for ${this.typeName}`);
                    let d = reader.skip(wireType);
                    if (u !== false)
                        (u === true ? UnknownFieldHandler.onRead : u)(this.typeName, message, fieldNo, wireType, d);
            }
        }
        return message;
    }
    internalBinaryWrite(message: ReceiveMessageResponse, writer: IBinaryWriter, options: BinaryWriteOptions): IBinaryWriter {
        /* string text = 1; */
        if (message.text !== "")
            writer.tag(1, WireType.LengthDelimited).string(message.text);
        /* string from = 2; */
        if (message.from !== "")
            writer.tag(2, WireType.LengthDelimited).string(message.from);
        let u = options.writeUnknownFields;
        if (u !== false)
            (u == true ? UnknownFieldHandler.onWrite : u)(this.typeName, message, writer);
        return writer;
    }
}
/**
 * @generated MessageType for protobuf message proto.ReceiveMessageResponse
 */
export const ReceiveMessageResponse = new ReceiveMessageResponse$Type();
/**
 * @generated ServiceType for protobuf service proto.Chat
 */
export const Chat = new ServiceType("proto.Chat", [
    { name: "Connect", options: {}, I: Empty, O: ConnectResponse },
    { name: "ReceiveMessages", serverStreaming: true, options: {}, I: Empty, O: ReceiveMessageResponse },
    { name: "SendMessage", options: {}, I: SendMessageRequest, O: Empty }
]);

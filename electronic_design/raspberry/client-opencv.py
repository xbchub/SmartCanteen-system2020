# !/usr/bin/python3
# -*- coding: utf-8 -*-

import cv2
import zmq
import base64
import time
from bluepy import btle
import numpy as np

import getPressure


def connect(ip, port):
    context = zmq.Context()
    socket = context.socket(zmq.PAIR)
    socket.connect("tcp://{}:{}".format(ip, port))
    return socket


def sendImg(socket, image):
    encoded, buffer = cv2.imencode('.jpg', image)
    jpg_as_text = base64.b64encode(buffer)
    socket.send(jpg_as_text)


def receive(socket):
    frame = socket.recv_string()
    return frame


def b64EncodeCV(frame):
    img = base64.b64decode(frame)
    npimg = np.frombuffer(img, dtype=np.uint8)
    return cv2.imdecode(npimg, 1)


def main():
    # init camera
    cap = cv2.VideoCapture(0)
        
    # init socket
    ip = '192.168.43.12'
    port = 8888
    socket = connect(ip, port)
    
    # init BLE
    # ble_address = "10:CE:A9:FD:9A:FC"
    ble_address = "20:CD:39:90:A5:81"
    p = btle.Peripheral(ble_address)
    readBLE = getPressure.MyDelegate(handle_num=5, sensor_num=3)
    p.setDelegate(readBLE)
    
    while True:
        weight_array, connection_closed = getPressure.readWeight(p, readBLE)
        
        if connection_closed:
            del p
            del readBLE
            p = btle.Peripheral(ble_address)
            readBLE = getPressure.MyDelegate(handle_num=5, sensor_num=3)
            p.setDelegate(readBLE)
            continue

        ret, frame = cap.read()
        if not ret:
            print("> No Camera")
            break
        
        sendImg(socket, frame)
        print("> image sent to server")
        socket.send_string(str(readBLE.weight_array.tolist()))
        print("> weights sent to server")
        
        received = receive(socket)
        try:
            error_code = int(received)
            print("> error code {} received from server".format(error_code))
            cv2.imshow('client', frame)
        except(ValueError):
            received = b64EncodeCV(received)
            print("> image received from server")
            cv2.imshow('received', received)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
        

    cap.release()
    cv2.destroyAllWindows()


if __name__ == '__main__':
    main()






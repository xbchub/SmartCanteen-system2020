# !/usr/bin/python3
# -*- coding: utf-8 -*-

from bluepy import btle
import time
import numpy as np


class MyDelegate(btle.DefaultDelegate):
    """
    监听与处理BLE设备Notification
    :param handle_num: data array length received
    :param sensor_num: numbers of sensors
    """
    def __init__(self, handle_num, sensor_num):
        btle.DefaultDelegate.__init__(self)
        self.handle_num = handle_num
        self.sensor_num = sensor_num
        self.weights_mat = np.full((sensor_num, handle_num), -85)
        self.weight_array = np.full(sensor_num, -85)
    
    def handleNotification(self, cHandle, datas):
        # received data should be {sensor1}_{sensor2}_{sensor3}
        datas = datas.decode('utf-8').split('_')
#         print(datas)
        datas = np.array(datas, dtype=np.int)
#         datas = str(datas)[5:].split('\\')[0]
#         datas = np.array([datas, datas, datas])
        # print("> received: {} N".format(data))
        try:
            self.weights_mat = refreshMat(self.weights_mat, datas)
            
            for i in range(self.weights_mat.shape[0]):
                self.weight_array[i] = dataFilter(
                    self.weights_mat[i, :])
        
        except(ValueError):
            # data不能从bytes转化为float，此时无数据，为STM32重启、正在设置BT05导致
            print("STM32 is setting up BT05, waiting for data...")
            time.sleep(0.1)


def refreshMat(data_mat, datas):
    # 更新当前array，刷新为最新数据
    data_mat= np.roll(data_mat, -1)
    data_mat[:, -1] = datas
    return data_mat


def dataFilter(data_array):
    if data_array.size <= 2:
        return np.mean(data_array)
    data_array = np.delete(data_array, [data_array.argmax(), data_array.argmin()])
    return np.mean(data_array)


def readWeight(p, readBLE):
    while True:
        try:
            print(readBLE.weights_mat)
            if p.waitForNotifications(0.2):
                # waiting for calling handleNotification()
                if np.any(np.isnan(readBLE.weight_array)):
                    continue
                return readBLE.weight_array, False
            time.sleep(0.1)
        
        except(btle.BTLEDisconnectError):
            print("Connection seems out, reconnecting...")
            time.sleep(0.1)
            return None, True
        except(KeyboardInterrupt, SystemExit):
            exit()

# def listen():
#     address = "10:CE:A9:FD:9A:FC"       # 实验用BT05
#     # address = "20:CD:39:90:A5:81"     # 远程调试的BT05
# 
#     while True:
#         p = btle.Peripheral(address)
#         readBLE = MyDelegate(handle_num=15)
#         p.setDelegate(readBLE)
#         while True:
#             try:
#                 print(readBLE.weights_dict)
#                 if p.waitForNotifications(0.01):
#                     # waiting for calling handleNotification()
#                     continue
#                 print("Waiting...")
#                 time.sleep(0.01)
#                 continue    # continue 2nd
#             except(btle.BTLEDisconnectError):
#                 print("Connection seems out, reconnecting...")
#                 time.sleep(0.1)
#                 break      # jump out the 2nd while, then continue 1st
#             except(KeyboardInterrupt, SystemExit):
#                 return
# 
# if __name__ == '__main__':
#     listen()

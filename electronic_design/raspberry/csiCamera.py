#!/usr/bin/python3
# -*- coding: utf-8 -*-
 
#通过网络发送图片给上位机，发送的格式为，先发送图片长度信息，然后再发送图像数据
 
import io
import picamera
import struct
import time


camera = picamera.PiCamera() #初始化摄像头
camera.resolution = (1440, 900) #设置分辨率
#摄像头预热
camera.start_preview()
# time.sleep(2)
# 
# #创建一个字节流
# stream = io.BytesIO()
# for foo in camera.capture_continuous(stream,'jpeg'): #连续捕获图像
#     #写图像长度信息到文件流，按照32bit无符号整数
#     #重定位指针位置
#     stream.seek(0) 
#     stream.truncate()
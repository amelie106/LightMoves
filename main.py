import cv2
import numpy as np
import time
import os
from cvzone.HandTrackingModule import HandDetector
import socket

# Path- new
folderPath = 'Header'
myList = os.listdir(folderPath)
overlayList = []
for imPath in myList:
    image = cv2.imread(f'{folderPath}/{imPath}')
    overlayList.append(image)

header = overlayList[0]

# Parameters
width, height = 1280, 720
cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)

# HandDetect
detector = HandDetector(maxHands=1, detectionCon=0.85)

# Communication
sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

while True:
    # Get frame
    success, img = cap.read()
    img = cv2.flip(img,1)

    # Find landmarks
    img[0:125, 0:1280] = header
    hands, img = detector.findHands(img)                #new
    lmList = detector.findPosition(img, draw = False)   #new

    if len(lmList)!=0:                                  #new
        print(lmList)
        x1,y1 = lmList[8][1:]    #Index
        x2, y2 = lmList[12][1:]  # Middle

    #Check which fingers are up
    tipIds = [4,8,12,16,20]
    fingers = []
    #thumb
    if lmList[tipIds[0]][1] < lmList[tipIds[0] - 1][1]:
        fingers.append(1)
    else:
        fingers.append(0)
    for id in range(1,5):
        if lmList[tipIds[id]][2] < lmList[tipIds[id] -2][2]:
            fingers.append(1)
        else:
            fingers.append(0)
    # Selection mode
    if fingers[1] and fingers[2]:
        
    #Drawing Mode
    if fingers[1] and fingers[2] == False:

    # Hands


    data = []
    # Landmark  values (x,y,z) *21
    if hands:
        # get first hands
        hand = hands[0]
        lmList = hand['lmList']
        for lm in lmList:
            data.extend([lm[0], height - lm[1], lm[2]])
        print(data)
        sock.sendto(str.encode(str(data)), serverAddressPort)

    cv2.imshow("Image", img)
    cv2.waitKey(1)

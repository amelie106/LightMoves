import cv2
import socket
from cvzone.HandTrackingModule import HandDetector

if __name__ == "__main__":
    cap = cv2.VideoCapture(0)

    # HandDetect
    detector = HandDetector(maxHands=1, detectionCon=0.85)

    # Communication
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    serverAddressPort = ("127.0.0.1", 5052)

    while True:
        # Get frame
        success, img = cap.read()
        img = cv2.flip(img,1)

        # Find landmarks
        hands, img = detector.findHands(img)

        data = []
        if hands:
            # Get first hand
            hand = hands[0]
            lmList = hand['lmList']
            data.extend([lmList[0][0], cap.get(4) - lmList[0][1]])
            sock.sendto(str.encode(str(data)), serverAddressPort)

        print(data)

        cv2.imshow("Image", img)
        cv2.waitKey(1)
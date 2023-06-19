import cv2
import socket
import mediapipe as mp
 
class HandDetector():
    
    mpHands = mp.solutions.hands
    mpDraw = mp.solutions.drawing_utils
    hands = mpHands.Hands(static_image_mode=False,
                          max_num_hands=2,
                          model_complexity=1,
                          min_detection_confidence=0.5)
    tipIds = [8, 12, 16, 20]
 
    def findHands(self, img, draw=True):
        imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
        self.results = self.hands.process(imgRGB)

        if self.results.multi_hand_landmarks:
            for handLms in self.results.multi_hand_landmarks:
                if draw:
                    self.mpDraw.draw_landmarks(img, handLms,
                    self.mpHands.HAND_CONNECTIONS)

        return img

    def findPosition(self, img, handNo=0, draw=True):
        self.lmList = []

        if self.results.multi_hand_landmarks:
            myHand = self.results.multi_hand_landmarks[handNo]
            for id, lm in enumerate(myHand.landmark):
                h, w, c = img.shape
                cx, cy = int(lm.x * w), int(lm.y * h)
                self.lmList.append([id, cx, cy])
                if draw:
                    cv2.circle(img, (cx, cy), 5, (255, 0, 255), cv2.FILLED)

        return self.lmList

    def fingersUp(self):
        fingers = []
        
        try:
            for id in self.tipIds:
                if self.lmList[id][2] < self.lmList[id - 2][2]:
                    fingers.append(1)
                else:
                    fingers.append(0)
        except:
            fingers = [0,0,0,0]

        return fingers


if __name__ == "__main__":
    # Capture and detect
    cap = cv2.VideoCapture(0)
    detector = HandDetector()

    # Communication
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    serverAddressPort = ("127.0.0.1", 5052)

    while True:
        # Read data
        success, img = cap.read()
        img = detector.findHands(img)
        lmList = detector.findPosition(img)
        fingers = detector.fingersUp()

        # Send data
        sock.sendto(str.encode(str(fingers)), serverAddressPort)

        # Log & show video
        if len(lmList) != 0:
            print(lmList[4])

        cv2.putText(img, str(fingers), (10, 70), cv2.FONT_HERSHEY_PLAIN, 3,
                    (255, 0, 255), 3)

        cv2.imshow("Image", img)
        cv2.waitKey(1)

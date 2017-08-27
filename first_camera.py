import numpy as np
import cv2

cap = cv2.VideoCapture(0)
while(True):
    # จับภาพแบบ frame by frame
    ret, frame = cap.read()
        # ตรงนี้ผมจะแสดงภาพออกมาเป็นขาวดำ โดยคำนวนผ่าน function cvtColor
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # แสดงผล frame ที่เป็นขาวดำครับ
    cv2.imshow('first_camera', gray)
    if cv2.waitKey(1) & 0xFF == ord('q'): # หน้าจอ จะปิดก็ต่อเมื่อ ผมกด q
        break

cap.release()
cv2.destroyAllWindows()